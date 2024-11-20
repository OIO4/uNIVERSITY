Imports System.Data.SqlClient

Public Class adam2
    Inherits System.Web.UI.Page
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("My_ConnectionString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'fillgridview()
            Dim ws As New WebService1()
            Dim ds As DataSet = ws.GetCourseTable()
            coursegrid.DataSource = ds
            coursegrid.DataBind()
            coursegrid.Visible = True
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'Try
        '    Using sqlCon = New SqlConnection(connectionString)
        '        sqlCon.Open()
        '        Dim sqlText = "INSERT INTO CourseByStudent (StudentId,CourseId,Grade,Semester) VALUES (@StudentId,@CourseId,@Grade,@Semester)"
        '        Dim cmd = New SqlCommand(sqlText, sqlCon)
        '        cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text)
        '        cmd.Parameters.AddWithValue("@CourseId", txtCourseId.Text)
        '        cmd.Parameters.AddWithValue("@Grade", txtGrade.Text)
        '        cmd.Parameters.AddWithValue("@Semester", txtSemester.Text)
        '        cmd.ExecuteNonQuery()
        '    End Using
        'Catch ex As Exception
        '    Response.Write("An error occurred: " & ex.Message)
        'End Try
        Try
            Dim ws As New WebService1()
            Dim result As Boolean = ws.InsertCourse(txtStudentId.Text, txtCourseId.Text, txtGrade.Text, txtSemester.Text)
            If result Then
                emptyfields()
            Else
                Response.Write("Error inserting course by student.")
            End If
        Catch ex As Exception
            Response.Write("An error occurred: " & ex.Message)
        End Try
    End Sub

    Public Sub emptyfields()
        txtCourseId.Text = ""
        txtCourseName.Text = ""
    End Sub

    'Public Sub fillgridview()
    '    Try
    '        Using sqlCon = New SqlConnection(connectionString)
    '            sqlCon.Open()
    '            Dim sqlText = "Select CourseId,CourseName from Course "
    '            Dim adapter As SqlDataAdapter
    '            Dim ds As New DataSet
    '            adapter = New SqlDataAdapter(sqlText, sqlCon)
    '            adapter.Fill(ds)
    '            sqlCon.Close()
    '            coursegrid.DataSource = ds.Tables(0)
    '            coursegrid.DataBind()
    '        End Using
    '    Catch ex As Exception
    '        Response.Write("An error occurred: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub coursegrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles coursegrid.PageIndexChanging
        coursegrid.PageIndex = e.NewPageIndex
        Dim searchquery As String = txtKeyWord.Text
        If Not String.IsNullOrEmpty(searchquery) Then
            Searchcoursegrid(searchquery)
        Else
            'fillgridview()
        End If
    End Sub

    Protected Sub coursegrid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles coursegrid.SelectedIndexChanged
        Dim selectedRow As GridViewRow = coursegrid.SelectedRow
        txtCourseId.Text = selectedRow.Cells(0).Text
        txtCourseName.Text = selectedRow.Cells(1).Text
    End Sub


    Private Sub Searchcoursegrid(Optional ByVal searchQuery As String = "", Optional ByVal searchByID As Boolean = False)
        Using sqlCon = New SqlConnection(connectionString)
            Try
                sqlCon.Open()
                Dim query As String
                If searchByID Then
                    query = "SELECT CourseId,CourseName  FROM course WHERE courseId = @search"
                Else
                    query = "SELECT CourseId,CourseName  FROM course"
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
                    coursegrid.DataSource = dataTable
                    coursegrid.DataBind()
                    coursegrid.Rows(0).Cells.Clear()
                    coursegrid.Rows(0).Cells.Add(New TableCell())
                    coursegrid.Rows(0).Cells(0).ColumnSpan = coursegrid.Columns.Count
                    coursegrid.Rows(0).Cells(0).Text = "No results found."
                    coursegrid.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
                Else
                    coursegrid.DataSource = dataTable
                    coursegrid.DataBind()
                End If
            Catch ex As Exception
                Response.Write("<script>alert('Error: " & ex.Message & "');</script>")
            End Try
        End Using
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Searchcoursegrid(txtKeyWord.Text)
    End Sub
End Class
