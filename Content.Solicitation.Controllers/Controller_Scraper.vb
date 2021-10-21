Imports Content.Solicitation.Adapters
Imports Content.Solicitation.Primitives
Public Class Controller_Scraper
    Public Scraper_Quilbot As Scraper_QB
    Public Scraper_Lemlist As Scraper_Lemlist
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
End Class
