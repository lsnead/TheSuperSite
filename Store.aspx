<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Store.aspx.vb" Inherits="Store" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Super Site: Store</title>
        <style type="text/css">
            .auto-style1 {
                margin-left: 920px;
            }
            
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

    <p class="auto-style1"> &nbsp;</p>
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
    
        <asp:DropDownList ID="characterStoreDropDownList" runat="server" AutoPostBack="True" DataSourceID="charactersSqlDataSource" DataTextField="name" DataValueField="character_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="charactersSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Characters %>" SelectCommand="SELECT [character_id], [name] FROM [characters]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="productsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Characters %>" SelectCommand="SELECT * FROM [products]"></asp:SqlDataSource>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Image ID="productImage" runat="server" Height="100px" Width="100px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        &nbsp;
        <asp:Label ID="productIdLabel" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Label ID="productNameLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="priceLabel" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="productDescriptionLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="quantityLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="orderQuantityLabel" runat="server" Text="Order Quantity"></asp:Label>
        <br />
        <asp:TextBox ID="orderQuantityTextBox" runat="server" Width="64px">1</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="addToCartButton" runat="server" Text="Add to Cart" onClick="AddToCart" />
    
        <br />
        <br />
        <asp:Label ID="errorLabel" runat="server"></asp:Label>
    
        <br />
        <asp:GridView ID="cartGridView" runat="server" Visible="False">
        </asp:GridView>
        <br />
        <asp:Label ID="totalLabel" runat="server" Visible="False"></asp:Label>
        <br />
        <a>
            <asp:ImageButton ID="cartImageButton" runat="server" BorderColor="#41A6DE" BorderStyle="Solid" Height="25px" ImageUrl="~/images/cart.png" PostBackUrl="~/Cart.aspx" Width="25px" />
            </a>
    
    </div>
    </form>
</body>
</html>
