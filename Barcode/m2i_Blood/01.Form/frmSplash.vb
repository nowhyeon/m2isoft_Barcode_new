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
        If marqueeProgressBarControl1.Properties.IsLoading = False Then
            tmrFrmSplash.Enabled = False

            Dim frmLogin = New frmLogin
            frmLogin.Show()

            Me.Hide()
        End If
    End Sub
End Class
