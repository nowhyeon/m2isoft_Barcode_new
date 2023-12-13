Imports DevExpress.XtraEditors

Public Class frmMDI
    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase

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
                Dim sMsg As String = "등록된 검사코드가 없습니다 !", sMsgTitle As String = "검사코드 오류"
                XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMain_Click(sender As Object, e As EventArgs) Handles btnMain.Click
        OpenChildForm(New frmMain())
    End Sub

    Private Sub btnTestList_Click(sender As Object, e As EventArgs) Handles btnTestList.Click
        OpenChildForm(New frmSetup())
    End Sub

    Private Sub btnAMH_Click(sender As Object, e As EventArgs) Handles btnAMH.Click
        OpenChildForm(New frmAMHTest())
    End Sub

    Private Sub AccordionControlElement8_Click(sender As Object, e As EventArgs) 
        OpenChildForm(New frmAMHTest2())
    End Sub

    Private Sub frmMDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Get_TestCode()
    End Sub

    Private Sub btnCommunication_click(sender As Object, e As EventArgs) Handles AccordionControlElement7.Click
        frmConfig.Show()
    End Sub

    Private Sub frmMDI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

End Class
