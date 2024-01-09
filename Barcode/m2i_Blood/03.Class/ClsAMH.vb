Public Class ClsAMH
    Private ClsEncrypt As New ClsEncryptDecrypt
    Private ClsErrorLog As New ClsErrorsAndEvents
    Private ClsDb As New ClsDatabase

    Public Function HOSPITAL_ORDER_PATIENT_GET(ByVal strDate As String,  '접수날짜
                                               ByVal strPTID As String  '차트번호
                                               ) As DataTable

        '검사항목 부분만 조회
        Dim sqldoc As String = String.Empty
        sqldoc = sqldoc & vbCrLf & " SELECT b.ORDERCODE AS TESTCODE                                           "
        sqldoc = sqldoc & vbCrLf & " FROM SLA_LabMaster a, SLA_LabResult b                                    "
        sqldoc = sqldoc & vbCrLf & " WHERE a.PTNO = b.PTNO                                                    "
        sqldoc = sqldoc & vbCrLf & " AND a.RECEIPTDATE = format(CONVERT(DATE,'" & strDate & "'),'yyyy-MM-dd') "
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

    Public Function HOSPITAL_ORDER_AMH_LIST_GET(ByVal strFromDate As String,   ' 시작날짜
                                            ByVal strToDate As String,     ' ~까지의 날짜
                                            ByVal strSearchType As String, ' 검색 형식
                                            ByVal strSearchText As String  ' 검색어
                                            ) As DataTable

        Dim sqldoc As String = String.Empty
        sqldoc = sqldoc & vbCrLf & " SELECT a.PTNO                                                                                                  AS PTID "
        sqldoc = sqldoc & vbCrLf & "      , a.SNAME                                                                                                 AS PTNM "
        sqldoc = sqldoc & vbCrLf & "      , format(CONVERT(DATE,a.ReceiptDate),'yyyy-MM-dd')                                                       AS REQDATE "
        sqldoc = sqldoc & vbCrLf & "      , a.SEX                                                                                                  AS PTSEX "
        'sqldoc = sqldoc & vbCrLf & "      , CONCAT(SUBSTRING(b.ReceiptDate, 3, 2),SUBSTRING(b.ReceiptDate, 6, 2) , RIGHT(b.ReceiptDate, 2),a.PTNO) As SPCNO "
        sqldoc = sqldoc & vbCrLf & "      , RIGHT('000000000000'+CAST(CONCAT(DATEDIFF(day, b.ReceiptDate,format(getdate(),'yyyyMMdd')),a.PTNO)AS VARCHAR(12)),12) As SPCNO "
        sqldoc = sqldoc & vbCrLf & "      , a.AGE                                                                                                  AS PTAGE "
        sqldoc = sqldoc & vbCrLf & "      , a.SIGNIN                                                                                                        "
        sqldoc = sqldoc & vbCrLf & "      , a.DeptCode                                                                                                      "
        sqldoc = sqldoc & vbCrLf & "      , b.RESULT                                                                                                      "
        sqldoc = sqldoc & vbCrLf & "      , b.RESULTDATE                                                                                                    "
        sqldoc = sqldoc & vbCrLf & "   FROM SLA_LabMaster a, SLA_LabResult b                                                                                "
        sqldoc = sqldoc & vbCrLf & "  WHERE a.PTNO = b.PTNO                                                                                                 "
        sqldoc = sqldoc & vbCrLf & "    AND a.ReceiptDate between CONVERT(DATE,'" & strFromDate & "') AND CONVERT(DATE,'" & strToDate & "')   -- 접수일자   "
        sqldoc = sqldoc & vbCrLf & "    AND b.ORDERCODE in ('AMH')                              -- 검사코드"
        Debug.Print(sqldoc)
        If strSearchType <> "" Then
            Select Case strSearchType
                Case "이름" : sqldoc = sqldoc & vbCrLf & "           AND a.SNAME      LIKE '%" & strSearchText & "%'        "
                Case "차트번호" : sqldoc = sqldoc & vbCrLf & "       AND a.PTNO       LIKE '%" & strSearchText & "%'        "
                Case Else
            End Select
        End If
        sqldoc = sqldoc & vbCrLf & " ORDER BY REQDATE, SPCNO                                                         "
        Debug.Print(sqldoc)
        Dim sTable As DataTable = ClsDb.CfSelectQuery(sqldoc)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            Return sTable
        Else
            Return Nothing
        End If
    End Function

    Public Function HOSPITAL_ORDER_AMH_RESULT(ByVal strDate As String, ByVal strPTID As String) As DataTable

        QueryString = String.Empty
        QueryString &= " SELECT b.ORDERCODE AS TESTCODE                                                      " & vbCrLf
        QueryString &= " ,b.LABNAME                                                                          " & vbCrLf
        QueryString &= " ,a.PTNO                                                                             " & vbCrLf
        QueryString &= " ,a.SNAME                                                                            " & vbCrLf
        QueryString &= " ,a.AGE                                                                              " & vbCrLf
        QueryString &= " ,b.RESULT                                                                           " & vbCrLf
        QueryString &= " FROM SLA_LabMaster a, SLA_LabResult b                                               " & vbCrLf
        QueryString &= " WHERE a.PTNO = b.PTNO                                                               " & vbCrLf
        QueryString &= " AND a.RECEIPTDATE = format(CONVERT(DATE,'" & strDate & "'),'yyyy-MM-dd')            " & vbCrLf
        QueryString &= " and   a.PTNO = '" & strPTID & "'                                                    " & vbCrLf
        QueryString &= " And b.LABNAME In  ('AMH')                                                           " & vbCrLf
        QueryString &= " ORDER BY TESTCODE                                                                   " & vbCrLf


        Dim sTable As DataTable = ClsDb.CfSelectQuery(QueryString)

        If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
            Return sTable
        Else
            Return Nothing
        End If

    End Function

End Class
