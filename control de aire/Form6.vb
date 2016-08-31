Imports System
Imports System.IO
Public Class Form6
    Dim rs As New Resizer
    Dim carpeta As String
    Dim indicecarpeta As Integer
    Dim buscando As Integer = 0
    Dim cancelar As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        buscar()
    End Sub

    Private Sub buscar()
        cancelar = False
        lv1.Items.Clear()
        Panel1.Visible = True
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        'Try
        Dim IP As String
        Dim Port As String
        Dim Protocol As String
        For i = 0 To ListBox2.Items.Count - 1
            On Error Resume Next
            Me.Update()
            Application.DoEvents()
            'Me.Text = ListBox2.Items(i).ToString
            If ListBox2.Items(i).ToString = carpeta & "$Recycle.Bin" Then
                ListBox2.SelectedIndex = i
            ElseIf ListBox2.Items(i).ToString = carpeta & "System Volume Information" Then
                ListBox2.SelectedIndex = i
            Else
                ListBox2.SelectedIndex = i
                'If item.IsFolder Or tipoarchivo = ".mp3" Or tipoarchivo = ".mp4" Or tipoarchivo = ".wav" Or tipoarchivo = ".wma" Or tipoarchivo = ".wmv" Or tipoarchivo = ".ogg" Or tipoarchivo = ".mpa" Or tipoarchivo = ".avi" Then
                For Each recent As String In My.Computer.FileSystem.GetFiles(ListBox2.SelectedItem.ToString & "\", FileIO.SearchOption.SearchAllSubDirectories, "*" & TextBox1.Text & "*.mp3", "*" & TextBox1.Text & "*.mp4", "*" & TextBox1.Text & "*.wav", "*" & TextBox1.Text & "*.wma", "*" & TextBox1.Text & "*.wmv", "*" & TextBox1.Text & "*.ogg", "*" & TextBox1.Text & "*.mpa", "*" & TextBox1.Text & "*.avi")
                    IP = System.IO.Path.GetFileNameWithoutExtension(recent)
                    Port = getTamFile(recent)
                    Protocol = recent
                    Me.lv1.Items.Add(IP)
                    Me.lv1.Items.Item(lv1.Items.Count - 1).SubItems.Add(Port)
                    Me.lv1.Items.Item(lv1.Items.Count - 1).SubItems.Add(Protocol)
                    ProgressBar1.Maximum = ListBox2.Items.Count
                    ProgressBar1.Value = ListBox2.SelectedIndex
                    Label5.Text = Protocol
                    Application.DoEvents()
                    If cancelar = True Then
                        Exit For
                    End If
                Next
            End If
            If cancelar = True Then
                Exit For
            End If
        Next
        Panel1.Visible = False
        GroupBox1.Enabled = True
        GroupBox2.Enabled = True
        If lv1.Items.Count = 0 Then
            lv1.Items.Clear()
            lv1.Items.Add("No se encontraron archivos")
        End If
    End Sub
    Public Function getTamFile(ByVal path As String) As String
        Dim fi As New FileInfo(path)
        If fi.Exists Then
            If (fi.Length / 1024) > 1024 Then
                Return Math.Round(((fi.Length / 1024) / 1024), 2).ToString() & " Mb"
            Else
                Return Math.Round((fi.Length / 1024), 2).ToString() & " Kb"
            End If
        Else
            Return String.Empty
        End If
    End Function
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        columnas()
        ComboBox1.Items.Clear()
        Dim drive As System.IO.DriveInfo
        For Each drive In System.IO.DriveInfo.GetDrives()
            If drive.IsReady = True Then
                ComboBox1.Items.Add(drive.Name)
            End If
        Next
        For Each drive In System.IO.DriveInfo.GetDrives()
            If drive.DriveType = IO.DriveType.Network Then
                ComboBox1.Items.Add(drive.Name)
            End If
        Next
        ComboBox1.SelectedIndex = 0
        indicecarpeta = ComboBox1.SelectedIndex
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        ComboBox1.Items.Clear()
                Dim drive As System.IO.DriveInfo
        For Each drive In System.IO.DriveInfo.GetDrives()
            If drive.IsReady = True Then
                ComboBox1.Items.Add(drive.Name)
            End If
        Next
        For Each drive In System.IO.DriveInfo.GetDrives()
            If drive.DriveType = IO.DriveType.Network Then
                ComboBox1.Items.Add(drive.Name)
            End If
        Next
            ComboBox1.SelectedIndex = indicecarpeta
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        On Error Resume Next
        carpeta = ComboBox1.SelectedItem.ToString

        ListBox2.Items.Clear()
        For Each strFolder As String In _
      My.Computer.FileSystem.GetDirectories(carpeta)

            If strFolder = carpeta & "\$Recycle.Bin" Then

            ElseIf strFolder = carpeta & "\System Volume Information" Then

            Else
                ListBox2.Items.Add(strFolder)
            End If

        Next
        indicecarpeta = ComboBox1.SelectedIndex
    End Sub

    Private Sub lv1_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs) Handles lv1.ColumnWidthChanged
        Static FireMe As Boolean = True
        If FireMe = True Then
            FireMe = False
            columnas()
            FireMe = True
        End If
    End Sub

    Private Sub lv1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles lv1.ColumnWidthChanging
        Static FireMe As Boolean = True
        If FireMe = True Then
            FireMe = False
            columnas()
            FireMe = True
        End If
    End Sub

    Private Sub lv1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles lv1.ItemDrag
        lv1.DoDragDrop(lv1.SelectedItems(0).SubItems(2).Text, DragDropEffects.Copy)
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TextBox1.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
        Label4.Text = "Archivos encontrados: " & lv1.Items.Count
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        buscando = buscando + 1
        If buscando = 0 Then
            Label3.Text = "BUSCANDO"
        ElseIf buscando = 1 Then
            Label3.Text = "BUSCANDO."
        ElseIf buscando = 2 Then
            Label3.Text = "BUSCANDO.."
        ElseIf buscando = 3 Then
            Label3.Text = "BUSCANDO..."
        ElseIf buscando = 4 Then
            Label3.Text = "BUSCANDO"
            buscando = 0
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cancelar = True
    End Sub
    Private Sub columnas()
        lv1.Columns(0).Width = lv1.Width * 74 / 100
        lv1.Columns(1).Width = lv1.Width * 20 / 100
        lv1.Columns(2).Width = 0
    End Sub
    Private Sub Form6_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
        columnas()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            buscar()
        End If
    End Sub

    Private Sub lv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv1.SelectedIndexChanged

    End Sub
End Class
