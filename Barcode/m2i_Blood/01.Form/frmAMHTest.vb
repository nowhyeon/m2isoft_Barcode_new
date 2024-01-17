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
                Call PsPrint()
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

    Private Sub PsMultiPrint()
        Dim sRowHandles As Int32() = GridView.GetSelectedRows()

        For sRowCnt = 0 To sRowHandles.Length - 1

            Dim Report_IF_AMH As Report_IF_AMH_1 = New Report_IF_AMH_1
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

                '----------------------------------------------------------------------------------------------------------------
                Dim series1 As Series = New Series("상위 5%", ViewType.Line)
                Dim series2 As Series = New Series("중간값", ViewType.Line)
                Dim series3 As Series = New Series("하위 5%", ViewType.Line)

                series1.Points.Add(New SeriesPoint(1, 9.95)) '1에 9.95
                series1.Points.Add(New SeriesPoint(3, 9.05))
                series1.Points.Add(New SeriesPoint(5, 7.59))
                series1.Points.Add(New SeriesPoint(7, 6.96))
                series1.Points.Add(New SeriesPoint(9, 4.44))
                series1.Points.Add(New SeriesPoint(11, 1.79))

                series2.Points.Add(New SeriesPoint(1, 4.0))
                series2.Points.Add(New SeriesPoint(3, 3.31))
                series2.Points.Add(New SeriesPoint(5, 2.81))
                series2.Points.Add(New SeriesPoint(7, 2.0))
                series2.Points.Add(New SeriesPoint(9, 0.882))
                series2.Points.Add(New SeriesPoint(11, 0.194))

                series3.Points.Add(New SeriesPoint(1, 1.52))
                series3.Points.Add(New SeriesPoint(3, 1.2))
                series3.Points.Add(New SeriesPoint(5, 0.711))
                series3.Points.Add(New SeriesPoint(7, 0.405))
                series3.Points.Add(New SeriesPoint(9, 0.059))
                series3.Points.Add(New SeriesPoint(11, 0.01))

                '마커 제거 
                CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
                CType(series2.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
                CType(series3.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True

                .XrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.LeftOutside
                .XrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Top

                .XrChart1.Series.Add(series1)
                .XrChart1.Series.Add(series2)
                .XrChart1.Series.Add(series3)

                .XrChart1.Series(0).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
                .XrChart1.Series(1).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
                .XrChart1.Series(2).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False

                Dim diagram As XYDiagram = CType(.XrChart1.Diagram, XYDiagram)

                '나이에 따른 결과분석 영역
                Select Case True
                    Case Val(txtPtAge.EditValue) >= 20 AndAlso Val(txtPtAge.EditValue) < 24.9
                        diagram.AxisX.Strips.Add(New Strip("Strip 1", 0, 2))
                    Case Val(txtPtAge.EditValue) >= 25 AndAlso Val(txtPtAge.EditValue) < 29.9
                        diagram.AxisX.Strips.Add(New Strip("Strip 1", 2, 4))
                    Case Val(txtPtAge.EditValue) >= 30 AndAlso Val(txtPtAge.EditValue) < 34.9
                        diagram.AxisX.Strips.Add(New Strip("Strip 1", 4, 6))
                    Case Val(txtPtAge.EditValue) >= 35 AndAlso Val(txtPtAge.EditValue) < 39.9
                        diagram.AxisX.Strips.Add(New Strip("Strip 1", 6, 8))
                    Case Val(txtPtAge.EditValue) >= 40 AndAlso Val(txtPtAge.EditValue) < 44.9
                        diagram.AxisX.Strips.Add(New Strip("Strip 1", 8, 10))
                    Case Val(txtPtAge.EditValue) >= 45 AndAlso Val(txtPtAge.EditValue) < 50.9
                        diagram.AxisX.Strips.Add(New Strip("Strip 1", 10, 12))
                End Select

                '결과값에 따른 선 
                With diagram.AxisY.ConstantLines(diagram.AxisY.ConstantLines.Add(New ConstantLine("제조사", .mAMHResult)))
                    .Color = Color.PaleVioletRed
                    .LineStyle.Thickness = 2
                    .Title.Alignment = ConstantLineTitleAlignment.Far
                    .Title.Visible = False
                    .ShowInLegend = True
                End With

                ' Customize the strip's behavior.(strip's설정)
                diagram.AxisX.Strips(0).Visible = True
                diagram.AxisX.Strips(0).ShowAxisLabel = False
                diagram.AxisX.Strips(0).AxisLabelText = ""
                diagram.AxisX.Strips(0).ShowInLegend = False
                diagram.AxisX.Strips(0).LegendText = ""

                ' Customize the strip's appearance.(strip's설정)
                diagram.AxisX.Strips(0).Color = Color.SkyBlue
                diagram.AxisX.Strips(0).FillStyle.FillMode = FillMode.Empty

                'x 값 이름 변경
                diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="20-24", value:=1))
                diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="25-29", value:=3))
                diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="30-34", value:=5))
                diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="35-39", value:=7))
                diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="40-44", value:=9))
                diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="45-50", value:=11))

                '----------------------------------------------------------------------------------------------------------------
                Dim series4 As Series = New Series("Side-by-Side Bar Series 1", ViewType.StackedBar)
                Dim series5 As Series = New Series("Side-by-Side Bar Series 2", ViewType.StackedBar)
                Dim series6 As Series = New Series("Side-by-Side Bar Series 3", ViewType.StackedBar)

                series4.Points.Add(New SeriesPoint(0, 0))
                series4.Points.Add(New SeriesPoint(1, 1))
                series4.Points.Add(New SeriesPoint(2, 0))
                series4.Points.Add(New SeriesPoint(3, 12))
                series4.Points.Add(New SeriesPoint(4, 0))
                series4.Points.Add(New SeriesPoint(5, 63))
                series4.Points.Add(New SeriesPoint(6, 0))

                series5.Points.Add(New SeriesPoint(0, 0))
                series5.Points.Add(New SeriesPoint(1, 24))
                series5.Points.Add(New SeriesPoint(2, 0))
                series5.Points.Add(New SeriesPoint(3, 57))
                series5.Points.Add(New SeriesPoint(4, 0))
                series5.Points.Add(New SeriesPoint(5, 32))
                series5.Points.Add(New SeriesPoint(6, 0))

                series6.Points.Add(New SeriesPoint(0, 0))
                series6.Points.Add(New SeriesPoint(1, 75))
                series6.Points.Add(New SeriesPoint(2, 0))
                series6.Points.Add(New SeriesPoint(3, 31))
                series6.Points.Add(New SeriesPoint(4, 0))
                series6.Points.Add(New SeriesPoint(5, 4))
                series6.Points.Add(New SeriesPoint(6, 0))

                .XrChart2.Series.Add(series4)
                .XrChart2.Series.Add(series5)
                .XrChart2.Series.Add(series6)

                ' Hide the legend (if necessary).
                .XrChart2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

                CType(.XrChart2.Diagram, XYDiagram).AxisY.WholeRange.MaxValue = 90

                'CType(.XrChart2.Diagram, XYDiagram).AxisX.WholeRange.MaxValue = 12

                ' Rotate the diagram (if necessary).
                CType(.XrChart2.Diagram, XYDiagram).Rotated = True

                Dim diagram2 As XYDiagram = CType(.XrChart2.Diagram, XYDiagram)

                Select Case True
                    Case Val(.mAMHResult) > 2.28
                        diagram2.AxisX.Strips.Add(New Strip("Strip 2", 0, 2))
                    Case Val(.mAMHResult) >= 0.69 And Val(.mAMHResult) <= 2.28
                        diagram2.AxisX.Strips.Add(New Strip("Strip 2", 2, 4))
                    Case Val(.mAMHResult) < 0.69
                        diagram2.AxisX.Strips.Add(New Strip("Strip 2", 4, 6))
                End Select

                ' Customize the strip's behavior.(다이어그램설정)
                diagram2.AxisX.Strips(0).Visible = True
                diagram2.AxisX.Strips(0).ShowAxisLabel = False
                diagram2.AxisX.Strips(0).AxisLabelText = ""
                diagram2.AxisX.Strips(0).ShowInLegend = False
                diagram2.AxisX.Strips(0).LegendText = ""

                ' Customize the strip's appearance.(다이어그램설정)
                diagram2.AxisX.Strips(0).Color = Color.SkyBlue
                diagram2.AxisX.Strips(0).FillStyle.FillMode = FillMode.Empty

                'y 값 이름 변경
                diagram2.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="2.28이상", value:=1))
                diagram2.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="0.69이상 ~ 2.27이하", value:=3))
                diagram2.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="0.68이하", value:=5))

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

            QueryString = String.Empty
            QueryString &= " SELECT * FROM m2i_LAB201                                           " & vbNewLine
            QueryString &= " WHERE REQDATE = '" & txtAcceptDate.Text & "'                       " & vbNewLine
            QueryString &= " AND   PTID = '" & txtPtChartNo.Text & "'                           " & vbNewLine

            Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

            If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                'QueryString = String.Empty
                'QueryString &= " UPDATE m2i_LAB201                                              " & vbNewLine
                'QueryString &= "    SET REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
                'QueryString &= "      , SPCNO = '" & txtBarcodeNo.Text & "'                     " & vbNewLine
                'QueryString &= "      , PRTDATE = '" & Format(Now, "yyyy-MM-dd") & "'           " & vbNewLine
                'QueryString &= "  WHERE REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
                'QueryString &= "  AND   PTID = '" & txtPtChartNo.Text & "'                      " & vbNewLine
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
            Else
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
            End If

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

    Private Sub PsPrint()
        Dim Report_IF_AMH As Report_IF_AMH_1 = New Report_IF_AMH_1
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

            '----------------------------------------------------------------------------------------------------------------
            Dim series1 As Series = New Series("상위 5%", ViewType.Line)
            Dim series2 As Series = New Series("중간값", ViewType.Line)
            Dim series3 As Series = New Series("하위 5%", ViewType.Line)

            series1.Points.Add(New SeriesPoint(1, 9.95)) '1에 9.95
            series1.Points.Add(New SeriesPoint(3, 9.05))
            series1.Points.Add(New SeriesPoint(5, 7.59))
            series1.Points.Add(New SeriesPoint(7, 6.96))
            series1.Points.Add(New SeriesPoint(9, 4.44))
            series1.Points.Add(New SeriesPoint(11, 1.79))

            series2.Points.Add(New SeriesPoint(1, 4.0))
            series2.Points.Add(New SeriesPoint(3, 3.31))
            series2.Points.Add(New SeriesPoint(5, 2.81))
            series2.Points.Add(New SeriesPoint(7, 2.0))
            series2.Points.Add(New SeriesPoint(9, 0.882))
            series2.Points.Add(New SeriesPoint(11, 0.194))

            series3.Points.Add(New SeriesPoint(1, 1.52))
            series3.Points.Add(New SeriesPoint(3, 1.2))
            series3.Points.Add(New SeriesPoint(5, 0.711))
            series3.Points.Add(New SeriesPoint(7, 0.405))
            series3.Points.Add(New SeriesPoint(9, 0.059))
            series3.Points.Add(New SeriesPoint(11, 0.01))

            '마커 제거 
            CType(series1.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
            CType(series2.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True
            CType(series3.View, LineSeriesView).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True

            .XrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.LeftOutside
            .XrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Top

            .XrChart1.Series.Add(series1)
            .XrChart1.Series.Add(series2)
            .XrChart1.Series.Add(series3)

            .XrChart1.Series(0).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
            .XrChart1.Series(1).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
            .XrChart1.Series(2).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False

            Dim diagram As XYDiagram = CType(.XrChart1.Diagram, XYDiagram)

            '나이에 따른 결과분석 영역
            Select Case True
                Case Val(txtPtAge.EditValue) >= 20 AndAlso Val(txtPtAge.EditValue) < 24.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 0, 2))
                Case Val(txtPtAge.EditValue) >= 25 AndAlso Val(txtPtAge.EditValue) < 29.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 2, 4))
                Case Val(txtPtAge.EditValue) >= 30 AndAlso Val(txtPtAge.EditValue) < 34.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 4, 6))
                Case Val(txtPtAge.EditValue) >= 35 AndAlso Val(txtPtAge.EditValue) < 39.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 6, 8))
                Case Val(txtPtAge.EditValue) >= 40 AndAlso Val(txtPtAge.EditValue) < 44.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 8, 10))
                Case Val(txtPtAge.EditValue) >= 45 AndAlso Val(txtPtAge.EditValue) < 50.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 10, 12))
            End Select

            '결과값에 따른 선 
            With diagram.AxisY.ConstantLines(diagram.AxisY.ConstantLines.Add(New ConstantLine("제조사", .mAMHResult)))
                .Color = Color.PaleVioletRed
                .LineStyle.Thickness = 2
                .Title.Alignment = ConstantLineTitleAlignment.Far
                .Title.Visible = False
                .ShowInLegend = True
            End With

            ' Customize the strip's behavior.(strip's설정)
            diagram.AxisX.Strips(0).Visible = True
            diagram.AxisX.Strips(0).ShowAxisLabel = False
            diagram.AxisX.Strips(0).AxisLabelText = ""
            diagram.AxisX.Strips(0).ShowInLegend = False
            diagram.AxisX.Strips(0).LegendText = ""

            ' Customize the strip's appearance.(strip's설정)
            diagram.AxisX.Strips(0).Color = Color.SkyBlue
            diagram.AxisX.Strips(0).FillStyle.FillMode = FillMode.Empty

            'x 값 이름 변경
            diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="20-24", value:=1))
            diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="25-29", value:=3))
            diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="30-34", value:=5))
            diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="35-39", value:=7))
            diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="40-44", value:=9))
            diagram.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="45-50", value:=11))

            '----------------------------------------------------------------------------------------------------------------
            Dim series4 As Series = New Series("Side-by-Side Bar Series 1", ViewType.StackedBar)
            Dim series5 As Series = New Series("Side-by-Side Bar Series 2", ViewType.StackedBar)
            Dim series6 As Series = New Series("Side-by-Side Bar Series 3", ViewType.StackedBar)

            series4.Points.Add(New SeriesPoint(0, 0))
            series4.Points.Add(New SeriesPoint(1, 1))
            series4.Points.Add(New SeriesPoint(2, 0))
            series4.Points.Add(New SeriesPoint(3, 12))
            series4.Points.Add(New SeriesPoint(4, 0))
            series4.Points.Add(New SeriesPoint(5, 63))
            series4.Points.Add(New SeriesPoint(6, 0))

            series5.Points.Add(New SeriesPoint(0, 0))
            series5.Points.Add(New SeriesPoint(1, 24))
            series5.Points.Add(New SeriesPoint(2, 0))
            series5.Points.Add(New SeriesPoint(3, 57))
            series5.Points.Add(New SeriesPoint(4, 0))
            series5.Points.Add(New SeriesPoint(5, 32))
            series5.Points.Add(New SeriesPoint(6, 0))

            series6.Points.Add(New SeriesPoint(0, 0))
            series6.Points.Add(New SeriesPoint(1, 75))
            series6.Points.Add(New SeriesPoint(2, 0))
            series6.Points.Add(New SeriesPoint(3, 31))
            series6.Points.Add(New SeriesPoint(4, 0))
            series6.Points.Add(New SeriesPoint(5, 4))
            series6.Points.Add(New SeriesPoint(6, 0))

            .XrChart2.Series.Add(series4)
            .XrChart2.Series.Add(series5)
            .XrChart2.Series.Add(series6)

            ' Hide the legend (if necessary).
            .XrChart2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

            CType(.XrChart2.Diagram, XYDiagram).AxisY.WholeRange.MaxValue = 90

            'CType(.XrChart2.Diagram, XYDiagram).AxisX.WholeRange.MaxValue = 12

            ' Rotate the diagram (if necessary).
            CType(.XrChart2.Diagram, XYDiagram).Rotated = True

            Dim diagram2 As XYDiagram = CType(.XrChart2.Diagram, XYDiagram)

            Select Case True
                Case Val(.mAMHResult) > 2.28
                    diagram2.AxisX.Strips.Add(New Strip("Strip 2", 0, 2))
                Case Val(.mAMHResult) >= 0.69 And Val(.mAMHResult) <= 2.28
                    diagram2.AxisX.Strips.Add(New Strip("Strip 2", 2, 4))
                Case Val(.mAMHResult) < 0.69
                    diagram2.AxisX.Strips.Add(New Strip("Strip 2", 4, 6))
            End Select

            ' Customize the strip's behavior.(다이어그램설정)
            diagram2.AxisX.Strips(0).Visible = True
            diagram2.AxisX.Strips(0).ShowAxisLabel = False
            diagram2.AxisX.Strips(0).AxisLabelText = ""
            diagram2.AxisX.Strips(0).ShowInLegend = False
            diagram2.AxisX.Strips(0).LegendText = ""

            ' Customize the strip's appearance.(다이어그램설정)
            diagram2.AxisX.Strips(0).Color = Color.SkyBlue
            diagram2.AxisX.Strips(0).FillStyle.FillMode = FillMode.Empty

            'y 값 이름 변경
            diagram2.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="2.28이상", value:=1))
            diagram2.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="0.69이상 ~ 2.27이하", value:=3))
            diagram2.AxisX.CustomLabels.Add(New CustomAxisLabel(name:="0.68이하", value:=5))

        End With

        'prevView (x)---------------------------------------------------------------------------------------------------------
        'Dim printTool As New ReportPrintTool(Report_IF_AMH)

        ' PrintDocument 인스턴스 생성
        'Dim printDocument As New PrintDocument()

        ' printTool.PrintingSystem.PageMargins = New Margins(50, 50, 50, 50) ' 여백 설정
        ' printTool.PrintingSystem.Landscape = True ' 가로 방향으로 출력 설정
        'printTool.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4 ' 용지 종류 설정

        ' 보고서를 바로 출력
        'printTool.Print()
        '---------------------------------------------------------------------------------------------------------------------

        'prevView (O)---------------------------------------------------------------------------------------------------------
        With frmReportView
            .dcvPrevView.DocumentSource = Report_IF_AMH
            Report_IF_AMH.CreateDocument()
            .ShowDialog()

            'If .DialogResult = DialogResult.OK Then
            '    SimpleButton1_Click(sender, e)
            'End If
        End With
        '---------------------------------------------------------------------------------------------------------------------

        QueryString = String.Empty
        QueryString &= " SELECT * FROM m2i_LAB201                                           " & vbNewLine
        QueryString &= " WHERE REQDATE = '" & txtAcceptDate.Text & "'                       " & vbNewLine
        QueryString &= " AND   PTID = '" & txtPtChartNo.Text & "'                           " & vbNewLine

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            'QueryString = String.Empty
            'QueryString &= " UPDATE m2i_LAB201                                              " & vbNewLine
            'QueryString &= "    SET REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
            'QueryString &= "      , SPCNO = '" & txtBarcodeNo.Text & "'                     " & vbNewLine
            'QueryString &= "      , PRTDATE = '" & Format(Now, "yyyy-MM-dd") & "'           " & vbNewLine
            'QueryString &= "  WHERE REQDATE = '" & txtAcceptDate.Text & "'                  " & vbNewLine
            'QueryString &= "  AND   PTID = '" & txtPtChartNo.Text & "'                      " & vbNewLine
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
        Else
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
        End If

        If QueryString.Length > 0 Then
            ClsDb.CfMExecuteQuery(QueryString)
        End If

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