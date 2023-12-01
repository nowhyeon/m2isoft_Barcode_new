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
        GfColumnSet(GridView1, "검사이름", "TESTNM", 30, "L", , True)
        'GfColumnSet(GridView1, "검사분야", "WORKAREA", 20, "L", , True)
        'GfColumnSet(GridView1, "채혈용기", "BLOODTUBE", 20, "L", , True)
        'GfColumnSet(GridView1, "검사약어", "TESTNM_10", 30, "L", , True)
        GfColumnSet(GridView1, "특이사항", "Remark", 30, "L", , True)
        GfColumnSet(GridView1, "출력장수", "PrintAdd", 15, "L", , True)
        GfColumnSet(GridView1, "바코드분류", "BarcodeDivision", 15, "L", , True)

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

    Private Sub PsFindRoutine()
        Try
            'SplashScreenManager.ShowWaitForm()

            Dim sWorkLog As String = " Customer List Searching."

            Call GsWorkLog(Me.Name.ToString, LogEvent._search, sWorkLog)

            Dim sTable As DataTable = Hospital_DB_AMH.HOSPITAL_ORDER_AMH_LIST_GET(dtpFrom.Text,             '시작일
                                                                                  dtpTo.Text,               '종료일
                                                                                  cboSearchCond.EditValue,  '검색타입
                                                                                  txtSearchWrd.Text)        '검색어
            grdSearchQry.DataSource = sTable

            'SplashScreenManager.CloseWaitForm()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "수진자 조회 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub frmAMHTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Get_TestCodeAMH()
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
End Class