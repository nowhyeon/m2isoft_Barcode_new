Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmSetup

    Dim ClsDb As New ClsDatabase
    Dim ClsErrorLog As New ClsErrorsAndEvents

    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

        LookUpSet(lupBloodTube)

        Me.StartPosition = FormStartPosition.CenterScreen                             ' 폼이 나올 때 중간에 위치

        With GridView
            .OptionsView.ShowGroupPanel = False                                       ' 그룹화 패널 표시 안함
            .OptionsSelection.EnableAppearanceFocusedCell = False                     ' 셀의 포커스 설정
            .OptionsSelection.MultiSelect = True                                      ' 다중라인 활성화
            .OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect         ' 그리드셀을 클릭 후 선택 가능

            .Columns.Clear()                                                          ' 그리드의 모든 열을 삭제
        End With

        '원래 형식 GfColumnSet(GridView, "검사코드", "TESTCD", 15, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "검사코드", "TESTCD", 15, "D", True, True, "S", 0)
        GfColumnSet(GridView, "검사이름", "TESTNM", 25, "D", True, True, "S", 0)
        GfColumnSet(GridView, "검사약어", "TestNm_10", 5, "D", True, True, "S", 0)
        GfColumnSet(GridView, "채혈용기", "BloodTube", 5, "D", True, True, "S", 0)
        GfColumnSet(GridView, "WorkArea", "WorkArea", 5, "D", True, True, "S", 0)
        GfColumnSet(GridView, "바코드 출력 장수", "PrintAdd", 5, "D", True, True, "S", 0)
        GfColumnSet(GridView, "특이사항", "Remark", 20, "D", True, True, "S", 0)
        GfColumnSet(GridView, "비고", "Note", 20, "D", True, True, "S", 0)

    End Sub

    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call PtReroadRoutine()

    End Sub

    Private Sub CommandButton_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles btnPanWork.ButtonClick

        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "Reroad"
                Call PtReroadRoutine()
            Case "Save"
                Call PtSaveRoutine()
            Case "Delete"
                Call PtDeleteRoutine()
            Case "Close"
                Call PtScreenClose()
        End Select
    End Sub

    Private Sub PtDeleteRoutine()

        Dim sReturn As Boolean = False

        QueryString = String.Empty
        QueryString &= "DELETE FROM m2i_LAB004 WHERE TESTCD = '" & txtTestCd.Text & "' "

        If QueryString.Length > 0 Then
            sReturn = ClsDb.CfMExecuteQuery(QueryString)
        End If

        If sReturn Then
            If XtraMessageBox.Show(_sMsg_Question.sMsgQst_Delete, _sMsg_Title.sMsgTitle_Info, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                XtraMessageBox.Show(_sMsg.sMsg_Delete, _sMsg_Title.sMsgTitle_Delete, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Call PtReroadRoutine()
                Call PtScreenClear()
            End If
        End If
    End Sub

    Private Sub PtSaveRoutine()
        Dim sReturn As Boolean = False

        If txtTestCd.Text.Length = 0 Then
            Exit Sub
        End If

        QueryString = String.Empty
        QueryString &= "SELECT TESTCD FROM m2i_LAB004 WHERE TESTCD = '" & txtTestCd.Text & "'"

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            QueryString = String.Empty
            QueryString &= "UPDATE [m2i_LAB004] SET                                       " & vbNewLine
            QueryString &= "       [TESTNM]          = '" & txtTestNm.Text & "',          " & vbNewLine
            QueryString &= "       [TestNm_10]       = '" & txtTestNm_10.Text & "',       " & vbNewLine
            QueryString &= "       [BloodTube]       = '" & lupBloodTube.EditValue & "',  " & vbNewLine
            QueryString &= "       [WorkArea]        = '" & txtWorkArea.Text & "',        " & vbNewLine
            QueryString &= "       [PrintAdd]        = '" & cboPrtCnt.EditValue & "',     " & vbNewLine
            QueryString &= "       [Remark]          = '" & txtRemark.Text & "',          " & vbNewLine
            QueryString &= "       [Note]            = '" & txtNote.Text & "'             " & vbNewLine
            QueryString &= " WHERE [TESTCD]          = '" & txtTestCd.Text & "'           "
            Debug.Print(QueryString)
        Else
            QueryString = String.Empty
            QueryString &= " INSERT INTO [m2i_LAB004]                                     " & vbNewLine
            QueryString &= " (                                                            " & vbNewLine
            QueryString &= "        [TESTCD],                                             " & vbNewLine
            QueryString &= "        [TESTNM],                                             " & vbNewLine
            QueryString &= "        [TestNm_10],                                          " & vbNewLine
            QueryString &= "        [BloodTube],                                          " & vbNewLine
            QueryString &= "        [WorkArea],                                           " & vbNewLine
            QueryString &= "        [PrintAdd],                                           " & vbNewLine
            QueryString &= "        [Remark],                                             " & vbNewLine
            QueryString &= "        [Note]                                                " & vbNewLine
            QueryString &= " )                                                            " & vbNewLine
            QueryString &= " VALUES                                                       " & vbNewLine
            QueryString &= " (                                                            " & vbNewLine
            QueryString &= "       '" & txtTestCd.Text & "',                              " & vbNewLine
            QueryString &= "       '" & txtTestNm.Text & "',                              " & vbNewLine
            QueryString &= "       '" & txtTestNm_10.Text & "',                           " & vbNewLine
            QueryString &= "       '" & lupBloodTube.EditValue & "',                      " & vbNewLine
            QueryString &= "       '" & txtWorkArea.Text & "',                            " & vbNewLine
            QueryString &= "       '" & cboPrtCnt.EditValue & "',                         " & vbNewLine
            QueryString &= "       '" & txtRemark.Text & "',                              " & vbNewLine
            QueryString &= "       '" & txtNote.Text & "'                                 " & vbNewLine
            QueryString &= " )                                                            " & vbNewLine
            Debug.Print(QueryString)
        End If

        If QueryString.Length > 0 Then
            sReturn = ClsDb.CfMExecuteQuery(QueryString)
        End If

        If sReturn Then
            Dim sMsg As String = "저장되었습니다.", sMsgTitle As String = "저장 완료", sQst As String = "저장 하시겠습니까?"
            XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' 저장 후 필요한 작업 수행
            PtReroadRoutine()
            PtScreenClear()
        End If
    End Sub

    Private Sub PtReroadRoutine()
        Try

            QueryString = String.Empty
            QueryString &= "SELECT * FROM m2i_LAB004 " & vbNewLine
            QueryString &= " ORDER BY TESTCD         "

            grdTestList.DataSource = ClsDb.CfMSelectQuery(QueryString)
            Call PtScreenClear()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "새로고침 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PtScreenClear()
        txtTestCd.Text = String.Empty
        txtTestNm.Text = String.Empty
        txtTestNm_10.Text = String.Empty
        lupBloodTube.EditValue = String.Empty
        txtWorkArea.Text = String.Empty
        cboPrtCnt.EditValue = String.Empty
        txtRemark.Text = String.Empty
        txtNote.Text = String.Empty
    End Sub

    Private Sub PtScreenClose()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub grdTestList_Click(sender As Object, e As EventArgs) Handles grdTestList.Click

        Dim sSelectRow As Integer = GridView.FocusedRowHandle

        If sSelectRow < 0 Then
            Return
        ElseIf sSelectRow >= 0 Then
            With GridView
                txtTestCd.Text = .GetRowCellValue(sSelectRow, "TESTCD").ToString()
                txtTestNm.Text = .GetRowCellValue(sSelectRow, "TESTNM").ToString()
                txtTestNm_10.Text = .GetRowCellValue(sSelectRow, "TestNm_10").ToString()
                If .GetRowCellValue(sSelectRow, "BloodTube").ToString() = "" Then
                    lupBloodTube.EditValue = 0
                Else
                    lupBloodTube.EditValue = .GetRowCellValue(sSelectRow, "BloodTube").ToString
                End If
                txtWorkArea.Text = .GetRowCellValue(sSelectRow, "WorkArea").ToString
                cboPrtCnt.EditValue = .GetRowCellValue(sSelectRow, "PrintAdd").ToString()
                txtRemark.Text = .GetRowCellValue(sSelectRow, "Remark").ToString()
                txtNote.Text = .GetRowCellValue(sSelectRow, "Note").ToString()
            End With

        End If

    End Sub

    Private Sub txtTestCd_EditValueChanged(sender As Object, e As EventArgs) Handles txtTestCd.EditValueChanged

        QueryString = String.Empty
        QueryString &= "SELECT * FROM m2i_LAB004 WHERE TESTCD = '" & txtTestCd.Text & "'"

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        ' TestCode를 입력했을 때 Search 기능
        If sTable.Rows.Count > 0 Then
            txtTestNm.Text = sTable.Rows(0)(1).ToString()
            txtTestNm_10.Text = sTable.Rows(0)(2).ToString()
            If sTable.Rows(0)(3).ToString() = "" Then
                lupBloodTube.EditValue = 0
            Else
                lupBloodTube.EditValue = sTable.Rows(0)(3).ToString()
            End If
            txtWorkArea.Text = sTable.Rows(0)(4).ToString()
            cboPrtCnt.EditValue = sTable.Rows(0)(5).ToString()
            txtRemark.Text = sTable.Rows(0)(6).ToString()
            txtNote.Text = sTable.Rows(0)(7).ToString()

        End If
    End Sub

    Private Sub txtTestNm_EditValueChanged(sender As Object, e As EventArgs) Handles txtTestNm.EditValueChanged
        QueryString = String.Empty
        QueryString &= "SELECT * FROM m2i_LAB004 WHERE TESTNM = '" & txtTestNm.Text & "'"

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        ' TestCode를 입력했을 때 Search 기능
        If sTable.Rows.Count > 0 Then
            txtTestCd.Text = sTable.Rows(0)(0).ToString()
            txtTestNm_10.Text = sTable.Rows(0)(2).ToString()
            If sTable.Rows(0)(3).ToString() = "" Then
                lupBloodTube.EditValue = 0
            Else
                lupBloodTube.EditValue = sTable.Rows(0)(3).ToString()
            End If
            txtWorkArea.Text = sTable.Rows(0)(4).ToString()
            cboPrtCnt.EditValue = sTable.Rows(0)(5).ToString()
            txtRemark.Text = sTable.Rows(0)(6).ToString()
            txtNote.Text = sTable.Rows(0)(7).ToString()

        End If
    End Sub
End Class