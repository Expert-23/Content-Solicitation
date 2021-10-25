Imports System.Threading
Imports Content.Solicitation.Primitives
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
