<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Student.aspx.vb" Inherits="uNIVERSITY.Student" %>

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
            margin: 0px 0 8px 16px;
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

    table {
      width: 100%;
      border-collapse: collapse;
        background-color: #5d5555;
    }

    table, th, td {
      border: 1px solid black;
      
    }

    th, td {
      padding: 8px;
      text-align: left;
    }

    </style>
</head>
<body>
    <form runat="server">
        <fieldset id="lblKeyWord">
            <legend>Student Form</legend>
            <br />
            <br />
            <br />
            <br />
            KeyWord&nbsp;
                <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="206px" />
            <asp:GridView ID="studentGrid" runat="server" AutoGenerateColumns="False" CssClass="table" style="margin-right: 0px; margin-top: 63px;" Width="996px" CellPadding="3" AllowPaging="True" Height="533px" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" >
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
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <div id="lblStudentId">
                <br />
                <br />
                Student Id&nbsp; <asp:TextBox ID="txtStudentId" runat="server" Enabled="False" placeholder="Don't touch this"></asp:TextBox>
                <br />
                <br />
            </div>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <p>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            </p>
            <p>
                Date Of Birth&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </p>
            <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="650px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="252px" />
            </p>
            &nbsp;&nbsp;&nbsp; <a href="Course.aspx">To register for your courses please click here</a>
            <br />
            <br />
            <br />
            <br />
        </fieldset>
    </form>
</body>
</html>