
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class _Default
    Inherits System.Web.UI.Page

    Private connectionString As String = WebConfigurationManager.ConnectionStrings("Characters").ConnectionString


    Protected Sub createAccountButton_Click(sender As Object, e As EventArgs) Handles createAccountButton.Click
        Dim insertSQL As New StringBuilder
        With insertSQL
            .Append("INSERT INTO customer (customer_name, street_address, city, state, zipcode, password)")
            .Append("VALUES (@customer_name, @street_address, @city, @state, @zipcode, @password)")
        End With

        Dim successBoolean As Boolean
        Dim myConnection As New SqlConnection()
        Try
            myConnection.Open()
            myConnection.ConnectionString = connectionString
            Dim myCommand As New SqlCommand(insertSQL.ToString, myConnection)
            With myCommand.Parameters

                .AddWithValue("@customer_name", nameTextBox.Text).ToString()
                .AddWithValue("@street_address", addressTextBox.Text).ToString()
                .AddWithValue("@city", cityTextBox.Text).ToString()
                .AddWithValue("@state", stateTextBox.Text).ToString()
                .AddWithValue("@zipcode", zipcodeTextBox.Text).ToString()
                .AddWithValue("@password", passwordTextBox.Text).ToString()
            End With
            myConnection.Open()
            createdLabel.Text = "Account Created. Welcome!"
            successBoolean = myCommand.ExecuteNonQuery
        Catch ex As Exception
            createdLabel.Text = ex.Message
        Finally
            myConnection.Close()
        End Try
    End Sub

End Class
