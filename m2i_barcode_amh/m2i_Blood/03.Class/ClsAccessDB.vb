Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class ClsAccessDB

    Public cMDBCn As New OleDbConnection

    Private ConnectionString As String

    Public Sub New()
        ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & gMDbName
        'ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & gLocalZIPDBFile
        cMDBCn.ConnectionString = ConnectionString
    End Sub


    Public Function CMDBDatabaseOpen(ByVal DBCn As OleDbConnection) As Boolean
        Try
            If cMDBCn.State = ConnectionState.Open OrElse cMDBCn.State = ConnectionState.Connecting Then
                cMDBCn.Close()
            End If

            cMDBCn.Open()

            Return True
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CMDBDatabaseName(ByVal DBCn As OleDbConnection) As String
        Return DBCn.Database
    End Function

    Public Function CMDBDatabaseClose(ByVal DBCn As OleDbConnection) As Boolean
        Try
            If DBCn.State = ConnectionState.Open Then
                DBCn.Close()
            End If

            Return True

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function CMDBSelectQuery(ByVal DBCn As OleDbConnection,
                                  QueryStr As String) As DataTable
        Dim sAdapter As OleDbDataAdapter, sTable As New DataTable, sReturn As Boolean

        If QueryStr.Length = 0 Then
            Return Nothing
        End If

        Try
            If CMDBDatabaseOpen(DBCn) Then

                sAdapter = New OleDbDataAdapter(QueryStr, DBCn)
                sAdapter.Fill(sTable)

                sReturn = True
            Else
                sReturn = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CMDBDatabaseClose(DBCn)

        If sReturn Then
            Return sTable
        Else
            Return Nothing
        End If

    End Function

    Public Function CMDBExecuteQuery(
                                   ByVal DBCn As OleDbConnection,
                                   QueryStr As String) As Boolean
        If QueryStr.Length = 0 Then
            Return False
        End If

        Dim sReturn As Boolean

        Try
            If CMDBDatabaseOpen(DBCn) Then
                Dim sCommand As OleDbCommand, sReturnCnt As Integer = 0

                sCommand = New OleDbCommand(QueryStr, DBCn)
                sReturnCnt = sCommand.ExecuteNonQuery

                sReturn = (sReturnCnt <> 0)
            Else
                sReturn = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CMDBDatabaseClose(DBCn)
        Return sReturn
    End Function

    Public Function CMDBMultiExecuteQuery(ByVal DBTYPE As String,
                                        ByVal DBCn As OleDbConnection,
                                        QueryStr() As String) As Boolean
        Dim sCommand As OleDbCommand, sTrans As OleDbTransaction
        Dim sCnt As Integer = 0, sReturn As Boolean = False

        If QueryStr.Length = 0 Then
            Return False
        End If

        Try
            If CMDBDatabaseOpen(DBCn) Then
                sTrans = DBCn.BeginTransaction()
                sCommand = DBCn.CreateCommand()
                sCommand.Connection = DBCn
                sCommand.Transaction = sTrans

                For sCnt = 0 To QueryStr.Length - 1
                    If QueryStr(sCnt).Length > 0 Then
                        Try
                            sCommand.CommandText = QueryStr(sCnt)
                            sCommand.ExecuteNonQuery()
                            sReturn = True
                        Catch ex As Exception
                            XtraMessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            sReturn = False
                        End Try
                    End If

                    If sReturn = False Then Exit For
                Next

                If sReturn Then
                    sTrans.Commit()
                Else
                    sTrans.Rollback()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CMDBDatabaseClose(DBCn)
        Return sReturn
    End Function

    Public Function LocalDBBackupCopy() As Boolean
        Try
            If Not System.IO.Directory.Exists(gLocalBackupFolder) Then
                System.IO.Directory.CreateDirectory(gLocalBackupFolder)
            End If

            If System.IO.File.Exists(String.Format(gLocalBackupFolder & "{0:yyyyMMdd}.mdb", Date.Today)) Then
                System.IO.File.Delete(String.Format(gLocalBackupFolder & "{0:yyyyMMdd}.mdb", Date.Today))
            End If

            System.IO.File.Copy(Application.StartupPath & gLocalDBFile,
                                String.Format(gLocalBackupFolder & "{0:yyyyMMdd}.mdb", Date.Today))

            Return True

        Catch ex As Exception
            Return False

        End Try

    End Function

End Class
