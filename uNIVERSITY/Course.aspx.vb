Imports System.Data.SqlClient
Imports System.Data

Public Class Course
    Inherits System.Web.UI.Page
    ' Declare controls with WithEvents
    Protected WithEvents txtCourseId As TextBox
    Protected WithEvents txtCourseName As TextBox
    Protected WithEvents btnSubmit As Button
    Protected WithEvents studentGrid As GridView

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadStudentData()
            BindStudentGrid()
        End If
    End Sub

    Protected Sub LoadStudentData()
        Dim connectionString As String = "Data Source=LBITDP131D\SQLEXPRESS;Initial Catalog=UsjUni;Integrated Security=true"
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "SELECT TOP 1 CourseId,CourseName from course"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    txtCourseId.Text = reader("CourseId").ToString()
                    txtCourseName.Text = reader("CourseName").ToString()
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
                    query = "SELECT CourseId,CourseName from course WHERE CourseId = @search"
                Else
                    query = "SELECT CourseId,CourseName from course"
                    If Not String.IsNullOrEmpty(searchQuery) Then
                        query &= " WHERE CourseName LIKE @search "
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
                Dim sqlText = "INSERT INTO Course (CourseId,Coursename) VALUES (@CourseId,@Coursename)"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@CourseId", txtCourseId.Text)
                cmd.Parameters.AddWithValue("@CourseName", txtCourseName.Text)
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

    Protected Sub studentGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles studentGrid.SelectedIndexChanged
        Dim selectedRow As GridViewRow = studentGrid.SelectedRow
        txtCourseId.Text = selectedRow.Cells(1).Text
        txtCourseName.Text = selectedRow.Cells(2).Text
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        BindStudentGrid(txtKeyWord.Text)
    End Sub
End Class