<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="uNIVERSITY.login" %>

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
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblUserName" runat="server" Text="User Name" ></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtUserName" runat="server" Width="361px" Required="true"></asp:TextBox>
            <br />
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
             <p>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblPassword" runat="server" Text="Password" Enabled="False" ></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="27px" Width="261px"></asp:TextBox>
            </p>
                <p style="width: 476px; margin-left: 130px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBoxPassword" runat="server" Text="Show Password" OnClick="ShowPassword()" />
            </p>
                <p>
                    &nbsp;</p>
                &nbsp;<p>
                 &nbsp;</p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnLogin" runat="server" Text="Login" Width="487px" Height="46px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
             <p>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            </p>
             <p>
                 <a href="register.aspx">Don't have an account? Click here to create one</a></p>
             <p>
                 &nbsp;</p>
        </div>
    </form>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        


    </p>
</body>
</html>
