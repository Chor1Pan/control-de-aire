'==========================================================
'Clase para reproducir archivos de mp3, utilizando las API´s
'Multimedia de Windows.
'Gonzalo Antonio Sosa M. Julio 2003
'==========================================================
Option Explicit On
Option Strict On

'importamos los espacios de nombres que necesitaremos.
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
    'devuelve una cadena con la información de posición del apuntador del archivo.
    'devuelve: Cadena con la información.
    Public Function Posicion(ByVal CalcularPosicion As Long) As String
        'obtenemos los segundos.
        Dim sec As Long = CalcularPosicion
        Dim mins As Long
        Dim hors As Long

        'si la cantidad de segundos es menor que 60 (1 minuto),
        If sec < 60 Then
            'devolvemos la cadena formateada a 0:Segundos.
            Return "00:" & Format(sec, "00")
            'si los segundos son mayores que 59 (60 o más),
        ElseIf sec > 59 Then
            'calculamos la cantidad de minutos,
            mins = CLng(Int(sec / 60))
            'restamos los segundos de la cantida de minutos obtenida,
            sec = sec - (mins * 60)
            'devolvemos la cadena formateada a Minustos:Segundos.
            Return Format(mins, "00") & ":" & Format(sec, "00")
        Else 'en caso de obtener un valor menos a 0, devolvemos una cadena vacía.
            Return ""
        End If
    End Function

    Public Function Tamano(ByVal CalcularTamano As Long) As String
        Dim sec As Long = CalcularTamano
        Dim mins As Long

        'si la cantidad de segundos es menor que 60 (1 minuto)
        If sec < 60 Then
            'devolvemos la cadena formateada a 0:Segundos.
            Return "00:" & Format(sec, "00")
            'si los segundos son mayores que 59 (60 o más),
        ElseIf sec > 59 Then
            mins = CLng(Int(sec / 60))
            sec = sec - (mins * 60)
            'devolvemos la cadena formateada a Minustos:Segundos.
            Return Format(mins, "00") & ":" & Format(sec, "00")
        Else
            Return ""
        End If
    End Function

    Public Function restos() As String
        Dim sec1 As Long '= CalcularTamano()
        Dim sec2 As Long '= CalcularPosicion()
        Dim sec3 As Long '= sec1 - sec2
        Dim mins As Long

        'si la cantidad de segundos es menor que 60 (1 minuto)
        If sec3 < 60 Then
            'devolvemos la cadena formateada a 0:Segundos.
            Return "00:" & Format(sec3, "00")
            'si los segundos son mayores que 59 (60 o más),
        ElseIf sec3 > 59 Then
            mins = CLng(Int(sec3 / 60))
            sec3 = sec3 - (mins * 60)
            'devolvemos la cadena formateada a Minustos:Segundos.
            Return Format(mins, "00") & ":" & Format(sec3, "00")
        Else
            Return ""
        End If
    End Function


End Class
