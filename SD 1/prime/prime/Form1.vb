Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer, n As Integer = TextBox1.Text
        For i = 2 To n - 1
            If n Mod i = 0 Then
                TextBox2.Text = "not prime"
                Exit For
            Else
                TextBox2.Text = "prime"
            End If
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class
