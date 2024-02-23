Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmUserAdd
    Dim ClsDb As New ClsDatabase
    Dim ClsErrorLog As New ClsErrorsAndEvents
    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        With GridView1
            .OptionsView.ShowGroupPanel = False
            .OptionsSelection.EnableAppearanceFocusedCell = False                                ' 포커스 설정
            .OptionsSelection.MultiSelect = True                                                 ' 다중라인 선택유무
            .OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
            .Columns.Clear()
        End With

        GfColumnSet(GridView1, "아이디", "EMP_ID", 20, "C", , False)
        GfColumnSet(GridView1, "비밀번호", "PASSWD", 20, "C", , False)
        GfColumnSet(GridView1, "사용자명", "EMP_NM", 40, "C", , False)

        Call UserReroadRoutine()

    End Sub

    Private Sub btnPanWork_Click(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles btnPanWork.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "Reroad"
                Call UserReroadRoutine()
            Case "Save"
                Call UserSaveRoutine()
            Case "Delete"
                Call UserDeleteRoutine()
            Case "Close"
                Call PtScreenClose()
        End Select
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick

        Try
            If e.Button = MouseButtons.Left Then ' 왼쪽 마우스 버튼 클릭인 경우에만 처리
                ' 클릭된 행의 데이터를 가져오기
                Dim focusedRow As Integer = GridView1.FocusedRowHandle

                ' 형식을 Object로 주어 개체 인스턴스 에러 방지
                Dim USERID As Object = GridView1.GetFocusedRowCellValue("EMP_ID")
                Dim USERPW As Object = GridView1.GetFocusedRowCellValue("PASSWD")
                Dim USERNM As Object = GridView1.GetFocusedRowCellValue("EMP_NM")

                If focusedRow >= 0 Then
                    '' NullReferenceException 에러 다시 발생 시 이 코드를 사용
                    'If testCd IsNot Nothing Then
                    '    txtTestCd.Text = testCd.ToString()
                    'Else
                    '    txtTestCd.Text = ""
                    'End If
                    txtID.Text = USERID.ToString().Trim()
                    txtPW.Text = USERPW.ToString().Trim()
                    txtNM.Text = USERNM.ToString().Trim()

                End If

            End If
        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try

    End Sub

    Private Sub UserReroadRoutine()
        Try
            SplashWaitForm.ShowWaitForm()

            QueryString = String.Empty
            QueryString &= "SELECT * FROM m2i_LAB001 " & vbNewLine
            QueryString &= "ORDER BY EMP_ID          "

            grdUserInfo.DataSource = ClsDb.CfMSelectQuery(QueryString)

            SplashWaitForm.CloseWaitForm()

            Call UserScreenClear()

        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try

    End Sub

    Private Sub UserScreenClear()
        txtID.Text = String.Empty
        txtPW.Text = String.Empty
        txtNM.Text = String.Empty
    End Sub

    Private Sub PtScreenClose()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UserSaveRoutine()
        Dim sReturn As Boolean = False

        Try
            If txtID.Text.Length = 0 Or txtPW.Text.Length = 0 Or txtNM.Text.Length = 0 Then
                XtraMessageBox.Show(_sMsg.sMsg_InputInfo, _sMsg_Title.sMsgTitle_Info, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            QueryString = String.Empty
            QueryString &= "SELECT EMP_ID FROM m2i_LAB001 WHERE EMP_ID = '" & txtID.Text & "'"

            Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

            If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                QueryString = String.Empty
                QueryString &= "UPDATE [m2i_LAB001] SET                                       " & vbNewLine
                QueryString &= "       [PASSWD]          = '" & txtPW.Text & "',              " & vbNewLine
                QueryString &= "       [EMP_NM]          = '" & txtNM.Text & "'               " & vbNewLine
                QueryString &= " WHERE [EMP_ID]          = '" & txtID.Text & "'               "
                Debug.Print(QueryString)
            Else
                QueryString = String.Empty
                QueryString &= " INSERT INTO [m2i_LAB001]                                     " & vbNewLine
                QueryString &= " (                                                            " & vbNewLine
                QueryString &= "        [EMP_ID],                                             " & vbNewLine
                QueryString &= "        [PASSWD],                                             " & vbNewLine
                QueryString &= "        [EMP_NM]                                              " & vbNewLine
                QueryString &= " )                                                            " & vbNewLine
                QueryString &= " VALUES                                                       " & vbNewLine
                QueryString &= " (                                                            " & vbNewLine
                QueryString &= "       '" & txtID.Text & "',                                  " & vbNewLine
                QueryString &= "       '" & txtPW.Text & "',                                  " & vbNewLine
                QueryString &= "       '" & txtNM.Text & "'                                   " & vbNewLine
                QueryString &= " )                                                            " & vbNewLine
                Debug.Print(QueryString)
            End If

            If QueryString.Length > 0 Then
                sReturn = ClsDb.CfMExecuteQuery(QueryString)
            End If

            If sReturn Then
                XtraMessageBox.Show(_sMsg.sMsg_Save, _sMsg_Title.sMsgTitle_Save, MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' 저장 후 필요한 작업 수행
                Call UserReroadRoutine()
                Call UserScreenClear()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try


    End Sub

    Private Sub UserDeleteRoutine()

        Dim sReturn As Boolean = False
        Try
            QueryString = String.Empty
            QueryString &= "DELETE FROM m2i_LAB001 WHERE EMP_ID = '" & txtID.Text & "' "

            If QueryString.Length > 0 Then
                sReturn = ClsDb.CfMExecuteQuery(QueryString)
            End If

            If sReturn Then
                XtraMessageBox.Show(_sMsg.sMsg_Delete, _sMsg_Title.sMsgTitle_Delete, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Call UserReroadRoutine()
                Call UserScreenClear()
            End If
        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try

    End Sub

    Private Sub frmUserAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub
End Class