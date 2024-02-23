Imports DevExpress.XtraEditors

Public Class frmPersonInfoAgree

    Private ClsDb As New ClsDatabase
    Private QueryString As String
    Private CheckYes As String = "Y"

    Private Sub frmPersonInfoAgree_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmdAgree.Enabled = False
    End Sub

    Private Sub ChkAgree_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAgree.CheckedChanged
        If ChkAgree.Checked = True Then
            CmdAgree.Enabled = True
        Else
            CmdAgree.Enabled = False
        End If
    End Sub

    Private Sub CmdAgree_Click(sender As Object, e As EventArgs) Handles CmdAgree.Click

        If txtUserID.Text = "" Then
            XtraMessageBox.Show(_sMsg.sMsg_NoID, _sMsg_Title.sMsgTitle_NoID, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If ChkAgree.Checked <> True Then
                XtraMessageBox.Show(_sMsg.sMsg_NoAgreeCheck, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If txtUserID.Text = frmLoginNew.txtUserID.Text Then

                    QueryString = String.Empty
                    QueryString = "UPDATE [m2i_LAB001] SET [CHK_YN] = '" & CheckYes & "' WHERE [EMP_ID] = '" & frmLoginNew.txtUserID.Text & "'" & vbCrLf

                    Debug.Print(QueryString)

                    ClsDb.CfMExecuteQuery(QueryString)

                    Me.DialogResult = DialogResult.Yes
                    Me.Close()

                Else
                    XtraMessageBox.Show(_sMsg.sMsg_NoID, _sMsg_Title.sMsgTitle_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        End If

    End Sub
End Class