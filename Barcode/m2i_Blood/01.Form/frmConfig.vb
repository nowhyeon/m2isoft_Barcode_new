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

        With cboDATABASETYPE
            .Properties.Items.Add("MSSQL")
            .Properties.Items.Add("ORACLE")
            .Properties.Items.Add("ACCESS")
        End With

        With XTCSetup
            .TabPages(0).Text = "※ 서버설정"
            .TabPages(1).Text = "※ 기타정보설정"
        End With

    End Sub

    Private Sub btnMyIP_Click(sender As Object, e As EventArgs) Handles btnMyIP.Click
        Try
            Dim ipentry As IPHostEntry

            ipentry = Dns.GetHostEntry("")
            txtMyIP.Text = ipentry.AddressList(1).ToString()

            MessageBox.Show("현재 컴퓨터의 IP 주소: " & txtMyIP.Text, "IP 주소", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("IP 주소를 가져오는 중 오류가 발생했습니다: " & ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnPingTest_Click(sender As Object, e As EventArgs) Handles btnPingTest.Click

        Dim ping As New Ping
        Dim pReply As PingReply = ping.Send(txtMyIP.Text, 1000)

        MessageBox.Show("Ping Test 결과 : " & pReply.Status.ToString, "Ping Test", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub PsClearRoutine()

        txtCommPort.Text = String.Empty
        txtCommPortNum.Text = String.Empty
        txtMyIP.Text = String.Empty
        txtPrtIP.Text = String.Empty
        txtPrtPort.Text = String.Empty

    End Sub

    Private Sub Common_Load()      ' XML파일 로드 하는 코드

        Dim xmlDoc As New XmlDocument()

        Try
            If Not System.IO.File.Exists(Application.StartupPath & "\Common.xml") Then     ' 파일 존재 여부 파악
                XtraMessageBox.Show(_sMsg.sMsg_NoXML, _sMsg_Title.sMsgTitle_File, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            xmlDoc.Load(Application.StartupPath & "\Common.xml")

            Dim mIF365 As XmlNodeList = xmlDoc.SelectNodes("/mIF365/SERVER")

            For Each SERVER As XmlNode In mIF365
                gDATABASE_TYPE = SERVER.SelectSingleNode("DATABASE_TYPE").InnerText
                gHOST_IP = SERVER.SelectSingleNode("HOST_IP").InnerText
                gHOST_PORT = SERVER.SelectSingleNode("HOST_PORT").InnerText
                gDATABASE_NAME = SERVER.SelectSingleNode("DATABASE_NAME").InnerText
                gUSER_ID = ClsEncryption.Decrypt(SERVER.SelectSingleNode("USER_ID").InnerText)
                gPASSWORD = ClsEncryption.Decrypt(SERVER.SelectSingleNode("PASSWORD").InnerText)
            Next
            cboDATABASETYPE.Text = gDATABASE_TYPE
            txtIP.Text = gHOST_IP
            txtPORT.Text = gHOST_PORT
            txtDATABASE.Text = gDATABASE_NAME
            txtUSERID.Text = gUSER_ID
            txtPASSWORLD.Text = gPASSWORD
        Catch ex As Exception

        End Try


    End Sub

End Class