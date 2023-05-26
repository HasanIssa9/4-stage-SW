Public Class Form1
    Public Function gcd(ByVal n1, ByVal n2) As Integer
        If n1 = 0 Then
            gcd = n2
        Else
            gcd = gcd(n2 Mod n1, n1)
        End If
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n As Integer = TextBox1.Text
        Dim i As Integer
        Dim j As Integer = 0
        For i = 1 To n - 1
            If gcd(n, i) = 1 Then
                j += 1
            End If
        Next
        MsgBox(j)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class
