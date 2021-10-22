Imports System.Drawing
Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Utilities
Imports Content.Solicitation.Localize
Imports Content.Solicitation.Schema.Internal_DB
Imports System.Data.SqlClient
Imports Loggingg

Public Class Persist_FileSystem

    Public Function Create_One_Message(ByVal message As Message) As Boolean

        Dim success As Boolean = False
        Dim bytes As Byte() = {}
        Serialization_Utilities.Serialize_Object(Of Message)(bytes, message)
        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("insert into {0} ({1}) VALUES (@binary)",
                                                        OPS.Message.Table_Name,
                                                        OPS.Message.ColName.Message_Binary
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

    Public Function Retrieve_One_Message(ByVal id As Integer) As Boolean

        Dim ds As New DataSet

        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("select * from {0} where {1} = '{2}'",
                                                        OPS.Message.Table_Name,
                                                        OPS.Message.ColName.ID,
                                                        id
                                                        )

                Dim da As New SqlDataAdapter(query, conn)
                da.Fill(ds)

                conn.Close()

            End Using

        Catch ex As SqlException

            MasterLog.MasterLogs().[Error](ex, "Sql Exception")

        Catch ex As Exception

            MasterLog.MasterLogs().[Error](ex, "")

        End Try

        Return success

    End Function

    Public Function Update_One_Message(ByVal message As Message) As Boolean

        Dim success As Boolean = False
        Dim bytes As Byte() = {}
        Serialization_Utilities.Serialize_Object(Of Message)(bytes, message)
        Try


            Using conn As New SqlClient.SqlConnection(OPS.Conn)

                conn.Open()

                Dim query As String = String.Format("update {0} set {1} = @binary where {2} = '{3}'",
                                                        OPS.Message.Table_Name,
                                                        OPS.Message.ColName.Message_Binary,
                                                        OPS.Message.ColName.ID,
                                                        message.ID
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

End Class
