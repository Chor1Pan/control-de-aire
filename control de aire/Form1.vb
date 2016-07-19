Imports ExpTreeLib
Imports ExpTreeLib.CShItem
Imports ExpTreeLib.SystemImageListManager
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports AxWMPLib
Imports WMPLib


Public Class Form1
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

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '      Dim NewVolume As Integer = ((UShort.MaxValue / 10) * 10)
        '       Dim NewVolumeAllChannels As UInteger = ((CUInt(100) And &HFFFF) Or (CUInt(NewVolume) << 16))
        '        Reproductor.waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels)

        Form2.Close()
        Form3.Close()
        Form4.Close()
        Application.Exit()
        Application.ExitThread()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        AxWindowsMediaPlayer1.settings.volume = 0
        columnas()
        Dim NewVolume As Integer = ((UShort.MaxValue / 10) * TrackBar2.Value)
        Dim NewVolumeAllChannels As UInteger = ((CUInt(NewVolume) And &HFFFF) Or (CUInt(NewVolume) << 16))
        Reproductor.waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels)
        MoveItemListView1.HideSelection = False
        TrackBar2.Value = 100
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = Application.StartupPath & "\Resources\startup.mp3"
        AxWindowsMediaPlayer1.Ctlcontrols.play()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer1.URL = ""
        MoveItemListView1.HideSelection = False
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
        columnas()
    End Sub

    Private Sub tiempoyhora_Tick(sender As Object, e As EventArgs) Handles tiempoyhora.Tick
        If Form2.Visible = True Then
            Panel1.Enabled = False
        Else
            Panel1.Enabled = True
        End If


        If Label10.Text = 10 Then
            fade.Interval = 100
        ElseIf Label10.Text = 9 Then
            fade.Interval = 90
        ElseIf Label10.Text = 8 Then
            fade.Interval = 80
        ElseIf Label10.Text = 7 Then
            fade.Interval = 70
        ElseIf Label10.Text = 6 Then
            fade.Interval = 60
        ElseIf Label10.Text = 5 Then
            fade.Interval = 50
        ElseIf Label10.Text = 4 Then
            fade.Interval = 40
        ElseIf Label10.Text = 3 Then
            fade.Interval = 30
        ElseIf Label10.Text = 2 Then
            fade.Interval = 20
        ElseIf Label10.Text = 1 Then
            fade.Interval = 10
        End If
        lbl_fecha.Text = FormatDateTime(Date.Now, DateFormat.LongDate)
        lbl_hora.Text = FormatDateTime(Date.Now, DateFormat.ShortTime) & ":" & Format(Date.Now.Second, "00")
        If MoveItemListView1.Items.Count = 0 Then
            indicelista = 0
        Else
            If MoveItemListView1.SelectedItems.Count = 0 Then
                Me.MoveItemListView1.Items(indicelista).Focused = True
                Me.MoveItemListView1.Items(indicelista).Selected = True
            End If
        End If
        If botonera1 = True Then
            GuardarBotoneraToolStripMenuItem.Enabled = True
            LimpiarBotoneraToolStripMenuItem.Enabled = True
        Else
            GuardarBotoneraToolStripMenuItem.Enabled = False
            LimpiarBotoneraToolStripMenuItem.Enabled = False
        End If
        If botonera2 = True Then
            ToolStripMenuItem1.Enabled = True
            ToolStripMenuItem3.Enabled = True
        Else
            ToolStripMenuItem1.Enabled = False
            ToolStripMenuItem3.Enabled = False
        End If
        If sonido.EstadoPausado = True Then
            TrackBar2.Value = 100
        End If
        If sonido.EstadoReproduciendo = False Then
            If sonido.EstadoPausado = True Then
                Button7.Enabled = True
            Else
                Button7.Enabled = False
            End If
        Else
            Button7.Enabled = True
        End If
    End Sub

    Private Sub LimpiarBotoneraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LimpiarBotoneraToolStripMenuItem.Click
        If MsgBox("Se borrarán todos los datos de la botonera." & vbCrLf & "¿Estás seguro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            For Each control As Button In GroupBox4.Controls
                If Not control.Name = "btn_menu1" Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If
                botonera1 = False
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If MsgBox("Se borrarán todos los datos de la botonera" & vbCrLf & "¿Estás seguro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            For Each control As Button In GroupBox5.Controls
                If Not control.Name = "btn_menu2" Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If
                botonera2 = False
            Next
        End If
    End Sub

    Private Sub btn_menu1_Click_1(sender As Object, e As EventArgs) Handles btn_menu1.Click
        menu1.Show(MousePosition.X, MousePosition.Y)
    End Sub

    Private Sub btn_menu2_Click(sender As Object, e As EventArgs) Handles btn_menu2.Click
        menu2.Show(MousePosition.X, MousePosition.Y)
    End Sub

    Private Sub ExpTree1_DoubleClick(sender As Object, e As EventArgs) Handles ExpTree1.DoubleClick
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

    Private Sub lv1_Click(sender As Object, e As EventArgs) Handles lv1.Click

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
    End Sub
    Private Sub Button1_DragDrop(sender As Object, e As DragEventArgs) Handles btnm1_1.DragDrop, btnm1_2.DragDrop, btnm1_3.DragDrop, btnm1_4.DragDrop, btnm1_5.DragDrop, btnm1_6.DragDrop, btnm1_7.DragDrop, btnm1_8.DragDrop, btnm1_9.DragDrop, btnm1_10.DragDrop, btnm1_11.DragDrop, btnm1_12.DragDrop, btnm1_13.DragDrop, btnm1_14.DragDrop, btnm1_15.DragDrop, btnm1_16.DragDrop, btnm1_17.DragDrop, btnm1_18.DragDrop, btnm1_19.DragDrop, btnm1_20.DragDrop, btnm1_21.DragDrop, btnm1_22.DragDrop, btnm1_23.DragDrop, btnm1_24.DragDrop, btnm1_25.DragDrop, btnm1_26.DragDrop, btnm1_27.DragDrop, btnm1_28.DragDrop, btnm1_29.DragDrop, btnm1_30.DragDrop, btnm2_1.DragDrop, btnm2_2.DragDrop, btnm2_3.DragDrop, btnm2_4.DragDrop, btnm2_5.DragDrop, btnm2_6.DragDrop, btnm2_7.DragDrop, btnm2_8.DragDrop, btnm2_9.DragDrop, btnm2_10.DragDrop, btnm2_11.DragDrop, btnm2_12.DragDrop, btnm2_13.DragDrop, btnm2_14.DragDrop, btnm2_15.DragDrop, btnm2_16.DragDrop, btnm2_17.DragDrop, btnm2_18.DragDrop, btnm2_19.DragDrop, btnm2_20.DragDrop, btnm2_21.DragDrop, btnm2_22.DragDrop, btnm2_23.DragDrop, btnm2_24.DragDrop, btnm2_25.DragDrop, btnm2_26.DragDrop, btnm2_27.DragDrop, btnm2_28.DragDrop, btnm2_29.DragDrop, btnm2_30.DragDrop
        CType(sender, Button).Text = System.IO.Path.GetFileNameWithoutExtension(e.Data.GetData(DataFormats.Text))
        CType(sender, Button).Tag = e.Data.GetData(DataFormats.Text)
        ToolTip1.SetToolTip(CType(sender, Button), CType(sender, Button).Text)
    End Sub

    Private Sub Button1_DragEnter(sender As Object, e As DragEventArgs) Handles btnm1_1.DragEnter, btnm1_2.DragEnter, btnm1_3.DragEnter, btnm1_4.DragEnter, btnm1_5.DragEnter, btnm1_6.DragEnter, btnm1_7.DragEnter, btnm1_8.DragEnter, btnm1_9.DragEnter, btnm1_10.DragEnter, btnm1_11.DragEnter, btnm1_12.DragEnter, btnm1_13.DragEnter, btnm1_14.DragEnter, btnm1_15.DragEnter, btnm1_16.DragEnter, btnm1_17.DragEnter, btnm1_18.DragEnter, btnm1_19.DragEnter, btnm1_20.DragEnter, btnm1_21.DragEnter, btnm1_22.DragEnter, btnm1_23.DragEnter, btnm1_24.DragEnter, btnm1_25.DragEnter, btnm1_26.DragEnter, btnm1_27.DragEnter, btnm1_28.DragEnter, btnm1_29.DragEnter, btnm1_30.DragEnter, btnm2_1.DragEnter, btnm2_2.DragEnter, btnm2_3.DragEnter, btnm2_4.DragEnter, btnm2_5.DragEnter, btnm2_6.DragEnter, btnm2_7.DragEnter, btnm2_8.DragEnter, btnm2_9.DragEnter, btnm2_10.DragEnter, btnm2_11.DragEnter, btnm2_12.DragEnter, btnm2_13.DragEnter, btnm2_14.DragEnter, btnm2_15.DragEnter, btnm2_16.DragEnter, btnm2_17.DragEnter, btnm2_18.DragEnter, btnm2_19.DragEnter, btnm2_20.DragEnter, btnm2_21.DragEnter, btnm2_22.DragEnter, btnm2_23.DragEnter, btnm2_24.DragEnter, btnm2_25.DragEnter, btnm2_26.DragEnter, btnm2_27.DragEnter, btnm2_28.DragEnter, btnm2_29.DragEnter, btnm2_30.DragEnter
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            e.Effect = DragDropEffects.Copy
            Windows.Forms.Cursor.Current = Cursors.Hand
        Else
            e.Effect = DragDropEffects.None
        End If
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
    Public Sub luegopausa()
        Button13.Enabled = True
        Button15.Enabled = True
        Button16.Enabled = True
        Dim selectedItem As Int32
        If MoveItemListView1.SelectedItems.Count > 0 Then
            selectedItem = MoveItemListView1.SelectedItems(0).Index
        End If
        If selectedItem < MoveItemListView1.Items.Count Then
            MoveItemListView1.Items(selectedItem).Selected = True
            Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
            Dim ruta As String = item.SubItems(2).Text
            IniciarReproduccion(ruta, item.SubItems(0).Text)
        End If
        If MoveItemListView1.SelectedItems.Count > 0 Then
            If launchpad = False Then
                reiniciarcolor()
                MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
                For Each item In MoveItemListView1.Items
                    item.ImageIndex = 3
                Next
                For Each item In MoveItemListView1.SelectedItems
                    item.ImageIndex = 2
                Next
            Else
                reiniciarcolor()
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        stTiempostotal.Text = sonido.Tamano()
        stTiempostranscurrido.Text = sonido.Posicion()
        stTiemposrestante.Text = sonido.restos
        Label5.Text = sonido.seg_restos
        Label13.Text = sonido.seg_restos
        If Not trackBarClick Then
            TrackBar1.Value = CInt(sonido.CalcularPosicion())
        End If
        Dim selectedItem As Int32
        If launchpad = True Then
            If MoveItemListView1.Items.Count > 0 Then
                If MoveItemListView1.SelectedItems.Count = 0 Then
                    Me.MoveItemListView1.Items(indicelista).Focused = True
                    Me.MoveItemListView1.Items(indicelista).Selected = True
                End If
            End If
            If sonido.EstadoDetenido Then
                DetenerReproduccion()
                If CheckBox1.Checked = True Then
                    abrirtanda()
                    CheckBox1.Checked = False
                    Exit Sub
                End If
                If MoveItemListView1.SelectedItems.Count > 0 Then
                    selectedItem = MoveItemListView1.SelectedItems(0).Index
                End If
                If selectedItem < MoveItemListView1.Items.Count Then
                    MoveItemListView1.Items(selectedItem).Selected = True
                    Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
                    Dim ruta As String = item.SubItems(2).Text
                    IniciarReproduccion(ruta, item.SubItems(0).Text)
                    playlista = True
                End If
                If MoveItemListView1.SelectedItems.Count > 0 Then
                    If launchpad = False Then
                        reiniciarcolor()
                        MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
                        For Each item In MoveItemListView1.Items
                            item.ImageIndex = 3
                        Next
                        For Each item In MoveItemListView1.SelectedItems
                            item.ImageIndex = 2
                        Next
                    Else
                        reiniciarcolor()
                    End If
                End If
            End If
        End If

        If sonido.EstadoDetenido Then
            DetenerReproduccion()
            If CheckBox1.Checked = True Then
                abrirtanda()
                CheckBox1.Checked = False
                Exit Sub
            End If
            If MoveItemListView1.SelectedItems.Count > 0 Then
                selectedItem = MoveItemListView1.SelectedItems(0).Index
            Else
                If MoveItemListView1.SelectedItems.Count > 0 Then
                    MoveItemListView1.Items(0).Selected = True
                End If
            End If
            If selectedItem < MoveItemListView1.Items.Count - 1 Then
                MoveItemListView1.Items(selectedItem + 1).Selected = True
                Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
                Dim ruta As String = item.SubItems(2).Text
                IniciarReproduccion(ruta, item.SubItems(0).Text)
            End If
            If MoveItemListView1.SelectedItems.Count > 0 Then
                If launchpad = False Then
                    reiniciarcolor()
                    MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
                    For Each item In MoveItemListView1.Items
                        item.ImageIndex = 3
                    Next
                    For Each item In MoveItemListView1.SelectedItems
                        item.ImageIndex = 2
                    Next
                Else
                    reiniciarcolor()
                End If
            End If
        End If
    End Sub
    Private Sub abrirtanda()
        DetenerReproduccion()
        Button13.Enabled = False
        Button15.Enabled = False
        Button16.Enabled = False
        Form2.Text = "Tanda: " & Label14.Text
        Form2.Show()
        Form2.adelante()
    End Sub
    Private Sub IniciarReproduccion3(ByVal archivoaudio As String, ByVal nombrearchivo As String)
        If archivoaudio <> "" Then
            AxWindowsMediaPlayer2.settings.volume = 100
            AxWindowsMediaPlayer2.URL = archivoaudio
            AxWindowsMediaPlayer2.Ctlcontrols.play()
            'contvolumen = 2
            'TrackBar2.Value = 2
            'pausado = 0
        End If
    End Sub
    Public Sub DetenerReproduccion3()
        AxWindowsMediaPlayer2.Ctlcontrols.stop()
        TrackBar2.Value = 100
        AxWindowsMediaPlayer2.settings.volume = 0
    End Sub

    Private Sub MoveItemListView1_DoubleClick(sender As Object, e As EventArgs) Handles MoveItemListView1.DoubleClick
        If MoveItemListView1.SelectedItems.Count > 0 Then
            reiniciarcolor()
            colorbotonera()
            Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
            Dim ruta As String = item.SubItems(2).Text
            IniciarReproduccion(ruta, item.SubItems(0).Text)
            playlista = True
            MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
            For Each item In MoveItemListView1.Items
                item.ImageIndex = 3
            Next
            For Each item In MoveItemListView1.SelectedItems
                item.ImageIndex = 2
            Next
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

    Private Sub btnm1_1_Click(sender As Object, e As EventArgs) Handles btnm1_1.Click, btnm1_2.Click, btnm1_3.Click, btnm1_4.Click, btnm1_5.Click, btnm1_6.Click, btnm1_7.Click, btnm1_8.Click, btnm1_9.Click, btnm1_10.Click, btnm1_11.Click, btnm1_12.Click, btnm1_13.Click, btnm1_14.Click, btnm1_15.Click, btnm1_16.Click, btnm1_17.Click, btnm1_18.Click, btnm1_19.Click, btnm1_20.Click, btnm1_21.Click, btnm1_22.Click, btnm1_23.Click, btnm1_24.Click, btnm1_25.Click, btnm1_26.Click, btnm1_27.Click, btnm1_28.Click, btnm1_29.Click, btnm1_30.Click
        If ToolStripMenuItem4.Checked = True Then
            If Not CType(sender, Button).Tag = "noitem" Then
                For Each Control As Button In GroupBox4.Controls
                    If Not Control.Name = "btn_menu1" Then
                        If Control.BackColor = Color.Green Then
                            Control.BackColor = Color.FromArgb(53, 87, 117)
                        End If
                    End If
                Next
                pisador1 = True
                IniciarReproduccion3(CType(sender, Button).Tag, CType(sender, Button).Text)
                CType(sender, Button).BackColor = Color.Green
            End If
        Else
            If Not CType(sender, Button).Tag = "noitem" Then
                pisador1 = False
                colorbotonera()
                IniciarReproduccion(CType(sender, Button).Tag, CType(sender, Button).Text)
                launchpad = True
                CType(sender, Button).BackColor = Color.Maroon
            End If
        End If
    End Sub

    Private Sub btnm2_1_Click(sender As Object, e As EventArgs) Handles btnm2_1.Click, btnm2_2.Click, btnm2_3.Click, btnm2_4.Click, btnm2_5.Click, btnm2_6.Click, btnm2_7.Click, btnm2_8.Click, btnm2_9.Click, btnm2_10.Click, btnm2_11.Click, btnm2_12.Click, btnm2_13.Click, btnm2_14.Click, btnm2_15.Click, btnm2_16.Click, btnm2_17.Click, btnm2_18.Click, btnm2_19.Click, btnm2_20.Click, btnm2_21.Click, btnm2_22.Click, btnm2_23.Click, btnm2_24.Click, btnm2_25.Click, btnm2_26.Click, btnm2_27.Click, btnm2_28.Click, btnm2_29.Click, btnm2_30.Click
        If ToolStripMenuItem5.Checked = True Then
            If Not CType(sender, Button).Tag = "noitem" Then
                For Each Control As Button In GroupBox5.Controls
                    If Not Control.Name = "btn_menu2" Then
                        If Control.BackColor = Color.Green Then
                            Control.BackColor = Color.FromArgb(53, 87, 117)
                        End If
                    End If
                Next
                pisador2 = True
                IniciarReproduccion3(CType(sender, Button).Tag, CType(sender, Button).Text)
                CType(sender, Button).BackColor = Color.Green
            End If
        Else
            If Not CType(sender, Button).Tag = "noitem" Then
                pisador2 = False
                colorbotonera()

                IniciarReproduccion(CType(sender, Button).Tag, CType(sender, Button).Text)
                launchpad = True
                CType(sender, Button).BackColor = Color.Maroon
            End If
        End If
    End Sub

    Private Sub btnm1_1_TextChanged(sender As Object, e As EventArgs) Handles btnm1_1.TextChanged, btnm1_2.TextChanged, btnm1_3.TextChanged, btnm1_4.TextChanged, btnm1_5.TextChanged, btnm1_6.TextChanged, btnm1_7.TextChanged, btnm1_8.TextChanged, btnm1_9.TextChanged, btnm1_10.TextChanged, btnm1_11.TextChanged, btnm1_12.TextChanged, btnm1_13.TextChanged, btnm1_14.TextChanged, btnm1_15.TextChanged, btnm1_16.TextChanged, btnm1_17.TextChanged, btnm1_18.TextChanged, btnm1_19.TextChanged, btnm1_20.TextChanged, btnm1_21.TextChanged, btnm1_22.TextChanged, btnm1_23.TextChanged, btnm1_24.TextChanged, btnm1_25.TextChanged, btnm1_26.TextChanged, btnm1_27.TextChanged, btnm1_28.TextChanged, btnm1_29.TextChanged, btnm1_30.TextChanged
        If Not CType(sender, Button).Text = "" Then
            botonera1 = True
        End If
    End Sub

    Private Sub btnm2_1_TextChanged(sender As Object, e As EventArgs) Handles btnm2_1.TextChanged, btnm2_2.TextChanged, btnm2_3.TextChanged, btnm2_4.TextChanged, btnm2_5.TextChanged, btnm2_6.TextChanged, btnm2_7.TextChanged, btnm2_8.TextChanged, btnm2_9.TextChanged, btnm2_10.TextChanged, btnm2_11.TextChanged, btnm2_12.TextChanged, btnm2_13.TextChanged, btnm2_14.TextChanged, btnm2_15.TextChanged, btnm2_16.TextChanged, btnm2_17.TextChanged, btnm2_18.TextChanged, btnm2_19.TextChanged, btnm2_20.TextChanged, btnm2_21.TextChanged, btnm2_22.TextChanged, btnm2_23.TextChanged, btnm2_24.TextChanged, btnm2_25.TextChanged, btnm2_26.TextChanged, btnm2_27.TextChanged, btnm2_28.TextChanged, btnm2_29.TextChanged, btnm2_30.TextChanged
        If Not CType(sender, Button).Text = "" Then
            botonera2 = True
        End If
    End Sub
    Private Sub lv1_MouseDown(sender As Object, e As MouseEventArgs) Handles lv1.MouseDown
        MouseIsDown = True
    End Sub

    Private Sub DetenerReproduccion()
        Label13.Text = 0
        reiniciarcolor()
        colorbotonera()
        playlista = False
        launchpad = False
        sonido.Cerrar()
        Timer1.Enabled = False
        Timer1.Stop()
        pausa.Stop()
        pausado = 0
        TrackBar1.Value = 0
        Label1.BackColor = Color.FromArgb(64, 0, 0) '53, 87, 117
        lblcancion.BackColor = Color.FromArgb(53, 87, 117)
        reiniciarcolor()
        For Each item In MoveItemListView1.Items
            item.ImageIndex = 3
        Next
        lblcancion.Text = ""
        Button9.Enabled = False
        Button8.Enabled = True
    End Sub
    Private Sub IniciarReproduccion(ByVal archivoaudio As String, ByVal nombrearchivo As String)
        If archivoaudio <> "" Then
            If sonido.EstadoReproduciendo() Then DetenerReproduccion()
            sonido.NombreDeArchivo = archivoaudio
            sonido.Reproducir()
            TrackBar1.Minimum = 0
            lblcancion.Text = nombrearchivo
            TrackBar1.Maximum = sonido.CalcularTamano()
            Label1.BackColor = Color.Red
            Button8.Enabled = False
            Button9.Enabled = True
            contvolumen = 0
            TrackBar2.Value = 0
            If sonido.CalcularTamano < 15 Then
                TrackBar1.TickFrequency = 1
            Else
                TrackBar1.TickFrequency = sonido.CalcularTamano / 15
            End If
            Timer1.Enabled = True
            Timer1.Start()
            pausa.Stop()
            pausado = 0
            TrackBar2.Value = 0
            Timer2.Start()
        End If
    End Sub

    Private Sub trackBar1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseDown
        trackBarClick = True
    End Sub

    Private Sub trackBar1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar1.MouseUp
        trackBarClick = False
        sonido.Detener()
        sonido.Reposicionar(TrackBar1.Value)
        sonido.ReproducirDesde(TrackBar1.Value)
        Timer1.Start()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Se borrarán todos los datos de la lista " & vbCrLf & "¿Estás seguro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
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
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If sonido.EstadoReproduciendo Then
            If MoveItemListView1.Items.Count > 1 Then
                Dim selectedItem As Int32
                If MoveItemListView1.SelectedItems.Count > 0 Then
                    selectedItem = MoveItemListView1.SelectedItems(0).Index
                End If

                If selectedItem < MoveItemListView1.Items.Count - 1 Then
                    MoveItemListView1.Items(selectedItem + 1).Selected = True
                    Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
                    Dim ruta As String = item.SubItems(2).Text
                    IniciarReproduccion(ruta, item.SubItems(0).Text)
                    reiniciarcolor()
                    colorbotonera()
                    MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
                    For Each item In MoveItemListView1.Items
                        item.ImageIndex = 3
                    Next
                    For Each item In MoveItemListView1.SelectedItems
                        item.ImageIndex = 2
                    Next
                    playlista = True
                End If
            Else
                Dim selectedItem As Int32
                If MoveItemListView1.SelectedItems.Count > 0 Then
                    selectedItem = MoveItemListView1.SelectedItems(0).Index
                    reiniciarcolor()
                    colorbotonera()
                    MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
                    For Each item In MoveItemListView1.Items
                        item.ImageIndex = 3
                    Next
                    For Each item In MoveItemListView1.SelectedItems
                        item.ImageIndex = 2
                    Next
                End If
                If selectedItem < MoveItemListView1.Items.Count Then
                    MoveItemListView1.Items(selectedItem).Selected = True
                    Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
                    Dim ruta As String = item.SubItems(2).Text
                    IniciarReproduccion(ruta, item.SubItems(0).Text)
                    reiniciarcolor()
                    colorbotonera()
                    MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
                    For Each item In MoveItemListView1.Items
                        item.ImageIndex = 3
                    Next
                    For Each item In MoveItemListView1.SelectedItems
                        item.ImageIndex = 2
                    Next
                    playlista = True
                End If
            End If
        Else
            Dim selectedItem As Int32
            If MoveItemListView1.SelectedItems.Count > 0 Then
                selectedItem = MoveItemListView1.SelectedItems(0).Index
            End If

            If selectedItem < MoveItemListView1.Items.Count - 1 Then
                MoveItemListView1.Items(selectedItem + 1).Selected = True
                Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
                Dim ruta As String = item.SubItems(2).Text
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim selectedItem As Int32
        If MoveItemListView1.SelectedItems.Count > 0 Then
            selectedItem = MoveItemListView1.SelectedItems(0).Index
            reiniciarcolor()
            colorbotonera()
            MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
            For Each item In MoveItemListView1.Items
                item.ImageIndex = 3
            Next
            For Each item In MoveItemListView1.SelectedItems
                item.ImageIndex = 2
            Next
        End If
        If selectedItem < MoveItemListView1.Items.Count Then
            MoveItemListView1.Items(selectedItem).Selected = True
            Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
            Dim ruta As String = item.SubItems(2).Text
            IniciarReproduccion(ruta, item.SubItems(0).Text)
            reiniciarcolor()
            colorbotonera()
            MoveItemListView1.SelectedItems(0).ForeColor = Color.Chartreuse
            For Each item In MoveItemListView1.Items
                item.ImageIndex = 3
            Next
            For Each item In MoveItemListView1.SelectedItems
                item.ImageIndex = 2
            Next
            playlista = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If sonido.EstadoReproduciendo Then
            'Timer1.Stop()
            TrackBar1.Value = 0
            'sonido.Detener()
            sonido.Reposicionar(TrackBar1.Value)
            sonido.ReproducirDesde(TrackBar1.Value)
            'Timer1.Start()
        Else
            Dim selectedItem As Int32
            If MoveItemListView1.SelectedItems.Count > 0 Then
                selectedItem = MoveItemListView1.SelectedItems(0).Index
            End If
            If selectedItem > 0 Then
                MoveItemListView1.Items(selectedItem - 1).Selected = True
                Dim item As ListViewItem = MoveItemListView1.SelectedItems(0)
                Dim ruta As String = item.SubItems(2).Text
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        DetenerReproduccion()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        pausar()
    End Sub
    Public Sub pausar()
        If Button7.Tag = "Pausar" Then
            sonido.Pausar()
            Button7.Tag = "Continuar"
            Timer1.Stop()
            pausa.Start()
        Else
            sonido.Continuar()
            Button7.Tag = "Pausar"
            Timer1.Start()
            pausa.Stop()
            pausado = 0
            Label1.BackColor = Color.Red
        End If
    End Sub

    Private Sub pausa_Tick(sender As Object, e As EventArgs) Handles pausa.Tick
        If pausado = 0 Then
            Label1.BackColor = Color.FromArgb(64, 0, 0)
            pausado = 1
        Else
            Label1.BackColor = Color.Red
            pausado = 0
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Label10.Text = Label10.Text + 1
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Label10.Text = Label10.Text - 1
    End Sub

    Private Sub Label10_TextChanged1(sender As Object, e As EventArgs) Handles Label10.TextChanged
        If Label10.Text >= 10 Then
            Label10.Text = 10
        ElseIf Label10.Text <= 1 Then
            Label10.Text = 1
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If sonido.EstadoReproduciendo Then
            fadestop = TrackBar2.Value / Label10.Text
            fadecount = 0
            Button1.Enabled = False
            fade.Start()
        End If
    End Sub

    Private Sub fade_Tick(sender As Object, e As EventArgs) Handles fade.Tick
        'fadecount = fadecount + 1
        On Error Resume Next
        TrackBar2.Value = TrackBar2.Value - 1 'fadestop
        If TrackBar2.Value <= 0 Then
            DetenerReproduccion()
            Button1.Enabled = True
            TrackBar2.Value = 100
            fade.Stop()
        End If
    End Sub

    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        Dim NewVolume As Integer = ((UShort.MaxValue / 10) * TrackBar2.Value / 10)
        Dim NewVolumeAllChannels As UInteger = ((CUInt(NewVolume) And &HFFFF) Or (CUInt(NewVolume) << 16))
        Reproductor.waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels)
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Lista de reprodución (*.cal)|*.cal"
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
        OpenFileDialog1.Filter = "Lista de reprodución (*.cal)|*.cal"
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
                If System.IO.File.Exists(Protocol) = True Then
                    Me.MoveItemListView1.Items.Add(IP)
                    Me.MoveItemListView1.Items.Item(MoveItemListView1.Items.Count - 1).SubItems.Add(Port)
                    Me.MoveItemListView1.Items.Item(MoveItemListView1.Items.Count - 1).SubItems.Add(Protocol)
                    Me.MoveItemListView1.Items.Item(MoveItemListView1.Items.Count - 1).SubItems.Add(Type)
                End If
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

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        OpenFileDialog1.Filter = "Lista de reprodución (*.tan)|*.tan"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Form2.cargarlista(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If Not Label14.Text = "" Then
            abrirtanda()
        End If
    End Sub

    Private Sub Label14_TextChanged(sender As Object, e As EventArgs) Handles Label14.TextChanged
        If Label14.Text = "" Then
            Button14.Enabled = False
            Button15.Enabled = False
            CheckBox1.Enabled = False
        Else
            Button14.Enabled = True
            Button15.Enabled = True
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick_1(sender As Object, e As EventArgs) Handles Timer2.Tick
        On Error Resume Next
        contvolumen = contvolumen + 1
        TrackBar2.Value = TrackBar2.Value + 30
        If contvolumen >= 3 Then
            TrackBar2.Value = 100
            Timer2.Stop()
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Form3.Show()
    End Sub

    Private Sub reiniciarcolor()
        For i As Integer = 0 To MoveItemListView1.Items.Count - 1
            MoveItemListView1.Items(i).ForeColor = Color.Yellow
        Next
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

    Private Sub Label5_TextChanged(sender As Object, e As EventArgs) Handles Label5.TextChanged
        If Label5.Text < 1 Then
            If MoveItemListView1.SelectedItems.Count > 0 Then
                reiniciarcolor()
            End If
        End If
    End Sub
    Private Sub columnas()
        MoveItemListView1.Columns(0).Width = MoveItemListView1.Width * 80 / 100
        MoveItemListView1.Columns(1).Width = MoveItemListView1.Width * 14 / 100
        MoveItemListView1.Columns(2).Width = 0
        MoveItemListView1.Columns(3).Width = 0
        lv1.Columns(0).Width = lv1.Width * 74 / 100
        lv1.Columns(1).Width = lv1.Width * 20 / 100
    End Sub

    Private Sub GuardarBotoneraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarBotoneraToolStripMenuItem.Click
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos bpl|*.bpl"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.DefaultExt = "bpl"
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.Title = "Guardar lista de Botones"
        If SaveFileDialog1.ShowDialog Then
            Try
                Dim sw As New IO.StreamWriter(SaveFileDialog1.FileName, False)
                sw.WriteLine(btnm1_1.Tag)
                sw.WriteLine(btnm1_2.Tag)
                sw.WriteLine(btnm1_3.Tag)
                sw.WriteLine(btnm1_4.Tag)
                sw.WriteLine(btnm1_5.Tag)
                sw.WriteLine(btnm1_6.Tag)
                sw.WriteLine(btnm1_7.Tag)
                sw.WriteLine(btnm1_8.Tag)
                sw.WriteLine(btnm1_9.Tag)
                sw.WriteLine(btnm1_10.Tag)
                sw.WriteLine(btnm1_11.Tag)
                sw.WriteLine(btnm1_12.Tag)
                sw.WriteLine(btnm1_13.Tag)
                sw.WriteLine(btnm1_14.Tag)
                sw.WriteLine(btnm1_15.Tag)
                sw.WriteLine(btnm1_16.Tag)
                sw.WriteLine(btnm1_17.Tag)
                sw.WriteLine(btnm1_18.Tag)
                sw.WriteLine(btnm1_19.Tag)
                sw.WriteLine(btnm1_20.Tag)
                sw.WriteLine(btnm1_21.Tag)
                sw.WriteLine(btnm1_22.Tag)
                sw.WriteLine(btnm1_23.Tag)
                sw.WriteLine(btnm1_24.Tag)
                sw.WriteLine(btnm1_25.Tag)
                sw.WriteLine(btnm1_26.Tag)
                sw.WriteLine(btnm1_27.Tag)
                sw.WriteLine(btnm1_28.Tag)
                sw.WriteLine(btnm1_29.Tag)
                sw.WriteLine(btnm1_30.Tag)
                sw.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "Archivos bpl|*.bpl"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.DefaultExt = "bpl"
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.Title = "Guardar lista de Botones"
        If SaveFileDialog1.ShowDialog Then
            Try
                Dim sw As New IO.StreamWriter(SaveFileDialog1.FileName, False)
                sw.WriteLine(btnm2_1.Tag)
                sw.WriteLine(btnm2_2.Tag)
                sw.WriteLine(btnm2_3.Tag)
                sw.WriteLine(btnm2_4.Tag)
                sw.WriteLine(btnm2_5.Tag)
                sw.WriteLine(btnm2_6.Tag)
                sw.WriteLine(btnm2_7.Tag)
                sw.WriteLine(btnm2_8.Tag)
                sw.WriteLine(btnm2_9.Tag)
                sw.WriteLine(btnm2_10.Tag)
                sw.WriteLine(btnm2_11.Tag)
                sw.WriteLine(btnm2_12.Tag)
                sw.WriteLine(btnm2_13.Tag)
                sw.WriteLine(btnm2_14.Tag)
                sw.WriteLine(btnm2_15.Tag)
                sw.WriteLine(btnm2_16.Tag)
                sw.WriteLine(btnm2_17.Tag)
                sw.WriteLine(btnm2_18.Tag)
                sw.WriteLine(btnm2_19.Tag)
                sw.WriteLine(btnm2_20.Tag)
                sw.WriteLine(btnm2_21.Tag)
                sw.WriteLine(btnm2_22.Tag)
                sw.WriteLine(btnm2_23.Tag)
                sw.WriteLine(btnm2_24.Tag)
                sw.WriteLine(btnm2_25.Tag)
                sw.WriteLine(btnm2_26.Tag)
                sw.WriteLine(btnm2_27.Tag)
                sw.WriteLine(btnm2_28.Tag)
                sw.WriteLine(btnm2_29.Tag)
                sw.WriteLine(btnm2_30.Tag)
                sw.Close()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub AbrirBotoneraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirBotoneraToolStripMenuItem.Click
        OpenFileDialog1.Filter = "Archivos bpl|*.bpl"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filepath As String = OpenFileDialog1.FileName
            Dim sr As New IO.StreamReader(filepath)
            Dim newstr(2) As String
            Dim IP As String
            IP = sr.ReadToEnd()
            sr.Close()
            RichTextBox2.Text = IP
            For Each control As Button In GroupBox4.Controls
                If Not control.Name = "btn_menu1" Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If

            Next
            On Error Resume Next
            btnm1_1.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(0))
            btnm1_2.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(1))
            btnm1_3.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(2))
            btnm1_4.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(3))
            btnm1_5.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(4))
            btnm1_6.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(5))
            btnm1_7.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(6))
            btnm1_8.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(7))
            btnm1_9.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(8))
            btnm1_10.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(9))
            btnm1_11.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(10))
            btnm1_12.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(11))
            btnm1_13.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(12))
            btnm1_14.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(13))
            btnm1_15.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(14))
            btnm1_16.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(15))
            btnm1_17.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(16))
            btnm1_18.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(17))
            btnm1_19.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(18))
            btnm1_20.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(19))
            btnm1_21.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(20))
            btnm1_22.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(21))
            btnm1_23.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(22))
            btnm1_24.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(23))
            btnm1_25.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(24))
            btnm1_26.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(25))
            btnm1_27.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(26))
            btnm1_28.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(27))
            btnm1_29.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(28))
            btnm1_30.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(29))
            btnm1_1.Tag = RichTextBox2.Lines(0)
            btnm1_2.Tag = RichTextBox2.Lines(1)
            btnm1_3.Tag = RichTextBox2.Lines(2)
            btnm1_4.Tag = RichTextBox2.Lines(3)
            btnm1_5.Tag = RichTextBox2.Lines(4)
            btnm1_6.Tag = RichTextBox2.Lines(5)
            btnm1_7.Tag = RichTextBox2.Lines(6)
            btnm1_8.Tag = RichTextBox2.Lines(7)
            btnm1_9.Tag = RichTextBox2.Lines(8)
            btnm1_10.Tag = RichTextBox2.Lines(9)
            btnm1_11.Tag = RichTextBox2.Lines(10)
            btnm1_12.Tag = RichTextBox2.Lines(11)
            btnm1_13.Tag = RichTextBox2.Lines(12)
            btnm1_14.Tag = RichTextBox2.Lines(13)
            btnm1_15.Tag = RichTextBox2.Lines(14)
            btnm1_16.Tag = RichTextBox2.Lines(15)
            btnm1_17.Tag = RichTextBox2.Lines(16)
            btnm1_18.Tag = RichTextBox2.Lines(17)
            btnm1_19.Tag = RichTextBox2.Lines(18)
            btnm1_20.Tag = RichTextBox2.Lines(19)
            btnm1_21.Tag = RichTextBox2.Lines(20)
            btnm1_22.Tag = RichTextBox2.Lines(21)
            btnm1_23.Tag = RichTextBox2.Lines(22)
            btnm1_24.Tag = RichTextBox2.Lines(23)
            btnm1_25.Tag = RichTextBox2.Lines(24)
            btnm1_26.Tag = RichTextBox2.Lines(25)
            btnm1_27.Tag = RichTextBox2.Lines(26)
            btnm1_28.Tag = RichTextBox2.Lines(27)
            btnm1_29.Tag = RichTextBox2.Lines(28)
            btnm1_30.Tag = RichTextBox2.Lines(29)
            For Each control As Button In GroupBox4.Controls
                If control.Text = "noitem" Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If
            Next

            For Each control As Button In GroupBox4.Controls
                If System.IO.File.Exists(control.Tag) = False Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        OpenFileDialog1.Filter = "Archivos bpl|*.bpl"
        OpenFileDialog1.FileName = ""
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim filepath As String = OpenFileDialog1.FileName
            Dim sr As New IO.StreamReader(filepath)
            Dim newstr(2) As String
            Dim IP As String

            IP = sr.ReadToEnd()
            sr.Close()
            RichTextBox2.Text = IP
            For Each control As Button In GroupBox5.Controls
                If Not control.Name = "btn_menu2" Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If
            Next
            On Error Resume Next
            btnm2_1.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(0))
            btnm2_2.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(1))
            btnm2_3.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(2))
            btnm2_4.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(3))
            btnm2_5.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(4))
            btnm2_6.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(5))
            btnm2_7.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(6))
            btnm2_8.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(7))
            btnm2_9.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(8))
            btnm2_10.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(9))
            btnm2_11.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(10))
            btnm2_12.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(11))
            btnm2_13.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(12))
            btnm2_14.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(13))
            btnm2_15.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(14))
            btnm2_16.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(15))
            btnm2_17.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(16))
            btnm2_18.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(17))
            btnm2_19.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(18))
            btnm2_20.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(19))
            btnm2_21.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(20))
            btnm2_22.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(21))
            btnm2_23.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(22))
            btnm2_24.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(23))
            btnm2_25.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(24))
            btnm2_26.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(25))
            btnm2_27.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(26))
            btnm2_28.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(27))
            btnm2_29.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(28))
            btnm2_30.Text = System.IO.Path.GetFileNameWithoutExtension(RichTextBox2.Lines(29))
            btnm2_1.Tag = RichTextBox2.Lines(0)
            btnm2_2.Tag = RichTextBox2.Lines(1)
            btnm2_3.Tag = RichTextBox2.Lines(2)
            btnm2_4.Tag = RichTextBox2.Lines(3)
            btnm2_5.Tag = RichTextBox2.Lines(4)
            btnm2_6.Tag = RichTextBox2.Lines(5)
            btnm2_7.Tag = RichTextBox2.Lines(6)
            btnm2_8.Tag = RichTextBox2.Lines(7)
            btnm2_9.Tag = RichTextBox2.Lines(8)
            btnm2_10.Tag = RichTextBox2.Lines(9)
            btnm2_11.Tag = RichTextBox2.Lines(10)
            btnm2_12.Tag = RichTextBox2.Lines(11)
            btnm2_13.Tag = RichTextBox2.Lines(12)
            btnm2_14.Tag = RichTextBox2.Lines(13)
            btnm2_15.Tag = RichTextBox2.Lines(14)
            btnm2_16.Tag = RichTextBox2.Lines(15)
            btnm2_17.Tag = RichTextBox2.Lines(16)
            btnm2_18.Tag = RichTextBox2.Lines(17)
            btnm2_19.Tag = RichTextBox2.Lines(18)
            btnm2_20.Tag = RichTextBox2.Lines(19)
            btnm2_21.Tag = RichTextBox2.Lines(20)
            btnm2_22.Tag = RichTextBox2.Lines(21)
            btnm2_23.Tag = RichTextBox2.Lines(22)
            btnm2_24.Tag = RichTextBox2.Lines(23)
            btnm2_25.Tag = RichTextBox2.Lines(24)
            btnm2_26.Tag = RichTextBox2.Lines(25)
            btnm2_27.Tag = RichTextBox2.Lines(26)
            btnm2_28.Tag = RichTextBox2.Lines(27)
            btnm2_29.Tag = RichTextBox2.Lines(28)
            btnm2_30.Tag = RichTextBox2.Lines(29)
            For Each control As Button In GroupBox5.Controls
                If control.Text = "noitem" Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If
            Next

            For Each control As Button In GroupBox5.Controls
                If System.IO.File.Exists(control.Tag) = False Then
                    control.Text = ""
                    control.Tag = "noitem"
                End If
            Next
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Label14.Text = ""
        Label12.Text = "00:00"
    End Sub

    Private Sub colorbotonera()
        For Each Control As Button In GroupBox4.Controls
            If Not Control.Name = "btn_menu1" Then
                Control.BackColor = Color.FromArgb(53, 87, 117)
            End If
        Next
        For Each Control As Button In GroupBox5.Controls
            If Not Control.Name = "btn_menu2" Then
                Control.BackColor = Color.FromArgb(53, 87, 117)
            End If
        Next
    End Sub



    Private Sub btnm1_1_MouseDown(sender As Object, e As MouseEventArgs) Handles btnm1_1.MouseDown, btnm1_2.MouseDown, btnm1_3.MouseDown, btnm1_4.MouseDown, btnm1_5.MouseDown, btnm1_6.MouseDown, btnm1_7.MouseDown, btnm1_8.MouseDown, btnm1_9.MouseDown, btnm1_10.MouseDown, btnm1_11.MouseDown, btnm1_12.MouseDown, btnm1_13.MouseDown, btnm1_14.MouseDown, btnm1_15.MouseDown, btnm1_16.MouseDown, btnm1_17.MouseDown, btnm1_18.MouseDown, btnm1_19.MouseDown, btnm1_20.MouseDown, btnm1_21.MouseDown, btnm1_22.MouseDown, btnm1_23.MouseDown, btnm1_24.MouseDown, btnm1_25.MouseDown, btnm1_26.MouseDown, btnm1_27.MouseDown, btnm1_28.MouseDown, btnm1_29.MouseDown, btnm1_30.MouseDown, btnm2_1.MouseDown, btnm2_2.MouseDown, btnm2_3.MouseDown, btnm2_4.MouseDown, btnm2_5.MouseDown, btnm2_6.MouseDown, btnm2_7.MouseDown, btnm2_8.MouseDown, btnm2_9.MouseDown, btnm2_10.MouseDown, btnm2_11.MouseDown, btnm2_12.MouseDown, btnm2_13.MouseDown, btnm2_14.MouseDown, btnm2_15.MouseDown, btnm2_16.MouseDown, btnm2_17.MouseDown, btnm2_18.MouseDown, btnm2_19.MouseDown, btnm2_20.MouseDown, btnm2_21.MouseDown, btnm2_22.MouseDown, btnm2_23.MouseDown, btnm2_24.MouseDown, btnm2_25.MouseDown, btnm2_26.MouseDown, btnm2_27.MouseDown, btnm2_28.MouseDown, btnm2_29.MouseDown, btnm2_30.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If CType(sender, Button).BackColor = Color.FromArgb(53, 87, 117) Then
                CType(sender, Button).Text = ""
                CType(sender, Button).Tag = "noitem"
                ToolTip1.SetToolTip(CType(sender, Button), CType(sender, Button).Text)
            End If
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        If Not ExpTree1.SelectedItem Is Nothing Then
            ExpTree1.RefreshTree()
        End If
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        final = final + 1
        If (final Mod 2) <> 0 Then
            lblcancion.BackColor = Color.FromArgb(253, 0, 26)
        Else
            lblcancion.BackColor = Color.FromArgb(140, 0, 3)
        End If
        If Label13.Text <= 0 Then
            Timer3.Stop()
            lblcancion.BackColor = Color.FromArgb(53, 87, 117)
            final = 0
        End If
    End Sub

    Private Sub Label13_TextChanged(sender As Object, e As EventArgs) Handles Label13.TextChanged
        If Label13.Text <= 10 Then
            If Timer3.Enabled = False Then
                Timer3.Enabled = True
            End If
        Else
            Timer3.Stop()
            lblcancion.BackColor = Color.FromArgb(53, 87, 117)
            final = 0
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If ToolStripMenuItem4.Checked = True Then
            ToolStripMenuItem4.ForeColor = Color.White
            ToolStripMenuItem4.BackColor = Color.Red
        Else
            ToolStripMenuItem4.ForeColor = Color.Black
            ToolStripMenuItem4.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer2_StatusChange(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer2.StatusChange
        If AxWindowsMediaPlayer2.playState = WMPPlayState.wmppsStopped Then
            DetenerReproduccion3()
            sonido.Continuar()
            If sonido.EstadoReproduciendo Then
                Label1.BackColor = Color.Red
            Else
                Label1.BackColor = Color.FromArgb(64, 0, 0)
            End If
            For Each Control As Button In GroupBox4.Controls
                If Not Control.Name = "btn_menu1" Then
                    If Control.BackColor = Color.Green Then
                        Control.BackColor = Color.FromArgb(53, 87, 117)
                    End If
                End If
            Next
            For Each Control As Button In GroupBox5.Controls
                If Not Control.Name = "btn_menu2" Then
                    If Control.BackColor = Color.Green Then
                        Control.BackColor = Color.FromArgb(53, 87, 117)
                    End If
                End If
            Next
        ElseIf AxWindowsMediaPlayer2.playState = WMPPlayState.wmppsPlaying Then
            Label1.BackColor = Color.Red
            sonido.Pausar()
            contvolumen = 0
            TrackBar2.Value = 0
            Timer2.Start()
        End If
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If ToolStripMenuItem5.Checked = True Then
            ToolStripMenuItem5.ForeColor = Color.White
            ToolStripMenuItem5.BackColor = Color.Red
        Else
            ToolStripMenuItem5.ForeColor = Color.Black
            ToolStripMenuItem5.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        
    End Sub

    Private Sub ExpTree1_StartUpDirectoryChanged(newVal As ExpTree.StartDir) Handles ExpTree1.StartUpDirectoryChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class
