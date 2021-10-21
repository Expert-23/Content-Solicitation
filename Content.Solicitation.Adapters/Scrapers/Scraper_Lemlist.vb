Imports System.Threading
Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Localize
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports Loggingg

Public Class Scraper_Lemlist
    Private mDriver As IWebDriver
    Private mDirChrome As String
    Private mUrl_Base As String
    Private mdirVPN As String
    Private mLemlist As Lemlist
    Private mJob As Job_Curation
    Private mRandom As New System.Random

    Public Sub New(ByVal dt2 As Lemlist, Job As Job_Curation)
        Initialize(dt2, Job)
    End Sub
    Private Sub Initialize(ByVal dt2 As Lemlist, Job As Job_Curation)
        mJob = Job
        mLemlist = dt2
        mDirChrome = "C:\Users\pc\Desktop\Software and Files\Expert 23\Google_For_Selenium_78.0.3904.7000\Chrome\Application\chrome.exe"
        mUrl_Base = "https://app.lemlist.com/campaigns/"
        mdirVPN = "C:\Users\pc\Desktop\Software and Files\Expert 23\Google_For_Selenium_78.0.3904.7000\Chrome\Application\2.0.0_0.crx"
    End Sub
    Public Sub Scrape()
        Initialise_Driver()
        Go_To_URl(mUrl_Base)
        Login()
        Create_Campaign()
        Upload_Csv()
        Add_Email()
        'Add_Time_Zone()
        Stop_Sending_Email_When()
        'Create_The_Campaign()
        Review()
    End Sub
    Private Sub Review()
        mDriver.Manage().Window.Maximize()
        Dim tabs = mDriver.FindElement(By.CssSelector(".tabs")).FindElements(By.TagName("a"))
        Utilities.Click_Elelment_No_Wait(tabs(tabs.Count - 1), mDriver)
        Thread.Sleep(5000)
        Dim doub As Double = mLemlist.NB_Rows / 100
        Dim index As Double = Math.Ceiling(doub)
        For i = 1 To index
            Thread.Sleep(4000)
            Dim div = mDriver.FindElement(By.CssSelector(".mt-2.leads-list.leads-review.js-perfect-scrollbar.ps"))
            Dim sections = div.FindElements(By.TagName("section"))

            For j = 0 To sections.Count - 1
                Utilities.Click_Elelment_No_Wait(sections(j), mDriver)
                Utilities.Click_Elelment_No_Wait(mDriver.FindElement(By.CssSelector(".review-lead.email")), mDriver)
                'Dim container
                'Try
                '    container = mDriver.FindElement(By.CssSelector(".fr-element.fr-view"))
                'Catch ex As Exception
                '    Thread.Sleep(5000)
                '    container = mDriver.FindElement(By.CssSelector(".js-enable-spellchecker.js-froala.fr-box.fr-basic.fr-bottom"))
                'End Try
                'Dim wrapper = container.FindElement(By.CssSelector(".fr-wrapper"))
                Dim body = mDriver.FindElement(By.CssSelector(".fr-element.fr-view"))
                Dim subject = mDriver.FindElement(By.CssSelector(".emojionearea-editor"))
                Dim bodyWithImage = Load_Next_Message_Version() & body.GetAttribute("innerHTML")
                Utilities.Send_Text_Element_No_Wait(subject, Load_Random_Subject, mDriver)
                Utilities.Send_Text_Element_No_Wait(body, bodyWithImage, mDriver)
                body.SendKeys(Keys.Return)
                Try

                    Utilities.Click_Elelment_No_Wait(mDriver.FindElement(By.CssSelector(".btn.btn-sm.btn-primary.js-campaigns-step-edit-save")), mDriver)
                Catch ex As Exception
                    Thread.Sleep(4000)
                    Utilities.Click_Elelment_No_Wait(mDriver.FindElement(By.CssSelector(".btn.btn-sm.btn-primary.js-campaigns-step-edit-save")), mDriver)
                End Try

            Next
            Dim nextPage = mDriver.FindElement(By.CssSelector(".flex-1.btn.btn-ico.btn-sm.btn-secondary.js-campaigns-review-page-next"))
            Utilities.Click_Elelment_No_Wait(nextPage, mDriver)
        Next
        Dim reviewed = mDriver.FindElements(By.CssSelector(".btn.btn-sm.btn-primary.js-campaigns-review-lead-reviewed"))
        Utilities.Click_Elelment(reviewed(reviewed.Count - 2), mDriver)
        Utilities.Click_Elelment(reviewed(reviewed.Count - 2), mDriver)
        Utilities.Click(".swal-button.swal-button--confirm.swal-button--danger", mDriver)
        mDriver.Quit()
    End Sub
    Private Sub Create_Campaign()
        mDriver.FindElement(By.CssSelector(".btn.btn-secondary.js-campaigns-create")).SendKeys(Keys.Return)
        Thread.Sleep(5000)


        mDriver.FindElement(By.CssSelector(".js-campaign-name.js-edit")).SendKeys(mLemlist.Campaign_Name)
        Dim nextBtn = mDriver.FindElement(By.CssSelector(".btn.btn-primary.js-campaign-name-save.show"))
        Utilities.Click_Elelment_No_Wait(nextBtn, mDriver)
        'Utilities.Click(".emojionearea-button-open", mDriver)
        'Utilities.Click(".emojibtn", mDriver)
        'Utilities.Click(".js-campaigns-label-create.btn.btn-primary.btn-sm", mDriver)
        'mDriver.FindElement(By.CssSelector(".swal-content__input")).SendKeys(mLemlist.Labels(0))
        'Utilities.Click(".swal-button.swal-button--confirm", mDriver)
        'Utilities.Click(".btn.btn-primary.js-next", mDriver)
    End Sub
    Private Sub Upload_Csv()
        Dim CSVBtn = mDriver.FindElement(By.CssSelector(".ui-grid")).FindElements(By.TagName("button"))(0)
        Utilities.Click_Elelment_No_Wait(CSVBtn, mDriver)
        Thread.Sleep(2000)
        Dim input = mDriver.FindElement(By.CssSelector(".p-5.text-center.js-drop-file")).FindElement(By.TagName("input"))
        Thread.Sleep(1000)
        input.SendKeys(mLemlist.CSV_File)
        Thread.Sleep(2000)
        Dim btnNext = mDriver.FindElement(By.CssSelector(".nav-buttons.js-leads-import-validate-csv")).FindElements(By.TagName("button"))(1)
        Utilities.Click_Elelment_No_Wait(btnNext, mDriver)
        Thread.Sleep(2000)
        Dim IgnoreL1 = mDriver.FindElements(By.CssSelector(".ui-grid"))(1).FindElements(By.TagName("button"))(1)
        Utilities.Click_Elelment_No_Wait(IgnoreL1, mDriver)
        Thread.Sleep(2000)
        Dim IgnoreL2 = mDriver.FindElements(By.CssSelector(".ui-grid"))(2).FindElements(By.TagName("button"))(0)
        Utilities.Click_Elelment_No_Wait(IgnoreL2, mDriver)
        Thread.Sleep(2000)

        Utilities.Click_Elelment_No_Wait(mDriver.FindElement(By.CssSelector(".btn.btn-secondary.js-leads-import-csv-ok")), mDriver)
        Thread.Sleep(2000)
        Dim IgnoreL3 = mDriver.FindElements(By.CssSelector(".ui-grid"))(3).FindElements(By.TagName("button"))(1)
        Utilities.Click_Elelment_No_Wait(IgnoreL3, mDriver)
        Thread.Sleep(2000)
        Dim IgnoreL4 = mDriver.FindElements(By.CssSelector(".ui-grid"))(4).FindElements(By.TagName("button"))(0)
        Utilities.Click_Elelment_No_Wait(IgnoreL4, mDriver)
        Thread.Sleep(2000)
        Dim selectBox = mDriver.FindElement(By.CssSelector(".ui-edit-container.js-schedule-inspiration")).FindElement(By.CssSelector(".ui-edit"))

        Utilities.Click_Elelment_No_Wait(selectBox.FindElements(By.TagName("option"))(Integer.Parse(mLemlist.Time_Zone)), mDriver)
        Dim selectBoxEmail = mDriver.FindElements(By.CssSelector(".ui-edit"))
        Dim selectOption = selectBoxEmail(selectBoxEmail.Count - 1).FindElement(By.TagName("option"))
        Dim Selected = selectBoxEmail(selectBoxEmail.Count - 1).FindElement(By.TagName("select"))
        Dim mapperTime As SortedDictionary(Of Integer, String) = New SortedDictionary(Of Integer, String)
        Thread.Sleep(2000)

        selectBoxEmail(selectBoxEmail.Count - 1).FindElement(By.TagName("select")).FindElements(By.TagName("option"))(Integer.Parse(mLemlist.Time_Zone)).Click()
        Thread.Sleep(2000)

        Dim senderContainer = mDriver.FindElement(By.CssSelector(".ui-edit-container.wizard-select.js-sender")).FindElements(By.TagName("optgroup"))
        senderContainer(senderContainer.Count - 1).FindElement(By.TagName("option")).Click()

        Dim btnSuccess = mDriver.FindElement(By.CssSelector(".js-go-to-sequence"))
        Utilities.Click_Elelment_No_Wait(btnSuccess, mDriver)
        Thread.Sleep(2000)
        'Utilities.Click(".content.flex-grow-1", mDriver)
        'Dim input = mDriver.FindElement(By.CssSelector("input[type='file']"))
        'input.SendKeys(mLemlist.CSV_File)
        'Thread.Sleep(1000)
        'Thread.Sleep(1000)
        'Utilities.Click(".btn.btn-primary.js-next", mDriver)
        'Thread.Sleep(mLemlist.NB_Rows * 7000 / 230)
        'Dim nbLeadsElement = mDriver.FindElement(By.CssSelector(".swal-content__div")).Text
        'Dim parts As String() = nbLeadsElement.Split(" ")
        'parts(1) = parts(1).Trim
        'mLemlist.NB_Rows = Integer.Parse(parts(1))
        'Thread.Sleep(1000)
        'Utilities.Click(".swal-button.swal-button--yes", mDriver)
    End Sub
    Private Sub Add_Email()
        Thread.Sleep(mLemlist.NB_Rows * 7000 / 230)
        Dim container = mDriver.FindElements(By.CssSelector(".d-flex.flex-row.align-items-center"))
        Dim clicker_Container As IJavaScriptExecutor = TryCast(mDriver, IJavaScriptExecutor)
        clicker_Container.ExecuteScript("arguments[0].click();", container(1))
        Thread.Sleep(3000)
        mLemlist.Subject = "DUMMY SUBJECT"
        mDriver.FindElement(By.CssSelector(".emojionearea-editor")).SendKeys("test")
        mDriver.FindElement(By.CssSelector(".fr-element.fr-view")).SendKeys(" ")
        Add_Image()
        mDriver.FindElement(By.CssSelector(".btn.btn-primary.js-save")).Click()
        Thread.Sleep(2000)

    End Sub
    Private Sub Add_Image()

        mDriver.FindElement(By.CssSelector(".fal.fa-images")).Click()
        Thread.Sleep(4000)
        mDriver.FindElement(By.CssSelector(".btn.btn-secondary.js-image-inspiration-create")).Click()
        Thread.Sleep(4000)
        mDriver.FindElement(By.CssSelector(".btn.btn-secondary.js-toggle-add")).Click()
        Thread.Sleep(4000)
        mDriver.FindElement(By.CssSelector(".image-button.js-image-templates-image-add")).Click()
        Thread.Sleep(4000)
        Dim input = mDriver.FindElement(By.Id("fileInput"))
        mLemlist.Images.Add(mJob.Current.SnippetRefDir)
        input.SendKeys(mLemlist.Images(0))
        Thread.Sleep(4000)
        mDriver.FindElement(By.CssSelector(".swal-button.swal-button--confirm.swal-button--danger")).Click()
        Thread.Sleep(4000)
        mDriver.FindElement(By.CssSelector(".btn.btn-primary.js-save")).Click()
        Thread.Sleep(4000)
        mDriver.FindElement(By.CssSelector(".btn.btn-link")).Click()
        Thread.Sleep(4000)

        Utilities.Click_Elelment_No_Wait(mDriver.FindElement(By.CssSelector(".fr-element.fr-view")).FindElement(By.TagName("div")).FindElement(By.TagName("img")), mDriver)


        mDriver.FindElement(By.Id("imageLink-3")).Click()
        Thread.Sleep(4000)
        mDriver.FindElement(By.CssSelector(".fr-popup.fr-desktop.fr-active")).FindElement(By.TagName("input")).SendKeys(mJob.Current.URL_Post)
        Thread.Sleep(2000)
        mDriver.FindElement(By.CssSelector(".fr-command.fr-submit")).Click()
        Thread.Sleep(1000)
    End Sub
    Private Sub Stop_Sending_Email_When()
        Try
            Dim tabs = mDriver.FindElement(By.CssSelector(".tabs")).FindElements(By.TagName("a"))
            Utilities.Click_Elelment_No_Wait(tabs(tabs.Count - 2), mDriver)
            Thread.Sleep(5000)
            Dim mainDiv = mDriver.FindElement(By.CssSelector(".main-content"))
            Dim clicker_Container As IJavaScriptExecutor = TryCast(mDriver, IJavaScriptExecutor)
            Dim inputs = mDriver.FindElements(By.CssSelector(".form-check-input.js-edit"))

            Dim scroller = mDriver.FindElement(By.CssSelector(".main-center.ps.ps--active-y"))
            clicker_Container.ExecuteScript("arguments[0].scrollTop+= 500", scroller)
            Thread.Sleep(1000)
            Dim countersend = 0
            For Each send In mLemlist.Stop_sending
                countersend = countersend + 1
                If countersend = 4 Then Exit For
                Dim key = Integer.Parse(send.Key)
                If send.Value = True Then
                    If key = 0 Then inputs(key).Click() : inputs(key).Click() Else inputs(key).Click()
                Else
                    If key = 0 Then inputs(key).Click()
                End If
            Next

            clicker_Container.ExecuteScript("arguments[0].scrollTop+= 500", scroller)
            Thread.Sleep(1000)
            For Each track In mLemlist.Tracking
                Dim key = Integer.Parse(track.Key)
                If track.Value = True Then
                    If key = 0 Then inputs(key + 2).Click() : inputs(key + 2).Click() Else inputs(key + 2).Click()
                Else
                    If key = 0 Then inputs(key + 2).Click()
                End If
            Next

            mDriver.FindElement(By.CssSelector(".btn.btn-primary.js-save")).Click()
            Thread.Sleep(2000)

            'Utilities.Click(".btn.btn-secondary.dropdown-toggle.js-sender-user", mDriver)
            'Dim btns = mDriver.FindElements(By.CssSelector(".dropdown-item"))
            'Dim clicker_Container As IJavaScriptExecutor = TryCast(mDriver, IJavaScriptExecutor)
            'clicker_Container.ExecuteScript("arguments[0].click();", btns(btns.Count - 4))
        Catch ex As NullReferenceException
            mDriver.Quit()
        Catch ex As Exception
            mDriver.Quit()
        End Try
    End Sub
    Private Sub Create_The_Campaign()
        Utilities.Click(".btn.btn-primary.js-campaign-create", mDriver)
    End Sub
    Private Sub Add_Time_Zone()
        Try
            Thread.Sleep(5000)
            Dim zones = mDriver.FindElements(By.CssSelector(".llcard.selectable.inspiration.schedule"))
            For Each index As Integer In [Enum].GetValues(GetType(Time_Zone))
                Dim myindex As Integer = index
            Next
            zones(Integer.Parse(mLemlist.Time_Zone)).Click()
            Utilities.Click(".btn.btn-primary.js-next", mDriver)
        Catch ex As NullReferenceException
            mDriver.Quit()
        Catch ex As Exception
            mDriver.Quit()
        End Try
    End Sub
    Private Sub Login()
        Dim LoginField = mDriver.FindElements(By.CssSelector(".ui-edit"))
        LoginField(0).FindElement(By.TagName("input")).SendKeys(mLemlist.User_Name)
        LoginField(1).FindElement(By.TagName("input")).SendKeys(mLemlist.Password)
        Thread.Sleep(2000)
        Dim loginBtn = mDriver.FindElement(By.CssSelector(".btn.btn-primary.js-login"))
        Utilities.Click_Elelment_No_Wait(loginBtn, mDriver)
        Thread.Sleep(5000)
    End Sub
    Private Sub Clean_Line(ByRef line As String)
        line = line.Trim
        line = line.Replace(vbLf, "")
        line = line.Replace(vbNewLine, "")
        line = line.Replace(vbCr, "")
        line = line.Replace(vbCrLf, "")
        line = line.Replace("""", "")
    End Sub
    Private Sub Initialise_Driver()
        Dim options As New ChromeOptions
        options.BinaryLocation = mDirChrome
        options.AddExtension(mdirVPN)
        mDriver = New ChromeDriver(options)
        mDriver.Manage.Timeouts.PageLoad = New TimeSpan(0, 0, 60)
        mDriver.Manage.Window.Maximize()
    End Sub
    Private Sub Go_To_URl(ByVal url As String)
        mDriver.Navigate.GoToUrl(url)
    End Sub
#Region "Messages"
    Private Function Load_Next_Message_Version() As String
        Load_Message()
        mLemlist.Message.Varied = Build_Version()
        Dim bodyText As String
        bodyText = mLemlist.Message.Varied.Body_Text
        Check_Message(bodyText)
        Return bodyText
    End Function
    Private Sub Check_Message(ByVal content As String)
        Dim sb As New System.Text.StringBuilder
        For Each word In Version.Check_For_Spam_Phrases(content)
            sb.AppendLine(word)
        Next
    End Sub
    Private Sub Load_Message()
        Dim success As Boolean
        If mLemlist.Message Is Nothing Then Serialization_Utilities.Load_Object_FileSystem_And_Deserialize(Of Message)(Filepath_WIP, mLemlist.Message, success) : Exit Sub
    End Sub
    Private Function Build_Version() As Version
        Dim vers As New Version()
        With mLemlist.Message
            Dim permutation As New SortedDictionary(Of Integer, Integer)
            permutation = Select_Random_Permutation()
            vers = Version.Build_Version(.Sentences, permutation)
        End With
        Return vers
    End Function
    Private Function Select_Random_Permutation() As SortedDictionary(Of Integer, Integer)
        Dim permutation As New SortedDictionary(Of Integer, Integer) 'line number, variation chosen
        With mLemlist.Message
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
    Private Function Load_Random_Subject() As String
        Dim random As New Random()
        Dim randomGen = random.Next(1, 3)
        Dim subject = mLemlist.Message.Sentences(0).Variations(randomGen)
        Return subject
    End Function
#End Region
End Class
