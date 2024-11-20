<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="register.aspx.vb" Inherits="uNIVERSITY.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="adamUni.css" />
    <script>
        function ShowPassword() {
            var passwordField = document.getElementById('txtPassword');
            var checkBox = document.getElementById('CheckBoxPassword');
            if (checkBox.checked) {
                passwordField.type = "text";
            } else {
                passwordField.type = "password";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <fieldset>
                <legend>Create account</legend>
                <br />
                <br />
&nbsp;
            <asp:Label ID="lblUserId" runat="server" Text="User ID" Visible="False"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtUserName0" runat="server" Width="361px" Visible="False"></asp:TextBox>
            <br />
            <br />
            <br />
            &nbsp;
            <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtUserName" runat="server" Width="361px"></asp:TextBox>
                <br />
&nbsp;<p>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblPassword" runat="server" Text="Password" Enabled="False" ></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="27px" Width="261px"></asp:TextBox>
            </p>
                <p style="width: 476px; margin-left: 130px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBoxPassword" runat="server" Text="Show Password" OnClick="ShowPassword()" />
            </p>
                <p>
                    &nbsp;</p>
                <p>
                &nbsp;&nbsp;
                Date Of Creation&nbsp;&nbsp; 
                <asp:TextBox ID="txtDateOfCreation" runat="server" TextMode="Date" Width="341px"></asp:TextBox>
                &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCreate" runat="server" Text="Create account" Width="467px" Height="78px" style="margin-left: 17px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
                <p>
            <a href="register.aspx">Have an account? Sign up</a></p>
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                </fieldset>
        </div>
    </form>
</body>
</html>



