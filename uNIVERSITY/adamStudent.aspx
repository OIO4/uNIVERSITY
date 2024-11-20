<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="adamStudent.aspx.vb" Inherits="uNIVERSITY.adam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="adamUni.css" />
</head>
<body>
    <form id="form1" runat="server">
         <div id="lblStudentId">
                <br />
                <br />
                Student Id&nbsp; <asp:TextBox ID="txtStudentId" runat="server" Enabled="False" placeholder="Don't touch this" Width="371px"></asp:TextBox>
                <br />
                <br />
            </div>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtFirstName" runat="server" Width="368px"></asp:TextBox>
            <p>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtLastName" runat="server" Width="372px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtFullName" runat="server" Width="370px"></asp:TextBox>
            </p>
            <p>
                Date Of Birth&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date" Width="341px"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtAddress" runat="server" Width="390px"></asp:TextBox>
            </p>
            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtPhone" runat="server" Width="409px"></asp:TextBox>
            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtEmail" runat="server" Width="409px"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="650px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update" Width="487px" Height="46px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </p>
         &nbsp;
         <asp:GridView ID="studentgrid" runat="server" AutoGenerateColumns="False" Height="178px" Width="313px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" AllowPaging="True" ForeColor="Black" GridLines="Vertical" style="margin-left:240px">
             <AlternatingRowStyle BackColor="#CCCCCC" />
             <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="StudentId" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" />
                    <asp:BoundField DataField="FullName" HeaderText="FullName" />
                    <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                 <asp:CommandField ShowSelectButton="True" />
             </Columns>
             <FooterStyle BackColor="#CCCCCC" />
             <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="Gray" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#383838" />
         </asp:GridView>
            <p>
                <asp:Label ID="lblKeyWord" runat="server" Text="Key Word"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtKeyWord" runat="server" Width="446px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" Width="507px" />
                &nbsp;</p>
         <p>
                &nbsp;</p>
         <p>
    <br />
                <a href="adamCourse.aspx"> To register for courses please click here </a></p>
         <p>
                &nbsp;</p>
    </form>
    <br />
    


</body>
</html>
