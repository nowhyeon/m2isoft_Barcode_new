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
            '
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
        mAddress &= "부산광역시 연제구 월드컵대로 125 7층 마리아의원" & vbCrLf
        mAddress &= "                         대표번호: 051-441-6555"
        lblAddress.Text = mAddress
    End Sub
End Class