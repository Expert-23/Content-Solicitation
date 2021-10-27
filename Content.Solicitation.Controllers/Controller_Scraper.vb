Imports Content.Solicitation.Adapters
Imports Content.Primitives
Public Class Controller_Scraper
    Private Scraper_Quilbot As Scraper_QB
    Private Scraper_Lemlist As Scraper_Lemlist
    Private Scraper_Reports As Scraper_Reports_Lemlist
    Public Sub New()
        Scraper_Quilbot = New Scraper_QB
    End Sub
    Public Sub Analyze_Message(ByRef message As Message, ByVal variants As Integer)
        Scraper_Quilbot.Scrape(message, variants)
    End Sub
    Public Sub Launch_Campaign(ByRef lemlist As Lemlist, ByRef job As Job_Curation)
        Scraper_Lemlist = New Scraper_Lemlist(lemlist, job)
        Scraper_Lemlist.Scrape()
    End Sub
    Public Sub Scrape_Reports()
        Scraper_Reports = New Scraper_Reports_Lemlist
        Scraper_Reports.Scrape_Reports()
    End Sub
End Class
