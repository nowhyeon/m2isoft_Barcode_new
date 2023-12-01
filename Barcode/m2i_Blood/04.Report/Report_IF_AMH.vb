Imports System.Drawing.Printing

Public Class Report_IF_AMH
    Public mPTNM
    Public mMedOffice
    Public mDoctor
    Public mChartNo
    Public mAcceptDate
    Public mReceiptDate
    Public mBirth
    Public mAge
    Public mAMHResult
    Public mComment1
    Public mComment2
    Public mComment3

    Private Sub VisitReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        lblPTNM.Text = mPTNM
        lblMedOffice.Text = mMedOffice
        lblDoctor.Text = mDoctor
        lblChartNo.Text = mChartNo
        lblAcceptDate.Text = mAcceptDate
        lblReceiptDate.Text = mReceiptDate
        lblBirth.Text = mBirth
        lblAge.Text = mAge
        lblAMHResult.Text = mAMHResult
        lblAMHComment1.Text = mComment1
        lblAMHComment2.Text = mComment2
        lblAMHComment3.Text = mComment3

    End Sub
End Class