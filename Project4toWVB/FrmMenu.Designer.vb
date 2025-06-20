<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu
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
        btnDataSet = New Button()
        btnAPI = New Button()
        SuspendLayout()
        ' 
        ' btnDataSet
        ' 
        btnDataSet.Font = New Font("Yu Gothic", 11.25F)
        btnDataSet.Location = New Point(508, 341)
        btnDataSet.Margin = New Padding(4, 5, 4, 5)
        btnDataSet.Name = "btnDataSet"
        btnDataSet.Size = New Size(177, 60)
        btnDataSet.TabIndex = 3
        btnDataSet.Text = "DATA SET"
        btnDataSet.UseVisualStyleBackColor = True
        ' 
        ' btnAPI
        ' 
        btnAPI.Font = New Font("Yu Gothic", 11.25F)
        btnAPI.Location = New Point(508, 229)
        btnAPI.Margin = New Padding(4, 5, 4, 5)
        btnAPI.Name = "btnAPI"
        btnAPI.Size = New Size(177, 68)
        btnAPI.TabIndex = 2
        btnAPI.Text = "NASA API"
        btnAPI.UseVisualStyleBackColor = True
        ' 
        ' FrmMenu
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1193, 630)
        Controls.Add(btnDataSet)
        Controls.Add(btnAPI)
        Name = "FrmMenu"
        Text = "FrmMenu"
        ResumeLayout(False)
    End Sub

    Private WithEvents btnDataSet As Button
    Private WithEvents btnAPI As Button
End Class
