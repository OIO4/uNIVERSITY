<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BooksRentedByStudents.aspx.vb" Inherits="uNIVERSITY.BooksRentedByStudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>

input[type=submit] {
  width: 500px;
  background-color: #5d5555;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
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


         .auto-style1 {
             width: 100%;
             border-collapse: collapse;
             border: 1px solid black;
         }


     </style>
</head>
<body>
    <fieldset>
        <legend> To rent books </legend>
    <form id="studentGrid" runat="server">
        <br />
        <h2>From the following table choose your Book</h2>
        <p>KeyWord&nbsp;
                <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="206px" />
            </p>
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
        <br id="studentGrid" />
        <div id="lblRentalPeriod">
        <div id="lblCourseId">
            StudentId&nbsp; <asp:TextBox ID="txtStudentId" runat="server" placeholder="Enter your Student ID"></asp:TextBox>
            <br />
            <br />
            BookId&nbsp;&nbsp; <asp:TextBox ID="txtBookId" runat="server" placeholder="Enter the books id that you would like to rent"></asp:TextBox>
            <br />
            <br />
        </div>
            RentalPeriod&nbsp;&nbsp; <asp:TextBox ID="txtRentalPeriod" runat="server" placeholder="Between 1 week and 4 weeks max"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </p>
        <p>
&nbsp;&nbsp; <a href="Course.aspx">To go back please click here</a></p>
        <p>
            &nbsp;</p>
           
    </form>
   </fieldset>
</body>
</html>
