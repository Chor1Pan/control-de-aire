Public Class Form4
    Dim contador As Integer = 0
    Dim recurso As Integer = 0
    Dim imagenindice As Integer = 0

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        Version.Text = "Versión: " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        Form1.Hide()
        Form2.Hide()
        Form3.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        imagenindice = imagenindice + 1
        If imagenindice = ImageList2.Images.Count Then
            imagenindice = 0
        End If
        PictureBox2.Image = ImageList2.Images(imagenindice)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        contador = contador + 1
        If contador >= 10 Then

        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        On Error Resume Next
        recurso = recurso + 1
        If System.IO.File.Exists(My.Application.Info.LoadedAssemblies(recurso).Location) = True Then
            Label2.Text = "Comprobando: " & My.Application.Info.LoadedAssemblies(recurso).FullName.ToString & " (" & My.Application.Info.LoadedAssemblies(recurso).Location & ")"
        Else
            Label2.Text = "No existe el recurso"
            Application.Exit()
        End If
        If recurso >= My.Application.Info.LoadedAssemblies.Count - 1 Then
            Form1.Show()
            Form1.Focus()
            Me.Close()
        End If
        My.Application.DoEvents()
    End Sub
End Class