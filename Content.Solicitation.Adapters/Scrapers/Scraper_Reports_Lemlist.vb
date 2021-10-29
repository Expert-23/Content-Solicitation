Imports System.Threading
Imports Content.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Localize
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome

Public Class Scraper_Reports_Lemlist
    Private mDriver As IWebDriver
    Private mDirChrome As String
    Private mUrl_Base As String
    Private mURL_Reports As String
    Private mdirVPN As String
    Public Reports As List(Of Reports)
    Public Sub New()
        Initilaize()
    End Sub
    Private Sub Initilaize()
        mDirChrome = "C:\Users\pc\Desktop\Software and Files\Expert 23\Google_For_Selenium_78.0.3904.7000\Chrome\Application\chrome.exe"
        mUrl_Base = "https://app.lemlist.com/campaigns/"
        mdirVPN = "C:\Users\pc\Desktop\Software and Files\Expert 23\Google_For_Selenium_78.0.3904.7000\Chrome\Application\2.0.0_0.crx"
        mURL_Reports = "https://app.lemlist.com/reports"
    End Sub
    Public Sub Scrape_Reports()
        Initialise_Driver()
        Go_To_URl(mUrl_Base)
        Login()
        Scrape_Pages()
    End Sub
    Private Sub Scrape_Pages()
        Go_To_URl(mURL_Reports)
        Get_Dates()
        Get_Campaign_Stats()
    End Sub
    Private Sub Get_Dates()
        mDriver.FindElements(By.CssSelector(".js-tab-switch"))(1).Click()
        Thread.Sleep(2000)
        mDriver.FindElement(By.CssSelector(".btn.btn-secondary.dropdown-toggle")).Click()
        Dim dateContainer = mDriver.FindElement(By.CssSelector(".dropdown-menu.max.scrollable-menu.show")).FindElements(By.TagName("button"))
        dateContainer(dateContainer.Count - 2).Click()
    End Sub
    Private Sub Get_Campaign_Stats()

        Thread.Sleep(1000)
        Dim container = mDriver.FindElement(By.CssSelector(".main-container"))
        container.Click()
        container.SendKeys(Keys.ArrowDown)
        container.SendKeys(Keys.ArrowDown)
        container.SendKeys(Keys.ArrowDown)
        Thread.Sleep(1000)
        mDriver.FindElement(By.CssSelector(".btn.btn-secondary.btn-block.dropdown-toggle")).Click()
        Dim campaignContainer = mDriver.FindElement(By.CssSelector(".dropdown-menu.max.scrollable-menu.checkbox-menu.reports-campaign-analytics-campaigns show")).FindElements(By.TagName("button"))

        For i = 1 To campaignContainer.Count - 1
            Utilities.Click_Elelment(campaignContainer(0), mDriver)
            Utilities.Click_Elelment(campaignContainer(0), mDriver)
            campaignContainer(i).Click()

            campaignContainer(0).Click()
            campaignContainer(0).Click()
            campaignContainer(i).Click()
            Thread.Sleep(1000)
            Dim report As New Reports

            Dim statsContainer = mDriver.FindElement(By.CssSelector(".stat-column")).FindElement(By.CssSelector(".stat-line")).FindElements(By.CssSelector(".stat-metrics-percent"))
            With report
                .ID = Guid.NewGuid().ToString
                .Campaign_Name = campaignContainer(i).FindElement(By.CssSelector(".col-4")).Text
                .Sent = statsContainer(0).Text
                .Opened = statsContainer(1).Text
                .Clicked = statsContainer(2).Text
                .Interested = statsContainer(3).Text
            End With
            Reports.Add(report)
        Next
    End Sub
    Private Sub Login()
        Dim LoginField = mDriver.FindElements(By.CssSelector(".ui-edit"))
        LoginField(0).FindElement(By.TagName("input")).SendKeys("qcontinuum@mail.com")
        LoginField(1).FindElement(By.TagName("input")).SendKeys("send2021!Email")
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
End Class
