<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="adamLibrary.aspx.vb" Inherits="uNIVERSITY.adamLibrary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="adamUni.css" />
</head>
<body>
    <form id="lblBookName" runat="server">
         <div id="lblBookId">
                <br />
                <br />
                <br />
                Student Id&nbsp; <asp:TextBox ID="txtStudentId" runat="server" Width="323px" ></asp:TextBox>
                <br />
                <br />
                Book Id&nbsp; <asp:TextBox ID="txtBookId" runat="server"  Enabled="False" placeholder="Select from table" Width="348px"></asp:TextBox>
                <br />
                <br />
            </div>
            Book Name&nbsp;
            <asp:TextBox ID="txtBookName" runat="server" Enabled="False"  placeholder="Select from table" Width="316px"></asp:TextBox>
            <br />
         <br />
                Rental Period&nbsp;
                <asp:TextBox ID="txtRentalPeriod" runat="server" Width="296px" ></asp:TextBox>
            <br />
            <br />
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="650px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
         <br />
         <br />
&nbsp;<div>
        </div>
         <asp:GridView ID="librarygrid" runat="server" AutoGenerateColumns="False" Height="178px" Width="525px" AllowPaging="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" style="margin-left: 330px">
             <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
                 <asp:BoundField DataField="BookId" HeaderText="BookId" />
                 <asp:BoundField DataField="BookName" HeaderText="BookName" />
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
&nbsp;&nbsp;&nbsp;&nbsp; <a href="adamCourse.aspx">To go back please click here </a>
         <br />
         <br />
    </form>
</body>
</html>
