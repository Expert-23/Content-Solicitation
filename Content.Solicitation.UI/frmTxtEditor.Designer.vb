<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTxtEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTxtEditor))
        Me.openWork = New System.Windows.Forms.OpenFileDialog()
        Me.tbUnderline = New System.Windows.Forms.ToolStripButton()
        Me.tbStrike = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbAlignLeft = New System.Windows.Forms.ToolStripButton()
        Me.tbAlignCentre = New System.Windows.Forms.ToolStripButton()
        Me.tbAlignRight = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbUpper = New System.Windows.Forms.ToolStripButton()
        Me.tbLower = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbZoom = New System.Windows.Forms.ToolStripButton()
        Me.tbZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.tbItalic = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbSelectSize = New System.Windows.Forms.ToolStripComboBox()
        Me.Status = New System.Windows.Forms.StatusStrip()
        Me.lblCharCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblZoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.rcMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.saveWork = New System.Windows.Forms.SaveFileDialog()
        Me.tbSelectFont = New System.Windows.Forms.ToolStripComboBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.tbBold = New System.Windows.Forms.ToolStripButton()
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.AddSnippetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddLogoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tools = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Document = New System.Windows.Forms.RichTextBox()
        Me.Status.SuspendLayout()
        Me.rcMenu.SuspendLayout()
        Me.mainMenu.SuspendLayout()
        Me.Tools.SuspendLayout()
        Me.SuspendLayout()
        '
        'openWork
        '
        Me.openWork.Filter = "Text Files |*.txt|RTF Files|*.rtf"
        Me.openWork.Title = "Open Work"
        '
        'tbUnderline
        '
        Me.tbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbUnderline.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUnderline.Image = CType(resources.GetObject("tbUnderline.Image"), System.Drawing.Image)
        Me.tbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbUnderline.Name = "tbUnderline"
        Me.tbUnderline.Size = New System.Drawing.Size(23, 22)
        Me.tbUnderline.Text = "U"
        '
        'tbStrike
        '
        Me.tbStrike.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbStrike.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStrike.Image = CType(resources.GetObject("tbStrike.Image"), System.Drawing.Image)
        Me.tbStrike.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbStrike.Name = "tbStrike"
        Me.tbStrike.Size = New System.Drawing.Size(23, 22)
        Me.tbStrike.Text = "S"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tbAlignLeft
        '
        Me.tbAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbAlignLeft.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAlignLeft.Image = CType(resources.GetObject("tbAlignLeft.Image"), System.Drawing.Image)
        Me.tbAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbAlignLeft.Name = "tbAlignLeft"
        Me.tbAlignLeft.Size = New System.Drawing.Size(23, 22)
        Me.tbAlignLeft.Text = "L"
        Me.tbAlignLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbAlignCentre
        '
        Me.tbAlignCentre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbAlignCentre.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAlignCentre.Image = CType(resources.GetObject("tbAlignCentre.Image"), System.Drawing.Image)
        Me.tbAlignCentre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbAlignCentre.Name = "tbAlignCentre"
        Me.tbAlignCentre.Size = New System.Drawing.Size(23, 22)
        Me.tbAlignCentre.Text = "C"
        '
        'tbAlignRight
        '
        Me.tbAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbAlignRight.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAlignRight.Image = CType(resources.GetObject("tbAlignRight.Image"), System.Drawing.Image)
        Me.tbAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbAlignRight.Name = "tbAlignRight"
        Me.tbAlignRight.Size = New System.Drawing.Size(23, 22)
        Me.tbAlignRight.Text = "R"
        Me.tbAlignRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tbUpper
        '
        Me.tbUpper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbUpper.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUpper.Image = CType(resources.GetObject("tbUpper.Image"), System.Drawing.Image)
        Me.tbUpper.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbUpper.Name = "tbUpper"
        Me.tbUpper.Size = New System.Drawing.Size(23, 22)
        Me.tbUpper.Text = "A"
        '
        'tbLower
        '
        Me.tbLower.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbLower.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLower.Image = CType(resources.GetObject("tbLower.Image"), System.Drawing.Image)
        Me.tbLower.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbLower.Name = "tbLower"
        Me.tbLower.Size = New System.Drawing.Size(23, 22)
        Me.tbLower.Text = "a"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tbZoom
        '
        Me.tbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbZoom.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.tbZoom.Image = CType(resources.GetObject("tbZoom.Image"), System.Drawing.Image)
        Me.tbZoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbZoom.Name = "tbZoom"
        Me.tbZoom.Size = New System.Drawing.Size(23, 22)
        Me.tbZoom.Text = "+"
        '
        'tbZoomOut
        '
        Me.tbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbZoomOut.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!)
        Me.tbZoomOut.Image = CType(resources.GetObject("tbZoomOut.Image"), System.Drawing.Image)
        Me.tbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbZoomOut.Name = "tbZoomOut"
        Me.tbZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.tbZoomOut.Text = "-"
        '
        'tbItalic
        '
        Me.tbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbItalic.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbItalic.Image = CType(resources.GetObject("tbItalic.Image"), System.Drawing.Image)
        Me.tbItalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbItalic.Name = "tbItalic"
        Me.tbItalic.Size = New System.Drawing.Size(23, 22)
        Me.tbItalic.Text = "I"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'tbSelectSize
        '
        Me.tbSelectSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tbSelectSize.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tbSelectSize.Name = "tbSelectSize"
        Me.tbSelectSize.Size = New System.Drawing.Size(80, 25)
        '
        'Status
        '
        Me.Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblCharCount, Me.ToolStripStatusLabel2, Me.lblZoom})
        Me.Status.Location = New System.Drawing.Point(0, 430)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(787, 22)
        Me.Status.TabIndex = 6
        Me.Status.Text = "StatusStrip1"
        '
        'lblCharCount
        '
        Me.lblCharCount.Name = "lblCharCount"
        Me.lblCharCount.Size = New System.Drawing.Size(13, 17)
        Me.lblCharCount.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(720, 17)
        Me.ToolStripStatusLabel2.Spring = True
        '
        'lblZoom
        '
        Me.lblZoom.Name = "lblZoom"
        Me.lblZoom.Size = New System.Drawing.Size(39, 17)
        Me.lblZoom.Text = "Zoom"
        '
        'rcMenu
        '
        Me.rcMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.rcMenu.Name = "rcMenu"
        Me.rcMenu.Size = New System.Drawing.Size(104, 114)
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'saveWork
        '
        Me.saveWork.Filter = "Text Files |*.txt|RTF Files|*.rtf"
        Me.saveWork.Title = "Save Work"
        '
        'tbSelectFont
        '
        Me.tbSelectFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tbSelectFont.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tbSelectFont.Name = "tbSelectFont"
        Me.tbSelectFont.Size = New System.Drawing.Size(180, 25)
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 1
        '
        'tbBold
        '
        Me.tbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tbBold.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBold.Image = CType(resources.GetObject("tbBold.Image"), System.Drawing.Image)
        Me.tbBold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbBold.Name = "tbBold"
        Me.tbBold.Size = New System.Drawing.Size(23, 22)
        Me.tbBold.Text = "B"
        '
        'mainMenu
        '
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddSnippetToolStripMenuItem, Me.AddLogoToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 25)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(787, 24)
        Me.mainMenu.TabIndex = 4
        Me.mainMenu.Text = "MenuStrip1"
        '
        'AddSnippetToolStripMenuItem
        '
        Me.AddSnippetToolStripMenuItem.Name = "AddSnippetToolStripMenuItem"
        Me.AddSnippetToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.AddSnippetToolStripMenuItem.Text = "Add Snippet"
        '
        'AddLogoToolStripMenuItem
        '
        Me.AddLogoToolStripMenuItem.Name = "AddLogoToolStripMenuItem"
        Me.AddLogoToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.AddLogoToolStripMenuItem.Text = "Add Logo"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Tools
        '
        Me.Tools.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator1, Me.toolStripSeparator5, Me.tbBold, Me.tbItalic, Me.tbUnderline, Me.tbStrike, Me.ToolStripSeparator6, Me.tbAlignLeft, Me.tbAlignCentre, Me.tbAlignRight, Me.ToolStripSeparator7, Me.tbUpper, Me.tbLower, Me.ToolStripSeparator8, Me.tbZoom, Me.tbZoomOut, Me.ToolStripSeparator9, Me.tbSelectFont, Me.tbSelectSize})
        Me.Tools.Location = New System.Drawing.Point(0, 0)
        Me.Tools.Name = "Tools"
        Me.Tools.Size = New System.Drawing.Size(787, 25)
        Me.Tools.TabIndex = 5
        Me.Tools.Text = "ToolStrip1"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Document
        '
        Me.Document.ContextMenuStrip = Me.rcMenu
        Me.Document.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Document.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.Document.Location = New System.Drawing.Point(0, 49)
        Me.Document.Name = "Document"
        Me.Document.Size = New System.Drawing.Size(787, 403)
        Me.Document.TabIndex = 7
        Me.Document.Text = ""
        '
        'frmTxtEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 452)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Document)
        Me.Controls.Add(Me.mainMenu)
        Me.Controls.Add(Me.Tools)
        Me.Name = "frmTxtEditor"
        Me.Text = "frmTxtEditor"
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        Me.rcMenu.ResumeLayout(False)
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.Tools.ResumeLayout(False)
        Me.Tools.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents openWork As OpenFileDialog
    Friend WithEvents tbUnderline As ToolStripButton
    Friend WithEvents tbStrike As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tbAlignLeft As ToolStripButton
    Friend WithEvents tbAlignCentre As ToolStripButton
    Friend WithEvents tbAlignRight As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tbUpper As ToolStripButton
    Friend WithEvents tbLower As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tbZoom As ToolStripButton
    Friend WithEvents tbZoomOut As ToolStripButton
    Friend WithEvents tbItalic As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents tbSelectSize As ToolStripComboBox
    Friend WithEvents Status As StatusStrip
    Friend WithEvents lblCharCount As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents lblZoom As ToolStripStatusLabel
    Friend WithEvents rcMenu As ContextMenuStrip
    Friend WithEvents UndoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents saveWork As SaveFileDialog
    Friend WithEvents tbSelectFont As ToolStripComboBox
    Friend WithEvents Timer As Timer
    Friend WithEvents tbBold As ToolStripButton
    Friend WithEvents mainMenu As MenuStrip
    Friend WithEvents toolStripSeparator5 As ToolStripSeparator
    Friend WithEvents Tools As ToolStrip
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents AddSnippetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddLogoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Document As RichTextBox
End Class
