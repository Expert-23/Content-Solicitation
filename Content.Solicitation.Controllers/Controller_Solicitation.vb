Imports Content.Solicitation.Hilda
Imports Content.Solicitation.Primitives

Public Class Controller_Solicitation

    Private mPersist_Solicitation As Persist_Solicitation

    Public Sub New()

        mPersist_Solicitation = New Persist_Solicitation()

    End Sub

    Public Function Get_All_Solicitation() As SortedDictionary(Of Integer, SortedDictionary(Of Integer, Job_Solicitation))

        Dim ds As New DataSet
        ds = mPersist_Solicitation.Retrieve_All_Job_Solicitation()

    End Function

End Class
