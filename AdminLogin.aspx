<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AdminLogin.aspx.vb" Inherits="AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Super Site: Administrator Login</title>
        <style type="text/css">
            
        .auto-style2 {
            text-align: center;
        }

        a {
            text-decoration: none;
            color: black;
            padding-left: 25px;
            padding-right: 25px;
            background-color: #41a6de;
        }
        h1{
            background-color: #d01e00;
        }
        body{
            background-color: #fedb0e;
        }
        form{
            background-color: #41a6de;
            margin: 70px;
            padding: 30px;
        }
        </style>
</head>
<body>

                   <h1 class="auto-style2">The Super Site</h1>
         
 
         <h3 class="auto-style2">
               <a href="Default.aspx">Home</a>
          <a href="Characters.aspx">Characters</a>
          <a href="Store.aspx">Store</a>
             <a href="Battle.aspx">Battle</a>
          <a href="AdminLogin.aspx">Administration</a>
        </h3>
                   <form id="form1" runat="server">
                       <div>
    
        <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:RequiredFieldValidator ID="usernameRequiredFieldValidator" runat="server" ControlToValidate="usernameTextBox" ErrorMessage="Username required" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="passwordTextBox" ErrorMessage="Password required*" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="loginButton" runat="server" Text="Log In" />
        <br />
    
    </div>
    </form>
</body>
</html>
