Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Adapters
Imports Content.Solicitation.Controllers
Public Class frmVar

#Region "Members"
    Public Message_ As Message
    Private mJob As Job_Curation
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
    Public Sub New(ByVal message As Message)
        InitializeComponent()
        mController_Message = New Controller_Message
        Message_ = message
        mEdit = True
        Map_Loaded()
    End Sub
    Private Sub Initialize_Message()
        Message_ = New Message(txtOriginal_Subject.Text, txtOriginal_Body.Text)
        Message_.ID = Guid.NewGuid.ToString
        Message_.Campaign_Name = txtBoxCampaignName.Text
        Message_.Date_Created = Date.Now
        Message_.Website = mWebsite
        If mEdit = False Then Message_.Date_Modified = Date.Now
    End Sub
#End Region

#Region "Form Events"
    Private Sub AnalyzeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalyzeToolStripMenuItem.Click
        Analyze_Message()
    End Sub
    Private Sub btnSentence_Substitute_Click(sender As Object, e As EventArgs) Handles btnSentence_Substitute.Click
        Change_Variation()
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
#End Region

#Region "Methods"
    Private Sub Push_Message()
        If mEdit Then Message_.Date_Modified = Date.Now : mController_Message.Update_One_Message(Message_) : Exit Sub
        If Message_ IsNot Nothing Then mController_Message.Save_One_Message(Message_) Else MessageBox.Show("There are no analyze messages") : Exit Sub
    End Sub
    Private Sub Analyze_Message()
        Initialize_Message()
        Dim s As New Scraper_QB
        Dim variants As Integer
        Try
            variants = Integer.Parse(txtBoxVariation.Text)
        Catch ex As Exception
            MessageBox.Show("Variations must be inputed as an integer")
        End Try
        s.Scrape(Message_, variants)
        Save_Message()
    End Sub

    Private Sub Save_Message()
        Dim frm As New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
        frm.ShowDialog()
        selectedPath = frm.FullFileRef()
        Dim success As Boolean
        Serialization_Utilities.Serialize_Object_And_Save_FileSystem(Message_, selectedPath, success)
    End Sub
    Private Sub Load_Next_Message_Version()
        Try
            If Message_ IsNot Nothing Then
                mLoading = True
                Load_Message(True)
                Load_Controls_Subject()
                Message_.ID = txtBoxCampaignName.Text
                Message_.Varied = Build_Version()
                Dim bodyText As String
                bodyText = Message_.Varied.Body_Text
                txtVersion.Text = bodyText
                Check_Message(bodyText)
                mLoading = False
                cboSentence_Number.Items.Clear()
                For i = 0 To Message_.Sentences.Count - 1
                    cboSentence_Number.Items.Add(i.ToString())
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function Build_Version() As Version
        Dim vers As New Version()
        With Message_
            Dim permutation As New SortedDictionary(Of Integer, Integer)
            permutation = Select_Random_Permutation()
            vers = Version.Build_Version(.Sentences, permutation)
        End With
        Return vers
    End Function
    Private Function Select_Random_Permutation() As SortedDictionary(Of Integer, Integer)
        Dim permutation As New SortedDictionary(Of Integer, Integer) 'line number, variation chosen
        With Message_
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
            If Message_ Is Nothing Then
                Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message)(selectedPath, Message_, success)
                If Message_ IsNot Nothing Then
                    txtSubject_Variations.Text = Message_.Sentences(0).Variations(3)
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
        txtOriginal_Subject.Text = Message_.Original_Subject.Original
        txtOriginal_Body.Text = Message_.Original.Body_Text
        txtSubject_Variations.Text = Message_.Sentences(0).Variations(3)
        Message_.Varied = Build_Version()
        txtBoxCampaignName.Text = Message_.Campaign_Name
        txtVersion.Text = Message_.Varied.Body_Text
    End Sub
    Private Sub Change_Variation()
        If cboSentence_Number.SelectedIndex > 0 And cboSentence_Variation.SelectedIndex > 0 Then
            Dim senteceIndex As Integer = cboSentence_Number.SelectedIndex
            Dim variationIndex As Integer = cboSentence_Variation.SelectedIndex
            If variationIndex = -1 Then Message_.Sentences(senteceIndex).Variations(0) = txtBoxNewSentence.Text Else Message_.Sentences(senteceIndex).Variations(variationIndex) = txtBoxNewSentence.Text
        End If

    End Sub
    Private Sub Load_Controls_Subject()
        Try
            cboSubjects.Items.Clear()
            Dim seen As New SortedDictionary(Of Integer, String)
            For Each entry In Message_.Sentences(0).Variations

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
        For j = 0 To Message_.Sentences(cboSentence_Number.SelectedIndex).Variations.Count - 1
            cboSentence_Variation.Items.Add(j.ToString())
        Next
    End Sub
    Private Sub Select_Sentence_Default()
        txtBoxNewSentence.Text = Message_.Sentences(cboSentence_Number.SelectedIndex).Variations(0)
    End Sub
    Private Sub Select_Sentence()
        txtBoxNewSentence.Text = Message_.Sentences(cboSentence_Number.SelectedIndex).Variations(cboSentence_Variation.SelectedIndex)
    End Sub
    Private Sub Changed_Subject_Variation()
        If mLoading Then Exit Sub
        If cboSubjects.SelectedItem Is Nothing Then txtSubject_Variations.Text = String.Empty : Exit Sub
        Dim index As Integer = cboSubjects.SelectedItem
        Dim subjectText As String = cboSubjects.Tag(index)
        txtSubject_Variations.Text = subjectText
        txtSubject_Variations.Tag = index
    End Sub
#End Region

End Class
