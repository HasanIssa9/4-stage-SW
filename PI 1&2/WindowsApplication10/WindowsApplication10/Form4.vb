Public Class Form4
    Public loadimg As New OpenFileDialog
    Public x As Integer, y As Integer, i As Integer, j As Integer, k As Integer
    Public r As Integer, g As Integer, b As Integer
    Public red(0 To 255) As Integer, green(0 To 255) As Integer, blue(0 To 255) As Integer
    Public red_st(0 To 255) As Integer, green_st(0 To 255) As Integer, blue_st(0 To 255) As Integer
    Public red_sh(0 To 255) As Integer, green_sh(0 To 255) As Integer, blue_sh(0 To 255) As Integer
    Public red_s(0 To 255) As Integer, green_s(0 To 255) As Integer, blue_s(0 To 255) As Integer
    Public red_e(0 To 255) As Integer, green_e(0 To 255) As Integer, blue_e(0 To 255) As Integer
    Public redCDF(0 To 255) As Integer, greenCDF(0 To 255) As Integer, blueCDF(0 To 255) As Integer
    Dim pixel As New Color
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If loadimg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.Load(loadimg.FileName)
        End If
        x = PictureBox1.Width
        y = PictureBox1.Height
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Dim img As New Bitmap(PictureBox1.Image)
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                red(r) += 1 : green(g) += 1 : blue(b) += 1
            Next
        Next
        For Me.k = 0 To 255
            ListBox1.Items.Add(Str(k) + "  R: " + Str(red(k)) + "  G: " + Str(green(k)) + "  B: " + Str(blue(k)))
            Chart1.Series("Red").Points.AddXY(k, red(k))
            Chart1.Series("Green").Points.AddXY(k, green(k))
            Chart1.Series("Blue").Points.AddXY(k, blue(k))
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox1.Items.Clear()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim stretch As New Bitmap(x, y)
        Dim maxR As Integer, maxG As Integer, maxB As Integer
        Dim minR As Integer, minG As Integer, minB As Integer
        Dim r1 As Integer, g1 As Integer, b1 As Integer
        For Me.i = 0 To 255
            If red(i) <> 0 Then
                minR = i
                Exit For
            End If
        Next
        For Me.i = 0 To 255
            If green(i) <> 0 Then
                minG = i
                Exit For
            End If
        Next
        For Me.i = 0 To 255
            If blue(i) <> 0 Then
                minB = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If red(i) <> 0 Then
                maxR = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If green(i) <> 0 Then
                maxG = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If blue(i) <> 0 Then
                maxB = i
                Exit For
            End If
        Next
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = ((r - minR) / (maxR - minR)) * 255
                g1 = ((g - minG) / (maxG - minG)) * 255
                b1 = ((b - minB) / (maxB - minB)) * 255
                If r1 > 255 Then r1 = 255
                If g1 > 255 Then g1 = 255
                If b1 > 255 Then b1 = 255
                red_st(r1) += 1 : green_st(g1) += 1 : blue_st(b1) += 1
                stretch.SetPixel(i, j, Color.FromArgb(r1, g1, b1))
            Next
        Next
        For Me.k = 0 To 255
            ListBox1.Items.Add(Str(k) + "  R: " + Str(red_st(k)) + "  G: " + Str(green_st(k)) + "  B: " + Str(blue_st(k)))
            Chart1.Series("Red").Points.AddXY(k, red_st(k))
            Chart1.Series("Green").Points.AddXY(k, green_st(k))
            Chart1.Series("Blue").Points.AddXY(k, blue_st(k))
        Next
        PictureBox2.Image = stretch
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ListBox1.Items.Clear()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim slide As New Bitmap(x, y)
        Dim offset As Integer = TextBox1.Text
        Dim r1 As Integer, g1 As Integer, b1 As Integer
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = r + offset
                g1 = g + offset
                b1 = b + offset
                If r1 > 255 Then r1 = 255
                If g1 > 255 Then g1 = 255
                If b1 > 255 Then b1 = 255
                red_s(r1) += 1 : green_s(g1) += 1 : blue_s(b1) += 1
                slide.SetPixel(i, j, Color.FromArgb(r1, g1, b1))
            Next
        Next
        For Me.k = 0 To 255
            ListBox1.Items.Add(Str(k) + "  R: " + Str(red_s(k)) + "  G: " + Str(green_s(k)) + "  B: " + Str(blue_s(k)))
            Chart1.Series("Red").Points.AddXY(k, red_s(k))
            Chart1.Series("Green").Points.AddXY(k, green_s(k))
            Chart1.Series("Blue").Points.AddXY(k, blue_s(k))
        Next
        PictureBox2.Image = slide
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ListBox1.Items.Clear()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim shrink As New Bitmap(x, y)
        Dim min As Integer = TextBox3.Text, max As Integer = TextBox2.Text
        Dim maxR As Integer, maxG As Integer, maxB As Integer
        Dim minR As Integer, minG As Integer, minB As Integer
        Dim r1 As Integer, g1 As Integer, b1 As Integer
        For Me.i = 0 To 255
            If red(i) <> 0 Then
                minR = i
                Exit For
            End If
        Next
        For Me.i = 0 To 255
            If green(i) <> 0 Then
                minG = i
                Exit For
            End If
        Next
        For Me.i = 0 To 255
            If blue(i) <> 0 Then
                minB = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If red(i) <> 0 Then
                maxR = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If green(i) <> 0 Then
                maxG = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If blue(i) <> 0 Then
                maxB = i
                Exit For
            End If
        Next
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = ((max - min) / (maxR - minR)) * ((r - minR) + min)
                g1 = ((max - min) / (maxG - minG)) * ((g - minG) + min)
                b1 = ((max - min) / (maxB - minB)) * ((b - minB) + min)
                If r1 > 255 Then r1 = 255
                If g1 > 255 Then g1 = 255
                If b1 > 255 Then b1 = 255
                red_sh(r1) += 1 : green_sh(g1) += 1 : blue_sh(b1) += 1
                shrink.SetPixel(i, j, Color.FromArgb(r1, g1, b1))
            Next
        Next
        For Me.k = 0 To 255
            ListBox1.Items.Add(Str(k) + "  R: " + Str(red_sh(k)) + "  G: " + Str(green_sh(k)) + "  B: " + Str(blue_sh(k)))
            Chart1.Series("Red").Points.AddXY(k, red_sh(k))
            Chart1.Series("Green").Points.AddXY(k, green_sh(k))
            Chart1.Series("Blue").Points.AddXY(k, blue_sh(k))
        Next
        PictureBox2.Image = shrink
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        End
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ListBox1.Items.Clear()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim equalization As New Bitmap(x, y)
        Dim sumR(0 To 255) As Integer, sumG(0 To 255) As Integer, sumB(0 To 255) As Integer
        Dim maxR As Integer, maxG As Integer, maxB As Integer
        Dim r1 As Integer, g1 As Integer, b1 As Integer
        For Me.i = 255 To 0 Step -1
            If red(i) <> 0 Then
                maxR = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If green(i) <> 0 Then
                maxG = i
                Exit For
            End If
        Next
        For Me.i = 255 To 0 Step -1
            If blue(i) <> 0 Then
                maxB = i
                Exit For
            End If
        Next
        redCDF(0) = red(0)
        greenCDF(0) = green(0)
        blueCDF(0) = blue(0)
        For Me.i = 1 To 255
            redCDF(i) = redCDF(i - 1) + red(i)
            greenCDF(i) = greenCDF(i - 1) + green(i)
            blueCDF(i) = blueCDF(i - 1) + blue(i)
        Next
        For Me.i = 0 To 255
            sumR(i) = Math.Round((redCDF(i) / (x * y)) * maxR)
            sumG(i) = Math.Round((greenCDF(i) / (x * y)) * maxG)
            sumB(i) = Math.Round((blueCDF(i) / (x * y)) * maxB)
        Next
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                r1 = sumR(r)
                g1 = sumG(g)
                b1 = sumB(b)
                If r1 > 255 Then r1 = 255
                If g1 > 255 Then g1 = 255
                If b1 > 255 Then b1 = 255
                red_e(r1) += 1 : green_e(g1) += 1 : blue_e(b1) += 1
                equalization.SetPixel(i, j, Color.FromArgb(r1, g1, b1))
            Next
        Next
        For Me.k = 0 To 255
            ListBox1.Items.Add(Str(k) + "  R: " + Str(red_e(k)) + "  G: " + Str(green_e(k)) + "  B: " + Str(blue_e(k)))
            Chart1.Series("Red").Points.AddXY(k, red_e(k))
            Chart1.Series("Green").Points.AddXY(k, green_e(k))
            Chart1.Series("Blue").Points.AddXY(k, blue_e(k))
        Next
        PictureBox2.Image = equalization
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim pixel As New Color
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim probR(0 To 255) As Double, probG(0 To 255) As Double, probB(0 To 255) As Double
        Dim meanR As Integer, meanG As Integer, meanB As Integer
        Dim SDR As Integer, SDG As Integer, SDB As Integer
        Dim EntropyR As Double, EntropyG As Double, EntropyB As Double
        Dim ENGR As Double, ENGG As Double, ENGB As Double
        For Me.i = 0 To x - 1
            For Me.j = 0 To y - 1
                pixel = img1.GetPixel(i, j)
                r = pixel.R : g = pixel.G : b = pixel.B
                Me.red(r) += 1
                Me.green(g) += 1
                Me.blue(b) += 1
            Next
        Next
        For Me.i = 0 To 255
            probr(i) = Math.Round(red(i) / (x * y), 2)
            probg(i) = Math.Round(green(i) / (x * y), 2)
            probb(i) = Math.Round(blue(i) / (x * y), 2)
            meanr += (i * probr(i))
            meang += (i * probg(i))
            meanb += (i * probb(i))
            SDR += Math.Round((i - meanR) ^ 2 * probR(i), 2)
            SDG += Math.Round((i - meanG) ^ 2 * probG(i), 2)
            SDB += Math.Round((i - meanB) ^ 2 * probB(i), 2)
            If probR(i) <> 0 Then
                EntropyR += probR(i) * (Math.Log(probR(i)) / Math.Log(2))
            End If
            If probG(i) <> 0 Then
                EntropyG += probG(i) * (Math.Log(probG(i)) / Math.Log(2))
            End If
            If probB(i) <> 0 Then
                EntropyB += probB(i) * Math.Log(probB(i), 2)
            End If
            ENGR += probR(i) ^ 2
            ENGG += probG(i) ^ 2
            ENGB += probB(i) ^ 2
            TextBox4.SelectedText = i & "  R: " & probR(i) & "  G: " & probG(i) & "  B: " & probB(i) & vbNewLine
        Next
        TextBox5.SelectedText = "R: " & meanR & "   G: " & meanG & "  B: " & meanB
        TextBox6.SelectedText = "R: " & Math.Sqrt(SDR) & "  G: " & Math.Sqrt(SDG) & "  B: " & Math.Sqrt(SDB)
        TextBox7.SelectedText = "R: " & EntropyR * -1 & "  G: " & EntropyG * -1 & "  B: " & EntropyB * -1
        TextBox8.SelectedText = "R: " & ENGR & "  G: " & ENGG & "  B: " & ENGB
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim img1 As New Bitmap(PictureBox1.Image)
        Dim subX As Integer = TextBox9.Text
        Dim subY As Integer = TextBox10.Text
        Dim a As Integer, b As Integer
        Dim subWidth As Integer = x \ subX
        Dim subHeight As Integer = y \ subY
        Dim segmented As New Bitmap(x, y)
        For Me.i = 0 To subX - 1
            For Me.j = 0 To subY - 1
                For a = i * subWidth + 1 To (i + 1) * subWidth - 1
                    For b = j * subHeight + 1 To (j + 1) * subHeight - 1
                        segmented.SetPixel(a, b, img1.GetPixel(a, b))
                    Next
                Next
                PictureBox2.Image = segmented
            Next
        Next
    End Sub
End Class