Imports Content.Solicitation.Hilda
Imports Content.Primitives
Public Class Controller_Persist
#Region "Members"
    Private mPersistMessage As Persist_Message
#End Region

#Region "Initilaization"
    Public Sub New()
        Initilaize()
    End Sub
    Private Sub Initilaize()
        mPersistMessage = New Persist_Message
    End Sub
#End Region
#Region "Methods"
    Public Function Create_One_Message(ByVal message As Message) As Boolean
        Return mPersistMessage.Create_One_Message(message)
    End Function
    Public Function Retrieve_All_Messages() As SortedDictionary(Of Integer, Message)
        Dim ds As New DataSet
        ds = mPersistMessage.Retrieve_All_Messages()
        Return New SortedDictionary(Of Integer, Message)
    End Function
#End Region


End Class
