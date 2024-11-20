Public Class Library
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"
        'Dim studentfirstname As String = txtFirstName.Text

        Using sqlCon = New SqlClient.SqlConnection(connectionString)
            sqlCon.Open()
            Dim sqlText = "insert into Library (BookName) Values( '" & txtBookName.Text & "')"
            Dim cmd = New SqlClient.SqlCommand(sqlText, sqlCon)

            cmd.ExecuteNonQuery()
        End Using

    End Sub
End Class