<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkStationBuild
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LOADToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAVEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboWebsite = New System.Windows.Forms.ToolStripComboBox()
        Me.WebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuildEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnippetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaunchCampaignToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.DGV_Snippet = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DGV_Snippet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.LOADToolStripMenuItem, Me.WIPToolStripMenuItem, Me.cboWebsite, Me.WebsiteToolStripMenuItem, Me.BuildEmailToolStripMenuItem, Me.SnippetToolStripMenuItem, Me.LaunchCampaignToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1350, 37)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(55, 33)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LOADToolStripMenuItem
        '
        Me.LOADToolStripMenuItem.Name = "LOADToolStripMenuItem"
        Me.LOADToolStripMenuItem.Size = New System.Drawing.Size(94, 33)
        Me.LOADToolStripMenuItem.Text = "Refresh"
        '
        'WIPToolStripMenuItem
        '
        Me.WIPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem1, Me.SAVEToolStripMenuItem})
        Me.WIPToolStripMenuItem.Name = "WIPToolStripMenuItem"
        Me.WIPToolStripMenuItem.Size = New System.Drawing.Size(57, 33)
        Me.WIPToolStripMenuItem.Text = "WIP"
        '
        'LoadToolStripMenuItem1
        '
        Me.LoadToolStripMenuItem1.Name = "LoadToolStripMenuItem1"
        Me.LoadToolStripMenuItem1.Size = New System.Drawing.Size(127, 26)
        Me.LoadToolStripMenuItem1.Text = "Load"
        '
        'SAVEToolStripMenuItem
        '
        Me.SAVEToolStripMenuItem.Name = "SAVEToolStripMenuItem"
        Me.SAVEToolStripMenuItem.Size = New System.Drawing.Size(127, 26)
        Me.SAVEToolStripMenuItem.Text = "Save"
        '
        'cboWebsite
        '
        Me.cboWebsite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cboWebsite.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboWebsite.Name = "cboWebsite"
        Me.cboWebsite.Size = New System.Drawing.Size(121, 33)
        '
        'WebsiteToolStripMenuItem
        '
        Me.WebsiteToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem"
        Me.WebsiteToolStripMenuItem.Size = New System.Drawing.Size(107, 33)
        Me.WebsiteToolStripMenuItem.Text = "Website: "
        '
        'BuildEmailToolStripMenuItem
        '
        Me.BuildEmailToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.EditToolStripMenuItem1})
        Me.BuildEmailToolStripMenuItem.Name = "BuildEmailToolStripMenuItem"
        Me.BuildEmailToolStripMenuItem.Size = New System.Drawing.Size(73, 33)
        Me.BuildEmailToolStripMenuItem.Text = "Email"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(119, 26)
        Me.EditToolStripMenuItem.Text = "New"
        '
        'EditToolStripMenuItem1
        '
        Me.EditToolStripMenuItem1.Name = "EditToolStripMenuItem1"
        Me.EditToolStripMenuItem1.Size = New System.Drawing.Size(119, 26)
        Me.EditToolStripMenuItem1.Text = "Edit"
        '
        'SnippetToolStripMenuItem
        '
        Me.SnippetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem2})
        Me.SnippetToolStripMenuItem.Name = "SnippetToolStripMenuItem"
        Me.SnippetToolStripMenuItem.Size = New System.Drawing.Size(93, 33)
        Me.SnippetToolStripMenuItem.Text = "Snippet"
        '
        'EditToolStripMenuItem2
        '
        Me.EditToolStripMenuItem2.Name = "EditToolStripMenuItem2"
        Me.EditToolStripMenuItem2.Size = New System.Drawing.Size(116, 26)
        Me.EditToolStripMenuItem2.Text = "Edit"
        '
        'LaunchCampaignToolStripMenuItem
        '
        Me.LaunchCampaignToolStripMenuItem.Name = "LaunchCampaignToolStripMenuItem"
        Me.LaunchCampaignToolStripMenuItem.Size = New System.Drawing.Size(191, 33)
        Me.LaunchCampaignToolStripMenuItem.Text = "Launch Campaign"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1350, 729)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1350, 692)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1344, 677)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(70, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1203, 332)
        Me.Panel3.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1197, 325)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Snippet"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1197, 325)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Snippet"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.DGV_Snippet, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 23)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1185, 285)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'DGV_Snippet
        '
        Me.DGV_Snippet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Snippet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGV_Snippet.Location = New System.Drawing.Point(3, 3)
        Me.DGV_Snippet.Name = "DGV_Snippet"
        Me.DGV_Snippet.Size = New System.Drawing.Size(1179, 279)
        Me.DGV_Snippet.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ComboBox1, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 23)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1185, 296)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(3, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(1179, 31)
        Me.ComboBox1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TableLayoutPanel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(70, 341)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1203, 333)
        Me.Panel4.TabIndex = 2
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.GroupBox4, 0, 0)
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 530.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1197, 317)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Narrow", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1191, 311)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Email"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.DataGridView2, 0, 0)
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(6, 28)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 277.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(1179, 277)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(1173, 271)
        Me.DataGridView2.TabIndex = 1
        '
        'frmWorkStationBuild
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmWorkStationBuild"
        Me.Text = "frmWorkStationBuild"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.DGV_Snippet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOADToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WIPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SAVEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cboWebsite As ToolStripComboBox
    Friend WithEvents WebsiteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BuildEmailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SnippetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents LaunchCampaignToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents DGV_Snippet As DataGridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents DataGridView2 As DataGridView
End Class
