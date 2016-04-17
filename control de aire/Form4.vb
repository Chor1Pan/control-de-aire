Public Class Form4
    Dim contador As Integer = 11
    Dim imagenindice As Integer = 0
    Private Sub Form4_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        
    End Sub

    Private Sub Form4_Leave(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.Leave
        If contador < 10 Then
            e.Cancel = True
        Else
            e.Cancel = False
            Me.Dispose()
            Form1.Show()
            Form1.Focus()
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        imagenindice = imagenindice + 1
        If imagenindice = ImageList2.Images.Count Then
            imagenindice = 0
        End If
        PictureBox2.Image = ImageList2.Images(imagenindice)
    End Sub
End Class