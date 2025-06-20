Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Public Class FrmMenu
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnAPI_Click(sender As Object, e As EventArgs) Handles btnAPI.Click
        Dim form As New FrmAPI()
        form.Show()
        Me.Hide()
    End Sub

    Private Sub btnDataSet_Click(sender As Object, e As EventArgs) Handles btnDataSet.Click
        Dim form As New FrmDataSet()
        form.Show()
        Me.Hide()
    End Sub
End Class