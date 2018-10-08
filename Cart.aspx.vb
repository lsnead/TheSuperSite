Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports EASendMailSvcObjLib
Imports System.Web.Mail
Imports System.Net.Mail.SmtpClient
Imports System.Net.Mail
Imports System.Web.Configuration

Partial Class Cart
    Inherits System.Web.UI.Page
    Dim dr As DataRow
    Private connectionString As String = WebConfigurationManager.ConnectionStrings("Characters").ConnectionString




    Protected Sub submitButton_Click(sender As Object, e As EventArgs) Handles submitButton.Click
        Dim selectSQL As String = "SELECT customer_name FROM customer"
        Dim myConnection As New SqlConnection(connectionString)
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim customerDataSet As New DataSet

        Try
            myConnection.Open()
            myAdapter.Fill(customerDataSet, "myCustomer")
            Dim customerRow As DataRow = customerDataSet.Tables("myCustomer").Rows(0)

            If nameTextBox.Text = customerRow("customer_name").Trim Then
                saveOrderInfo()

                sendEmail()


                messageLabel.Text = "Order Placed"

                subtractQuantity()
            Else
                messageLabel.Text = "Oops! You don't have an account with us yet. Go to our Home page to create one!"
                nameTextBox.Text = ""
                addressTextBox.Text = ""
                cityTextBox.Text = ""
                stateTextBox.Text = ""
                zipcodeTextBox.Text = ""
                emailTextBox.Text = ""
                creditCardTextBox.Text = ""
            End If

        Catch ex As Exception
            messageLabel.Text = ex.Message
        End Try



    End Sub

    Private Sub Cart_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("Cart") Is Nothing Then
                Dim dt As DataTable = CType(Session("Cart"), DataTable)
                otherGridView.DataSource = dt
                otherGridView.DataBind()
                totalLabel.Text = "$" & GetItemTotal()
            End If

        End If


    End Sub


    Function GetItemTotal() As Decimal
        Dim dt As DataTable = CType(Session("Cart"), DataTable)
        Dim index As Integer
        Dim decRunningTotal As Decimal

        For index = 0 To dt.Rows.Count - 1
            dr = dt.Rows(index)
            decRunningTotal += (dr("Cost") * dr("Quantity"))
        Next

        Return decRunningTotal
    End Function

    Function getOrderQuantity() As Integer
        Dim dt As DataTable = CType(Session("Cart"), DataTable)
        Dim index As Integer
        Dim orderQuantity As Integer

        For index = 0 To dt.Rows.Count - 1
            dr = dt.Rows(index)
            orderQuantity += (dr("Quantity") * dt.Rows.Count)
        Next

        Return orderQuantity
    End Function


    Public Sub otherGridView_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles otherGridView.RowDeleting

        Try
            Dim index As Integer = Convert.ToInt32(e.RowIndex)
            Dim dt As DataTable = CType(Session("Cart"), DataTable)
            dt.Rows(index).Delete()
            Session("Cart") = dt

            otherGridView.DataSource = dt
            otherGridView.DataBind()

            totalLabel.Text = "$" & GetItemTotal()
            messageLabel.Text = "Item deleted"
        Catch ex As Exception
            messageLabel.Text = ex.Message
        End Try


    End Sub

    Private Sub otherGridView_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles otherGridView.RowCommand
        If (e.CommandName = "Add") Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString)
            Dim dt As DataTable = CType(Session("Cart"), DataTable)
            dr = dt.Rows(index)
            Session("Cart") = dt

            dr("Quantity") += 1

            otherGridView.DataSource = dt
            otherGridView.DataBind()

            totalLabel.Text = "$" & GetItemTotal()

        End If

        If (e.CommandName = "Subtract") Then

            Dim index As Integer = Convert.ToInt32(e.CommandArgument.ToString)
            Dim dt As DataTable = CType(Session("Cart"), DataTable)
            dr = dt.Rows(index)
            Session("Cart") = dt

            dr("Quantity") -= 1

            otherGridView.DataSource = dt
            otherGridView.DataBind()

            totalLabel.Text = "$" & GetItemTotal()

        End If
    End Sub

    Private Sub saveOrderInfo()
        Dim connectionString As String = WebConfigurationManager.ConnectionStrings("Characters").ConnectionString

        Dim insertSQL As New StringBuilder
        With insertSQL
            .Append("INSERT INTO theOrder (product_id, order_quantity, customer_name)")
            .Append("VALUES (@product_id, @order_quantity, @customer_name)")
        End With

        Dim dt As DataTable = CType(Session("Cart"), DataTable)
        Dim index As Integer


        Dim successBoolean As Boolean
        Dim myConnection As New SqlConnection(connectionString)
        Try
            myConnection.Open()
            myConnection.ConnectionString = connectionString
            Dim myCommand As New SqlCommand(insertSQL.ToString, myConnection)
            With myCommand.Parameters

                For index = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(index)
                    .AddWithValue("@product_id", dr("ID"))
                Next

                .AddWithValue("order_quantity", getOrderQuantity())
                .AddWithValue("customer_name", nameTextBox.Text)
            End With

            myCommand.ExecuteNonQuery()

        Catch ex As Exception
            successBoolean = False
            messageLabel.Text = "order" & ex.Message
        Finally
            myConnection.Close()
        End Try
    End Sub

    Private Sub subtractQuantity()
        Dim index As Integer
        Dim dt As DataTable = CType(Session("Cart"), DataTable)
        dr = dt.Rows(index)

        Dim updateSQL As New StringBuilder
        With updateSQL
            .Append("UPDATE products SET ")
            .Append("quantity= quantity - 1 ")
            .Append(" WHERE product_id=@product_id")
        End With
        Dim successBoolean As Boolean = True
        Dim myConnection As New SqlConnection()
        myConnection.ConnectionString = connectionString
        Try
            myConnection.Open()
            '   myConnection.ConnectionString = connectionString
            Dim myCommand As New SqlCommand(updateSQL.ToString, myConnection)

            With myCommand.Parameters
                .AddWithValue("@product_id", dr("ID"))
            End With

            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            messageLabel.Text = ex.Message
        Finally
            myConnection.Close()
        End Try

    End Sub

    Private Sub sendEmail()
        Dim orderConfirmation As New Net.Mail.MailMessage()
        Try

            orderConfirmation.From = New MailAddress("thesupersitejcu@gmail.com")
            orderConfirmation.To.Add(New MailAddress(emailTextBox.Text))
            orderConfirmation.Subject = "The Super Site: Order Confirmation"
            orderConfirmation.Body = "Hi " & nameTextBox.Text & ", thank you for your order! Your order will be sent to " _
                & addressTextBox.Text & ", " & cityTextBox.Text & ", " & stateTextBox.Text & " " & zipcodeTextBox.Text _
                & ". Please contact thesupersitejcu@gmail.com if you have any questions about your order. Have a great day!"

            Dim SMTP As New SmtpClient("smtp.gmail.com")
            SMTP.Port = 587
            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("thesupersitejcu@gmail.com", "CatWoman123%")
            SMTP.Send(orderConfirmation)
        Catch ex As Exception
            messageLabel.Text = "email" & ex.Message
        End Try
    End Sub
End Class
