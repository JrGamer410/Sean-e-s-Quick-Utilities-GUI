Imports Microsoft.Win32

Public Class LMC
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim doChange As Integer = 1
        Try
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "legalnoticecaption", TextBox1.Text)
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
            Label3.Visible = False
            doChange = 0
        End Try
        Try
            Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "legalnoticetext", TextBox2.Text)
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message & "
Ensure this app is being run as an Administrator.", 0 + 16, "Something went wrong!")
            Label3.Visible = False
            doChange = 0
        End Try
        If doChange = 1 Then
            Label3.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class