Public Class frmMain

    Private Sub btnToolLibrary_Click(sender As System.Object, e As System.EventArgs) Handles btnToolLibrary.Click
        frmLibrary.Show()
    End Sub

    Private Sub btnToolLights_Click(sender As System.Object, e As System.EventArgs) Handles btnToolLights.Click
        frmLightsSolver.Show()
    End Sub

    Private Sub btnToolStat_Click(sender As System.Object, e As System.EventArgs) Handles btnToolStat.Click
        frmStatCalc.Show()
    End Sub
End Class