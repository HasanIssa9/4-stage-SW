Public Class Form3
    Public loadimg As New OpenFileDialog
    Public x As Integer, y As Integer, i As Integer, j As Integer
    Public r As Integer, g As Integer, b As Integer
    Public r1 As Integer, g1 As Integer, b1 As Integer
    Public r2 As Integer, g2 As Integer, b2 As Integer
    Dim pixel As New Color, pixel2 As New Color
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If loadimg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.Load(loadimg.FileName)
        End If
        x = PictureBox1.Width
        y = PictureBox1.Height
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If loadimg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox2.Load(loadimg.FileName)
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim pic1 As New Bitmap(PictureBox1.Image)
        Dim pic2 As New Bitmap(PictureBox2.Image)
        Dim pic3 As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = pic1.GetPixel(i, j)
                pixel2 = pic2.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = pixel2.R : g1 = pixel2.G : b1 = pixel2.B
                r2 = (r And r1) : g2 = (g And g1) : b2 = (b And b1)
                If r2 > 255 Then r2 = 255
                If r2 < 0 Then r2 = 0
                If g2 > 255 Then g2 = 255
                If g2 < 0 Then g2 = 0
                If b2 > 255 Then b2 = 255
                If b2 < 0 Then b2 = 0
                pic3.SetPixel(i, j, Color.FromArgb(r2, g2, b2))
            Next
        Next
        PictureBox3.Image = pic3
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim pic1 As New Bitmap(PictureBox1.Image)
        Dim pic2 As New Bitmap(PictureBox2.Image)
        Dim pic3 As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = pic1.GetPixel(i, j)
                pixel2 = pic2.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = pixel2.R : g1 = pixel2.G : b1 = pixel2.B
                r2 = (r + r1) / 2 : g2 = (g + g1) / 2 : b2 = (b + b1) / 2
                If r2 > 255 Then r2 = 255
                If r2 < 0 Then r2 = 0
                If g2 > 255 Then g2 = 255
                If g2 < 0 Then g2 = 0
                If b2 > 255 Then b2 = 255
                If b2 < 0 Then b2 = 0
                pic3.SetPixel(i, j, Color.FromArgb(r2, g2, b2))
            Next
        Next
        PictureBox3.Image = pic3
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim pic1 As New Bitmap(PictureBox1.Image)
        Dim pic2 As New Bitmap(PictureBox2.Image)
        Dim pic3 As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = pic1.GetPixel(i, j)
                pixel2 = pic2.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = pixel2.R : g1 = pixel2.G : b1 = pixel2.B
                r2 = (r - r1) : g2 = (g - g1) : b2 = (b - b1)
                If r2 > 255 Then r2 = 255
                If r2 < 0 Then r2 = 0
                If g2 > 255 Then g2 = 255
                If g2 < 0 Then g2 = 0
                If b2 > 255 Then b2 = 255
                If b2 < 0 Then b2 = 0
                pic3.SetPixel(i, j, Color.FromArgb(r2, g2, b2))
            Next
        Next
        PictureBox3.Image = pic3
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim pic1 As New Bitmap(PictureBox1.Image)
        Dim pic2 As New Bitmap(PictureBox2.Image)
        Dim pic3 As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = pic1.GetPixel(i, j)
                pixel2 = pic2.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = pixel2.R : g1 = pixel2.G : b1 = pixel2.B
                r2 = (r Or r1) : g2 = (g Or g1) : b2 = (b Or b1)
                If r2 > 255 Then r2 = 255
                If r2 < 0 Then r2 = 0
                If g2 > 255 Then g2 = 255
                If g2 < 0 Then g2 = 0
                If b2 > 255 Then b2 = 255
                If b2 < 0 Then b2 = 0
                pic3.SetPixel(i, j, Color.FromArgb(r2, g2, b2))
            Next
        Next
        PictureBox3.Image = pic3
    End Sub
End Class