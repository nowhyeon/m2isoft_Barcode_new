Imports System.IO
Imports System.ComponentModel
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls

Public Class frmManual
    Private Sub PsManualPrintRoutine()
        If memoComment.Text <> "" Then
            Call Print_Manual_Print(txtBarcodeNo.Text, memoComment.Text)
        End If
    End Sub

    Private Sub menuBtn_click(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles menuBtn.ButtonClick
        Dim sTag As String = CType(e.Button, WindowsUIButton).Tag.ToString()

        Select Case sTag
            Case "print"
                Call PsManualPrintRoutine()
            Case "close"
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
        End Select
    End Sub
End Class