Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmBarcode
    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase
    Public Hospital_DB As New ClsOrder
    Private SearchEnabled As Boolean = False

    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다. 'test
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen

        With GridView
            .OptionsView.ShowGroupPanel = False
            .OptionsSelection.EnableAppearanceFocusedCell = False                                ' 포커스 설정
            .OptionsSelection.MultiSelect = True                                                 ' 다중라인 선택유무
            '.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect                 ' 선택모드(일반)  
            .OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect          ' 선택모드(체크박스)
            .OptionsSelection.CheckBoxSelectorColumnWidth = 40

            .Columns.Clear()
        End With
        GfColumnSet(GridView, "차트번호", "PTID", 35, "L", , True)
        GfColumnSet(GridView, "이름", "PTNM", 23, "L", , True)
        GfColumnSet(GridView, "접수일", "REQDATE", 35, "L", , True)
        GfColumnSet(GridView, "바코드", "SPCNO", 50, "L", , True)
        GfColumnSet(GridView, "성별", "PTSEX", 12, "L", , True)
        GfColumnSet(GridView, "나이", "PTAGE", 12, "L", , True)

        GfColumnSet(GridView3, "검사이름", "TESTNM", 30, "L", , True)
        GfColumnSet(GridView3, "검사분야", "WORKAREA", 20, "L", , True)
        GfColumnSet(GridView3, "채혈용기", "BLOODTUBE", 20, "L", , True)
        GfColumnSet(GridView3, "검사약어", "TESTNM_10", 30, "L", , True)
        GfColumnSet(GridView3, "특이사항", "Remark", 30, "L", , True)
        GfColumnSet(GridView3, "출력장수", "PrintAdd", 15, "L", , True)
        GfColumnSet(GridView3, "바코드분류", "BarcodeDivision", 15, "L", , True)

        grdSearchQry.Dock = DockStyle.Fill

    End Sub

    Private Sub btnManual_Click(sender As Object, e As EventArgs)
        frmManual.Show()
    End Sub

    '수진자 조회
    Private Sub PsFindRoutine()
        Try
            'SplashScreenManager.ShowWaitForm()

            Dim sWorkLog As String = " Customer List Searching."

            Call GsWorkLog(Me.Name.ToString, LogEvent._search, sWorkLog)

            Dim sTable As DataTable = Hospital_DB.HOSPITAL_ORDER_LIST_GET(dtpFrom.Text,             '시작일
                                                                          dtpTo.Text,               '종료일
                                                                          cboReceipt.EditValue,     '접수타입
                                                                          cboSearchCond.EditValue,  '검색타입
                                                                          txtSearchWrd.Text)        '검색어
            grdSearchQry.DataSource = sTable

            'SplashScreenManager.CloseWaitForm()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "수진자 조회 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '프린트완료 건 backColor 변경
    Private Sub GridView_RowStyle(ByVal sender As Object,
                                  ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView.RowStyle
        Try
            Dim View As GridView = sender

            If (e.RowHandle >= 0) Then
                Dim PITD As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("PTID"))
                Dim REQDATE As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("REQDATE"))

                QueryString = String.Empty
                QueryString &= " SELECT *          " & vbNewLine
                QueryString &= " FROM [m2i_LAB201] " & vbNewLine
                QueryString &= " WHERE 1 = 1       " & vbNewLine
                QueryString &= " AND [REQDATE] >= '" & Format(dtpFrom.EditValue, "yyyy-MM-dd") & "'" & vbNewLine

                Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

                If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                    For intRow = 0 To sTable.Rows.Count - 1
                        If PITD = sTable.Rows(intRow)("PTID").ToString And REQDATE = sTable.Rows(intRow)("REQDATE").ToString Then
                            e.Appearance.BackColor = Color.Salmon
                            e.Appearance.BackColor2 = Color.SeaShell
                            e.HighPriority = True
                        End If
                    Next
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub GRID_SET_COLOR(grdview As GridView,
    '                          i As Integer,
    '                          setColor As String)
    '    Dim intRow As Integer = GridView.GetVisibleRowHandle(i)
    '    With GridView
    '        Select Case setColor
    '            Case "RED"
    '                '.Appearance.Row.ForeColor = Color.Red
    '                .SetRowCellValue(intRow, "이름", ForeColor = Color.Red)
    '            Case "BLUE"

    '            Case "BLACK"
    '        End Select
    '    End With
    'End Sub

    Private Sub grdSearchQry_Click(sender As Object, e As EventArgs) Handles grdSearchQry.Click
        Dim sSelectRow As Integer = GridView.FocusedRowHandle
        Dim TESTCD As String = String.Empty

        Try
            SplashScreenManager.ShowWaitForm()

            With GridView
                txtPtChartNo.Text = .GetRowCellValue(sSelectRow, "PTID").ToString()        '차트번호
                txtPtnm.Text = .GetRowCellValue(sSelectRow, "PTNM").ToString()             '수진자이름
                txtReceiptDate.Text = .GetRowCellValue(sSelectRow, "REQDATE").ToString()   '접수일
                txtPtSex.Text = .GetRowCellValue(sSelectRow, "PTSEX").ToString()           '성별
                txtBarcodeNo.Text = .GetRowCellValue(sSelectRow, "SPCNO").ToString()       '바코드번호
                txtPtAge.Text = .GetRowCellValue(sSelectRow, "PTAGE").ToString()           '나이
                txtAcceptDate.Text = .GetRowCellValue(sSelectRow, "RESULTDATE").ToString() '결과일
                txtDoctor.Text = .GetRowCellValue(sSelectRow, "SIGNIN").ToString()         '의사
                txtMedOffice.Text = .GetRowCellValue(sSelectRow, "DeptCode").ToString()    '진료과
                memoComment.Text = .GetRowCellValue(sSelectRow, "REMARK").ToString()       '메모
            End With

            Dim TestCode As DataTable = Hospital_DB.HOSPITAL_ORDER_PATIENT_GET(GridView.GetRowCellValue(sSelectRow, "REQDATE").ToString,
                                                                               GridView.GetRowCellValue(sSelectRow, "PTID").ToString,
                                                                               GridView.GetRowCellValue(sSelectRow, "STATUS").ToString)

            If Not IsNothing(TestCode) AndAlso TestCode.Rows.Count > 0 Then
                For Each row As DataRow In TestCode.Rows
                    TESTCD &= "'" & row(0).ToString & "',"
                Next
                TESTCD = Mid(TESTCD, 1, Len(TESTCD) - 1)
            Else
                Dim sMsg As String = "등록된 검사코드가 없습니다 !", sMsgTitle As String = "검사코드 오류"
                XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            QueryString = String.Empty
            QueryString &= " SELECT [TESTNM],  [WORKAREA], [BLOODTUBE], [TESTNM_10], [Remark],  [PrintAdd] " & vbCrLf
            QueryString &= " FROM [m2i_LAB004]                                                             " & vbCrLf
            QueryString &= " WHERE 1 = 1                                                                   " & vbCrLf
            QueryString &= " AND [TESTCD] in (" & TESTCD & ")                                              " & vbCrLf
            QueryString &= " ORDER BY [WORKAREA],[BLOODTUBE]                                               " & vbCrLf

            Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

            grdSelect.DataSource = sTable

            SplashScreenManager.CloseWaitForm()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Get_TestCode()

        dtpFrom.DateTime = Now.AddDays(-PrevDay)
        dtpTo.DateTime = Now.AddDays(NextDay)

        With cboReceipt.Properties
            .Items.Clear()
            .Items.Add("선택없음")
            .Items.Add("접수")
            .Items.Add("결과")
        End With

        With cboPrintYN.Properties
            .Items.Clear()
            .Items.Add("선택없음")
            .Items.Add("출력")
            .Items.Add("미출력")
        End With

        With cboSearchCond.Properties
            .Items.Clear()
            .Items.Add("선택없음")
            .Items.Add("이름")
            .Items.Add("차트번호")
        End With

    End Sub

    Private Sub PsPrintRoutine()
        Dim strOldDivision As String = String.Empty
        Dim strNewDivision As String = String.Empty
        Dim printBool As Boolean

        Dim intRowCount As Integer

        Dim sPTNM As String = txtPtnm.EditValue
        Dim sBARCODE As String = txtBarcodeNo.EditValue
        Dim sCHARTNO As String = txtPtChartNo.EditValue
        Dim sSEX As String = txtPtSex.EditValue
        Dim sAGE As String = txtPtAge.EditValue
        'Dim sPTDIV As String = String.Empty
        'Dim sBIRTH As String = String.Empty
        Dim sMEDOFFICE As String = txtMedOffice.EditValue
        Dim sRECEIPTDATE As String = txtReceiptDate.EditValue
        Dim sDOCTOR As String = txtDoctor.EditValue
        Dim sACCEPTDATE As String = txtAcceptDate.EditValue
        Dim sMEMO As String = memoComment.EditValue

        For intRowCount = 0 To GridView3.RowCount - 1
            With GridView3

                strNewDivision = .GetRowCellValue(intRowCount, "WORKAREA").ToString()

                If strNewDivision <> strOldDivision Or printBool = False Then
                    Print_Barcode(sPTNM, sBARCODE, sCHARTNO, sSEX, sAGE, sMEDOFFICE, sRECEIPTDATE, sDOCTOR, sACCEPTDATE, sMEMO)
                End If

                strOldDivision = .GetRowCellValue(intRowCount, "WORKAREA").ToString()
                printBool = True
            End With
        Next

    End Sub

    '수진자조회 버튼
    Private Sub CommandButton_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel2.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "Find"
                Call PsFindRoutine()
        End Select
    End Sub

    '하단 버튼
    Private Sub CommandButton2_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "print"
                Call PsPrintRoutine()
            Case "manualShow"
                Call frmManual.Show()
            Case "Remove"
                Call PsClearRoutine()

            Case "SearchOn"
                ' 토글 상태 업데이트
                SearchEnabled = Not SearchEnabled

                If SearchEnabled Then
                    ' 검색 켜기
                    GridView.OptionsView.ShowAutoFilterRow = True
                    GridView.OptionsFind.AlwaysVisible = True
                Else
                    ' 검색 끄기
                    GridView.OptionsView.ShowAutoFilterRow = False
                    GridView.OptionsFind.AlwaysVisible = False
                End If

            Case "close"
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
        End Select
    End Sub

    Private Sub PsClearRoutine()
        dtpFrom.EditValue = Now.AddDays(-PrevDay)
        dtpTo.EditValue = Now.AddDays(NextDay)
        cboReceipt.EditValue = String.Empty
        cboPrintYN.EditValue = String.Empty
        cboSearchCond.EditValue = String.Empty
        txtSearchWrd.EditValue = String.Empty
        txtPtnm.EditValue = String.Empty
        txtBarcodeNo.EditValue = String.Empty
        txtPtSex.EditValue = String.Empty
        txtPtAge.EditValue = String.Empty
        txtPtChartNo.EditValue = String.Empty
        txtPtDiv.EditValue = String.Empty
        txtPtBirth.EditValue = String.Empty
        txtMedOffice.EditValue = String.Empty
        txtReceiptDate.EditValue = String.Empty
        txtDoctor.EditValue = String.Empty
        txtAcceptDate.EditValue = String.Empty
        memoComment.EditValue = String.Empty

        grdSearchQry.DataSource = Nothing
        grdSelect.DataSource = Nothing
    End Sub

    'mDB에서 검사코드 가져온다
    Public Sub Get_TestCode()
        Try
            QueryString = String.Empty
            QueryString &= " SELECT TESTCD, TESTNM  " & vbCrLf
            QueryString &= " FROM m2i_LAB004        " & vbCrLf
            QueryString &= " WHERE TESTCD <> 'AMH'  " & vbCrLf
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

        End Try
    End Sub

End Class