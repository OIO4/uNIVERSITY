<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CourseByStudent.aspx.vb" Inherits="uNIVERSITY.CourseByStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblStudentId" runat="server" Text="StudentId"></asp:Label>
            <asp:TextBox ID="txtStudentId" runat="server"></asp:TextBox>
        </div>
        <p>
            CourseId<asp:TextBox ID="txtCourseId" runat="server"></asp:TextBox>
        </p>
        <p id="btnSubmit">
            <asp:Label ID="lblGrade" runat="server" Text="Grade"></asp:Label>
            <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblSemester" runat="server" Text="Semester"></asp:Label>
            <asp:TextBox ID="txtSemester" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </p>
    </form>
</body>
</html>
