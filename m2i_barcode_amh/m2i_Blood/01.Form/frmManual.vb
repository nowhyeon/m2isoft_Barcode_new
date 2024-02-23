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
            Case "Save"
                Call PsSaveRoutine()
            Case "Clear"
                'Call PsScreenClear()
            Case "print"
                Call PsManualPrintRoutine()
            Case "close"
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
        End Select
    End Sub

    Private Sub PsSaveRoutine()
        System.IO.File.WriteAllText(txtFileNM.Text, memoComment.Text, System.Text.Encoding.Default)
    End Sub

    Private Sub btnFileOpen_click(sender As Object, e As EventArgs) Handles btnFileOpen.Click
        Dim dlgOFD As New OpenFileDialog()
        Dim sfilePath As String

        With dlgOFD
            .InitialDirectory = Application.StartupPath
            .Filter = "바코드 샘플 텍스트 (*.txt)|*.txt|바코드 샘플 텍스트 (*.rtf)|*.rtf"
            .FilterIndex = 1
        End With

        If dlgOFD.ShowDialog = DialogResult.OK Or dlgOFD.FileNames.Length > 0 Then
            sfilePath = dlgOFD.FileName
            txtFileNM.Text = sfilePath

            '-[ 텍스트 파일을 읽으려면
            'txtFileMemo.Text = My.Computer.FileSystem.ReadAllText(sfilePath)

            '-[ 인코딩된 텍스트 파일을 읽으려면 
            'txtFileMemo.Text = My.Computer.FileSystem.ReadAllText(sfilePath, System.Text.Encoding.Default)

            Dim strContents = System.IO.File.ReadAllText(sfilePath, System.Text.Encoding.Default)
            'Dim strContents = System.IO.File.ReadAllText(sfilePath, System.Text.Encoding.UTF8)

            memoComment.Text = strContents
        Else
            Return
        End If

    End Sub
End Class