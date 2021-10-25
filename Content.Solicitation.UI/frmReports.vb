Imports Content.Solicitation.Primitives
Imports Content.Solicitation.Controllers
Imports Content.Solicitation.Adapters
Public Class frmReports
#Region "Members"
    Private mController_Scraper As Controller_Scraper
#End Region
#Region "Initialization"
    Public Sub New()
        InitializeComponent()
        Initialize_Form()
    End Sub
    Private Sub Initialize_Form()
        mController_Scraper = New Controller_Scraper
        Initialize_Combobox_Website()
    End Sub
    Private Sub Initialize_Combobox_Website()
        cboWebsite.Items.Clear()
        With cboWebsite
            For Each item In System.Enum.GetValues(GetType(Websites))

                If item <> Websites.unspecified Then
                    .Items.Add(item)
                End If
            Next
            .SelectedIndex = 0
        End With
    End Sub
#End Region

#Region "Form Events"
    Private Sub LoadReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadReportsToolStripMenuItem.Click
        Scrape_Reports()
    End Sub
#End Region
#Region "Methods"
    Public Sub Scrape_Reports()
        mController_Scraper.Scrape_Reports()
    End Sub
#End Region

End Class