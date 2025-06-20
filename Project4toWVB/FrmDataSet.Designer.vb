<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataSet
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblProgress = New Label()
        btnEnviarArchivo = New Button()
        txtPlainText = New TextBox()
        treeView = New TreeView()
        dgvData = New DataGridView()
        pgb = New ProgressBar()
        groupBox3 = New GroupBox()
        btnSaveSqlChanges = New Button()
        cmbExportFormat = New ComboBox()
        btnExport = New Button()
        btnExportPDF = New Button()
        groupBox2 = New GroupBox()
        btnOpen = New Button()
        btnsqlDate = New Button()
        groupBox1 = New GroupBox()
        cmbDeleteType = New ComboBox()
        btnDelete = New Button()
        btnClearData = New Button()
        groupBox4 = New GroupBox()
        lblView = New Label()
        cmbViewOption = New ComboBox()
        rbDistant = New RadioButton()
        btnSearch = New Button()
        btnRedshift = New Button()
        rbClose = New RadioButton()
        txtSearch = New TextBox()
        btnGoBack = New Button()
        cmbClassFilter = New ComboBox()
        btnFilterClass = New Button()
        label1 = New Label()
        lblData = New Label()
        groupBox5 = New GroupBox()
        btnGraphics = New Button()
        btnScatterPlot = New Button()
        formsPlot2 = New ScottPlot.WinForms.FormsPlot()
        formsPlot1 = New ScottPlot.WinForms.FormsPlot()
        CType(dgvData, ComponentModel.ISupportInitialize).BeginInit()
        groupBox3.SuspendLayout()
        groupBox2.SuspendLayout()
        groupBox1.SuspendLayout()
        groupBox4.SuspendLayout()
        groupBox5.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblProgress
        ' 
        lblProgress.AutoSize = True
        lblProgress.Location = New Point(26, 440)
        lblProgress.Name = "lblProgress"
        lblProgress.Size = New Size(0, 25)
        lblProgress.TabIndex = 66
        ' 
        ' btnEnviarArchivo
        ' 
        btnEnviarArchivo.Font = New Font("Yu Gothic UI", 11.25F)
        btnEnviarArchivo.Location = New Point(291, 557)
        btnEnviarArchivo.Name = "btnEnviarArchivo"
        btnEnviarArchivo.Size = New Size(110, 50)
        btnEnviarArchivo.TabIndex = 64
        btnEnviarArchivo.Text = "Email"
        btnEnviarArchivo.UseVisualStyleBackColor = True
        ' 
        ' txtPlainText
        ' 
        txtPlainText.Location = New Point(1436, 146)
        txtPlainText.Multiline = True
        txtPlainText.Name = "txtPlainText"
        txtPlainText.ScrollBars = ScrollBars.Vertical
        txtPlainText.Size = New Size(344, 393)
        txtPlainText.TabIndex = 63
        txtPlainText.Visible = False
        ' 
        ' treeView
        ' 
        treeView.Location = New Point(961, 146)
        treeView.Name = "treeView"
        treeView.Size = New Size(469, 393)
        treeView.TabIndex = 62
        ' 
        ' dgvData
        ' 
        dgvData.BackgroundColor = SystemColors.ControlLight
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvData.Location = New Point(291, 146)
        dgvData.Margin = New Padding(4, 5, 4, 5)
        dgvData.Name = "dgvData"
        dgvData.RowHeadersWidth = 62
        dgvData.Size = New Size(663, 393)
        dgvData.TabIndex = 61
        ' 
        ' pgb
        ' 
        pgb.Location = New Point(15, 468)
        pgb.Name = "pgb"
        pgb.Size = New Size(232, 34)
        pgb.TabIndex = 60
        pgb.Visible = False
        ' 
        ' groupBox3
        ' 
        groupBox3.Controls.Add(btnSaveSqlChanges)
        groupBox3.Controls.Add(cmbExportFormat)
        groupBox3.Controls.Add(btnExport)
        groupBox3.Controls.Add(btnExportPDF)
        groupBox3.Location = New Point(13, 239)
        groupBox3.Margin = New Padding(4, 5, 4, 5)
        groupBox3.Name = "groupBox3"
        groupBox3.Padding = New Padding(4, 5, 4, 5)
        groupBox3.Size = New Size(260, 192)
        groupBox3.TabIndex = 59
        groupBox3.TabStop = False
        groupBox3.Text = "Exportar"
        ' 
        ' btnSaveSqlChanges
        ' 
        btnSaveSqlChanges.Font = New Font("Yu Gothic UI", 11.25F)
        btnSaveSqlChanges.Location = New Point(13, 100)
        btnSaveSqlChanges.Margin = New Padding(4, 5, 4, 5)
        btnSaveSqlChanges.Name = "btnSaveSqlChanges"
        btnSaveSqlChanges.Size = New Size(110, 76)
        btnSaveSqlChanges.TabIndex = 41
        btnSaveSqlChanges.Text = "Changes SQL"
        btnSaveSqlChanges.UseVisualStyleBackColor = True
        ' 
        ' cmbExportFormat
        ' 
        cmbExportFormat.Font = New Font("Yu Gothic UI", 11.25F)
        cmbExportFormat.FormattingEnabled = True
        cmbExportFormat.Location = New Point(8, 32)
        cmbExportFormat.Name = "cmbExportFormat"
        cmbExportFormat.Size = New Size(129, 39)
        cmbExportFormat.TabIndex = 16
        ' 
        ' btnExport
        ' 
        btnExport.Font = New Font("Yu Gothic UI", 11.25F)
        btnExport.Location = New Point(143, 32)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(110, 50)
        btnExport.TabIndex = 17
        btnExport.Text = "Export"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnExportPDF
        ' 
        btnExportPDF.Font = New Font("Yu Gothic UI", 11.25F)
        btnExportPDF.Location = New Point(143, 100)
        btnExportPDF.Name = "btnExportPDF"
        btnExportPDF.Size = New Size(110, 76)
        btnExportPDF.TabIndex = 27
        btnExportPDF.Text = "Export PDF"
        btnExportPDF.UseVisualStyleBackColor = True
        ' 
        ' groupBox2
        ' 
        groupBox2.Controls.Add(btnOpen)
        groupBox2.Controls.Add(btnsqlDate)
        groupBox2.Location = New Point(8, 132)
        groupBox2.Margin = New Padding(4, 5, 4, 5)
        groupBox2.Name = "groupBox2"
        groupBox2.Padding = New Padding(4, 5, 4, 5)
        groupBox2.Size = New Size(260, 106)
        groupBox2.TabIndex = 58
        groupBox2.TabStop = False
        ' 
        ' btnOpen
        ' 
        btnOpen.Font = New Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnOpen.Location = New Point(13, 34)
        btnOpen.Margin = New Padding(4, 5, 4, 5)
        btnOpen.Name = "btnOpen"
        btnOpen.Size = New Size(110, 50)
        btnOpen.TabIndex = 1
        btnOpen.Text = "Open"
        btnOpen.UseVisualStyleBackColor = True
        ' 
        ' btnsqlDate
        ' 
        btnsqlDate.Font = New Font("Yu Gothic UI", 11.25F)
        btnsqlDate.Location = New Point(131, 36)
        btnsqlDate.Margin = New Padding(4, 5, 4, 5)
        btnsqlDate.Name = "btnsqlDate"
        btnsqlDate.Size = New Size(110, 50)
        btnsqlDate.TabIndex = 40
        btnsqlDate.Text = "Sql"
        btnsqlDate.UseVisualStyleBackColor = True
        ' 
        ' groupBox1
        ' 
        groupBox1.Controls.Add(cmbDeleteType)
        groupBox1.Controls.Add(btnDelete)
        groupBox1.Controls.Add(btnClearData)
        groupBox1.Location = New Point(8, 504)
        groupBox1.Margin = New Padding(4, 5, 4, 5)
        groupBox1.Name = "groupBox1"
        groupBox1.Padding = New Padding(4, 5, 4, 5)
        groupBox1.Size = New Size(258, 138)
        groupBox1.TabIndex = 57
        groupBox1.TabStop = False
        ' 
        ' cmbDeleteType
        ' 
        cmbDeleteType.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        cmbDeleteType.FormattingEnabled = True
        cmbDeleteType.Location = New Point(13, 25)
        cmbDeleteType.Name = "cmbDeleteType"
        cmbDeleteType.Size = New Size(164, 39)
        cmbDeleteType.TabIndex = 12
        ' 
        ' btnDelete
        ' 
        btnDelete.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDelete.Location = New Point(13, 75)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(110, 50)
        btnDelete.TabIndex = 13
        btnDelete.Text = "Delete"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnClearData
        ' 
        btnClearData.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnClearData.Location = New Point(129, 75)
        btnClearData.Name = "btnClearData"
        btnClearData.Size = New Size(110, 50)
        btnClearData.TabIndex = 14
        btnClearData.Text = "Clear data"
        btnClearData.UseVisualStyleBackColor = True
        ' 
        ' groupBox4
        ' 
        groupBox4.Controls.Add(lblView)
        groupBox4.Controls.Add(cmbViewOption)
        groupBox4.Controls.Add(rbDistant)
        groupBox4.Controls.Add(btnSearch)
        groupBox4.Controls.Add(btnRedshift)
        groupBox4.Controls.Add(rbClose)
        groupBox4.Controls.Add(txtSearch)
        groupBox4.Controls.Add(btnGoBack)
        groupBox4.Controls.Add(cmbClassFilter)
        groupBox4.Controls.Add(btnFilterClass)
        groupBox4.Controls.Add(label1)
        groupBox4.Location = New Point(8, 12)
        groupBox4.Margin = New Padding(4, 5, 4, 5)
        groupBox4.Name = "groupBox4"
        groupBox4.Padding = New Padding(4, 5, 4, 5)
        groupBox4.Size = New Size(1780, 113)
        groupBox4.TabIndex = 56
        groupBox4.TabStop = False
        ' 
        ' lblView
        ' 
        lblView.AutoSize = True
        lblView.Font = New Font("Yu Gothic UI", 11.25F)
        lblView.Location = New Point(1494, 45)
        lblView.Name = "lblView"
        lblView.Size = New Size(63, 31)
        lblView.TabIndex = 40
        lblView.Text = "View"
        ' 
        ' cmbViewOption
        ' 
        cmbViewOption.FormattingEnabled = True
        cmbViewOption.Location = New Point(1569, 42)
        cmbViewOption.Name = "cmbViewOption"
        cmbViewOption.Size = New Size(183, 33)
        cmbViewOption.TabIndex = 40
        ' 
        ' rbDistant
        ' 
        rbDistant.AutoSize = True
        rbDistant.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbDistant.Location = New Point(798, 30)
        rbDistant.Margin = New Padding(4, 5, 4, 5)
        rbDistant.Name = "rbDistant"
        rbDistant.Size = New Size(149, 35)
        rbDistant.TabIndex = 32
        rbDistant.TabStop = True
        rbDistant.Text = "Far objects"
        rbDistant.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Font = New Font("Yu Gothic UI", 12F)
        btnSearch.Location = New Point(548, 41)
        btnSearch.Margin = New Padding(4, 5, 4, 5)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(110, 50)
        btnSearch.TabIndex = 29
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' btnRedshift
        ' 
        btnRedshift.Font = New Font("Yu Gothic UI", 12F)
        btnRedshift.Location = New Point(971, 41)
        btnRedshift.Margin = New Padding(4, 5, 4, 5)
        btnRedshift.Name = "btnRedshift"
        btnRedshift.Size = New Size(110, 50)
        btnRedshift.TabIndex = 34
        btnRedshift.Text = "Order"
        btnRedshift.UseVisualStyleBackColor = True
        ' 
        ' rbClose
        ' 
        rbClose.AutoSize = True
        rbClose.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rbClose.Location = New Point(799, 72)
        rbClose.Margin = New Padding(4, 5, 4, 5)
        rbClose.Name = "rbClose"
        rbClose.Size = New Size(168, 35)
        rbClose.TabIndex = 31
        rbClose.TabStop = True
        rbClose.Text = "Near objects"
        rbClose.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(143, 48)
        txtSearch.Margin = New Padding(4, 5, 4, 5)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(380, 37)
        txtSearch.TabIndex = 28
        ' 
        ' btnGoBack
        ' 
        btnGoBack.Font = New Font("Yu Gothic UI", 12F)
        btnGoBack.Location = New Point(15, 41)
        btnGoBack.Margin = New Padding(4, 5, 4, 5)
        btnGoBack.Name = "btnGoBack"
        btnGoBack.Size = New Size(110, 50)
        btnGoBack.TabIndex = 21
        btnGoBack.Text = "Go back"
        btnGoBack.UseVisualStyleBackColor = True
        ' 
        ' cmbClassFilter
        ' 
        cmbClassFilter.Font = New Font("Yu Gothic UI", 11.25F)
        cmbClassFilter.FormattingEnabled = True
        cmbClassFilter.Location = New Point(1122, 41)
        cmbClassFilter.Name = "cmbClassFilter"
        cmbClassFilter.Size = New Size(183, 39)
        cmbClassFilter.TabIndex = 18
        ' 
        ' btnFilterClass
        ' 
        btnFilterClass.Font = New Font("Yu Gothic UI", 11.25F)
        btnFilterClass.Location = New Point(1313, 32)
        btnFilterClass.Name = "btnFilterClass"
        btnFilterClass.Size = New Size(110, 50)
        btnFilterClass.TabIndex = 19
        btnFilterClass.Text = "Filter"
        btnFilterClass.UseVisualStyleBackColor = True
        ' 
        ' label1
        ' 
        label1.AllowDrop = True
        label1.AutoSize = True
        label1.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        label1.Location = New Point(702, 52)
        label1.Margin = New Padding(4, 0, 4, 0)
        label1.Name = "label1"
        label1.Size = New Size(98, 31)
        label1.TabIndex = 30
        label1.Text = "Redshift"
        ' 
        ' lblData
        ' 
        lblData.AllowDrop = True
        lblData.AutoSize = True
        lblData.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblData.Location = New Point(805, 576)
        lblData.Margin = New Padding(4, 0, 4, 0)
        lblData.Name = "lblData"
        lblData.Size = New Size(49, 31)
        lblData.TabIndex = 55
        lblData.Text = "No:"
        ' 
        ' groupBox5
        ' 
        groupBox5.Controls.Add(btnGraphics)
        groupBox5.Controls.Add(btnScatterPlot)
        groupBox5.Location = New Point(561, 655)
        groupBox5.Margin = New Padding(4, 5, 4, 5)
        groupBox5.Name = "groupBox5"
        groupBox5.Padding = New Padding(4, 5, 4, 5)
        groupBox5.Size = New Size(138, 163)
        groupBox5.TabIndex = 69
        groupBox5.TabStop = False
        ' 
        ' btnGraphics
        ' 
        btnGraphics.Font = New Font("Yu Gothic UI", 11.25F)
        btnGraphics.Location = New Point(17, 32)
        btnGraphics.Name = "btnGraphics"
        btnGraphics.Size = New Size(110, 50)
        btnGraphics.TabIndex = 23
        btnGraphics.Text = "Pie "
        btnGraphics.UseVisualStyleBackColor = True
        ' 
        ' btnScatterPlot
        ' 
        btnScatterPlot.Font = New Font("Yu Gothic UI", 11.25F)
        btnScatterPlot.Location = New Point(17, 88)
        btnScatterPlot.Name = "btnScatterPlot"
        btnScatterPlot.Size = New Size(110, 50)
        btnScatterPlot.TabIndex = 26
        btnScatterPlot.Text = "Scatter"
        btnScatterPlot.UseVisualStyleBackColor = True
        ' 
        ' formsPlot2
        ' 
        formsPlot2.DisplayScale = 1F
        formsPlot2.Location = New Point(729, 655)
        formsPlot2.Margin = New Padding(4, 5, 4, 5)
        formsPlot2.Name = "formsPlot2"
        formsPlot2.Size = New Size(1069, 403)
        formsPlot2.TabIndex = 68
        ' 
        ' formsPlot1
        ' 
        formsPlot1.DisplayScale = 1F
        formsPlot1.Location = New Point(13, 655)
        formsPlot1.Margin = New Padding(4, 5, 4, 5)
        formsPlot1.Name = "formsPlot1"
        formsPlot1.Size = New Size(511, 403)
        formsPlot1.TabIndex = 67
        ' 
        ' FrmDataSet
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1801, 1050)
        Controls.Add(groupBox5)
        Controls.Add(formsPlot2)
        Controls.Add(formsPlot1)
        Controls.Add(lblProgress)
        Controls.Add(btnEnviarArchivo)
        Controls.Add(txtPlainText)
        Controls.Add(treeView)
        Controls.Add(dgvData)
        Controls.Add(pgb)
        Controls.Add(groupBox3)
        Controls.Add(groupBox2)
        Controls.Add(groupBox1)
        Controls.Add(groupBox4)
        Controls.Add(lblData)
        Name = "FrmDataSet"
        Text = "FrmDataSet"
        CType(dgvData, ComponentModel.ISupportInitialize).EndInit()
        groupBox3.ResumeLayout(False)
        groupBox2.ResumeLayout(False)
        groupBox1.ResumeLayout(False)
        groupBox4.ResumeLayout(False)
        groupBox4.PerformLayout()
        groupBox5.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private WithEvents lblProgress As Label
    Private WithEvents btnEnviarArchivo As Button
    Private WithEvents txtPlainText As TextBox
    Private WithEvents treeView As TreeView
    Private WithEvents dgvData As DataGridView
    Private WithEvents pgb As ProgressBar
    Private WithEvents groupBox3 As GroupBox
    Private WithEvents btnSaveSqlChanges As Button
    Private WithEvents cmbExportFormat As ComboBox
    Private WithEvents btnExport As Button
    Private WithEvents btnExportPDF As Button
    Private WithEvents groupBox2 As GroupBox
    Private WithEvents btnOpen As Button
    Private WithEvents btnsqlDate As Button
    Private WithEvents groupBox1 As GroupBox
    Private WithEvents cmbDeleteType As ComboBox
    Private WithEvents btnDelete As Button
    Private WithEvents btnClearData As Button
    Private WithEvents groupBox4 As GroupBox
    Private WithEvents lblView As Label
    Private WithEvents cmbViewOption As ComboBox
    Private WithEvents rbDistant As RadioButton
    Private WithEvents btnSearch As Button
    Private WithEvents btnRedshift As Button
    Private WithEvents rbClose As RadioButton
    Private WithEvents txtSearch As TextBox
    Private WithEvents btnGoBack As Button
    Private WithEvents cmbClassFilter As ComboBox
    Private WithEvents btnFilterClass As Button
    Private WithEvents label1 As Label
    Private WithEvents lblData As Label
    Private WithEvents groupBox5 As GroupBox
    Private WithEvents btnGraphics As Button
    Private WithEvents btnScatterPlot As Button
    Private WithEvents formsPlot2 As ScottPlot.WinForms.FormsPlot
    Private WithEvents formsPlot1 As ScottPlot.WinForms.FormsPlot
End Class
