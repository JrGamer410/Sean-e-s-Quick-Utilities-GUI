Public Class BibliographicGenerator
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If middlename.Text = "" Then
            RichTextBox1.Text = lastname.Text & ", " & firstname.Text & ". " & booktitle.Text & ". " & public_city.Text & ": " & public_name.Text & ", " & NumericUpDown1.Value & ". " & book_type.Text & "."
        Else
            RichTextBox1.Text = lastname.Text & ", " & middlename.Text & ", " & firstname.Text & ". " & booktitle.Text & ". " & public_city.Text & ": " & public_name.Text & ", " & NumericUpDown1.Value & ". " & book_type.Text & "."
        End If
    End Sub
End Class