
Partial Class AdminLogin
    Inherits System.Web.UI.Page
    Private adminUserName As String = "username"
    Private adminPassWord As String = "password"


    Protected Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click
        If usernameTextBox.Text = adminUserName And passwordTextBox.Text = adminPassWord Then
            Response.Redirect("~/Administration.aspx")
        End If
    End Sub
End Class
