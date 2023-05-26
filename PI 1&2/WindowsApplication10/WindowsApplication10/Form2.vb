Public Class Form2
    Public loadimg As New OpenFileDialog
    Public x As Integer, y As Integer, i As Integer, j As Integer
    Public r As Integer, g As Integer, b As Integer
    Dim pixel As New Color, pixel2 As New Color
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If loadimg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.Load(loadimg.FileName)
        End If
        x = PictureBox1.Width
        y = PictureBox1.Height
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim pixel As New Color
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim zero_order As New Bitmap(x * 2 + 1, y * 2 + 1)
        Dim n As Integer, m As Integer, k As Integer
        n = 1 : m = 0
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                m = m + 1
                zero_order.SetPixel(n, m, Color.FromArgb(r, g, b))
                m = m + 1
                zero_order.SetPixel(n, m, Color.FromArgb(r, g, b))
            Next
            n += 1
            For k = 0 To m - 1
                pixel = zero_order.GetPixel(n - 1, k)
                zero_order.SetPixel(n, k, Color.FromArgb(CInt(pixel.R), CInt(pixel.G), CInt(pixel.B)))
            Next
            m = 0
            n += 1
        Next
        PictureBox2.Image = zero_order
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim first_order As New Bitmap(2 * x + 1, 2 * y + 1)
        Dim n As Integer, m As Integer, k As Integer
        Dim r2 As Integer, g2 As Integer, b2 As Integer
        Dim ra As Integer, ga As Integer, ba As Integer
        n = 0 : m = 0 : k = 0
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                first_order.SetPixel(n, m, Color.FromArgb(r, g, b))
                m = m + 1
                If (j <> (y - 1)) Then
                    pixel2 = img1.GetPixel(i, j + 1)
                    r2 = pixel2.R : g2 = pixel2.G : b2 = pixel2.B
                    ra = (r + r2) / 2 : ga = (g + g2) / 2 : ba = (b + b2) / 2
                    first_order.SetPixel(n, m, Color.FromArgb(ra, ga, ba))
                    m = m + 1
                End If
            Next
            n = n + 1
            For k = 0 To m - 1
                pixel = first_order.GetPixel(n - 1, k)
                r = pixel.R : g = pixel.G : b = pixel.B
                first_order.SetPixel(n, k, Color.FromArgb(r, g, b))
            Next
            m = 0
            n = n + 1
        Next
        PictureBox2.Image = first_order
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        End
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim img2 As New Bitmap(2 * x + 2, 2 * y + 2)
        Dim convolution As New Bitmap(2 * x + 2, 2 * y + 2)
        Dim n As Integer, m As Integer
        Dim a As Integer, b As Integer, c As Integer
        Dim r1 As Integer, g1 As Integer, b1 As Integer
        a = 0.25 : b = 0.5 : c = 1
        n = 0 : m = 0
        For Me.i = 0 To x - 2
            For Me.j = 0 To y - 2
                If (i Mod 2 = 0) And (j Mod 2 = 0) Then
                    img2.SetPixel(m, n, Color.FromArgb(0, 0, 0))
                Else
                    n = j * 2 : m = i * 2
                    pixel = img1.GetPixel(i, j)
                    r = pixel.R : g = pixel.G : b = pixel.B
                    img2.SetPixel(m, n, Color.FromArgb(r, g, b))
                End If
            Next
        Next

        For Me.i = 1 To 2 * x - 3
            For Me.j = 1 To 2 * y - 3
                r1 = (img2.GetPixel(i - 1, j - 1).R * a) + (img2.GetPixel(i, j - 1).R * b) + (img2.GetPixel(i + 1, j - 1).R * a) +
                    (img2.GetPixel(i - 1, j).R * b) + (img2.GetPixel(i, j).R * c) + (img2.GetPixel(i + 1, j).R * b) +
                    (img2.GetPixel(i - 1, j + 1).R * a) + (img2.GetPixel(i, j + 1).R * b) + (img2.GetPixel(i + 1, j + 1).R * a)

                g1 = (img2.GetPixel(i - 1, j - 1).G * a) + (img2.GetPixel(i, j - 1).G * b) + (img2.GetPixel(i + 1, j - 1).G * a) +
                    (img2.GetPixel(i - 1, j).G * b) + (img2.GetPixel(i, j).G * c) + (img2.GetPixel(i + 1, j).G * b) +
                    (img2.GetPixel(i - 1, j + 1).G * a) + (img2.GetPixel(i, j + 1).G * b) + (img2.GetPixel(i + 1, j + 1).G * a)

                b1 = (img2.GetPixel(i - 1, j - 1).B * a) + (img2.GetPixel(i, j - 1).B * b) + (img2.GetPixel(i + 1, j - 1).B * a) +
                    (img2.GetPixel(i - 1, j).B * b) + (img2.GetPixel(i, j).B * c) + (img2.GetPixel(i + 1, j).B * b) +
                    (img2.GetPixel(i - 1, j + 1).B * a) + (img2.GetPixel(i, j + 1).B * b) + (img2.GetPixel(i + 1, j + 1).B * a)

                If r1 > 255 Then r1 = 255
                If r1 < 0 Then r1 = 0
                If g1 > 255 Then g1 = 255
                If g1 < 0 Then g1 = 0
                If b1 > 255 Then b1 = 255
                If b1 < 0 Then b1 = 0
                convolution.SetPixel(i, j, Color.FromArgb(r1, g1, b1))
            Next
        Next
        PictureBox2.Image = convolution

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim img2 As New Bitmap(PictureBox1.Image)
        Dim mean As New Bitmap(x, y)
        For Me.i = 1 To x - 2
            For Me.j = 1 To y - 2
                r = (CInt(img2.GetPixel(i - 1, j - 1).R) + CInt(img2.GetPixel(i, j - 1).R) + CInt(img2.GetPixel(i + 1, j - 1).R) +
                    CInt(img2.GetPixel(i - 1, j).R) + CInt(img2.GetPixel(i, j).R) + CInt(img2.GetPixel(i + 1, j).R) +
                    CInt(img2.GetPixel(i - 1, j + 1).R) + CInt(img2.GetPixel(i, j + 1).R) + CInt(img2.GetPixel(i + 1, j + 1).R)) / 9

                g = (CInt(img2.GetPixel(i - 1, j - 1).G) + CInt(img2.GetPixel(i, j - 1).G) + CInt(img2.GetPixel(i + 1, j - 1).G) +
                    CInt(img2.GetPixel(i - 1, j).G) + CInt(img2.GetPixel(i, j).G) + CInt(img2.GetPixel(i + 1, j).G) +
                    CInt(img2.GetPixel(i - 1, j + 1).G) + CInt(img2.GetPixel(i, j + 1).G) + CInt(img2.GetPixel(i + 1, j + 1).G)) / 9

                b = (CInt(img2.GetPixel(i - 1, j - 1).B) + CInt(img2.GetPixel(i, j - 1).B) + CInt(img2.GetPixel(i + 1, j - 1).B) +
                    CInt(img2.GetPixel(i - 1, j).B) + CInt(img2.GetPixel(i, j).B) + CInt(img2.GetPixel(i + 1, j).B) +
                    CInt(img2.GetPixel(i - 1, j + 1).B) + CInt(img2.GetPixel(i, j + 1).B) + CInt(img2.GetPixel(i + 1, j + 1).B)) / 9

                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                mean.SetPixel(i, j, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = mean
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim img2 As New Bitmap(PictureBox1.Image)
        Dim median As New Bitmap(x, y)
        Dim red(9) As Integer
        Dim green(9) As Integer
        Dim blue(9) As Integer
        For Me.i = 1 To x - 2
            For Me.j = 1 To y - 2
                red = {CInt(img2.GetPixel(i - 1, j - 1).R), CInt(img2.GetPixel(i, j - 1).R), CInt(img2.GetPixel(i + 1, j - 1).R),
                    CInt(img2.GetPixel(i - 1, j).R), CInt(img2.GetPixel(i, j).R), CInt(img2.GetPixel(i + 1, j).R),
                    CInt(img2.GetPixel(i - 1, j + 1).R), CInt(img2.GetPixel(i, j + 1).R), CInt(img2.GetPixel(i + 1, j + 1).R)}
                Array.Sort(red)
                r = red(5)
                green = {CInt(img2.GetPixel(i - 1, j - 1).G), CInt(img2.GetPixel(i, j - 1).G), CInt(img2.GetPixel(i + 1, j - 1).G),
                    CInt(img2.GetPixel(i - 1, j).G), CInt(img2.GetPixel(i, j).G), CInt(img2.GetPixel(i + 1, j).G),
                    CInt(img2.GetPixel(i - 1, j + 1).G), CInt(img2.GetPixel(i, j + 1).G), CInt(img2.GetPixel(i + 1, j + 1).G)}
                Array.Sort(green)
                g = green(5)
                blue = {CInt(img2.GetPixel(i - 1, j - 1).B), CInt(img2.GetPixel(i, j - 1).B), CInt(img2.GetPixel(i + 1, j - 1).B),
                    CInt(img2.GetPixel(i - 1, j).B), CInt(img2.GetPixel(i, j).B), CInt(img2.GetPixel(i + 1, j).B),
                    CInt(img2.GetPixel(i - 1, j + 1).B), CInt(img2.GetPixel(i, j + 1).B), CInt(img2.GetPixel(i + 1, j + 1).B)}
                Array.Sort(blue)
                b = blue(5)

                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                median.SetPixel(i, j, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = median
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim img2 As New Bitmap(PictureBox1.Image)
        Dim enhancement As New Bitmap(x, y)
        Dim s As Integer = 1
        Dim s1 As Integer = -2
        For Me.i = 1 To x - 2
            For Me.j = 1 To y - 2
                r = CInt(img2.GetPixel(i - 1, j - 1).R * s1) + CInt(img2.GetPixel(i, j - 1).R * s) + CInt(img2.GetPixel(i + 1, j - 1).R * s1) +
                    CInt(img2.GetPixel(i - 1, j).R * s) + CInt(img2.GetPixel(i, j).R * 5) + CInt(img2.GetPixel(i + 1, j).R * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).R * s1) + CInt(img2.GetPixel(i, j + 1).R * s) + CInt(img2.GetPixel(i + 1, j + 1).R * s1)

                g = CInt(img2.GetPixel(i - 1, j - 1).G * s1) + CInt(img2.GetPixel(i, j - 1).G * s) + CInt(img2.GetPixel(i + 1, j - 1).G * s1) +
                    CInt(img2.GetPixel(i - 1, j).G * s) + CInt(img2.GetPixel(i, j).G * 5) + CInt(img2.GetPixel(i + 1, j).G * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).G * s1) + CInt(img2.GetPixel(i, j + 1).G * s) + CInt(img2.GetPixel(i + 1, j + 1).G * s1)

                b = CInt(img2.GetPixel(i - 1, j - 1).B * s1) + CInt(img2.GetPixel(i, j - 1).B * s) + CInt(img2.GetPixel(i + 1, j - 1).B * s1) +
                    CInt(img2.GetPixel(i - 1, j).B * s) + CInt(img2.GetPixel(i, j).B * 5) + CInt(img2.GetPixel(i + 1, j).B * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).B * s1) + CInt(img2.GetPixel(i, j + 1).B * s) + CInt(img2.GetPixel(i + 1, j + 1).B * s1)

                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                enhancement.SetPixel(i, j, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = enhancement
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim img2 As New Bitmap(PictureBox1.Image)
        Dim enhancement As New Bitmap(x, y)
        Dim s As Integer = 0
        Dim a As Integer = 1
        Dim a1 As Integer = -1
        For Me.i = 1 To x - 2
            For Me.j = 1 To y - 2
                r = CInt(img2.GetPixel(i - 1, j - 1).R * a) + CInt(img2.GetPixel(i, j - 1).R * s) + CInt(img2.GetPixel(i + 1, j - 1).R * s) +
                    CInt(img2.GetPixel(i - 1, j).R * s) + CInt(img2.GetPixel(i, j).R * a) + CInt(img2.GetPixel(i + 1, j).R * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).R * s) + CInt(img2.GetPixel(i, j + 1).R * s) + CInt(img2.GetPixel(i + 1, j + 1).R * a1)

                g = CInt(img2.GetPixel(i - 1, j - 1).G * a) + CInt(img2.GetPixel(i, j - 1).G * s) + CInt(img2.GetPixel(i + 1, j - 1).G * s) +
                    CInt(img2.GetPixel(i - 1, j).G * s) + CInt(img2.GetPixel(i, j).G * a) + CInt(img2.GetPixel(i + 1, j).G * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).G * s) + CInt(img2.GetPixel(i, j + 1).G * s) + CInt(img2.GetPixel(i + 1, j + 1).G * a1)

                b = CInt(img2.GetPixel(i - 1, j - 1).B * a) + CInt(img2.GetPixel(i, j - 1).B * s) + CInt(img2.GetPixel(i + 1, j - 1).B * s) +
                    CInt(img2.GetPixel(i - 1, j).B * s) + CInt(img2.GetPixel(i, j).B * a) + CInt(img2.GetPixel(i + 1, j).B * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).B * s) + CInt(img2.GetPixel(i, j + 1).B * s) + CInt(img2.GetPixel(i + 1, j + 1).B * a1)

                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                enhancement.SetPixel(i, j, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = enhancement
    End Sub

   

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim img2 As New Bitmap(PictureBox1.Image)
        Dim sobel As New Bitmap(x, y)
        Dim s As Integer = 0
        Dim a As Integer = 1
        Dim a1 As Integer = -1
        For Me.i = 1 To x - 2
            For Me.j = 1 To y - 2
                r = CInt(img2.GetPixel(i - 1, j - 1).R * a1) + CInt(img2.GetPixel(i, j - 1).R * (-2)) + CInt(img2.GetPixel(i + 1, j - 1).R * a1) +
                    CInt(img2.GetPixel(i - 1, j).R * s) + CInt(img2.GetPixel(i, j).R * s) + CInt(img2.GetPixel(i + 1, j).R * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).R * a) + CInt(img2.GetPixel(i, j + 1).R * 2) + CInt(img2.GetPixel(i + 1, j + 1).R * a)

                g = CInt(img2.GetPixel(i - 1, j - 1).G * a1) + CInt(img2.GetPixel(i, j - 1).G * (-2)) + CInt(img2.GetPixel(i + 1, j - 1).G * a1) +
                    CInt(img2.GetPixel(i - 1, j).G * s) + CInt(img2.GetPixel(i, j).G * s) + CInt(img2.GetPixel(i + 1, j).G * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).G * a) + CInt(img2.GetPixel(i, j + 1).G * 2) + CInt(img2.GetPixel(i + 1, j + 1).G * a)

                b = CInt(img2.GetPixel(i - 1, j - 1).B * a1) + CInt(img2.GetPixel(i, j - 1).B * (-2)) + CInt(img2.GetPixel(i + 1, j - 1).B * a1) +
                    CInt(img2.GetPixel(i - 1, j).B * s) + CInt(img2.GetPixel(i, j).B * s) + CInt(img2.GetPixel(i + 1, j).B * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).B * a) + CInt(img2.GetPixel(i, j + 1).B * 2) + CInt(img2.GetPixel(i + 1, j + 1).B * a)

                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                sobel.SetPixel(i, j, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = sobel
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim img2 As New Bitmap(PictureBox1.Image)
        Dim preWilt As New Bitmap(x, y)
        Dim s As Integer = 0
        Dim a As Integer = 1
        Dim a1 As Integer = -1
        For Me.i = 1 To x - 2
            For Me.j = 1 To y - 2
                r = CInt(img2.GetPixel(i - 1, j - 1).R * a1) + CInt(img2.GetPixel(i, j - 1).R * a1) + CInt(img2.GetPixel(i + 1, j - 1).R * a1) +
                    CInt(img2.GetPixel(i - 1, j).R * s) + CInt(img2.GetPixel(i, j).R * s) + CInt(img2.GetPixel(i + 1, j).R * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).R * a) + CInt(img2.GetPixel(i, j + 1).R * a) + CInt(img2.GetPixel(i + 1, j + 1).R * a)

                g = CInt(img2.GetPixel(i - 1, j - 1).G * a1) + CInt(img2.GetPixel(i, j - 1).G * a1) + CInt(img2.GetPixel(i + 1, j - 1).G * a1) +
                    CInt(img2.GetPixel(i - 1, j).G * s) + CInt(img2.GetPixel(i, j).G * s) + CInt(img2.GetPixel(i + 1, j).G * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).G * a) + CInt(img2.GetPixel(i, j + 1).G * a) + CInt(img2.GetPixel(i + 1, j + 1).G * a)

                b = CInt(img2.GetPixel(i - 1, j - 1).B * a1) + CInt(img2.GetPixel(i, j - 1).B * a1) + CInt(img2.GetPixel(i + 1, j - 1).B * a1) +
                    CInt(img2.GetPixel(i - 1, j).B * s) + CInt(img2.GetPixel(i, j).B * s) + CInt(img2.GetPixel(i + 1, j).B * s) +
                    CInt(img2.GetPixel(i - 1, j + 1).B * a) + CInt(img2.GetPixel(i, j + 1).B * a) + CInt(img2.GetPixel(i + 1, j + 1).B * a)

                If r > 255 Then r = 255
                If r < 0 Then r = 0
                If g > 255 Then g = 255
                If g < 0 Then g = 0
                If b > 255 Then b = 255
                If b < 0 Then b = 0
                preWilt.SetPixel(i, j, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = preWilt
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim img As New Bitmap(PictureBox1.Image)
        Dim gray As New Bitmap(x, y)
        Dim r1 As Integer, g1 As Integer, b1 As Integer
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img.GetPixel(i, j)
                r1 = pixel.R : g1 = pixel.G : b1 = pixel.B
                r = (r1 + g1 + b1) / 3 : g = (r1 + g1 + b1) / 3 : b = (r1 + g1 + b1) / 3
                gray.SetPixel(x - i - 1, y - j - 1, Color.FromArgb(r, g, b))
            Next
        Next
        PictureBox2.Image = gray
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim img As New Bitmap(PictureBox1.Image)
        Dim binary As New Bitmap(x, y)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                If img.GetPixel(i, j).R < 128 And img.GetPixel(i, j).G < 128 And img.GetPixel(i, j).B < 128 Then
                    binary.SetPixel(x - i - 1, j, Color.Black)
                Else
                    binary.SetPixel(x - i - 1, j, Color.White)
                End If
            Next
        Next
        PictureBox2.Image = binary
    End Sub
End Class