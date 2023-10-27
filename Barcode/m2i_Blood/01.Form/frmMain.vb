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
        GfColumnSet(GridView, "이름", "PTNM", 20, "L", , True)
        GfColumnSet(GridView, "접수일", "REQDATE", 20, "L", , True)
        GfColumnSet(GridView, "바코드", "SPCNO", 20, "L", , True)
        GfColumnSet(GridView, "성별", "PTSEX", 20, "L", , True)
        GfColumnSet(GridView, "나이", "PTAGE", 20, "L", , True)

        grdSearchQry.Dock = DockStyle.Fill

    End Sub

    Private Sub btnManual_Click(sender As Object, e As EventArgs)
        Dim manual As New frmManual
        manual.Show()
    End Sub

    '수진자 조회
    Private Sub PsFindRoutine()
        Try
            'Dim sWorkLog As String = " Customer List Searching."

            'Call GsWorkLog(Me.Name.ToString, LogEvent._search, sWorkLog)

            Dim sTable As DataTable = Hospital_DB.HOSPITAL_ORDER_LIST_GET(Format(dtpFrom.EditValue, "yyyyMMdd"),'시작일
                                                                            Format(dtpTo.EditValue, "yyyyMMdd"),'종료일
                                                                            cboReceipt.EditValue,               '접수타입
                                                                            cboSearchCond.EditValue,            '검색타입
                                                                            txtSearchWrd.Text)                  '검색어

            grdSearchQry.DataSource = sTable

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "수진자 조회 에러", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '수진자조회 버튼
    Private Sub CommandButton_ButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles btnSelect.ButtonClick

        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "Find"
                Call PsFindRoutine()
        End Select
    End Sub

    Private Sub grdSearchQry_Click(sender As Object, e As EventArgs) Handles grdSearchQry.Click
        Dim sSelectRow As Integer = GridView.FocusedRowHandle

        With GridView
            txtPtChartNo.Text = .GetRowCellValue(sSelectRow, "PTID").ToString()
            txtPtnm.Text = .GetRowCellValue(sSelectRow, "PTNM").ToString()
            txtAcceptDate.Text = .GetRowCellValue(sSelectRow, "REQDATE").ToString()
            txtPtSex.Text = .GetRowCellValue(sSelectRow, "PTSEX").ToString()
            txtBarcodeNo.Text = .GetRowCellValue(sSelectRow, "SPCNO").ToString()
            txtPtAge.Text = .GetRowCellValue(sSelectRow, "PTAGE").ToString()
        End With

        Dim sTable As DataTable = Hospital_DB.HOSPITAL_ORDER_PATIENT_GET(GridView.GetRowCellValue(sSelectRow, "REQDATE").ToString,
                                                                 GridView.GetRowCellValue(sSelectRow, "PTID").ToString,
                                                                 GridView.GetRowCellValue(sSelectRow, "JUBSU").ToString)

        grdSelect.DataSource = sTable
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.EditValue = Now
        dtpTo.EditValue = Now

        With cboReceipt
            .Properties.Items.Clear()
            .Properties.Items.Add("01.접수")
            .Properties.Items.Add("02.결과")
        End With
        With cboPrintYN
            .Properties.Items.Clear()
            .Properties.Items.Add("01.출력")
            .Properties.Items.Add("02.미출력")
        End With
        With cboSearchCond
            .Properties.Items.Clear()
            .Properties.Items.Add("01.검색조건")
            .Properties.Items.Add("02.환자명")
            .Properties.Items.Add("03.차트번호")
            .Properties.Items.Add("04.검사코드")
        End With
    End Sub

End Class