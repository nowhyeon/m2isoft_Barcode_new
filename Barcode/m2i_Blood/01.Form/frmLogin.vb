Imports DevExpress.Skins
Imports DevExpress.XtraEditors
Imports System.IO
Imports System.Net

Public Class frmLogin

    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase
    Private sUserName As String = ""
    Private sPassword As String = ""

    Private invalidPswdCount As Integer = 0

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim sMsg As String

        invalidPswdCount += 1

        Try

            If invalidPswdCount <= validPswdCount And txtPW.Text.Length > 0 And gUserPASSWD = txtPW.Text Then

                Me.DialogResult = DialogResult.Cancel
                Me.Hide()

                frmMDI.Show()
            Else
                txtPW.Text = String.Empty
                txtPW.Focus()

                sMsg = "비밀번호가 틀렸습니다."
                XtraMessageBox.Show(sMsg, "비밀번호 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Catch ex As Exception
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try
    End Sub

    Private Sub frmLogin_Closed(sender As Object, e As EventArgs) Handles Me.Closed, MyBase.FormClosed
        Me.DialogResult = DialogResult.Cancel
    End Sub


    Private Sub txtID_Leave(sender As Object, e As EventArgs) Handles txtID.Leave

        Dim sReturn As Boolean = False

        Try
            If layoutcontrolitem1.Text.Length > 0 Then
                gUserID = txtID.Text

                QueryString = String.Empty
                QueryString &= " SELECT EMP_ID, EMP_NM, PASSWD FROM m2i_LAB001" & vbCrLf
                QueryString &= "  WHERE EMP_ID = '" & txtID.Text & "'"

                Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)
                If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then

                    lblUser.Text = sTable.Rows(0)("EMP_NM").ToString
                    gUserNM = sTable.Rows(0)("EMP_NM").ToString
                    gUserPASSWD = sTable.Rows(0)("PASSWD").ToString

                Else
                    Dim sMsg As String = "등록되지 않은 아이디입니다 !", sMsgTitle As String = "아이디 오류"
                    XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtID_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

        End If

    End Sub

    Private Sub lblLink_Click(sender As Object, e As EventArgs) Handles lblLink.Click
        Process.Start("IExplore.exe", "http://m2isoft.com/")
    End Sub

End Class