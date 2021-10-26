<Serializable>
Public Class Solicitation_Message_Combo
    Public Solicit As Job_Solicitation
    Public Message As Message
    Public Sub New()
        Solicit = New Job_Solicitation
        Message = New Message
    End Sub
    Public Overrides Function ToString() As String
        Return String.Empty
    End Function
End Class
