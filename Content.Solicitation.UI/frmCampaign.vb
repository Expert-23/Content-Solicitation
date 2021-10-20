Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Controllers
Public Class frmCAmpaign

    Private mControllerScraper As Controller_Scraper
    Private mMessage As Message
    Private mJob As Job_Curation
    Private mZone As SortedDictionary(Of Time_Zone, Boolean)
    Private mSending As SortedDictionary(Of Stop_Sending_Lead, Boolean)
    Private mTracking As SortedDictionary(Of Tracking, Boolean)
    Private mLemlist As New Lemlist
    Public Sub New(message As Message, Job As Job_Curation)
        Initialize(message, Job)
    End Sub
    Private Sub Initialize(message As Message, Job As Job_Curation)
        InitializeComponent()
        mMessage = message
        mJob = Job
        mSending = New SortedDictionary(Of Stop_Sending_Lead, Boolean)
        mTracking = New SortedDictionary(Of Tracking, Boolean)
        mZone = New SortedDictionary(Of Time_Zone, Boolean)
        mLemlist = New Lemlist
        mControllerScraper = New Controller_Scraper
    End Sub

    Private Sub LoadCampaignToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LoadCampaignToolStripMenuItem.Click
        Map_Zones()
        Map_Sending()
        Map_Tracking()
        Map_Lemlist()
        Dim a = Integer.Parse(mLemlist.Time_Zone)
        mLemlist.Message = mMessage
        mControllerScraper.Launch_Campaign(mLemlist, mJob)
    End Sub
    Private Sub Map_Lemlist()
        mLemlist.Campaign_Name = txtBox_Campaign_Name.Text
        mLemlist.Labels.Add(txtBox_Label.Text)
        For Each zone In mZone
            If zone.Value = True Then
                mLemlist.Time_Zone = zone.Key
                Exit For
            End If
        Next
        mLemlist.Stop_sending = mSending
        mLemlist.Tracking = mTracking
        mLemlist.User_Name = "qcontinuum@mail.com"
        mLemlist.Password = "send2021!Email"
    End Sub
    Private Sub Map_Zones()
        mZone = New SortedDictionary(Of Time_Zone, Boolean)
        mZone.Add(Time_Zone.local, rdBtn_Local.Checked)
        mZone.Add(Time_Zone.newyork, rdBtn_NewYork.Checked)
        mZone.Add(Time_Zone.paris, rdBtn_Paris.Checked)
        mZone.Add(Time_Zone.san_francisco, rdBtn_Sanfracisco.Checked)
        mZone.Add(Time_Zone.san_francisco_night, rdBtn_SanFrancisco_Night.Checked)
    End Sub
    Private Sub Map_Sending()
        mSending = New SortedDictionary(Of Stop_Sending_Lead, Boolean)
        mSending.Add(Stop_Sending_Lead.replies_to_message, ChkBox_Reply.Checked)
        mSending.Add(Stop_Sending_Lead.opens_email, checkBox_Open.Checked)
        mSending.Add(Stop_Sending_Lead.clicks_on_link, checkBox_Click.Checked)
    End Sub
    Private Sub Map_Tracking()
        mTracking = New SortedDictionary(Of Tracking, Boolean)
        mTracking.Add(Tracking.email_opens, chck_Track_Email.Checked)
        mTracking.Add(Tracking.link_clicks, chck_Track_Link.Checked)
        mTracking.Add(Tracking.reply_body, chck_Track_reply.Checked)
    End Sub
    Private Sub btnFile_Upload_Click(sender As Object, e As EventArgs) Handles btnFile_Upload.Click
        Dim openFileDialog1 As New OpenFileDialog
        Dim result As DialogResult = openFileDialog1.ShowDialog()
        Dim file = openFileDialog1.FileName
        mLemlist.CSV_File = file
        file = file.Substring(file.LastIndexOf("\") + 1)
        lblFile.Text = file
        File_Size()
    End Sub
    Private Sub File_Size()
        Dim file As String = My.Computer.FileSystem.ReadAllText(mLemlist.CSV_File)
        Dim lines As String() = file.Split(vbNewLine)
        mLemlist.NB_Rows = lines.Count
        MessageBox.Show(mLemlist.NB_Rows)
    End Sub
End Class