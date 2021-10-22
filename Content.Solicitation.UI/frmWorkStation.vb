Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities

Public Class frmWorkStation
#Region "Members"
    Private mMessage As List(Of Message)
    Private mJob As List(Of Job_Solicitation)
    Private mSelected_Message As Message
    Private mSelected_Job As Job_Solicitation
    Private mJOB_Message As Solicitation_Message_Combo
#End Region

#Region "Initialization"
    Public Sub New()
        InitializeComponent()
        Initialize_Form()
    End Sub
    Private Sub Initialize_Form()
        Initialize_Members()
        Initialize_Combobox_Websites()
    End Sub
    Private Sub Initialize_Members()
        mMessage = New List(Of Message)
        mJob = New List(Of Job_Solicitation)
        mSelected_Message = New Message
        mSelected_Job = New Job_Solicitation
    End Sub
    Private Sub Initialize_Combobox_Websites()
        cboWebsite.Items.Clear()
        With cboWebsite
            For Each item In System.Enum.GetValues(GetType(Websites))

                If item <> Websites.unspecified Then
                    .Items.Add(item)
                End If
            Next
            .SelectedIndex = 0
        End With
    End Sub
#End Region

#Region "Form Events"
    Private Sub txtBoxSubject_TextChanged(sender As Object, e As EventArgs) Handles txtBoxSubject.TextChanged
        txtBoxSubject.ScrollBars = ScrollBars.Both
    End Sub
    Private Sub txtBoxBody_TextChanged(sender As Object, e As EventArgs) Handles txtBoxBody.TextChanged
        txtBoxBody.ScrollBars = ScrollBars.Both
    End Sub
    Private Sub LoadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LoadToolStripMenuItem1.Click
        Load_JOB_Message()
    End Sub
    Private Sub LaunchCampaignToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaunchCampaignToolStripMenuItem.Click
        Launch_Campaign()
    End Sub
    Private Sub SAVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SAVEToolStripMenuItem.Click
        Save_Form()
    End Sub
    Private Sub cboSnippet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSnippet.SelectedIndexChanged
        Map_Selected_Job()
    End Sub
    Private Sub cboEmail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmail.SelectedIndexChanged
        Map_Selected_Email()
    End Sub
    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        Edit_Email()
    End Sub
#End Region

#Region "Methods"
    Private Sub Map_Selected_Email()
        txtBoxSubject.Text = mMessage(cboEmail.SelectedIndex).Original_Subject.Original
        mSelected_Message = mMessage(cboEmail.SelectedIndex)
        txtBoxBody.Text = mMessage(cboEmail.SelectedIndex).Original.Body_Text
    End Sub
    Private Sub Map_Job_Email()
        Map_Selected_Email()
        Map_Selected_Job()
    End Sub
    Private Sub Edit_Email()
        Dim frm = New frmVar(mSelected_Message)
        frm.ShowDialog()
    End Sub
    Private Sub Map_Selected_Job()
        mSelected_Job = mJob(cboSnippet.SelectedIndex)
    End Sub
    Private Sub Launch_Campaign()
        Dim JOB As New Job_Curation
        Dim message As New Message
        Dim frm = New frmCAmpaign(message, JOB)
        frm.ShowDialog()
    End Sub
    Private Sub Load_JOB_Message()
        Dim success As Boolean
        Dim selectedPath
        Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        selectedPath = frm.FullFileRef()
        Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Solicitation_Message_Combo)(selectedPath, mJOB_Message, success)
        Map_Job_Email()
    End Sub
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim msg As New Message
        Dim frm As New frmVar()
        frm.ShowDialog()
        If frm.Message_ IsNot Nothing Then
            mMessage.Add(frm.Message_)
            cboEmail.Items.Add(frm.Message_.ID)
            mSelected_Message = frm.Message_
        End If
    End Sub
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
#End Region
End Class