Imports Content.Solicitation.Schema.Internal_DB
Public Class Persist_Solicitation

    Public Function Create_One_Job_Solicitation(ByVal job_solicitation As Job_Solicitation, ByVal imagebytes As Byte()) As Boolean

        Dim job_binary As Byte() = {}
        Serialization_Utilities.Serialize_Object(Of Job_Solicitation)(job_binary, job_solicitation)
        Dim photo As Bitmap = job_solicitation.Snippet

        Dim date_created As DateTime = DateTime.Now
        Dim success As Boolean = False
        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("Insert INTO {0}({1},{2},{3},{4},{5},{6},{7},{8}) values('{9}','{10}','{11}','{12}','{13}',@binary,@binary1,'{13}')",
                                                    OPS.Job_Solicitation.Table_Name,
                                                    OPS.Job_Solicitation.ColName.Content_Item_ID,
                                                    OPS.Job_Solicitation.ColName.Job_Status,
                                                    OPS.Job_Solicitation.ColName.Website,
                                                    OPS.Job_Solicitation.ColName.Category,
                                                    OPS.Job_Solicitation.ColName.Date_Created,
                                                    OPS.Job_Solicitation.ColName.Job_Solicitation,
                                                    OPS.Job_Solicitation.ColName.Snippet,
                                                    OPS.Job_Solicitation.ColName.Date_Modified,
                                                    job_solicitation.Item_Content.ID,
                                                    job_solicitation.Item_Content.Status,
                                                    job_solicitation.Item_Content.Website.ToString(),
                                                    job_solicitation.Item_Content.Category,
                                                    date_created,
)

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@binary", job_binary)
                cmd.Parameters.AddWithValue("@binary1", imagebytes)


                cmd.ExecuteNonQuery()


                conn.Close()
                success = True



            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return success

    End Function

    Public Function Create_Mulitple_Job_Solicitation(ByRef solicitations As Dictionary(Of String, Tuple(Of Job_Solicitation, Boolean))) As Boolean

        Dim success As Boolean = False

        Try

            If solicitations Is Nothing Then Return False

            Dim updated_Collection As New Dictionary(Of String, Tuple(Of Job_Solicitation, Boolean))

            For Each entry In solicitations.Values

                Dim job_solicit As Job_Solicitation = entry.Item1
                Dim ispushed As Boolean = entry.Item2

                If Not ispushed Then

                    Dim id As String = job_solicit.Item_Content.ID_Unique
                    'If Not Create_One_Job_Solicitation(job_solicit) Then


                    '    updated_Collection.Add(id, New Tuple(Of Job_Solicitation, Boolean)(job_solicit, False))

                    '    Console.WriteLine("Failed To Create Job with ID : {0}", job_solicit.Item_Content.ID)

                    'Else
                    '    updated_Collection.Add(id, New Tuple(Of Job_Solicitation, Boolean)(job_solicit, True))

                    'End If

                End If


            Next


            success = True
            solicitations = updated_Collection

        Catch ex As NullReferenceException

            MasterLog.MasterLogs().Error(ex, "Object With Null Reference")

        Catch ex As Exception

            MasterLog.MasterLogs().Error(ex, "")

        End Try

        Return success
    End Function

    Public Function Update_One_Solicitation(job_solicitation As Job_Solicitation) As Boolean
        Dim solicitation_binary As Byte() = {}

        Dim success As Boolean = False

        Try

            Serialization_Utilities.Serialize_Object(Of Job_Solicitation)(solicitation_binary, job_solicitation)

            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("UPDATE {0}  SET {1}  = @binary WHERE {2}= '{3}' ",
                                                    OPS.Job_Solicitation.Table_Name,
                                                    OPS.Job_Solicitation.ColName.Job_Solicitation,
                                                    OPS.Job_Solicitation.ColName.Content_Item_ID,
                                                    job_solicitation.Item_Content.ID)


                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@binary", solicitation_binary)

                cmd.ExecuteNonQuery()
                conn.Close()

                success = True



            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return success


    End Function

    Public Function Delete_One_Solicitation(ByVal id As Integer) As Boolean

        Dim success As Boolean = False
        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("delete from {0} WHERE {1}= '{2}' ",
                                                    OPS.Job_Solicitation.Table_Name,
                                                    OPS.Job_Solicitation.ColName.ID,
                                                    id)


                Dim cmd As New SqlCommand(query, conn)

                cmd.ExecuteNonQuery()
                conn.Close()

                success = True

            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return success


    End Function

    Public Function Retrieve_One_Job_Solicitation(ByVal id As Integer) As Boolean

        Dim ds As New DataSet

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("select * from {0} where {1} = '{2}'",
                                                    OPS.Job_Solicitation.Table_Name,
                                                    OPS.Job_Solicitation.ColName.ID,
                                                    id)

                Dim da = New SqlDataAdapter(query, conn)
                da.Fill(ds)

                conn.Close()
                success = True



            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return success

    End Function

    Public Function Retrieve_All_Job_Solicitation() As DataSet

        Dim ds As New DataSet

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("select * from {0}",
                                                    OPS.Job_Solicitation.Table_Name)

                Dim da = New SqlDataAdapter(query, conn)
                da.Fill(ds)

                conn.Close()
                kjkpo
            End Using

        Catch ex As SqlException0iuiuiu

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return ds

    End Function

End Class
