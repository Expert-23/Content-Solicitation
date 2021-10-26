Imports Content.Solicitation.Primitives
Public Class frmWorkStationBuild

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Initialize()

    End Sub
    Private Sub Map_DGV()

    End Sub
    Private Sub Map_DGV_Email()
        DGV_Snippet.ColumnCount = 3
        DGV_Snippet.Columns(0).Name = "Product ID"
        DGV_Snippet.Columns(1).Name = "Product Name"
        DGV_Snippet.Columns(2).Name = "Product_Price"

        Dim row As String() = New String() {"1", "Product 1", "1000"}
        DGV_Snippet.Rows.Add(row)
        row = New String() {"2", "Product 2", "2000"}
        DGV_Snippet.Rows.Add(row)
        row = New String() {"3", "Product 3", "3000"}
        DGV_Snippet.Rows.Add(row)
        row = New String() {"4", "Product 4", "4000"}
        DGV_Snippet.Rows.Add(row)
    End Sub
    Private Sub Map_DGV_Content_Solicit()

    End Sub


End Class