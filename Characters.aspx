<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Characters.aspx.vb" Inherits="Characters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Super Site: Characters</title>
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
                text-align: left;
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
    <div class="auto-style2">
    
        <asp:DropDownList ID="characterDropDownList" runat="server" AutoPostBack="True" DataSourceID="charactersSqlDataSource" DataTextField="name" DataValueField="character_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="charactersSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Characters %>" SelectCommand="SELECT * FROM [characters] ORDER BY [name]"></asp:SqlDataSource>
        &nbsp;
    
    </div>
        <p class="auto-style2">
            <br />
            <br />&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="characterImageButton" runat="server" Height="100px" PostBackUrl="~/Store.aspx" Width="100px" />
        </p>
        <p class="auto-style2">
            &nbsp;<asp:Label ID="characterLabel" runat="server"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
            <h3> Don&#39;t see your favorite character(s)? Add them to our database!</h3>
        <p> *Users will not be able to buy products related to user added characters</p>
        <p> 
            <asp:Label ID="Label6" runat="server" Text="Please proofread before submitting. If you need to update or delete a record, contact thesupersitejcu@gmail.com"></asp:Label>
        </p>
        <p> &nbsp;</p>
        <p class="auto-style3">  
            <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="nameRequiredFieldValidator" runat="server" ControlToValidate="nameTextBox" ErrorMessage="Name Required*" ForeColor="#D01E00"></asp:RequiredFieldValidator>
        </p>
        <p class="auto-style3">  
            <asp:Label ID="Label2" runat="server" Text="Alter Ego: "></asp:Label>
&nbsp;
            <asp:TextBox ID="alterEgoTextBox" runat="server"></asp:TextBox>
        </p>
        <p class="auto-style3"> 
            <asp:Label ID="Label3" runat="server" Text="Super Powers: "></asp:Label>
&nbsp;
            <asp:TextBox ID="superPowersTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="insertButton" runat="server" Text="Add Character" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p class="auto-style3"> 
            <asp:Label ID="Label4" runat="server" Text="Publisher:  "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="publisherTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="publisherRequiredFieldValidator" runat="server" ControlToValidate="publisherTextBox" ErrorMessage="Publisher Required*" ForeColor="#D01E00"></asp:RequiredFieldValidator>
        </p>
        <p class="auto-style3"> 
            <asp:Label ID="Label5" runat="server" Text="Alignment: "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="alignmentTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="alignmentRequiredFieldValidator" runat="server" ControlToValidate="alignmentTextBox" ErrorMessage="Alignment Required*" ForeColor="#D01E00"></asp:RequiredFieldValidator>
        </p>
        <p> &nbsp;</p>
        <p> 
            <asp:Label ID="confirmationLabel" runat="server"></asp:Label>
        </p>
        <p> &nbsp;</p>
          <p class="auto-style2">  
            <a>
            <asp:ImageButton ID="cartImageButton" runat="server" BorderColor="#41A6DE" BorderStyle="Solid" Height="25px" ImageUrl="~/images/cart.png" PostBackUrl="~/Cart.aspx" Width="25px" />
            </a>
    
        </p>
    </form>
</body>
</html>
