﻿Public Class frmFountain
    Private Buffs(17) As Label
    Private Debuffs(15) As Label
    Private sFortune As String = ""
    Private posFortune As String = ""
    Private negFortune As String = ""
    Private oFortune As Integer = 0

    Private Sub frmFountain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Configure Buff Array
        Buffs(0) = lblBuff1
        Buffs(1) = lblBuff2
        Buffs(2) = lblBuff3
        Buffs(3) = lblBuff4
        Buffs(4) = lblBuff5
        Buffs(5) = lblBuff6
        Buffs(6) = lblBuff7
        Buffs(7) = lblBuff8
        Buffs(8) = lblBuff9
        Buffs(9) = lblBuff10
        Buffs(10) = lblBuff11
        Buffs(11) = lblBuff12
        Buffs(12) = lblBuff13
        Buffs(13) = lblBuff14
        Buffs(14) = lblBuff15
        Buffs(15) = lblBuff16
        Buffs(16) = lblBuff17
        Buffs(17) = lblBuff18

        ' Configure Debuff Array
        Debuffs(0) = lblDebuff1
        Debuffs(1) = lblDebuff2
        Debuffs(2) = lblDebuff3
        Debuffs(3) = lblDebuff4
        Debuffs(4) = lblDebuff5
        Debuffs(5) = lblDebuff6
        Debuffs(6) = lblDebuff7
        Debuffs(7) = lblDebuff8
        Debuffs(8) = lblDebuff9
        Debuffs(9) = lblDebuff10
        Debuffs(10) = lblDebuff11
        Debuffs(11) = lblDebuff12
        Debuffs(12) = lblDebuff13
        Debuffs(13) = lblDebuff14
        Debuffs(14) = lblDebuff15
        Debuffs(15) = lblDebuff16

        ' Loop Through Arrays To Set Tags & Handlers
        For Each lb As Label In Buffs
            lb.Tag = "0" ' Unselected
            AddHandler lb.MouseEnter, AddressOf LabelHover
            AddHandler lb.MouseClick, AddressOf LabelClick
            AddHandler lb.MouseLeave, AddressOf LabelLeave
        Next

        For Each lb As Label In Debuffs
            lb.Tag = "0" ' Unselected
            AddHandler lb.MouseEnter, AddressOf LabelHover
            AddHandler lb.MouseClick, AddressOf LabelClick
            AddHandler lb.MouseLeave, AddressOf LabelLeave
        Next
    End Sub

    Private Sub chkHideUnsel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHideUnsel.CheckedChanged
        Dim ctrlHeight As Integer = Buffs(0).Size.Height
        Dim ctrlPos As Integer = pnlPositive.Size.Height
        Dim ctrlNeg As Integer = pnlNegative.Size.Height
        Dim cntPos As Integer = 0
        Dim cntNeg As Integer = 0

        If chkHideUnsel.Checked = True Then
            ' Update Text
            chkHideUnsel.Text = "Show All"

            ' Loop Buffs
            For Each lb As Label In Buffs
                lb.Visible = False
                If lb.Tag = "1" Then
                    lb.Visible = True
                    cntPos += 1
                End If
            Next
            ' Buff Scroll Buffer
            lblBufferPos.Height = ctrlPos - (cntPos * ctrlHeight) + 1

            ' Loop Debuffs
            For Each lb As Label In Debuffs
                lb.Visible = False
                If lb.Tag = "1" Then
                    lb.Visible = True
                    cntNeg += 1
                End If
            Next

            ' Debuff Scroll Buffer
            lblBufferNeg.Height = ctrlNeg - (cntNeg * ctrlHeight) + 1

        Else
            chkHideUnsel.Text = "Show Selected"
            For Each lb As Label In Buffs
                lb.Visible = True
            Next
            lblBufferPos.Height = 1

            For Each lb As Label In Debuffs
                lb.Visible = True
            Next
            lblBufferNeg.Height = 1
        End If
    End Sub

    Private Sub LabelHover(sender As Object, e As System.EventArgs)
        Dim lb As Label = CType(sender, Label)
        lb.Image = My.Resources.Fountain_Btn_Hover

        ' Panel Fix, See Region "Panel Scroll Fix"
        If lb.Name.Contains("Debuff") Then
            activePanel = pnlNegative
        ElseIf lb.Name.Contains("Buff") Then
            activePanel = pnlPositive
        Else
            activePanel = Nothing
        End If
    End Sub

    Private Sub LabelClick(sender As Object, e As System.EventArgs)
        Dim lb As Label = CType(sender, Label)
        If lb.Tag = "0" Then
            lb.Tag = "1"
            lb.Image = My.Resources.Fountain_Btn_Selected
        ElseIf lb.Tag = "1" Then
            lb.Tag = "0"
            lb.Image = My.Resources.Fountain_Btn_Base
        End If

        UpdateDisplays()
    End Sub

    Private Sub LabelLeave(sender As Object, e As System.EventArgs)
        Dim lb As Label = CType(sender, Label)
        If lb.Tag = "0" Then
            lb.Image = My.Resources.Fountain_Btn_Base
        ElseIf lb.Tag = "1" Then
            lb.Image = My.Resources.Fountain_Btn_Selected
        End If

        ' Panel Fix, See Region "Panel Scroll Fix"
        If activePanel IsNot Nothing And lastActive IsNot Nothing Then lastActive.Focus()
        activePanel = Nothing
    End Sub

    Private Sub UpdateFortune()
        oFortune = 0
        negFortune = ""
        posFortune = ""
        sFortune = ""

        For Each buff As Label In Buffs
            If buff.Tag = "1" Then
                ' Extract Fortune Amount
                Dim parts() As String = buff.Text.Trim().Split(" ")
                Dim vPart As String = parts(0).Substring(1, parts(0).Length - 1)
                Dim iPart As Integer = 0
                Integer.TryParse(vPart, iPart)

                oFortune += iPart
            End If

            posFortune &= buff.Tag
        Next
        sFortune &= Convert.ToInt64(posFortune, 2)

        sFortune &= "A"

        For Each debuff As Label In Debuffs
            If debuff.Tag = "1" Then
                ' Extract Fortune Amount
                Dim parts() As String = debuff.Text.Trim().Split(" ")
                Dim vPart As String = parts(0).Substring(1, parts(0).Length - 1)
                Dim iPart As Integer = 0
                Integer.TryParse(vPart, iPart)

                oFortune -= iPart
            End If

            negFortune &= debuff.Tag
        Next
        sFortune &= Convert.ToInt64(negFortune, 2)

        sFortune &= "A" & oFortune
        sFortune &= "A" & IIf(chkHideUnsel.Checked = True, "1", "0")
    End Sub

    Private Sub UpdateDisplays()
        UpdateFortune()
        If oFortune < 0 Then
            picFavorBalance.Image = My.Resources.Fountain_NegFav
            lblFavor.ForeColor = Color.Red
            lblFavor.Text = "Favor " & oFortune
        ElseIf oFortune = 0 Then
            picFavorBalance.Image = My.Resources.Fountain_NeuFav
            lblFavor.ForeColor = Color.White
            lblFavor.Text = "Favor 0"
        ElseIf oFortune > 0 Then
            picFavorBalance.Image = My.Resources.Fountain_PosFav
            lblFavor.ForeColor = Color.LimeGreen
            lblFavor.Text = "Favor +" & oFortune
        End If
        lblFavCost.Text = Math.Min(Math.Max(150 * ((2 ^ oFortune) - 1), 0), 200000000)
        lblFavGold.Text = Math.Max(5 * (-1 * oFortune), 0) & "%"
        lblFavXp.Text = Math.Max(5 * (-1 * oFortune), 0) & "%"
    End Sub

    Private Sub btnShare_Click(sender As System.Object, e As System.EventArgs) Handles btnShare.Click
        UpdateDisplays()

        Clipboard.SetText(sFortune)
        MessageBox.Show("Copied Share Code To Clipboard", "Share Code", MessageBoxButtons.OK)
    End Sub

    Private Sub btnLoadShare_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadShare.Click
        Dim pRet As Boolean = False
        Dim mRet As DialogResult
        Do
            Dim ret As String = InputBox("Paste in share code. Leave blank to cancel.", "Share Code Entry", "")
            If ret = "" Then Return

            pRet = ParseCode(ret)
            If pRet = False Then
                mRet = MessageBox.Show("Invalid share code! Make sure you copied and pasted it correctly!", "Share Code Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
            End If
        Loop While mRet = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Dim mRet As DialogResult = MessageBox.Show("Clear fountain selection?", "Confirm Reset", MessageBoxButtons.YesNo)
        If mRet = Windows.Forms.DialogResult.No Then Return

        For Each lb As Label In Buffs
            lb.Tag = "0"
            lb.Image = My.Resources.Fountain_Btn_Base
        Next

        For Each lb As Label In Debuffs
            lb.Tag = "0"
            lb.Image = My.Resources.Fountain_Btn_Base
        Next

        UpdateDisplays()
        chkHideUnsel_CheckedChanged(Nothing, Nothing)
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        sfd.Title = "Save Fountain Setup..."
        sfd.Filter = "Fountain Setup|*.hfs|All Files|*.*"
        Dim ret As DialogResult = sfd.ShowDialog()
        If ret = Windows.Forms.DialogResult.Cancel Then Return

        System.IO.File.WriteAllText(sfd.FileName, sFortune)
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        ofd.Title = "Open Fountain Setup..."
        ofd.Filter = "Fountain Setup|*.hf|All Files|*.*"
        Dim ret As DialogResult = ofd.ShowDialog()
        If ret = Windows.Forms.DialogResult.Cancel Then Return

        Dim sRet As String = System.IO.File.ReadAllText(ofd.FileName)
        Dim mRet As DialogResult
        Dim pRet As Boolean = False
        Do
            pRet = ParseCode(sRet)
            If pRet = False Then
                mRet = MessageBox.Show("Error! Could not parse file contents. Do you wish to try again?", "Load Parse Error", MessageBoxButtons.YesNo)
            End If
        Loop While mRet = Windows.Forms.DialogResult.Yes And pRet = False
    End Sub

    Private Function ParseCode(code As String) As Boolean
        Dim parts() As String = code.Split("A")
        If parts.Length <> 4 Then
            Return False
        End If

        ' We have enough parts!
        Try
            ' Parse elements to longs and convert to binary strings

            ' " Positive
            Dim piFav As Long = 0
            Long.TryParse(parts(0), piFav)
            Dim pFav As String = Convert.ToString(piFav, 2).PadLeft(Buffs.Length, "0")

            ' " Negative
            Dim niFav As Long = 0
            Long.TryParse(parts(1), niFav)
            Dim nFav As String = Convert.ToString(niFav, 2).PadLeft(Debuffs.Length, "0")

            ' " Overall Favor
            Dim oiFav As Long = 0
            Long.TryParse(parts(2), oiFav)
            Dim oFav As String = Convert.ToString(oiFav, 2)

            ' " Selection Checkbox
            Dim ciSel As Long = 0
            Long.TryParse(parts(3), ciSel)
            If ciSel = 0 Then chkHideUnsel.Checked = False Else If ciSel = 1 Then chkHideUnsel.Checked = True

            ' Verify element lengths - If these trigger than padding failed or theres more bits than desired, may be an outdated share code
            If pFav.Length <> Buffs.Length Then Return False
            If nFav.Length <> Debuffs.Length Then Return False

            ' Finally Parse for Buff Tags and then run UpdateDisplays()
            For i = 0 To pFav.Length - 1
                Buffs(i).Tag = pFav.Chars(i)
                Buffs(i).Image = IIf(pFav.Chars(i) = "1", My.Resources.Fountain_Btn_Selected, My.Resources.Fountain_Btn_Base)
            Next

            ' " Debuffs
            For i = 0 To nFav.Length - 1
                Debuffs(i).Tag = nFav.Chars(i)
                Debuffs(i).Image = IIf(nFav.Chars(i) = "1", My.Resources.Fountain_Btn_Selected, My.Resources.Fountain_Btn_Base)
            Next

            ' Update Display Info
            UpdateDisplays()
            chkHideUnsel_CheckedChanged(Nothing, Nothing)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

#Region "PanelScrollFix"

    Private activePanel As Panel = Nothing
    Private lastActive As Object = Nothing

    Private Sub frmFountain_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If lastActive Is Nothing Then lastActive = Me.ActiveControl

        If activePanel IsNot Nothing Then
            activePanel.Focus()
        End If
    End Sub
#End Region

End Class