Imports LiveCharts.Definitions.Charts
Imports MailKit.Net.Smtp
Imports Microsoft.Data.SqlClient
Imports MimeKit
Imports QuestPDF.Drawing
Imports QuestPDF.Elements
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure
Imports ScottPlot
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.Json
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Xml.Linq
Imports PdfColors = QuestPDF.Helpers.Colors
Imports ScottPlotColors = ScottPlot.Colors

Public Class FrmDataSet
    Private allRows As New List(Of String())
    Private connectionString As String = "Server=localhost\SQLEXPRESS;Database=NASA;Trusted_connection=yes;TrustServerCertificate=true"

    Public Sub New()
        InitializeComponent()

        cmbViewOption.Items.Clear()
        cmbViewOption.Items.AddRange(New String() {"Table", "Txt plain"})
        cmbViewOption.SelectedIndex = 0
        AddHandler cmbViewOption.SelectedIndexChanged, AddressOf cmbViewOption_SelectedIndexChanged

        txtPlainText.Visible = False
        AddHandler Me.Load, AddressOf Form2_Load
        AddHandler btnFilterClass.Click, AddressOf btnFilterClass_Click
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs)
        cmbClassFilter.Items.Clear()
        cmbClassFilter.Items.AddRange(New String() {"ALL", "STAR", "GALAXY", "QSO"})
        cmbClassFilter.SelectedIndex = 0

        cmbExportFormat.Items.Clear()
        cmbExportFormat.Items.AddRange(New String() {"CSV", "TXT", "JSON", "XML"})
        cmbExportFormat.SelectedIndex = 0

        cmbDeleteType.Items.Clear()
        cmbDeleteType.Items.AddRange(New String() {"Row", "Column"})
        cmbDeleteType.SelectedIndex = 0
    End Sub
    Private Sub cmbViewOption_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim optionSelected As String = cmbViewOption.SelectedItem.ToString()

        If optionSelected = "Txt plain" Then
            txtPlainText.Text = ConvertToPlainText()
            txtPlainText.Visible = True
            dgvData.Visible = False
        ElseIf optionSelected = "Table" Then
            txtPlainText.Visible = False
            dgvData.Visible = True
        End If
    End Sub
    Private Function ConvertToPlainText() As String
        Dim sb As New StringBuilder()

        ' Encabezados
        Dim headers = dgvData.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.HeaderText)
        sb.AppendLine(String.Join(vbTab, headers)) ' Usa tabulación para separar

        ' Filas
        For Each row As String() In allRows
            sb.AppendLine(String.Join(vbTab, row))
        Next

        Return sb.ToString()
    End Function

    Private Sub btnFilterClass_Click(sender As Object, e As EventArgs)
        Dim filtroSeleccionado As String = cmbClassFilter.SelectedItem.ToString()
        Dim indexClass As Integer = dgvData.Columns.Cast(Of DataGridViewColumn)().
        Where(Function(col) col.HeaderText.Equals("class", StringComparison.OrdinalIgnoreCase)).
        Select(Function(col) col.Index).FirstOrDefault()

        If indexClass = -1 Then
            MessageBox.Show("No se encontró la columna 'class'.")
            Return
        End If

        If filtroSeleccionado.Equals("ALL", StringComparison.OrdinalIgnoreCase) Then
            DisplayRows(allRows)
            Return
        End If

        Dim filasFiltradas = allRows.Where(Function(row) row.Length > indexClass AndAlso
        row(indexClass).Equals(filtroSeleccionado, StringComparison.OrdinalIgnoreCase)).ToList()

        DisplayRows(filasFiltradas)
    End Sub
    Private Sub LoadSQLData()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Consulta SQL para obtener todos los registros de la tabla dbo.Skyserver
                Dim query As String = "SELECT * FROM dbo.Skyserver"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()

                        dgvData.Rows.Clear()
                        dgvData.Columns.Clear()
                        allRows.Clear() ' Limpiar los datos almacenados en memoria

                        ' Agregar columnas al DataGridView
                        For i As Integer = 0 To reader.FieldCount - 1
                            dgvData.Columns.Add(reader.GetName(i), reader.GetName(i))
                        Next

                        ' Cargar filas en allRows y en el DataGridView
                        While reader.Read()
                            Dim row(reader.FieldCount - 1) As String
                            For i As Integer = 0 To reader.FieldCount - 1
                                row(i) = reader(i).ToString()
                            Next

                            allRows.Add(row)
                            dgvData.Rows.Add(row)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos desde la base de datos: " & ex.Message)
        End Try
    End Sub


    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim openFileDialog As New OpenFileDialog With {
        .Filter = "CSV and TXT files (*.csv;*.txt)|*.csv;*.txt",
        .Title = "Open file"
    }

        If openFileDialog.ShowDialog() <> DialogResult.OK Then Exit Sub

        Dim filePath As String = openFileDialog.FileName

        Try
            Dim lines = File.ReadAllLines(filePath)

            dgvData.Rows.Clear()
            dgvData.Columns.Clear()
            allRows.Clear()

            If lines.Length > 0 Then
                Dim delimiter As Char = ","c
                Dim headers = lines(0).Split(delimiter)
                For Each header In headers
                    dgvData.Columns.Add(header, header)
                Next

                For i As Integer = 1 To lines.Length - 1
                    Dim row = lines(i).Split(delimiter)
                    allRows.Add(row)
                Next

                DisplayRows(allRows)
                LlenarTreeView(allRows)
                CountData()
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub
    Private Sub DisplayRows(rows As List(Of String()))
        dgvData.Rows.Clear()
        For Each row In rows
            dgvData.Rows.Add(row)
        Next
    End Sub

    Private Sub LlenarTreeView(rows As List(Of String()))
        treeView.Nodes.Clear()

        Dim gruposPorClase = rows.GroupBy(Function(row) row(ObtenerIndiceColumna("class"))).ToList()

        For Each grupoClase In gruposPorClase
            Dim nodoClase As New TreeNode(grupoClase.Key)
            treeView.Nodes.Add(nodoClase)

            Dim gruposPorObjid = grupoClase.GroupBy(Function(row) row(ObtenerIndiceColumna("objid"))).ToList()

            For Each grupoObjid In gruposPorObjid
                Dim nodoObjid As New TreeNode($"Objid: {grupoObjid.Key}")
                nodoClase.Nodes.Add(nodoObjid)

                For Each item In grupoObjid
                    Dim ra As String = item(ObtenerIndiceColumna("ra"))
                    Dim dec As String = item(ObtenerIndiceColumna("dec"))
                    Dim nodoCoords As New TreeNode($"RA: {ra}, DEC: {dec}")
                    nodoObjid.Nodes.Add(nodoCoords)
                Next
            Next
        Next
    End Sub

    Private Function ObtenerIndiceColumna(nombreColumna As String) As Integer
        Dim encabezados = dgvData.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.HeaderText).ToList()
        Return encabezados.IndexOf(nombreColumna)
    End Function
    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If cmbExportFormat.SelectedItem Is Nothing Then Return

        Dim formato As String = cmbExportFormat.SelectedItem.ToString()
        Dim saveFileDialog As New SaveFileDialog()

        Select Case formato
            Case "CSV"
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv"
                saveFileDialog.Title = "Exportar a CSV"
            Case "TXT"
                saveFileDialog.Filter = "TXT files (*.txt)|*.txt"
                saveFileDialog.Title = "Exportar a TXT"
            Case "JSON"
                saveFileDialog.Filter = "JSON files (*.json)|*.json"
                saveFileDialog.Title = "Exportar a JSON"
            Case "XML"
                saveFileDialog.Filter = "XML files (*.xml)|*.xml"
                saveFileDialog.Title = "Exportar a XML"
        End Select

        If saveFileDialog.ShowDialog() <> DialogResult.OK Then Return

        Dim ruta = saveFileDialog.FileName

        Try
            Select Case formato
                Case "CSV"
                    GuardarArchivoCSV(ruta)
                Case "TXT"
                    GuardarArchivoTXT(ruta)
                Case "JSON"
                    ExportarAJSON(ruta)
                Case "XML"
                    ExportarAXML(ruta)
            End Select

            MessageBox.Show($"Archivo exportado correctamente en formato {formato}.")
            Process.Start(New ProcessStartInfo() With {.FileName = ruta, .UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Error exportando archivo: " & ex.Message)
        End Try
    End Sub

    Public Sub GuardarArchivoCSV(ruta As String)
        Dim lines As New List(Of String)
        Dim headers = dgvData.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.HeaderText)
        lines.Add(String.Join(",", headers))

        For Each row As DataGridViewRow In dgvData.Rows
            If Not row.IsNewRow Then
                Dim cells = row.Cells.Cast(Of DataGridViewCell)().Select(Function(cell) EscapeForCsv(cell.Value?.ToString()))
                lines.Add(String.Join(",", cells))
            End If
        Next

        File.WriteAllLines(ruta, lines)
    End Sub

    Private Function EscapeForCsv(value As String) As String
        If value.Contains(",") OrElse value.Contains("""") OrElse value.Contains(vbLf) Then
            value = value.Replace("""", """""")
            Return $"""{value}"""
        End If
        Return value
    End Function
    Public Sub GuardarArchivoTXT(ruta As String)
        Dim lines As New List(Of String)
        Dim headers = dgvData.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.HeaderText)
        lines.Add(String.Join(vbTab, headers))

        For Each row As DataGridViewRow In dgvData.Rows
            If Not row.IsNewRow Then
                Dim cells = row.Cells.Cast(Of DataGridViewCell)().Select(Function(cell) cell.Value?.ToString())
                lines.Add(String.Join(vbTab, cells))
            End If
        Next

        File.WriteAllLines(ruta, lines)
    End Sub
    Public Sub ExportarAJSON(ruta As String)
        Dim listaObjetos As New List(Of Dictionary(Of String, String))

        For Each row As DataGridViewRow In dgvData.Rows
            If Not row.IsNewRow Then
                Dim dict As New Dictionary(Of String, String)
                For Each col As DataGridViewColumn In dgvData.Columns
                    Dim valor = If(row.Cells(col.Index).Value?.ToString(), "")
                    dict(col.HeaderText) = valor
                Next
                listaObjetos.Add(dict)
            End If
        Next

        Dim opciones As New JsonSerializerOptions With {.WriteIndented = True}
        Dim jsonString As String = JsonSerializer.Serialize(listaObjetos, opciones)

        File.WriteAllText(ruta, jsonString)
    End Sub
    Public Sub ExportarAXML(ruta As String)
        Dim root As New XElement("Registros")

        For Each row As DataGridViewRow In dgvData.Rows
            If Not row.IsNewRow Then
                Dim registro As New XElement("Registro")
                For Each col As DataGridViewColumn In dgvData.Columns
                    Dim valor = If(row.Cells(col.Index).Value?.ToString(), "")
                    registro.Add(New XElement(col.HeaderText, valor))
                Next
                root.Add(registro)
            End If
        Next

        Dim doc As New XDocument(root)
        doc.Save(ruta)
    End Sub
    Private Sub EnviarCorreo(toEmail As String, subject As String, body As String, filePath As String)
        If Not File.Exists(filePath) Then
            MessageBox.Show("El archivo adjunto no existe.")
            Return
        End If

        Dim message = New MimeMessage()
        message.From.Add(New MailboxAddress("Rosalinda", "rosalindacedillo2017@gmail.com"))
        message.To.Add(MailboxAddress.Parse(toEmail))
        message.Subject = subject

        Dim builder As New BodyBuilder With {
        .TextBody = body
    }
        builder.Attachments.Add(filePath)
        message.Body = builder.ToMessageBody()

        Try
            Using client As New SmtpClient()
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls)
                client.Authenticate("rosalindacedillo2017@gmail.com", "rqcs laqq upjg rypk")
                client.Send(message)
                client.Disconnect(True)
            End Using

            MessageBox.Show("Email sent successfully.")
        Catch ex As Exception
            MessageBox.Show("Error al enviar el correo: " & ex.Message)
        End Try
    End Sub
    Private Sub btnEnviarArchivo_Click(sender As Object, e As EventArgs) Handles btnEnviarArchivo.Click
        Dim openFileDialog As New OpenFileDialog With {
        .Filter = "CSV files (*.csv)|*.csv|TXT files (*.txt)|*.txt|JSON files (*.json)|*.json|XML files (*.xml)|*.xml|PDF files (*.pdf)|*.pdf",
        .Title = "Seleccionar archivo para enviar por correo"
    }

        If openFileDialog.ShowDialog() <> DialogResult.OK Then Return

        Dim ruta As String = openFileDialog.FileName

        If Not File.Exists(ruta) Then
            MessageBox.Show("El archivo seleccionado no existe.")
            Return
        End If

        Try
            EnviarCorreo("rosalindacedillo2017@gmail.com", "Archivo Exportado", "Aquí está el archivo exportado.", ruta)
        Catch ex As Exception
            MessageBox.Show("Error al enviar el correo: " & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvData.CurrentCell Is Nothing Then
            MessageBox.Show("Select a cell to delete the corresponding row or column.")
            Return
        End If

        Dim opcion As String = cmbDeleteType.SelectedItem.ToString()

        If opcion = "Row" Then
            Dim rowIndex As Integer = dgvData.CurrentCell.RowIndex

            Dim confirm = MessageBox.Show($"¿Delete fila {rowIndex + 1}?", "Confirm deletion", MessageBoxButtons.YesNo)
            If confirm = DialogResult.Yes Then
                dgvData.Rows.RemoveAt(rowIndex)
                CountData()
                If rowIndex < allRows.Count Then allRows.RemoveAt(rowIndex)
            End If

        ElseIf opcion = "Column" Then
            Dim colIndex As Integer = dgvData.CurrentCell.ColumnIndex
            Dim colName As String = dgvData.Columns(colIndex).HeaderText

            Dim confirm = MessageBox.Show($"¿Delete column '{colName}'?", "Confirm deletion", MessageBoxButtons.YesNo)
            If confirm = DialogResult.Yes Then
                dgvData.Columns.RemoveAt(colIndex)

                ' También eliminar columna de allRows
                For i As Integer = 0 To allRows.Count - 1
                    Dim listRow = allRows(i).ToList()
                    If colIndex < listRow.Count Then listRow.RemoveAt(colIndex)
                    allRows(i) = listRow.ToArray()
                Next
            End If
        End If
    End Sub
    Private Sub btnClearData_Click(sender As Object, e As EventArgs) Handles btnClearData.Click
        Dim confirmResult = MessageBox.Show("¿Seguro que quieres limpiar toda la tabla?",
                                        "Confirmar limpieza",
                                        MessageBoxButtons.YesNo)

        If confirmResult = DialogResult.Yes Then
            dgvData.Rows.Clear()
            dgvData.Columns.Clear()
            allRows.Clear()
        End If
    End Sub

    Private Sub btnGraphics_Click(sender As Object, e As EventArgs) Handles btnGraphics.Click
        If allRows.Count = 0 Then
            MessageBox.Show("No hay datos cargados.")
            Return
        End If

        Try
            Dim conteos As New Dictionary(Of String, Integer) From {
                {"STAR", 0},
                {"GALAXY", 0},
                {"QSO", 0}
            }

            For Each fila In allRows
                If fila.Length > 13 Then
                    Dim clase As String = fila(13).Trim().ToUpper()
                    If conteos.ContainsKey(clase) Then conteos(clase) += 1
                End If
            Next

            Dim etiquetas() As String = conteos.Keys.ToArray()
            Dim valores() As Double = conteos.Values.Select(Function(v) CDbl(v)).ToArray()

            GraphicPie(etiquetas, valores)
        Catch ex As Exception
            MessageBox.Show("Error al graficar: " & ex.Message)
        End Try
    End Sub

    Private Sub GraphicPie(etiquetas As String(), valores As Double())
        Dim plt = formsPlot1.Plot
        plt.Clear()

        Dim pie = plt.Add.Pie(valores)

        Dim total As Double = valores.Sum()
        pie.ExplodeFraction = 0.1
        pie.SliceLabelDistance = 0.5

        For i As Integer = 0 To Math.Min(pie.Slices.Count, etiquetas.Length) - 1
            pie.Slices(i).LabelFontSize = 16
            pie.Slices(i).Label = $"{valores(i)}"
            pie.Slices(i).LegendText = $"{etiquetas(i)} ({valores(i) / total:P1})"
        Next

        pie.DonutFraction = 0
        pie.Rotation = ScottPlot.Angle.FromDegrees(0)

        plt.Axes.Frameless()
        plt.HideGrid()

        formsPlot1.Refresh()
    End Sub

    Private Sub btnScatterPlot_Click(sender As Object, e As EventArgs) Handles btnScatterPlot.Click
        If allRows.Count = 0 Then
            MessageBox.Show("There are no data loaded.")
            Return
        End If

        Try
            Dim raList As New List(Of Double)()
            Dim decList As New List(Of Double)()
            Dim count As Integer = 0

            For Each fila In allRows
                If fila.Length > 13 AndAlso fila(13).Trim().ToUpper() = "STAR" Then
                    Dim ra As Double
                    Dim dec As Double
                    If Double.TryParse(fila(1), ra) AndAlso Double.TryParse(fila(2), dec) Then
                        raList.Add(ra)
                        decList.Add(dec)
                        count += 1
                    End If
                    If count >= 1000 Then Exit For
                End If
            Next

            Dim plt = formsPlot2.Plot
            plt.Clear()

            Dim scatter = plt.Add.ScatterPoints(raList.ToArray(), decList.ToArray())
            scatter.MarkerSize = 5
            scatter.Color = ScottPlot.Colors.Blue
            scatter.MarkerShape = MarkerShape.FilledCircle

            plt.Title("Primeras 1000 Estrellas (RA vs DEC)")
            plt.XLabel("Ascensión Recta (ra)")
            plt.YLabel("Declinación (dec)")
            plt.Axes.SetLimits(0, 360, -90, 90)

            formsPlot2.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error in graphing stars: " & ex.Message)
        End Try
    End Sub
    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click


    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim texto As String = txtSearch.Text.Trim().ToLower()
        Dim coincidencias As Integer = 0

        For Each row As DataGridViewRow In dgvData.Rows
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value IsNot Nothing AndAlso cell.Value.ToString().ToLower().Contains(texto) Then
                    cell.Style.BackColor = System.Drawing.Color.LightPink
                    coincidencias += 1
                Else
                    cell.Style.BackColor = System.Drawing.Color.White
                End If
            Next
        Next

        MessageBox.Show($"{coincidencias} coincidencias encontradas.")
    End Sub
    Private Sub btnRedshift_Click(sender As Object, e As EventArgs) Handles btnRedshift.Click
        Dim indexRedshift As Integer = -1

        For Each col As DataGridViewColumn In dgvData.Columns
            If col.HeaderText.Equals("redshift", StringComparison.OrdinalIgnoreCase) Then
                indexRedshift = col.Index
                Exit For
            End If
        Next

        If indexRedshift = -1 Then
            MessageBox.Show("The column 'redshift' was not found.")
            Return
        End If

        Dim OrdererRow As List(Of String())

        If rbClose.Checked Then
            OrdererRow = allRows.
            Where(Function(row) row.Length > indexRedshift AndAlso Double.TryParse(row(indexRedshift), Nothing)).
            OrderBy(Function(row) Double.Parse(row(indexRedshift))).ToList()

            MessageBox.Show("Sorted by closest objects (low redshift).")
        ElseIf rbDistant.Checked Then
            OrdererRow = allRows.
            Where(Function(row) row.Length > indexRedshift AndAlso Double.TryParse(row(indexRedshift), Nothing)).
            OrderByDescending(Function(row) Double.Parse(row(indexRedshift))).ToList()

            MessageBox.Show("Sorted by most distant objects (high redshift).")
        Else
            MessageBox.Show("Select an order option: Near or Far.")
            Return
        End If

        DisplayRows(OrdererRow)
        CountData()
    End Sub
    Private Sub CountData()
        Dim total As Integer = dgvData.Rows.Cast(Of DataGridViewRow)().Count(Function(r) Not r.IsNewRow)
        lblData.Text = $"Data: {total}"
    End Sub

    Private Sub btnsqlDate_Click(sender As Object, e As EventArgs) Handles btnsqlDate.Click
        LoadSQLData()
    End Sub

    Private Sub btnSaveSqlChanges_Click(sender As Object, e As EventArgs) Handles btnSaveSqlChanges.Click
        Try
            pgb.Visible = True
            pgb.Value = 0
            pgb.Maximum = dgvData.Rows.Count - 1
            lblProgress.Text = "Processing..."

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim checkTableQuery As String = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Skyserver_Updated' AND xtype = 'U') " &
                                            "BEGIN " &
                                            "CREATE TABLE dbo.Skyserver_Updated (" &
                                            "objid FLOAT, ra FLOAT, dec FLOAT, u FLOAT, g FLOAT, r FLOAT, i FLOAT, z FLOAT, " &
                                            "run INT, rerun INT, camcol INT, field INT, specobjid FLOAT, class VARCHAR(50), " &
                                            "redshift FLOAT, plate INT, mjd INT, fiberid INT) " &
                                            "END"

                Using command As New SqlCommand(checkTableQuery, connection)
                    command.ExecuteNonQuery()
                End Using

                Dim dataTable As New DataTable()
                dataTable.Columns.Add("objid", GetType(Double))
                dataTable.Columns.Add("ra", GetType(Double))
                dataTable.Columns.Add("dec", GetType(Double))
                dataTable.Columns.Add("u", GetType(Double))
                dataTable.Columns.Add("g", GetType(Double))
                dataTable.Columns.Add("r", GetType(Double))
                dataTable.Columns.Add("i", GetType(Double))
                dataTable.Columns.Add("z", GetType(Double))
                dataTable.Columns.Add("run", GetType(Integer))
                dataTable.Columns.Add("rerun", GetType(Integer))
                dataTable.Columns.Add("camcol", GetType(Integer))
                dataTable.Columns.Add("field", GetType(Integer))
                dataTable.Columns.Add("specobjid", GetType(Double))
                dataTable.Columns.Add("class", GetType(String))
                dataTable.Columns.Add("redshift", GetType(Double))
                dataTable.Columns.Add("plate", GetType(Integer))
                dataTable.Columns.Add("mjd", GetType(Integer))
                dataTable.Columns.Add("fiberid", GetType(Integer))

                For Each row As DataGridViewRow In dgvData.Rows
                    If Not row.IsNewRow Then
                        Dim dataRow As DataRow = dataTable.NewRow()
                        dataRow("objid") = ValidateConvertDouble(row.Cells("objid").Value)
                        dataRow("ra") = ValidateConvertDouble(row.Cells("ra").Value)
                        dataRow("dec") = ValidateConvertDouble(row.Cells("dec").Value)
                        dataRow("u") = ValidateConvertDouble(row.Cells("u").Value)
                        dataRow("g") = ValidateConvertDouble(row.Cells("g").Value)
                        dataRow("r") = ValidateConvertDouble(row.Cells("r").Value)
                        dataRow("i") = ValidateConvertDouble(row.Cells("i").Value)
                        dataRow("z") = ValidateConvertDouble(row.Cells("z").Value)
                        dataRow("run") = row.Cells("run").Value
                        dataRow("rerun") = row.Cells("rerun").Value
                        dataRow("camcol") = row.Cells("camcol").Value
                        dataRow("field") = row.Cells("field").Value
                        dataRow("specobjid") = ValidateConvertDouble(row.Cells("specobjid").Value)
                        dataRow("class") = row.Cells("class").Value
                        dataRow("redshift") = ValidateConvertDouble(row.Cells("redshift").Value)
                        dataRow("plate") = row.Cells("plate").Value
                        dataRow("mjd") = row.Cells("mjd").Value
                        dataRow("fiberid") = row.Cells("fiberid").Value

                        dataTable.Rows.Add(dataRow)
                    End If

                    If pgb.Value < pgb.Maximum Then
                        pgb.Value += 1
                    Else
                        pgb.Value = pgb.Maximum
                    End If
                Next

                Using bulkCopy As New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "dbo.Skyserver_Updated"
                    bulkCopy.WriteToServer(dataTable)
                End Using

                MessageBox.Show("Loaded correctly.")
            End Using

        Catch ex As Exception
            MessageBox.Show("Error creating the table or inserting the data: " & ex.Message)
        Finally
            pgb.Visible = False
            lblProgress.Visible = False
        End Try
    End Sub

    Private Function ValidateConvertDouble(value As Object) As Double
        Dim result As Double
        If value IsNot Nothing AndAlso Double.TryParse(value.ToString(), result) Then
            Return result
        End If
        Return 0.0
    End Function

    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click

    End Sub


End Class