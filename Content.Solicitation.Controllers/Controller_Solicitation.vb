Imports Content.Solicitation.Hilda
Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities

Public Class Controller_Solicitation

    Private mPersist_Solicitation As Persist_Solicitation

    Public Sub New()

        mPersist_Solicitation = New Persist_Solicitation()

    End Sub

    Public Function Get_All_Solicitations() As SortedDictionary(Of Integer, SortedDictionary(Of Integer, Job_Solicitation))

        Dim success = False

        Dim solicitations As New SortedDictionary(Of Integer, SortedDictionary(Of Integer, Job_Solicitation))
        Dim solicitation As SortedDictionary(Of Integer, Job_Solicitation)
        Dim ds As New DataSet
        ds = mPersist_Solicitation.Retrieve_All_Job_Solicitation()

        For i = 0 To ds.Tables(0).Rows.Count

            solicitation = New SortedDictionary(Of Integer, Job_Solicitation)
            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Job_Solicitation)(ds.Tables(0).Rows(i)(1), success)
            solicitation.Add(ds.Tables(0).Rows(i)(0), msg)
            solicitations.Add(i, solicitation)

        Next

        Return solicitations

    End Function

    Public Function Get_All_Solicitations_By_Website(ByVal website As Websites, ByVal job_status As Content_Status) As SortedDictionary(Of Integer, SortedDictionary(Of Integer, Job_Solicitation))

        Dim success = False

        Dim solicitations As New SortedDictionary(Of Integer, SortedDictionary(Of Integer, Job_Solicitation))
        Dim solicitation As SortedDictionary(Of Integer, Job_Solicitation)
        Dim ds As New DataSet
        ds = mPersist_Solicitation.Retrieve_All_Job_Solicitation(website, job_status)

        For i = 0 To ds.Tables(0).Rows.Count

            solicitation = New SortedDictionary(Of Integer, Job_Solicitation)
            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Job_Solicitation)(ds.Tables(0).Rows(i)(1), success)
            solicitation.Add(ds.Tables(0).Rows(i)(0), msg)
            solicitations.Add(i, solicitation)

        Next

        Return solicitations

    End Function

End Class
