Public Class frmLibrary
    Private SourceCtrl As Object
    Private oPics(5) As PictureBox
    Private oTxts(5) As Label

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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
            oTxts(i).AllowDrop = True
            oTxts(i).BackColor = Color.FromArgb(128, 0, 0, 0)
        Next
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

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click
        frmLightsSolver.Show()
    End Sub
End Class
