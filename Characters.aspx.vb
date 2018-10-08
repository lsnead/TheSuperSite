Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports System.Data
Partial Class Characters
    Inherits System.Web.UI.Page

    Private connectionString As String = WebConfigurationManager.ConnectionStrings("Characters").ConnectionString

    Protected Sub characterDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles characterDropDownList.SelectedIndexChanged
        Dim selectSQL As String = "SELECT * FROM characters WHERE character_id='" & characterDropDownList.SelectedValue & "'"
        Dim myConnection As New SqlConnection(connectionString)
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim charactersDataSet As New DataSet

        Try
            myConnection.Open()
            myAdapter.Fill(charactersDataSet, "myCharacters")
            Dim characterRow As DataRow = charactersDataSet.Tables("myCharacters").Rows(0)

            Dim characterString As New StringBuilder
            With characterString
                .Append("<b>Name: </b>")
                .Append(characterRow("name"))
                .Append("</br>")

                .Append("<b>Alter Ego: </b>")
                .Append(characterRow("alter_ego"))
                .Append("</br>")

                .Append("<b>Super Powers: </b>")
                .Append(characterRow("super_powers"))
                .Append("</br>")

                .Append("<b>Publisher: </b>")
                .Append(characterRow("publisher"))
                .Append("</br>")

                .Append("<b>Alignment: </b>")
                .Append(characterRow("alignment"))
                .Append("</br>")
            End With


            characterImageButton.ImageUrl = characterRow("image")

            characterLabel.Text = characterString.ToString

        Catch ex As Exception
            myAdapter.Fill(charactersDataSet, "myCharacters")
            Dim characterRow As DataRow = charactersDataSet.Tables("myCharacters").Rows(0)

            Dim characterString As New StringBuilder
            With characterString
                .Append("<b>Name: </b>")
                .Append(characterRow("name"))
                .Append("</br>")

                .Append("<b>Alter Ego: </b>")
                .Append(characterRow("alter_ego"))
                .Append("</br>")

                .Append("<b>Super Powers: </b>")
                .Append(characterRow("super_powers"))
                .Append("</br>")

                .Append("<b>Publisher: </b>")
                .Append(characterRow("publisher"))
                .Append("</br>")

                .Append("<b>Alignment: </b>")
                .Append(characterRow("alignment"))
                .Append("</br>")
            End With

            characterImageButton.ImageUrl = "images\playerOne.png"
            characterLabel.Text = characterString.ToString
        Finally
            myConnection.Close()
        End Try

    End Sub

    Private Sub Characters_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            characterDropDownList.DataBind()
            ' characterDropDownList.SelectedIndex = 0
            characterDropDownList_SelectedIndexChanged(sender, e)
        End If

    End Sub

    Protected Sub insertButton_Click(sender As Object, e As EventArgs) Handles insertButton.Click
        Dim insertSQL As New StringBuilder
        With insertSQL
            .Append("INSERT INTO characters (name, alter_ego, super_powers, publisher, alignment)")
            .Append("VALUES (@name, @alter_ego, @super_powers, @publisher, @alignment)")
        End With


        Dim successBoolean As Boolean
        Dim myConnection As New SqlConnection()
        Try
            myConnection.ConnectionString = connectionString
            Dim myCommand As New SqlCommand(insertSQL.ToString, myConnection)
            With myCommand.Parameters

                .AddWithValue("@name", nameTextBox.Text).ToString()
                .AddWithValue("@alter_ego", alterEgoTextBox.Text).ToString()
                .AddWithValue("@super_powers", superPowersTextBox.Text).ToString()
                .AddWithValue("@publisher", publisherTextBox.Text).ToString()
                .AddWithValue("@alignment", alignmentTextBox.Text).ToString()
            End With
            myConnection.Open()
            successBoolean = myCommand.ExecuteNonQuery
            ' confirmationLabel.Text = "Yay! Your character has been added to our database"
        Catch ex As Exception
            successBoolean = False
            confirmationLabel.Text = "Oh no! Something went wrong, your character was not added" & ex.Message
        Finally
            myConnection.Close()
        End Try


        If successBoolean Then
            ''this displays the new record in the dropdownlist
            characterDropDownList.DataBind()
            ''this displays the new record's information
            'Dim position As Integer = 0
            'For index As Integer = 0 To characterDropDownList.Items.Count - 1
            '    If characterDropDownList.Items(index).Value = 0 Then
            '        position = index
            '    End If
            '    characterDropDownList.SelectedIndex = position
            'Next

            characterLabel.Text = "Yay! Your character has been added to our database"
            characterImageButton.ImageUrl = "images\playerTwo.png"

        End If
        nameTextBox.Text = ""
        alterEgoTextBox.Text = ""
        superPowersTextBox.Text = ""
        publisherTextBox.Text = ""
        alignmentTextBox.Text = ""
    End Sub

End Class
