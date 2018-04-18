Public Class frmLightsSolver
    Private tbtArr(3, 3) As PictureBox
    Private tbtsArr(3, 3) As Label
    Private fbfArr(5, 5) As PictureBox
    Private fbfsArr(5, 5) As Label

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            Me.Size = New System.Drawing.Size(248, 198)
        ElseIf TabControl1.SelectedIndex = 1 Then
            Me.Size = New System.Drawing.Size(408, 278)
        End If
    End Sub

    Private Sub frmLightsSolver_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New System.Drawing.Size(248, 198)
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