
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Controllers
Imports Content.Primitives
Imports Content.Solicitation.UI

Public Class frmWorkStation
#Region "Members"
    Private mMessage As SortedDictionary(Of String, Message)
    Private mJob As SortedDictionary(Of Integer, Job_Solicitation)
    Private mSelected_Message As Message
    Private mSelected_Job As Job_Solicitation
    Private mJOB_Message As Solicitation_Message_Combo
    Private mPersist_Message As Controller_Message
    Private mPersist_Job As Controller_Solicitation
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

        mMessage = New SortedDictionary(Of String, Message)
        mJob = New SortedDictionary(Of Integer, Job_Solicitation)
        mSelected_Message = New Message
        mSelected_Job = New Job_Solicitation
        mPersist_Message = New Controller_Message
        mPersist_Job = New Controller_Solicitation

    End Sub
    Private Sub Initialize_Comboboxes()
        Initialize_Combobox_Websites()
        Initialize_Combo_Box_Email()
        Initialize_Combo_Box_Solicit()
    End Sub
    Private Sub Initialize_Combo_Box_Email()
        cboEmail.Items.Clear()
        cboEmail.Text = ""
        For Each key In mMessage
            cboEmail.Items.Add(key.Value)
        Next
        cboEmail.SelectedIndex = mMessage.Count - 1
    End Sub
    Private Sub Initialize_Combo_Box_Solicit()
        cboSnippet.Items.Clear()
        cboEmail.Text = ""
        For Each key In mJob
            cboSnippet.Items.Add(key.Value)
        Next
        cboSnippet.SelectedIndex = mJob.Count - 1
    End Sub
    Private Sub Initialize_Combobox_Websites()
        cboWebsite.Items.Clear()
        With cboWebsite
            For Each item In System.Enum.GetValues(GetType(Websites))

                If item <> Websites.unspecified Then
                    .Items.Add(item)
                End If
            Next

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
    Private Sub cboWebsite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboWebsite.SelectedIndexChanged
        Retrieve_All()
    End Sub
    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem.Click
        Load_Reports()
    End Sub
    Private Sub SnippetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SnippetToolStripMenuItem.Click
        View_Snippet()
    End Sub
#End Region

#Region "Methods"
    Private Sub Load_Reports()
        Dim frm As frmReports = New frmReports
        frm.ShowDialog()
    End Sub
    Private Sub Retrieve_All()
        Retrieve_Messages()
        Retrieve_Solicits()
        Initialize_Combo_Box_Email()
        Initialize_Combo_Box_Solicit()
    End Sub
    Private Sub Retrieve_Messages()
        Dim website As Websites = DirectCast([Enum].Parse(GetType(Websites), cboWebsite.SelectedItem), Websites)
        mMessage = mPersist_Message.Get_One_Message_By_Website(website)
    End Sub
    Private Sub Retrieve_Solicits()
        Dim website = DirectCast([Enum].Parse(GetType(Websites), cboWebsite.SelectedItem), Websites)
        mJob = mPersist_Job.Get_All_Solicitations_By_Website(website, Content_Status.solicited_pushed)
    End Sub

    Private Sub Retrieve_All_Messages()
        mMessage = New SortedDictionary(Of String, Message)
        mMessage = mPersist_Message.Get_All_Messages()
    End Sub
    Private Sub Retrieve_All_Solicits()

    End Sub
    Private Sub Load_New_Email()
        If cboWebsite.SelectedItem IsNot Nothing Then
            Dim msg As New Message
            Dim webbsite = DirectCast([Enum].Parse(GetType(Websites), cboWebsite.SelectedItem), Websites)
            Dim frm As New frmVar(webbsite)
            frm.ShowDialog()
            Retrieve_Messages()
            Initialize_Combo_Box_Email()
        Else
            MessageBox.Show("You must Select a website")
        End If

    End Sub
    Private Sub Map_Selected_Email()

        mSelected_Message = cboEmail.SelectedItem
        txtBoxSubject.Text = mSelected_Message.Original.Subject.Original
        txtBoxBody.Text = mSelected_Message.Original.Body_Text
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
        If cboSnippet.SelectedItem Is Nothing Then Exit Sub
        mSelected_Job = cboSnippet.SelectedItem
        Try
            PictureBox1.Image = mSelected_Job.Snippet
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Launch_Campaign()
        Dim JOB As New Job_Curation
        Dim message As New Message
        If mSelected_Message.Campaign_Name Is Nothing Or mSelected_Job.Snippet Is Nothing Then
            MessageBox.Show("Select A Solicit and An Email To Continue")
        Else
            Dim frm = New frmCAmpaign(message, JOB)
            frm.ShowDialog()

        End If
    End Sub
    Private Sub Load_JOB_Message()
        Dim success As Boolean
        Dim selectedPath
        Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        selectedPath = frm.FullFileRef()
        Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Solicitation_Message_Combo)(selectedPath, mJOB_Message, success)
        If mJOB_Message IsNot Nothing Then Map_Loaded(mJOB_Message)
    End Sub
    Private Sub Map_Loaded(ByVal jOb_Message As Solicitation_Message_Combo)
        Initialize_Combobox_Websites()
        cboWebsite.SelectedItem = jOb_Message.Website
        Initialize_Combo_Box_Email()
        Initialize_Combo_Box_Solicit()
        Retrieve_Messages()
        Retrieve_Solicits()
        mSelected_Message = jOb_Message.Message
        mSelected_Job = jOb_Message.Solicit
        mSelected_Job.Snippet = mPersist_Job.To_Bitmap_From_Bytes_Array(jOb_Message.Image_Bytes)
        PictureBox1.Image = mSelected_Job.Snippet
        cboEmail.SelectedIndex = cboEmail.FindStringExact(mJOB_Message.Message.ToString)
        cboSnippet.SelectedIndex = cboSnippet.FindStringExact(mJOB_Message.Solicit.ToString)
        txtBoxBody.Text = jOb_Message.Message.Original.Body_Text
        txtBoxSubject.Text = jOb_Message.Message.Original_Subject.Original
    End Sub
    Private Sub Save_Form()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        Dim selectedPath = frm.FullFileRef()
        Dim success As Boolean
        Dim cmb As New Solicitation_Message_Combo
        With cmb
            .Message = mSelected_Message
            .Solicit = mSelected_Job
            .Image_Bytes = mPersist_Job.To_Bytes_Array_From_BitMap(mSelected_Job.Snippet)
            .Website = cboWebsite.SelectedItem
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
    Private Sub View_Snippet()
        If mSelected_Job Is Nothing Then MessageBox.Show("No selected Job")
        If mSelected_Job.Snippet IsNot Nothing Then Dim frmSol As New frmSolicit(mSelected_Job.Snippet) : frmSol.ShowDialog()
    End Sub
#End Region
End Class