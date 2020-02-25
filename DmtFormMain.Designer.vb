<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DmtFormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DmtFormMain))
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonGetAttachment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSaveAttachment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSetSkip = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButtonOptions = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemCenterFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemShowToolBar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFitPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFitWidth = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemShowThumbs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemShowSuggestions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelMessages = New System.Windows.Forms.ToolStripLabel()
        Me.ListViewAttachments = New System.Windows.Forms.ListView()
        Me.MailNr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AttachmentName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Status = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListBoxErps = New System.Windows.Forms.ListBox()
        Me.ListBoxCoCds = New System.Windows.Forms.ListBox()
        Me.ListBoxDocumentTypes = New System.Windows.Forms.ListBox()
        Me.txtFolderPath = New System.Windows.Forms.TextBox()
        Me.ButtonOpenFolder = New System.Windows.Forms.Button()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBoxPages = New System.Windows.Forms.ListBox()
        Me.ButtonMovePage = New System.Windows.Forms.Button()
        Me.pdfControl = New System.Windows.Forms.Panel()
        Me.ToolStripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonGetAttachment, Me.ToolStripSeparator1, Me.ToolStripButtonSaveAttachment, Me.ToolStripButtonSetSkip, Me.ToolStripSeparator2, Me.ToolStripDropDownButtonOptions, Me.ToolStripSeparator3, Me.ToolStripLabelMessages})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(1141, 25)
        Me.ToolStripMain.TabIndex = 0
        Me.ToolStripMain.Text = "ToolStrip1"
        '
        'ToolStripButtonGetAttachment
        '
        Me.ToolStripButtonGetAttachment.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ToolStripButtonGetAttachment.Image = CType(resources.GetObject("ToolStripButtonGetAttachment.Image"), System.Drawing.Image)
        Me.ToolStripButtonGetAttachment.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonGetAttachment.Name = "ToolStripButtonGetAttachment"
        Me.ToolStripButtonGetAttachment.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripButtonGetAttachment.Text = "Get attachment"
        Me.ToolStripButtonGetAttachment.ToolTipText = "Get attachments from selected mail"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButtonSaveAttachment
        '
        Me.ToolStripButtonSaveAttachment.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ToolStripButtonSaveAttachment.Image = CType(resources.GetObject("ToolStripButtonSaveAttachment.Image"), System.Drawing.Image)
        Me.ToolStripButtonSaveAttachment.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonSaveAttachment.Name = "ToolStripButtonSaveAttachment"
        Me.ToolStripButtonSaveAttachment.Size = New System.Drawing.Size(115, 22)
        Me.ToolStripButtonSaveAttachment.Text = "Save attachment"
        '
        'ToolStripButtonSetSkip
        '
        Me.ToolStripButtonSetSkip.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ToolStripButtonSetSkip.Image = CType(resources.GetObject("ToolStripButtonSetSkip.Image"), System.Drawing.Image)
        Me.ToolStripButtonSetSkip.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripButtonSetSkip.Name = "ToolStripButtonSetSkip"
        Me.ToolStripButtonSetSkip.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButtonSetSkip.Text = "Set skip"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButtonOptions
        '
        Me.ToolStripDropDownButtonOptions.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ToolStripDropDownButtonOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCenterFilter, Me.ToolStripSeparator4, Me.ToolStripMenuItemShowToolBar, Me.ToolStripMenuItemFitPage, Me.ToolStripMenuItemFitWidth, Me.ToolStripMenuItemShowThumbs, Me.ToolStripSeparator5, Me.ToolStripMenuItemShowSuggestions})
        Me.ToolStripDropDownButtonOptions.Image = CType(resources.GetObject("ToolStripDropDownButtonOptions.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButtonOptions.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripDropDownButtonOptions.Name = "ToolStripDropDownButtonOptions"
        Me.ToolStripDropDownButtonOptions.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripDropDownButtonOptions.Text = "Options"
        '
        'ToolStripMenuItemCenterFilter
        '
        Me.ToolStripMenuItemCenterFilter.Name = "ToolStripMenuItemCenterFilter"
        Me.ToolStripMenuItemCenterFilter.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemCenterFilter.Text = "Filter CoCds"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripMenuItemShowToolBar
        '
        Me.ToolStripMenuItemShowToolBar.Name = "ToolStripMenuItemShowToolBar"
        Me.ToolStripMenuItemShowToolBar.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemShowToolBar.Text = "Pdf - show toolbar"
        '
        'ToolStripMenuItemFitPage
        '
        Me.ToolStripMenuItemFitPage.Name = "ToolStripMenuItemFitPage"
        Me.ToolStripMenuItemFitPage.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemFitPage.Text = "Pdf - fit page"
        '
        'ToolStripMenuItemFitWidth
        '
        Me.ToolStripMenuItemFitWidth.Name = "ToolStripMenuItemFitWidth"
        Me.ToolStripMenuItemFitWidth.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemFitWidth.Text = "Pdf - fit width"
        '
        'ToolStripMenuItemShowThumbs
        '
        Me.ToolStripMenuItemShowThumbs.Name = "ToolStripMenuItemShowThumbs"
        Me.ToolStripMenuItemShowThumbs.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemShowThumbs.Text = "Pdf - Show thumbs"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripMenuItemShowSuggestions
        '
        Me.ToolStripMenuItemShowSuggestions.Name = "ToolStripMenuItemShowSuggestions"
        Me.ToolStripMenuItemShowSuggestions.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItemShowSuggestions.Text = "Show suggestions"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabelMessages
        '
        Me.ToolStripLabelMessages.AutoSize = False
        Me.ToolStripLabelMessages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabelMessages.Name = "ToolStripLabelMessages"
        Me.ToolStripLabelMessages.Size = New System.Drawing.Size(200, 22)
        Me.ToolStripLabelMessages.Text = "System messages"
        '
        'ListViewAttachments
        '
        Me.ListViewAttachments.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ListViewAttachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.MailNr, Me.AttachmentName, Me.Status})
        Me.ListViewAttachments.ForeColor = System.Drawing.Color.White
        Me.ListViewAttachments.FullRowSelect = True
        Me.ListViewAttachments.GridLines = True
        Me.ListViewAttachments.Location = New System.Drawing.Point(0, 28)
        Me.ListViewAttachments.Name = "ListViewAttachments"
        Me.ListViewAttachments.Size = New System.Drawing.Size(393, 196)
        Me.ListViewAttachments.TabIndex = 2
        Me.ListViewAttachments.UseCompatibleStateImageBehavior = False
        Me.ListViewAttachments.View = System.Windows.Forms.View.Details
        '
        'MailNr
        '
        Me.MailNr.Text = "Mnr"
        Me.MailNr.Width = 40
        '
        'AttachmentName
        '
        Me.AttachmentName.Text = "AttchName"
        Me.AttachmentName.Width = 275
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 70
        '
        'ListBoxErps
        '
        Me.ListBoxErps.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ListBoxErps.ForeColor = System.Drawing.Color.White
        Me.ListBoxErps.FormattingEnabled = True
        Me.ListBoxErps.ItemHeight = 15
        Me.ListBoxErps.Location = New System.Drawing.Point(399, 28)
        Me.ListBoxErps.Name = "ListBoxErps"
        Me.ListBoxErps.Size = New System.Drawing.Size(70, 199)
        Me.ListBoxErps.TabIndex = 3
        '
        'ListBoxCoCds
        '
        Me.ListBoxCoCds.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ListBoxCoCds.ForeColor = System.Drawing.Color.White
        Me.ListBoxCoCds.FormattingEnabled = True
        Me.ListBoxCoCds.ItemHeight = 15
        Me.ListBoxCoCds.Location = New System.Drawing.Point(469, 28)
        Me.ListBoxCoCds.Name = "ListBoxCoCds"
        Me.ListBoxCoCds.Size = New System.Drawing.Size(64, 199)
        Me.ListBoxCoCds.TabIndex = 4
        '
        'ListBoxDocumentTypes
        '
        Me.ListBoxDocumentTypes.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ListBoxDocumentTypes.ForeColor = System.Drawing.Color.White
        Me.ListBoxDocumentTypes.FormattingEnabled = True
        Me.ListBoxDocumentTypes.ItemHeight = 15
        Me.ListBoxDocumentTypes.Location = New System.Drawing.Point(533, 28)
        Me.ListBoxDocumentTypes.Name = "ListBoxDocumentTypes"
        Me.ListBoxDocumentTypes.Size = New System.Drawing.Size(182, 199)
        Me.ListBoxDocumentTypes.TabIndex = 5
        '
        'txtFolderPath
        '
        Me.txtFolderPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtFolderPath.ForeColor = System.Drawing.Color.White
        Me.txtFolderPath.Location = New System.Drawing.Point(721, 28)
        Me.txtFolderPath.Name = "txtFolderPath"
        Me.txtFolderPath.Size = New System.Drawing.Size(367, 23)
        Me.txtFolderPath.TabIndex = 6
        '
        'ButtonOpenFolder
        '
        Me.ButtonOpenFolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ButtonOpenFolder.Location = New System.Drawing.Point(1094, 28)
        Me.ButtonOpenFolder.Name = "ButtonOpenFolder"
        Me.ButtonOpenFolder.Size = New System.Drawing.Size(34, 23)
        Me.ButtonOpenFolder.TabIndex = 7
        Me.ButtonOpenFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonOpenFolder.UseVisualStyleBackColor = False
        '
        'txtFileName
        '
        Me.txtFileName.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.txtFileName.ForeColor = System.Drawing.Color.White
        Me.txtFileName.Location = New System.Drawing.Point(721, 57)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(339, 23)
        Me.txtFileName.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1060, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = ".pdf"
        '
        'ListBoxPages
        '
        Me.ListBoxPages.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.ListBoxPages.ForeColor = System.Drawing.Color.White
        Me.ListBoxPages.FormattingEnabled = True
        Me.ListBoxPages.ItemHeight = 15
        Me.ListBoxPages.Location = New System.Drawing.Point(721, 86)
        Me.ListBoxPages.Name = "ListBoxPages"
        Me.ListBoxPages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBoxPages.Size = New System.Drawing.Size(39, 139)
        Me.ListBoxPages.TabIndex = 11
        '
        'ButtonMovePage
        '
        Me.ButtonMovePage.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ButtonMovePage.Location = New System.Drawing.Point(766, 86)
        Me.ButtonMovePage.Name = "ButtonMovePage"
        Me.ButtonMovePage.Size = New System.Drawing.Size(85, 23)
        Me.ButtonMovePage.TabIndex = 12
        Me.ButtonMovePage.Text = "Move Page"
        Me.ButtonMovePage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonMovePage.UseVisualStyleBackColor = False
        '
        'pdfControl
        '
        Me.pdfControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pdfControl.Location = New System.Drawing.Point(0, 230)
        Me.pdfControl.Name = "pdfControl"
        Me.pdfControl.Size = New System.Drawing.Size(1139, 332)
        Me.pdfControl.TabIndex = 13
        '
        'DmtFormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1141, 564)
        Me.Controls.Add(Me.ToolStripMain)
        Me.Controls.Add(Me.ListBoxCoCds)
        Me.Controls.Add(Me.ListBoxErps)
        Me.Controls.Add(Me.ButtonMovePage)
        Me.Controls.Add(Me.ListBoxPages)
        Me.Controls.Add(Me.ButtonOpenFolder)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.txtFolderPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListViewAttachments)
        Me.Controls.Add(Me.ListBoxDocumentTypes)
        Me.Controls.Add(Me.pdfControl)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Name = "DmtFormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "DmtFormMain"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripMain As Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonGetAttachment As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSaveAttachment As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSetSkip As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripDropDownButtonOptions As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabelMessages As Windows.Forms.ToolStripLabel
    Friend WithEvents ListViewAttachments As Windows.Forms.ListView
    Friend WithEvents ListBoxErps As Windows.Forms.ListBox
    Friend WithEvents ListBoxCoCds As Windows.Forms.ListBox
    Friend WithEvents ListBoxDocumentTypes As Windows.Forms.ListBox
    Friend WithEvents txtFolderPath As Windows.Forms.TextBox
    Friend WithEvents ButtonOpenFolder As Windows.Forms.Button
    Friend WithEvents txtFileName As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents ToolStripMenuItemCenterFilter As Windows.Forms.ToolStripMenuItem
    Friend WithEvents MailNr As Windows.Forms.ColumnHeader
    Friend WithEvents AttachmentName As Windows.Forms.ColumnHeader
    Friend WithEvents Status As Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripMenuItemShowToolBar As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFitPage As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFitWidth As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemShowSuggestions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemShowThumbs As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBoxPages As Windows.Forms.ListBox
    Friend WithEvents ButtonMovePage As Windows.Forms.Button
    Friend WithEvents pdfControl As Windows.Forms.Panel
End Class
