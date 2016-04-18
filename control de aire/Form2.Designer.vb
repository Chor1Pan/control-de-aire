<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.timercanciontiempo = New System.Windows.Forms.Timer(Me.components)
        Me.pausa = New System.Windows.Forms.Timer(Me.components)
        Me.fade = New System.Windows.Forms.Timer(Me.components)
        Me.tiempoyhora = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.sbr1 = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.lblcancion = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.stTiempostranscurrido = New System.Windows.Forms.Label()
        Me.stTiemposrestante = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrackBar2
        '
        Me.TrackBar2.Location = New System.Drawing.Point(273, 92)
        Me.TrackBar2.Maximum = 100
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar2.Size = New System.Drawing.Size(45, 203)
        Me.TrackBar2.TabIndex = 40
        Me.TrackBar2.TabStop = False
        Me.TrackBar2.TickFrequency = 10
        Me.TrackBar2.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.TrackBar2.Value = 100
        Me.TrackBar2.Visible = False
        '
        'Timer1
        '
        '
        'timercanciontiempo
        '
        '
        'pausa
        '
        Me.pausa.Interval = 1000
        '
        'fade
        '
        Me.fade.Interval = 1000
        '
        'tiempoyhora
        '
        Me.tiempoyhora.Enabled = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Controls.Add(Me.TrackBar2)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.cb1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.sbr1)
        Me.GroupBox2.Controls.Add(Me.RichTextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 185)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 322)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.UseCompatibleTextRendering = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(170, 170)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(75, 23)
        Me.AxWindowsMediaPlayer1.TabIndex = 41
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'ListView1
        '
        Me.ListView1.AllowDrop = True
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader1, Me.ColumnHeader4})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.Location = New System.Drawing.Point(1, 8)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(417, 314)
        Me.ListView1.TabIndex = 19
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width = 349
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Duración"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ruta"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 187)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(495, 20)
        Me.TextBox2.TabIndex = 17
        Me.TextBox2.Visible = False
        '
        'cb1
        '
        Me.cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb1.Location = New System.Drawing.Point(12, 160)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(199, 21)
        Me.cb1.TabIndex = 6
        Me.cb1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 213)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(495, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Visible = False
        '
        'sbr1
        '
        Me.sbr1.Location = New System.Drawing.Point(12, 129)
        Me.sbr1.Name = "sbr1"
        Me.sbr1.Size = New System.Drawing.Size(199, 20)
        Me.sbr1.TabIndex = 0
        Me.sbr1.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(245, 141)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(262, 40)
        Me.RichTextBox1.TabIndex = 16
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'lblcancion
        '
        Me.lblcancion.AutoEllipsis = True
        Me.lblcancion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblcancion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcancion.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblcancion.Location = New System.Drawing.Point(15, 24)
        Me.lblcancion.Name = "lblcancion"
        Me.lblcancion.Size = New System.Drawing.Size(391, 23)
        Me.lblcancion.TabIndex = 33
        Me.lblcancion.Text = "00:00"
        Me.lblcancion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblcancion.UseCompatibleTextRendering = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblcancion)
        Me.GroupBox1.Controls.Add(Me.TrackBar1)
        Me.GroupBox1.Controls.Add(Me.stTiempostranscurrido)
        Me.GroupBox1.Controls.Add(Me.stTiemposrestante)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 177)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.UseCompatibleTextRendering = True
        '
        'Label8
        '
        Me.Label8.AutoEllipsis = True
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Lime
        Me.Label8.Location = New System.Drawing.Point(140, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 22)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "0"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label8.UseCompatibleTextRendering = True
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(303, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 22)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "00:00"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label7.UseCompatibleTextRendering = True
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(229, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 18)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Tiempo total:"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(42, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 18)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Elementos en lista:"
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.Enabled = False
        Me.TrackBar1.Location = New System.Drawing.Point(6, 129)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(410, 30)
        Me.TrackBar1.TabIndex = 26
        Me.TrackBar1.TabStop = False
        Me.TrackBar1.TickFrequency = 5
        '
        'stTiempostranscurrido
        '
        Me.stTiempostranscurrido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.stTiempostranscurrido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stTiempostranscurrido.ForeColor = System.Drawing.Color.Lime
        Me.stTiempostranscurrido.Location = New System.Drawing.Point(303, 58)
        Me.stTiempostranscurrido.Name = "stTiempostranscurrido"
        Me.stTiempostranscurrido.Size = New System.Drawing.Size(67, 22)
        Me.stTiempostranscurrido.TabIndex = 27
        Me.stTiempostranscurrido.Text = "00:00"
        Me.stTiempostranscurrido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.stTiempostranscurrido.UseCompatibleTextRendering = True
        '
        'stTiemposrestante
        '
        Me.stTiemposrestante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.stTiemposrestante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stTiemposrestante.ForeColor = System.Drawing.Color.Lime
        Me.stTiemposrestante.Location = New System.Drawing.Point(117, 58)
        Me.stTiemposrestante.Name = "stTiemposrestante"
        Me.stTiemposrestante.Size = New System.Drawing.Size(67, 22)
        Me.stTiemposrestante.TabIndex = 27
        Me.stTiemposrestante.Text = "00:00"
        Me.stTiemposrestante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.stTiemposrestante.UseCompatibleTextRendering = True
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 18)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tiempo Restante:"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(197, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 18)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Tiempo Transcurrido:"
        '
        'Timer2
        '
        Me.Timer2.Interval = 50
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(430, 512)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tanda"
        Me.TopMost = True
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents timercanciontiempo As System.Windows.Forms.Timer
    Friend WithEvents pausa As System.Windows.Forms.Timer
    Friend WithEvents fade As System.Windows.Forms.Timer
    Friend WithEvents tiempoyhora As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents cb1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents sbr1 As System.Windows.Forms.TextBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents lblcancion As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents stTiempostranscurrido As System.Windows.Forms.Label
    Friend WithEvents stTiemposrestante As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
