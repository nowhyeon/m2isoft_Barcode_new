Imports System.IO
Imports System.ComponentModel
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls

Public Class frmMain
    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase
    Public Hospital_DB As New ClsOrder

    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen

        With GridView
            .OptionsView.ShowGroupPanel = False
            .OptionsSelection.EnableAppearanceFocusedCell = False                                ' 포커스 설정
            .OptionsSelection.MultiSelect = True                                                 ' 다중라인 선택유무
            .OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect

            .Columns.Clear()
        End With
        'GridView, "검사코드", "TESTCD", 15, "D", True, True, "S", 0, False, Nothing, False, False
        GfColumnSet(GridView, "차트번호", "PTID", 30, "L", , True)
        GfColumnSet(GridView, "이름", "PTNM", 15, "L", , True)
        GfColumnSet(GridView, "접수일", "REQDATE", 30, "L", , True)
        GfColumnSet(GridView, "바코드", "SPCNO", 30, "L", , True)
        GfColumnSet(GridView, "성별", "PTSEX", 15, "L", , True)
        GfColumnSet(GridView, "나이", "PTAGE", 15, "L", , True)

        GfColumnSet(GridView3, "검사이름", "TESTNM", 30, "L", , True)
        GfColumnSet(GridView3, "채혈용기", "BLOODTUBE", 20, "L", , True)
        GfColumnSet(GridView3, "검사분야", "WORKAREA", 20, "L", , True)
        GfColumnSet(GridView3, "검사약어", "TESTNM_10", 30, "L", , True)
        GfColumnSet(GridView3, "특이사항", "Remark", 40, "L", , True)
        GfColumnSet(GridView3, "출력장수", "PrintAdd", 15, "L", , True)
        GfColumnSet(GridView3, "바코드분류", "BarcodeDivision", 15, "L", , True)

        grdSearchQry.Dock = DockStyle.Fill

    End Sub

    Private Sub btnManual_Click(sender As Object, e As EventArgs)
        Dim manual As New frmManual
        manual.Show()
    End Sub

    '수진자 조회
    Private Sub PsFindRoutine()
        Try
            Dim sWorkLog As String = " Customer List Searching."

            Call GsWorkLog(Me.Name.ToString, LogEvent._search, sWorkLog)



            Dim sTable As DataTable = Hospital_DB.HOSPITAL_ORDER_LIST_GET(Format(dtpFrom.EditValue, "yyyyMMdd"),'시작일
                                                                          Format(dtpTo.EditValue, "yyyyMMdd"),  '종료일
                                                                          cboReceipt.EditValue,                 '접수타입
                                                                          cboSearchCond.EditValue,              '검색타입
                                                                          txtSearchWrd.Text)                    '검색어

            grdSearchQry.DataSource = sTable

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "수진자 조회 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub grdSearchQry_Click(sender As Object, e As EventArgs) Handles grdSearchQry.Click
        Dim sSelectRow As Integer = GridView.FocusedRowHandle
        Dim TESTCD As String = String.Empty

        Try
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
                                                                               GridView.GetRowCellValue(sSelectRow, "JUBSU").ToString)

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
            QueryString &= " SELECT TESTNM, BLOODTUBE, WORKAREA, TESTNM_10, Remark,  PrintAdd" & vbCrLf
            QueryString &= "   FROM m2i_LAB004                                               " & vbCrLf
            QueryString &= "  WHERE 1 = 1                                                    " & vbCrLf
            QueryString &= "    AND TESTCD in (" & TESTCD & ")                               " & vbCrLf
            QueryString &= "  ORDER BY BLOODTUBE,WORKAREA                                    " & vbCrLf

            Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

            grdSelect.DataSource = sTable

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.EditValue = Now
        dtpTo.EditValue = Now

        With cboReceipt.Properties
            .Items.Add("접수")
            .Items.Add("결과")
        End With

        With cboPrintYN.Properties
            .Items.Add("출력")
            .Items.Add("미출력")
        End With

        With cboSearchCond.Properties
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

                strNewDivision = .GetRowCellValue(intRowCount, "BLOODTUBE").ToString()

                If strNewDivision <> strOldDivision Or printBool = False Then
                    Print_Barcode(sPTNM, sBARCODE, sCHARTNO, sSEX, sAGE, sMEDOFFICE, sRECEIPTDATE, sDOCTOR, sACCEPTDATE, sMEMO)
                End If

                strOldDivision = .GetRowCellValue(intRowCount, "BLOODTUBE").ToString()
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
        End Select
    End Sub
End Class