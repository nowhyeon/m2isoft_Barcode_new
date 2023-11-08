Imports OracleInternal
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.Data.OleDb

Public Class ClsDatabase

    Public cDbCn As New SqlConnection
    Public cMsDbCn As New SqlConnection
    '-[ 오라클 접속 DLL 참조
    Public cOraDbCn As New Oracle.ManagedDataAccess.Client.OracleConnection
    Public mDBCn As New OleDbConnection()

    Private ConnectionString As String

    Public Sub New()

        ConnectionString = "data source=" & Str_HOST_IP & ";" &
                           "initial catalog=" & Str_DATABASE_NAME & ";" &
                           "user id=" & Str_USER_ID & ";" &
                           "password=" & Str_PASSWORD & ";" &
                           "Persist Security Info=true " & ";" &
                           "Connection Timeout=10"

        cDbCn.ConnectionString = ConnectionString

        'mdb 연결
        mDBCn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & gMDbName & ";" &
                                 "User ID=" & gMDbUserNM & ";" &
                                 "Jet OLEDB:Database Password=" & gMDbUserPW & ";"
    End Sub

    Public Sub MSSQL_DBOpen()
        ConnectionString = "data source=" & Str_HOST_IP & ";" &
                           "initial catalog=" & Str_DATABASE_NAME & ";" &
                           "user id=" & Str_USER_ID & ";" &
                           "password=" & Str_PASSWORD & ";" &
                           "Persist Security Info=true " & ";" &
                           "Connection Timeout=10"

        If cMsDbCn.State = ConnectionState.Open Or cMsDbCn.State = ConnectionState.Connecting Then
            cMsDbCn.Close()
        End If

        cMsDbCn.ConnectionString = ConnectionString

        cMsDbCn.Open()

    End Sub

    Public Sub ORACLE_DBOpen()

        ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" &
                           "(HOST=" & Str_HOST_IP & ")" &
                           "(PORT=" & Str_HOST_PORT & ")))" &
                           "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" & Str_DATABASE_NAME & ")));" &
                           "User ID=" & Str_USER_ID & ";" &
                           "Password=" & Str_PASSWORD & ";" &
                           "Connection Timeout=10;"

        If cOraDbCn.State = ConnectionState.Open Or cOraDbCn.State = ConnectionState.Connecting Then
            cOraDbCn.Close()
        End If

        cOraDbCn.ConnectionString = ConnectionString

        cOraDbCn.Open()

    End Sub

    Public Function CfDatabaseName() As String
        Return cDbCn.Database
    End Function

    Public Function CfDatabaseOpen() As Boolean
        Try
            If cDbCn.State = ConnectionState.Open OrElse cDbCn.State = ConnectionState.Connecting Then
                cDbCn.Close()
            End If

            cDbCn.Open()

            Return True

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try
    End Function

    Public Function CfMDatabaseOpen() As Boolean
        Try
            If mDBCn.State = ConnectionState.Open OrElse mDBCn.State = ConnectionState.Connecting Then
                mDBCn.Close()
            End If

            mDBCn.Open()

            Return True

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "mDB 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try
    End Function

    Public Function CfDatabaseClose() As Boolean
        Try
            If cDbCn.State = ConnectionState.Open Then
                cDbCn.Close()
            End If

            Return True

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try
    End Function

    Public Function CfMDatabaseClose() As Boolean
        Try
            If mDBCn.State = ConnectionState.Open Then
                mDBCn.Close()
            End If

            Return True

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "mDB 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        End Try
    End Function

    Public Function CfSelectQuery(queryStr As String) As DataTable

        If queryStr.Length = 0 Then
            Return Nothing
        End If

        Dim sAdapter As SqlDataAdapter, sTable As New DataTable, sReturn As Boolean
        Try
            If CfDatabaseOpen() Then

                sAdapter = New SqlDataAdapter(queryStr, cDbCn)
                sAdapter.Fill(sTable)

                sReturn = True
            Else
                sReturn = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CfDatabaseClose()

        If sReturn Then
            Return sTable
        Else
            Return Nothing
        End If

    End Function

    Public Function CfMSelectQuery(queryStr As String) As DataTable
        If queryStr.Length = 0 Then
            Return Nothing
        End If

        Dim sAdapter As OleDbDataAdapter, sTable As New DataTable, sReturn As Boolean

        Try
            If CfMDatabaseOpen() Then

                sAdapter = New OleDbDataAdapter(queryStr, mDBCn)
                sAdapter.Fill(sTable)

                sReturn = True
            Else
                sReturn = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CfMDatabaseClose()

        If sReturn Then
            Return sTable
        Else
            Return Nothing
        End If

    End Function

    Public Function CfExecuteQuery(queryStr As String) As Boolean
        If queryStr.Length = 0 Then
            Return False
        End If

        Dim sReturn As Boolean
        Try
            If CfDatabaseOpen() Then
                Dim sCommand As SqlCommand, sReturnCnt As Integer = 0

                sCommand = New SqlCommand(queryStr, cDbCn)
                sReturnCnt = sCommand.ExecuteNonQuery

                sReturn = (sReturnCnt <> 0)
            Else
                sReturn = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CfDatabaseClose()
        Return sReturn
    End Function

    Public Function CfMExecuteQuery(queryStr As String) As Boolean
        If queryStr.Length = 0 Then
            Return False
        End If

        Dim sReturn As Boolean
        Try
            If CfMDatabaseOpen() Then
                Dim sCommand As OleDbCommand, sReturnCnt As Integer = 0

                sCommand = New OleDbCommand(queryStr, mDBCn)
                sReturnCnt = sCommand.ExecuteNonQuery

                sReturn = (sReturnCnt <> 0)
            Else
                sReturn = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CfMDatabaseClose()
        Return sReturn
    End Function



    Public Function CfMultiExecuteQuery(queryStr() As String) As Boolean
        If queryStr.Length = 0 Then
            Return False
        End If

        Dim sCommand As SqlCommand, sTrans As SqlTransaction
        Dim sCnt As Integer = 0, sReturn As Boolean = False

        Try
            If CfDatabaseOpen() Then
                sTrans = cDbCn.BeginTransaction()
                sCommand = cDbCn.CreateCommand()
                sCommand.Connection = cDbCn
                sCommand.Transaction = sTrans

                For sCnt = 0 To queryStr.Length - 1
                    'sCommand = New SqlCommand(queryStr(sCnt), cDbCn)
                    If queryStr(sCnt).Length > 0 Then
                        Try
                            sCommand.CommandText = queryStr(sCnt)
                            sCommand.ExecuteNonQuery()
                            sReturn = True
                        Catch ex As Exception
                            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            XtraMessageBox.Show(ex.Message, "데이터베이스 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
            sReturn = False
        End Try

        Call CfDatabaseClose()
        Return sReturn
    End Function

End Class
