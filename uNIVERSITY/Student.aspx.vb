Imports System.Data.SqlClient
Imports System.Data

Public Class Student
    Inherits System.Web.UI.Page
    ' Declare controls with WithEvents()
    Protected WithEvents txtFirstName As TextBox
    Protected WithEvents txtLastName As TextBox
    Protected WithEvents txtFullName As TextBox
    Protected WithEvents txtDateOfBirth As TextBox
    Protected WithEvents txtAddress As TextBox
    Protected WithEvents txtPhone As TextBox
    Protected WithEvents txtEmail As TextBox
    Protected WithEvents TxtStudentId As TextBox
    Protected WithEvents BtnSubmit As Button
    Protected WithEvents StudentGrid As GridView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadStudentData()
            BindStudentGrid()
            BtnSubmit.Visible = True
            btnUpdate.Visible = False
            TxtStudentId.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtFullName.Text = ""
            txtDateOfBirth.Text = ""
            txtAddress.Text = ""
            txtPhone.Text = ""
            txtEmail.Text = ""
        End If
    End Sub

    Protected Sub LoadStudentData()
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "SELECT TOP 1 StudentId, FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email FROM Student"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    txtStudentId.Text = reader("StudentId").ToString()
                    txtFirstName.Text = reader("FirstName").ToString()
                    txtLastName.Text = reader("LastName").ToString()
                    txtFullName.Text = reader("FullName").ToString()
                    txtDateOfBirth.Text = reader("DateOfBirth").ToString()
                    txtAddress.Text = reader("Address").ToString()
                    txtPhone.Text = reader("Phone").ToString()
                    txtEmail.Text = reader("Email").ToString()
                End If
            End Using
        Catch ex As Exception
            ' Log the exception or show a message
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub BindStudentGrid(Optional ByVal searchQuery As String = "", Optional ByVal searchByID As Boolean = False)
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"

        Using sqlCon = New SqlConnection(connectionString)
            Try
                sqlCon.Open()
                Dim query As String
                If searchByID Then
                    query = "SELECT StudentId, FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email  FROM student WHERE StudentId = @search"
                Else
                    query = "SELECT StudentId, FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email  FROM student"
                    If Not String.IsNullOrEmpty(searchQuery) Then
                        query &= " WHERE firstname LIKE @search OR lastname LIKE @search OR phone LIKE @search OR email LIKE @search OR address LIKE @search"
                    End If
                End If
                Dim command As New SqlCommand(query, sqlCon)
                If searchByID Then
                    command.Parameters.AddWithValue("@search", searchQuery)
                ElseIf Not String.IsNullOrEmpty(searchQuery) Then
                    command.Parameters.AddWithValue("@search", "%" & searchQuery & "%")
                End If
                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)
                If dataTable.Rows.Count = 0 Then
                    dataTable.Rows.Add(dataTable.NewRow()) ' Add an empty row to display the "No results found" message
                    studentGrid.DataSource = dataTable
                    studentGrid.DataBind()
                    studentGrid.Rows(0).Cells.Clear()
                    studentGrid.Rows(0).Cells.Add(New TableCell())
                    studentGrid.Rows(0).Cells(0).ColumnSpan = studentGrid.Columns.Count
                    studentGrid.Rows(0).Cells(0).Text = "No results found."
                    studentGrid.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
                Else
                    studentGrid.DataSource = dataTable
                    studentGrid.DataBind()
                End If
            Catch ex As Exception
                Response.Write("<script>alert('Error: " & ex.Message & "');</script>")
            End Try
        End Using
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        BtnSubmit.Visible = True
        btnUpdate.Visible = False
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "INSERT INTO Student (FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email) VALUES (@FirstName, @LastName, @FullName, @DateOfBirth, @Address, @Phone, @Email)"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
                cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text)
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.ExecuteNonQuery()
            End Using
            LoadStudentData()
            BindStudentGrid()
        Catch ex As Exception
            ' Log the exception or show a message
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles studentGrid.PageIndexChanging
        studentGrid.PageIndex = e.NewPageIndex
        BindStudentGrid()
    End Sub

    Protected Sub StudentGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles StudentGrid.SelectedIndexChanged
        btnUpdate.Visible = True
        BtnSubmit.Visible = False

        Dim selectedRow As GridViewRow = StudentGrid.SelectedRow
        TxtStudentId.Text = selectedRow.Cells(0).Text
        txtFirstName.Text = selectedRow.Cells(1).Text
        txtLastName.Text = selectedRow.Cells(2).Text
        txtFullName.Text = selectedRow.Cells(3).Text
        txtDateOfBirth.Text = selectedRow.Cells(4).Text
        txtAddress.Text = selectedRow.Cells(5).Text
        txtPhone.Text = selectedRow.Cells(6).Text
        txtEmail.Text = selectedRow.Cells(7).Text
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        BindStudentGrid(txtKeyWord.Text)
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        BtnSubmit.Visible = False
        btnUpdate.Visible = True
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "UPDATE Student SET FirstName = @FirstName ,LastName = @LastName,FullName = @FullName  ,DateOfBirth =@DateOfBirth,Address = @Address,Phone = @Phone,Email = @Email WHERE studentid = @StudentId"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@StudentId", TxtStudentId.Text)
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
                cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text)
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.ExecuteNonQuery()
            End Using
            LoadStudentData()
            BindStudentGrid()
        Catch ex As Exception
            ' Log the exception or show a message
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub
End Class
