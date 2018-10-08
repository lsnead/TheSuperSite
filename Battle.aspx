<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Battle.aspx.vb" Inherits="Battle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Super Site: Battle</title>
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
        .auto-style3 {
            text-align: right;
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
    <div >
    
        <div class="auto-style2">
    
        <asp:DropDownList ID="playerOneDropDownList" runat="server" AutoPostBack="True" DataSourceID="charactersSqlDataSource" DataTextField="name" DataValueField="character_id">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="playerTwoDropDownList" runat="server" AutoPostBack="True" DataSourceID="charactersSqlDataSource" DataTextField="name" DataValueField="character_id">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Image ID="playerOneImage" runat="server" Height="100px" Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="VS."></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="playerTwoImage" runat="server" Height="100px" Width="100px" />
        <br />
        <br />
        <asp:Button ID="battleButton" runat="server" Text="Battle!" />
        <br />
        <br />
        </div>
        <asp:SqlDataSource ID="charactersSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Characters %>" SelectCommand="SELECT [character_id], [name] FROM [characters]"></asp:SqlDataSource>
        <div class="auto-style2">
        <asp:Label ID="winnerLabel" runat="server"></asp:Label>
    
            <br />
            <br />
        </div>
        <p>&nbsp;</p>
        <p class="auto-style2">
&nbsp;
            <asp:Label ID="lastWinnerLabel" runat="server"></asp:Label>
        </p>
        <p class="auto-style2">
            <asp:Label ID="lastLoserLabel" runat="server"></asp:Label>
        </p>
        <p class="auto-style3">
            <a>
            <asp:ImageButton ID="cartImageButton" runat="server" BorderColor="#41A6DE" BorderStyle="Solid" Height="25px" ImageUrl="~/images/cart.png" PostBackUrl="~/Cart.aspx" Width="25px" />
            </a>
        </p>
    </div>
    </form>
</body>
</html>
