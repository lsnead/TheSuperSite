Imports Microsoft.VisualBasic


Public Class CartItem
    Public Product As Product
    Public Quantity As Integer

    Public Sub New(ByVal product As Product, ByVal quantity As Integer)
        Me.Product = product
        Me.Quantity = quantity
    End Sub
    Public Sub AddQuantity(ByVal iAdditionalQuantity As Integer)
        Me.Quantity += iAdditionalQuantity
    End Sub

    Public Function Display() As String

        Return Product.Name + " (" + Quantity.ToString() _
            + " at " + FormatCurrency(Product.UnitPrice) + " each)"
    End Function

End Class
