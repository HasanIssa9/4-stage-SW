Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim num1 As Integer = TextBox1.Text
        Dim num2 As Integer = TextBox2.Text
        Dim g As Integer
        While num2 <> 0
            g = num2
            num2 = num1 Mod num2
            num1 = g
        End While
        TextBox3.Text = num1
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim num1 As Integer = TextBox1.Text
        Dim num2 As Integer = TextBox2.Text
        Dim g As Integer, x As Integer
        x = num1 * num2
        While num2 <> 0
            g = num2
            num2 = num1 Mod num2
            num1 = g
        End While
        TextBox4.Text = x / num1
    End Sub
End Class
