Public Class Form1
    Public loadimg As New OpenFileDialog
    Public x As Integer, y As Integer, i As Integer, j As Integer, brightness As Integer, dark As Integer, k As Integer
    Public r As Integer, g As Integer, b As Integer
    Dim pixel As New Color
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If loadimg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.Load(loadimg.FileName)
        End If
        x = PictureBox1.Width
        y = PictureBox1.Height
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim img1 As New Bitmap(PictureBox1.Image)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                TextBox1.SelectedText = "R = " & Str(r) & " G = " & Str(g) & " B = " & Str(b) & vbNewLine
                ListBox1.Items.Add("R = " & Str(r) & " G = " & Str(g) & " B = " & Str(b))
            Next
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim darkness_img As New Bitmap(x, y)
        Dim img1 As New Bitmap(PictureBox1.Image)
        dark = 0
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                dark = TextBox3.Text
                r = r - dark : g = g - dark : b = b - dark
                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                darkness_img.SetPixel(i, j, Color.FromArgb(r, g, b))
                PictureBox6.Image = darkness_img

            Next
        Next

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim brightness_img As New Bitmap(x, y)
        Dim img1 As New Bitmap(PictureBox1.Image)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                brightness = TextBox2.Text
                r = r + brightness : g = g + brightness : b = b + brightness
                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                brightness_img.SetPixel(i, j, Color.FromArgb(r, g, b))
                PictureBox5.Image = brightness_img

            Next
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim red_img As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                red_img.SetPixel(i, j, Color.FromArgb(r, 0, 0))
            Next
        Next
        PictureBox2.Image = red_img
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim green_img As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                green_img.SetPixel(i, j, Color.FromArgb(0, g, 0))
            Next
        Next
        PictureBox3.Image = green_img
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim blue_img As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                blue_img.SetPixel(i, j, Color.FromArgb(0, 0, b))
            Next
        Next
        PictureBox4.Image = blue_img
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        End
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
