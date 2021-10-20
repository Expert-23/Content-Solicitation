Imports Content.Solicitation.Primitives
Public Class frmWorkStation
    Private Sub BuildEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildEmailToolStripMenuItem.Click
        Dim job As New Job_Curation
        Dim frm As New frmVar(job)
        frm.ShowDialog()
    End Sub

    Private Sub LaunchCampaignToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaunchCampaignToolStripMenuItem.Click

    End Sub

    Private Sub EmailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailsToolStripMenuItem.Click

    End Sub
End Class