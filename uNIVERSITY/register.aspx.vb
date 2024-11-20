Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography

Public Class register
    Inherits System.Web.UI.Page
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("My_ConnectionString").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "INSERT INTO LogInUser (UserName,Password,DateOfCreation) Values (@UserName,@Password,@DateOfCreation)"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text)
                cmd.Parameters.AddWithValue("@Password", hashing.HashPassword(txtPassword.Text))
                cmd.Parameters.AddWithValue("@DateOfCreation", txtDateOfCreation.Text)
                cmd.ExecuteNonQuery()
                sqlCon.Close()
            End Using
            Response.Redirect("login.aspx")
        Catch ex As Exception
            ' Log the exception or show a message
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub

End Class
