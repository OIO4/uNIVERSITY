<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Course.aspx.vb" Inherits="uNIVERSITY.Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style>   
   input[type=submit] {
     border-style: none;
         border-color: inherit;
         border-width: medium;
         background-color: #5d5555;
         color: white;
         padding: 14px 20px;
         margin: 8px 0;
         border-radius: 4px;
         cursor: pointer;
}
   input[type=text] {
  width: 40%;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 4px;
  resize: vertical;
}

 </style>
</head>
<body>
    <fieldset>
        <legend>Course Registration</legend>
    <form id="lblCourseName" runat="server">
        <h2>From the following table choose the course(/s) </h2>
            KeyWord&nbsp;
                <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="206px" />
            <asp:GridView ID="studentGrid" runat="server" CssClass="table" style="margin-right: 0px; margin-top: 63px;" Width="996px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AllowPaging="True" CellSpacing="2" Height="533px" >
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
         <br />
        <div id="lblCourseId">
            Course Id&nbsp; <asp:TextBox ID="txtCourseId" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
        Course Name&nbsp;&nbsp; <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
         <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Height="59px" Width="500px" />
         <br />
         <br />
&nbsp;&nbsp; <a href="Student.aspx">To go back please click here</a>
         <br />
         <br />
         &nbsp;&nbsp; <a href="BooksRentedByStudents.aspx">If interested in books click here</a>
         <br />
&nbsp;<br />
    </form>
        </fieldset>
</body>
</html>
