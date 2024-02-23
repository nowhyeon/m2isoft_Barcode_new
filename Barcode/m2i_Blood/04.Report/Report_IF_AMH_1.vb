Imports DevExpress.XtraEditors
Imports DevExpress.XtraCharts
Imports System.Drawing.Printing



Public Class Report_IF_AMH
    Public mPTNM As String
    Public mMedOffice As String
    Public mDoctor As String
    Public mChartNo As String
    Public mAcceptDate As String
    Public mReceiptDate As String
    Public mBirth As String
    Public mAge As String
    Public mSex As String
    Public mLow As String
    Public mHigh As String
    Public mAMHResult As String
    Public mComment1 As String
    Public mComment2 As String
    Public mComment3 As String
    Public mComment4 As String
    Public mRemark As String
    Public mRemark1 As String

    Public mAMHConn As String
    Public strAFC1 As String

    Public mAddress As String
    Public mSpace As String = "                         "

    Private ClsDb As New ClsDatabase

    Private Sub VisitReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint

        Dim sex As String

        With frmAMHTest
            If .txtPtSex.EditValue = "F" Then
                sex = "여"
            ElseIf .txtPtSex.EditValue = "M" Then
                sex = "남"
            Else
                sex = "공통"
            End If

            mPTNM = .txtPtnm.EditValue
            mBirth = .txtPtBirth.EditValue
            mSex = sex
            mAge = .txtPtAge.EditValue
            mChartNo = .txtPtChartNo.EditValue
            mMedOffice = .txtMedOffice.EditValue
            mReceiptDate = .txtReceiptDate.EditValue
            mDoctor = .txtDoctor.EditValue
            mAcceptDate = .txtAcceptDate.EditValue
            mAMHResult = .RESULT.Text

            '---------------------------------------------------------------------------------------------------------------
            Dim series1 As Series = New Series("상위 5%", ViewType.Line)
            Dim series2 As Series = New Series("중간값", ViewType.Line)
            Dim series3 As Series = New Series("하위 5%", ViewType.Line)
            Dim series4 As Series = New Series("Side-by-Side Bar Series 1", ViewType.StackedBar)
            Dim series5 As Series = New Series("Side-by-Side Bar Series 2", ViewType.StackedBar)
            Dim series6 As Series = New Series("Side-by-Side Bar Series 3", ViewType.StackedBar)

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


            XrChart1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.LeftOutside
            XrChart1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.Top

            XrChart1.Series.Add(series1)
            XrChart1.Series.Add(series2)
            XrChart1.Series.Add(series3)

            XrChart1.Series(0).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
            XrChart1.Series(1).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
            XrChart1.Series(2).LabelsVisibility = DevExpress.Utils.DefaultBoolean.False
            '------------------------------------------------------------------------------------------------------

            Dim diagram As XYDiagram = CType(XrChart1.Diagram, XYDiagram)

            '나이에 따른 결과분석 영역
            Select Case True
                Case Val(.txtPtAge.EditValue) >= 20 AndAlso Val(.txtPtAge.EditValue) < 24.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 0, 2))
                Case Val(.txtPtAge.EditValue) >= 25 AndAlso Val(.txtPtAge.EditValue) < 29.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 2, 4))
                Case Val(.txtPtAge.EditValue) >= 30 AndAlso Val(.txtPtAge.EditValue) < 34.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 4, 6))
                Case Val(.txtPtAge.EditValue) >= 35 AndAlso Val(.txtPtAge.EditValue) < 39.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 6, 8))
                Case Val(.txtPtAge.EditValue) >= 40 AndAlso Val(.txtPtAge.EditValue) < 44.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 8, 10))
                Case Val(.txtPtAge.EditValue) >= 45 AndAlso Val(.txtPtAge.EditValue) < 50.9
                    diagram.AxisX.Strips.Add(New Strip("Strip 1", 10, 12))

            End Select

            '결과값에 따른 선 
            With diagram.AxisY.ConstantLines(diagram.AxisY.ConstantLines.Add(New ConstantLine("결과값", mAMHResult)))
                .Color = Color.PaleVioletRed
                .LineStyle.Thickness = 2
                .Title.Alignment = ConstantLineTitleAlignment.Far
                .Title.Visible = False
                .ShowInLegend = True
            End With

            'Customize the strip's behavior.(strip's설정)
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

            XrChart2.Series.Add(series4)
            XrChart2.Series.Add(series5)
            XrChart2.Series.Add(series6)

            ' Hide the legend (if necessary).
            XrChart2.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False

            CType(XrChart2.Diagram, XYDiagram).AxisY.WholeRange.MaxValue = 90

            'CType(.XrChart2.Diagram, XYDiagram).AxisX.WholeRange.MaxValue = 12

            ' Rotate the diagram (if necessary).
            CType(XrChart2.Diagram, XYDiagram).Rotated = True

            Dim diagram2 As XYDiagram = CType(XrChart2.Diagram, XYDiagram)

            Select Case True
                Case Val(mAMHResult) > 2.28
                    diagram2.AxisX.Strips.Add(New Strip("Strip 2", 0, 2))
                Case Val(mAMHResult) >= 0.69 And Val(mAMHResult) <= 2.28
                    diagram2.AxisX.Strips.Add(New Strip("Strip 2", 2, 4))
                Case Val(mAMHResult) < 0.69
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

        strAFC1 = String.Empty
        If Val(mAMHResult) > 2.28 Then
            strAFC1 &= vbCrLf & "● AFC 0개 이상 ~ 7개 미만인 확률은 1%"
            strAFC1 &= vbCrLf & "● AFC 8개 이상 ~ 15개 미만인 확률은 24%"
            strAFC1 &= vbCrLf & "● AFC 15개 초과 일 확률은 75% 입니다."
        ElseIf Val(mAMHResult) >= 0.69 And Val(mAMHResult) <= 2.28 Then
            strAFC1 &= vbCrLf & "● AFC 0개 이상 ~ 7개 미만인 확률은 12%"
            strAFC1 &= vbCrLf & "● AFC 8개 이상 ~ 15개 미만인 확률은 57%"
            strAFC1 &= vbCrLf & "● AFC 15개 초과 일 확률은 31% 입니다."
        ElseIf Val(mAMHResult) < 0.69 Then
            strAFC1 &= vbCrLf & "● AFC 0개 이상 ~ 7개 미만인 확률은 63%"
            strAFC1 &= vbCrLf & "● AFC 8개 이상 ~ 15개 미만인 확률은 32%"
            strAFC1 &= vbCrLf & "● AFC 15개 초과 일 확률은 4% 입니다."
        End If

        mComment1 = String.Empty
        If Val(mAMHResult) < 0.01 Then
            mComment1 &= vbCrLf & "AMH 결과값 0.01 이하 ng/ml 이며 "
        ElseIf Val(mAMHResult) >= 0.01 And Val(mAMHResult) <= 23 Then
            mComment1 &= vbCrLf & "AMH 결과값 " & mAMHResult & " ng/ml 이며 "
        Else
            mComment1 &= vbCrLf & "AMH 결과값 23 이상 ng/ml 이며"
        End If




        QueryString = String.Empty
        QueryString &= " SELECT *                                       " & vbCrLf
        QueryString &= " FROM [AMH_JUDGE]                               " & vbCrLf
        QueryString &= " WHERE Val(age_f) <='" & Val(mAge) & "'         " & vbCrLf
        QueryString &= " AND Val(age_to) >= '" & Val(mAge) & "'         " & vbCrLf
        QueryString &= " AND val(low) < '" & Val(mAMHResult) & "'       " & vbCrLf
        QueryString &= " AND val(high)>= '" & Val(mAMHResult) & "'      " & vbCrLf

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            mLow = sTable.Rows(0)("LOW").ToString
            mHigh = sTable.Rows(0)("HIGH").ToString
            mComment2 = sTable.Rows(0)("COMMENT").ToString
            mRemark = sTable.Rows(0)("REMARK").ToString
            mRemark1 = sTable.Rows(0)("REMARK1").ToString
        Else
            XtraMessageBox.Show(_sMsg.sMsg_NoContents, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        mComment2 = "수검자 연령대의 [ " & mComment2 & "] 구간에 해당하며 "

        If Val(mAMHResult) >= 4.45 Then
            mComment3 = " 만 20세 여성 중앙값 이상입니다."
        ElseIf Val(mAMHResult) < 0.1 Then
            mComment3 = " 만 50세 여성 중앙값 이하입니다."
        ElseIf Val(mAMHResult) >= 0.1 And Val(mAMHResult) < 4.45 Then

            If mAMHResult <> "" Then
                '계산공식: (나이) = (정량결과 - 7.6241) / 0.155 * -1
                mAMHConn = (Val(mAMHResult) - 7.6241) / 0.155 * -1
                '           절대값  소수점 버림     
                mAMHConn = Math.Abs(Fix(mAMHConn))
            Else
                mAMHConn = ""
            End If

            '                          계산공식 = (정량결과 - 7.4908) / 0.1502 * -1
            '                        strAMHConn = (Val(strAMHResult) - 7.6241) / 0.155  * -1
            '                        strAMHConn = Abs(Fix(strAMHConn))
            mComment3 = "만 " & mAMHConn & " 세 중앙값에 해당합니다."

        End If


        If Val(mAge) < 20 Or Val(mAge) > 50 Then
            mComment4 = mRemark1
        Else
            If mRemark <> "" Then
                mComment4 = mComment1 & mComment2 & vbCrLf & mRemark & vbCrLf & mRemark1
            Else
                mComment4 = mComment1 & mComment2 & mComment3 '& vbCrLf & vbCrLf & strAMHRemark1
            End If

        End If

        ' 나이 및 결과수치별 Remark 내용 표시 <-수정필요 
        'If Val(mAge) >= 20 And Val(mAge) < 25 Then
        '    If Val(mLow) >= 0 And Val(mHigh) <= 1.22 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    ElseIf Val(mLow) >= 11.7 And Val(mHigh) <= 100 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    End If
        'ElseIf Val(mAge) >= 25 And Val(mAge) < 30 Then
        '    If Val(mLow) >= 0 And Val(mHigh) <= 0.89 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    ElseIf Val(mLow) >= 9.85 And Val(mHigh) <= 100 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    End If
        'ElseIf Val(mAge) >= 30 And Val(mAge) < 35 Then
        '    If Val(mAMHResult) >= 0 And Val(mAMHResult) <= 0.58 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    ElseIf Val(mAMHResult) >= 8.13 And Val(mAMHResult) <= 100 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    End If
        'ElseIf Val(mAge) >= 35 And Val(mAge) < 40 Then
        '    If Val(mAMHResult) >= 0 And Val(mAMHResult) <= 0.15 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    ElseIf Val(mAMHResult) >= 7.49 And Val(mAMHResult) <= 100 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    End If
        'ElseIf Val(mAge) >= 40 And Val(mAge) < 45 Then
        '    If Val(mAMHResult) >= 0 And Val(mAMHResult) <= 0.03 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    ElseIf Val(mAMHResult) >= 5.47 And Val(mAMHResult) <= 100 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    End If
        'ElseIf Val(mAge) >= 45 And Val(mAge) < 50 Then
        '    If Val(mAMHResult) >= 0 And Val(mAMHResult) <= 0.01 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    ElseIf Val(mAMHResult) >= 2.71 And Val(mAMHResult) <= 100 Then
        '        lblRemark.Text = mRemark & vbCrLf & mRemark1
        '    End If
        'Else
        '    If Val(mAMHResult) >= 0 And Val(mAMHResult) <= 100 Then
        '        lblRemark.Text = mRemark1
        '    End If
        'End If

        lblPTNM.Text = mPTNM
        lblMedOffice.Text = mMedOffice
        lblDoctor.Text = mDoctor
        lblChartNo.Text = mChartNo
        lblAcceptDate.Text = mAcceptDate
        lblReceiptDate.Text = mReceiptDate
        lblBirth.Text = mBirth
        lblAge.Text = mSex & " / " & mAge
        lblAMHResult.Text = mAMHResult
        lblAMHComment1.Text = mComment4
        lblAMHComment2.Text = strAFC1


        ' 보고서 하단 병원 주소 입력
        mAddress = String.Empty
        mAddress &= "부산광역시 북구 덕천동 금곡대로 15 미래로병원" & vbCrLf
        mAddress &= mSpace & "대표번호: 051-330-5000"
        lblAddress.Text = mAddress
    End Sub

End Class