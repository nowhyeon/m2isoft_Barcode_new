Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

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

        GfColumnSet(GridView, "검사코드", "TESTCD", 15, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "검사이름", "TESTNM", 5, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "검사약어", "TESTNM_10", 5, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "검사분야", "WorkArea", 5, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "채혈용기", "BloodTube", 5, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "바코드 출력 장수", "PrintAdd", 5, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "특이사항", "Remark", 20, "D", True, True, "S", 0, False, Nothing, False, False)
        GfColumnSet(GridView, "바코드분류", "BarcodeDivsion", 10, "D", True, True, "S", 0, False, Nothing, False, False)

        grdTestList.Dock = DockStyle.Fill

    End Sub


    Private Sub PtSaveRoutine()                     ' 검사항목 저장 및 수정 기능(올인원)

        Dim sTable As DataTable = CType(grdTestList.DataSource, DataTable).GetChanges()
        ' grdTestList의 데이터원본을 DataTable로 변환 후 변경된 데이터를 가져옴
        Dim sReturn As Boolean
        Dim sCode As String = ""
        Dim sWorkLog As String = ""

        Try
            If Not IsNothing(sTable) Then
                For Each sDataRow As DataRow In sTable.Rows
                    QueryString = ""
                    If sDataRow.RowState = DataRowState.Added Then
                        QueryString &= "INSERT INTO m2i_LAB002                                 " & vbNewLine
                        QueryString &= "     ( TESTCD                                          " & vbNewLine
                        QueryString &= "     , TESTNM                                          " & vbNewLine
                        QueryString &= "     , TestNM_10                                       " & vbNewLine
                        QueryString &= "     , WorkArea                                        " & vbNewLine
                        QueryString &= "     , BloodTube                                       " & vbNewLine
                        QueryString &= "     , PrintAdd                                        " & vbNewLine
                        QueryString &= "     , Remark                                          " & vbNewLine
                        QueryString &= "     , BarcodeDivision ) VALUES (                      " & vbNewLine
                        QueryString &= "       '" & sDataRow("TESTCD").ToString & "'           " & vbNewLine
                        QueryString &= "     , '" & sDataRow("TESTNM").ToString & "'           " & vbNewLine
                        QueryString &= "     , '" & sDataRow("TestNM_10").ToString & "'        " & vbNewLine
                        QueryString &= "     , '" & sDataRow("WorkArea").ToString & "'         " & vbNewLine
                        QueryString &= "     , '" & sDataRow("BloodTube").ToString & "'        " & vbNewLine
                        QueryString &= "     , '" & sDataRow("PrintAdd").ToString & "'         " & vbNewLine
                        QueryString &= "     , '" & sDataRow("Remark").ToString & "'           " & vbNewLine
                        QueryString &= "     , '" & sDataRow("BarcodeDivision").ToString & "') "

                    ElseIf sDataRow.RowState = DataRowState.Modified Then
                        ' 해당 행의 상태가 수정되었을 때
                        sCode = sDataRow("TESTCD", DataRowVersion.Original).ToString

                        QueryString &= "UPDATE m2i_LAB002 SET                                                    " & vbNewLine
                        QueryString &= "       TESTNM          = '" & sDataRow("TESTNM").ToString & "'           " & vbNewLine
                        QueryString &= "     , TestNM_10       = '" & sDataRow("TestNM_10").ToString & "'        " & vbNewLine
                        QueryString &= "     , WorkArea        = '" & sDataRow("WorkArea").ToString & "'         " & vbNewLine
                        QueryString &= "     , BloodTube       = '" & sDataRow("BloodTube").ToString & "'        " & vbNewLine
                        QueryString &= "     , PrintAdd        = '" & sDataRow("PrintAdd").ToString & "'         " & vbNewLine
                        QueryString &= "     , Remark          = '" & sDataRow("Remark").ToString & "'           " & vbNewLine
                        QueryString &= "     , BarcodeDivision = '" & sDataRow("BarcodeDivision").ToString & "'  " & vbNewLine
                        QueryString &= " WHERE TESTCD          = '" & sDataRow("TESTCD").ToString & "' "

                    ElseIf sDataRow.RowState = DataRowState.Deleted Then
                        ' 해당 행의 상태가 삭제되었을 때
                        sCode = sDataRow("TESTCD", DataRowVersion.Original).ToString

                        QueryString &= "DELETE FROM m2i_LAB002 WHERE TESTCD = '" & sDataRow("TESTCD").ToString & "' "

                    End If

                    If QueryString.Length > 0 Then
                        sReturn = ClsDb.CfMExecuteQuery(QueryString)
                        If sReturn = False Then
                            Exit For
                        End If
                    End If
                Next

            End If

            If sReturn Then

                Dim sMsg As String = "성공적으로 저장되었습니다.", sMsgTitle As String = "저장 완료"
                XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "저장 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PtReroadRoutine()
        Try
            Dim sWorkLog As String = " TestList Searching."

            'Call GsWorkLog(Me.Name.ToString, LogEvent._search, sWorkLog)

            QueryString = ""
            QueryString &= "SELECT * FROM m2i_LAB002 " & vbNewLine
            QueryString &= " ORDER BY TESTCD         "

            grdTestList.DataSource = ClsDb.CfMSelectQuery(QueryString)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "새로고침 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Private Sub Button_Click(sender As Object, e As EventArgs)
    '    If sender Is btnReroad Then
    '        Dim sMsg As String = "새로고침 되었습니다.", sMsgTitle As String = "안내"

    '        Call PtReroadRoutine()
    '        XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    ElseIf sender Is btnDelete Then
    '        GridView.DeleteRow(GridView.FocusedRowHandle)
    '    ElseIf sender Is btnInsert Then
    '        Call PsInsertRoutine()
    '    End If

    'End Sub

    Private Function PsInsertRoutine() As Integer
        GridView.AddNewRow()                                       ' 새로운 행을 추가(편집모드로 전환)
        Dim sNewRow As Integer = GridControl.NewItemRowHandle      ' 신규라인

        Try
            'GridView.SetRowCellValue(sNewRow, "Person", "담당자")
            'GridView.SetRowCellValue(sNewRow, "Zipcd", GridView.RowCount)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "추가 오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return sNewRow
    End Function

    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call PtReroadRoutine()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

        Dim sReturn As Boolean = False

        If txtTestCd.Text.Length = 0 Then
            Exit Sub
        End If


        QueryString = ""
        QueryString &= "SELECT TESTCD FROM m2i_LAB002                             " & vbNewLine
        QueryString &= " WHERE TESTCD = '" & txtTestCd.Text & "'                  " & vbNewLine

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count >= 0 Then
            QueryString &= "UPDATE m2i_LAB002 SET                                      " & vbNewLine
            QueryString &= "     , TESTNM          = '" & txtTestNm.Text & "'          " & vbNewLine
            QueryString &= "     , TestNM_10       = '" & txtTestNm_10.Text & "'       " & vbNewLine
            QueryString &= "     , WorkArea        = '" & txtWorkArea.Text & "'        " & vbNewLine
            QueryString &= "     , BloodTube       = '" & txtBloodTube.Text & "'       " & vbNewLine
            QueryString &= "     , PrintAdd        = '" & txtPrtCnt.Text & "'          " & vbNewLine
            QueryString &= "     , Remark          = '" & txtRemark.Text & "'          " & vbNewLine
            QueryString &= "     , BarcodeDivision = '" & txtBarcodeDivision.Text & "' " & vbNewLine
            QueryString &= " WHERE TESTCD          = '" & txtTestCd.Text & "'          " & vbNewLine
        ElseIf Not IsNothing(sTable) AndAlso sTable.Rows.Count = 0 Then
            QueryString &= "INSERT INTO m2i_LAB002                                     " & vbNewLine
            QueryString &= "     ( TESTCD                                              " & vbNewLine
            QueryString &= "     , TESTNM                                              " & vbNewLine
            QueryString &= "     , TestNM_10                                           " & vbNewLine
            QueryString &= "     , WorkArea                                            " & vbNewLine
            QueryString &= "     , BloodTube                                           " & vbNewLine
            QueryString &= "     , PrintAdd                                            " & vbNewLine
            QueryString &= "     , Remark                                              " & vbNewLine
            QueryString &= "     , BarcodeDivision ) VALUES (                          " & vbNewLine
            QueryString &= "       '" & txtTestCd.Text & "'                            " & vbNewLine
            QueryString &= "     , '" & txtTestNm.Text & "'                            " & vbNewLine
            QueryString &= "     , '" & txtTestNm_10.Text & "'                         " & vbNewLine
            QueryString &= "     , '" & txtWorkArea.Text & "'                          " & vbNewLine
            QueryString &= "     , '" & txtBloodTube.Text & "'                         " & vbNewLine
            QueryString &= "     , '" & txtPrtCnt.Text & "'                            " & vbNewLine
            QueryString &= "     , '" & txtRemark.Text & "'                            " & vbNewLine
            QueryString &= "     , '" & txtBarcodeDivision.Text & "' )                 " & vbNewLine

        End If

        If QueryString.Length > 0 Then
            sReturn = ClsDb.CfMExecuteQuery(QueryString)
        End If

        If sReturn Then

            Dim sMsg As String = " 저장되었습니다.", sMsgTitle As String = Me.Text
            XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call PtReroadRoutine()
            Call PtScreenClear()

        End If
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

    Private Sub grdTestList_Click(sender As Object, e As EventArgs) Handles grdTestList.Click
        Dim sSelectRow As Integer = GridView.FocusedRowHandle

        If sSelectRow < 0 Then
            Return
        End If

        With GridView
            txtTestCd.Text = .GetRowCellValue(sSelectRow, "TESTCD").ToString()
            txtTestNm.Text = .GetRowCellValue(sSelectRow, "TESTNM").ToString()
            If sSelectRow < 0 AndAlso sSelectRow >= 0 Then
                txtTestNm_10.Text = .GetRowCellValue(sSelectRow, "TESTNM_10").ToString()
            End If
            txtWorkArea.Text = .GetRowCellValue(sSelectRow, "WorkArea").ToString()
            txtBloodTube.Text = .GetRowCellValue(sSelectRow, "BloodTube").ToString()
            txtPrtCnt.Text = .GetRowCellValue(sSelectRow, "PrintAdd").ToString()
            txtRemark.Text = .GetRowCellValue(sSelectRow, "Remark").ToString()
            txtBarcodeDivision.Text = .GetRowCellValue(sSelectRow, "BarcodeDivision").ToString()
        End With
    End Sub
End Class