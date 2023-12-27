Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars.Docking2010
Public Class frmRemote
    Private Sub frmRemote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Serveritems As String() = {"Help", "1515"}
        Dim Channelitems As String() = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}

        txtMyIP.Text = UserIP
        txtMyPC.Text = UserPC

        cboRemoteSer.Properties.Items.AddRange(Serveritems)
        cboWaitCh.Properties.Items.AddRange(Channelitems)

        cboRemoteSer.SelectedIndex = 1
        cboWaitCh.SelectedIndex = 0
    End Sub

    Private Sub WindowsUIButtonPanel_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsUIButtonPanel.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "Remote"
                Call PsRemote()
            Case "Close"
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
        End Select
    End Sub

    Private Sub PsRemote()
        Dim SeeTrolFile As String = "C:\Program Files (x86)\seetrol\client\SeetrolClient.exe"
        Dim SeeTrolFileName As String = String.Empty
        Dim localInfo As String

        If cboWaitCh.SelectedItem.ToString = "" Then
            XtraMessageBox.Show(_sMsg.sMsg_NoCh, _sMsg_Title.sMsgTitle_Info, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            cboWaitCh.Focus()
            Exit Sub
        End If

        Try
            localInfo = UserIP & "(" & UserPC & ")"

            '실행파일 찾기
            If System.IO.File.Exists(SeeTrolFile) Then
                SeeTrolFileName = SeeTrolFile
            Else
                Process.Start("IExplore.exe", "https://377.co.kr") '"http://" & cboServer.Text.Trim & ".seetrol.com"
            End If

            If SeeTrolFileName <> "" Then
                Process.Start(SeeTrolFileName, " -" & localInfo & " -" & cboRemoteSer.Text.Trim & ".seetrol.com -12301 -12302 -12303 -auto," & cboWaitCh.SelectedItem.ToString & ",invisible")
                Me.Close()
            End If
        Catch ex As Exception

            XtraMessageBox.Show(ex.Message, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        End Try

    End Sub

End Class