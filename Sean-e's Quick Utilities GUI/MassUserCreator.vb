﻿Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Runtime.Remoting.Contexts
Imports System.DirectoryServices.AccountManagement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class MassUserCreator
    Private Sub MassUserCreator_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
Me.Close()
End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim current_times As Integer = 0
        While current_times <> NumericUpDown1.Value
            current_times = current_times + 1

        End While
    End Sub
End Class