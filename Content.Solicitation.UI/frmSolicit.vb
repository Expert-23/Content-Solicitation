Public Class frmSolicit

    Private mPicture As Bitmap
    Public Sub New(pict As Bitmap)
        InitializeComponent()
        pictBoxSolicit.Image = pict
    End Sub

End Class