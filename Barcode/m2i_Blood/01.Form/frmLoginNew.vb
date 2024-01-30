Imports DevExpress.Skins
Imports DevExpress.XtraEditors

Public Class frmLoginNew

    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents

    ' ClsClsDatabase 클래스 불러오는 변수
    Private ClsDb As New ClsDatabase

    ' 패스워드 오기입 시 카운트 변수
    Private invalidPswdCount As Integer = 0

    ' 아이디 저장 체크 유무 변수
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
        My.Settings.UserSkin = "Office 2019 Colorful"
        cboSkin.Text = My.Settings.UserSkin

        lblUsernm.Text = String.Empty

        '이미지 로드
        picLogin.Load(Application.StartupPath & "\AD_LOGIN.jpg")

        IsClick = IIf(ReadReg("Login Check") = "True", True, False)
        chkSaveYN.Checked = IsClick


        If chkSaveYN.Checked = True Then
            txtUserID.Text = ReadReg("Login ID")
            txtPassword.Text = ReadReg("Login PW")
        End If

        txtUserID.Focus()

    End Sub

#Region "아이디 입력 후 커서가 비밀번호 입력으로 갈 때"
    Private Sub txtUserID_Leave(sender As Object, e As EventArgs) Handles txtUserID.Leave

        Dim sReturn As Boolean = False
        Dim sTable As DataTable

        Try

            If txtUserID.Text.Length > 0 Then

                QueryString = String.Empty
                QueryString &= " SELECT [EMP_ID], [EMP_NM], [PASSWD] FROM [m2i_LAB001]       " & vbCrLf
                QueryString &= " WHERE 1 = 1                                                 " & vbCrLf
                QueryString &= " AND [EMP_ID] = '" & txtUserID.Text & "'                     "

                Debug.Print(QueryString)

                sTable = ClsDb.CfMSelectQuery(QueryString)

                If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                    gUserID = sTable.Rows(0)("EMP_ID").ToString
                    gUserNM = sTable.Rows(0)("EMP_NM").ToString
                    gUserPASSWD = sTable.Rows(0)("PASSWD").ToString

                    lblUsernm.Text = gUserNM
                Else
                    lblUsernm.Text = String.Empty

                    txtUserID.Focus()

                    XtraMessageBox.Show(_sMsg.sMsg_NoID, _sMsg_Title.sMsgTitle_NoID, MessageBoxButtons.OK, MessageBoxIcon.Error)

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "로그인 버튼 클릭 후 패스워드 오기입 시 이벤트"
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
                    Call SaveReg("Login PW", txtPassword.Text)
                    Call SaveReg("Login Check", IsClick)
                Else
                    Call SaveReg("Login ID", String.Empty)
                    Call SaveReg("Login PW", String.Empty)
                    Call SaveReg("Login Check", IsClick)
                End If

                ' ID/PW 체크 후 개인정보동의서폼 출력

                If Personal_Info_Agree_YN(txtUserID.Text) <> "" Then
                    Me.DialogResult = DialogResult.Yes
                    Me.Hide()

                Else

                    With frmPersonInfoAgree

                        .StartPosition = FormStartPosition.CenterScreen
                        .TopMost = True
                        .ShowDialog()

                    End With

                    If frmPersonInfoAgree.DialogResult = DialogResult.Yes Then
                        Me.DialogResult = DialogResult.Yes
                        Me.Hide()
                    End If

                End If
                frmMainNew.Show()

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
#End Region

    Private Sub cboSkin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSkin.SelectedIndexChanged
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = cboSkin.Text
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

    Private Sub CmdNewUser_Click(sender As Object, e As EventArgs) Handles CmdNewUser.Click
        frmUserAdd.Show()
    End Sub

#Region "Enter 키로 텍스트에딧 넘기는 이벤트 "
    Private Sub txtUserID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter And txtPassword.Text <> "" Then
            CmdLogin.PerformClick()
        End If
    End Sub
#End Region

    Private Sub frmLoginNew_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.DialogResult = DialogResult.Cancel
    End Sub

End Class