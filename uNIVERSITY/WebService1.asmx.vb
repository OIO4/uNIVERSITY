Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WebService1
    Inherits System.Web.Services.WebService
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("My_ConnectionString").ConnectionString
    Public Property SBDBConn As Object

    <WebMethod()>
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()>
    Public Function GetStudentTable() As DataSet
        If SBDBConn Is Nothing Then
            SBDBConn = New SqlClient.SqlConnection(connectionString)
        End If
        Dim SqlCmdGetAllTables As New SqlClient.SqlCommand()
        SqlCmdGetAllTables.Connection = SBDBConn
        SqlCmdGetAllTables.CommandText = "select * from student"
        SqlCmdGetAllTables.CommandType = CommandType.Text
        Dim dsAllTables As New DataSet()
        Try
            If SBDBConn.State = ConnectionState.Closed Then
                SBDBConn.Open()
            End If
            Dim da As New SqlClient.SqlDataAdapter(SqlCmdGetAllTables)
            da.Fill(dsAllTables)
        Catch ex As Exception
            Throw New Exception("An error occurred while retrieving the tables.", ex)
        Finally
            If SBDBConn.State = ConnectionState.Open Then
                SBDBConn.Close()
            End If
        End Try
        Return dsAllTables
    End Function

    <WebMethod()>
    Public Function GetCourseTable() As DataSet
        If SBDBConn Is Nothing Then
            SBDBConn = New SqlClient.SqlConnection(connectionString)
        End If
        Dim SqlCmdGetAllTables As New SqlClient.SqlCommand()
        SqlCmdGetAllTables.Connection = SBDBConn
        SqlCmdGetAllTables.CommandText = "select * from course"
        SqlCmdGetAllTables.CommandType = CommandType.Text
        Dim dsAllTables As New DataSet()
        Try
            If SBDBConn.State = ConnectionState.Closed Then
                SBDBConn.Open()
            End If
            Dim da As New SqlClient.SqlDataAdapter(SqlCmdGetAllTables)
            da.Fill(dsAllTables)
        Catch ex As Exception
            Throw New Exception("An error occurred while retrieving the tables.", ex)
        Finally
            If SBDBConn.State = ConnectionState.Open Then
                SBDBConn.Close()
            End If
        End Try
        Return dsAllTables
    End Function

    '<WebMethod()>
    'Public Function GetCourseByStudentTable() As DataSet
    '    If SBDBConn Is Nothing Then
    '        SBDBConn = New SqlClient.SqlConnection(connectionString)
    '    End If
    '    Dim SqlCmdGetAllTables As New SqlClient.SqlCommand()
    '    SqlCmdGetAllTables.Connection = SBDBConn
    '    SqlCmdGetAllTables.CommandText = "select * from CourseByStudent"
    '    SqlCmdGetAllTables.CommandType = CommandType.Text
    '    Dim dsAllTables As New DataSet()
    '    Try
    '        If SBDBConn.State = ConnectionState.Closed Then
    '            SBDBConn.Open()
    '        End If
    '        Dim da As New SqlClient.SqlDataAdapter(SqlCmdGetAllTables)
    '        da.Fill(dsAllTables)
    '    Catch ex As Exception
    '        Throw New Exception("An error occurred while retrieving the tables.", ex)
    '    Finally
    '        If SBDBConn.State = ConnectionState.Open Then
    '            SBDBConn.Close()
    '        End If
    '    End Try
    '    Return dsAllTables
    'End Function

    <WebMethod()>
    Public Function GetLibraryTable() As DataSet
        If SBDBConn Is Nothing Then
            SBDBConn = New SqlClient.SqlConnection(connectionString)
        End If
        Dim SqlCmdGetAllTables As New SqlClient.SqlCommand()
        SqlCmdGetAllTables.Connection = SBDBConn
        SqlCmdGetAllTables.CommandText = "select * from Library"
        SqlCmdGetAllTables.CommandType = CommandType.Text
        Dim dsAllTables As New DataSet()
        Try
            If SBDBConn.State = ConnectionState.Closed Then
                SBDBConn.Open()
            End If
            Dim da As New SqlClient.SqlDataAdapter(SqlCmdGetAllTables)
            da.Fill(dsAllTables)
        Catch ex As Exception
            Throw New Exception("An error occurred while retrieving the tables.", ex)
        Finally
            If SBDBConn.State = ConnectionState.Open Then
                SBDBConn.Close()
            End If
        End Try
        Return dsAllTables
    End Function

    '<WebMethod()>
    'Public Function GetLogInUserTable() As DataSet
    '    If SBDBConn Is Nothing Then
    '        SBDBConn = New SqlClient.SqlConnection(connectionString)
    '    End If
    '    Dim SqlCmdGetAllTables As New SqlClient.SqlCommand()
    '    SqlCmdGetAllTables.Connection = SBDBConn
    '    SqlCmdGetAllTables.CommandText = "select * from LogInUser"
    '    SqlCmdGetAllTables.CommandType = CommandType.Text
    '    Dim dsAllTables As New DataSet()
    '    Try
    '        If SBDBConn.State = ConnectionState.Closed Then
    '            SBDBConn.Open()
    '        End If
    '        Dim da As New SqlClient.SqlDataAdapter(SqlCmdGetAllTables)
    '        da.Fill(dsAllTables)
    '    Catch ex As Exception
    '        Throw New Exception("An error occurred while retrieving the tables.", ex)
    '    Finally
    '        If SBDBConn.State = ConnectionState.Open Then
    '            SBDBConn.Close()
    '        End If
    '    End Try
    '    Return dsAllTables
    'End Function

    '<WebMethod()>
    'Public Function GetBooksRentedByStudentsTable() As DataSet
    '    If SBDBConn Is Nothing Then
    '        SBDBConn = New SqlClient.SqlConnection(connectionString)
    '    End If
    '    Dim SqlCmdGetAllTables As New SqlClient.SqlCommand()
    '    SqlCmdGetAllTables.Connection = SBDBConn
    '    SqlCmdGetAllTables.CommandText = "select * from BooksRentedByStudents"
    '    SqlCmdGetAllTables.CommandType = CommandType.Text
    '    Dim dsAllTables As New DataSet()
    '    Try
    '        If SBDBConn.State = ConnectionState.Closed Then
    '            SBDBConn.Open()
    '        End If
    '        Dim da As New SqlClient.SqlDataAdapter(SqlCmdGetAllTables)
    '        da.Fill(dsAllTables)
    '    Catch ex As Exception
    '        Throw New Exception("An error occurred while retrieving the tables.", ex)
    '    Finally
    '        If SBDBConn.State = ConnectionState.Open Then
    '            SBDBConn.Close()
    '        End If
    '    End Try
    '    Return dsAllTables
    'End Function

    '<WebMethod()>
    'Public Function GetAllTables() As DataSet
    '    If SBDBConn Is Nothing Then
    '        SBDBConn = New SqlClient.SqlConnection(connectionString)
    '    End If
    '    Dim SqlCmdGetAllTables As New SqlClient.SqlCommand()
    '    SqlCmdGetAllTables.Connection = SBDBConn
    '    SqlCmdGetAllTables.CommandText = "AllTables"
    '    SqlCmdGetAllTables.CommandType = CommandType.StoredProcedure
    '    Dim dsAllTables As New DataSet()
    '    Try
    '        If SBDBConn.State = ConnectionState.Closed Then
    '            SBDBConn.Open()
    '        End If
    '        Dim da As New SqlClient.SqlDataAdapter(SqlCmdGetAllTables)
    '        da.Fill(dsAllTables)
    '    Catch ex As Exception
    '        Throw New Exception("An error occurred while retrieving the tables.", ex)
    '    Finally
    '        If SBDBConn.State = ConnectionState.Open Then
    '            SBDBConn.Close()
    '        End If
    '    End Try
    '    Return dsAllTables
    'End Function

    <WebMethod()>
    Public Function InsertStudent(ByVal firstName As String, ByVal lastName As String, ByVal fullName As String, ByVal dateOfBirth As String, ByVal address As String, ByVal phone As String, ByVal email As String) As Boolean
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "INSERT INTO Student (FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email) VALUES (@FirstName, @LastName, @FullName, @DateOfBirth, @Address, @Phone, @Email)"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@FirstName", firstName)
                cmd.Parameters.AddWithValue("@LastName", lastName)
                cmd.Parameters.AddWithValue("@FullName", fullName)
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth)
                cmd.Parameters.AddWithValue("@Address", address)
                cmd.Parameters.AddWithValue("@Phone", phone)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.ExecuteNonQuery()
                sqlCon.Close()
                Return True
            End Using
        Catch ex As Exception
            ' Log the exception or show a message
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function InsertCourse(ByVal studentId As Integer, ByVal courseId As String, ByVal grade As String, ByVal semester As String) As Boolean
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "INSERT INTO CourseByStudent (StudentId,CourseId,Grade,Semester) VALUES (@StudentId,@CourseId,@Grade,@Semester)"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@StudentId", studentId)
                cmd.Parameters.AddWithValue("@CourseId", courseId)
                cmd.Parameters.AddWithValue("@Grade", grade)
                cmd.Parameters.AddWithValue("@Semester", semester)
                cmd.ExecuteNonQuery()
                sqlCon.Close()
                Return True
            End Using
        Catch ex As Exception
            ' Log the exception or show a message
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function InsertLibrary(ByVal studentId As Integer, ByVal bookId As String, ByVal RentalPeriod As String) As Boolean
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "INSERT INTO BooksRentedByStudents (StudentId,BookId,RentalPeriod) VALUES (@StudentId,@BookId,@RentalPeriod)"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@StudentId", studentId)
                cmd.Parameters.AddWithValue("@BookId", bookId)
                cmd.Parameters.AddWithValue("@RentalPeriod", RentalPeriod)
                cmd.ExecuteNonQuery()
                sqlCon.Close()
                Return True
            End Using
        Catch ex As Exception
            ' Log the exception or show a message
            Return False
        End Try
    End Function

    Public Function UpdateStudent(ByVal StudentId As String, ByVal firstName As String, ByVal lastName As String, ByVal fullName As String, ByVal dateOfBirth As String, ByVal address As String, ByVal phone As String, ByVal email As String) As Boolean
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim sqlText = "UPDATE Student SET FirstName = @FirstName ,LastName = @LastName,FullName = @FullName ,DateOfBirth =@DateOfBirth,Address = @Address,Phone = @Phone,Email = @Email WHERE studentid = @StudentId"
                Dim cmd = New SqlCommand(sqlText, sqlCon)
                cmd.Parameters.AddWithValue("@StudentId", StudentId)
                cmd.Parameters.AddWithValue("@FirstName", firstName)
                cmd.Parameters.AddWithValue("@LastName", lastName)
                cmd.Parameters.AddWithValue("@FullName", fullName)
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth)
                cmd.Parameters.AddWithValue("@Address", address)
                cmd.Parameters.AddWithValue("@Phone", phone)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.ExecuteNonQuery()
                sqlCon.Close()
                Return True
            End Using
        Catch ex As Exception
            ' Log the exception or show a message
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function SearchStudent1(searchQuery As String) As DataTable
        Return SearchStudentsFunc(searchQuery, True)
    End Function

    <WebMethod()>
    Public Function SearchStudent2(searchQuery As String) As DataTable
        Return SearchStudentsFunc(searchQuery, False)
    End Function

    Private Function SearchStudentsFunc(searchQuery As String, searchByID As Boolean) As DataTable
        Try
            Using sqlCon = New SqlConnection(connectionString)
                sqlCon.Open()
                Dim query As String
                If searchByID Then
                    query = "SELECT StudentId, FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email  FROM student WHERE StudentId = @search"
                Else
                    query = "SELECT StudentId, FirstName, LastName, FullName, DateOfBirth, Address, Phone, Email  FROM student"
                    If Not String.IsNullOrEmpty(searchQuery) Then
                        query &= " WHERE firstname LIKE @search OR lastname LIKE @search Or fullname LIKE @search OR DateOfBirth LIKE @search OR phone LIKE @search OR email LIKE @search OR address LIKE @search"
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
                Return dataTable
            End Using
        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        End Try
    End Function

End Class
