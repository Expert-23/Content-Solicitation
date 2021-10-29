Imports System.Drawing
<Serializable>
Public Class Job_Solicitation

    Public Item_Content As Content_Item

    <NonSerialized>
    Public Snippet As Bitmap

    Public Snippet_File_Path As String
    Public Timestamp As DateTime
    Public Date_Modified As DateTime

    Public Sub New()

        Initialize_Job()

    End Sub

    Public Sub New(ByVal dr As DataRow)
        Initialize_Job(dr)
    End Sub

    Private Sub Initialize_Job()

        Item_Content = New Content_Item
        Snippet_File_Path = String.Empty
        Timestamp = Now
        Date_Modified = Now



    End Sub

    Private Sub Initialize_Job(ByVal dr As DataRow)






    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}:{1}:{2}", Item_Content.ID, Item_Content.Name_Source, Timestamp.ToString("M/d/yy"))
    End Function

    Public Shared Function Get_Test_Snippet() As Bitmap
        Dim test As Bitmap
        Return test

    End Function

End Class

