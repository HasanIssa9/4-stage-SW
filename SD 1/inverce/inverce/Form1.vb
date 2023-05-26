Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim g(100) As Integer
        Dim u(100) As Integer
        Dim v(100) As Integer
        Dim i As Integer = 1
        Dim y As Integer, x As Integer
        Dim n As Integer = TextBox1.Text
        Dim a As Integer = TextBox2.Text
        Dim b As Integer = TextBox3.Text
        g(0) = n
        g(1) = a
        u(0) = 1
        u(1) = 0
        v(0) = 0
        v(1) = 1
        While g(i) <> 0
            y = g(i - 1) / g(i)
            g(1 + i) = g(i - 1) - y * g(i)
            u(1 + i) = u(i - 1) - y * u(i)
            v(1 + i) = v(i - 1) - y * v(i)
            i += 1
        End While
        x = -v(i - 1)
        If x >= 0 Then
            TextBox4.Text =x
        Else
            TextBox4.Text = x + n
        End If
        TextBox5.Text = (b * x) Mod n
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class
