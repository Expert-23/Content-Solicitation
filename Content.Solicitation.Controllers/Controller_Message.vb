Imports Content.Solicitation.Hilda
Imports Content.Primitives
Imports Content.Solicitation.Utilities

Public Class Controller_Message

    Public mPersist_Message As Persist_Message

    Public Sub New()

        mPersist_Message = New Persist_Message

    End Sub

    Public Function Get_All_Messages() As SortedDictionary(Of Integer, SortedDictionary(Of String, Message))

        Dim ds As New DataSet
        Dim messages As New SortedDictionary(Of Integer, SortedDictionary(Of String, Message))
        Dim row As SortedDictionary(Of String, Message)

        ds = mPersist_Message.Retrieve_All_Messages()
        Dim success As Boolean = False

        For i = 0 To ds.Tables(0).Rows.Count - 1

            row = New SortedDictionary(Of String, Message)
            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Message)(ds.Tables(0).Rows(i)(1), success)
            row.Add(ds.Tables(0).Rows(i)(2), msg)
            messages.Add(ds.Tables(0).Rows(i)(0), row)

        Next

        Return messages

    End Function

    Public Function Get_One_Message(ByVal id As Integer) As SortedDictionary(Of Integer, SortedDictionary(Of String, Message))

        Dim ds As New DataSet
        Dim messages As New SortedDictionary(Of Integer, SortedDictionary(Of String, Message))
        Dim row As SortedDictionary(Of String, Message)

        ds = mPersist_Message.Retrieve_One_Message(id)
        Dim success As Boolean = False

        For i = 0 To ds.Tables(0).Rows.Count

            row = New SortedDictionary(Of String, Message)
            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Message)(ds.Tables(0).Rows(i)(1), success)
            row.Add(ds.Tables(0).Rows(i)(2), msg)
            messages.Add(ds.Tables(0).Rows(i)(0), row)

        Next

        Return messages

    End Function

    Public Function Get_One_Message_By_Website(ByVal website As Websites) As SortedDictionary(Of Integer, SortedDictionary(Of String, Message))

        Dim ds As New DataSet
        Dim messages As New SortedDictionary(Of Integer, SortedDictionary(Of String, Message))
        Dim row As SortedDictionary(Of String, Message)

        ds = mPersist_Message.Retrieve_All_Messages_By_Website(website)
        Dim success As Boolean = False

        For i = 0 To ds.Tables(0).Rows.Count - 1

            row = New SortedDictionary(Of String, Message)
            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Message)(ds.Tables(0).Rows(i)(1), success)
            row.Add(ds.Tables(0).Rows(i)(2), msg)
            messages.Add(ds.Tables(0).Rows(i)(0), row)

        Next

        Return messages

    End Function

    Public Function Get_One_Solicite_By_Website(ByVal website As Websites) As SortedDictionary(Of Integer, SortedDictionary(Of String, Message))

        Dim ds As New DataSet
        Dim messages As New SortedDictionary(Of Integer, SortedDictionary(Of String, Message))
        Dim row As SortedDictionary(Of String, Message)

        ds = mPersist_Message.Retrieve_All_Messages_By_Website(website)
        Dim success As Boolean = False

        For i = 0 To ds.Tables(0).Rows.Count - 1

            row = New SortedDictionary(Of String, Message)
            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Message)(ds.Tables(0).Rows(i)(1), success)
            row.Add(ds.Tables(0).Rows(i)(2), msg)
            messages.Add(ds.Tables(0).Rows(i)(0), row)

        Next

        Return messages

    End Function

    Public Function Save_One_Message(ByVal message As Message) As Boolean
        Return mPersist_Message.Create_One_Message(message)
    End Function
    Public Function Update_One_Message(ByVal message As Message) As Boolean
        Return mPersist_Message.Update_One_Message(message)
    End Function

End Class
