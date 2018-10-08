<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Administration.aspx.vb" Inherits="Administration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Super Site: Administrator Changes</title>
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
    <div class="auto-style3">
    
        <asp:DropDownList ID="characterDropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="character_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:Characters %>" DeleteCommand="DELETE FROM [characters] WHERE [character_id] = @original_character_id AND [name] = @original_name AND (([alter_ego] = @original_alter_ego) OR ([alter_ego] IS NULL AND @original_alter_ego IS NULL)) AND [publisher] = @original_publisher AND (([super_powers] = @original_super_powers) OR ([super_powers] IS NULL AND @original_super_powers IS NULL)) AND [alignment] = @original_alignment AND (([image] = @original_image) OR ([image] IS NULL AND @original_image IS NULL))" InsertCommand="INSERT INTO [characters] ([name], [alter_ego], [publisher], [super_powers], [alignment], [image]) VALUES (@name, @alter_ego, @publisher, @super_powers, @alignment, @image)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [characters]" UpdateCommand="UPDATE [characters] SET [name] = @name, [alter_ego] = @alter_ego, [publisher] = @publisher, [super_powers] = @super_powers, [alignment] = @alignment, [image] = @image WHERE [character_id] = @original_character_id AND [name] = @original_name AND (([alter_ego] = @original_alter_ego) OR ([alter_ego] IS NULL AND @original_alter_ego IS NULL)) AND [publisher] = @original_publisher AND (([super_powers] = @original_super_powers) OR ([super_powers] IS NULL AND @original_super_powers IS NULL)) AND [alignment] = @original_alignment AND (([image] = @original_image) OR ([image] IS NULL AND @original_image IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_character_id" Type="Int32" />
                <asp:Parameter Name="original_name" Type="String" />
                <asp:Parameter Name="original_alter_ego" Type="String" />
                <asp:Parameter Name="original_publisher" Type="String" />
                <asp:Parameter Name="original_super_powers" Type="String" />
                <asp:Parameter Name="original_alignment" Type="String" />
                <asp:Parameter Name="original_image" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="alter_ego" Type="String" />
                <asp:Parameter Name="publisher" Type="String" />
                <asp:Parameter Name="super_powers" Type="String" />
                <asp:Parameter Name="alignment" Type="String" />
                <asp:Parameter Name="image" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="alter_ego" Type="String" />
                <asp:Parameter Name="publisher" Type="String" />
                <asp:Parameter Name="super_powers" Type="String" />
                <asp:Parameter Name="alignment" Type="String" />
                <asp:Parameter Name="image" Type="String" />
                <asp:Parameter Name="original_character_id" Type="Int32" />
                <asp:Parameter Name="original_name" Type="String" />
                <asp:Parameter Name="original_alter_ego" Type="String" />
                <asp:Parameter Name="original_publisher" Type="String" />
                <asp:Parameter Name="original_super_powers" Type="String" />
                <asp:Parameter Name="original_alignment" Type="String" />
                <asp:Parameter Name="original_image" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <p> <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="nameRequiredFieldValidator" runat="server" ControlToValidate="nameTextBox" ErrorMessage="Name Required*" ForeColor="#D01E00"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="insertCharacterButton" runat="server" Text="Add Character" />
        </p>
        <p> 
            <asp:Label ID="Label2" runat="server" Text="Alter Ego: "></asp:Label>
&nbsp;
            <asp:TextBox ID="alterEgoTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p> 
            <asp:Label ID="Label3" runat="server" Text="Super Powers: "></asp:Label>
&nbsp;
            <asp:TextBox ID="superPowersTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="deleteCharacterButton" runat="server" Text="Delete Character" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p> 
            <asp:Label ID="Label4" runat="server" Text="Publisher:  "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="publisherTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="publisherRequiredFieldValidator" runat="server" ControlToValidate="publisherTextBox" ErrorMessage="Publisher Required*" ForeColor="#D01E00"></asp:RequiredFieldValidator>
        </p>
        <p> 
            <asp:Label ID="Label5" runat="server" Text="Alignment: "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="alignmentTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="alignmentRequiredFieldValidator" runat="server" ControlToValidate="alignmentTextBox" ErrorMessage="Alignment Required*" ForeColor="#D01E00"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="updateCharacterButton" runat="server" Text="Update Character" />
        </p>
            <p> 
            <asp:Label ID="Label12" runat="server" Text="Image: "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="characterImageTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        </p>
        <p> &nbsp;</p>
        <p> 
            <asp:Label ID="characterConfirmationLabel" runat="server"></asp:Label>
        </p>
        <p> 
            &nbsp;</p>
        <br />
            <asp:Label ID="Label11" runat="server" Text="Character Id:  "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="characterIdTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<p> <asp:Label ID="Label6" runat="server" Text="Product Name: "></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="productNameTextBox" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="insertProductButton" runat="server" Text="Add Product" />
        </p>
        <p> 
            <asp:Label ID="Label7" runat="server" Text="Price: "></asp:Label>
&nbsp;
            <asp:TextBox ID="priceTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p> 
            <asp:Label ID="Label8" runat="server" Text="Description: "></asp:Label>
&nbsp;
            <asp:TextBox ID="descriptionTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="deleteProductButton" runat="server" Text="Delete Product" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p> 
            <asp:Label ID="Label9" runat="server" Text="Quantity: "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="quantityTextBox" runat="server"></asp:TextBox>
        </p>
        <p> 
            <asp:Label ID="Label10" runat="server" Text="Image: "></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="productImageTextBox" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="updateProductButton" runat="server" Text="Update Product" />
        </p>
        <p> &nbsp;</p>
        <p> 
            <asp:Label ID="productConfirmationLabel" runat="server"></asp:Label>
        </p>
        <p> 
            &nbsp;</p>
            <br />
    
    </div>
    </form>
</body>
</html>
