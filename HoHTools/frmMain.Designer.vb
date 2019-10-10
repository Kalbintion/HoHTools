<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnToolLibrary = New System.Windows.Forms.Button()
        Me.btnToolLights = New System.Windows.Forms.Button()
        Me.btnToolStat = New System.Windows.Forms.Button()
        Me.lblDeveloped = New System.Windows.Forms.Label()
        Me.btnOverlay = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnConstellation = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.HoHTools.My.Resources.Resources.HoHLogo
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(426, 85)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnToolLibrary
        '
        Me.btnToolLibrary.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnToolLibrary.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnToolLibrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToolLibrary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToolLibrary.ForeColor = System.Drawing.Color.White
        Me.btnToolLibrary.Image = Global.HoHTools.My.Resources.Resources.Icon_Library_Tool
        Me.btnToolLibrary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnToolLibrary.Location = New System.Drawing.Point(12, 91)
        Me.btnToolLibrary.Name = "btnToolLibrary"
        Me.btnToolLibrary.Size = New System.Drawing.Size(130, 32)
        Me.btnToolLibrary.TabIndex = 1
        Me.btnToolLibrary.Text = "Library Tool"
        Me.btnToolLibrary.UseVisualStyleBackColor = False
        '
        'btnToolLights
        '
        Me.btnToolLights.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnToolLights.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnToolLights.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToolLights.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToolLights.ForeColor = System.Drawing.Color.White
        Me.btnToolLights.Image = Global.HoHTools.My.Resources.Resources.Icon_Lights_Tool
        Me.btnToolLights.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnToolLights.Location = New System.Drawing.Point(148, 91)
        Me.btnToolLights.Name = "btnToolLights"
        Me.btnToolLights.Size = New System.Drawing.Size(130, 32)
        Me.btnToolLights.TabIndex = 2
        Me.btnToolLights.Text = "Lights On"
        Me.btnToolLights.UseVisualStyleBackColor = False
        '
        'btnToolStat
        '
        Me.btnToolStat.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnToolStat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnToolStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToolStat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToolStat.ForeColor = System.Drawing.Color.White
        Me.btnToolStat.Image = Global.HoHTools.My.Resources.Resources.Icon_Stats_tool
        Me.btnToolStat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnToolStat.Location = New System.Drawing.Point(148, 129)
        Me.btnToolStat.Name = "btnToolStat"
        Me.btnToolStat.Size = New System.Drawing.Size(130, 32)
        Me.btnToolStat.TabIndex = 3
        Me.btnToolStat.Text = "Stat Calc"
        Me.btnToolStat.UseVisualStyleBackColor = False
        Me.btnToolStat.Visible = False
        '
        'lblDeveloped
        '
        Me.lblDeveloped.BackColor = System.Drawing.Color.Transparent
        Me.lblDeveloped.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblDeveloped.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeveloped.ForeColor = System.Drawing.Color.White
        Me.lblDeveloped.Location = New System.Drawing.Point(0, 170)
        Me.lblDeveloped.Name = "lblDeveloped"
        Me.lblDeveloped.Size = New System.Drawing.Size(426, 21)
        Me.lblDeveloped.TabIndex = 4
        Me.lblDeveloped.Text = "Developed by Kalbintion, http://www.twitch.tv/kalbintion"
        '
        'btnOverlay
        '
        Me.btnOverlay.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOverlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOverlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOverlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOverlay.ForeColor = System.Drawing.Color.White
        Me.btnOverlay.Image = Global.HoHTools.My.Resources.Resources.Town_Gold
        Me.btnOverlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOverlay.Location = New System.Drawing.Point(284, 129)
        Me.btnOverlay.Name = "btnOverlay"
        Me.btnOverlay.Size = New System.Drawing.Size(130, 32)
        Me.btnOverlay.TabIndex = 6
        Me.btnOverlay.Text = "Game Overlay"
        Me.btnOverlay.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Image = Global.HoHTools.My.Resources.Resources.Skill_Power
        Me.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSettings.Location = New System.Drawing.Point(12, 129)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(130, 32)
        Me.btnSettings.TabIndex = 7
        Me.btnSettings.Text = "Settings Editor"
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnConstellation
        '
        Me.btnConstellation.BackColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConstellation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConstellation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConstellation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConstellation.ForeColor = System.Drawing.Color.White
        Me.btnConstellation.Image = Global.HoHTools.My.Resources.Resources.Icon_Constellation_On
        Me.btnConstellation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConstellation.Location = New System.Drawing.Point(284, 91)
        Me.btnConstellation.Name = "btnConstellation"
        Me.btnConstellation.Size = New System.Drawing.Size(130, 32)
        Me.btnConstellation.TabIndex = 8
        Me.btnConstellation.Text = "Constellation"
        Me.btnConstellation.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.HoHTools.My.Resources.Resources.Background
        Me.ClientSize = New System.Drawing.Size(426, 191)
        Me.Controls.Add(Me.btnConstellation)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnOverlay)
        Me.Controls.Add(Me.lblDeveloped)
        Me.Controls.Add(Me.btnToolStat)
        Me.Controls.Add(Me.btnToolLights)
        Me.Controls.Add(Me.btnToolLibrary)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Heroes of Hammerwatch Toolset"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnToolLibrary As System.Windows.Forms.Button
    Friend WithEvents btnToolLights As System.Windows.Forms.Button
    Friend WithEvents btnToolStat As System.Windows.Forms.Button
    Friend WithEvents lblDeveloped As System.Windows.Forms.Label
    Friend WithEvents btnOverlay As System.Windows.Forms.Button
    Friend WithEvents btnSettings As System.Windows.Forms.Button
    Friend WithEvents btnConstellation As System.Windows.Forms.Button
End Class
