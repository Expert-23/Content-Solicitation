Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Adapters
Imports Loggingg

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
    Private Sub Load_Next_Message_Version()
        Try
            mLoading = True
            Load_Message(True)
            Load_Controls_Subject()
            mMessage.ID = Guid.NewGuid.ToString
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
        Catch ex As NullReferenceException
            MasterLog.MasterLogs().Error(ex, "Object with null reference")
        Catch ex As Exception
            MasterLog.MasterLogs().Error(ex, "")
        End Try
    End Sub
    Private Function Build_Version() As Version
        Dim vers As New Version()
        With mMessage
            Dim permutation As New SortedDictionary(Of Integer, Integer)
            permutation = Select_Random_Permutation()
            vers = Version.Build_Version(.Sentences, permutation)
        End With
        Return vers
    End Function
    Private Function Select_Random_Permutation() As SortedDictionary(Of Integer, Integer)
        Try
            Dim permutation As New SortedDictionary(Of Integer, Integer) 'line number, variation chosen
            With mMessage
                For i = 1 To .Sentences.Count - 1
                    Dim sentnce As Sentence = .Sentences(i)
                    If sentnce.Variations.Count > 0 Then
                        Dim which As Integer = mRandom.Next(0, sentnce.Variations.Count)
                        permutation.Add(i, which)
                    End If
                Next
            End With
            Return permutation
        Catch ex As NullReferenceException
            MasterLog.MasterLogs().Error(ex, "Object with null reference")
        Catch ex As Exception
            MasterLog.MasterLogs().Error(ex, "")
        End Try
    End Function
    Private Sub Load_Message(ByVal morph As Boolean)
        Dim success As Boolean
        If Not morph Then
            Dim frm As frmFileSystem = New frmFileSystem("", "C:\Users\pc\source\repos\Expert-23\Content\G23.Content.Complete\z_cache\wip\")
            frm.ShowDialog()
            selectedPath = frm.FullFileRef()
        End If
        Try
            If mMessage Is Nothing Then Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message)(selectedPath, mMessage, success) : txtSubject_Variations.Text = mMessage.Sentences(0).Variations(3) : Exit Sub
        Catch ex As NullReferenceException
            MasterLog.MasterLogs().Error(ex, "Object with null reference")
        Catch ex As Exception
            MasterLog.MasterLogs().Error(ex, "")
        End Try
        txtSubject_Variations.Text = mMessage.Sentences(0).Variations(3)
    End Sub
    Private Sub Check_Message(ByVal content As String)
        Try
            Dim sb As New System.Text.StringBuilder
            For Each word In Version.Check_For_Spam_Phrases(content)
                sb.AppendLine(word)
            Next
            'txtSpam.Text = sb.ToString
        Catch ex As NullReferenceException
            MasterLog.MasterLogs().Error(ex, "Object with null reference")
        Catch ex As Exception
            MasterLog.MasterLogs().Error(ex, "")
        End Try
    End Sub
    Private Sub Change_Variation()
        Try
            Dim senteceIndex As Integer = cboSentence_Number.SelectedIndex
            Dim variationIndex As Integer = cboSentence_Variation.SelectedIndex
            If variationIndex = -1 Then mMessage.Sentences(senteceIndex).Variations(0) = txtBoxNewSentence.Text Else mMessage.Sentences(senteceIndex).Variations(variationIndex) = txtBoxNewSentence.Text
        Catch ex As NullReferenceException
            MasterLog.MasterLogs().Error(ex, "Object with null reference")
        Catch ex As Exception
            MasterLog.MasterLogs().Error(ex, "")
        End Try
    End Sub
    Private Sub Load_Controls_Subject()
        Try
            cboSubjects.Items.Clear()
            Dim seen As New SortedDictionary(Of Integer, String)
            For Each entry In mMessage.Sentences(0).Variations

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
        Catch ex As NullReferenceException
            MasterLog.MasterLogs().Error(ex, "Object with null reference")
        Catch ex As IndexOutOfRangeException
            MasterLog.MasterLogs().Error(ex, "Index out of range")
        Catch ex As Exception
            MasterLog.MasterLogs().Error(ex, "")
        End Try
    End Sub
    Private Sub Sentence_Change()
        Select_Variation()
        Select_Sentence_Default()
    End Sub
    Private Sub Select_Variation()
        cboSentence_Variation.Items.Clear()
        For j = 0 To mMessage.Sentences(cboSentence_Number.SelectedIndex).Variations.Count - 1
            cboSentence_Variation.Items.Add(j.ToString())
        Next
    End Sub
    Private Sub Select_Sentence_Default()
        txtBoxNewSentence.Text = mMessage.Sentences(cboSentence_Number.SelectedIndex).Variations(0)
    End Sub
    Private Sub Select_Sentence()
        txtBoxNewSentence.Text = mMessage.Sentences(cboSentence_Number.SelectedIndex).Variations(cboSentence_Variation.SelectedIndex)
    End Sub
    Private Sub Changed_Subject_Variation()
        Try
            If mLoading Then Exit Sub
            If cboSubjects.SelectedItem Is Nothing Then txtSubject_Variations.Text = String.Empty : Exit Sub
            Dim index As Integer = cboSubjects.SelectedItem
            Dim subjectText As String = cboSubjects.Tag(index)
            txtSubject_Variations.Text = subjectText
            txtSubject_Variations.Tag = index
        Catch ex As NullReferenceException
            MasterLog.MasterLogs().Error(ex, "Object with null reference")
        Catch ex As Exception
            MasterLog.MasterLogs().Error(ex, "")
        End Try
    End Sub
#End Region
End Class
