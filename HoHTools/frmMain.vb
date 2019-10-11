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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnOverlay.Click
        frmLibraryOverlay.Show()
        frmLightsSolverOverlay.Show()
    End Sub

    Private Sub btnSettings_Click(sender As System.Object, e As System.EventArgs) Handles btnSettings.Click
        frmSettingsEditor.Show()
    End Sub

    Private Sub btnConstellation_Click(sender As System.Object, e As System.EventArgs) Handles btnConstellation.Click
        frmConstellation.Show()
    End Sub

    Private Sub btnFountain_Click(sender As System.Object, e As System.EventArgs) Handles btnFountain.Click
        frmFountain.Show()
    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class