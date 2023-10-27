Public Class ClsIniFile
    Private _Path As String

    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
        (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String,
        ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
        (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String,
        ByVal lpFileName As String) As Integer

    Public Sub New(ByVal IniPath As String)
        _Path = IniPath
    End Sub

    Public Function ReadValue(ByVal section As String, ByVal key As String) As String
        Dim sb As New System.Text.StringBuilder(255)
        Dim count As Integer = GetPrivateProfileString(section, key, "", sb, 255, _Path)
        Return sb.ToString()
    End Function

    Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
        WritePrivateProfileString(section, key, value, _Path)
    End Sub
End Class