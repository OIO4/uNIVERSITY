Imports System.Data.SqlClient
Public Class adamLibrary
    Inherits System.Web.UI.Page
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("My_ConnectionString").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'fillgridview()
            Dim ws As New WebService1()
            Dim ds As DataSet = ws.GetLibraryTable()
            librarygrid.DataSource = ds
            librarygrid.DataBind()
            librarygrid.Visible = True
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'Try
        '    Using sqlCon = New SqlConnection(connectionString)
        '        sqlCon.Open()
        '        Dim sqlText = "INSERT INTO BooksRentedByStudents (StudentId,BookId,RentalPeriod) VALUES (@StudentId,@BookId,@RentalPeriod)"
        '        Dim cmd = New SqlCommand(sqlText, sqlCon)
        '        cmd.Parameters.AddWithValue("@StudentId", txtStudentId.Text)
        '        cmd.Parameters.AddWithValue("@BookId", txtBookId.Text)
        '        cmd.Parameters.AddWithValue("@RentalPeriod", txtRentalPeriod.Text)
        '        cmd.ExecuteNonQuery()
        '    End Using

        'Catch ex As Exception
        '    Response.Write("An error occurred: " & ex.Message)
        'End Try
        Try
            Dim ws As New WebService1()
            Dim result As Boolean = ws.InsertLibrary(txtStudentId.Text, txtBookId.Text, txtRentalPeriod.Text)
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
        txtStudentId.Text = ""
        txtBookId.Text = ""
        txtRentalPeriod.Text = ""
    End Sub

    'Public Sub fillgridview()
    '    Try
    '        Using sqlCon = New SqlConnection(connectionString)
    '            sqlCon.Open()
    '            Dim sqlText = "Select BookId,BookName from Library "
    '            Dim adapter As SqlDataAdapter
    '            Dim ds As New DataSet
    '            adapter = New SqlDataAdapter(sqlText, sqlCon)
    '            adapter.Fill(ds)
    '            sqlCon.Close()
    '            librarygrid.DataSource = ds.Tables(0)
    '            librarygrid.DataBind()
    '        End Using

    '    Catch ex As Exception
    '        Response.Write("An error occurred: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub librarygrid_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles librarygrid.PageIndexChanging
        librarygrid.PageIndex = e.NewPageIndex
        Dim searchquery As String = txtKeyWord.Text
        If Not String.IsNullOrEmpty(searchquery) Then
            Searchlibrarygrid(searchquery)
        Else
            'fillgridview()
        End If
    End Sub

    Protected Sub librarygrid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles librarygrid.SelectedIndexChanged
        Dim selectedRow As GridViewRow = librarygrid.SelectedRow
        txtBookId.Text = selectedRow.Cells(0).Text
        txtBookName.Text = selectedRow.Cells(1).Text
    End Sub

    Private Sub Searchlibrarygrid(Optional ByVal searchQuery As String = "", Optional ByVal searchByID As Boolean = False)
        Using sqlCon = New SqlConnection(connectionString)
            Try
                sqlCon.Open()
                Dim query As String
                If searchByID Then
                    query = "Select BookId,BookName from Library WHERE BookId = @search"
                Else
                    query = "Select BookId,BookName from Library"
                    If Not String.IsNullOrEmpty(searchQuery) Then
                        query &= " WHERE BookName LIKE @search"
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
                    librarygrid.DataSource = dataTable
                    librarygrid.DataBind()
                    librarygrid.Rows(0).Cells.Clear()
                    librarygrid.Rows(0).Cells.Add(New TableCell())
                    librarygrid.Rows(0).Cells(0).ColumnSpan = librarygrid.Columns.Count
                    librarygrid.Rows(0).Cells(0).Text = "No results found."
                    librarygrid.Rows(0).Cells(0).HorizontalAlign = HorizontalAlign.Center
                Else
                    librarygrid.DataSource = dataTable
                    librarygrid.DataBind()
                End If
            Catch ex As Exception
                Response.Write("<script>alert('Error: " & ex.Message & "');</script>")
            End Try
        End Using
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Searchlibrarygrid(txtKeyWord.Text)
    End Sub
End Class