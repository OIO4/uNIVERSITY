<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="adamCourse.aspx.vb" Inherits="uNIVERSITY.adam2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="adamUni.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="lblSemester">
                <br />
                <br />
                &nbsp;<asp:Label ID="lblStudentId" runat="server" Text="Student Id" ></asp:Label>
&nbsp;<asp:TextBox ID="txtStudentId" runat="server" Width="331px" ></asp:TextBox>
                <br />
                <br />
                &nbsp;<asp:Label ID="lblCourseId" runat="server" Text="Course Id" ></asp:Label>
&nbsp;<asp:TextBox ID="txtCourseId" runat="server" Enabled="False" placeholder="Select from table" Width="335px" ></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblGrade" runat="server" Text="Grade"></asp:Label>
&nbsp;<asp:TextBox ID="txtGrade" runat="server" Enabled="False" placeholder="To be determined" Width="371px" ></asp:TextBox>
                <br />
                <br />
            </div>
            Course Name&nbsp;
            <asp:TextBox ID="txtCourseName" runat="server" Enabled="false"  placeholder="Select from table" Width="366px"></asp:TextBox>
            <br />
            <br />
            Semester&nbsp; <asp:TextBox ID="txtSemester" runat="server" Width="326px" ></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="650px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
         <asp:GridView ID="coursegrid" runat="server" AutoGenerateColumns="False" Height="178px" Width="544px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" AllowPaging="True" ForeColor="Black" GridLines="Vertical" style="margin-left: 356px">
             <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
                 <asp:BoundField DataField="CourseId" HeaderText="CourseId" />
                 <asp:BoundField DataField="CourseName" HeaderText="CourseName" />
                 <asp:CommandField ShowSelectButton="True" />
             </Columns>
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#808080" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
         </asp:GridView>
            <br />
                <asp:Label ID="lblKeyWord" runat="server" Text="Key Word"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="507px" />
                &nbsp;<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp; <a href="adamLibrary.aspx">If interested in books please click here </a>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp; <a href="adamStudent.aspx">To go back please click here </a>
            <br />
            <br />
    </form>
</body>
</html>