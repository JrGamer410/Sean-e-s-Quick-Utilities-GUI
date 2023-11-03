Public Class RenameFile
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            My.Computer.FileSystem.RenameFile(TextBox1.Text, TextBox2.Text)
            MsgBox("File renamed successfully!", 0 + 64, "Success!")
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message & "
If you continue to get this error, please report an issue on the GitHub", 0 + 16, "Something went wrong!")
        End Try
    End Sub
End Class