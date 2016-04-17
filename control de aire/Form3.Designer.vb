<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.menu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.timercanciontiempo = New System.Windows.Forms.Timer(Me.components)
        Me.pausa = New System.Windows.Forms.Timer(Me.components)
        Me.fade = New System.Windows.Forms.Timer(Me.components)
        Me.tiempoyhora = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MoveItemListView1 = New controldeaire.MoveItemListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.sbr1 = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ExpTree1 = New ExpTreeLib.ExpTree()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.lv1 = New System.Windows.Forms.ListView()
        Me.ColumnHeaderName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderModifyDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.stMensajes = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.menu2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stMensajes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer2
        '
        Me.Timer2.Interval = 50
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'menu2
        '
        Me.menu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripSeparator2, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.menu2.Name = "menu1"
        Me.menu2.Size = New System.Drawing.Size(168, 76)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = Global.controldeaire.My.Resources.Resources.clear
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem1.Text = "Limpiar Botonera"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(164, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = Global.controldeaire.My.Resources.Resources.openfile
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem2.Text = "Abrir Botonera"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = Global.controldeaire.My.Resources.Resources.save16
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem3.Text = "Guardar Botonera"
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
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Archivos de lista .lst|*.lst"
        Me.SaveFileDialog1.Title = "Guardar Lista de Reproduccióm"
        '
        'Label8
        '
        Me.Label8.AutoEllipsis = True
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Lime
        Me.Label8.Location = New System.Drawing.Point(101, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 22)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "0"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label8.UseCompatibleTextRendering = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(1008, 612)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 48
        Me.Button12.Text = "Button12"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MoveItemListView1)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.cb1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.sbr1)
        Me.GroupBox2.Controls.Add(Me.RichTextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(521, -4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(350, 499)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.UseCompatibleTextRendering = True
        '
        'MoveItemListView1
        '
        Me.MoveItemListView1.AllowDrop = True
        Me.MoveItemListView1.AutoArrange = False
        Me.MoveItemListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.MoveItemListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.MoveItemListView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.MoveItemListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!)
        Me.MoveItemListView1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.MoveItemListView1.FullRowSelect = True
        Me.MoveItemListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.MoveItemListView1.HideSelection = False
        Me.MoveItemListView1.InsertionLineColor = System.Drawing.Color.White
        Me.MoveItemListView1.Location = New System.Drawing.Point(3, 9)
        Me.MoveItemListView1.Name = "MoveItemListView1"
        Me.MoveItemListView1.Size = New System.Drawing.Size(345, 486)
        Me.MoveItemListView1.TabIndex = 53
        Me.MoveItemListView1.UseCompatibleStateImageBehavior = False
        Me.MoveItemListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Pista"
        Me.ColumnHeader5.Width = 239
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Tiempo"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 83
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Width = 0
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(12, 183)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(495, 20)
        Me.TextBox2.TabIndex = 17
        Me.TextBox2.Visible = False
        '
        'cb1
        '
        Me.cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb1.Location = New System.Drawing.Point(12, 156)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(199, 21)
        Me.cb1.TabIndex = 6
        Me.cb1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 180)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(495, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Visible = False
        '
        'sbr1
        '
        Me.sbr1.Location = New System.Drawing.Point(12, 125)
        Me.sbr1.Name = "sbr1"
        Me.sbr1.Size = New System.Drawing.Size(199, 20)
        Me.sbr1.TabIndex = 0
        Me.sbr1.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(245, 137)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(262, 40)
        Me.RichTextBox1.TabIndex = 16
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(216, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 22)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "00:00"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label7.UseCompatibleTextRendering = True
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(142, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 18)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Tiempo total:"
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 18)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Elementos en lista:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.SplitContainer1)
        Me.GroupBox3.Location = New System.Drawing.Point(2, -5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(517, 580)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.UseCompatibleTextRendering = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SplitContainer1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 9)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ExpTree1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lv1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.stMensajes)
        Me.SplitContainer1.Size = New System.Drawing.Size(511, 569)
        Me.SplitContainer1.SplitterDistance = 157
        Me.SplitContainer1.TabIndex = 0
        Me.SplitContainer1.TabStop = False
        '
        'ExpTree1
        '
        Me.ExpTree1.AutoScroll = True
        Me.ExpTree1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExpTree1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ExpTree1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExpTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpTree1.Location = New System.Drawing.Point(0, 0)
        Me.ExpTree1.Name = "ExpTree1"
        Me.ExpTree1.ShowHiddenFolders = False
        Me.ExpTree1.ShowRootLines = False
        Me.ExpTree1.Size = New System.Drawing.Size(157, 569)
        Me.ExpTree1.TabIndex = 4
        Me.ExpTree1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(127, 26)
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Image = Global.controldeaire.My.Resources.Resources.reload
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(151, 273)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(75, 23)
        Me.AxWindowsMediaPlayer1.TabIndex = 29
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'lv1
        '
        Me.lv1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lv1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderName, Me.ColumnHeaderSize, Me.ColumnHeaderType, Me.ColumnHeaderModifyDate})
        Me.lv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv1.LargeImageList = Me.ImageList1
        Me.lv1.Location = New System.Drawing.Point(0, 0)
        Me.lv1.MultiSelect = False
        Me.lv1.Name = "lv1"
        Me.lv1.ShowItemToolTips = True
        Me.lv1.Size = New System.Drawing.Size(350, 569)
        Me.lv1.SmallImageList = Me.ImageList1
        Me.lv1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lv1.TabIndex = 6
        Me.lv1.TabStop = False
        Me.lv1.UseCompatibleStateImageBehavior = False
        Me.lv1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Text = "Nombre"
        Me.ColumnHeaderName.Width = 238
        '
        'ColumnHeaderSize
        '
        Me.ColumnHeaderSize.Text = "Tamaño"
        Me.ColumnHeaderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeaderSize.Width = 80
        '
        'ColumnHeaderType
        '
        Me.ColumnHeaderType.Text = "Tipo"
        Me.ColumnHeaderType.Width = 0
        '
        'ColumnHeaderModifyDate
        '
        Me.ColumnHeaderModifyDate.Text = "Modificado"
        Me.ColumnHeaderModifyDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeaderModifyDate.Width = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "File Audio.ico")
        Me.ImageList1.Images.SetKeyName(1, "1458270385_folder-close.png")
        '
        'stMensajes
        '
        Me.stMensajes.AutoSize = False
        Me.stMensajes.Dock = System.Windows.Forms.DockStyle.None
        Me.stMensajes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.stMensajes.Location = New System.Drawing.Point(236, 170)
        Me.stMensajes.Name = "stMensajes"
        Me.stMensajes.Size = New System.Drawing.Size(211, 22)
        Me.stMensajes.TabIndex = 5
        Me.stMensajes.Text = "StatusStrip1"
        Me.stMensajes.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(121, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(521, 530)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(350, 44)
        Me.Panel1.TabIndex = 49
        '
        'Button3
        '
        Me.Button3.AutoEllipsis = True
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Button3.Image = Global.controldeaire.My.Resources.Resources.save24
        Me.Button3.Location = New System.Drawing.Point(126, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(95, 32)
        Me.Button3.TabIndex = 33
        Me.Button3.TabStop = False
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.AutoEllipsis = True
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Button2.Image = Global.controldeaire.My.Resources.Resources.open24
        Me.Button2.Location = New System.Drawing.Point(8, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 32)
        Me.Button2.TabIndex = 33
        Me.Button2.TabStop = False
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.AutoEllipsis = True
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.Enabled = False
        Me.Button4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Button4.Image = Global.controldeaire.My.Resources.Resources.clear24
        Me.Button4.Location = New System.Drawing.Point(242, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(95, 32)
        Me.Button4.TabIndex = 33
        Me.Button4.TabStop = False
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(522, 496)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(349, 31)
        Me.Panel2.TabIndex = 50
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(874, 576)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear tanda"
        Me.menu2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stMensajes.ResumeLayout(False)
        Me.stMensajes.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents menu2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents timercanciontiempo As System.Windows.Forms.Timer
    Friend WithEvents pausa As System.Windows.Forms.Timer
    Friend WithEvents fade As System.Windows.Forms.Timer
    Friend WithEvents tiempoyhora As System.Windows.Forms.Timer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents cb1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents sbr1 As System.Windows.Forms.TextBox
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Public WithEvents lv1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderModifyDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents stMensajes As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ExpTree1 As ExpTreeLib.ExpTree
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents MoveItemListView1 As controldeaire.MoveItemListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ActualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
