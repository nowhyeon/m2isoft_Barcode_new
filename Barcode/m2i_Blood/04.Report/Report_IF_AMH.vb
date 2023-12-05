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
    Public mAMHResult As String
    Public mComment1 As String
    Public mComment2 As String
    Public mComment3 As String
    Public mComment4 As String
    Public mRemark As String
    Public mRemark1 As String

    Public mAMHConn As String
    Public strAFC1 As String

    Dim ClsDb As New ClsDatabase

    Private Sub VisitReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint


        strAFC1 = String.Empty
        If Val(mAMHResult) > 2.28 Then
            strAFC1 &= vbCrLf & "● AFC 0개 이상 ~ 7개 미만인 확률은 1%"
            strAFC1 &= vbCrLf & "● AFC 8개 이상 ~ 15개 미만인 확률은 24%"
            strAFC1 &= vbCrLf & "● AFC 15개 초과 일 확룰은 75% 입니다."
        ElseIf Val(mAMHResult) >= 0.69 And Val(mAMHResult) <= 2.28 Then
            strAFC1 &= vbCrLf & "● AFC 0개 이상 ~ 7개 미만인 확률은 12%"
            strAFC1 &= vbCrLf & "● AFC 8개 이상 ~ 15개 미만인 확률은 57%"
            strAFC1 &= vbCrLf & "● AFC 15개 초과 일 확룰은 31% 입니다."
        ElseIf Val(mAMHResult) < 0.69 Then
            strAFC1 &= vbCrLf & "● AFC 0개 이상 ~ 7개 미만인 확률은 63%"
            strAFC1 &= vbCrLf & "● AFC 8개 이상 ~ 15개 미만인 확률은 32%"
            strAFC1 &= vbCrLf & "● AFC 15개 초과 일 확룰은 4% 입니다."
        End If

        mComment1 = String.Empty
        If Val(mAMHResult) < 0.01 Then
            mComment1 &= vbCrLf & "AMH 결과값 0.01 이하 ng/ml 이며 "
            'strAMHResult1 = strAMHResult 'strAMHResult1 : grid 클릭했을 때  미리보기로 보여줄 값 
        ElseIf Val(mAMHResult) >= 0.01 And Val(mAMHResult) <= 23 Then
            mComment1 &= vbCrLf & "AMH 결과값 " & mAMHResult & " ng/ml 이며 "
            'strAMHResult1 = strAMHResult
        Else
            mComment1 &= vbCrLf & "AMH 결과값 23 이상 ng/ml 이며"
            'strAMHResult1 = strAMHResult  
        End If

        QueryString = String.Empty
        QueryString &= " SELECT *                                      " & vbCrLf
        QueryString &= "   FROM AMH_JUDGE                              " & vbCrLf
        QueryString &= "  WHERE Val(age_f) <=              " & Val(mAge) & vbCrLf
        QueryString &= "    AND Val(age_to) >=       " & Val(mAge) & " " & vbCrLf
        QueryString &= "    AND val(low) <           " & Val(mAMHResult) & vbCrLf
        QueryString &= "    AND val(high)>=   " & Val(mAMHResult) & "  " & vbCrLf

        Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            'lblUser.Text = sTable.Rows(0)("EMP_NM").ToString
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

                mAMHConn = Math.Abs(Fix(mAMHConn))
            Else
                mAMHConn = ""
            End If
            ''
            '''                           계산공식 = (정량결과-7.4908)/0.1502*-1
            ''                        strAMHConn = (Val(strAMHResult) - 7.6241) / 0.155 * -1
            ''                        strAMHConn = Abs(Fix(strAMHConn))
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

        lblPTNM.Text = mPTNM
        lblMedOffice.Text = mMedOffice
        lblDoctor.Text = mDoctor
        lblChartNo.Text = mChartNo
        lblAcceptDate.Text = mAcceptDate
        lblReceiptDate.Text = mReceiptDate
        lblBirth.Text = mBirth
        lblAge.Text = mAge
        lblAMHResult.Text = mAMHResult
        lblAMHComment1.Text = mComment4
        lblAMHComment2.Text = strAFC1
        'lblAMHComment3.Text = mComment3

    End Sub
End Class