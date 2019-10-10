Imports System.Runtime.InteropServices
Imports System.Text
Imports System.ComponentModel

Public Class frmLightsSolverOverlay
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

    Public isExpanded As Boolean = False

    Private tbtArr(3, 3) As PictureBox
    Private tbtsArr(3, 3) As Label
    Private fbfArr(5, 5) As PictureBox
    Private fbfsArr(5, 5) As Label

    Private Sub frmLightsSolverOverlay_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        ' Core Code
        SetWindowPos(Me.Handle(), HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
        Me.Size = New System.Drawing.Size(targetSizeX, targetSizeY)
        Dim procs() As Process = Process.GetProcessesByName("hwr")
        Dim hwr As Process = procs(0)
        winProc = hwr

        winHandle = hwr.MainWindowHandle
        winTitle = hwr.MainWindowTitle

        ' Lights Code
        SetupArray() ' See Region: Array Set-up

        ' Add button handlers (Minimize "Handles..." spam)
        For i As Integer = 1 To 3 Step 1
            For j As Integer = 1 To 3 Step 1
                AddHandler tbtArr(i, j).Click, AddressOf Me.LightToggle
                tbtArr(i, j).Tag = "0"
            Next
        Next

        For i As Integer = 1 To 5 Step 1
            For j As Integer = 1 To 5 Step 1
                AddHandler fbfArr(i, j).Click, AddressOf Me.LightToggle
                fbfArr(i, j).Tag = "0"
            Next
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
            If frmLibraryOverlay.isExpanded Then
                Me.Visible = False
                Exit Sub
            End If
            Me.Visible = True
            If winHandle = IntPtr.Zero Then Exit Sub

            If Not GetWindowRect(winHandle, winRect) Then Throw New Win32Exception

            winR = Rectangle.FromLTRB(winRect.left, winRect.top, winRect.right, winRect.bottom)

            If actTitle = Me.Text Or actTitle.Contains("OBS") Then Exit Sub

            Me.Location = New Point(winR.Left + 2, winR.Top + 50)
        Else
            Me.Visible = False
        End If
    End Sub

    Private Sub lblExpander_Click(sender As System.Object, e As System.EventArgs) Handles lblExpander.Click
        Const defaultSize As Integer = 24

        If targetSizeX = defaultSize Then
            TabControl1.Visible = True
            If TabControl1.SelectedIndex = 0 Then
                UpdateTargetSize(268, 174, 14)
            ElseIf TabControl1.SelectedIndex = 1 Then
                UpdateTargetSize(419, 247, 14)
            End If
            isExpanded = True
        Else
            TabControl1.Visible = False
            UpdateTargetSize(defaultSize, defaultSize, 14)
            SetForegroundWindow(winProc.MainWindowHandle)
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

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            UpdateTargetSize(268, 174, 14)
        ElseIf TabControl1.SelectedIndex = 1 Then
            UpdateTargetSize(419, 247, 14)
        End If
    End Sub

    Private Sub LightToggle(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim psender As PictureBox = CType(sender, PictureBox)
        If psender.Tag = "0" Then
            psender.Tag = "1"
            psender.Image = My.Resources.Tile_ON
        ElseIf psender.Tag = "1" Then
            psender.Tag = "0"
            psender.Image = My.Resources.Tile_Off
        End If
    End Sub

    Private Sub btnSolve3x3_Click(sender As System.Object, e As System.EventArgs) Handles btnSolve3x3.Click
        Dim pArr(3, 3) As Integer
        Dim lArr(3, 3) As Integer

        ' Setup start values
        For i = 1 To 3 Step 1
            For j = 1 To 3 Step 1
                lArr(i, j) = Integer.Parse(tbtArr(i, j).Tag)
            Next
        Next

        ' Pass 1
        For i = 2 To 3 Step 1
            For j = 1 To 3 Step 1
                If lArr(i - 1, j) = 0 Then
                    PressLight(lArr, i, j, pArr)
                End If
            Next
        Next

        ' Pattern Press
        Dim lastRow As String = ""
        For i = 1 To 3 Step 1
            lastRow &= lArr(3, i)
        Next
        If lastRow = "011" Then
            PressLight(lArr, 1, 1, pArr)
            PressLight(lArr, 1, 2, pArr)
        ElseIf lastRow = "101" Then
            PressLight(lArr, 1, 1, pArr)
            PressLight(lArr, 1, 2, pArr)
            PressLight(lArr, 1, 3, pArr)
        ElseIf lastRow = "001" Then
            PressLight(lArr, 1, 3, pArr)
        ElseIf lastRow = "110" Then
            PressLight(lArr, 1, 2, pArr)
            PressLight(lArr, 1, 3, pArr)
        ElseIf lastRow = "010" Then
            PressLight(lArr, 1, 1, pArr)
            PressLight(lArr, 1, 3, pArr)
        ElseIf lastRow = "100" Then
            PressLight(lArr, 1, 1, pArr)
        ElseIf lastRow = "000" Then
            PressLight(lArr, 1, 2, pArr)
        End If

        ' Pass 2
        For i = 2 To 3 Step 1
            For j = 1 To 3 Step 1
                If lArr(i - 1, j) = 0 Then
                    PressLight(lArr, i, j, pArr)
                End If
            Next
        Next

        ' We should be solved, display results
        For i = 1 To 3 Step 1
            For j = 1 To 3 Step 1
                If (pArr(i, j)) = 0 Then
                    tbtsArr(i, j).BackColor = Color.FromArgb(128, 255, 0, 0)
                Else
                    tbtsArr(i, j).BackColor = Color.FromArgb(128, 0, 255, 0)
                End If
                tbtsArr(i, j).Text = pArr(i, j)
            Next
        Next
    End Sub

    Private Sub btnSolve5x5_Click(sender As System.Object, e As System.EventArgs) Handles btnSolve5x5.Click
        Dim pArr(5, 5) As Integer
        Dim lArr(5, 5) As Integer

        ' Setup start values
        For i = 1 To 5 Step 1
            For j = 1 To 5 Step 1
                lArr(i, j) = Integer.Parse(fbfArr(i, j).Tag)
            Next
        Next

        ' Pass 1
        ChaseLights(lArr, pArr)

        ' Pattern Press
        Dim lastRow As String = ""
        For i = 1 To 5 Step 1
            lastRow &= lArr(5, i)
        Next
        ' 00000 => NS        ' 10000 => NS        ' 01000 => NS        ' 11000 => 00010     ' 00100 => 00100
        ' 10100 => NS        ' 01100 => NS        ' 11100 => NS        ' 00010 => NS        ' 10010 => 10000
        ' 01010 => NS        ' 11010 => NS        ' 00110 => NS        ' 10110 => NS        ' 01110 => 00011
        ' 11110 => NS        ' 00001 => NS        ' 10001 => NS        ' 01001 => 00001     ' 11001 => NS
        ' 00101 => NS        ' 10101 => 00111     ' 01101 => NS        ' 11101 => NS        ' 00011 => 01000
        ' 10011 => NS        ' 01011 => NS        ' 11011 => NS        ' 00111 => NS        ' 10111 => NS
        ' 01111 => NS        ' 11111 => NS                                                  NS = No Solution
        If lastRow = "11000" Then
            PressLight(lArr, 1, 4, pArr)
        ElseIf lastRow = "00100" Then
            PressLight(lArr, 1, 3, pArr)
        ElseIf lastRow = "10010" Then
            PressLight(lArr, 1, 1, pArr)
        ElseIf lastRow = "01110" Then
            PressLight(lArr, 1, 4, pArr)
            PressLight(lArr, 1, 5, pArr)
        ElseIf lastRow = "01001" Then
            PressLight(lArr, 1, 5, pArr)
        ElseIf lastRow = "01001" Then
            PressLight(lArr, 1, 5, pArr)
        ElseIf lastRow = "10101" Then
            PressLight(lArr, 1, 3, pArr)
            PressLight(lArr, 1, 4, pArr)
            PressLight(lArr, 1, 5, pArr)
        ElseIf lastRow = "00011" Then
            PressLight(lArr, 1, 2, pArr)
        Else
            For i = 1 To 5 Step 1
                For j = 1 To 5 Step 1
                    fbfsArr(i, j).Text = "ERR"
                Next
            Next
            Exit Sub ' We cannot solve any other bottom pattern
        End If

        ' Pass 2
        ChaseLights(lArr, pArr)

        ' We should be solved, display results
        For i = 1 To 5 Step 1
            For j = 1 To 5 Step 1
                If (pArr(i, j)) = 0 Then
                    fbfsArr(i, j).BackColor = Color.FromArgb(128, 255, 0, 0)
                Else
                    fbfsArr(i, j).BackColor = Color.FromArgb(128, 0, 255, 0)
                End If
                fbfsArr(i, j).Text = pArr(i, j)
            Next
        Next
    End Sub

    Private Sub ChaseLights(ByRef lightArray(,) As Integer, ByRef pressArray(,) As Integer)
        For i = 2 To lightArray.GetUpperBound(0) Step 1
            For j = 1 To lightArray.GetUpperBound(0) Step 1
                If lightArray(i - 1, j) = 0 Then
                    PressLight(lightArray, i, j, pressArray)
                End If
            Next
        Next
    End Sub

    Private Sub PressLight(ByRef lightArray(,) As Integer, ByVal row As Integer, ByVal col As Integer, ByRef pressArray(,) As Integer)
        pressArray(row, col) = (pressArray(row, col) + 1) Mod 2

        ' Up
        If row - 1 >= 1 Then
            lightArray(row - 1, col) = (lightArray(row - 1, col) + 1) Mod 2
        End If
        ' Down
        If row + 1 <= lightArray.GetUpperBound(0) Then
            lightArray(row + 1, col) = (lightArray(row + 1, col) + 1) Mod 2
        End If
        ' Left
        If col - 1 >= 1 Then
            lightArray(row, col - 1) = (lightArray(row, col - 1) + 1) Mod 2
        End If
        ' Right
        If col + 1 <= lightArray.GetUpperBound(0) Then
            lightArray(row, col + 1) = (lightArray(row, col + 1) + 1) Mod 2
        End If
        ' Self
        lightArray(row, col) = (lightArray(row, col) + 1) Mod 2
    End Sub


#Region "Array Set-up"
    Private Sub SetupArray()
        tbtArr(1, 1) = tbt11
        tbtArr(1, 2) = tbt12
        tbtArr(1, 3) = tbt13
        tbtArr(2, 1) = tbt21
        tbtArr(2, 2) = tbt22
        tbtArr(2, 3) = tbt23
        tbtArr(3, 1) = tbt31
        tbtArr(3, 2) = tbt32
        tbtArr(3, 3) = tbt33
        tbtsArr(1, 1) = tbts11
        tbtsArr(1, 2) = tbts12
        tbtsArr(1, 3) = tbts13
        tbtsArr(2, 1) = tbts21
        tbtsArr(2, 2) = tbts22
        tbtsArr(2, 3) = tbts23
        tbtsArr(3, 1) = tbts31
        tbtsArr(3, 2) = tbts32
        tbtsArr(3, 3) = tbts33

        fbfArr(1, 1) = fbf11
        fbfArr(1, 2) = fbf12
        fbfArr(1, 3) = fbf13
        fbfArr(1, 4) = fbf14
        fbfArr(1, 5) = fbf15
        fbfArr(2, 1) = fbf21
        fbfArr(2, 2) = fbf22
        fbfArr(2, 3) = fbf23
        fbfArr(2, 4) = fbf24
        fbfArr(2, 5) = fbf25
        fbfArr(3, 1) = fbf31
        fbfArr(3, 2) = fbf32
        fbfArr(3, 3) = fbf33
        fbfArr(3, 4) = fbf34
        fbfArr(3, 5) = fbf35
        fbfArr(4, 1) = fbf41
        fbfArr(4, 2) = fbf42
        fbfArr(4, 3) = fbf43
        fbfArr(4, 4) = fbf44
        fbfArr(4, 5) = fbf45
        fbfArr(5, 1) = fbf51
        fbfArr(5, 2) = fbf52
        fbfArr(5, 3) = fbf53
        fbfArr(5, 4) = fbf54
        fbfArr(5, 5) = fbf55
        fbfsArr(1, 1) = fbfs11
        fbfsArr(1, 2) = fbfs12
        fbfsArr(1, 3) = fbfs13
        fbfsArr(1, 4) = fbfs14
        fbfsArr(1, 5) = fbfs15
        fbfsArr(2, 1) = fbfs21
        fbfsArr(2, 2) = fbfs22
        fbfsArr(2, 3) = fbfs23
        fbfsArr(2, 4) = fbfs24
        fbfsArr(2, 5) = fbfs25
        fbfsArr(3, 1) = fbfs31
        fbfsArr(3, 2) = fbfs32
        fbfsArr(3, 3) = fbfs33
        fbfsArr(3, 4) = fbfs34
        fbfsArr(3, 5) = fbfs35
        fbfsArr(4, 1) = fbfs41
        fbfsArr(4, 2) = fbfs42
        fbfsArr(4, 3) = fbfs43
        fbfsArr(4, 4) = fbfs44
        fbfsArr(4, 5) = fbfs45
        fbfsArr(5, 1) = fbfs51
        fbfsArr(5, 2) = fbfs52
        fbfsArr(5, 3) = fbfs53
        fbfsArr(5, 4) = fbfs54
        fbfsArr(5, 5) = fbfs55
    End Sub
#End Region
End Class