Imports System.Drawing.Printing
Imports DevExpress.XtraEditors

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

    Private ClsDb As New ClsDatabase

    Private Sub VisitReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint


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
        QueryString &= "   FROM AMH_JUDGE                               " & vbCrLf
        QueryString &= "  WHERE Val(age_f) <='" & Val(mAge) & "'        " & vbCrLf
        QueryString &= "    AND Val(age_to) >= '" & Val(mAge) & "'      " & vbCrLf
        QueryString &= "    AND val(low) < '" & Val(mAMHResult) & "'    " & vbCrLf
        QueryString &= "    AND val(high)>= '" & Val(mAMHResult) & "'   " & vbCrLf

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            mComment2 = sTable.Rows(0)("COMMENT").ToString
            mRemark = sTable.Rows(0)("REMARK").ToString
            mRemark1 = sTable.Rows(0)("REMARK1").ToString
        Else
            Dim sMsg As String = "해당되는 사항이 없습니다 !", sMsgTitle As String = "오류"
            XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        mComment2 = "수검자 연령대의 [ " & mComment2 & "] 구간에 해당하며 "

        If Val(mAMHResult) >= 4.45 Then
            mComment3 = " 만 20세 여성 중앙값 이상입니다."
        ElseIf Val(mAMHResult) < 0.1 Then
            mComment3 = " 만 50세 여성 중앙값 이하입니다."
        ElseIf Val(mAMHResult) >= 0.1 And Val(mAMHResult) < 4.45 Then

            If mAMHResult <> "" Then
                '계산공식: (나이) = (정량결과          - 7.6241) / 0.155 * -1
                mAMHConn = (Val(mAMHResult) - 7.6241) / 0.155 * -1
                '           절대값  소수점 버림     
                mAMHConn = Math.Abs(Fix(mAMHConn))
            Else
                mAMHConn = ""
            End If
            '
            '                          계산공식 = (정량결과          - 7.4908) / 0.1502 * -1
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

        '나이에 따른 이미지
        Select Case True
            Case Val(mAge) >= 20 AndAlso Val(mAge) < 24.9
                picAMHResult.ImageUrl = Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_06.jpg"
            Case Val(mAge) >= 25 AndAlso Val(mAge) < 29.9
                picAMHResult.ImageUrl = Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_05.jpg"
            Case Val(mAge) >= 30 AndAlso Val(mAge) < 34.9
                picAMHResult.ImageUrl = Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_04.jpg"
            Case Val(mAge) >= 35 AndAlso Val(mAge) < 39.9
                picAMHResult.ImageUrl = Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_03.jpg"
            Case Val(mAge) >= 40 AndAlso Val(mAge) < 44.9
                picAMHResult.ImageUrl = Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_02.jpg"
            Case Val(mAge) >= 45 AndAlso Val(mAge) < 50.9
                picAMHResult.ImageUrl = Application.StartupPath & "\05.Rpt\AMH_Form_01\00.AMH_BACK_01.jpg"
        End Select

        '결과값에 따른 선
        Select Case True
            Case Val(mAMHResult) >= 10
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 130)
            Case Val(mAMHResult) > 9 AndAlso Val(mAMHResult) < 10
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 136.5)
            Case Val(mAMHResult) = 9
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 143)
            Case Val(mAMHResult) > 8 AndAlso Val(mAMHResult) < 9
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 136.5)
            Case Val(mAMHResult) = 8
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 156)
            Case Val(mAMHResult) > 7 AndAlso Val(mAMHResult) < 8
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 162.5)
            Case Val(mAMHResult) = 7
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 169)
            Case Val(mAMHResult) > 6 AndAlso Val(mAMHResult) < 7
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 175.5)
            Case Val(mAMHResult) = 6
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 182)
            Case Val(mAMHResult) > 5 AndAlso Val(mAMHResult) < 6
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 188.5)
            Case Val(mAMHResult) = 5
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 195)
            Case Val(mAMHResult) > 4 AndAlso Val(mAMHResult) < 5
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 201.5)
            Case Val(mAMHResult) = 4
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 208)
            Case Val(mAMHResult) > 3 AndAlso Val(mAMHResult) < 4
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 214.5)
            Case Val(mAMHResult) = 3
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 221)
            Case Val(mAMHResult) > 2 AndAlso Val(mAMHResult) < 3
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 227.5)
            Case Val(mAMHResult) = 2
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 234)
            Case Val(mAMHResult) > 1 AndAlso Val(mAMHResult) < 2
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 240.5)
            Case Val(mAMHResult) = 1
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 247)
            Case Val(mAMHResult) > 0 AndAlso Val(mAMHResult) < 1
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 253.5)
            Case Val(mAMHResult) <= 0
                AMHResultLine.LocationF = New System.Drawing.PointF(373, 260)
        End Select

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
        mAddress &= "부산마리아의원" & vbCrLf
        mAddress &= "부산광역시 연제구 월드컵대로 125 7층 마리아의원" & vbCrLf
        mAddress &= "대표번호: 051-441-6555" & vbCrLf
        lblAcceptDate.Text = mAddress
    End Sub
End Class