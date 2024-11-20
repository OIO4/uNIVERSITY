Imports System.Data.SqlClient
Imports System.Data

Public Class Student
    Inherits System.Web.UI.Page
    ' Declare controls with WithEvents
    Protected WithEvents txtStudentId As TextBox
    Protected WithEvents txtBookId As TextBox
    Protected WithEvents txtRentalPeriod As TextBox
    Protected WithEvents btnSubmit As Button
    Protected WithEvents studentGrid As GridView
    Private txtBookName As Object

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadStudentData()
            BindStudentGrid()
        End If
    End Sub

    Private Sub BindStudentGrid()
        Throw New NotImplementedException()
    End Sub

    Protected Sub LoadStudentData()
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "SELECT TOP 1 BookId,BookName FROM Library"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    txtBookId.Text = reader("BookId").ToString()
                    txtBookName.Text = reader("BookName").ToString()
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
                    query = "SELECT BookId,BookName FROM Library WHERE BookId = @search"
                Else
                    query = "SELECT BookId,BookName FROM Library"
                    If Not String.IsNullOrEmpty(searchQuery) Then
                        query &= " WHERE BookName LIKE @search "
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

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "insert into BooksRentedByStudents (StudentId,BookId,RentalPeriod) Values( '" & txtStudentId.Text & "','" & txtBookId.Text & "','" & txtRentalPeriod.Text & "')"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text)
                cmd.Parameters.AddWithValue("@BookId", txtBookId.Text)
                cmd.Parameters.AddWithValue("@RentalPeriod", txtRentalPeriod.Text)
                cmd.ExecuteNonQuery()
            End Using
            LoadStudentData()
            BindStudentGrid()
        Catch ex As Exception
            ' Log the exception or show a message
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles StudentGrid.PageIndexChanging
        StudentGrid.PageIndex = e.NewPageIndex
        BindStudentGrid()
    End Sub

    Protected Sub studentGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles StudentGrid.SelectedIndexChanged
        Dim selectedRow As GridViewRow = StudentGrid.SelectedRow
        txtBookId.Text = selectedRow.Cells(0).Text
        txtBookName.Text = selectedRow.Cells(1).Text
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        BindStudentGrid(txtKeyWord.Text)
    End Sub

    Private Sub BindStudentGrid(text As String)
        Throw New NotImplementedException()
    End Sub
End Class