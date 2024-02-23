Imports System.IO
Imports System.Text
Imports System.Windows.Forms

<CLSCompliant(True)>
Public Class ClsErrorsAndEvents

    Public Sub New()
    End Sub

    Public Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)

        If Not System.IO.Directory.Exists(Application.StartupPath & "\Errors\") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors\")
        End If
        '-[ Check the File
        Try
            Using fs As FileStream = New FileStream(Application.StartupPath & "\Errors\ErrLog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Dim s As StreamWriter = New StreamWriter(fs)
                s.Close()
                fs.Close()
            End Using
        Catch ex As Exception

        End Try

        '-[ Log it
        Try
            Using fs1 As FileStream = New FileStream(Application.StartupPath & "\Errors\ErrLog.txt", FileMode.Append, FileAccess.Write)
                Dim s1 As StreamWriter = New StreamWriter(fs1)
                s1.Write("[ Title         ] : " & title & vbCrLf)
                s1.Write("[ Message   ] : " & msg & vbCrLf)
                s1.Write("[ StackTrace ] : " & vbCrLf & stkTrace & vbCrLf)
                s1.Write("[ Date/Time  ] : " & DateTime.Now.ToString() & vbCrLf)
                s1.Write("-------------------------------------------------------------------------------------" & vbCrLf)
                s1.Close()
                fs1.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub

End Class