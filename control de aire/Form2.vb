Imports ExpTreeLib
Imports ExpTreeLib.CShItem
Imports ExpTreeLib.SystemImageListManager
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim rs As New Resizer
    Private LastSelectedCSI As CShItem
    Dim testTime As New DateTime(1, 1, 1, 0, 0, 0)
    Private Shared Event1 As New ManualResetEvent(True)
    Dim tipoarchivo As String
    Private MouseIsDown As Boolean = False
    Dim contador As Integer = 0
    Private hashMusica As New Hashtable()
    Dim sonido As New Reproductor
    Private trackBarClick As Boolean
    Dim archivoenlista As String
    Dim pausado As Integer = 0
    Dim fadestop As Integer
    Dim fadecount As Integer = 0
    Dim indicelista As Integer
    Dim contvolumen As Integer = 0

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        DetenerReproduccion()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TrackBar2.Value = 100
        rs.FindAllControls(Me)
        AxWindowsMediaPlayer1.settings.volume = 0
        ListView1.Columns(0).Width = ListView1.Width * 85 / 100
        ListView1.Columns(1).Width = ListView1.Width * 14 / 100
        Dim NewVolume As Integer = ((UShort.MaxValue / 10) * TrackBar2.Value)
        Dim NewVolumeAllChannels As UInteger = ((CUInt(NewVolume) And &HFFFF) Or (CUInt(NewVolume) << 16))
        Reproductor.waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels)
        ListView1.HideSelection = False
        TrackBar2.Value = 100
    End Sub
    Public Function cargarlista(ByRef archivo)
        ListView1.Items.Clear()
        Dim filepath As String = archivo
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
                Me.ListView1.Items.Add(IP)
                Me.ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(Port)
                Me.ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(Protocol)
                Me.ListView1.Items.Item(ListView1.Items.Count - 1).SubItems.Add(Type)
            End If
        Loop
        Dim Total As Double, i As Integer
        If ListView1.Items.Count = 0 Then
            Label7.Text = "00:00"
        Else
            For i = 0 To ListView1.Items.Count - 1
                Total = Total + ListView1.Items(i).SubItems(3).Text
                Label7.Text = Tamano3(Total)
            Next
        End If
        Label8.Text = ListView1.Items.Count
        Form1.Label12.Text = Label7.Text
        Form1.Label14.Text = System.IO.Path.GetFileNameWithoutExtension(archivo)
        inputstream.Close()
        Return ""
    End Function
    Private Sub Form2_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
        ListView1.Columns(0).Width = ListView1.Width * 85 / 100
        ListView1.Columns(1).Width = ListView1.Width * 14 / 100
    End Sub

    Public Sub DetenerReproduccion2()
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        'Timer1.Enabled = False
        'Timer1.Stop()
        'TrackBar1.Value = 0
        'stTiempostotal.Text = "00:00"
        'stTiempostranscurrido.Text = "00:00"

    End Sub
    Public Sub IniciarReproduccion2(ByVal archivoaudio As String)
        If archivoaudio <> "" Then
            AxWindowsMediaPlayer1.Ctlcontrols.stop()
            AxWindowsMediaPlayer1.URL = archivoaudio
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            contador = 0
            timercanciontiempo.Enabled = True
            'TrackBar1.TickFrequency = Sonido.CalcularTamano / 10
            'Timer1.Enabled = True
            'Timer1.Start()
            'End If
        End If
    End Sub

    Public Function Tamano2() As String
        Dim sec As Long = AxWindowsMediaPlayer1.currentMedia.duration
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
            ListView1.Items.Add(archivoenlista)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(Tamano2())
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(AxWindowsMediaPlayer1.URL)
            ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(AxWindowsMediaPlayer1.currentMedia.duration)
            Dim Total As Double, i As Integer
            If ListView1.Items.Count = 0 Then
                Label7.Text = "00:00"
            Else
                For i = 0 To ListView1.Items.Count - 1
                    Total = Total + ListView1.Items(i).SubItems(3).Text
                    Label7.Text = Tamano3(Total)
                Next
            End If
            Label8.Text = ListView1.Items.Count
        End If
    End Sub

    Public Sub adelante()
        Dim selectedItem As Int32
        If ListView1.SelectedItems.Count > 0 Then
            selectedItem = ListView1.SelectedItems(0).Index
        End If
        If selectedItem < ListView1.Items.Count Then
            ListView1.Items(0).Selected = True
            Dim item As ListViewItem = ListView1.SelectedItems(0)
            Dim ruta As String = item.SubItems(2).Text
            IniciarReproduccion(ruta, item.SubItems(0).Text)
        End If

    End Sub

    Private Sub DetenerReproduccion()
        Form1.Label1.BackColor = Color.FromArgb(64, 0, 0)
        sonido.Cerrar()
        Timer1.Enabled = False
        Timer1.Stop()
        pausa.Stop()
        pausado = 0
        TrackBar1.Value = 0
        lblcancion.Text = ""
        Dim i As Integer
        i = ListView1.Items.Count - 1
        If ListView1.Items(i).Selected = True Then
            Form1.luegopausa()
            Me.Hide()
        End If
    End Sub
    Private Sub IniciarReproduccion(ByVal archivoaudio As String, ByVal nombrearchivo As String)
        If archivoaudio <> "" Then
            If sonido.EstadoReproduciendo() Then DetenerReproduccion()
            sonido.NombreDeArchivo = archivoaudio
            sonido.Reproducir()
            TrackBar1.Minimum = 0
            lblcancion.Text = nombrearchivo
            TrackBar1.Maximum = sonido.CalcularTamano()
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
            Form1.Label1.BackColor = Color.Red
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ListView1.Items.Count > 0 Then
            If ListView1.SelectedItems.Count = 0 Then
                Me.ListView1.Items(indicelista).Focused = True
                Me.ListView1.Items(indicelista).Selected = True

            End If
        End If
        stTiempostranscurrido.Text = sonido.Posicion()
        stTiemposrestante.Text = sonido.restos
        If Not trackBarClick Then
            TrackBar1.Value = CInt(sonido.CalcularPosicion())
        End If
        If sonido.EstadoDetenido Then
            DetenerReproduccion()
            Dim selectedItem As Int32
            If ListView1.SelectedItems.Count > 0 Then
                selectedItem = ListView1.SelectedItems(0).Index
            End If
            If selectedItem < ListView1.Items.Count - 1 Then
                ListView1.Items(selectedItem + 1).Selected = True
                Dim item As ListViewItem = ListView1.SelectedItems(0)
                Dim ruta As String = item.SubItems(2).Text
                IniciarReproduccion(ruta, item.SubItems(0).Text)
            End If
        End If
    End Sub
    Private Sub ListView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangedEventArgs)
        Static FireMe As Boolean = True
        If FireMe = True Then
            FireMe = False
            ListView1.Columns(0).Width = ListView1.Width * 85 / 100
            ListView1.Columns(1).Width = ListView1.Width * 14 / 100
            FireMe = True
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs)
        e.Cancel = True
    End Sub

    Private Sub ListView1_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If ListView1.SelectedItems.Count > 0 Then
                Dim item As ListViewItem = ListView1.SelectedItems(0)
                item.Remove()
                If ListView1.Items.Count = 0 Then
                    Label7.Text = "00:00"
                Else
                    Dim Total As Double, i As Integer
                    For i = 0 To ListView1.Items.Count - 1
                        Total = Total + ListView1.Items(i).SubItems(3).Text
                        Label7.Text = Tamano3(Total)
                    Next
                End If
                Label8.Text = ListView1.Items.Count
            End If
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            indicelista = ListView1.SelectedIndices(0)
            If ListView1.SelectedItems.Count = 0 Then
                Me.ListView1.Items(indicelista).Focused = True
                Me.ListView1.Items(indicelista).Selected = True
            End If
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

    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        Dim NewVolume As Integer = ((UShort.MaxValue / 10) * TrackBar2.Value / 10)
        Dim NewVolumeAllChannels As UInteger = ((CUInt(NewVolume) And &HFFFF) Or (CUInt(NewVolume) << 16))
        Reproductor.waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels)
    End Sub
End Class
