Imports System.Security.Cryptography
Imports System.Text
Public Class hashing
    Public Shared Function HashPassword(password As String) As String
        Using sha256 As New SHA256CryptoServiceProvider
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim hashedPassword As New StringBuilder()
            For Each b As Byte In bytes
                hashedPassword.AppendFormat("{0:x2}", b)
            Next
            Return hashedPassword.ToString()
        End Using
    End Function

End Class
