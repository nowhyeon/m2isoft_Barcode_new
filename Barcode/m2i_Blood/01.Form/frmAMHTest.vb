Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraCharts
Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class frmAMHTest

    Public Hospital_DB As New ClsOrder
    Public Hospital_DB_AMH As New ClsAMH

    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents

    Private ClsDb As New ClsDatabase

    Private SearchEnabled As Boolean = False

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
        GfColumnSet(GridView, "접수일", "REQDATE", 25, "C", , True)
        GfColumnSet(GridView, "차트번호", "PTID", 25, "C", , True)
        GfColumnSet(GridView, "이름", "PTNM", 23, "C", , True)
        GfColumnSet(GridView, "나이", "PTAGE", 12, "C", , True)

        ' 수진자 AMH 상세 결과 Grid
        GfColumnSet(GridView1, "차트번호", "PTNO", 23, "C", , True)
        GfColumnSet(GridView1, "검사명", "LABNAME", 30, "C", , True)
        GfColumnSet(GridView1, "검사코드", "TESTCODE", 30, "C", , True)
        GfColumnSet(GridView1, "수진자명", "SNAME", 30, "C", , True)
        GfColumnSet(GridView1, "결과", "RESULT", 15, "C", , True)

        grdSearchQry.Dock = DockStyle.Fill

    End Sub

    Private Sub frmAMHTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Get_TestCodeAMH()

        dtpFrom.DateTime = Now.AddDays(-PrevDay)
        dtpTo.DateTime = Now.AddDays(NextDay)

        With cboPrintYN.Properties
            .Items.Add("선택 없음")
            .Items.Add("출력")
            .Items.Add("미출력")
        End With

        With cboSearchCond.Properties
            .Items.Add("선택 없음")
            .Items.Add("이름")
            .Items.Add("차트번호")
            .Items.Add("바코드번호")
        End With

    End Sub

    '수진자조회 버튼
    Private Sub CommandButton_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel2.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "Find"
                Call PsFindRoutine()
        End Select
    End Sub

    Private Sub WindowsUIButtonPanel1_Click(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles WindowsUIButtonPanel3.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "MultiPrint"
                Call PsMultiPrint()
            Case "print"
                Select Case ReportIndex
                    Case 0
                        Call PsPrint_Default()
                    Case 1
                        Call PsPrint_AIN()
                    Case 2
                        Call PsPrint_IBF()
                End Select
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

        End Select
    End Sub

#Region "다중 출력"
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
                sex = "공통"
            End If

            'prevView (x)---------------------------------------------------------------------------------------------------------
            Dim printTool As New ReportPrintTool(Report_IF_AMH)

            ' PrintDocument 인스턴스 생성
            Dim printDocument As New PrintDocument()

            ' printTool.PrintingSystem.PageMargins = New Margins(50, 50, 50, 50) ' 여백 설정
            ' printTool.PrintingSystem.Landscape = True ' 가로 방향으로 출력 설정
            printTool.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4 ' 용지 종류 설정

            ' 보고서를 바로 출력
            printTool.Print()

#Region "보고서 출력 시 결과를 MDB에 덮어쓰기"
            'QueryString = String.Empty
            'QueryString &= " UPDATE m2i_LAB201                                              " & vbNewLine
            'QueryString &= "    SET REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
            'QueryString &= "      , SPCNO = '" & txtBarcodeNo.Text & "'                     " & vbNewLine
            'QueryString &= "      , PRTDATE = '" & Format(Now, "yyyy-MM-dd") & "'           " & vbNewLine
            'QueryString &= "  WHERE REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
            'QueryString &= "  AND   PTID = '" & txtPtChartNo.Text & "'                      " & vbNewLine
#End Region

            QueryString = String.Empty
                QueryString &= " INSERT INTO m2i_LAB201                                         " & vbNewLine
                QueryString &= " (                                                              " & vbNewLine
                QueryString &= "        REQDATE                                                 " & vbNewLine
                QueryString &= "      , SPCNO                                                   " & vbNewLine
                QueryString &= "      , PTNM                                                    " & vbNewLine
                QueryString &= "      , PTID                                                    " & vbNewLine
                QueryString &= "      , PRTDATE                                                 " & vbNewLine
                QueryString &= "  )VALUES(                                                      " & vbNewLine
                QueryString &= "   '" & txtAcceptDate.Text & "'                                 " & vbNewLine
                QueryString &= "  ,'" & txtBarcodeNo.Text & "'                                  " & vbNewLine
                QueryString &= "  ,'" & txtPtnm.Text & "'                                       " & vbNewLine
                QueryString &= "  ,'" & txtPtChartNo.Text & "'                                  " & vbNewLine
                QueryString &= "  ,'" & Format(Now, "yyyy-MM-dd") & "'                          " & vbNewLine
            QueryString &= "  )                                                             " & vbNewLine

            If QueryString.Length > 0 Then
                ClsDb.CfMExecuteQuery(QueryString)
            End If

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
#End Region

#Region "기본 보고서 단일 출력"
    Private Sub PsPrint_Default()

        Dim Report_AMH_IF As Report_IF_AMH = New Report_IF_AMH

        '보고서 출력 시 미리보기 (O)--------------------
        With frmReportView
            .dcvPrevView.DocumentSource = Report_AMH_IF
            Report_AMH_IF.CreateDocument()
            .ShowDialog()
        End With

#Region "출력한 수진자 덮어쓰기 형식"
        'QueryString = String.Empty
        'QueryString &= " UPDATE m2i_LAB201                                              " & vbNewLine
        'QueryString &= "    SET REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
        'QueryString &= "      , SPCNO = '" & txtBarcodeNo.Text & "'                     " & vbNewLine
        'QueryString &= "      , PRTDATE = '" & Format(Now, "yyyy-MM-dd") & "'           " & vbNewLine
        'QueryString &= "  WHERE REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
        'QueryString &= "  AND   PTID = '" & txtPtChartNo.Text & "'                      " & vbNewLine
#End Region

        QueryString = String.Empty
        QueryString &= " INSERT INTO m2i_LAB201                                         " & vbNewLine
        QueryString &= " (                                                              " & vbNewLine
        QueryString &= "        REQDATE                                                 " & vbNewLine
        QueryString &= "      , SPCNO                                                   " & vbNewLine
        QueryString &= "      , PTNM                                                    " & vbNewLine
        QueryString &= "      , PTID                                                    " & vbNewLine
        QueryString &= "      , PRTDATE                                                 " & vbNewLine
        QueryString &= "  )VALUES(                                                      " & vbNewLine
        QueryString &= "   '" & txtAcceptDate.Text & "'                                 " & vbNewLine
        QueryString &= "  ,'" & txtBarcodeNo.Text & "'                                  " & vbNewLine
        QueryString &= "  ,'" & txtPtnm.Text & "'                                       " & vbNewLine
        QueryString &= "  ,'" & txtPtChartNo.Text & "'                                  " & vbNewLine
        QueryString &= "  ,'" & Format(Now, "yyyy-MM-dd") & "'                          " & vbNewLine
        QueryString &= "  )                                                             " & vbNewLine

        If QueryString.Length > 0 Then
            ClsDb.CfMExecuteQuery(QueryString)
        End If

#Region "출력 시 미리보기 없음"
        'Dim printTool As New ReportPrintTool(Report_IF_AMH)

        ' PrintDocument 인스턴스 생성
        'Dim printDocument As New PrintDocument()

        ' printTool.PrintingSystem.PageMargins = New Margins(50, 50, 50, 50) ' 여백 설정
        ' printTool.PrintingSystem.Landscape = True ' 가로 방향으로 출력 설정
        'printTool.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4 ' 용지 종류 설정

        ' 보고서를 바로 출력
        'printTool.Print()
#End Region

    End Sub
#End Region

#Region "아인여성의원 보고서 단일 출력"
    Private Sub PsPrint_AIN()

        Dim Report_AMH_IF As Report_IF_AMH_2 = New Report_IF_AMH_2

        '보고서 출력 시 미리보기 (O)--------------------
        With frmReportView
            .dcvPrevView.DocumentSource = Report_AMH_IF
            Report_AMH_IF.CreateDocument()
            .ShowDialog()
        End With

#Region "출력한 수진자 덮어쓰기 형식"
        'QueryString = String.Empty
        'QueryString &= " UPDATE m2i_LAB201                                              " & vbNewLine
        'QueryString &= "    SET REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
        'QueryString &= "      , SPCNO = '" & txtBarcodeNo.Text & "'                     " & vbNewLine
        'QueryString &= "      , PRTDATE = '" & Format(Now, "yyyy-MM-dd") & "'           " & vbNewLine
        'QueryString &= "  WHERE REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
        'QueryString &= "  AND   PTID = '" & txtPtChartNo.Text & "'                      " & vbNewLine
#End Region

        QueryString = String.Empty
        QueryString &= " INSERT INTO m2i_LAB201                                         " & vbNewLine
        QueryString &= " (                                                              " & vbNewLine
        QueryString &= "        REQDATE                                                 " & vbNewLine
        QueryString &= "      , SPCNO                                                   " & vbNewLine
        QueryString &= "      , PTNM                                                    " & vbNewLine
        QueryString &= "      , PTID                                                    " & vbNewLine
        QueryString &= "      , PRTDATE                                                 " & vbNewLine
        QueryString &= "  )VALUES(                                                      " & vbNewLine
        QueryString &= "   '" & txtAcceptDate.Text & "'                                 " & vbNewLine
        QueryString &= "  ,'" & txtBarcodeNo.Text & "'                                  " & vbNewLine
        QueryString &= "  ,'" & txtPtnm.Text & "'                                       " & vbNewLine
        QueryString &= "  ,'" & txtPtChartNo.Text & "'                                  " & vbNewLine
        QueryString &= "  ,'" & Format(Now, "yyyy-MM-dd") & "'                          " & vbNewLine
        QueryString &= "  )                                                             " & vbNewLine

        If QueryString.Length > 0 Then
            ClsDb.CfMExecuteQuery(QueryString)
        End If

#Region "출력 시 미리보기 없음"
        'Dim printTool As New ReportPrintTool(Report_IF_AMH)

        ' PrintDocument 인스턴스 생성
        'Dim printDocument As New PrintDocument()

        ' printTool.PrintingSystem.PageMargins = New Margins(50, 50, 50, 50) ' 여백 설정
        ' printTool.PrintingSystem.Landscape = True ' 가로 방향으로 출력 설정
        'printTool.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4 ' 용지 종류 설정

        ' 보고서를 바로 출력
        'printTool.Print()
#End Region

    End Sub
#End Region

#Region "아이비에프 보고서 단일 출력"
    Private Sub PsPrint_IBF()

        Dim Report_AMH_IF As Report_IF_AMH_3 = New Report_IF_AMH_3

        '보고서 출력 시 미리보기 (O)-------------------
        With frmReportView
            .dcvPrevView.DocumentSource = Report_AMH_IF
            Report_AMH_IF.CreateDocument()
            .ShowDialog()
        End With

#Region "출력한 수진자 덮어쓰기 형식"
        'QueryString = String.Empty
        'QueryString &= " UPDATE m2i_LAB201                                              " & vbNewLine
        'QueryString &= "    SET REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
        'QueryString &= "      , SPCNO = '" & txtBarcodeNo.Text & "'                     " & vbNewLine
        'QueryString &= "      , PRTDATE = '" & Format(Now, "yyyy-MM-dd") & "'           " & vbNewLine
        'QueryString &= "  WHERE REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
        'QueryString &= "  AND   PTID = '" & txtPtChartNo.Text & "'                      " & vbNewLine
#End Region

        QueryString = String.Empty
        QueryString &= " INSERT INTO m2i_LAB201                                         " & vbNewLine
        QueryString &= " (                                                              " & vbNewLine
        QueryString &= "        REQDATE                                                 " & vbNewLine
        QueryString &= "      , SPCNO                                                   " & vbNewLine
        QueryString &= "      , PTNM                                                    " & vbNewLine
        QueryString &= "      , PTID                                                    " & vbNewLine
        QueryString &= "      , PRTDATE                                                 " & vbNewLine
        QueryString &= "  )VALUES(                                                      " & vbNewLine
        QueryString &= "   '" & txtAcceptDate.Text & "'                                 " & vbNewLine
        QueryString &= "  ,'" & txtBarcodeNo.Text & "'                                  " & vbNewLine
        QueryString &= "  ,'" & txtPtnm.Text & "'                                       " & vbNewLine
        QueryString &= "  ,'" & txtPtChartNo.Text & "'                                  " & vbNewLine
        QueryString &= "  ,'" & Format(Now, "yyyy-MM-dd") & "'                          " & vbNewLine
        QueryString &= "  )                                                             " & vbNewLine

        If QueryString.Length > 0 Then
            ClsDb.CfMExecuteQuery(QueryString)
        End If

#Region "출력 시 미리보기 없음"
        'Dim printTool As New ReportPrintTool(Report_IF_AMH)

        ' PrintDocument 인스턴스 생성
        'Dim printDocument As New PrintDocument()

        ' printTool.PrintingSystem.PageMargins = New Margins(50, 50, 50, 50) ' 여백 설정
        ' printTool.PrintingSystem.Landscape = True ' 가로 방향으로 출력 설정
        'printTool.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4 ' 용지 종류 설정

        ' 보고서를 바로 출력
        'printTool.Print()
#End Region

    End Sub
#End Region

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

    'mDB에서 검사코드 가져온다
    Public Sub Get_TestCodeAMH()
        Try
            QueryString = String.Empty
            QueryString &= " SELECT TESTCD, TESTNM  " & vbCrLf
            QueryString &= " FROM m2i_LAB002        " & vbCrLf
            QueryString &= " WHERE TESTCD = 'AMH'   " & vbCrLf                  ' 검사코드가 다를 수 있기 때문에 수정 필요
            QueryString &= " ORDER BY TESTCD        " & vbCrLf

            Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)         ' mDB의 TESTCD의 정보를 가져와서 sTable이라는 테이블에 저장

            ' sTable에 없는 검사코드가 있을 때
            If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                For Each row As DataRow In sTable.Rows
                    gTestCodeAMH &= "'" & row(1).ToString & "',"
                Next
                gTestCodeAMH = Mid(gTestCodeAMH, 1, Len(gTestCodeAMH) - 1)
            Else
                XtraMessageBox.Show(_sMsg.sMsg_NoTestCode, _sMsg_Title.sMsgTitle_TestCode, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PsClearRoutine()

        cboPrintYN.EditValue = "선택 없음"
        cboSearchCond.EditValue = "선택 없음"
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
        grdSearchQry.DataSource = Nothing

        PictureEdit1.Image = Nothing
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

End Class