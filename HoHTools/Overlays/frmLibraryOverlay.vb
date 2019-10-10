Imports System.Runtime.InteropServices
Imports System.Text
Imports System.ComponentModel

Public Class frmLibraryOverlay
#Region "user32 API"
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean
    End Function

    Private Const SWP_NOSIZE As Integer = &H1
    Private Const SWP_NOMOVE As Integer = &H2
    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)

    ' Retrieves Window Rect Data
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function GetWindowRect(ByVal hwnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function SetForegroundWindow(ByVal hwnd As Integer) As IntPtr
    End Function

    ' Retrieve Handle to Foreground Win
    <DllImport("user32.dll")> _
    Private Shared Function GetForegroundWindow() As Integer
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowText(hWnd As Integer, text As StringBuilder, count As Integer) As Integer
    End Function

    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Private Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
#End Region

#Region "Animation/Window Target"
    Private winProc As Process
    Private actTitle As String = ""
    Private winTitle As String = ""
    Private winHandle As Integer = 0
    Private winRect As RECT
    Private winR As Rectangle

    Private targetSizeX As Integer = 24
    Private targetSizeY As Integer = 24
    Private targetSizeXStep As Integer = 2
    Private targetSizeYStep As Integer = 2
#End Region

    Private SourceCtrl As Object
    Private oPics(5) As PictureBox
    Private oTxts(5) As Label

    Public isExpanded As Boolean = False

    Private Sub OverlayTest_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Core Code
        SetWindowPos(Me.Handle(), HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
        Me.Size = New System.Drawing.Size(targetSizeX, targetSizeY)
        Dim procs() As Process = Process.GetProcessesByName("hwr")
        Dim hwr As Process = procs(0)
        winProc = hwr

        winHandle = hwr.MainWindowHandle
        winTitle = hwr.MainWindowTitle

        ' Library Code
        oPics(1) = pic1
        oPics(2) = pic2
        oPics(3) = pic3
        oPics(4) = pic4
        oTxts(1) = txt1
        oTxts(2) = txt2
        oTxts(3) = txt3
        oTxts(4) = txt4

        For i = 1 To 4 Step 1
            oPics(i).AllowDrop = True
            oPics(i).BackColor = Color.FromArgb(128, 0, 0, 0)
            oTxts(i).AllowDrop = True
            oTxts(i).BackColor = Color.FromArgb(128, 0, 0, 0)
        Next
    End Sub

    Private Sub tmrOverlayPosition_Tick(sender As System.Object, e As System.EventArgs) Handles tmrOverlayPosition.Tick
        Const intCharCount As Integer = 256
        Dim inthWnd As Integer = 0
        Dim strhTxt As New StringBuilder(intCharCount)

        inthWnd = GetForegroundWindow()
        If GetWindowText(inthWnd, strhTxt, intCharCount) > 0 Then
            actTitle = strhTxt.ToString()
        End If
    End Sub

    Private Sub tmrMover_Tick(sender As System.Object, e As System.EventArgs) Handles tmrMover.Tick
        If winTitle = actTitle Or actTitle = Me.Text Or actTitle.Contains("OBS") Then
            If frmLightsSolverOverlay.isExpanded Then
                Me.Visible = False
                Exit Sub
            End If
            Me.Visible = True
            If winHandle = IntPtr.Zero Then Exit Sub

            If Not GetWindowRect(winHandle, winRect) Then Throw New Win32Exception

            winR = Rectangle.FromLTRB(winRect.left, winRect.top, winRect.right, winRect.bottom)

            If actTitle = Me.Text Or actTitle.Contains("OBS") Then Exit Sub

            Me.Location = New Point(winR.Left + 2, winR.Top + 25)
        Else
            Me.Visible = False
        End If
    End Sub

    Private Sub lblExpander_Click(sender As System.Object, e As System.EventArgs) Handles lblExpander.Click
        Const defaultSize As Integer = 24

        If targetSizeX = defaultSize Then
            UpdateTargetSize(288, 139, 14)
            isExpanded = True
        Else
            SetForegroundWindow(winProc.MainWindowHandle)
            UpdateTargetSize(defaultSize, defaultSize, 14)
            isExpanded = False
        End If
    End Sub

    Private Sub UpdateTargetSize(ByVal newX As Integer, ByVal newY As Integer, ByVal steps As Integer)
        targetSizeX = newX
        targetSizeY = newY
        targetSizeXStep = Integer.Parse(Math.Round(Math.Abs(Me.Width - newX) / steps))
        targetSizeYStep = Integer.Parse(Math.Round(Math.Abs(Me.Height - newY) / steps))
        tmrAnimator.Enabled = True
    End Sub

    Private Sub tmrAnimator_Tick(sender As System.Object, e As System.EventArgs) Handles tmrAnimator.Tick
        ' Resizing Portion
        If Me.Width < targetSizeX Then Me.Width += targetSizeXStep
        If Me.Width > targetSizeX Then Me.Width -= targetSizeXStep
        If Me.Height < targetSizeY Then Me.Height += targetSizeYStep
        If Me.Height > targetSizeY Then Me.Height -= targetSizeYStep

        ' Clamping
        If Math.Abs(Me.Width - targetSizeX) < targetSizeXStep Then Me.Width = targetSizeX
        If Math.Abs(Me.Height - targetSizeY) < targetSizeYStep Then Me.Height = targetSizeY

        ' Disable animator when not needed
        If Me.Width = targetSizeX And Me.Height = targetSizeY Then
            tmrAnimator.Enabled = False
        End If

    End Sub

    Private Sub switchObjects(fFrom As Integer, fTo As Integer)
        Dim TargetPic As PictureBox
        Dim TargetTxt As Label
        Dim SourcePic As PictureBox
        Dim SourceTxt As Label
        Dim TempPic As Image
        Dim TempTxt As String

        If GetType(Label) = SourceCtrl.GetType Then
            SourceTxt = SourceCtrl
            SourcePic = oPics(fFrom)
        ElseIf GetType(PictureBox) = SourceCtrl.GetType Then
            SourcePic = SourceCtrl
            SourceTxt = oTxts(fFrom)
        Else
            Exit Sub ' Abort!
        End If

        TargetPic = oPics(fTo)
        TargetTxt = oTxts(fTo)

        TempPic = SourcePic.Image
        TempTxt = SourceTxt.Text

        SourcePic.Image = TargetPic.Image
        SourceTxt.Text = TargetTxt.Text

        TargetPic.Image = TempPic
        TargetTxt.Text = TempTxt


        SourceCtrl = Nothing

    End Sub

    Private Sub pic1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic1.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 1)
    End Sub

    Private Sub pic1_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic1.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub pic1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pic1.MouseDown
        SourceCtrl = pic1
        pic1.DoDragDrop(pic1, DragDropEffects.Move)
    End Sub

    Private Sub pic2_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic2.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 2)
    End Sub

    Private Sub pic2_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic2.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub pic2_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pic2.MouseDown
        SourceCtrl = pic2
        pic2.DoDragDrop(pic2, DragDropEffects.Move)
    End Sub

    Private Sub pic3_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic3.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 3)
    End Sub

    Private Sub pic3_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic3.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub pic3_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pic3.MouseDown
        SourceCtrl = pic3
        pic3.DoDragDrop(pic3, DragDropEffects.Move)
    End Sub

    Private Sub pic4_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic4.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 4)
    End Sub

    Private Sub pic4_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pic4.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub pic4_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pic4.MouseDown
        SourceCtrl = pic4
        pic4.DoDragDrop(pic4, DragDropEffects.Move)
    End Sub

    Private Sub txt1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt1.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 1)
    End Sub

    Private Sub txt1_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt1.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub txt1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txt1.MouseDown
        SourceCtrl = txt1
        txt1.DoDragDrop(txt1, DragDropEffects.Move)
    End Sub

    Private Sub txt2_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt2.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 2)
    End Sub

    Private Sub txt2_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt2.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub txt2_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txt2.MouseDown
        SourceCtrl = txt2
        txt2.DoDragDrop(txt2, DragDropEffects.Move)
    End Sub

    Private Sub txt3_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt3.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 3)
    End Sub

    Private Sub txt3_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt3.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub txt3_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txt3.MouseDown
        SourceCtrl = txt3
        txt3.DoDragDrop(txt3, DragDropEffects.Move)
    End Sub

    Private Sub txt4_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt4.DragDrop
        switchObjects(Integer.Parse(SourceCtrl.Name.ToString.Substring(3, 1)), 4)
    End Sub

    Private Sub txt4_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txt4.DragEnter
        SourceCtrl = txt4
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub txt4_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txt4.MouseDown
        txt4.DoDragDrop(txt4, DragDropEffects.Move)
    End Sub

    Private Sub pnlExtender_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlExtender.Paint

    End Sub
End Class