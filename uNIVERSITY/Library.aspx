<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Library.aspx.vb" Inherits="uNIVERSITY.Library" %>

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

</style>
</head>
<body>
    <fieldset>
        <legend>Library Books To Rent</legend>
    <form id="form1" runat="server">
        <div>
        <div id="lblStudentId">
            BookId<asp:TextBox ID="txtBookId" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>
            <asp:Label ID="lblBookName" runat="server" Text="BookName"></asp:Label>
            <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;
        </div>
        <p>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        </p>
    </form>
        </fieldset>
</body>
</html>
