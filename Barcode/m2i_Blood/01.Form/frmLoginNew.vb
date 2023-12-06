Imports DevExpress.Skins
Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net

Public Class frmLoginNew

    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase
    Private sUserNm As String = String.Empty
    Private sPw As String = String.Empty

    Private invalidPswdCount As Integer = 0

    Private IsClick As Boolean = False

    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        Me.StartPosition = FormStartPosition.CenterScreen
        txtUserID.Focus()


    End Sub

    Private Sub frmLoginNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DevExpress.UserSkins.BonusSkins.Register()                  ' Dev 확장 Skin

        For Each sCnt As SkinContainer In SkinManager.Default.Skins
            cboSkin.Properties.Items.Add(sCnt.SkinName)
        Next
        My.Settings.UserSkin = "DevExpress Style"
        cboSkin.Text = My.Settings.UserSkin

        lblUsernm.Text = String.Empty

        '이미지 로드
        picLogin.Load(Application.StartupPath & "\AD_LOGIN.jpg")

        IsClick = IIf(ReadReg("Login Check") = "True", True, False)
        chkSaveYN.Checked = IsClick

        Application.DoEvents()

        If chkSaveYN.Checked = True Then
            txtUserID.Text = ReadReg("Login ID")
        End If


    End Sub

    Private Sub CmdLogin_Click(sender As Object, e As EventArgs) Handles CmdLogin.Click

        invalidPswdCount += 1

        Try
            If invalidPswdCount <= validPswdCount And txtPassword.Text.Length > 0 And gUserPASSWD = txtPassword.Text Then

                My.Settings.UserSkin = cboSkin.Text
                My.Settings.Save()

                Me.DialogResult = DialogResult.Cancel
                Me.Hide()

                If IsClick = True Then
                    Call SaveReg("Login ID", txtUserID.Text)
                    Call SaveReg("Login Check", IsClick)
                Else
                    Call SaveReg("Login ID", String.Empty)
                    Call SaveReg("Login Check", IsClick)
                End If

                frmMDI.Show()

            ElseIf invalidPswdCount > validPswdCount Then
                Application.Exit()
            Else

                txtPassword.Text = String.Empty
                txtPassword.Focus()

                XtraMessageBox.Show(_sMsg.sMsg_NoPw & "(" & validPswdCount + 1 & "번 중 " & invalidPswdCount & "번)", _sMsg_Title.sMsgTitle_NoPw, MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        Catch ex As Exception
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try
    End Sub

    Private Sub cboSkin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSkin.SelectedIndexChanged
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = cboSkin.Text
    End Sub

    Private Sub frmLoginNew_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub txtUserID_Leave(sender As Object, e As EventArgs) Handles txtUserID.Leave, MyBase.Load

        Dim sReturn As Boolean = False
        Dim searchString As String = "@"

        Try

            If txtUserID.Text.Length > 0 Then
                gUserID = txtUserID.Text

                QueryString = String.Empty
                QueryString &= " SELECT EMP_ID, EMP_NM, PASSWD FROM m2i_LAB001       " & vbCrLf
                QueryString &= "  WHERE 1 = 1                                        " & vbCrLf

                If InStr(txtUserID.Text, searchString) Then
                    QueryString &= "    AND EMP_ID    = '" & txtUserID.Text & "'     "
                End If

                Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

                If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                    gUserID = sTable.Rows(0)("EMP_ID").ToString
                    gUserNM = sTable.Rows(0)("EMP_NM").ToString
                    gUserPASSWD = sTable.Rows(0)("PASSWD").ToString

                    lblUsernm.Text = sTable.Rows(0)("EMP_NM").ToString

                Else
                    XtraMessageBox.Show(_sMsg.sMsg_NoID, _sMsg_Title.sMsgTitle_NoID, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkSaveYN_Click(sender As Object, e As EventArgs) Handles chkSaveYN.Click
        If IsClick = True Then
            IsClick = False
        Else
            IsClick = True
        End If
    End Sub

    Private Sub LabelControl2_Click(sender As Object, e As EventArgs) Handles LabelControl2.Click
        Process.Start("IExplore.exe", "http://m2isoft.com/")
    End Sub
End Class