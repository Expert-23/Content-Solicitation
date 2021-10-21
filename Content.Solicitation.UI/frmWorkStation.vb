Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities

Public Class frmWorkStation
#Region "Members"
    Private mMessage As List(Of Message)
    Private mJob As List(Of Job_Solicitation)
    Private mSelected_Message As Message
    Private mSelected_Job As Job_Solicitation
#End Region
    Public Sub New()
        InitializeComponent()
        Initialize_Form()
    End Sub
    Private Sub Initialize_Form()
        mMessage = New List(Of Message)
        mJob = New List(Of Job_Solicitation)
        mSelected_Message = New Message
        mSelected_Job = New Job_Solicitation
    End Sub
#Region "Form Events"
    Private Sub txtBoxSubject_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSubject.TextChanged
        txtBoxSubject.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub txtBoxBody_TextChanged(sender As Object, e As EventArgs) Handles txtBoxBody.TextChanged
        txtBoxBody.ScrollBars = ScrollBars.Both
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
    Private Sub cboEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmail.SelectedIndexChanged
        txtBoxSubject.Text = mMessage(cboEmail.SelectedIndex).Original_Subject.Original
        mSelected_Message = mMessage(cboEmail.SelectedIndex)
        txtBoxBody.Text = mMessage(cboEmail.SelectedIndex).Original.Body_Text
    End Sub
    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        Dim frm = New frmVar(mSelected_Message)
        frm.ShowDialog()
    End Sub


    Private Sub LoadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem1.Click

    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim msg As New Message
        Dim frm As New frmVar()
        frm.ShowDialog()
        mMessage.Add(frm.Message_)
        cboEmail.Items.Add(frm.Message_.ID)
       mSelected_Message = frm.Message_
    End Sub
    Private Sub Load_Message(ByVal morph As Boolean)
        'Dim success As Boolean
        'Dim selectedPath
        'If Not morph Then
        '    Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        '    frm.ShowDialog()
        '    selectedPath = frm.FullFileRef()
        'End If
        'Try
        '    If mMessage Is Nothing Then Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message)(selectedPath, mMessage, success) : txtBoxBody.Text = mMessage.Sentences(0).Variations(3) : Exit Sub
        'Catch ex As Exception
        '    Exit Sub
        'End Try
        'txtBoxBody.Text = mMessage.Sentences(0).Variations(3)
    End Sub
#End Region
    Private Sub Save_Form()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        Dim selectedPath = frm.FullFileRef()
        Dim success As Boolean
        Dim cmb As New Solicitation_Message_Combo
        With cmb
            .Message = mMessage(cboEmail.SelectedIndex)
            .Solicit = mJob(cboSnippet.SelectedIndex)
        End With
        Serialization_Utilities.Serialize_Object_And_Save_FileSystem(cmb, selectedPath, success)
    End Sub
    Private Sub Load_Form()
        Dim cmb As New Solicitation_Message_Combo
        Dim success As Boolean

        Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
            frm.ShowDialog()
        Dim selectedPath = frm.FullFileRef()

        Try
            Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Solicitation_Message_Combo)(selectedPath, cmb, success)
            mSelected_Job = cmb.Solicit
            mSelected_Message = cmb.Message
            txtBoxBody.Text = mSelected_Message.Original.Body_Text
            txtBoxSubject.Text = mSelected_Message.Original_Subject.Original
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub

    Private Sub cboSnippet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSnippet.SelectedIndexChanged
        mSelected_Job = mJob(cboSnippet.SelectedIndex)
    End Sub
End Class