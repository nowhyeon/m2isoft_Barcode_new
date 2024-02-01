Imports DevExpress.XtraEditors

Public Class frmMainNew
    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase

    Private Sub frmMainNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If CommonRead() = False Then
            End
        End If

        Select Case ProgramIndex
            Case 0
                aceAMH.Visible = False
            Case 1
                aceBarcode.Visible = False
        End Select

        BsiWorkDate.Caption = Format(Now, "yyyy-MM-dd")
        BsiUserNM.Caption = frmLoginNew.lblUsernm.Text

    End Sub

    Private Sub aceBarcode_Click(sender As Object, e As EventArgs) Handles aceBarcode.Click
        PtFormShow(frmBarcode, sender)
    End Sub

    Private Sub aceAMH_Click(sender As Object, e As EventArgs) Handles aceAMH.Click
        PtFormShow(frmAMHTest, sender)
    End Sub

    Private Sub aceTestCode_Click(sender As Object, e As EventArgs) Handles aceTestCode.Click
        PtFormShow(frmSetup, sender)
    End Sub

    Private Sub aceComm_Click(sender As Object, e As EventArgs) Handles aceComm.Click
        frmConfig.Show()
    End Sub

    Private Sub frmMainNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing
        If XtraMessageBox.Show(_sMsg.sMsg_Exit, _sMsg_Title.sMsgTitle_Exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
        Else
            End
        End If
    End Sub

    Private Sub aceRemote_Click(sender As Object, e As EventArgs) Handles aceRemote.Click
        frmRemote.Show()
    End Sub

    Private Sub aceUser_Click(sender As Object, e As EventArgs) Handles aceUser.Click
        frmUserAdd.Show()
    End Sub

    'mDB에서 검사코드 가져온다
    Public Sub Get_TestCode()
        Try
            QueryString = String.Empty
            QueryString &= " SELECT TESTCD, TESTNM  " & vbCrLf
            QueryString &= " FROM m2i_LAB002        " & vbCrLf
            QueryString &= " WHERE 1 = 1            " & vbCrLf
            QueryString &= " ORDER BY TESTCD        " & vbCrLf


            Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)
            ' mDB의 TESTCD의 정보를 가져와서 sTable이라는 테이블에 저장

            ' sTable에 없는 검사코드가 있을 때
            If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                For Each row As DataRow In sTable.Rows
                    gTestCode &= "'" & row(1).ToString & "',"
                Next
                gTestCode = Mid(gTestCode, 1, Len(gTestCode) - 1)
            Else
                XtraMessageBox.Show(_sMsg.sMsg_NoTestCode, _sMsg_Title.sMsgTitle_TestCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try
    End Sub

    Private Sub PtFormShow(_frmname As XtraForm, sender As Object)

        Me.Cursor = Cursors.AppStarting
        Try

            _frmname.Text = sender.text
            _frmname.MdiParent = Me

            TabView.AddDocument(_frmname)
            TabView.ActivateDocument(_frmname)

            _frmname.Show()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

End Class