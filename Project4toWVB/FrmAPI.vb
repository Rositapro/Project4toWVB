Imports System.Net.Http
Imports System.Text.Json
Imports System.Diagnostics
Public Class FrmAPI
    Private Const api As String = "https://api.nasa.gov/planetary/apod"
    Private Const key As String = "dlI71b7WG1efSkePYdr6zw61QSrjIMqqDQDn7GTQ"
    Private ReadOnly _httpClient As New HttpClient()

    Private Async Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cbMonth.SelectedIndex < 0 Then
            MessageBox.Show("Selecciona un mes.")
            Return
        End If

        Dim selectedMonth As Integer = cbMonth.SelectedIndex + 1
        Dim year As Integer = DateTime.Now.Year

        Dim startDate As New DateTime(year, selectedMonth, 1)
        Dim endDate As DateTime = startDate.AddMonths(1).AddDays(-1)

        Dim url As String = $"{api}?api_key={key}&start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}"

        Try
            Dim json As String = Await _httpClient.GetStringAsync(url)
            Dim result = JsonSerializer.Deserialize(Of List(Of ApodResponse))(json)

            If result IsNot Nothing Then
                dgvData.DataSource = result
                dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

                If TypeOf dgvData.Columns("url") IsNot DataGridViewLinkColumn Then
                    Dim colIndex As Integer = dgvData.Columns("url").Index
                    dgvData.Columns.Remove("url")
                    Dim linkCol As New DataGridViewLinkColumn With {
                        .Name = "url",
                        .HeaderText = "Imagen",
                        .DataPropertyName = "url",
                        .UseColumnTextForLinkValue = False,
                        .LinkBehavior = LinkBehavior.SystemDefault
                    }
                    dgvData.Columns.Insert(colIndex, linkCol)
                End If
            Else
                MessageBox.Show("No se encontraron datos para ese mes.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al obtener los datos: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        If e.RowIndex >= 0 AndAlso dgvData.Columns(e.ColumnIndex).Name = "url" Then
            Dim cellValue = dgvData.Rows(e.RowIndex).Cells(e.ColumnIndex).Value?.ToString()
            If Not String.IsNullOrEmpty(cellValue) Then
                Try
                    Process.Start(New ProcessStartInfo With {
                        .FileName = cellValue,
                        .UseShellExecute = True
                    })
                Catch ex As Exception
                    MessageBox.Show("No se pudo abrir el enlace: " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub FrmAPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbMonth.Items.AddRange(New String() {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        })
        cbMonth.SelectedIndex = 0
    End Sub

    Private Sub btnGoBack_Click(sender As Object, e As EventArgs) Handles btnGoBack.Click
        Dim menu As New FrmMenu()
        menu.Show()
        Me.Close()
    End Sub

    Public Class ApodResponse
        Public Property title As String
        Public Property [date] As String
        Public Property explanation As String
        Public Property url As String
        Public Property media_type As String
    End Class

End Class
