Imports System.Net

Public Class FileDownloader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            TextBox2.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Some fields are not filled in. Please fill in all fields to continue.", 0 + 16, "Missing Fields")
        Else
            Dim webClient As New WebClient()

            Try
                webClient.DownloadFile(TextBox1.Text, TextBox2.Text)
                MsgBox("File downloaded successfully.", 0 + 64, "Success!")
            Catch ex As Exception
                MsgBox("An error occurred: " & ex.Message & "
If this issue continues, please report an issue on the GitHub.", 0 + 16, "Oops!")
            End Try
        End If
    End Sub
End Class