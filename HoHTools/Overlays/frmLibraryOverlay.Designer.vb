<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLibraryOverlay
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibraryOverlay))
        Me.tmrOverlayPosition = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMover = New System.Windows.Forms.Timer(Me.components)
        Me.tmrAnimator = New System.Windows.Forms.Timer(Me.components)
        Me.pnlExtender = New System.Windows.Forms.Panel()
        Me.lblExpander = New System.Windows.Forms.Label()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.txt1 = New System.Windows.Forms.Label()
        Me.txt4 = New System.Windows.Forms.Label()
        Me.txt3 = New System.Windows.Forms.Label()
        Me.txt2 = New System.Windows.Forms.Label()
        Me.pic4 = New System.Windows.Forms.PictureBox()
        Me.pic3 = New System.Windows.Forms.PictureBox()
        Me.pic2 = New System.Windows.Forms.PictureBox()
        Me.pnlExtender.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrOverlayPosition
        '
        Me.tmrOverlayPosition.Enabled = True
        '
        'tmrMover
        '
        Me.tmrMover.Enabled = True
        Me.tmrMover.Interval = 1
        '
        'tmrAnimator
        '
        Me.tmrAnimator.Enabled = True
        Me.tmrAnimator.Interval = 1
        '
        'pnlExtender
        '
        Me.pnlExtender.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlExtender.Controls.Add(Me.lblExpander)
        Me.pnlExtender.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlExtender.Location = New System.Drawing.Point(264, 0)
        Me.pnlExtender.Name = "pnlExtender"
        Me.pnlExtender.Size = New System.Drawing.Size(24, 139)
        Me.pnlExtender.TabIndex = 1
        '
        'lblExpander
        '
        Me.lblExpander.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblExpander.Image = Global.HoHTools.My.Resources.Resources.Icon_Library_Tool
        Me.lblExpander.Location = New System.Drawing.Point(0, 0)
        Me.lblExpander.Name = "lblExpander"
        Me.lblExpander.Size = New System.Drawing.Size(24, 24)
        Me.lblExpander.TabIndex = 0
        Me.lblExpander.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlContainer
        '
        Me.pnlContainer.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlContainer.Controls.Add(Me.Label4)
        Me.pnlContainer.Controls.Add(Me.Label3)
        Me.pnlContainer.Controls.Add(Me.Label2)
        Me.pnlContainer.Controls.Add(Me.Label1)
        Me.pnlContainer.Controls.Add(Me.pic1)
        Me.pnlContainer.Controls.Add(Me.txt1)
        Me.pnlContainer.Controls.Add(Me.txt4)
        Me.pnlContainer.Controls.Add(Me.txt3)
        Me.pnlContainer.Controls.Add(Me.txt2)
        Me.pnlContainer.Controls.Add(Me.pic4)
        Me.pnlContainer.Controls.Add(Me.pic3)
        Me.pnlContainer.Controls.Add(Me.pic2)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(264, 139)
        Me.pnlContainer.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(198, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Chapter IV"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(131, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Chapter III"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(67, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Chapter II"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Chapter I"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pic1
        '
        Me.pic1.BackColor = System.Drawing.Color.Black
        Me.pic1.Image = Global.HoHTools.My.Resources.Resources.Icon_Blood
        Me.pic1.Location = New System.Drawing.Point(6, 23)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(58, 58)
        Me.pic1.TabIndex = 12
        Me.pic1.TabStop = False
        '
        'txt1
        '
        Me.txt1.BackColor = System.Drawing.Color.Black
        Me.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt1.ForeColor = System.Drawing.Color.White
        Me.txt1.Location = New System.Drawing.Point(6, 84)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(58, 46)
        Me.txt1.TabIndex = 16
        Me.txt1.Text = "Blood Pact"
        Me.txt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt4
        '
        Me.txt4.BackColor = System.Drawing.Color.Black
        Me.txt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt4.ForeColor = System.Drawing.Color.White
        Me.txt4.Location = New System.Drawing.Point(198, 84)
        Me.txt4.Name = "txt4"
        Me.txt4.Size = New System.Drawing.Size(58, 46)
        Me.txt4.TabIndex = 19
        Me.txt4.Text = "Malign Transformation"
        Me.txt4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt3
        '
        Me.txt3.BackColor = System.Drawing.Color.Black
        Me.txt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt3.ForeColor = System.Drawing.Color.White
        Me.txt3.Location = New System.Drawing.Point(134, 84)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(58, 46)
        Me.txt3.TabIndex = 18
        Me.txt3.Text = "Withering Decay"
        Me.txt3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt2
        '
        Me.txt2.BackColor = System.Drawing.Color.Black
        Me.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txt2.ForeColor = System.Drawing.Color.White
        Me.txt2.Location = New System.Drawing.Point(70, 84)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(58, 46)
        Me.txt2.TabIndex = 17
        Me.txt2.Text = "Embrace The Dark"
        Me.txt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pic4
        '
        Me.pic4.BackColor = System.Drawing.Color.Black
        Me.pic4.Image = Global.HoHTools.My.Resources.Resources.Icon_Malign
        Me.pic4.Location = New System.Drawing.Point(198, 23)
        Me.pic4.Name = "pic4"
        Me.pic4.Size = New System.Drawing.Size(58, 58)
        Me.pic4.TabIndex = 15
        Me.pic4.TabStop = False
        '
        'pic3
        '
        Me.pic3.BackColor = System.Drawing.Color.Black
        Me.pic3.Image = Global.HoHTools.My.Resources.Resources.Icon_Decay
        Me.pic3.Location = New System.Drawing.Point(134, 23)
        Me.pic3.Name = "pic3"
        Me.pic3.Size = New System.Drawing.Size(58, 58)
        Me.pic3.TabIndex = 14
        Me.pic3.TabStop = False
        '
        'pic2
        '
        Me.pic2.BackColor = System.Drawing.Color.Black
        Me.pic2.Image = Global.HoHTools.My.Resources.Resources.Icon_Dark
        Me.pic2.Location = New System.Drawing.Point(70, 23)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(58, 58)
        Me.pic2.TabIndex = 13
        Me.pic2.TabStop = False
        '
        'frmLibraryOverlay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(288, 139)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.pnlExtender)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLibraryOverlay"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Heroes of Hammerwatch - Overlay - Library"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.ActiveCaption
        Me.pnlExtender.ResumeLayout(False)
        Me.pnlContainer.ResumeLayout(False)
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblExpander As System.Windows.Forms.Label
    Friend WithEvents tmrOverlayPosition As System.Windows.Forms.Timer
    Friend WithEvents tmrMover As System.Windows.Forms.Timer
    Friend WithEvents tmrAnimator As System.Windows.Forms.Timer
    Friend WithEvents pnlExtender As System.Windows.Forms.Panel
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pic1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt1 As System.Windows.Forms.Label
    Friend WithEvents txt4 As System.Windows.Forms.Label
    Friend WithEvents txt3 As System.Windows.Forms.Label
    Friend WithEvents txt2 As System.Windows.Forms.Label
    Friend WithEvents pic4 As System.Windows.Forms.PictureBox
    Friend WithEvents pic3 As System.Windows.Forms.PictureBox
    Friend WithEvents pic2 As System.Windows.Forms.PictureBox
End Class
