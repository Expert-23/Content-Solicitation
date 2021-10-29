Imports System.Drawing.Text
Imports System.IO
Imports System.Text
Imports System.Windows.Documents
Imports Content.Primitives
Public Class frmTxtEditor
    Public Message_Job As Message_Job
#Region "Editor and Timer"
    Private Sub TextEditor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        For fntSize = 10 To 75
            tbSelectSize.Items.Add(fntSize)
        Next

        Dim fonts As New InstalledFontCollection()
        For fntFamily As Integer = 0 To fonts.Families.Length - 1
            tbSelectFont.Items.Add(fonts.Families(fntFamily).Name)
        Next
        If Message_Job.Message.Email IsNot Nothing Then

            If Message_Job.Message.Email.File_Dir <> "" Then

            End If
            Document.LoadFile(Message_Job.Message.Email.File_Dir,
                         RichTextBoxStreamType.RichText)
        Else
            Message_Job.Message.Email = New Email_Format
            Document.Text = Message_Job.Message.Original.Body_Text
        End If

        '-----------------------------
        'If Message_Job.Email_Format.document IsNot Nothing Then
        '    If Message_Job.Email_Format.Logo_Selection <> "" Then
        '        Clipboard.SetImage(My.Resources.R23_Logo)
        '        Document.SelectionStart = 234
        '        'Document.SelectionStart = Convert.ToInt32(Message_Job.Email_Format.Logo_Selection)

        '        Document.Paste()
        '    End If

        '    If Message_Job.Email_Format.Snippet_Selection <> "" Then
        '        Clipboard.SetImage(Message_Job.Job.Snippet)
        '        Dim x = Convert.ToInt32(Message_Job.Email_Format.Snippet_Selection)
        '        Document.SelectionStart = Convert.ToInt32(Message_Job.Email_Format.Snippet_Selection)
        '        Document.Paste()
        '    End If
        'Else
        '    Document.Text = Message_Job.Message.Original.Body_Text
        'End If

    End Sub

    Private Sub Timer_Tick(sender As System.Object, e As System.EventArgs) Handles Timer.Tick
        lblCharCount.Text = "Characters in the current document: " & Document.TextLength.ToString()


        lblZoom.Text = Document.ZoomFactor.ToString()



    End Sub


    Private Sub Document_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles Document.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub


#End Region


#Region "Main Menu Bar"
    Private Sub mMNew_Click(sender As System.Object, e As System.EventArgs)
        NewDocument()
    End Sub

    Private Sub mMOpen_Click(sender As System.Object, e As System.EventArgs)
        Open()
    End Sub

    Private Sub mMSave_Click(sender As System.Object, e As System.EventArgs)
        Save()
    End Sub

    Private Sub mMExit_Click(sender As System.Object, e As System.EventArgs)
        ExitApplication()
    End Sub



    '----------------------------

    Private Sub mMUndo_Click(sender As System.Object, e As System.EventArgs)
        Undo()
    End Sub

    Private Sub mMRedo_Click(sender As System.Object, e As System.EventArgs)
        Redo()
    End Sub

    Private Sub mMCut_Click(sender As System.Object, e As System.EventArgs)
        Cut()
    End Sub

    Private Sub mMCopy_Click(sender As System.Object, e As System.EventArgs)
        Copy()
    End Sub

    Private Sub mMPaste_Click(sender As System.Object, e As System.EventArgs)
        Paste()
    End Sub

    Private Sub mMSelectAll_Click(sender As System.Object, e As System.EventArgs)
        SelectAll()
    End Sub

    '-----------------------

    Private Sub mMCustomize_Click(sender As System.Object, e As System.EventArgs)
        Customize()
    End Sub

#End Region


#Region "Toolbar"


    Private Sub tbNew_Click(sender As System.Object, e As System.EventArgs)
        NewDocument()
    End Sub

    Private Sub tbOpen_Click(sender As System.Object, e As System.EventArgs)
        Open()
    End Sub

    Private Sub tbSave_Click(sender As System.Object, e As System.EventArgs)
        Save()
    End Sub

    Private Sub tbCut_Click(sender As System.Object, e As System.EventArgs)
        Cut()
    End Sub

    Private Sub tbCopy_Click(sender As System.Object, e As System.EventArgs)
        Copy()
    End Sub

    Private Sub tbPaste_Click(sender As System.Object, e As System.EventArgs)
        Paste()
    End Sub


    '---------------------------------

    Private Sub tbBold_Click(sender As System.Object, e As System.EventArgs) Handles tbBold.Click
        Dim bfont As New Font(Document.Font, FontStyle.Bold)
        Dim rfont As New Font(Document.Font, FontStyle.Regular)

        If Document.SelectedText.Length = 0 Then Exit Sub
        If Document.SelectionFont.Bold Then
            Document.SelectionFont = rfont
        Else
            Document.SelectionFont = bfont
        End If

    End Sub

    Private Sub tbItalic_Click(sender As System.Object, e As System.EventArgs) Handles tbItalic.Click

        Dim Ifont As New Font(Document.Font, FontStyle.Italic)
        Dim rfont As New Font(Document.Font, FontStyle.Regular)

        If Document.SelectedText.Length = 0 Then Exit Sub
        If Document.SelectionFont.Italic Then
            Document.SelectionFont = rfont
        Else
            Document.SelectionFont = Ifont
        End If
    End Sub

    Private Sub tbUnderline_Click(sender As System.Object, e As System.EventArgs) Handles tbUnderline.Click

        Dim Ufont As New Font(Document.Font, FontStyle.Underline)
        Dim rfont As New Font(Document.Font, FontStyle.Regular)

        If Document.SelectedText.Length = 0 Then Exit Sub
        If Document.SelectionFont.Underline Then
            Document.SelectionFont = rfont
        Else
            Document.SelectionFont = Ufont
        End If
    End Sub

    Private Sub tbStrike_Click(sender As System.Object, e As System.EventArgs) Handles tbStrike.Click
        Dim Sfont As New Font(Document.Font, FontStyle.Strikeout)
        Dim rfont As New Font(Document.Font, FontStyle.Regular)


        If Document.SelectedText.Length = 0 Then Exit Sub
        If Document.SelectionFont.Strikeout Then
            Document.SelectionFont = rfont
        Else
            Document.SelectionFont = Sfont
        End If
    End Sub

    ' -------------------------------


    Private Sub tbAlignLeft_Click(sender As System.Object, e As System.EventArgs) Handles tbAlignLeft.Click
        Document.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub tbAlignCentre_Click(sender As System.Object, e As System.EventArgs) Handles tbAlignCentre.Click
        Document.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub tbAlignRight_Click(sender As System.Object, e As System.EventArgs) Handles tbAlignRight.Click
        Document.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    '----------------------------------------------

    Private Sub tbUpper_Click(sender As System.Object, e As System.EventArgs) Handles tbUpper.Click
        Document.SelectedText = Document.SelectedText.ToUpper()
    End Sub

    Private Sub tbLower_Click(sender As System.Object, e As System.EventArgs) Handles tbLower.Click
        Document.SelectedText = Document.SelectedText.ToLower()
    End Sub

    '---------------------------------------


    Private Sub tbZoom_Click(sender As System.Object, e As System.EventArgs) Handles tbZoom.Click
        If Document.ZoomFactor = 63 Then

            Exit Sub
        Else

            Document.ZoomFactor = Document.ZoomFactor + 1
        End If


    End Sub

    Private Sub tbZoomOut_Click(sender As System.Object, e As System.EventArgs) Handles tbZoomOut.Click
        If Document.ZoomFactor = 1 Then
            Exit Sub

        Else

            Document.ZoomFactor = Document.ZoomFactor - 1
        End If



    End Sub


    '------------------------------------------

    Private Sub tbSelectFont_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbSelectFont.SelectedIndexChanged
        Dim ComboFonts As System.Drawing.Font

        Try
            ComboFonts = Document.SelectionFont
            Document.SelectionFont = New System.Drawing.Font(tbSelectFont.Text, Document.SelectionFont.Size, Document.SelectionFont.Style)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub tbSelectSize_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbSelectSize.SelectedIndexChanged
        Document.SelectionFont = New Font(tbSelectSize.SelectedItem.ToString, CInt(tbSelectSize.SelectedItem.ToString), Document.SelectionFont.Style)
    End Sub



#End Region


#Region "Methods"

#Region "File"

    'CLEAR THE RICHTEXTBOX - MAKES NEW DOCUMENT
    Private Sub NewDocument()
        Document.Clear()
    End Sub

    'OPEN WORK AS PLAIN TEXT FILE
    Private Sub Open()
        If openWork.ShowDialog = Windows.Forms.DialogResult.OK Then

            Document.LoadFile(openWork.FileName,
                              RichTextBoxStreamType.PlainText)

        End If
    End Sub

    'SAVE WORK AS PLAIN TEXT FILE
    Private Sub Save()
        If saveWork.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Document.SaveFile(saveWork.FileName,
                                  RichTextBoxStreamType.PlainText)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    'EXIT THE PROGRAM
    Private Sub ExitApplication()
        Me.Close()
    End Sub



#End Region

#Region "Edit"

    Private Sub Undo()
        Document.Undo()
    End Sub

    Private Sub Redo()
        Document.Redo()
    End Sub

    Private Sub Cut()
        Document.Cut()
    End Sub

    Private Sub Copy()
        Document.Copy()
    End Sub

    Private Sub Paste()
        Document.Paste()
    End Sub

    Private Sub SelectAll()
        Document.SelectAll()
    End Sub


#End Region

#Region "Tools"

    Private Sub Customize()
        Dim ColorPicker As New ColorDialog()

        ColorPicker.AllowFullOpen = True
        ColorPicker.FullOpen = True
        ColorPicker.AnyColor = True

        If ColorPicker.ShowDialog = Windows.Forms.DialogResult.OK Then
            mainMenu.BackColor = ColorPicker.Color
            Tools.BackColor = ColorPicker.Color
            Status.BackColor = ColorPicker.Color
        End If

    End Sub



#End Region


#End Region


#Region "RightClickMenu"

    Private Sub UndoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        Undo()
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        Redo()
    End Sub

    Private Sub CutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Cut()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Paste()
    End Sub

    Private Sub AddSnippetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddSnippetToolStripMenuItem.Click
        Clipboard.SetImage(Message_Job.Job.Snippet)
        Dim selection As Integer = Document.SelectionStart
        Dim line As Integer = Document.GetLineFromCharIndex(selection)
        Message_Job.Message.Email.Snippet_Position = line.ToString
        Message_Job.Message.Email.Snippet_Selection = selection
        Document.Paste()
    End Sub

    Private Sub AddLogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddLogoToolStripMenuItem.Click
        Clipboard.SetImage(My.Resources.R23_Logo)
        Dim selection As Integer = Document.SelectionStart
        Dim line As Integer = Document.GetLineFromCharIndex(selection)
        Message_Job.Message.Email.Logo_Position = line.ToString
        Message_Job.Message.Email.Logo_Selection = selection
        Document.Paste()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Save_File()
    End Sub
    Private Sub Save_File()

        Message_Job.Message.Email.File_Dir = "C:\Users\pc\source\repos\Expert-23\Content-Solicitation\z-cache\EmailFormat\" & Guid.NewGuid.ToString & ".txt"
        Try
            Message_Job.Message.Email.Font_Family = tbSelectFont.Text
            Message_Job.Message.Email.Font_Size = tbSelectSize.Text
            Document.SaveFile(Message_Job.Message.Email.File_Dir,
                                  RichTextBoxStreamType.RichText)

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region
End Class