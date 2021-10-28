<Serializable>
Public Class Solicitation_Message_Combo
    Public Solicit As Job_Solicitation
    Public Message As Message
    Public Image_Bytes As Byte()
    Public Website As Websites
    Public Sub New()
        Solicit = New Job_Solicitation
        Message = New Message
    End Sub
    Public Overrides Function ToString() As String
        Return Message.Original_Subject.Original & "," & Solicit.Item_Content.Title
    End Function
End Class
