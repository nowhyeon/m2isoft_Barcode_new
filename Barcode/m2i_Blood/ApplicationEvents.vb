Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices
Imports DevExpress.XtraEditors

Namespace My
    ' MyApplication에 대해 다음 이벤트를 사용할 수 있습니다.
    ' Startup: 응용 프로그램이 시작되고 시작 폼이 만들어지기 전에 발생합니다.
    ' Shutdown: 모든 응용 프로그램 폼이 닫힌 후에 발생합니다.  이 이벤트는 응용 프로그램이 비정상적으로 종료되는 경우에는 발생하지 않습니다.
    ' UnhandledException: 응용 프로그램에서 처리되지 않은 예외가 발생하는 경우 이 이벤트가 발생합니다.
    ' StartupNextInstance: 단일 인스턴스 응용 프로그램을 시작할 때 해당 응용 프로그램이 이미 활성 상태인 경우 발생합니다. 
    ' NetworkAvailabilityChanged: 네트워크가 연결되거나 연결이 끊어질 때 발생합니다.
    Partial Friend Class MyApplication
        Dim clsDB As New ClsDatabase
        Dim clsACCESSDB As New ClsAccessDB
        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

            WindowsFormsSettings.LoadApplicationSettings()
            REM WindowsFormsSettings.DefaultFont = New System.Drawing.Font("Tahoma", 9)
            WindowsFormsSettings.DefaultFont = New System.Drawing.Font("맑은 고딕", 9)

            If CommonRead() = False Then
                End
            End If

            clsDB.MSSQL_DBOpen()
            'clsDB.ACCESS_DBOpen()

        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            CloseDB()
        End Sub

        Public Sub CloseDB()
            Dim clsDB As New ClsDatabase
            Try
                Call clsDB.CfDatabaseClose()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            Dim sMsgTitle As String = "mIF365"
            If e.IsNetworkAvailable = True Then
                Dim sMsg As String = "네트워크 상태가 ON Line입니다. 업무를 진행하시기 바랍니다."
                XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)

                'Form1.tslMessage.Text = "네트워크 상태가 ON Line입니다. 업무를 진행하시기 바랍니다."
            Else
                Dim sMsg As String = "네트워크 상태가 Off Line입니다. 확인하십시요."
                XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Form1.tslMessage.Text = "네트워크 상태가 Off Line입니다. 확인하십시요."

            End If
        End Sub

        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            Dim sMsgTitle As String = "mIF365"
            If e.BringToForeground = True Then
                Dim sMsg As String = "프로그램이 두번 실행 중 입니다."
                XtraMessageBox.Show(sMsg, sMsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub
    End Class
End Namespace
