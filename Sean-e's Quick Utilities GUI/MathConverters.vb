Public Class MathConverters
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If from.Text = "Centimeters" And ComboBox2.Text = "Inches" Then
            Dim centi_to_inch As Double = NumericUpDown1.Value * 0.393701
            MsgBox(NumericUpDown1.Value & " Centimeters is " & centi_to_inch & " inches.", 0 + 64, "Conversion")
        ElseIf from.Text = "Inches" And ComboBox2.Text = "Centimeters" Then
            Dim inch_to_centi As Double = NumericUpDown1.Value * 2.54
            MsgBox(NumericUpDown1.Value & " Inches is " & inch_to_centi & " centimeters.", 0 + 64, "Conversion")
        ElseIf from.Text = "Centimeters" And ComboBox2.Text = "Millimeters" Then
            Dim centi_to_milli As Double = NumericUpDown1.Value * 10.0
            MsgBox(NumericUpDown1.Value & " Centimeters is " & centi_to_milli & " millimeters.", 0 + 64, "Conversion")
        ElseIf from.Text = "Millimeters" And ComboBox2.Text = "Centimeters" Then
            Dim milli_to_centi As Double = NumericUpDown1.Value * 0.1
            MsgBox(NumericUpDown1.Value & " Millimeters is " & milli_to_centi & " Centimeters.", 0 + 64, "Conversion")
        ElseIf from.Text = ComboBox2.Text Then
            MsgBox(NumericUpDown1.Value & " " & from.Text & " is " & NumericUpDown1.Value & " " & ComboBox2.Text, 0 + 64, "Conversion")
        ElseIf from.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Make sure both dropdowns have a unit selected.", 0 + 16, "Conversion Error!")
        End If
    End Sub
End Class