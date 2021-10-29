Imports Content.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Adapters
Imports Content.Solicitation.Controllers
Public Class frmVar
#Region "Members"

    Public mMessage_Job As Message_Job

    Private mController_Message As Controller_Message
    Private mRandom As New System.Random
    Private selectedPath As String
    Private mLoading As Boolean
    Private mEdit As Boolean
    Private mWebsite As Websites
#End Region

#Region "Initialization"
    Public Sub New(ByVal website As Websites)
        mWebsite = website
        InitializeComponent()
        mController_Message = New Controller_Message
        mEdit = False
    End Sub
    Public Sub New(ByRef message_Job As Message_Job)
        InitializeComponent()
        mController_Message = New Controller_Message
        mMessage_Job = message_Job
        mEdit = True
        Map_Loaded()
    End Sub
    Private Sub Initialize_Message()
        mMessage_Job.Message = New Message(txtOriginal_Subject.Text, txtOriginal_Body.Text)
        mMessage_Job.Message.ID = Guid.NewGuid.ToString
        mMessage_Job.Message.Campaign_Name = txtBoxCampaignName.Text
        mMessage_Job.Message.Date_Created = Date.Now
        mMessage_Job.Message.Website = mWebsite
        If mEdit = False Then mMessage_Job.Message.Date_Modified = Date.Now
    End Sub
#End Region

#Region "Form Events"
    Private Sub AnalyzeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalyzeToolStripMenuItem.Click
        Analyze_Message()
    End Sub
    Private Sub btnSentence_Substitute_Click(sender As Object, e As EventArgs) Handles btnSentence_Substitute.Click
        Change_Variation_Body()
    End Sub
    Private Sub MORPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MORPHToolStripMenuItem.Click
        Load_Next_Message_Version()
    End Sub
    Private Sub cboSentence_Number_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSentence_Number.SelectedIndexChanged
        Sentence_Change()
    End Sub
    Private Sub mnuItmWip_Load_Click(sender As Object, e As EventArgs) Handles mnuItmWip_Load.Click
        Load_Message(False)
    End Sub
    Private Sub mnuItmWIP_Save_Click(sender As Object, e As EventArgs) Handles mnuItmWIP_Save.Click
        Save_Message()
    End Sub
    Private Sub cboSentence_Variation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSentence_Variation.SelectedIndexChanged
        Select_Sentence()
    End Sub
    Private Sub cboSubjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubjects.SelectedIndexChanged
        Changed_Subject_Variation()
    End Sub
    Private Sub txtOriginal_Body_TextChanged(sender As Object, e As EventArgs) Handles txtOriginal_Body.TextChanged
        txtOriginal_Body.ScrollBars = ScrollBars.Both
    End Sub
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Push_Message()
    End Sub
    Private Sub txtVersion_TextChanged(sender As Object, e As EventArgs) Handles txtVersion.TextChanged
        txtVersion.ScrollBars = ScrollBars.Both
    End Sub
    Private Sub btnSubjectSubstitute_Click(sender As Object, e As EventArgs) Handles btnSubjectSubstitute.Click
        Change_Variation_Subject()
    End Sub
    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Load_Font()
    End Sub
    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Show_Txt_Editor()
    End Sub
    Private Sub btnResetBold_Click(sender As Object, e As EventArgs) Handles btnResetBold.Click
        Reset_Bold_Words()
    End Sub
    Private Sub btnAdd_Bold_Click(sender As Object, e As EventArgs) Handles btnAdd_Bold.Click
        Add_Bold_Word()
    End Sub
    Private Sub txtBoxBold_TextChanged(sender As Object, e As EventArgs) Handles txtBoxBold.TextChanged
        txtBoxBold.ScrollBars = ScrollBars.Both
    End Sub
    Private Sub txtboxUnderlined_TextChanged(sender As Object, e As EventArgs) Handles txtboxUnderlined.TextChanged
        txtboxUnderlined.ScrollBars = ScrollBars.Both
    End Sub
    Private Sub btnResetUnderlined_Click(sender As Object, e As EventArgs) Handles btnResetUnderlined.Click
        Reset_Undelined_Words()
    End Sub
    Private Sub btnAddUnderlimed_Click(sender As Object, e As EventArgs) Handles btnAddUnderlimed.Click
        Add_Underline_Words()
    End Sub

#End Region

#Region "Methods"
    Private Sub Reset_Undelined_Words()

        mMessage_Job.Message.Email.Underlined_Words = New List(Of String)
        txtboxUnderlined.Text = ""
        txtBoxSingleUnderline.Text = ""
    End Sub
    Private Sub Add_Underline_Words()
        If txtBoxSingleUnderline.Text <> "" Then
            mMessage_Job.Message.Email.Underlined_Words.Add(txtBoxSingleUnderline.Text.Trim)
            If txtboxUnderlined.Text = "" Then
                txtboxUnderlined.Text = txtBoxSingleUnderline.Text & vbNewLine
            Else
                txtboxUnderlined.Text = txtboxUnderlined.Text & vbNewLine & txtBoxSingleUnderline.Text
            End If
        End If
        txtBoxSingleUnderline.Text = ""
    End Sub
    Private Sub Reset_Bold_Words()
        mMessage_Job.Message.Email.Bold_Words = New List(Of String)
        txtBoxBold.Text = ""
        txtboxSingleBold.Text = ""
    End Sub
    Private Sub Add_Bold_Word()
        If txtboxSingleBold.Text <> "" Then
            mMessage_Job.Message.Email.Bold_Words.Add(txtboxSingleBold.Text.Trim)
            If txtBoxBold.Text = "" Then
                txtBoxBold.Text = txtboxSingleBold.Text & vbNewLine
            Else
                txtBoxBold.Text = txtBoxBold.Text & vbNewLine & txtboxSingleBold.Text

            End If
        End If
        txtboxSingleBold.Text = ""
    End Sub

    Private Sub Show_Txt_Editor()
        If txtVersion.Text <> "" Then
            Dim frm As New frmTxtEditor
            frm.Message_Job = mMessage_Job
            frm.ShowDialog()

            mMessage_Job.Message.Email = frm.Message_Job.Message.Email
        Else
            MessageBox.Show("body message is  still empty")
        End If
    End Sub
    Private Sub Push_Message()
        If mEdit Then mMessage_Job.Message.Date_Modified = Date.Now : mController_Message.Update_One_Message(mMessage_Job.Message) : Exit Sub
        If mMessage_Job.Message IsNot Nothing Then
            mController_Message.Save_One_Message(mMessage_Job.Message)
            Me.Close()
        Else
            MessageBox.Show("There are no analyze messages")
            Exit Sub
        End If
    End Sub
    Private Sub Analyze_Message()
        Initialize_Message()
        If txtBoxCampaignName.Text = "" Then MessageBox.Show("Campaign name is empty")
        Try
            Dim s As New Scraper_QB
            Dim variants As Integer
            variants = Integer.Parse(txtBoxVariation.Text)
            If txtOriginal_Body.Text.Length < 5 Then MessageBox.Show("Body message is empty") : Exit Sub
            If txtOriginal_Subject.Text = "" Then MessageBox.Show("Subject cannot be empty") : Exit Sub
            s.Scrape(mMessage_Job.Message, variants)
            Save_Message()
        Catch ex As Exception
            MessageBox.Show("Variations must be inputed as an integer")
        End Try
    End Sub
    Private Sub Save_Message()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        selectedPath = frm.FullFileRef()
        Dim success As Boolean
        Serialization_Utilities.Serialize_Object_And_Save_FileSystem(mMessage_Job.Message, selectedPath, success)
    End Sub
    Private Sub Load_Next_Message_Version()
        Try
            If mMessage_Job.Message IsNot Nothing Then
                mLoading = True
                Load_Message(True)
                Load_Controls_Subject()
                mMessage_Job.Message.ID = txtBoxCampaignName.Text
                mMessage_Job.Message.Varied = Build_Version()
                Dim bodyText As String
                bodyText = mMessage_Job.Message.Varied.Body_Text
                txtVersion.Text = bodyText
                Check_Message(bodyText)
                mLoading = False
                cboSentence_Number.Items.Clear()
                For i = 0 To mMessage_Job.Message.Sentences.Count - 1
                    cboSentence_Number.Items.Add(i.ToString())
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function Build_Version() As Version
        Dim vers As New Version()
        With mMessage_Job.Message
            Dim permutation As New SortedDictionary(Of Integer, Integer)
            permutation = Select_Random_Permutation()
            vers = Version.Build_Version(.Sentences, permutation)
        End With
        Return vers
    End Function
    Private Function Select_Random_Permutation() As SortedDictionary(Of Integer, Integer)
        Dim permutation As New SortedDictionary(Of Integer, Integer) 'line number, variation chosen
        With mMessage_Job.Message
            For i = 1 To .Sentences.Count - 1
                Dim sentnce As Sentence = .Sentences(i)
                If sentnce.Variations.Count > 0 Then
                    Dim which As Integer = mRandom.Next(0, sentnce.Variations.Count)
                    permutation.Add(i, which)
                End If
            Next
        End With
        Return permutation
    End Function
    Private Sub Load_Message(ByVal morph As Boolean)
        Dim success As Boolean
        If Not morph Then
            Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
            frm.ShowDialog()
            selectedPath = frm.FullFileRef()
        End If
        Try
            If mMessage_Job.Message Is Nothing Then
                Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message)(selectedPath, mMessage_Job.Message, success)
                If mMessage_Job.Message IsNot Nothing Then
                    txtSubject_Variations.Text = mMessage_Job.Message.Sentences(0).Variations(3)
                    Map_Loaded()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub Check_Message(ByVal content As String)
        Dim sb As New System.Text.StringBuilder
        For Each word In Version.Check_For_Spam_Phrases(content)
            sb.AppendLine(word)
        Next
        'txtSpam.Text = sb.ToString
    End Sub
    Private Sub Map_Loaded()
        txtOriginal_Subject.Text = mMessage_Job.Message.Original_Subject.Original
        txtOriginal_Body.Text = mMessage_Job.Message.Original.Body_Text
        txtSubject_Variations.Text = mMessage_Job.Message.Sentences(0).Variations(3)
        mMessage_Job.Message.Varied = Build_Version()
        txtBoxCampaignName.Text = mMessage_Job.Message.Campaign_Name
        If mMessage_Job.Message.Email IsNot Nothing Then txtboxUnderlined.Text = MapWords(mMessage_Job.Message.Email.Underlined_Words)
        If mMessage_Job.Message.Email IsNot Nothing Then txtBoxBold.Text = MapWords(mMessage_Job.Message.Email.Bold_Words)
        If mMessage_Job.Message.Sentences.Count > 1 Then txtBoxVariation.Text = mMessage_Job.Message.Sentences(1).Variations.Count - 1.ToString
        txtVersion.Text = mMessage_Job.Message.Varied.Body_Text
    End Sub
    Private Sub Change_Variation_Body()
        If cboSentence_Number.SelectedIndex > 0 And cboSentence_Variation.SelectedIndex > 0 Then
            Dim senteceIndex As Integer = cboSentence_Number.SelectedIndex
            Dim variationIndex As Integer = cboSentence_Variation.SelectedIndex
            If variationIndex = -1 Then mMessage_Job.Message.Sentences(senteceIndex).Variations(0) = txtBoxNewSentence.Text Else mMessage_Job.Message.Sentences(senteceIndex).Variations(variationIndex) = txtBoxNewSentence.Text
        End If
    End Sub
    Private Sub Change_Variation_Subject()
        If cboSubjects.SelectedIndex > 0 Then
            mMessage_Job.Message.Sentences(0).Variations(cboSubjects.SelectedIndex) = txtSubject_Variations.Text
        End If
    End Sub
    Private Sub Load_Controls_Subject()
        Try
            cboSubjects.Items.Clear()
            Dim seen As New SortedDictionary(Of Integer, String)
            For Each entry In mMessage_Job.Message.Sentences(0).Variations

                Dim number = entry.Key
                Dim text = entry.Value

                If Not seen.ContainsValue(text.Trim(" ")) Then
                    seen.Add(number, text)
                    cboSubjects.Items.Add(number)
                End If

            Next

            cboSubjects.SelectedItem = cboSubjects.Items(0)
            cboSubjects.Tag = seen

            txtSubject_Variations.Text = seen(0)
            txtSubject_Variations.Tag = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Sentence_Change()
        Select_Variation()
        Select_Sentence_Default()
    End Sub
    Private Sub Select_Variation()
        cboSentence_Variation.Items.Clear()
        For j = 0 To mMessage_Job.Message.Sentences(cboSentence_Number.SelectedIndex).Variations.Count - 1
            cboSentence_Variation.Items.Add(j.ToString())
        Next
    End Sub
    Private Sub Select_Sentence_Default()
        txtBoxNewSentence.Text = mMessage_Job.Message.Sentences(cboSentence_Number.SelectedIndex).Variations(0)
    End Sub
    Private Sub Select_Sentence()
        txtBoxNewSentence.Text = mMessage_Job.Message.Sentences(cboSentence_Number.SelectedIndex).Variations(cboSentence_Variation.SelectedIndex)
    End Sub
    Private Sub Changed_Subject_Variation()
        If mLoading Then Exit Sub
        If cboSubjects.SelectedItem Is Nothing Then txtSubject_Variations.Text = String.Empty : Exit Sub
        Dim index As Integer = cboSubjects.SelectedItem
        Dim subjectText As String = cboSubjects.Tag(index)
        txtSubject_Variations.Text = subjectText
        txtSubject_Variations.Tag = index
    End Sub
    Private Sub Load_Font()
        Dim frm As New frmFont
        frm.ShowDialog()
    End Sub

    Private Function MapWords(ByVal words As List(Of String)) As String
        Dim result As String = ""
        For Each word In words
            result = result & word & vbNewLine
        Next
        Return result
    End Function
#End Region

End Class
