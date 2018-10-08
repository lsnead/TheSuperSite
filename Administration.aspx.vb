
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class Administration
    Inherits System.Web.UI.Page

    Private connectionString As String = WebConfigurationManager.ConnectionStrings("Characters").ConnectionString


    Private Sub Administration_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            characterDropDownList.DataBind()
            characterDropDownList.SelectedIndex = -1
        End If

    End Sub

    Protected Sub characterDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles characterDropDownList.SelectedIndexChanged
        Dim selectSQL As String = "SELECT * FROM characters WHERE character_id='" & characterDropDownList.SelectedValue & "'"
        Dim myConnection As New SqlConnection(connectionString)
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim charactersDataset As New DataSet
        Try
            myConnection.Open()
            myAdapter.Fill(charactersDataset, "myCharacters")
            Dim rowCharacter As DataRow = charactersDataset.Tables("myCharacters").Rows(0)
            nameTextBox.Text = rowCharacter("name").ToString
            alterEgoTextBox.Text = rowCharacter("alter_ego").ToString
            superPowersTextBox.Text = rowCharacter("super_powers").ToString
            publisherTextBox.Text = rowCharacter("publisher").ToString
            alignmentTextBox.Text = rowCharacter("alignment").ToString
            characterImageTextBox.Text = rowCharacter("image").ToString


        Catch ex As Exception
            characterConfirmationLabel.Text = "Error getting character information.  " & ex.Message
        Finally
            myConnection.Close()
        End Try

        Dim selectPSQL As String = "SELECT * FROM products WHERE character_id='" & characterDropDownList.SelectedValue & "'"
        Dim myPConnection As New SqlConnection(connectionString)
        Dim myPCommand As New SqlCommand(selectPSQL, myPConnection)
        Dim myPAdapter As New SqlDataAdapter(myPCommand)
        Dim productsDataset As New DataSet

        Try
            myPConnection.Open()
            myPAdapter.Fill(productsDataset, "Products")
            Dim rowProduct As DataRow = productsDataset.Tables("Products").Rows(0)

            characterIdTextBox.Text = rowProduct("character_id").ToString
            productNameTextBox.Text = rowProduct("product_name").ToString
            priceTextBox.Text = rowProduct("price").ToString
            descriptionTextBox.Text = rowProduct("description").ToString
            quantityTextBox.Text = rowProduct("quantity").ToString
            productImageTextBox.Text = rowProduct("image").ToString



        Catch ex As Exception
            productConfirmationLabel.Text = "Error getting product information.  " & ex.Message
        Finally
            myPConnection.Close()
        End Try

    End Sub

    Protected Sub insertCharacterButton_Click(sender As Object, e As EventArgs) Handles insertCharacterButton.Click
        Dim insertSQL As New StringBuilder
        With insertSQL
            .Append("INSERT INTO characters (name, alter_ego, super_powers, publisher, alignment, image)")
            .Append("VALUES (@name, @alter_ego, @super_powers, @publisher, @alignment, @image)")
            ' .Append("WHERE character_id='" & characterDropDownList.SelectedValue & "'")
        End With


        Dim successBoolean As Boolean
        Dim myConnection As New SqlConnection()
        myConnection.ConnectionString = connectionString
        Try
            myConnection.Open()
            Dim myCommand As New SqlCommand(insertSQL.ToString, myConnection)
            With myCommand.Parameters

                .AddWithValue("@name", nameTextBox.Text).ToString()
                .AddWithValue("@alter_ego", alterEgoTextBox.Text).ToString()
                .AddWithValue("@super_powers", superPowersTextBox.Text).ToString()
                .AddWithValue("@publisher", publisherTextBox.Text).ToString()
                .AddWithValue("@alignment", alignmentTextBox.Text).ToString()
                .AddWithValue("@image", characterImageTextBox.Text).ToString()

            End With
            successBoolean = myCommand.ExecuteNonQuery
            characterConfirmationLabel.Text = "New character has been added to database"
        Catch ex As Exception
            successBoolean = False
            characterConfirmationLabel.Text = ex.Message
        Finally
            myConnection.Close()
        End Try


        If successBoolean Then
            characterDropDownList.DataBind()

            Dim position As Integer = 0
            For index As Integer = 0 To characterDropDownList.Items.Count - 1
                If characterDropDownList.Items(index).Value = characterIdTextBox.Text Then
                    position = index
                End If
            Next

            characterDropDownList.SelectedIndex = position
        End If

    End Sub

    Protected Sub insertProductButton_Click(sender As Object, e As EventArgs) Handles insertProductButton.Click
        Dim insertSQL As New StringBuilder
        With insertSQL
            .Append("INSERT INTO products (character_id, product_name, price, description, quantity, image)")
            .Append("VALUES (@character_id, @product_name, @price, @description, @quantity, @image)")
        End With


        Dim successBoolean As Boolean
        Dim myConnection As New SqlConnection()
        myConnection.ConnectionString = connectionString
        Try
            myConnection.Open()

            Dim myCommand As New SqlCommand(insertSQL.ToString, myConnection)
            With myCommand.Parameters

                .AddWithValue("@character_id", characterIdTextBox.Text).ToString()
                .AddWithValue("@product_name", productNameTextBox.Text).ToString()
                .AddWithValue("@price", priceTextBox.Text).ToString()
                .AddWithValue("@description", descriptionTextBox.Text).ToString()
                .AddWithValue("@quantity", quantityTextBox.Text).ToString()
                .AddWithValue("@image", productImageTextBox.Text).ToString()
            End With
            successBoolean = myCommand.ExecuteNonQuery
            productConfirmationLabel.Text = "Product added."
        Catch ex As Exception
            successBoolean = False
            productConfirmationLabel.Text = "Error adding product. " & ex.Message
        Finally
            myConnection.Close()
        End Try


        If successBoolean Then
            characterDropDownList.DataBind()
        End If

    End Sub

    Protected Sub deleteCharacterButton_Click(sender As Object, e As EventArgs) Handles deleteCharacterButton.Click
        Dim deleteSQL As String
        deleteSQL = "DELETE FROM characters WHERE character_id=@character_id"
        Dim myConnection As New SqlConnection()
        Dim successBoolean As Boolean = True
        myConnection.ConnectionString = connectionString
        Try
            myConnection.Open()

            Dim myCommand As New SqlCommand(deleteSQL, myConnection)
            myCommand.Parameters.AddWithValue("@character_id", characterDropDownList.SelectedValue)
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            successBoolean = False
            characterConfirmationLabel.Text = "ERROR in deleting character and it's products. " & ex.Message
        Finally
            myConnection.Close()
        End Try
        If successBoolean Then
            characterDropDownList.DataBind()
            characterDropDownList_SelectedIndexChanged(sender, e)
            characterConfirmationLabel.Text = "Character and it's products have been deleted"
        End If
    End Sub

    Protected Sub deleteProductButton_Click(sender As Object, e As EventArgs) Handles deleteProductButton.Click
        Dim deleteSQL As String
        deleteSQL = "DELETE FROM products WHERE character_id=@character_id"
        Dim myConnection As New SqlConnection()
        Dim successBoolean As Boolean = True
        myConnection.ConnectionString = connectionString
        Try
            myConnection.Open()
            Dim myCommand As New SqlCommand(deleteSQL, myConnection)
            myCommand.Parameters.AddWithValue("@character_id", characterDropDownList.SelectedValue)

            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            successBoolean = False
            productConfirmationLabel.Text = "ERROR in deleting product. " & ex.Message
        Finally
            myConnection.Close()
        End Try
        If successBoolean Then
            characterDropDownList.DataBind()
            characterDropDownList_SelectedIndexChanged(sender, e)
            productConfirmationLabel.Text = "Products have been deleted"
        End If
    End Sub


    Protected Sub updateCharacterButton_Click(sender As Object, e As EventArgs) Handles updateCharacterButton.Click
        Dim updateSQL As New StringBuilder
        With updateSQL
            .Append("UPDATE characters SET ")
            .Append("character_id=@character_ id, name=@name, alter_ego=@alter_ego, super_powers=@super_powers, publisher=@publisher, alignment=@alignment, image=@image")
            .Append(" WHERE character_id=@character_id")
        End With
        Dim successBoolean As Boolean = True
        Dim myConnection As New SqlConnection()
        myConnection.ConnectionString = connectionString
        Try
            myConnection.Open()

            Dim myCommand As New SqlCommand(updateSQL.ToString, myConnection)
            With myCommand.Parameters
                .AddWithValue("character_id", characterDropDownList.SelectedValue)
                .AddWithValue("@name", nameTextBox.Text).ToString()
                .AddWithValue("@alter_ego", alterEgoTextBox.Text).ToString()
                .AddWithValue("@super_powers", superPowersTextBox.Text).ToString()
                .AddWithValue("@publisher", publisherTextBox.Text).ToString()
                .AddWithValue("@alignment", alignmentTextBox.Text).ToString()
                .AddWithValue("@image", characterImageTextBox.Text).ToString()
            End With

            successBoolean = myCommand.ExecuteNonQuery
            characterConfirmationLabel.Text = "Record Updated"
        Catch ex As Exception
            successBoolean = False
            characterConfirmationLabel.Text = "Error Updating Record. " & ex.Message
        Finally
            myConnection.Close()
        End Try
        If successBoolean Then
            characterDropDownList.DataBind()
            Dim position As Integer = 0
            For index As Integer = 0 To characterDropDownList.Items.Count - 1
                If characterDropDownList.Items(index).Value = characterIdTextBox.Text Then
                    position = index
                End If
            Next
            characterDropDownList.SelectedIndex = position
        End If
    End Sub

    Protected Sub updateProductButton_Click(sender As Object, e As EventArgs) Handles updateProductButton.Click
        Dim updateSQL As New StringBuilder
        With updateSQL
            .Append("UPDATE products SET ")
            .Append("product_name=@product_name, character_id=@character_id, price=@price, description=@description, quantity=@quantity, image=@image")
            .Append(" WHERE character_id=@character_id")
        End With
        Dim successBoolean As Boolean = True
        Dim myConnection As New SqlConnection()
        myConnection.ConnectionString = connectionString
        Try
            myConnection.Open()
            Dim myCommand As New SqlCommand(updateSQL.ToString, myConnection)
            With myCommand.Parameters
                .AddWithValue("@character_id", characterIdTextBox.Text).ToString()
                .AddWithValue("@product_name", productNameTextBox.Text).ToString()
                .AddWithValue("@price", priceTextBox.Text).ToString()
                .AddWithValue("@description", descriptionTextBox.Text).ToString()
                .AddWithValue("@quantity", quantityTextBox.Text).ToString()
                .AddWithValue("@image", productImageTextBox.Text).ToString()
            End With

            successBoolean = myCommand.ExecuteNonQuery
            productConfirmationLabel.Text = "Record Updated"
        Catch ex As Exception
            successBoolean = False
            productConfirmationLabel.Text = "Error Updating Record. " & ex.Message
        Finally
            myConnection.Close()
        End Try
        If successBoolean Then
            characterDropDownList.DataBind()
            Dim position As Integer = 0
            For index As Integer = 0 To characterDropDownList.Items.Count - 1
                If characterDropDownList.Items(index).Value = characterIdTextBox.Text Then
                    position = index
                End If
            Next
            characterDropDownList.SelectedIndex = position
        End If
    End Sub
End Class
