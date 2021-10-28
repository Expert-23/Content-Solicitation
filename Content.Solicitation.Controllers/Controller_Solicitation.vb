Imports Content.Solicitation.Hilda
Imports Content.Primitives
Imports Content.Solicitation.Utilities
Imports System.IO

Public Class Controller_Solicitation

    Private mPersist_Solicitation As Persist_Solicitation

    Public Sub New()

        mPersist_Solicitation = New Persist_Solicitation()

    End Sub

    Public Function Get_All_Solicitations() As SortedDictionary(Of Integer, Job_Solicitation)

        Dim success = False

        Dim solicitations As New SortedDictionary(Of Integer, Job_Solicitation)
        Dim ds As New DataSet
        ds = mPersist_Solicitation.Retrieve_All_Job_Solicitation()

        For i = 0 To ds.Tables(0).Rows.Count

            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Job_Solicitation)(ds.Tables(0).Rows(i)(1), success)
            solicitations.Add(i, msg)

        Next

        Return solicitations

    End Function

    Public Function Get_All_Solicitations_By_Website(ByVal website As Websites, ByVal job_status As Content_Status) As SortedDictionary(Of Integer, Job_Solicitation)

        Dim success = False

        Dim solicitation As New SortedDictionary(Of Integer, Job_Solicitation)
        Dim ds As New DataSet
        ds = mPersist_Solicitation.Retrieve_All_Job_Solicitation(website, job_status)

        For i = 0 To ds.Tables(0).Rows.Count - 1


            'Dim job As Job_Solicitation = Serialization_Utilities.DeSerialize_Object(Of Job_Solicitation)(ds.Tables(0).Rows(i)(1), success)

            'With job

            '    .s

            'End With

            solicitation = New SortedDictionary(Of Integer, Job_Solicitation)
            Dim msg = Serialization_Utilities.DeSerialize_Object(Of Job_Solicitation)(ds.Tables(0).Rows(i)(1), success)
            msg.Snippet = To_Bitmap_From_Bytes_Array(ds.Tables(0).Rows(i)(7))
            solicitation.Add(ds.Tables(0).Rows(i)(0), msg)

        Next

        Return solicitation

    End Function
    Public Function To_Bitmap_From_Bytes_Array(ByVal image_bytes As Byte()) As Bitmap

        Dim bitmap As Bitmap
        Using ms As New MemoryStream(image_bytes)

            bitmap = New Bitmap(ms)
            ms.Close()
            ms.Dispose()

        End Using

        Return bitmap
    End Function

    Public Function To_Bytes_Array_From_BitMap(ByVal snippet As Bitmap) As Byte()

        Dim image_bytes As Byte()
        Using ms As New MemoryStream
            snippet.Save(ms, Imaging.ImageFormat.Png)

            image_bytes = ms.ToArray()
            ms.Close()
            ms.Dispose()
        End Using

        Return image_bytes

    End Function
End Class
