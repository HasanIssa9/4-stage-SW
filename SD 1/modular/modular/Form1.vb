Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Integer = TextBox1.Text
        Dim n As Integer = TextBox2.Text
        Dim q As Integer, r As Integer
        q = a \ n
        r = a - q * n
        If r < 0 Then
            r += n
        End If
        TextBox3.Text = r
    End Sub
End Class
