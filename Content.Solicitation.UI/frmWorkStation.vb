Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Controllers

Public Class frmWorkStation
#Region "Members"
    Private mMessage As SortedDictionary(Of Integer, SortedDictionary(Of String, Message))
    Private mJob As SortedDictionary(Of Integer, SortedDictionary(Of Integer, Job_Solicitation))
    Private mSelected_Message As Message
    Private mSelected_Job As Job_Solicitation
    Private mJOB_Message As Solicitation_Message_Combo
    Private mPersist_Message As Controller_Message
#End Region

#Region "Initialization"
    Public Sub New()
        InitializeComponent()
        Initialize_Form()
    End Sub
    Private Sub Initialize_Form()
        Initialize_Members()
        Initialize_Comboboxes()
    End Sub
    Private Sub Initialize_Members()

        mMessage = New SortedDictionary(Of Integer, SortedDictionary(Of String, Message))
        mJob = New SortedDictionary(Of Integer, SortedDictionary(Of Integer, Job_Solicitation))
        mSelected_Message = New Message
        mSelected_Job = New Job_Solicitation
        mPersist_Message = New Controller_Message
        Retrieve_All()
    End Sub
    Private Sub Initialize_Comboboxes()
        Initialize_Combobox_Websites()
        Initialize_Combo_Box_Email()
    End Sub
    Private Sub Initialize_Combo_Box_Email()
        cboEmail.Items.Clear()
        For Each key In mMessage
            If key.Value.Values.First().Campaign_Name IsNot Nothing Then cboEmail.Items.Add(key.Value.Values.First().Campaign_Name)
        Next
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
    Private Sub frmWorkStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
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
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Load_New_Email()
    End Sub
#End Region

#Region "Methods"
    Private Sub Retrieve_All()
        Retrieve_All_Messages()
    End Sub
    Private Sub Retrieve_All_Messages()
        mMessage = New SortedDictionary(Of Integer, SortedDictionary(Of String, Message))
        mMessage = mPersist_Message.Get_All_Messages()
    End Sub
    Private Sub Retrieve_All_Solicits()

    End Sub
    Private Sub Load_New_Email()
        Dim msg As New Message
        Dim frm As New frmVar(cboWebsite.SelectedItem.ToString)
        frm.ShowDialog()
        Retrieve_All()
        Initialize_Comboboxes()
    End Sub
    Private Sub Map_Selected_Email()
        For Each keyval In mMessage
            If keyval.Value.Values.First.Campaign_Name = cboEmail.SelectedItem Then
                txtBoxSubject.Text = keyval.Value.Values.First().Original_Subject.Original
                mSelected_Message = keyval.Value.Values.First()
                txtBoxBody.Text = keyval.Value.Values.First().Original.Body_Text
                Exit Sub
            End If
        Next
    End Sub
    Private Sub Map_Job_Email()
        Map_Selected_Email()
        Map_Selected_Job()
    End Sub
    Private Sub Edit_Email()
        If mSelected_Message.ID <> "-1" Then
            Dim frm = New frmVar(mSelected_Message)
            frm.ShowDialog()
        Else
            MessageBox.Show("There are no selected email")
        End If
    End Sub
    Private Sub Map_Selected_Job()
        Dim job As SortedDictionary(Of Integer, Job_Solicitation)
        job = mJob(cboSnippet.SelectedIndex)
        mSelected_Job = job.Values.First()
    End Sub
    Private Sub Launch_Campaign()
        Dim JOB As New Job_Curation
        Dim message As New Message
        Dim frm = New frmCAmpaign(message, JOB)
        frm.ShowDialog()
        Retrieve_All()
        Initialize_Combo_Box_Email()
    End Sub
    Private Sub Load_JOB_Message()
        Dim success As Boolean
        Dim selectedPath
        Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        selectedPath = frm.FullFileRef()
        Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Solicitation_Message_Combo)(selectedPath, mJOB_Message, success)
        If mJOB_Message IsNot Nothing Then Map_Job_Email()
    End Sub
    Private Sub Save_Form()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        Dim selectedPath = frm.FullFileRef()
        Dim success As Boolean
        Dim cmb As New Solicitation_Message_Combo
        Dim msg As SortedDictionary(Of String, Message)
        msg = mMessage(cboEmail.SelectedIndex)
        Dim job As SortedDictionary(Of Integer, Job_Solicitation)
        job = mJob(cboSnippet.SelectedIndex)
        With cmb
            .Message = msg.Values.First
            .Solicit = job.Values.First
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