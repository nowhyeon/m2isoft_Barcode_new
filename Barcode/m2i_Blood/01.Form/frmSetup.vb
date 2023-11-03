Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraBars.Docking2010

Public Class frmSetup

    Dim ClsDb As New ClsDatabase
    Dim ClsErrorLog As New ClsErrorsAndEvents

    Public Sub New()

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

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
        GfColumnSet(GridView, "검사분야", "WorkArea", 5, "D", True, True, "S", 0)
        GfColumnSet(GridView, "채혈용기", "BloodTube", 5, "D", True, True, "S", 0)
        GfColumnSet(GridView, "바코드 출력 장수", "PrintAdd", 5, "D", True, True, "S", 0)
        GfColumnSet(GridView, "특이사항", "Remark", 20, "D", True, True, "S", 0)
        GfColumnSet(GridView, "바코드분류", "BarcodeDivision", 20, "D", True, True, "S", 0)

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

        QueryString = ""
        QueryString &= "DELETE FROM m2i_LAB002 WHERE TESTCD = '" & txtTestCd.Text & "' "

        If QueryString.Length > 0 Then
            sReturn = ClsDb.CfMExecuteQuery(QueryString)
        End If

        If sReturn Then
            XtraMessageBox.Show(_sMsg_Question.sMsgQst_Delete, _sMsg_Title.sMsgTitle_Info, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            XtraMessageBox.Show(_sMsg.sMsg_Save, _sMsg_Title.sMsgTitle_Save, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call PtReroadRoutine()
            Call PtScreenClear()
        End If
    End Sub

    Private Sub PtSaveRoutine() ' 검사항목 저장 및 수정 기능(올인원)
        Dim sReturn As Boolean = False

        If txtTestCd.Text.Length = 0 Then
            Exit Sub
        End If

        QueryString = ""
        QueryString &= "SELECT TESTCD FROM m2i_LAB002                           " & vbNewLine
        QueryString &= " WHERE TESTCD = '" & txtTestCd.Text & "'                " & vbNewLine
        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count >= 0 Then
            QueryString = ""
            QueryString &= "UPDATE m2i_LAB002 SET                                        " & vbNewLine
            QueryString &= "       TESTNM          = '" & txtTestNm.Text & "',           " & vbNewLine
            QueryString &= "       TestNm_10       = '" & txtTestNm_10.Text & "',        " & vbNewLine
            QueryString &= "       WorkArea        = '" & txtWorkArea.Text & "',         " & vbNewLine
            QueryString &= "       BloodTube       = '" & txtBloodTube.Text & "',        " & vbNewLine
            QueryString &= "       PrintAdd        = '" & txtPrtCnt.Text & "',           " & vbNewLine
            QueryString &= "       Remark          = '" & txtRemark.Text & "',           " & vbNewLine
            QueryString &= "       BarcodeDivision = '" & txtBarcodeDivision.Text & "'  " & vbNewLine
            QueryString &= " WHERE TESTCD          = '" & txtTestCd.Text & "'"
        Else
            QueryString = ""
            QueryString &= "INSERT INTO m2i_LAB002 (TESTCD, TESTNM, TestNm_10, WorkArea, BloodTube, PrintAdd, Remark, BarcodeDivision) VALUES ( "
            QueryString &= "       '" & txtTestCd.Text & "',                             " & vbNewLine
            QueryString &= "       '" & txtTestNm.Text & "',                             " & vbNewLine
            QueryString &= "       '" & txtTestNm_10.Text & "',                          " & vbNewLine
            QueryString &= "       '" & txtWorkArea.Text & "',                           " & vbNewLine
            QueryString &= "       '" & txtBloodTube.Text & "',                          " & vbNewLine
            QueryString &= "       '" & txtPrtCnt.Text & "',                             " & vbNewLine
            QueryString &= "       '" & txtRemark.Text & "',                             " & vbNewLine
            QueryString &= "       '" & txtBarcodeDivision.Text & "')                    "

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
            Dim sWorkLog As String = " TestList Searching."

            'Call GsWorkLog(Me.Name.ToString, LogEvent._search, sWorkLog)

            QueryString = ""
            QueryString &= "SELECT * FROM m2i_LAB002 " & vbNewLine
            QueryString &= " ORDER BY TESTCD         "

            grdTestList.DataSource = ClsDb.CfMSelectQuery(QueryString)
            Call PtScreenClear()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "새로고침 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PtScreenClear()
        txtTestCd.Text = ""
        txtTestNm.Text = ""
        txtTestNm_10.Text = ""
        txtWorkArea.Text = ""
        txtBloodTube.Text = ""
        txtPrtCnt.Text = ""
        txtRemark.Text = ""
        txtBarcodeDivision.Text = ""
        txtTestCd.Text = ""
    End Sub

    Private Sub PtScreenClose()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub grdTestList_Click(sender As Object, e As EventArgs) Handles grdTestList.Click
        Dim sSelectRow As Integer = GridView.FocusedRowHandle

        If sSelectRow < 0 Then
            Return
        End If

        With GridView
            txtTestCd.Text = .GetRowCellValue(sSelectRow, "TESTCD").ToString()
            txtTestNm.Text = .GetRowCellValue(sSelectRow, "TESTNM").ToString()
            txtTestNm_10.Text = .GetRowCellValue(sSelectRow, "TestNm_10").ToString()
            txtWorkArea.Text = .GetRowCellValue(sSelectRow, "WorkArea").ToString()
            txtBloodTube.Text = .GetRowCellValue(sSelectRow, "BloodTube").ToString()
            txtPrtCnt.Text = .GetRowCellValue(sSelectRow, "PrintAdd").ToString()
            txtRemark.Text = .GetRowCellValue(sSelectRow, "Remark").ToString()
            txtBarcodeDivision.Text = .GetRowCellValue(sSelectRow, "BarcodeDivision").ToString()
        End With
    End Sub

    Private Sub GroupControl1_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub gcTestList_Paint(sender As Object, e As PaintEventArgs) Handles gcTestList.Paint

    End Sub
End Class