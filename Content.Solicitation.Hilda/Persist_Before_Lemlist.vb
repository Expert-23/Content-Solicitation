Imports System.Data.SqlClient
Imports Content.Solicitation.Schema.Internal_DB
Imports Loggingg

Public Class Persist_Before_Lemlist

    Public Function Create_One(ByVal sorted As SortedDictionary(Of Integer, String)) As Boolean

            Dim success As Boolean = False

            Try

                Using conn As New SqlClient.SqlConnection(OPS.Conn)

                    conn.Open()

                    Dim query As String = String.Format("Insert into {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18}) VALUES('{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}')", OPS.Before_Lemlist.Table_Name,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.ID,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.LinkedIn_URL,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.First_Name,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Last_Name,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Company,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Title_Actual,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.City,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.State,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Alternate_Address,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Alternate_Phone,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Email,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Title,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Country,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Website,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Address,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Phone_Number,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Date_Created,
                                                                                                                                                                                                                                                                                                        OPS.Before_Lemlist.ColName.Status,
                                                                                                                                                                                                                                                                                                        sorted(0),
                                                                                                                                                                                                                                                                                                        sorted(1),
                                                                                                                                                                                                                                                                                                        sorted(2),
                                                                                                                                                                                                                                                                                                        sorted(3),
                                                                                                                                                                                                                                                                                                        sorted(4),
                                                                                                                                                                                                                                                                                                        sorted(5),
                                                                                                                                                                                                                                                                                                        sorted(6),
                                                                                                                                                                                                                                                                                                        sorted(7),
                                                                                                                                                                                                                                                                                                        sorted(8),
                                                                                                                                                                                                                                                                                                        sorted(9),
                                                                                                                                                                                                                                                                                                        sorted(10),
                                                                                                                                                                                                                                                                                                        sorted(11),
                                                                                                                                                                                                                                                                                                        sorted(12),
                                                                                                                                                                                                                                                                                                        sorted(13),
                                                                                                                                                                                                                                                                                                        sorted(14),
                                                                                                                                                                                                                                                                                                        sorted(15),
                                                                                                                                                                                                                                                                                                        sorted(16),
                                                                                                                                                                                                                                                                                                        sorted(17))

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

        Public Function Create_Mulitple(ByRef data As SortedDictionary(Of Integer, SortedDictionary(Of Integer, String))) As Boolean

            Dim success As Boolean = False

            Try

                If data Is Nothing Or data.Count = 0 Then Return False

                For Each entry In data.Values

                    Create_One(entry)

                Next

                success = True

            Catch ex As NullReferenceException

                MasterLog.MasterLogs().[Error](ex, "Object With Null Reference")

            Catch ex As Exception

                MasterLog.MasterLogs().[Error](ex, "")

            End Try

            Return success

        End Function

        Public Function Delete_One(ByVal id As Integer) As Boolean

            Dim success As Boolean = False
            Try


                Using conn As New SqlClient.SqlConnection(OPS.Conn)

                    conn.Open()

                    Dim query As String = String.Format("delete from {0} WHERE {1}= '{2}' ",
                                                        OPS.Before_Lemlist.Table_Name,
                                                        OPS.Before_Lemlist.ColName.Index,
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

        Public Function Delete_All() As Boolean

            Dim success As Boolean = False
            Try


                Using conn As New SqlClient.SqlConnection(OPS.Conn)

                    conn.Open()

                    Dim query As String = String.Format("delete from {0}",
                                                        OPS.Before_Lemlist.Table_Name)

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

        Public Function Retrieve_One(ByVal id As String) As DataSet

            Dim ds As New DataSet

            Try


                Using conn As New SqlClient.SqlConnection(OPS.Conn)

                    conn.Open()

                    Dim query As String = String.Format("select * from {0} where {1} = '{2}'",
                                                        OPS.Before_Lemlist.Table_Name,
                                                        OPS.Before_Lemlist.ColName.Index,
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

        Public Function Retrieve_All() As DataSet

            Dim ds As New DataSet

            Try


                Using conn As New SqlConnection(OPS.Conn)

                    conn.Open()

                    Dim query As String = String.Format("select * from {0}", OPS.Before_Lemlist.Table_Name)

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

