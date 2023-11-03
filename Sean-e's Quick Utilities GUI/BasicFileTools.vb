Public Class BasicFileTools
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedItem.ToString = "Create File" Then
            Dim FileToCreate = InputBox("Enter the file name of the file to create.", "File Creator")
            If FileToCreate = "" Then
            Else
                Try
                    System.IO.File.Create(FileToCreate)
                Catch ex As Exception
                    MsgBox("Something went wrong: " & ex.Message & "
Try again later. If this continues, please report an issue on the GitHub.", 0 + 16, "Oops!")
                End Try
            End If
        ElseIf ListBox1.SelectedItem.ToString = "Delete File" Then
            Dim FileToDelete = InputBox("Enter the file name of the file to delete.", "File Deleter")
            If FileToDelete = "" Then
            Else
                Try
                    My.Computer.FileSystem.DeleteFile(FileToDelete)
                Catch ex As Exception
                    MsgBox("Something went wrong: " & ex.Message & "
Try again later. If this continues, please report an issue on the GitHub.", 0 + 16, "Oops!")
                End Try
            End If
        ElseIf ListBox1.SelectedItem.ToString = "Rename File" Then
            RenameFile.Show()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class