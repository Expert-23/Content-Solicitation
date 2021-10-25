Imports System.Data.SqlClient
Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Schema.Internal_DB
Imports Content.Solicitation.Utilities
Imports Loggingg

Public Class Persist_Message

    Public Function Create_One_Message(ByVal message As Message) As Boolean

        Dim bytes As Byte() = {}
        Serialization_Utilities.Serialize_Object(Of Message)(bytes, message)

        Dim success As Boolean = False

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("Insert into {0} ({1},{2},{3},{4}) VALUES(@binary,'{6}','{7}','{5}')",
                                                    OPS.Message.Table_Name,
                                                    OPS.Message.ColName.Message_Binary,
                                                    OPS.Message.ColName.Campaign_Name,
                                                    OPS.Message.ColName.Website,
                                                    OPS.Message.ColName.Date_Created,
                                                    DateTime.Now,
                                                    message.ID,
                                                    message.Website
                                                    )

                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@binary", bytes)

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

    Public Function Update_One_Message(ByVal message As Message) As Boolean

        Dim bytes As Byte() = {}
        Serialization_Utilities.Serialize_Object(Of Message)(bytes, message)
        Dim success As Boolean = False

        Try

            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("UPDATE {0}  SET {2}  = @binary , {3} = '{5}'  WHERE {1}= '{4}' ",
                                                    OPS.Message.Table_Name,
                                                    OPS.Message.ColName.Campaign_Name,
                                                    OPS.Message.ColName.Message_Binary,
                                                    OPS.Message.ColName.Date_Updated,
                                                    message.ID,
                                                    DateTime.Now)


                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@binary", bytes)

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

    Public Function Delete_One_Message(ByVal id As Integer) As Boolean

        Dim success As Boolean = False
        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("delete from {0} WHERE {1}= '{2}' ",
                                                    OPS.Message.Table_Name,
                                                    OPS.Message.ColName.ID,
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

    Public Function Retrieve_One_Message(ByVal id As Integer) As DataSet

        Dim ds As New DataSet

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("select * from {0} where {1} = '{2}'",
                                                    OPS.Message.Table_Name,
                                                    OPS.Message.ColName.ID,
                                                    id)

                Dim da = New SqlDataAdapter(query, conn)
                da.Fill(ds)

                conn.Close()

            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return ds

    End Function

    Public Function Retrieve_All_Messages_By_Website(ByVal website As Websites) As DataSet

        Dim ds As New DataSet

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("select * from {0} where {1} = '{2}'",
                                                    OPS.Message.Table_Name,
                                                    OPS.Message.ColName.Website,
                                                    website)

                Dim da = New SqlDataAdapter(query, conn)
                da.Fill(ds)

                conn.Close()

            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return ds

    End Function

    Public Function Retrieve_All_Solicites_By_Website(ByVal website As Websites) As DataSet

        Dim ds As New DataSet

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("select * from {0} where {1} = '{2}'",
                                                    OPS.Message.Table_Name,
                                                    OPS.Message.ColName.Website,
                                                    website)

                Dim da = New SqlDataAdapter(query, conn)
                da.Fill(ds)

                conn.Close()

            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return ds

    End Function

    Public Function Retrieve_All_Messages() As DataSet

        Dim ds As New DataSet

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("select * from {0}",
                                                    OPS.Message.Table_Name)

                Dim da = New SqlDataAdapter(query, conn)
                da.Fill(ds)

                conn.Close()

            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return ds

    End Function

End Class
