﻿Public Class ClsOrder
    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase

    Public Function HOSPITAL_ORDER_PATIENT_GET(ByVal strDate As String,  '접수날짜
                                               ByVal strPTID As String,  '차트번호
                                               ByVal strState As String  '접수상태
                                               ) As DataTable

        '검사항목 부분만 조회
        Dim sqldoc As String = String.Empty
        sqldoc = sqldoc & vbCrLf & " SELECT b.ORDERCODE AS TESTCODE                                           "
        sqldoc = sqldoc & vbCrLf & " FROM SLA_LabMaster a, SLA_LabResult b                                    "
        sqldoc = sqldoc & vbCrLf & " WHERE a.PTNO = b.PTNO                                                    "
        sqldoc = sqldoc & vbCrLf & " AND a.RECEIPTDATE = format(CONVERT(DATE,'" & strDate & "'),'yyyy-MM-dd') "
        If strState <> "" Then
            sqldoc = sqldoc & vbCrLf & " AND a.JSTATUS = " & strState & "      -- A:04 R:02                   "
        End If
        sqldoc = sqldoc & vbCrLf & " and   a.PTNO = '" & strPTID & "'                                         "
        sqldoc = sqldoc & vbCrLf & " and   b.LABNAME in  (" & gTestCode & " )   -- 검사코드                   "
        sqldoc = sqldoc & vbCrLf & " ORDER BY TESTCODE                                                        "

        Dim sTable As DataTable = ClsDb.CfSelectQuery(sqldoc)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            Return sTable
        Else
            Return Nothing
        End If

    End Function

    Public Function HOSPITAL_ORDER_LIST_GET(ByVal strFromDate As String,   ' 시작날짜
                                            ByVal strToDate As String,     ' ~까지의 날짜
                                            ByVal strRcptType As String,   ' 접수 형식
                                            ByVal strSearchType As String, ' 검색 형식
                                            ByVal strSearchText As String  ' 검색어
                                            ) As DataTable

        Dim sqldoc As String = String.Empty
        sqldoc = sqldoc & vbCrLf & " SELECT a.PTNO                                                                                                  AS PTID                "
        sqldoc = sqldoc & vbCrLf & "      , a.SNAME                                                                                                 AS PTNM                "
        sqldoc = sqldoc & vbCrLf & "      , format(CONVERT(DATE,a.ReceiptDate),'yyyy-MM-dd')                                                       AS REQDATE              "
        sqldoc = sqldoc & vbCrLf & "      , a.SEX                                                                                                  AS PTSEX                "
        'sqldoc = sqldoc & vbCrLf & "      , CONCAT(SUBSTRING(b.ReceiptDate, 3, 2),SUBSTRING(b.ReceiptDate, 6, 2) , RIGHT(b.ReceiptDate, 2),a.PTNO) As SPCNO "
        sqldoc = sqldoc & vbCrLf & "      , RIGHT('000000000000'+CAST(CONCAT(DATEDIFF(day, b.ReceiptDate,format(getdate(),'yyyyMMdd')),a.PTNO)AS VARCHAR(12)),12) As SPCNO "
        sqldoc = sqldoc & vbCrLf & "      , a.AGE                                                                                                  AS PTAGE                "
        sqldoc = sqldoc & vbCrLf & "      , a.JSTATUS                                                                                              AS STATUS               "
        sqldoc = sqldoc & vbCrLf & "      , a.SIGNIN                                                                                                                       "
        sqldoc = sqldoc & vbCrLf & "      , b.REMARK                                                                                                                       "
        sqldoc = sqldoc & vbCrLf & "      , a.DeptCode                                                                                                                     "
        sqldoc = sqldoc & vbCrLf & "      , b.RESULTDATE                                                                                                                   "
        sqldoc = sqldoc & vbCrLf & "   FROM SLA_LabMaster a, SLA_LabResult b                                                                                               "
        sqldoc = sqldoc & vbCrLf & "  WHERE a.PTNO = b.PTNO                                                                                                                "
        sqldoc = sqldoc & vbCrLf & "    AND a.ReceiptDate between CONVERT(DATE,'" & strFromDate & "') AND CONVERT(DATE,'" & strToDate & "')   -- 접수일자                  "
        sqldoc = sqldoc & vbCrLf & "    AND b.ORDERCODE in (" & gTestCode & " )                                                               -- 검사코드                  "
        If strRcptType <> "" Then
            Select Case strRcptType
                Case "결과" : sqldoc = sqldoc & vbCrLf & " AND   a.JSTATUS   = 2                                -- 02:결과                                                 "
                Case "접수" : sqldoc = sqldoc & vbCrLf & " AND   a.JSTATUS   = 4                                -- 04:접수                                                 "
                Case Else
            End Select
        End If

        If strSearchType <> "" Then
            Select Case strSearchType
                Case "이름" : sqldoc = sqldoc & vbCrLf & "           AND a.SNAME         LIKE '%" & strSearchText & "%'                                                    "
                Case "차트번호" : sqldoc = sqldoc & vbCrLf & "       AND a.PTNO          LIKE '%" & strSearchText & "%'                                                    "
                Case "바코드번호" : sqldoc = sqldoc & vbCrLf & "     AND a.SPCNO         LIKE '%" & strSearchText & "%'                                                    "
                Case Else
            End Select
        End If
        sqldoc = sqldoc & vbCrLf & " ORDER BY REQDATE, SPCNO                                                                                                               "
        Debug.Print(sqldoc)
        Dim sTable As DataTable = ClsDb.CfSelectQuery(sqldoc)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            Return sTable
        Else
            Return Nothing
        End If
    End Function

End Class
