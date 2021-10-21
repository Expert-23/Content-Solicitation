Imports Content.Solicitation.Primitives
Public Class frmWorkStation
    Private Sub BuildEmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildEmailToolStripMenuItem.Click
        Dim job As New Job_Curation
        Dim frm As New frmVar(job)
        frm.ShowDialog()
    End Sub

    Private Sub LaunchCampaignToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaunchCampaignToolStripMenuItem.Click
        Dim JOB As New Job_Curation
        Dim message As New Message
        Dim frm = New frmCAmpaign(message, JOB)
        frm.ShowDialog()
    End Sub

End Class