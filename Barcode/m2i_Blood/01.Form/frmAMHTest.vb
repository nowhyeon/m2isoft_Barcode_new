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
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class frmAMHTest

    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase
    Public Hospital_DB As New ClsOrder
    Public Hospital_DB_AMH As New ClsAMH

    Public Sub New()
        ' 디자이너에서 이 호출이 필요합니다.
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

        ' 수진자 조회 결과 Grid
        GfColumnSet(GridView, "차트번호", "PTID", 35, "L", , True)
        GfColumnSet(GridView, "이름", "PTNM", 23, "L", , True)
        GfColumnSet(GridView, "접수일", "REQDATE", 35, "L", , True)
        GfColumnSet(GridView, "바코드", "SPCNO", 50, "L", , True)
        GfColumnSet(GridView, "성별", "PTSEX", 12, "L", , True)
        GfColumnSet(GridView, "나이", "PTAGE", 12, "L", , True)

        ' 수진자 AMH 상세 결과 Grid
        GfColumnSet(GridView1, "검사코드", "TESTCODE", 30, "C", , True)
        GfColumnSet(GridView1, "수진자번호", "PTNO", 23, "C", , True)
        GfColumnSet(GridView1, "수진자명", "SNAME", 30, "C", , True)
        GfColumnSet(GridView1, "나이", "AGE", 15, "C", , True)
        GfColumnSet(GridView1, "결과", "RESULT", 15, "C", , True)

        grdSearchQry.Dock = DockStyle.Fill

    End Sub

    '수진자조회 버튼
    Private Sub CommandButton_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel2.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "Find"
                Call PsFindRoutine()
        End Select
    End Sub

    Private Sub WindowsUIButtonPanel1_Click(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "MultiPrint"
                Call PsMultiPrint()
            Case "print"
                Call PsPrint()
            Case "Remove"
                Call PsClearRoutine()
        End Select
    End Sub

    Private Sub PsMultiPrint()
        Dim sRowHandles As Int32() = GridView.GetSelectedRows()

        For sRowCnt = 0 To sRowHandles.Length - 1

            Dim Report_IF_AMH As Report_IF_AMH = New Report_IF_AMH
            Dim sex As String
            If GridView.GetRowCellValue(sRowCnt, "PTSEX").ToString = "F" Then
                sex = "여"
            ElseIf GridView.GetRowCellValue(sRowCnt, "PTSEX").ToString = "M" Then
                sex = "남"
            Else
                sex = "-"
            End If

            With Report_IF_AMH
                .mPTNM = GridView.GetRowCellValue(sRowCnt, "PTNM").ToString
                .mBirth = ""
                .mSex = sex
                .mAge = GridView.GetRowCellValue(sRowCnt, "PTAGE").ToString
                .mChartNo = GridView.GetRowCellValue(sRowCnt, "PTID").ToString
                .mMedOffice = GridView.GetRowCellValue(sRowCnt, "DeptCode").ToString
                .mReceiptDate = GridView.GetRowCellValue(sRowCnt, "REQDATE").ToString
                .mDoctor = GridView.GetRowCellValue(sRowCnt, "SIGNIN").ToString
                .mAcceptDate = GridView.GetRowCellValue(sRowCnt, "RESULTDATE").ToString
                .mAMHResult = GridView.GetRowCellValue(sRowCnt, "RESULT").ToString
                '.mComment1 = ""
                '.mComment2 = ""
                '.mComment3 = ""
            End With

            'prevView (x)---------------------------------------------------------------------------------------------------------
            Dim printTool As New ReportPrintTool(Report_IF_AMH)

            ' PrintDocument 인스턴스 생성
            Dim printDocument As New PrintDocument()

            ' printTool.PrintingSystem.PageMargins = New Margins(50, 50, 50, 50) ' 여백 설정
            ' printTool.PrintingSystem.Landscape = True ' 가로 방향으로 출력 설정
            printTool.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4 ' 용지 종류 설정

            ' 보고서를 바로 출력
            printTool.Print()
            '---------------------------------------------------------------------------------------------------------------------

            'prevView (O)---------------------------------------------------------------------------------------------------------
            'With frmReportView
            '    .dcvPrevView.DocumentSource = Report_IF_AMH
            '    Report_IF_AMH.CreateDocument()
            '    .ShowDialog()

            '    'If .DialogResult = DialogResult.OK Then
            '    '    SimpleButton1_Click(sender, e)
            '    'End If
            'End With
            '---------------------------------------------------------------------------------------------------------------------
        Next
    End Sub

    Private Sub PsPrint()
        Dim Report_IF_AMH As Report_IF_AMH = New Report_IF_AMH
        Dim sex As String
        If txtPtSex.EditValue = "F" Then
            sex = "여"
        ElseIf txtPtSex.EditValue = "M" Then
            sex = "남"
        Else
            sex = "-"
        End If

        With Report_IF_AMH
            .mPTNM = txtPtnm.EditValue
            .mBirth = txtPtBirth.EditValue
            .mSex = sex
            .mAge = txtPtAge.EditValue
            .mChartNo = txtPtChartNo.EditValue
            .mMedOffice = txtMedOffice.EditValue
            .mReceiptDate = txtReceiptDate.EditValue
            .mDoctor = txtDoctor.EditValue
            .mAcceptDate = txtAcceptDate.EditValue
            .mAMHResult = RESULT.Text
            '.mComment1 = ""
            '.mComment2 = ""
            '.mComment3 = ""
        End With

        'prevView (x)---------------------------------------------------------------------------------------------------------
        Dim printTool As New ReportPrintTool(Report_IF_AMH)

        ' PrintDocument 인스턴스 생성
        Dim printDocument As New PrintDocument()

        ' printTool.PrintingSystem.PageMargins = New Margins(50, 50, 50, 50) ' 여백 설정
        ' printTool.PrintingSystem.Landscape = True ' 가로 방향으로 출력 설정
        printTool.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4 ' 용지 종류 설정

        ' 보고서를 바로 출력
        printTool.Print()
        '---------------------------------------------------------------------------------------------------------------------

        'prevView (O)---------------------------------------------------------------------------------------------------------
        'With frmReportView
        '    .dcvPrevView.DocumentSource = Report_IF_AMH
        '    Report_IF_AMH.CreateDocument()
        '    .ShowDialog()

        '    'If .DialogResult = DialogResult.OK Then
        '    '    SimpleButton1_Click(sender, e)
        '    'End If
        'End With
        '---------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub grdSearchQry_Click(sender As Object, e As EventArgs) Handles grdSearchQry.Click

        Dim sSelectRow As Integer = GridView.FocusedRowHandle
        Dim TESTCD As String = String.Empty
        Dim PTAGE As Integer = GridView.GetRowCellValue(sSelectRow, "PTAGE")

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
                RESULT.Text = .GetRowCellValue(sSelectRow, "RESULT").ToString()
            End With

            Dim TestCode As DataTable = Hospital_DB_AMH.HOSPITAL_ORDER_AMH_RESULT(GridView.GetRowCellValue(sSelectRow, "REQDATE").ToString,
                                                                               GridView.GetRowCellValue(sSelectRow, "PTID").ToString)

            If Not IsNothing(TestCode) AndAlso TestCode.Rows.Count > 0 Then
                For Each row As DataRow In TestCode.Rows
                    TESTCD &= "'" & row(0).ToString & "',"
                Next
                TESTCD = Mid(TESTCD, 1, Len(TESTCD) - 1)
            Else
                XtraMessageBox.Show(_sMsg.sMsg_NoTestCode, _sMsg_Title.sMsgTitle_TestCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Dim sTable As DataTable = ClsDb.CfSelectQuery(QueryString)

            grdAMH.DataSource = sTable

            Select Case True
                Case PTAGE >= 20 AndAlso PTAGE <= 24
                    PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_06.jpg")
                Case PTAGE >= 25 AndAlso PTAGE <= 29
                    PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_05.jpg")
                Case PTAGE >= 30 AndAlso PTAGE <= 34
                    PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_04.jpg")
                Case PTAGE >= 35 AndAlso PTAGE <= 39
                    PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_03.jpg")
                Case PTAGE >= 40 AndAlso PTAGE <= 44
                    PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_02.jpg")
                Case PTAGE >= 45 AndAlso PTAGE <= 50
                    PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_01.jpg")
            End Select

            SplashScreenManager.CloseWaitForm()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PsFindRoutine()
        Try
            SplashScreenManager.ShowWaitForm()

            Dim sWorkLog As String = " Customer List Searching."

            Call GsWorkLog(Me.Name.ToString, LogEvent._search, sWorkLog)

            Dim sTable As DataTable = Hospital_DB_AMH.HOSPITAL_ORDER_AMH_LIST_GET(dtpFrom.Text,             '시작일
                                                                                  dtpTo.Text,               '종료일
                                                                                  cboSearchCond.EditValue,  '검색타입
                                                                                  txtSearchWrd.Text)        '검색어
            grdSearchQry.DataSource = sTable

            SplashScreenManager.CloseWaitForm()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "수진자 조회 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAMHTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Get_TestCodeAMH()

        SplashScreenManager.ShowWaitForm()

        dtpFrom.DateTime = Now.AddDays(-PrevDay)
        dtpTo.DateTime = Now.AddDays(NextDay)

        With cboPrintYN.Properties
            .Items.Clear()
            .Items.Add("출력")
            .Items.Add("미출력")
        End With

        With cboSearchCond.Properties
            .Items.Clear()
            .Items.Add("이름")
            .Items.Add("차트번호")
            .Items.Add("바코드번호")
        End With

        SplashScreenManager.CloseWaitForm()
    End Sub

    'mDB에서 검사코드 가져온다
    Public Sub Get_TestCodeAMH()
        Try
            QueryString = String.Empty
            QueryString &= " SELECT TESTCD, TESTNM  " & vbCrLf
            QueryString &= " FROM m2i_LAB002        " & vbCrLf
            QueryString &= " WHERE TESTCD = 'AMH'   " & vbCrLf
            QueryString &= " ORDER BY TESTCD        " & vbCrLf

            Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)
            ' mDB의 TESTCD의 정보를 가져와서 sTable이라는 테이블에 저장

            ' sTable에 없는 검사코드가 있을 때
            If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                For Each row As DataRow In sTable.Rows
                    gTestCodeAMH &= "'" & row(1).ToString & "',"
                Next
                gTestCodeAMH = Mid(gTestCodeAMH, 1, Len(gTestCodeAMH) - 1)
            Else
                Dim sMsg As String = "등록된 검사코드가 없습니다 !", sMsgTitle As String = "검사코드 오류"
                XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PsClearRoutine()
        'dtpFrom.EditValue = Now.AddDays(-PrevDay)
        'dtpTo.EditValue = Now.AddDays(NextDay)
        cboPrintYN.EditValue = String.Empty
        cboSearchCond.EditValue = String.Empty
        txtSearchWrd.EditValue = String.Empty
        txtPtnm.EditValue = String.Empty
        txtBarcodeNo.EditValue = String.Empty
        txtPtSex.EditValue = String.Empty
        txtPtAge.EditValue = String.Empty
        txtPtChartNo.EditValue = String.Empty
        txtPtBirth.EditValue = String.Empty
        txtMedOffice.EditValue = String.Empty
        txtReceiptDate.EditValue = String.Empty
        txtDoctor.EditValue = String.Empty
        txtAcceptDate.EditValue = String.Empty

        grdAMH.DataSource = Nothing

        PictureEdit1.Image = Image.FromFile(Application.StartupPath & "\05.Rpt\AMH_Form_01\AMH.jpg")
    End Sub

End Class