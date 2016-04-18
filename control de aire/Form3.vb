
Imports ExpTreeLib
Imports ExpTreeLib.CShItem
Imports ExpTreeLib.SystemImageListManager
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports AxWMPLib
Imports WMPLib
Public Class Form3
    Inherits System.Windows.Forms.Form
    Dim archivoenlista As String
    Dim pausado As Integer = 0
    Dim fadestop As Integer
    Dim fadecount As Integer = 0
    Dim playlista As Boolean = False
    Dim indicelista As Integer
    Dim botonera1 As Boolean
    Dim botonera2 As Boolean
    Dim final As Integer = 0
    Dim contador As Integer = 0
    Dim contvolumen As Integer = 0
    Private hashMusica As New Hashtable()
    Dim sonido As New Reproductor
    Dim rs As New Resizer
    Dim launchpad As Boolean = False
    Dim testTime As New DateTime(1, 1, 1, 0, 0, 0)
    Dim tipoarchivo As String
    Private MouseIsDown As Boolean = False
    Private trackBarClick As Boolean
    Private LastSelectedCSI As CShItem
    Private Shared Event1 As New ManualResetEvent(True)
    Dim pisador1 As Boolean = False
    Dim pisador2 As Boolean = False

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        AxWindowsMediaPlayer1.settings.volume = 0
        columnas()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = Application.StartupPath & "\Resources\startup.mp3"
        AxWindowsMediaPlayer1.Ctlcontrols.play()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = ""
        MoveItemListView1.HideSelection = False
    End Sub

    Private Sub Form3_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
        columnas()
    End Sub
    Private Sub columnas()
        MoveItemListView1.Columns(0).Width = MoveItemListView1.Width * 80 / 100
        MoveItemListView1.Columns(1).Width = MoveItemListView1.Width * 14 / 100
        MoveItemListView1.Columns(2).Width = 0
        MoveItemListView1.Columns(3).Width = 0
        lv1.Columns(0).Width = lv1.Width * 74 / 100
        lv1.Columns(1).Width = lv1.Width * 20 / 100
    End Sub
    Private Sub ExpTree1_DoubleClick(sender As Object, e As EventArgs)
        ExpTree1.ExpandANode(ExpTree1.SelectedItem)
    End Sub
    Private Sub AfterNodeSelect(ByVal pathName As String, ByVal CSI As CShItem) Handles ExpTree1.ExpTreeNodeSelected
        Dim dirList As New ArrayList()
        Dim fileList As New ArrayList()
        Dim filetype As New ArrayList()
        Dim TotalItems As Integer
        LastSelectedCSI = CSI
        If CSI.DisplayName.Equals(CShItem.strMyComputer) Then
            'dirList = CSI.GetDirectories 'avoid re-query since only has dirs
        Else
            'dirList = CSI.GetDirectories
            fileList = CSI.GetFiles
        End If
        SetUpComboBox(CSI)
        TotalItems = dirList.Count + fileList.Count
        Event1.WaitOne()
        If TotalItems > 0 Then
            Dim item As CShItem
            dirList.Sort()
            fileList.Sort()

            sbr1.Text = pathName & "                 " & _
                        dirList.Count & " Directories " & fileList.Count & " Files"
            Dim combList As New ArrayList(TotalItems)
            combList.AddRange(dirList)
            combList.AddRange(fileList)
            lv1.BeginUpdate()
            lv1.Items.Clear()
            RichTextBox1.Text = ""
            If CSI.DisplayName.Equals("Escritorio") Or CSI.DisplayName.Equals("Desktop") Then
                TextBox2.Text = CShItem.DesktopDirectoryPath & "\"
            Else
                TextBox2.Text = CSI.Path & "\"
            End If
            For Each item In combList
                tipoarchivo = System.IO.Path.GetExtension(item.GetFileName)
                If item.IsFolder Or tipoarchivo = ".mp3" Or tipoarchivo = ".mp4" Or tipoarchivo = ".wav" Or tipoarchivo = ".wma" Or tipoarchivo = ".wmv" Or tipoarchivo = ".ogg" Or tipoarchivo = ".mpa" Or tipoarchivo = ".avi" Then
                    Dim lvi As New ListViewItem(item.DisplayName)
                    With lvi
                        .ImageKey = 0
                        If Not item.IsDisk And item.IsFileSystem And Not item.IsFolder Then
                            If item.Length > 1024 Then
                                .SubItems.Add(Format(item.Length / 1024, "#,### KB"))
                            Else
                                .SubItems.Add(Format(item.Length, "##0 Bytes"))
                            End If
                        Else
                            .SubItems.Add("")
                        End If
                        .SubItems.Add(System.IO.Path.GetExtension(item.GetFileName))
                        If item.IsDisk Then
                            .SubItems.Add("Disco de sistema")
                        Else
                            If item.LastWriteTime = testTime Then '"#1/1/0001 12:00:00 AM#" is empty
                                .SubItems.Add("")
                            Else
                                .SubItems.Add(item.LastWriteTime)
                            End If
                        End If
                        .ImageIndex = SystemImageListManager.GetIconIndex(item, True)
                        .Tag = item
                        .SubItems.Add(TextBox2.Text & item.GetFileName)
                    End With
                    lv1.Items.Add(lvi)
                End If
            Next
            lv1.EndUpdate()
            LoadLV1Images()
        Else
            lv1.Items.Clear()
            lv1.Items.Add("No se encontraron archivos")
        End If
    End Sub
    Private BackList As ArrayList

    Private Sub SetUpComboBox(ByVal item As CShItem)
        BackList = New ArrayList()
        With cb1
            .Items.Clear()
            .Text = ""
            Dim CSI As CShItem = item
            Do While Not IsNothing(CSI.Parent)
                CSI = CSI.Parent
                BackList.Add(CSI)
                .Items.Add(CSI.DisplayName)
            Loop
            .SelectedIndex = -1
        End With
        lv1.Focus()
    End Sub

    Private Sub cb1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb1.SelectedIndexChanged
        With cb1
            If .SelectedIndex > -1 AndAlso _
                 .SelectedIndex < BackList.Count Then
                Dim item As CShItem = BackList(.SelectedIndex)
                BackList = New ArrayList()
                .Items.Clear()
                ExpTree1.RootItem = item
            End If
        End With
    End Sub

    Private Sub LoadLV1Images()
        Dim ts As New ThreadStart(AddressOf DoLoadLv)
        Dim ot As New Thread(ts)
        Event1.Reset()
        ot.Start()
    End Sub

    Private Sub DoLoadLv()
        On Error Resume Next
        Dim lvi As ListViewItem
        For Each lvi In lv1.Items
            lvi.ImageIndex = 0
        Next
        Event1.Set()
    End Sub

    Private Sub lv1_DoubleClick(sender As Object, e As EventArgs) Handles lv1.DoubleClick
        On Error Resume Next
        TextBox1.Text = lv1.SelectedItems(0).SubItems(0).Text & lv1.SelectedItems(0).SubItems(2).Text
        Dim vUltimoCaracter As String = TextBox2.Text.Substring(TextBox2.Text.Length - 1)
        lv1.DoDragDrop(lv1.SelectedItems(0).Text, DragDropEffects.Link)
        If MouseIsDown Then
            If vUltimoCaracter = "\" Then
                TextBox2.Text = Mid(TextBox2.Text, 1, Len(TextBox2.Text) - 1)
            End If
            IniciarReproduccion2(TextBox2.Text & "\" & TextBox1.Text)
            archivoenlista = System.IO.Path.GetFileNameWithoutExtension(TextBox2.Text & "\" & TextBox1.Text)
        End If
    End Sub
    Private Sub lv1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles lv1.ItemDrag
        lv1.DoDragDrop(lv1.SelectedItems(0).SubItems(4).Text, DragDropEffects.Copy)
        'End If
        'MouseIsDown = False
    End Sub
    Public Sub DetenerReproduccion2()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub
    Public Sub IniciarReproduccion2(ByVal archivoaudio As String)
        If archivoaudio <> "" Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            AxWindowsMediaPlayer1.URL = archivoaudio
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            contador = 0
            timercanciontiempo.Enabled = True
        End If
    End Sub


    Public Function Tamano2(ByVal sec As Long) As String
        Dim mins As Long
        If sec < 60 Then
            Return "00:" & Format(sec, "00")
        ElseIf sec > 59 Then
            mins = CLng(Int(sec / 60))
            sec = sec - (mins * 60)
            Return Format(mins, "00") & ":" & Format(sec, "00")
        Else
            Return ""
        End If
    End Function
    Public Function Tamano3(ByVal tamanio As Long) As String
        Dim sec As Long = tamanio
        Dim mins As Long
        If sec < 60 Then
            Return "00:" & Format(sec, "00")
        ElseIf sec > 59 Then
            mins = CLng(Int(sec / 60))
            sec = sec - (mins * 60)
            Return Format(mins, "00") & ":" & Format(sec, "00")
        Else
            Return ""
        End If
    End Function
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles timercanciontiempo.Tick
        AxWindowsMediaPlayer1.settings.volume = 0
        contador = contador + 1
        If contador = 3 Then
            timercanciontiempo.Enabled = False
            MoveItemListView1.Items.Add(archivoenlista, 3)
            MoveItemListView1.Items(MoveItemListView1.Items.Count - 1).SubItems.Add(Tamano2(AxWindowsMediaPlayer1.currentMedia.duration))
            MoveItemListView1.Items(MoveItemListView1.Items.Count - 1).SubItems.Add(AxWindowsMediaPlayer1.URL)
            MoveItemListView1.Items(MoveItemListView1.Items.Count - 1).SubItems.Add(AxWindowsMediaPlayer1.currentMedia.duration)

            Dim Total As Double, i As Integer
            If MoveItemListView1.Items.Count = 0 Then
                Label7.Text = "00:00"
            Else
                For i = 0 To MoveItemListView1.Items.Count - 1
                    Total = Total + MoveItemListView1.Items(i).SubItems(3).Text
                    Label7.Text = Tamano3(Total)
                Next
            End If
            Label8.Text = MoveItemListView1.Items.Count
        End If
    End Sub

    Private Sub MoveItemListView1_DragDrop(sender As Object, e As DragEventArgs) Handles MoveItemListView1.DragDrop
        IniciarReproduccion2(e.Data.GetData(DataFormats.Text))
        archivoenlista = System.IO.Path.GetFileNameWithoutExtension(e.Data.GetData(DataFormats.Text))
    End Sub

    Private Sub MoveItemListView1_DragEnter(sender As Object, e As DragEventArgs) Handles MoveItemListView1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Copy

        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

   
    Private Sub lv1_MouseDown(sender As Object, e As MouseEventArgs) Handles lv1.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        Try
            columnas()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SplitContainer1_SplitterMoving(sender As Object, e As SplitterCancelEventArgs) Handles SplitContainer1.SplitterMoving
        columnas()
    End Sub
    Private Sub Lv1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles lv1.ColumnWidthChanged
        Static FireMe As Boolean = True
        If FireMe = True Then
            FireMe = False
            columnas()
            FireMe = True
        End If
    End Sub

    Private Sub Lv1_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lv1.ColumnWidthChanging
        e.Cancel = True
    End Sub
    Private Sub MoveItemListView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles MoveItemListView1.ColumnWidthChanged
        Static FireMe As Boolean = True
        If FireMe = True Then
            FireMe = False
            columnas()
            FireMe = True
        End If
    End Sub

    Private Sub MoveItemListView1_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles MoveItemListView1.ColumnWidthChanging
        e.Cancel = True
    End Sub

    Private Sub MoveItemListView1_MouseDown(sender As Object, e As MouseEventArgs) Handles MoveItemListView1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If MoveItemListView1.SelectedItems.Count > 0 Then
                Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
                item.Remove()
                If MoveItemListView1.Items.Count = 0 Then
                    Label7.Text = "00:00"
                Else
                    Dim Total As Double, i As Integer
                    For i = 0 To MoveItemListView1.Items.Count - 1
                        Total = Total + MoveItemListView1.Items(i).SubItems(3).Text
                        Label7.Text = Tamano3(Total)
                    Next
                End If
                Label8.Text = MoveItemListView1.Items.Count
            End If
            If MoveItemListView1.Items.Count > 0 Then
                If indicelista = MoveItemListView1.Items.Count Then
                    indicelista = indicelista - 1
                    If MoveItemListView1.SelectedItems.Count = 0 Then
                        Me.MoveItemListView1.Items(indicelista).Focused = True
                        Me.MoveItemListView1.Items(indicelista).Selected = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub MoveItemListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles MoveItemListView1.SelectedIndexChanged
        If MoveItemListView1.Items.Count > 0 Then
            If MoveItemListView1.SelectedItems.Count > 0 Then
                indicelista = MoveItemListView1.SelectedIndices(0)
                If MoveItemListView1.SelectedItems.Count = 0 Then
                    Me.MoveItemListView1.Items(indicelista).Focused = True
                    Me.MoveItemListView1.Items(indicelista).Selected = True
                End If
            End If
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        If Not ExpTree1.SelectedItem Is Nothing Then
            ExpTree1.RefreshTree()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MoveItemListView1.Items.Clear()
        Dim Total As Double, i As Integer
        If MoveItemListView1.Items.Count = 0 Then
            Label7.Text = "00:00"
        Else
            For i = 0 To MoveItemListView1.Items.Count - 1
                Total = Total + MoveItemListView1.Items(i).SubItems(3).Text
                Label7.Text = Tamano3(Total)
            Next
        End If
        Label8.Text = MoveItemListView1.Items.Count
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If Not ExpTree1.SelectedItem Is Nothing Then
            ExpTree1.RefreshTree()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Lista de reprodución (*.tan)|*.tan"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.DefaultExt = "cal"
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.Title = "Guardar lista de reproducción"
        If SaveFileDialog1.ShowDialog Then
            Try
                Dim sw As New IO.StreamWriter(SaveFileDialog1.FileName, False)
                For i As Integer = 0 To Me.MoveItemListView1.Items.Count - 1
                    sw.WriteLine(((MoveItemListView1.Items(i).Text & vbTab) + MoveItemListView1.Items(i).SubItems(1).Text() & vbTab) + MoveItemListView1.Items(i).SubItems(2).Text() & vbTab + MoveItemListView1.Items(i).SubItems(3).Text())
                Next
                sw.Close()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub Label8_TextChanged(sender As Object, e As EventArgs) Handles Label8.TextChanged
        If Label8.Text = 0 Then
            Button3.Enabled = False
            Button4.Enabled = False
        Else
            Button3.Enabled = True
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "Lista de reprodución (*.tan)|*.tan"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            MoveItemListView1.Items.Clear()
            Dim filepath As String = OpenFileDialog1.FileName
            Dim inputstream As New IO.StreamReader(filepath)
            Dim newstr(2) As String
            Dim IP As String
            Dim Port As String
            Dim Protocol As String
            Dim Type As String
            Do While inputstream.Peek <> -1
                newstr = inputstream.ReadLine().Split(vbTab)
                IP = newstr(0)
                Port = newstr(1)
                Protocol = newstr(2)
                Type = newstr(3)
                Me.MoveItemListView1.Items.Add(IP)
                Me.MoveItemListView1.Items.Item(MoveItemListView1.Items.Count - 1).SubItems.Add(Port)
                Me.MoveItemListView1.Items.Item(MoveItemListView1.Items.Count - 1).SubItems.Add(Protocol)
                Me.MoveItemListView1.Items.Item(MoveItemListView1.Items.Count - 1).SubItems.Add(Type)
            Loop
            Dim Total As Double, i As Integer
            If MoveItemListView1.Items.Count = 0 Then
                Label7.Text = "00:00"
            Else
                For i = 0 To MoveItemListView1.Items.Count - 1
                    Total = Total + MoveItemListView1.Items(i).SubItems(3).Text
                    Label7.Text = Tamano3(Total)
                Next
            End If
            Label8.Text = MoveItemListView1.Items.Count
            inputstream.Close()
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        OpenFileDialog1.Filter = "Lista de reprodución (*.cal)|*.cal"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Form2.cargarlista(OpenFileDialog1.FileName)
        End If
    End Sub
End Class



