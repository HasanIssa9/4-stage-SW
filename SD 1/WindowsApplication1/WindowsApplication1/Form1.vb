Public Class Form1
    Dim letters As New Dictionary(Of String, Integer) From {{"a", 0}, {"b", 1}, {"c", 2}, {"d", 3}, {"e", 4}, {"f", 5}, {"g", 6}, {"h", 7}, {"i", 8}, {"j", 9}, {"k", 10}, {"l", 11}, {"m", 12}, {"n", 13}, {"o", 14}, {"p", 15}, {"q", 16}, {"r", 17}, {"s", 18}, {"t", 19}, {"u", 20}, {"v", 21}, {"w", 22}, {"x", 23}, {"y", 24}, {"z", 25}}
    Dim lettersArray As New List(Of Integer)
    Dim i As Integer, m As Integer, z As Integer
    Dim x As Char
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        lettersArray.Clear()
        For Me.i = 1 To TextBox1.TextLength
            x = Mid(TextBox1.Text, i, 1)
            ListBox1.Items.Add(x & " ... " & letters.Item(LCase(x)))
            lettersArray.Add(letters.Item(LCase(x)))
        Next
        m = MessageBox.Show(String.Join(" ", lettersArray))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        Dim pair As KeyValuePair(Of String, Integer)
        For Each pair In letters
            ListBox1.Items.Add(pair.Key & " ... " & pair.Value)
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub
End Class
