Public Class Form1
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As Integer = TextBox1.Text
        Dim z As Integer = TextBox2.Text
        Dim n As Integer = TextBox3.Text
        Dim x As Integer = 1
        While z <> 0
            While z Mod 2 = 0
                z = z \ 2
                a = (a * a) Mod n
            End While
            z -= 1
            x = (x * a) Mod n
        End While
        MsgBox(x, , "X=")
    End Sub
End Class
