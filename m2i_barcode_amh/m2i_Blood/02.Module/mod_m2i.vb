﻿Imports System.IO
Imports System.Net
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Xml
Imports Microsoft.Win32


Module mod_m2i

    ' 로그인 설정
    Public QueryString As String = String.Empty

    Public gUserID As String = String.Empty
    Public gUserNM As String = String.Empty
    Public gUserPASSWD As String = String.Empty
    Public gUserLEV As String = String.Empty

    ' 비밀번호 오기입 카운트(5회 오기입 시 프로그램 Exit)
    Public validPswdCount As Integer = 4

#Region "XML파일용 변수"
    ' TCPIP 프린트설정
    Public gBolFlag As String = "TCPIP"             ' LAN: TCPIP, 시리얼: SERIAL
    Public gPrintIP_ZD As String                    ' "172.0.0.101"
    Public gPrintPort As Integer                    ' 9100
    Public gPrintTimeOut As Integer = 5000

    ' DB 연결 설정
    Public Str_HOST_IP As String
    Public Str_HOST_PORT As String
    Public Str_DATABASE_NAME As String
    Public Str_DATABASE_TYPE As String
    Public Str_USER_ID As String
    Public Str_PASSWORD As String

    ' mDB 설정
    Public gMDbType As String
    Public gMDbName As String = Application.StartupPath & "\00.DATABASE\m2i_Local_DB.mdb"
    Public gMDbUserNM As String = "admin"
    Public gMDbUserPW As String = "admin"

    ' 날짜 설정
    Public NextDay As Integer   ' dtpTo 컨트롤에 들어갈 변수( dtpTo ) 양수가 들어가야 함
    Public PrevDay As Integer   ' dtpFrom 컨트롤에 들어갈 변수( dtpFrom ) 음수가 들어가야 함

    ' 프로그램 선택 설정
    Public ProgramIndex As Integer

    ' 보고서 선택 설정
    Public ReportIndex As Integer

#End Region

    ' 검사코드 받는 변수(바코드용, AMH용)
    Public gTestCode As String
    Public gTestCodeAMH As String

    ' 원격요청용 변수
    Public UserIP As String
    Public UserPC As String

    ' MDB 백업용 변수
    Public gLocalBackupFolder As String = Application.StartupPath & "\Backup\"
    Public gLocalDBFile As String = "\00.DATABASE\m2i_Local_DB.mdb"

    Dim ClsDb As New ClsDatabase
    Dim ClsErrorLog As New ClsErrorsAndEvents

    Public Structure LogEvent
        Shared _insert As String = "Data Insert"          ' 데이터 삽입 작업 시 나타내는 로그 이벤트
        Shared _modify As String = "Data Modify"          ' 데이터 수정 작업 시 나타내는 로그 이벤트
        Shared _delete As String = "Data Delete"          ' 데이터 삭제 작업 시 나타내는 로그 이벤트
        Shared _export As String = "Data List Export"     ' 데이터 목록 내보내기 작업 시
        Shared _print As String = "Data List Print"       ' 데이터 목록 인쇄 작업 시
        Shared _search As String = "Data Search"          ' 데이터 검색 작업 시
        Shared _MenuWork As String = "Menu Work"          ' 메뉴 작업 시
    End Structure

#Region "자식폼 열기"
    Public Sub OpenChildForm(childForm As XtraForm)

        childForm.TopLevel = False                                   ' 자식 폼 설정
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        'frmMDI.FluentDesignFormContainer1.Controls.Add(childForm)    ' FluentDesignFormControl에 자식 폼 추가
        frmMainNew.TabView.Container.Add(childForm)
        childForm.BringToFront()                                     ' 자식 폼을 앞으로 가져오기
        childForm.Show()                                             ' 자식 폼 표시

    End Sub
#End Region

#Region "Grid Column 설정"
    Public Sub GfColumnSet(gridNm As GridView,                     ' 그리드의 이름                             
                           textNm As String,                       ' 입력/수정할 때 기입하는 항목들의 헤드이름
                           columnNm As String,                     ' 그리드의 열이름
                           colWidth As Integer,                    ' 그리드의 열의 가로길이
                           Optional HAlian As String = "D",        ' 그리드의 셀 수평정렬 기본값: Default
                           Optional colVisible As Boolean = True,  ' 그리드의 열의 시각화 기본값: True
                           Optional colEdit As Boolean = True,     ' 그리드의 열 수정모드
                           Optional colType As String = "S",       ' 그리드의 열 타입 기본값: 텍스트모드    
                           Optional colDecTxtNum As Integer = 0,   ' 텍스트의 길이제한
                           Optional colFrozen As Boolean = False,  ' 열 길이 고정
                           Optional colLue As Object = Nothing,    ' Lookup 또는 ComboBox 타입의 열에 대한 RepositoryItem
                           Optional colSort As Boolean = False,    ' 열 정렬
                           Optional colMerge As Boolean = False)   ' 열 병합

        Dim addCol As Columns.GridColumn = gridNm.Columns.Add()

        Try
            With addCol
                .FieldName = columnNm
                .AppearanceHeader.Options.UseTextOptions = True   ' 컬럼 헤드의 텍스트 스타일 쉽게 조절
                .AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                .AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Caption = textNm                                 ' 컬럼 헤드
                .Visible = colVisible                             ' 컬럼 시각화
                .OptionsColumn.AllowEdit = colEdit                ' 컬럼 수정모드
                .MinWidth = 1
                .Width = colWidth                                 ' 칼럼 폭(넓이)
                '.OptionsColumn.AllowSort = IIf(colSort, DevExpress.Utils.DefaultBoolean.True, DevExpress.Utils.DefaultBoolean.False)      ' 칼럼 Sort유무
                .AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap  ' 줄바꿈 옵션

                Select Case HAlian.Substring(0, 1)                ' Substring(0, 1) 0: 시작 위치, 1: 추출할 문자 수
                    Case "D" : .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default
                    Case "C" : .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    Case "L" : .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                    Case "R" : .AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                End Select

                .AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                ' 그리드의 셀에 텍스트 수직정렬 옵션

                If HAlian.Length > 1 And Mid(HAlian, 2, 1) = "F" Then
                    .OptionsColumn.FixedWidth = True
                End If

                ' 컬럼 고정
                If colFrozen Then
                    .Fixed = Columns.FixedStyle.Left
                End If

                ' 셀병합의 셀단위 허용여부
                If colMerge Then
                    .OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Else
                    .OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                End If

                Select Case colType.Substring(0, 1)
                    Case "I"
                        Dim imgEdit As New RepositoryItemPictureEdit()            ' 이미지 관련 속성 제어
                        imgEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                        .ColumnEdit = imgEdit
                    Case "D"            ' Date Type
                        Dim txtEdit As New RepositoryItemTextEdit()               ' 텍스트 관련 속성 제어
                        With txtEdit
                            .Mask.MaskType = Mask.MaskType.Simple                 ' 텍스트 입력 형식 준수하게 유도
                            .Mask.EditMask = "0000-00-00"                         ' 형식화된 텍스트
                            .Mask.UseMaskAsDisplayFormat = True                   ' 사용자형식 허용
                            .Mask.ShowPlaceHolders = False                        ' 빈문자의 경우 형식문자의 표현여부
                            .Mask.SaveLiteral = True                              ' 실제값에 형식문자 포함여부
                        End With
                        .ColumnEdit = txtEdit
                    Case "N"            ' Numeric Type
                        .DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        .DisplayFormat.FormatString = "{0:n" & colDecTxtNum.ToString & "}"
                    Case "C"            ' Checkbox Type
                        Dim chkEdit As New RepositoryItemCheckEdit()
                        With chkEdit
                            .ValueChecked = CType("1", String)
                            .ValueUnchecked = CType("0", String)
                        End With
                        .ColumnEdit = chkEdit
                    Case "L"            ' Lookup Type
                        .ColumnEdit = CType(colLue, RepositoryItemLookUpEdit)
                    Case "B"           ' Combobox Type
                        .ColumnEdit = CType(colLue, RepositoryItemComboBox)
                    Case "S"
                        Dim txtEdit As New RepositoryItemTextEdit()
                        With txtEdit
                            If colType.Length > 1 Then
                                Select Case colType.Substring(1, 1)
                                    Case "P"
                                        .PasswordChar = CType("*", Char)
                                        .UseSystemPasswordChar = True
                                    Case "U"
                                        .CharacterCasing = CharacterCasing.Upper
                                End Select
                            End If
                            If colDecTxtNum > 0 Then
                                .MaxLength = colDecTxtNum
                            End If
                        End With
                        .ColumnEdit = txtEdit
                    Case "M"
                        Dim mmeEdit As New RepositoryItemMemoEdit()
                        .ColumnEdit = mmeEdit
                    Case "P"
                        Dim cmdBtn As New RepositoryItemButtonEdit
                        'cmdBtn.TextEditStyle = TextEditStyles.HideTextEditor
                        .ColumnEdit = cmdBtn
                End Select
            End With
        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try
    End Sub

#End Region

#Region "AMH 결과보고서 양식 룩업에딧 정의"
    Public Sub ReportLookUpSet(lueObj As LookUpEdit)
        Try
            QueryString = String.Empty
            QueryString &= "     SELECT DISTINCT [ID],[ReportNM] FROM [m2i_Report]            " & vbCrLf
            QueryString &= "     WHERE 1=1                                                    " & vbCrLf

            With lueObj.Properties
                .Columns.Clear()
                .TextEditStyle = Controls.TextEditStyles.DisableTextEditor                             ' 텍스트 입력 비활성화
                .DataSource = ClsDb.CfMSelectQuery(QueryString)
                .Columns.Add(New Controls.LookUpColumnInfo("ID", "번호", 100))
                .Columns.Add(New Controls.LookUpColumnInfo("ReportNM", "보고서양식", 100))
                .ValueMember = "ID"
                .DisplayMember = "ReportNM"
                .BestFitMode = Controls.BestFitMode.BestFitResizePopup
            End With

        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try
    End Sub
#End Region

#Region "frmSetup - BloodTube 룩업에딧 정의"
    Public Sub LookUpSet(lueObj As LookUpEdit)
        Try
            QueryString = String.Empty
            ' BloodTube 룩업에딧 정의
            QueryString &= "SELECT BloodTube FROM m2i_LAB002                                  " & vbCrLf
            QueryString &= "GROUP BY BloodTube                                                "

            With lueObj.Properties
                .Columns.Clear()
                .TextEditStyle = Controls.TextEditStyles.DisableTextEditor                             ' 텍스트 입력 비활성화
                .DataSource = ClsDb.CfMSelectQuery(QueryString)
                .Columns.Add(New Controls.LookUpColumnInfo("BloodTube", "채혈용기", 100))
                .ValueMember = "BloodTube"
                .DisplayMember = "BloodTube"
                .BestFitMode = Controls.BestFitMode.BestFitResizePopup
            End With
        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try
    End Sub
#End Region

#Region "바코드 프린터 단일출력"
    Public Sub Print_Barcode(ByVal sPTNM As String,          '이름
                             ByVal sBARCODE As String,       '바코드
                             ByVal sCHARTNO As String,       '차트번호
                             ByVal sSEX As String,           '성별
                             ByVal sAGE As String,           '나이
                             ByVal sMEDOFFICE As String,     '진료과
                             ByVal sRECEIPTDATE As String,   '접수일
                             ByVal sDOCTOR As String,        '담당의
                             ByVal sACCEPTDATE As String,    '처방일
                             ByVal sMEMO As String)          '메모

        Dim sIpPing As New Net.NetworkInformation.Ping()
        Dim sPingReply As Net.NetworkInformation.PingReply = sIpPing.Send(gPrintIP_ZD, gPrintTimeOut)
        Dim BarcodeString As String = String.Empty
        Dim sReturn As Boolean = False
        'Dim i As Integer

        '성별처리
        If sSEX = "F" Then
            sSEX = "여"
        ElseIf sSEX = "M" Then
            sSEX = "남"
        Else
            sSEX = "공통"
        End If

        BarcodeString = "^XA" & vbCrLf
        BarcodeString &= "^LH0,0" & vbCrLf
        BarcodeString &= "^SEE:UHANGUL.DAT^FS" & vbCrLf
        BarcodeString &= "^PON^FS" & vbCrLf
        BarcodeString &= "^CW1,E:KFONT15.FNT^FS" & vbCrLf

        BarcodeString &= "^FO45,40^CI26^A1N,25,20^FD이름 : " & sPTNM & "^FS" & vbCrLf
        BarcodeString &= "^FO340,40^CI26^A1N,25,20^FD" & sSEX & "," & sAGE & "세^FS" & vbCrLf
        BarcodeString &= "^FO45,75^CI26^A1N,25,20^FD차트번호 : " & sCHARTNO & "^FS" & vbCrLf
        BarcodeString &= "^FO45,110^CI26^A1N,25,25^FD진료과 : " & sMEDOFFICE & "^FS" & vbCrLf
        BarcodeString &= "^FO230,110^CI26^A1N,25,25^FD담당의 : " & sDOCTOR & "^FS" & vbCrLf
        BarcodeString &= "^FO135,145^CI26^A1N,25,25^FD접수날짜 : " & sRECEIPTDATE & "^FS" & vbCrLf

        BarcodeString &= "^BY2,2,80" & vbCrLf
        BarcodeString &= "^FO45,180^B3N,N,,Y,N^FD" & sBARCODE & "^FS" & vbCrLf ' B3 39
        'BarcodeString &= "^FO45,180^B3N,N,50,Y^FD" & sBARCODE & "^FS" & vbCrLf ' 같은 39인데 height 조절 

        BarcodeString &= "^PQ1,1,1,Y^FS" & vbCrLf
        BarcodeString &= "^XZ" & vbCrLf

        If gBolFlag = "SERIAL" Then
            'Try
            '    With SerialPort
            '        .Close()
            '        .PortName = "COM4"
            '        .BaudRate = 9600
            '        .DataBits = 8
            '        .StopBits = 1
            '        .Open()
            '    End With
            'Catch ex As Exception
            '    XtraMessageBox.Show("Serial Port(" & SerialPort.PortName & ") Not open !!", "Serial Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
            'End Try

            'Call PfSendCommand(BarcodeString)
        Else
            If sPingReply.Status <> Net.NetworkInformation.IPStatus.Success Then

                'Call SaveScreenShot(True)

                Dim sMsgStr As String = "BARCODE Printer(" & gPrintIP_ZD & ")에 연결할 수 없습니다." & vbCrLf & " 네트워크 연결상태를 확인 후 다시 실행해 주세요."
                XtraMessageBox.Show(sMsgStr, "프린터연결오류", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                Try
                    Using tcpClient As New System.Net.Sockets.TcpClient
                        tcpClient.Connect(gPrintIP_ZD, gPrintPort)
                        Using Writer As New System.IO.StreamWriter(tcpClient.GetStream(), System.Text.Encoding.GetEncoding("euc-kr")) 'UTF-8 인코딩 => ^CI28과 같이 사용
                            Writer.Write(BarcodeString)
                            Writer.Flush()
                        End Using
                    End Using

                    QueryString = String.Empty
                    QueryString &= " SELECT * FROM m2i_LAB201                                           " & vbNewLine
                    QueryString &= " WHERE REQDATE = '" & sRECEIPTDATE & "'                             " & vbNewLine
                    QueryString &= " AND   PTID = '" & sCHARTNO & "'                                    " & vbNewLine
                    Dim sTable As DataTable = ClsDb.CfMSelectQuery(QueryString)

                    If Not IsNothing(sTable) AndAlso sTable.Rows.Count > 0 Then
                        QueryString = String.Empty
                        QueryString &= " UPDATE m2i_LAB201                                              " & vbNewLine
                        QueryString &= " SET REQDATE = '" & sRECEIPTDATE & "'                           " & vbNewLine
                        QueryString &= "     , SPCNO = '" & sBARCODE & "'                               " & vbNewLine
                        QueryString &= "     , PRTDATE = '" & Format(Now, "yyyy-MM-dd") & "'            " & vbNewLine
                        QueryString &= " WHERE REQDATE = '" & sRECEIPTDATE & "'                         " & vbNewLine
                        QueryString &= " AND   PTID = '" & sCHARTNO & "'                                " & vbNewLine
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
                        QueryString &= "   '" & sRECEIPTDATE & "'                                       " & vbNewLine
                        QueryString &= "  ,'" & sBARCODE & "'                                           " & vbNewLine
                        QueryString &= "  ,'" & sPTNM & "'                                              " & vbNewLine
                        QueryString &= "  ,'" & sCHARTNO & "'                                           " & vbNewLine
                        QueryString &= "  ,'" & Format(Now, "yyyy-MM-dd") & "'                          " & vbNewLine
                        QueryString &= "  )                                                             " & vbNewLine
                    End If

                    If QueryString.Length > 0 Then
                        sReturn = ClsDb.CfMExecuteQuery(QueryString)
                    End If

                Catch ex As Exception
                    XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
                End Try
            End If
        End If

    End Sub
#End Region

#Region "바코드프린터 메뉴얼(수기로) 출력"
    Public Sub Print_Manual_Print(strBarcodeNo As String,   '바코드번호
                                  strMemoComment As String) '코멘트

        Dim BarcodeString As String = String.Empty
        Dim strBarcodeString As String = String.Empty
        Dim strHeight As Integer
        Dim strFontWidth As Integer
        Dim strStartPos As Integer

        Dim sIpPing As New Net.NetworkInformation.Ping()
        Dim sPingReply As Net.NetworkInformation.PingReply = sIpPing.Send(gPrintIP_ZD, gPrintTimeOut)

        Dim strtmp
        Dim i As Integer

        BarcodeString = "^XA" & vbCrLf
        BarcodeString &= "^LH0,0" & vbCrLf
        BarcodeString &= "^SEE:UHANGUL.DAT^FS" & vbCrLf
        BarcodeString &= "^PON^FS" & vbCrLf
        BarcodeString &= "^CW1,E:KFONT15.FNT^FS" & vbCrLf

        strtmp = Split(strMemoComment, vbCrLf)

        Select Case UBound(strtmp)
            Case 0
                strHeight = 110
            Case 1
                strHeight = 70
            Case Is >= 2
                strHeight = 30
        End Select

        For i = 0 To UBound(strtmp)
            strBarcodeString = strtmp(i)

            If IsNumeric(strBarcodeString) Then                         '숫자일 때
                strFontWidth = 70
                strStartPos = 10 + (10 - Len(strBarcodeString)) * 20
            Else                                                        '문자일 때
                strFontWidth = 50
                strStartPos = 10
                If Len(strBarcodeString) < 10 Then strBarcodeString = Space(10 - Len(strBarcodeString)) & strBarcodeString
            End If

            BarcodeString = BarcodeString & vbCrLf & "^FO" & strStartPos & "," & strHeight + (80 * (i)) & "^CI26^A1N,70," & strFontWidth & "^FD" & strBarcodeString & "^FS"
        Next

        If strBarcodeNo <> "" Then
            BarcodeString &= "^BY2,2,80" & vbCrLf
            BarcodeString &= "^FO60,180^B3N,N,,Y,N^FD" & strBarcodeNo & "^FS" & vbCrLf
        End If

        BarcodeString &= "^PQ1,1,1,Y^FS" & vbCrLf
        BarcodeString &= "^XZ" & vbCrLf

        If gBolFlag = "SERIAL" Then
            'Try
            '    With SerialPort
            '        .Close()
            '        .PortName = "COM4"
            '        .BaudRate = 9600
            '        .DataBits = 8
            '        .StopBits = 1
            '        .Open()
            '    End With
            'Catch ex As Exception
            '    XtraMessageBox.Show("Serial Port(" & SerialPort.PortName & ") not open !!", "Serial Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
            'End Try

            'Call PfSendCommand(BarcodeString)
        Else
            If sPingReply.Status <> Net.NetworkInformation.IPStatus.Success Then

                'Call SaveScreenShot(True)

                Dim sMsgStr As String = "BARCODE Printer(" & gPrintIP_ZD & ")에 연결할 수 없습니다." & vbCrLf & " 네트워크 연결상태를 확인 후 다시 실행해 주세요."
                XtraMessageBox.Show(sMsgStr, "프린터연결오류", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else
                Try
                    Using tcpClient As New System.Net.Sockets.TcpClient
                        tcpClient.Connect(gPrintIP_ZD, gPrintPort)
                        Using Writer As New System.IO.StreamWriter(tcpClient.GetStream(), System.Text.Encoding.GetEncoding("euc-kr")) 'UTF-8 인코딩 => ^CI28과 같이 사용
                            Writer.Write(BarcodeString)
                            Writer.Flush()
                        End Using
                    End Using
                Catch ex As Exception
                    XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
                End Try
            End If
        End If
    End Sub
#End Region

#Region "XML파일에 저장된 내용 읽어오기"
    Public Function CommonRead() As Boolean
        Dim ClsEncryption As New ClsEncryptDecrypt

        Try
            If Not System.IO.File.Exists(Application.StartupPath & "\COMMON.XML") Then
                XtraMessageBox.Show(_sMsg.sMsg_NoLoad, _sMsg_Title.sMsgTitle_File, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(Application.StartupPath & "\COMMON.XML")

            Dim mBlood As XmlNodeList = xmlDoc.SelectNodes("/mBlood/SERVER")
            Dim mBlood2 As XmlNodeList = xmlDoc.SelectNodes("/mBlood/Communication")
            Dim mBlood4 As XmlNodeList = xmlDoc.SelectNodes("/mBlood/DateSet")
            Dim mBlood5 As XmlNodeList = xmlDoc.SelectNodes("/mBlood/ProgramSelect")
            Dim mBlood6 As XmlNodeList = xmlDoc.SelectNodes("/mBlood/ReportSelect")

            For Each SERVER As XmlNode In mBlood
                Str_DATABASE_TYPE = SERVER.SelectSingleNode("DATABASE_TYPE").InnerText
                Str_HOST_IP = SERVER.SelectSingleNode("HOST_IP").InnerText
                Str_HOST_PORT = SERVER.SelectSingleNode("HOST_PORT").InnerText
                Str_DATABASE_NAME = SERVER.SelectSingleNode("DATABASE_NAME").InnerText
                Str_USER_ID = ClsEncryption.Decrypt(SERVER.SelectSingleNode("USER_ID").InnerText)
                Str_PASSWORD = ClsEncryption.Decrypt(SERVER.SelectSingleNode("PASSWORD").InnerText)
            Next

            For Each Communication As XmlNode In mBlood2
                ' GK420d 같은 시리얼을 사용하는 프린터기에 대한 포트 설정 필요
                'Str_DATABASE_TYPE = Communication.SelectSingleNode("COMM_PORT").InnerText
                'Str_HOST_IP = Communication.SelectSingleNode("COMM_PORTNUM").InnerText
                'gPrintIP = Communication.SelectSingleNode("PC_IP").InnerText
                gPrintIP_ZD = Communication.SelectSingleNode("PRINTER_IP").InnerText
                gPrintPort = Communication.SelectSingleNode("PRINTER_PORT").InnerText
            Next

            For Each DateSet As XmlNode In mBlood4
                NextDay = DateSet.SelectSingleNode("NextDay").InnerText
                PrevDay = DateSet.SelectSingleNode("PrevDay").InnerText
            Next

            For Each ProgramSelect As XmlNode In mBlood5
                ProgramIndex = ProgramSelect.SelectSingleNode("ProgramIndex").InnerText
            Next

            For Each ReportSelect As XmlNode In mBlood6
                ReportIndex = ReportSelect.SelectSingleNode("ReportIndex").InnerText
            Next

            Return True

        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
            Return False
        End Try


    End Function
#End Region

#Region "레지스트리에 저장된 내용 읽어오기"
    Public Function ReadReg(strRegKey As String) As String

        ' HKEY_CURRENT_USER 아래 "Software\YourApplication" 경로
        Dim RegistryKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\m2isoft\ProgramSelect")

        If RegistryKey IsNot Nothing Then
            Dim Value As Object = RegistryKey.GetValue(strRegKey)

            If Value IsNot Nothing Then
                Return Value
            End If

            Console.WriteLine(Value & " 값이 전달되었습니다.")

            RegistryKey.Close()
        End If

        Return ""

    End Function
#End Region

#Region "레지스트리에 내용 저장하기"
    Public Function SaveReg(strRegKey As String, strValue As String) As Boolean

        Dim RegistryKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\m2isoft\ProgramSelect")

        RegistryKey.SetValue(strRegKey, strValue)
        RegistryKey.Close()

        Console.WriteLine(strValue & " Registry 값이 저장되었습니다.")

        SaveReg = True
    End Function
#End Region

#Region "현재 PC의 IP주소 가져오기"
    Public Function GetIPAddress() As String
        Dim hostName As String = Dns.GetHostName()
        Dim ipHostEntry As IPHostEntry = Dns.GetHostEntry(hostName)

        Dim Ipv4Address As String = ""
        For Each ipAddress As IPAddress In ipHostEntry.AddressList
            If ipAddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                Ipv4Address = ipAddress.ToString()
                Exit For
            End If
        Next

        Console.WriteLine("Local IPv4 Address: " & Ipv4Address)
        Console.ReadLine()
        Return Ipv4Address

    End Function
#End Region

#Region "현재 PC의 이름 가져오기"
    Public Function GetComputerName() As String
        Dim ComputerName As String = Environment.MachineName
        GetComputerName = ComputerName
    End Function
#End Region

#Region "백업파일 삭제"
    Public Function FileDelete(BackupFileName As String) As Boolean
        Try
            If File.Exists(BackupFileName) Then
                File.Delete(BackupFileName)
                Console.WriteLine(" > 파일이 존재하여 삭제합니다.")
            Else
                Console.WriteLine(" > 파일이 존재하지 않습니다.")
            End If

        Catch ex As Exception
            Console.WriteLine(" > 파일 삭제 중 에러 발생: " & ex.Message)
        End Try

        Return True

    End Function
#End Region


#Region "개인정보동의 여부 반환"
    Public Function Personal_Info_Agree_YN(txtID As String) As String
        Dim cDb As New ClsDatabase
        Dim sTable As DataTable

        QueryString = String.Empty
        QueryString = " SELECT [CHK_YN] FROM [m2i_LAB001] WHERE [EMP_ID] = '" & txtID & "' " & vbCrLf
        'QueryString = " WHERE [EMP_ID] = '" & txtID & "'      "

        Debug.Print(QueryString)

        sTable = ClsDb.CfMSelectQuery(QueryString)

        Return Trim(sTable(0)("CHK_YN").ToString)
    End Function
#End Region

End Module