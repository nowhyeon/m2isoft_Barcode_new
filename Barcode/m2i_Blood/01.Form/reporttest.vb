Public Class reporttest
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim Report_IF_AMH2 As Report_IF_AMH_2 = New Report_IF_AMH_2

        With frmReportView
            .dcvPrevView.DocumentSource = Report_IF_AMH2
            Report_IF_AMH2.CreateDocument(False)
            .ShowDialog()

            'If .DialogResult = DialogResult.OK Then
            '    SimpleButton1_Click(sender, e)
            'End If
        End With
    End Sub

    Private Sub DocumentViewer1_Load(sender As Object, e As EventArgs)

    End Sub
End Class