<Serializable>
Public Class Message_Job
    Public Job As Job_Solicitation
    Public Message As Message
    Public Image_Bytes As Byte()
    Public Website As Websites

    Public Sub New()
        Job = New Job_Solicitation
        Message = New Message

    End Sub
    Public Overrides Function ToString() As String
        Return Message.Original_Subject.Original & "," & Job.Item_Content.Title
    End Function
End Class
