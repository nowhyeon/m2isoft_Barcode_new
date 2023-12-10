Public Class frmSplash
    Sub New
        InitializeComponent()
        Me.labelControl1.Text = "Copyright © 1998-" & DateTime.Now.Year.ToString()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrFrmSplash.Enabled = True
    End Sub

    Private Sub tmr_tick(sender As Object, e As EventArgs) Handles tmrFrmSplash.Tick
        marqueeProgressBarControl1.Position += 2
        If marqueeProgressBarControl1.Position >= 100 Then

            frmLoginNew.Show()
            Me.Close()

        End If
    End Sub
End Class
