Imports Microsoft.VisualBasic

Public Class CartItemList



    Private CartItems As List(Of CartItem)

    Public Sub New()
        'Constructor initializes the CartItems field.
        CartItems = New List(Of CartItem)
    End Sub

    Public Property Count As Integer
        'Defines Count property to return a count of items in the list.
        Get
            Return CartItems.Count
        End Get
        Set(value As Integer)
            value = CartItems.Count
        End Set
    End Property

    Default Public Property Item(ByVal index As Integer) As CartItem
        'Get and set a cart item in the list using the index value
        'This property gets the items in the cart for display in the ListBox
        'on the Cart page.
        Get
            Return CartItems(index)
        End Get
        Set(ByVal value As CartItem)
            CartItems(index) = value
        End Set
    End Property

    Default Public Property Item(ByVal id As String) As CartItem
        Get
            For Each c As CartItem In CartItems
                If c.Product.ProductID = id Then
                    Return c
                End If
            Next

            Return Nothing
        End Get

        Set(value As CartItem)
            value.Product.ProductID = id
        End Set
    End Property

    Public Shared Function GetCart() As CartItemList
        If CType(HttpContext.Current.Session("Cart"), CartItemList) Is Nothing Then
            HttpContext.Current.Session.Add("Cart", New CartItemList)
        End If
        Return CType(HttpContext.Current.Session("Cart"), CartItemList)
    End Function

    Public Sub AddItem(ByVal Product As Product, ByVal Quantity As Integer)

        Dim c As New CartItem(Product, Quantity)
        CartItems.Add(c)
    End Sub

    Public Sub removeAt(ByVal index As Integer)

        CartItems.RemoveAt(index)
    End Sub

    Public Sub Clear()

        CartItems.Clear()
    End Sub

End Class
