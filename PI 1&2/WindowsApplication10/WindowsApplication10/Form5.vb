Public Class Form5
    Public rlc(8, 8) As Integer
    Public loadimg As New OpenFileDialog
    Public r As Integer, g As Integer, b As Integer
    Public x As Integer, y As Integer, i As Integer, j As Integer
    Dim pixel As New Color
    Dim count0 As Integer, count1 As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        rlc = {{0, 0, 0, 0, 0, 0, 0, 0},
               {1, 1, 1, 1, 0, 0, 0, 0},
               {0, 1, 1, 0, 0, 0, 0, 0},
               {0, 1, 1, 1, 1, 1, 0, 0},
               {0, 1, 1, 1, 0, 0, 1, 0},
               {0, 0, 1, 0, 0, 1, 1, 0},
               {1, 1, 1, 1, 0, 1, 0, 0},
               {0, 0, 0, 0, 0, 0, 0, 0}}
        For Me.i = 0 To 7
            For Me.j = 0 To 7
                If rlc(i, j) <> 0 And j = 0 Then TextBox1.SelectedText = Str(0) & ","
                If rlc(i, j) = 0 Then
                    count0 += 1
                    If j = 7 Then
                        TextBox1.SelectedText = Str(count0) & ","
                        count0 = 0
                    ElseIf rlc(i, j + 1) = 1 Then
                        TextBox1.SelectedText = Str(count0) & ","
                        count0 = 0
                    End If
                Else
                    count1 += 1
                    If j = 7 Then
                        TextBox1.SelectedText = Str(count1) & ","
                        count1 = 0
                    ElseIf rlc(i, j + 1) = 0 Then
                        TextBox1.SelectedText = Str(count1) & ","
                        count1 = 0
                    End If
                End If
            Next
            TextBox1.SelectedText = vbNewLine
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If loadimg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.Load(loadimg.FileName)
        End If
        x = PictureBox1.Width
        y = PictureBox1.Height
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim img As New Bitmap(PictureBox1.Image)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                If r = 0 Then
                    count0 += 1
                    If j = y - 1 Then
                        TextBox1.SelectedText = Str(count0) & ","
                        count0 = 0
                    ElseIf img.GetPixel(i, j + 1).R = 255 Then
                        TextBox1.SelectedText = Str(count0) & ","
                        count0 = 0
                    End If
                Else
                    count1 += 1
                    If j = y - 1 Then
                        TextBox1.SelectedText = Str(count1) & ","
                        count1 = 0
                    ElseIf img.GetPixel(i, j + 1).R = 0 Then
                        TextBox1.SelectedText = Str(count1) & ","
                        count1 = 0
                    End If
                End If
            Next
            TextBox1.SelectedText = vbNewLine
        Next
    End Sub
End Class