Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities

Public Class frmWorkStation
#Region "Members"
    Private mMessage As Message
    Private mSnippet As Bitmap
#End Region
#Region "Form Events"
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
    Private Sub SAVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SAVEToolStripMenuItem.Click
        Save_Form()
    End Sub
    Private Sub Save_Form()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        Dim selectedPath = frm.FullFileRef()
        Dim success As Boolean
        Serialization_Utilities.Serialize_Object_And_Save_FileSystem(mMessage, selectedPath, success)
    End Sub

    Private Sub LoadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem1.Click

    End Sub
    Private Sub Load_Message(ByVal morph As Boolean)
        Dim success As Boolean
        Dim selectedPath
        If Not morph Then
            Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
            frm.ShowDialog()
            selectedPath = frm.FullFileRef()
        End If
        Try
            If mMessage Is Nothing Then Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message)(selectedPath, mMessage, success) : txtBoxBody.Text = mMessage.Sentences(0).Variations(3) : Exit Sub
        Catch ex As Exception
            Exit Sub
        End Try
        txtBoxBody.Text = mMessage.Sentences(0).Variations(3)
    End Sub
#End Region

End Class