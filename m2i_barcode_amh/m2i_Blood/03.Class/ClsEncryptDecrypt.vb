Imports System.Security.Cryptography
Imports System.Text

Public Class ClsEncryptDecrypt
    Dim DES As New TripleDESCryptoServiceProvider
    Dim MD5 As New MD5CryptoServiceProvider

    Function Encrypt(StringInput As String) As String
        If StringInput.Length = 0 Then
            Return String.Empty
        End If

        Dim Key As String = "M2I_SOFT"

        Try
            DES.Key = MD5Hash(Key)
            DES.Mode = CipherMode.ECB
            Dim buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(StringInput)
            Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Function Decrypt(EncryptedString As String) As String
        If EncryptedString.Length = 0 Then
            Return String.Empty
        End If

        Dim Key As String = "M2I_SOFT"
        Try
            DES.Key = MD5Hash(Key)
            DES.Mode = CipherMode.ECB
            Dim Buffer As Byte() = Convert.FromBase64String(EncryptedString)
            Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Function MD5Hash(value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function


End Class
