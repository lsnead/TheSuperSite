Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports EASendMailSvcObjLib
Imports System.Web.Mail
Imports System.Net.Mail.SmtpClient
Imports System.Net.Mail

Partial Class Store

    Inherits System.Web.UI.Page

    Private connectionString As String = WebConfigurationManager.ConnectionStrings("Characters").ConnectionString



    Protected Sub characterStoreDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles characterStoreDropDownList.SelectedIndexChanged
        Dim selectSQL As String = "SELECT * FROM products WHERE character_id='" & characterStoreDropDownList.SelectedValue & "'"
        Dim myConnection As New SqlConnection(connectionString)
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim charactersDataSet As New DataSet

        Try
            myConnection.Open()
            myAdapter.Fill(charactersDataSet, "myCharacters")
            Dim productRow As DataRow = charactersDataSet.Tables("myCharacters").Rows(0)



            productIdLabel.Text = productRow("product_id")
            productNameLabel.Text = productRow("product_name")
            priceLabel.Text = "$" & productRow("price")
            productDescriptionLabel.Text = productRow("description")
            quantityLabel.Text = "Quantity available: " & productRow("quantity")


            If productRow("quantity") = 0 Then
                quantityLabel.Text = "SOLD OUT"
                addToCartButton.Enabled() = False
            End If

            productImage.ImageUrl = productRow("image")


            orderQuantityTextBox.Visible = True
            addToCartButton.Visible = True

            errorLabel.Text = ""

        Catch ex As Exception
            productIdLabel.Text = "No products available for this character. Check back soon!"
            productNameLabel.Text = " "
            priceLabel.Text = " "
            productDescriptionLabel.Text = " "
            quantityLabel.Text = " "

            orderQuantityLabel.Text = " "
            orderQuantityTextBox.Visible = False
            addToCartButton.Visible = False

            productImage.ImageUrl = "images\imagecomingsoon.png"

        Finally
            myConnection.Close()
        End Try
    End Sub

    Private Sub Store_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            characterStoreDropDownList.DataBind()
            characterStoreDropDownList_SelectedIndexChanged(sender, e)
            makeCart()
        End If
        orderQuantityTextBox.Text = 1
    End Sub

    Dim cartDataTable As System.Data.DataTable
    Dim cartDataRow As System.Data.DataRow


    Private Sub makeCart()
        cartDataTable = New System.Data.DataTable("Cart")
        With cartDataTable
            .Columns.Add("ID", GetType(Integer))
            .Columns("ID").AutoIncrement = True
            .Columns("ID").AutoIncrementSeed = 1

            .Columns.Add("Quantity", GetType(Integer))
            .Columns.Add("Product", GetType(String))
            .Columns.Add("Cost", GetType(Double))
        End With


        Session("Cart") = cartDataTable
    End Sub

    Sub AddToCart(s As Object, e As EventArgs)
        cartDataTable = Session("Cart")
        ' Session("Quantity") = cartDataRow("Quantity")
        Dim Quantity = orderQuantityTextBox.Text
        Session("Quantity") = Quantity
        Dim Product = productNameLabel.Text
        Dim match As Boolean = False

        For Each cartDataRow In cartDataTable.Rows
            If cartDataRow("Product") = Product Then
                cartDataRow("Quantity") += CInt(Quantity)
                match = True
                Exit For
            End If
        Next

        If Not match Then
            cartDataRow = cartDataTable.NewRow
            cartDataRow("Quantity") = (Quantity)
            cartDataRow("Product") = Product
            cartDataRow("Cost") = CDbl(priceLabel.Text)
            cartDataTable.Rows.Add(cartDataRow)
        End If
        Session("Cart") = cartDataTable

        cartGridView.DataSource = cartDataTable
        cartGridView.DataBind()

        errorLabel.Text = "Item added to cart"

        totalLabel.Text = "$" & GetItemTotal()
    End Sub

    Function GetItemTotal() As Decimal
        Dim index As Integer
        Dim decRunningTotal As Decimal

        For index = 0 To cartDataTable.Rows.Count - 1
            cartDataRow = cartDataTable.Rows(index)
            decRunningTotal += (cartDataRow("Cost") * cartDataRow("Quantity"))
        Next

        Return decRunningTotal
    End Function

    Sub Delete_Item(s As Object, e As DataGridCommandEventArgs)
        cartDataTable = Session("Cart")
        cartDataTable.Rows(e.Item.ItemIndex).Delete()
        Session("Cart") = cartDataTable

        cartGridView.DataSource = cartDataTable
        cartGridView.DataBind()

        totalLabel.Text = "$" & GetItemTotal()
    End Sub

End Class
