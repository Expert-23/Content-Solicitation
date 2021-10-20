Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Adapters
Public Class frmVar
#Region "Members"
    Private mMessage As Message
    Private mJob As Job_Curation

    Private mRandom As New System.Random
    Private selectedPath As String
    Private mLoading As Boolean
#End Region
#Region "Initialization"
    Public Sub New(ByVal job As Job_Curation)
        InitializeComponent()
        Initialize_Form(job)
    End Sub
    Private Sub Initialize_Form(ByVal job As Job_Curation)
        mJob = job
    End Sub
#End Region
#Region "Form Events"
    Private Sub frmVar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize_Form(mJob)
    End Sub

    Private Sub AnalyzeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalyzeToolStripMenuItem.Click
        Analyze_Message()
    End Sub
#End Region
#Region "Methods"
    Private Sub Analyze_Message()
        Initialize_Message()
        Dim s As New Scraper_QB
        Dim variants As Integer = 3
        s.Scrape(mMessage.Sentences, variants)
        Save_Message()
    End Sub
    Private Sub Initialize_Message()
        mMessage = New Message(txtOriginal_Subject.Text, txtOriginal_Body.Text)
    End Sub
    Private Sub Save_Message()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        selectedPath = frm.FullFileRef()
        Dim success As Boolean
        Serialization_Utilities.Serialize_Object_And_Save_FileSystem(mMessage, selectedPath, success)
    End Sub

    Private Sub MORPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MORPHToolStripMenuItem.Click
        Load_Next_Message_Version
    End Sub
    Private Sub Load_Next_Message_Version()

        Try
            mLoading = True

            Load_Message(True)
            Load_Controls_Subject()

            mMessage.ID = mnuItmCampaign_Name.Text
            mMessage.Varied = Build_Version()

            Dim bodyText As String
            bodyText = mMessage.Varied.Body_Text

            txtVersion.Text = bodyText
            Check_Message(bodyText)

            mLoading = False

            cboSentence_Number.Items.Clear()
            For i = 0 To mMessage.Sentences.Count - 1
                cboSentence_Number.Items.Add(i.ToString())
            Next
        Catch ex As Exception

        End Try




    End Sub
#End Region







End Class
