Public Class frmConstellation
    Private finalized As Boolean = False
    Private grid(4)() As PictureBox

    Private Sub cmbConstellations_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbConstellations.SelectedIndexChanged
        UpdateConstellation(cmbConstellations.Text)
    End Sub

    Private Sub UpdateConstellation(ByVal name As String)
        If finalized = False Then Return

        Select Case name
            Case "Bolt"
                ToggleViaString("01000 00100 01110 00100 00010")
            Case "Rupee"
                ToggleViaString("00100 01010 01010 01010 00100")
            Case "Arrow"
                ToggleViaString("00100 01000 10111 01000 00100")
            Case "Cross"
                ToggleViaString("00100 01110 00100 00100 00100")
            Case "Meteor"
                ToggleViaString("10000 01000 00110 00101 00011")
            Case "Sword"
                ToggleViaString("00001 00010 10100 01000 10100")
            Case "Shield"
                ToggleViaString("11111 10001 10001 01010 00100")
            Case "Pitchfork"
                ToggleViaString("10101 10101 01110 00100 00100")
            Case Else
                TurnAllOff()
        End Select
    End Sub

    Private Sub ToggleViaString(ByVal data As String)
        data = data.Replace(" ", "") ' Strip all spaces
        For j = 0 To 4
            For i = 0 To 4
                If data.Chars(j * 5 + i) = "0" Then
                    grid(i)(j).Image = My.Resources.Icon_Constellation_Off
                    grid(i)(j).Tag = "0"
                Else
                    grid(i)(j).Image = My.Resources.Icon_Constellation_On
                    grid(i)(j).Tag = "1"
                End If
            Next
        Next
    End Sub

    Private Sub TurnAllOn()
        For j = 0 To 4
            For i = 0 To 4
                grid(i)(j).Image = My.Resources.Icon_Constellation_On
                grid(i)(j).Tag = "1"
            Next
        Next
    End Sub

    Private Sub TurnAllOff()
        For j = 0 To 4
            For i = 0 To 4
                grid(i)(j).Image = My.Resources.Icon_Constellation_Off
                grid(i)(j).Tag = "0"
            Next
        Next
    End Sub

    Private Sub frmConstellation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Init 2d arrays
        For i = 0 To 4
            ReDim Preserve grid(i)(4)
        Next

        ' Create control array
        grid(0)(0) = pic00
        grid(0)(1) = pic01
        grid(0)(2) = pic02
        grid(0)(3) = pic03
        grid(0)(4) = pic04
        grid(1)(0) = pic10
        grid(1)(1) = pic11
        grid(1)(2) = pic12
        grid(1)(3) = pic13
        grid(1)(4) = pic14
        grid(2)(0) = pic20
        grid(2)(1) = pic21
        grid(2)(2) = pic22
        grid(2)(3) = pic23
        grid(2)(4) = pic24
        grid(3)(0) = pic30
        grid(3)(1) = pic31
        grid(3)(2) = pic32
        grid(3)(3) = pic33
        grid(3)(4) = pic34
        grid(4)(0) = pic40
        grid(4)(1) = pic41
        grid(4)(2) = pic42
        grid(4)(3) = pic43
        grid(4)(4) = pic44


        Dim ptStart As Point = picBack.Location
        For i = 0 To 4
            For j = 0 To 4
                ' Update control location
                grid(i)(j).Location = New Point(ptStart.X + ((i + 1) * 16 + (i * grid(i)(j).Image.Size.Width)), ptStart.Y + ((j + 1) * 16 + (j * grid(i)(j).Image.Size.Height)))

                ' Add click handler
                AddHandler grid(i)(j).Click, AddressOf ToggleGrid

                ' Add Default Tag
                grid(i)(j).Tag = "0"
            Next
        Next

        finalized = True

        ' Turn Them All Off
        TurnAllOff()
    End Sub

    Public Sub ToggleGrid(ByVal sender As Object, ByVal e As EventArgs)
        Dim t As PictureBox = sender
        Console.WriteLine(t.ImageLocation)

        If t.Tag = "0" Then
            t.Image = My.Resources.Icon_Constellation_On
            t.Tag = "1"
        Else
            t.Image = My.Resources.Icon_Constellation_Off
            t.Tag = "0"
        End If
    End Sub
End Class