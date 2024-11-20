Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography

Public Class login
    Inherits System.Web.UI.Page
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("My_ConnectionString").ConnectionString
    Public Property CheckState As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ValidateUser()
    End Sub
    Private Sub ValidateUser()
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand("SELECT * FROM LogInUser WHERE Username = @Username AND Password = @Password", connection)
            command.Parameters.AddWithValue("@Username", txtUserName.Text)
            command.Parameters.AddWithValue("@Password", hashing.HashPassword(txtPassword.Text))
            Dim adapter As New SqlDataAdapter(command)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)
            If dataTable.Rows.Count = 0 Then
                Response.Write("<script>alert('Error: Incorrect username or password') </script>")
            Else
                Response.Redirect("adamStudent.aspx")
            End If
        End Using
    End Sub



End Class


