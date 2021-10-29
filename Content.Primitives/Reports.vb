Public Class Reports
    Public ID As String
    Public Website As Websites
    Public Campaign_Name As String
    Public Sent As String
    Public Opened As String
    Public Clicked As String
    Public Replied As String
    Public Interested As String
    Public Sub New()
        ID = String.Empty
        Website = Websites.unspecified
        Campaign_Name = String.Empty
        Sent = String.Empty
        Opened = String.Empty
        Clicked = String.Empty
        Replied = String.Empty
        Interested = String.Empty
    End Sub
    Public Overrides Function ToString() As String
        Return ID & vbTab & Website.ToString & vbTab & Campaign_Name & vbTab & Sent & vbTab &
               Opened & vbTab & Clicked & vbTab & Replied & vbTab & Interested & vbNewLine
    End Function
End Class
