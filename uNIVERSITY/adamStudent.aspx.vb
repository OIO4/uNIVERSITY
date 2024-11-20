Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Imports System.IO

Public Class adam
    Inherits System.Web.UI.Page
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("My_ConnectionString").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'fillgridview()
            Dim ws As New WebService1()
            Dim ds As DataSet = ws.GetStudentTable()
            studentgrid.DataSource = ds
            studentgrid.DataBind()
            emptyfields()
            studentgrid.Visible = True
            btnUpdate.Visible = False
            btnSubmit.Visible = True
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'Try
        '    Using sqlCon = New SqlConnection(connectionString)
        '        sqlCon.Open()
        '        Dim sqlText = "INSERT INTO Student (FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email) VALUES (@FirstName, @LastName, @FullName, @DateOfBirth, @Address, @Phone, @Email)"
        '        Dim cmd = New SqlCommand(sqlText, sqlCon)
        '        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
        '        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
        '        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
        '        cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text)
        '        cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
        '        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
        '        cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
        '        cmd.ExecuteNonQuery()
        '        sqlCon.Close()
        '    End Using
        '    emptyfields()
        'Catch ex As Exception
        '    ' Log the exception or show a message
        '    Response.Write("An error occurred: " & ex.Message)
        'End Try
        Try
            Dim ws As New WebService1()
            Dim result As Boolean = ws.InsertStudent(txtFirstName.Text, txtLastName.Text, txtFullName.Text, txtDateOfBirth.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text)
            If result Then
                emptyfields()
            Else
                Response.Write("An error occurred while inserting student.")
            End If
        Catch ex As Exception
            ' Log the exception or show a message
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub

    Public Sub emptyfields()
        txtStudentId.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtFullName.Text = ""
        txtDateOfBirth.Text = ""
        txtAddress.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
    End Sub

    'Public Sub fillgridview()
    '    Try
    '        Using sqlCon = New SqlConnection(connectionString)
    '            sqlCon.Open()
    '            Dim sqlText = "Select studentid,FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email from Student "
    '            Dim adapter As SqlDataAdapter
    '            Dim ds As New DataSet
    '            adapter = New SqlDataAdapter(sqlText, sqlCon)
    '            adapter.Fill(ds)
    '            sqlCon.Close()
    '            studentgrid.DataSource = ds.Tables(0)
    '            studentgrid.DataBind()
    '        End Using
    '    Catch ex As Exception
    '        Response.Write("An error occurred: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub studentgrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles studentgrid.PageIndexChanging
        studentgrid.PageIndex = e.NewPageIndex
        Dim searchquery As String = txtKeyWord.Text
        If Not String.IsNullOrEmpty(searchquery) Then
            SearchStudentGrid(searchquery)
        Else
            Dim ws As New WebService1()
            Dim ds As DataSet = ws.GetStudentTable()
            studentgrid.DataSource = ds
            studentgrid.DataBind()
            'fillgridview()
        End If
    End Sub

    Protected Sub studentgrid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles studentgrid.SelectedIndexChanged
        btnUpdate.Visible = True
        btnSubmit.Visible = False
        Dim selectedRow As GridViewRow = studentgrid.SelectedRow
        txtStudentId.Text = selectedRow.Cells(1).Text
        txtFirstName.Text = selectedRow.Cells(2).Text
        txtLastName.Text = selectedRow.Cells(3).Text
        txtFullName.Text = selectedRow.Cells(4).Text
        txtDateOfBirth.Text = DateTime.Parse(selectedRow.Cells(5).Text).ToString("yyyy-MM-dd")
        txtAddress.Text = selectedRow.Cells(6).Text
        txtPhone.Text = selectedRow.Cells(7).Text
        txtEmail.Text = selectedRow.Cells(8).Text
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'btnSubmit.Visible = False
        'btnUpdate.Visible = True
        'Try
        '    Using sqlCon = New SqlConnection(connectionString)
        '        sqlCon.Open()
        '        Dim sqlText = "UPDATE Student SET FirstName = @FirstName ,LastName = @LastName,FullName = @FullName ,DateOfBirth =@DateOfBirth,Address = @Address,Phone = @Phone,Email = @Email WHERE studentid = @StudentId"
        '        Dim cmd = New SqlCommand(sqlText, sqlCon)
        '        cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text)
        '        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
        '        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
        '        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text)
        '        cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text)
        '        cmd.Parameters.AddWithValue("@Address", txtAddress.Text)
        '        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text)
        '        cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
        '        cmd.ExecuteNonQuery()
        '    End Using
        '    emptyfields()
        '    Dim ws As New WebService1()
        '    Dim ds As DataSet = ws.GetStudentTable()
        '    studentgrid.DataSource = ds
        '    studentgrid.DataBind()
        '    'fillgridview()
        'Catch ex As Exception
        '    Response.Write("An error occurred: " & ex.Message)
        'End Try
        btnSubmit.Visible = False
        btnUpdate.Visible = True
        Try
            Dim ws As New WebService1()
            Dim result As Boolean = ws.UpdateStudent(txtStudentId.Text, txtFirstName.Text, txtLastName.Text, txtFullName.Text, txtDateOfBirth.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text)
            If result Then
                Response.Write("Student updated successfully!")
            Else
                Response.Write("Error updating student.")
            End If
            emptyfields()
            Dim ds As DataSet = ws.GetStudentTable()
            studentgrid.DataSource = ds
            studentgrid.DataBind()
            'fillgridview()
        Catch ex As Exception
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub SearchStudentGrid(Optional ByVal searchQuery As String = "", Optional ByVal searchByID As Boolean = False)
        'Using sqlCon = New SqlConnection(connectionString)
        '    Try
        '        sqlCon.Open()
        '        Dim query As String
        '        If searchByID Then
        '            query = "SELECT StudentId, FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email  FROM student WHERE StudentId = @search"
        '        Else
        '            query = "SELECT StudentId, FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email  FROM student"
        '            If Not String.IsNullOrEmpty(searchQuery) Then
        '                query &= " WHERE firstname LIKE @search OR lastname LIKE @search Or fullname LIKE @search OR DateOfBirth LIKE @search OR phone LIKE @search OR email LIKE @search OR address LIKE @search"
        '            End If
        '        End If
        '        Dim command As New SqlCommand(query, sqlCon)
        '        If searchByID Then
        '            command.Parameters.AddWithValue("@search", searchQuery)
        '        ElseIf Not String.IsNullOrEmpty(searchQuery) Then
        '            command.Parameters.AddWithValue("@search", "%" & searchQuery & "%")
        '        End If
        '        Dim adapter As New SqlDataAdapter(command)
        '        Dim dataTable As New DataTable()
        '        adapter.Fill(dataTable)
        '        If dataTable.Rows.Count = 0 Then
        '            dataTable.Rows.Add(dataTable.NewRow()) ' Add an empty row to display the "No results found" message
        '            studentgrid.DataSource = dataTable
        '            studentgrid.DataBind()
        '            studentgrid.Rows(0).Cells.Clear()
        '            studentgrid.Rows(0).Cells.Add(New TableCell())
        '            studentgrid.Rows(0).Cells(0).ColumnSpan = studentgrid.Columns.Count
        '            studentgrid.Rows(0).Cells(0).Text = "No results found."
        '            studentgrid.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
        '        Else
        '            studentgrid.DataSource = dataTable
        '            studentgrid.DataBind()
        '        End If
        '    Catch ex As Exception
        '        Response.Write("<script>alert('Error: " & ex.Message & "');</script>")
        '    End Try
        'End Using
        Dim ws As New WebService1()
        Dim dataTable As DataTable
        If searchByID Then
            dataTable = ws.SearchStudent1(searchQuery)
        Else
            dataTable = ws.SearchStudent2(searchQuery)
        End If
        If dataTable.Rows.Count = 0 Then
            dataTable.Rows.Add(dataTable.NewRow()) ' Add an empty row to display the "No results found" message
            studentgrid.DataSource = dataTable
            studentgrid.DataBind()
            studentgrid.Rows(0).Cells.Clear()
            studentgrid.Rows(0).Cells.Add(New TableCell())
            studentgrid.Rows(0).Cells(0).ColumnSpan = studentgrid.Columns.Count
            studentgrid.Rows(0).Cells(0).Text = "No results found."
            studentgrid.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
        Else
            studentgrid.DataSource = dataTable
            studentgrid.DataBind()
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SearchStudentGrid(txtKeyWord.Text.Trim)
    End Sub
End Class