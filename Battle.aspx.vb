Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports System.Data
Partial Class Battle
    Inherits System.Web.UI.Page

    Private connectionString As String = WebConfigurationManager.ConnectionStrings("Characters").ConnectionString
    Private picker As New Random



    Private Sub Battle_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            playerOneImage.ImageUrl = "images\playerOne.png"
            playerTwoImage.ImageUrl = "images\playerTwo.png"

            playerOneDropDownList.DataBind()
            playerOneDropDownList.SelectedIndex = -1

            playerTwoDropDownList.DataBind()
            playerTwoDropDownList.SelectedIndex = -1

            Dim battleCookie As HttpCookie = Request.Cookies("LastBattle")

        End If

            winnerLabel.Text = " "

        checkCookie("winner")
        checkCookie("loser")

        displayWinner("winner")
        displayLoser("loser")

    End Sub

    Protected Sub playerOneDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles playerOneDropDownList.SelectedIndexChanged
        Dim selectSQL As String = "SELECT image, name FROM characters WHERE character_id='" & playerOneDropDownList.SelectedValue & "'"
        Dim myConnection As New SqlConnection(connectionString)
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim charactersDataSet As New DataSet


        myConnection.Open()
        myAdapter.Fill(charactersDataSet, "myCharacters")
        Dim characterRow As DataRow = charactersDataSet.Tables("myCharacters").Rows(0)


        playerOneImage.ImageUrl = characterRow("image")


    End Sub


    Protected Sub playerTwoDropDownList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles playerTwoDropDownList.SelectedIndexChanged
        Dim selectSQL As String = "SELECT image, name FROM characters WHERE character_id='" & playerTwoDropDownList.SelectedValue & "'"
        Dim myConnection As New SqlConnection(connectionString)
        Dim myCommand As New SqlCommand(selectSQL, myConnection)
        Dim myAdapter As New SqlDataAdapter(myCommand)
        Dim charactersDataSet As New DataSet


        myConnection.Open()
        myAdapter.Fill(charactersDataSet, "myCharacters")
        Dim characterRow As DataRow = charactersDataSet.Tables("myCharacters").Rows(0)


        playerTwoImage.ImageUrl = characterRow("image")

    End Sub

    Private Sub battle(ByVal one As DropDownList, ByVal two As DropDownList)
        Dim firstRandom As Integer
        firstRandom = picker.Next(0, 100)

        Dim secondRandom As Integer
        secondRandom = picker.Next(0, 100)

        Dim battleCookie As HttpCookie = Request.Cookies("LastBattle")

        If firstRandom > secondRandom Then
            winnerLabel.Text = one.SelectedItem.ToString & " Wins!"
            modifyCookie("winner", one.SelectedItem.ToString)
            modifyCookie("loser", two.SelectedItem.ToString)
        ElseIf secondRandom > firstRandom Then
            winnerLabel.Text = two.SelectedItem.ToString & " Wins!"
            modifyCookie("winner", two.SelectedItem.ToString)
            modifyCookie("loser", one.SelectedItem.ToString)
        Else
            winnerLabel.Text = "It's a tie!"
        End If


    End Sub

    Protected Sub battleButton_Click(sender As Object, e As EventArgs) Handles battleButton.Click
        battle(playerOneDropDownList, playerTwoDropDownList)

        If playerOneImage.ImageUrl = "images\playerOne.png" Or playerTwoImage.ImageUrl = "images\playerTwo.png" Then
            winnerLabel.Text = "Please select a character first"
        End If

    End Sub

    Private Sub checkCookie(ByVal cookieName As String)
        Dim battleCookie As HttpCookie = Request.Cookies(cookieName)
        If battleCookie Is Nothing Then
            battleCookie = New HttpCookie(cookieName)
            battleCookie.Value = 0
            battleCookie.Expires = DateAndTime.Now.AddDays(5)
            Response.Cookies.Add(battleCookie)
        End If
    End Sub

    Private Sub modifyCookie(ByVal cookieName As String, ByVal value As String)
        Dim battleCookie As HttpCookie = Request.Cookies(cookieName)
        battleCookie.Value = value
        battleCookie.Expires = DateAndTime.Now.AddDays(5)
        Response.Cookies.Add(battleCookie)
    End Sub

    Private Sub displayWinner(ByVal winnerCookieName As String)
        Dim battleCookie As HttpCookie = Request.Cookies(winnerCookieName)
        lastWinnerLabel.Text = battleCookie.Value & " was the last winner!"
    End Sub

    Private Sub displayLoser(ByVal loserCookie As String)
        Dim battleCookie As HttpCookie = Request.Cookies(loserCookie)
        lastLoserLabel.Text = battleCookie.Value & " was the last loser!"
    End Sub
End Class
