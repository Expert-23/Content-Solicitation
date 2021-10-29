Imports System.Windows.Forms

<Serializable>
Public Class Email_Format
    Public Snippet_Position As String
    Public Logo_Position As String
    Public Logo_Selection As String
    Public Snippet_Selection As String
    Public Font_Family As String
    Public Font_Size As String
    Public Date_Created As DateTime
    Public Date_Modified As DateTime
    Public File_Dir As String
    Public Bold_Words As List(Of String)
    Public Binary_String As String
    Public Underlined_Words As List(Of String)

    Public Sub New()
        Initialize()
    End Sub
    Private Sub Initialize()
        Snippet_Position = String.Empty
        Logo_Position = String.Empty
        Font_Family = String.Empty
        Font_Size = String.Empty
        Logo_Selection = String.Empty
        Snippet_Selection = String.Empty
        File_Dir = String.Empty
        Date_Created = Date.Now
        Date_Modified = Date.Now
        Bold_Words = New List(Of String)
        Underlined_Words = New List(Of String)
        Binary_String = String.Empty
    End Sub
    Public Overrides Function ToString() As String
        Return Font_Family & vbTab & Font_Size
    End Function
End Class
