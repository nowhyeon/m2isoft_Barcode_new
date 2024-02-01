Imports System.Net
Imports System.Net.NetworkInformation
Imports System.ComponentModel
Imports System.Xml
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors

Public Class frmConfig

    Dim ClsErrorLog As New ClsErrorsAndEvents
    Dim ClsEncryption As New ClsEncryptDecrypt

    Private Sub frmConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call PsClearRoutine()

        Call Common_Load()

        With cboDBType
            .Properties.Items.Add("MSSQL")
            .Properties.Items.Add("ORACLE")
            .Properties.Items.Add("ACCESS")
        End With

        Call ReportLookUpSet(LueReport)

    End Sub

    Private Sub btnPanWork_Click(sender As Object, e As ButtonEventArgs) Handles btnPanWork.ButtonClick

        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag

            Case "Reroad"
                Call Common_Load()
            Case "Save"
                Call PsAddRoutine()
            Case "Clear"
                Call PsClearRoutine()
            Case "Close"
                Me.DialogResult = DialogResult.Cancel
                Me.Close()

        End Select

    End Sub

    Private Sub btnFileDic_Click(sender As Object, e As EventArgs) 
        Dim dlgOFD As New OpenFileDialog()
        Dim sfilePath As String

        With dlgOFD
            .InitialDirectory = Application.StartupPath
            .Filter = "MDB파일 (*.mdb)|*.mdb"
            .FilterIndex = 1
        End With

        If dlgOFD.ShowDialog = DialogResult.OK Then
            sfilePath = dlgOFD.FileName

            '-[ 텍스트 파일을 읽으려면
            'txtFileMemo.Text = My.Computer.FileSystem.ReadAllText(sfilePath)

            '-[ 인코딩된 텍스트 파일을 읽으려면 
            'txtFileMemo.Text = My.Computer.FileSystem.ReadAllText(sfilePath, System.Text.Encoding.Default)

            ' 파일의 내용을 읽어오는 부분
            'Dim strContents = System.IO.File.ReadAllText(sfilePath, System.Text.Encoding.Default)

            'txtFileMemo.Text = strContents
        Else
            Return
        End If
    End Sub

    'Private Sub DateSetupTextEdit_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub PsAddRoutine()          ' XML파일에 서브 노드들을 추가해주는 코드

        Dim ClsEncryption As New ClsEncryptDecrypt
        Dim xmlDoc As New XmlDocument()
        Try
            If XtraMessageBox.Show(_sMsg_Question.sMsgQst_Save, _sMsg_Title.sMsgTitle_Info, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim rootNode As XmlNode = xmlDoc.CreateElement("mBlood")
                xmlDoc.AppendChild(rootNode)

                Dim childNode As XmlNode = xmlDoc.CreateElement("SERVER")
                Dim childNode2 As XmlNode = xmlDoc.CreateElement("Communication")
                Dim childNode4 As XmlNode = xmlDoc.CreateElement("DateSet")
                Dim childNode5 As XmlNode = xmlDoc.CreateElement("ProgramSelect")
                Dim childNode6 As XmlNode = xmlDoc.CreateElement("ReportSelect")

                ' XML 파일에 NODE를 추가해주는 부분 
                ' - SERVER 부분에 들어가는 노드들 -
                Dim DATABASE_TYPE_Node As XmlNode = xmlDoc.CreateElement("DATABASE_TYPE")
                Dim HOST_IP_Node As XmlNode = xmlDoc.CreateElement("HOST_IP")
                Dim HOST_PORT_Node As XmlNode = xmlDoc.CreateElement("HOST_PORT")
                Dim DB__NM_Node As XmlNode = xmlDoc.CreateElement("DATABASE_NAME")
                Dim USER_ID_Node As XmlNode = xmlDoc.CreateElement("USER_ID")
                Dim PASSWORD_Node As XmlNode = xmlDoc.CreateElement("PASSWORD")

                ' - 통신설정 부분에 들어가는 노드들 -
                Dim COMM_PORT_Node As XmlNode = xmlDoc.CreateElement("COMM_PORT")
                Dim COMM_PORTNUM_Node As XmlNode = xmlDoc.CreateElement("COMM_PORTNUM")
                Dim PRINTER_IP_Node As XmlNode = xmlDoc.CreateElement("PRINTER_IP")
                Dim PRINTER_PORT_Node As XmlNode = xmlDoc.CreateElement("PRINTER_PORT")

                ' - 날짜설정 부분에 들어가는 노드들 -
                Dim NextDay_Node As XmlNode = xmlDoc.CreateElement("NextDay")
                Dim PrevDay_Node As XmlNode = xmlDoc.CreateElement("PrevDay")

                ' - 프로그램 선택 부분에 들어가는 노드들 -
                Dim ProgramIndex_Node As XmlNode = xmlDoc.CreateElement("ProgramIndex")

                ' - 보고서 선택 부분에 들어가는 노드들 -
                Dim ReportIndex_Node As XmlNode = xmlDoc.CreateElement("ReportIndex")

#Region "병원 전산 서버 연결"
                DATABASE_TYPE_Node.InnerText = cboDBType.Text                       ' DB 타입 노드에 들어갈 입력값
                childNode.AppendChild(DATABASE_TYPE_Node)

                HOST_IP_Node.InnerText = txtDBIP.Text                               ' DB IP 노드에 들어갈 입력값
                childNode.AppendChild(HOST_IP_Node)

                HOST_PORT_Node.InnerText = txtDBPort.Text                           ' DB PORT NUMBER 노드에 들어갈 입력값
                childNode.AppendChild(HOST_PORT_Node)

                DB__NM_Node.InnerText = txtDataBaseNM.Text                         ' DB 이름 노드에 들어갈 입력값
                childNode.AppendChild(DB__NM_Node)

                USER_ID_Node.InnerText = ClsEncryption.Encrypt(txtConnID.Text)      ' 접속 ID 노드에 들어갈 입력값
                childNode.AppendChild(USER_ID_Node)

                PASSWORD_Node.InnerText = ClsEncryption.Encrypt(txtConnPW.Text)     ' 접속 PW 노드에 들어갈 입력값
                childNode.AppendChild(PASSWORD_Node)
#End Region

#Region "바코드프린터기 시리얼, LAN 연결 선택"
                COMM_PORT_Node.InnerText = txtCommPort.Text                         ' 시리얼통신 포트 노드에 들어갈 입력값
                childNode2.AppendChild(COMM_PORT_Node)

                COMM_PORTNUM_Node.InnerText = txtCommPortNum.Text                   ' 시리얼통신 포트 번호에 들어갈 입력값
                childNode2.AppendChild(COMM_PORTNUM_Node)

                PRINTER_IP_Node.InnerText = txtPrtIP.Text                           ' 바코드 프린터의 IP에 들어갈 입력값
                childNode2.AppendChild(PRINTER_IP_Node)

                PRINTER_PORT_Node.InnerText = txtPrtPort.Text                       ' 바코드 프린터 포트 번호에 들어갈 입력값
                childNode2.AppendChild(PRINTER_PORT_Node)
#End Region

#Region "날짜 선택"
                NextDay_Node.InnerText = txtNextDay.Text
                childNode4.AppendChild(NextDay_Node)

                PrevDay_Node.InnerText = txtPrevDay.Text
                childNode4.AppendChild(PrevDay_Node)
#End Region

#Region "바코드, AMH 선택"
                ProgramIndex_Node.InnerText = RdgProgram.SelectedIndex
                childNode5.AppendChild(ProgramIndex_Node)
#End Region

#Region "보고서 선택"
                ReportIndex_Node.InnerText = LueReport.EditValue
                childNode6.AppendChild(ReportIndex_Node)
#End Region

                rootNode.AppendChild(childNode)
                rootNode.AppendChild(childNode2)
                rootNode.AppendChild(childNode4)
                rootNode.AppendChild(childNode5)
                rootNode.AppendChild(childNode6)

                xmlDoc.Save(Application.StartupPath & "\Common.xml")

                XtraMessageBox.Show(_sMsg.sMsg_Save, _sMsg_Title.sMsgTitle_Info, MessageBoxButtons.OK, MessageBoxIcon.Information)
#Region "프로그램 재시작"
                'If XtraMessageBox.Show(_sMsg_Question.sMsgQst_RebootOn, _sMsg_Title.sMsgTitle_Reboot, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '    Application.Exit()
                '    System.Threading.Thread.Sleep(2000)
                '    Application.Restart()
                'Else

                'End If
#End Region

            Else
                ' 저장을 안함
            End If

        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try


    End Sub

    Private Sub PsClearRoutine()

        txtCommPort.Text = String.Empty
        txtCommPortNum.Text = String.Empty
        txtPrtIP.Text = String.Empty
        txtPrtPort.Text = String.Empty
        cboDBType.Text = String.Empty
        txtDBIP.Text = String.Empty
        txtDataBaseNM.Text = String.Empty
        txtDBPort.Text = String.Empty
        txtDataBaseNM.Text = String.Empty
        txtConnID.Text = String.Empty
        txtConnPW.Text = String.Empty

    End Sub

    Private Sub Common_Load()      ' XML파일 로드 하는 코드

        Dim xmlDoc As New XmlDocument()

        Try
            If Not System.IO.File.Exists(Application.StartupPath & "\Common.xml") Then     ' 파일 존재 여부 파악
                XtraMessageBox.Show(_sMsg.sMsg_NoXML, _sMsg_Title.sMsgTitle_File, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            xmlDoc.Load(Application.StartupPath & "\Common.xml")

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

            cboDBType.Text = Str_DATABASE_TYPE
            txtDBIP.Text = Str_HOST_IP
            txtDBPort.Text = Str_HOST_PORT
            txtDataBaseNM.Text = Str_DATABASE_NAME
            txtConnID.Text = Str_USER_ID
            txtConnPW.Text = Str_PASSWORD

            txtPrtIP.Text = gPrintIP_ZD
            txtPrtPort.Text = gPrintPort

            txtNextDay.Text = NextDay
            txtPrevDay.Text = PrevDay

            RdgProgram.SelectedIndex = ProgramIndex

            LueReport.EditValue = ReportIndex

        Catch ex As Exception
            XtraMessageBox.Show(_sMsg.sMsg_Error, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ClsErrorLog.WriteToErrorLog(ex.Message, ex.StackTrace, Application.ProductName)
        End Try

    End Sub

End Class