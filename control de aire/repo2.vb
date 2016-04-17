Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Reproductor

    <DllImport("winmm.dll")> _
    Public Shared Function mciSendString(ByVal lpstrCommand As String, _
    ByVal lpstrReturnString As StringBuilder, ByVal uReturnLength As Integer, ByVal hwndCallBack As Integer) As Integer
    End Function


    <DllImport("winmm.dll")> _
    Public Shared Function waveOutGetNumDevs() As Integer
    End Function

    <DllImport("winmm.dll")> _
    Public Shared Function mciGetErrorString(ByVal fwdError As Integer, _
    ByVal lpszErrorText As StringBuilder, ByVal cchErrorText As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> _
    Public Shared Function GetShortPathName(ByVal lpszLongPath As String, _
    ByVal lpszShortPath As StringBuilder, ByVal cchBuffer As Integer) As Integer
    End Function

    <DllImport("kernel32.dll")> _
    Public Shared Function GetLongPathName(ByVal lpszShortPath As String, _
    ByVal lpszLongPath As StringBuilder, ByVal cchBuffer As Integer) As Integer
    End Function
    <DllImport("winmm.dll")> _
    Public Shared Function waveOutGetVolume(ByVal hwo As IntPtr, ByRef dwVolume As UInteger) As Integer
    End Function

    <DllImport("winmm.dll")> _
    Public Shared Function waveOutSetVolume(ByVal hwo As IntPtr, ByVal dwVolume As UInteger) As Integer
    End Function

    Const MAX_PATH As Integer = 260
    Const Tipo As String = "MPEGVIDEO"
    Const _Alias As String = "ArchivoDeSonido"
    Private fileName As String
    Public Event ReproductorEstado(ByVal Msg As String)
    Public Sub New()

    End Sub

    Public Property NombreDeArchivo() As String
        Get
            Return Me.fileName
        End Get
        Set(ByVal Value As String)
            Me.fileName = Value
        End Set
    End Property

    Private Function NombreCorto(ByVal NombreLargo As String) As String
        Dim sBuffer As New StringBuilder(MAX_PATH)
        If GetShortPathName(NombreLargo, sBuffer, MAX_PATH) > 0 Then
            Return sBuffer.ToString()
        Else
            Return ""
        End If
    End Function

    Public Function NombreLargo(ByVal NombreCorto As String) As String
        Dim sBuffer As New StringBuilder(MAX_PATH)
        If GetLongPathName(NombreCorto, sBuffer, MAX_PATH) > 0 Then
            Return sBuffer.ToString()
        Else
            Return ""
        End If
    End Function

    Public Function MciMensajesDeError(ByVal ErrorCode As Integer) As String
        Dim sBuffer As New StringBuilder(MAX_PATH)
        If mciGetErrorString(ErrorCode, sBuffer, MAX_PATH) <> 0 Then
            sBuffer.ToString()
        Else
            Return ""
        End If
        Return ""
    End Function

    Public Function DispositivosDeSonido() As Integer
        Return waveOutGetNumDevs()
    End Function
    Public Function Abrir() As Boolean
        If fileName <> "" Then
            Dim _NombreCorto As String = NombreCorto(fileName)
            If mciSendString("open " & _NombreCorto & " type " & _
            Tipo & " alias " & _Alias, Nothing, 0, 0) = 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub Reproducir()
        If fileName <> "" Then
            If Abrir() Then
                Dim mciResul As Integer = mciSendString("play " & _Alias, Nothing, 0, 0)
                If mciResul = 0 Then
                    RaiseEvent _
                    ReproductorEstado("Ok")
                Else
                    RaiseEvent ReproductorEstado(MciMensajesDeError(mciResul))
                End If
            Else
                RaiseEvent ReproductorEstado("No se ha logrado abrir el archivo especificado.")
            End If
        Else 
            RaiseEvent _
            ReproductorEstado("no se ha especificado ningún nombre de archivo.")
        End If
    End Sub

    Public Sub ReproducirDesde(ByVal Desde As Long)
        Dim mciresul As Integer = mciSendString("play " & _Alias & " from " & _
        (Desde * 1000).ToString(), Nothing, 0, 0)
        If mciresul = 0 Then
            RaiseEvent ReproductorEstado("Nueva Posición: " & Desde.ToString())
        Else
            RaiseEvent ReproductorEstado(MciMensajesDeError(mciresul))
        End If
    End Sub
    Public Sub Velocidad(ByVal Tramas As Integer)
        Dim mciresul As Integer = mciSendString("set " & _Alias & " tempo " & _
        Tramas.ToString(), Nothing, 0, 0)
        If mciresul = 0 Then
            RaiseEvent ReproductorEstado("Velocidad Modificada.")
        Else
            RaiseEvent ReproductorEstado(MciMensajesDeError(mciresul))
        End If
    End Sub

    Public Sub Reposicionar(ByVal NuevaPosicion As Integer)
        Dim mciResul As Integer = mciSendString("seek " & _Alias & " to " & _
        (NuevaPosicion * 1000).ToString(), Nothing, 0, 0)
        If mciResul = 0 Then
            RaiseEvent ReproductorEstado("Nueva Posición: " & NuevaPosicion.ToString())
        Else
            RaiseEvent ReproductorEstado(MciMensajesDeError(mciResul))
        End If
    End Sub

    Public Sub Principio()
        Dim mciresul As Integer = mciSendString("seek " & _Alias & " to start", Nothing, 0, 0)
        If mciresul = 0 Then
            RaiseEvent ReproductorEstado("Inicio de: " & _
            Path.GetFileNameWithoutExtension(fileName))
        Else
            RaiseEvent ReproductorEstado(MciMensajesDeError(mciresul))
        End If
    End Sub

    Public Sub Final()
        Dim mciresul As Integer = mciSendString("seek " & _Alias & " to end", Nothing, 0, 0)
        If mciresul = 0 Then
            RaiseEvent ReproductorEstado("Final de: " & _
            Path.GetFileNameWithoutExtension(fileName))
        Else
            RaiseEvent ReproductorEstado(MciMensajesDeError(mciresul))
        End If
    End Sub

    Public Sub Pausar()
        Dim mciresul As Integer = mciSendString("pause " & _Alias, Nothing, 0, 0)
        If mciresul = 0 Then
            RaiseEvent ReproductorEstado("Pausada")
        Else
            RaiseEvent ReproductorEstado(MciMensajesDeError(mciresul))
        End If
    End Sub

    Public Sub Continuar()
        Dim mciResul As Integer = mciSendString("resume " & _Alias, Nothing, 0, 0)
        If mciResul = 0 Then
            RaiseEvent ReproductorEstado("Continuar")
        Else
            RaiseEvent ReproductorEstado(MciMensajesDeError(mciResul))
        End If
    End Sub

    Public Sub Cerrar()
        mciSendString("stop " & _Alias, Nothing, 0, 0)
        mciSendString("close " & _Alias, Nothing, 0, 0)
    End Sub

    Public Sub Detener()
        mciSendString("stop " & _Alias, Nothing, 0, 0)
    End Sub
    Public Function Estado() As String
        Dim sBuffer As New StringBuilder(MAX_PATH)
        mciSendString("status " & _Alias & " mode", sBuffer, MAX_PATH, 0)
        Return sBuffer.ToString()
    End Function
    Public Function EstadoReproduciendo() As Boolean
        Return CBool(IIf(Estado() = "playing", True, False))
    End Function
    Public Function EstadoPausado() As Boolean
        Return CBool(IIf(Estado() = "paused", True, False))
    End Function
    Public Function EstadoDetenido() As Boolean
        Return CBool(IIf(Estado() = "stopped", True, False))
    End Function
    Public Function EstadoAbierto() As Boolean
        Return CBool(IIf(Estado() = "open", True, False))
    End Function
    Public Function CalcularPosicion() As Long
        Dim sBuffer As New StringBuilder(MAX_PATH)
        mciSendString("set " & _Alias & " time format milliseconds", Nothing, 0, 0)
        mciSendString("status " & _Alias & " position", sBuffer, MAX_PATH, 0)
        If sBuffer.ToString() <> "" Then
            Return CLng(Long.Parse(sBuffer.ToString()) / 1000)
        Else
            Return 0L
        End If
    End Function

    Public Function Posicion() As String
        Dim sec As Long = CalcularPosicion()
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
    Public Function CalcularTamano() As Long
        Dim sBuffer As New StringBuilder(MAX_PATH)
        mciSendString("set " & _Alias & " time format milliseconds", Nothing, 0, 0)
        mciSendString("status " & _Alias & " length", sBuffer, MAX_PATH, 0)
        If sBuffer.ToString() <> "" Then
            Return CLng(Long.Parse(sBuffer.ToString()) / 1000)
        Else
            Return 0L
        End If
    End Function
    Public Function Tamano() As String
        Dim sec As Long = CalcularTamano()
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
    Public Function restos() As String
        Dim sec1 As Long = CalcularTamano()
        Dim sec2 As Long = CalcularPosicion()
        Dim sec3 As Long = sec1 - sec2
        Dim mins As Long
        If sec3 < 60 Then
            Return "00:" & Format(sec3, "00")
        ElseIf sec3 > 59 Then
            mins = CLng(Int(sec3 / 60))
            sec3 = sec3 - (mins * 60)
            Return Format(mins, "00") & ":" & Format(sec3, "00")
        Else
            Return ""
        End If
    End Function

    Public Function seg_restos() As String
        Dim sec1 As Long = CalcularTamano()
        Dim sec2 As Long = CalcularPosicion()
        Dim sec3 As Long = sec1 - sec2
        Return Format(sec3, "0")
    End Function

    Public Function niveles() As Integer
        Dim sBuffer As New StringBuilder(MAX_PATH)
        'mciSendString("Status " & strAlias & " level", strReturn, 255, 0)
        Dim mciResul As Integer = mciSendString("Status " & _Alias & " level", sBuffer, 255, 0)
        Return mciResul
    End Function
End Class
