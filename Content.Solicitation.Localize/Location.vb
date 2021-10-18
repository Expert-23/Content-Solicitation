Imports System.IO.Directory
Public Module Locations

    Public Class Root

        Public Shared Function Directory() As String
            Dim rootpath As String = GetParent(
                       GetParent(
                       GetParent(
                       GetParent(
                       My.Application.Info.DirectoryPath).ToString).ToString).ToString).ToString
            Return rootpath

        End Function

    End Class

    Public Class Cache

        Private Shared mDirectory As String = "z_cache"
        Public Shared Function Directory() As String

            Return Root.Directory.TrimEnd("\") & "\" & mDirectory

        End Function

    End Class



    Public Class Images

        Private Shared mDirectory As String = "images"
        Public Shared Function Directory() As String

            Return Cache.Directory.TrimEnd("\") & "\" & mDirectory

        End Function

        Private Shared mFIlename_Base As String = "image_"
        Public Shared mFormat As String = "png"

        Public Shared Function Filename(ByVal modifier As String) As String
            Return String.Format("{0}{1}", mFIlename_Base, modifier)
        End Function
        Public Shared Function Filepath(ByVal modifier As String) As String
            Return String.Format("{0}\{1}.{2}", Directory.TrimEnd("\"), Filename(modifier), mFormat)
        End Function

    End Class

    Public Class Testing


        Private Shared mDirectory As String = "test"
        Public Shared Function Directory() As String

            Return Cache.Directory.TrimEnd("\") & "\" & mDirectory

        End Function


        Private Shared mFilemame_Content As String = "scrape_content.bin"
        Private Shared mFilemame_Content2 As String = "scrape_content_Test_OLD_VERSION.bin"
        Public Shared Filepath_Content As String = Directory() & "\" & mFilemame_Content
        Public Shared Filepath_Content_test As String = Directory() & "\" & mFilemame_Content2

    End Class

    Public Class Solicitation
        Private Shared mDirectory As String = "solicitation"

        Public Shared Function Directory() As String

            Return Cache.Directory.TrimEnd("\") & "\" & mDirectory

        End Function



    End Class

    Public Class Work_In_Progress

        Private Shared mDirectory As String = "wip"
        Public Shared Function Directory() As String
            Console.WriteLine(Cache.Directory)
            Return Cache.Directory.TrimEnd("\") & "\" & mDirectory

        End Function

    End Class

End Module
