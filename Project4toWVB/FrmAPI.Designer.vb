<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAPI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        btnGoBack = New Button()
        label1 = New Label()
        cbMonth = New ComboBox()
        btnSearch = New Button()
        dgvData = New DataGridView()
        CType(dgvData, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnGoBack
        ' 
        btnGoBack.Font = New Font("Yu Gothic UI", 12F)
        btnGoBack.Location = New Point(70, 29)
        btnGoBack.Margin = New Padding(4, 5, 4, 5)
        btnGoBack.Name = "btnGoBack"
        btnGoBack.Size = New Size(150, 62)
        btnGoBack.TabIndex = 9
        btnGoBack.Text = "Go back"
        btnGoBack.UseVisualStyleBackColor = True
        ' 
        ' label1
        ' 
        label1.AutoSize = True
        label1.Font = New Font("Yu Gothic UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        label1.Location = New Point(577, 62)
        label1.Margin = New Padding(4, 0, 4, 0)
        label1.Name = "label1"
        label1.Size = New Size(309, 48)
        label1.TabIndex = 8
        label1.Text = "Picture of the day"
        ' 
        ' cbMonth
        ' 
        cbMonth.Font = New Font("Yu Gothic UI", 12F)
        cbMonth.FormattingEnabled = True
        cbMonth.Location = New Point(70, 179)
        cbMonth.Margin = New Padding(4, 5, 4, 5)
        cbMonth.Name = "cbMonth"
        cbMonth.Size = New Size(171, 40)
        cbMonth.TabIndex = 7
        ' 
        ' btnSearch
        ' 
        btnSearch.Font = New Font("Yu Gothic UI", 12F)
        btnSearch.Location = New Point(278, 170)
        btnSearch.Margin = New Padding(4, 5, 4, 5)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(150, 62)
        btnSearch.TabIndex = 6
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' dgvData
        ' 
        dgvData.BackgroundColor = SystemColors.ControlLight
        dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Yu Gothic UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(64))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgvData.DefaultCellStyle = DataGridViewCellStyle2
        dgvData.Location = New Point(70, 267)
        dgvData.Margin = New Padding(4, 5, 4, 5)
        dgvData.Name = "dgvData"
        dgvData.ReadOnly = True
        dgvData.RowHeadersWidth = 62
        dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvData.Size = New Size(1300, 680)
        dgvData.TabIndex = 5
        ' 
        ' FrmAPI
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1430, 996)
        Controls.Add(btnGoBack)
        Controls.Add(label1)
        Controls.Add(cbMonth)
        Controls.Add(btnSearch)
        Controls.Add(dgvData)
        Name = "FrmAPI"
        Text = "Form1"
        CType(dgvData, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private WithEvents btnGoBack As Button
    Private WithEvents label1 As Label
    Private WithEvents cbMonth As ComboBox
    Private WithEvents btnSearch As Button
    Private WithEvents dgvData As DataGridView

End Class
