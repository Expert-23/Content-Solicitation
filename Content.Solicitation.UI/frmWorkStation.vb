
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
    Private mMessage_Job As Message_Job
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
        mMessage_Job = New Message_Job
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

        mMessage_Job.Message = cboEmail.SelectedItem
        txtBoxSubject.Text = mMessage_Job.Message.Original.Subject.Original
        txtBoxBody.Text = mMessage_Job.Message.Original.Body_Text
    End Sub

    Private Sub Edit_Email()
        If mMessage_Job.Message.ID <> "-1" Then
            Dim frm = New frmVar(mMessage_Job)
            frm.ShowDialog()
        Else
            MessageBox.Show("There are no selected email")
        End If
    End Sub
    Private Sub Map_Selected_Job()
        If cboSnippet.SelectedItem Is Nothing Then Exit Sub
        mMessage_Job.Job = cboSnippet.SelectedItem
        Try
            PictureBox1.Image = mMessage_Job.Job.Snippet
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Launch_Campaign()
        Dim file As String = "C:\Users\pc\source\repos\Expert-23\Content-Solicitation\z-cache\bitmap\" & Guid.NewGuid.ToString & ".png"

        Using bm As New Bitmap(mMessage_Job.Job.Snippet)
            bm.Save(file)
            bm.Dispose()
        End Using
        mMessage_Job.Job.Snippet_File_Path = file
        If mMessage_Job.Message.Campaign_Name Is Nothing Or mMessage_Job.Job.Snippet Is Nothing Then
            MessageBox.Show("Select A Solicit and An Email To Continue")
        Else
            Dim frm = New frmCAmpaign(mMessage_Job)
            frm.ShowDialog()
        End If
    End Sub
    Private Sub Load_JOB_Message()
        Dim success As Boolean
        Dim selectedPath
        Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        selectedPath = frm.FullFileRef()
        Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message_Job)(selectedPath, mMessage_Job, success)
        If mMessage_Job IsNot Nothing Then Map_Loaded(mMessage_Job)
    End Sub
    Private Sub Map_Loaded(ByVal jOb_Message As Message_Job)
        Initialize_Combobox_Websites()
        cboWebsite.SelectedItem = jOb_Message.Website
        Initialize_Combo_Box_Email()
        Initialize_Combo_Box_Solicit()
        Retrieve_Messages()
        Retrieve_Solicits()
        mMessage_Job.Job.Snippet = mPersist_Job.To_Bitmap_From_Bytes_Array(jOb_Message.Image_Bytes)
        PictureBox1.Image = mMessage_Job.Job.Snippet
        cboEmail.SelectedIndex = cboEmail.FindStringExact(mMessage_Job.Message.ToString)
        cboSnippet.SelectedIndex = cboSnippet.FindStringExact(mMessage_Job.Job.ToString)
        txtBoxBody.Text = jOb_Message.Message.Original.Body_Text
        txtBoxSubject.Text = jOb_Message.Message.Original_Subject.Original
    End Sub
    Private Sub Save_Form()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        Dim selectedPath = frm.FullFileRef()
        Dim success As Boolean
        mMessage_Job.Image_Bytes = mPersist_Job.To_Bytes_Array_From_BitMap(mMessage_Job.Job.Snippet)
        mMessage_Job.Website = cboWebsite.SelectedItem
        Serialization_Utilities.Serialize_Object_And_Save_FileSystem(mMessage_Job, selectedPath, success)
    End Sub
    Private Sub Load_Form()
        Dim cmb As New Message_Job
        Dim success As Boolean
        Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        Dim selectedPath = frm.FullFileRef()
        Try
            Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message_Job)(selectedPath, cmb, success)
            mSelected_Job = cmb.Job
            mMessage_Job.Message = cmb.Message
            txtBoxBody.Text = mMessage_Job.Message.Original.Body_Text
            txtBoxSubject.Text = mMessage_Job.Message.Original_Subject.Original
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub View_Snippet()
        If mMessage_Job.Job Is Nothing Then MessageBox.Show("No selected Job")
        If mMessage_Job.Job.Snippet IsNot Nothing Then Dim frmSol As New frmSolicit(mMessage_Job.Job.Snippet) : frmSol.ShowDialog()
    End Sub


#End Region
End Class