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
        Me.ToolStripMenuItemSelectSuggestions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPersistCoCd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemTopWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButtonUsefullLinks = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemSuggestionsSP = New System.Windows.Forms.ToolStripMenuItem()
        Me.EntitiesSPListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoCdsSPListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBoxSuggestions = New System.Windows.Forms.GroupBox()
        Me.LabelEntity = New System.Windows.Forms.Label()
        Me.LabelDocType = New System.Windows.Forms.Label()
        Me.LabelTotal = New System.Windows.Forms.Label()
        Me.LabelPo = New System.Windows.Forms.Label()
        Me.LabelScan = New System.Windows.Forms.Label()
        Me.ToolStripMain.SuspendLayout()
        Me.GroupBoxSuggestions.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonGetAttachment, Me.ToolStripSeparator1, Me.ToolStripButtonSaveAttachment, Me.ToolStripButtonSetSkip, Me.ToolStripSeparator2, Me.ToolStripDropDownButtonOptions, Me.ToolStripSeparator3, Me.ToolStripDropDownButtonUsefullLinks, Me.ToolStripLabelMessages})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
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
        Me.ToolStripDropDownButtonOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCenterFilter, Me.ToolStripSeparator4, Me.ToolStripMenuItemShowToolBar, Me.ToolStripMenuItemFitPage, Me.ToolStripMenuItemFitWidth, Me.ToolStripMenuItemShowThumbs, Me.ToolStripSeparator5, Me.ToolStripMenuItemShowSuggestions, Me.ToolStripMenuItemSelectSuggestions, Me.ToolStripMenuItemPersistCoCd, Me.ToolStripSeparator6, Me.ToolStripMenuItemTopWindow})
        Me.ToolStripDropDownButtonOptions.Image = CType(resources.GetObject("ToolStripDropDownButtonOptions.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButtonOptions.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripDropDownButtonOptions.Name = "ToolStripDropDownButtonOptions"
        Me.ToolStripDropDownButtonOptions.Size = New System.Drawing.Size(78, 22)
        Me.ToolStripDropDownButtonOptions.Text = "Options"
        '
        'ToolStripMenuItemCenterFilter
        '
        Me.ToolStripMenuItemCenterFilter.Name = "ToolStripMenuItemCenterFilter"
        Me.ToolStripMenuItemCenterFilter.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemCenterFilter.Text = "Filter CoCds"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItemShowToolBar
        '
        Me.ToolStripMenuItemShowToolBar.Enabled = False
        Me.ToolStripMenuItemShowToolBar.Name = "ToolStripMenuItemShowToolBar"
        Me.ToolStripMenuItemShowToolBar.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemShowToolBar.Text = "Pdf - show toolbar"
        '
        'ToolStripMenuItemFitPage
        '
        Me.ToolStripMenuItemFitPage.Name = "ToolStripMenuItemFitPage"
        Me.ToolStripMenuItemFitPage.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemFitPage.Text = "Pdf - fit page"
        '
        'ToolStripMenuItemFitWidth
        '
        Me.ToolStripMenuItemFitWidth.Name = "ToolStripMenuItemFitWidth"
        Me.ToolStripMenuItemFitWidth.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemFitWidth.Text = "Pdf - fit width"
        '
        'ToolStripMenuItemShowThumbs
        '
        Me.ToolStripMenuItemShowThumbs.Name = "ToolStripMenuItemShowThumbs"
        Me.ToolStripMenuItemShowThumbs.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemShowThumbs.Text = "Pdf - Show thumbs"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItemShowSuggestions
        '
        Me.ToolStripMenuItemShowSuggestions.Name = "ToolStripMenuItemShowSuggestions"
        Me.ToolStripMenuItemShowSuggestions.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemShowSuggestions.Text = "Show suggestions"
        '
        'ToolStripMenuItemSelectSuggestions
        '
        Me.ToolStripMenuItemSelectSuggestions.Name = "ToolStripMenuItemSelectSuggestions"
        Me.ToolStripMenuItemSelectSuggestions.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemSelectSuggestions.Text = "Select suggestions"
        '
        'ToolStripMenuItemPersistCoCd
        '
        Me.ToolStripMenuItemPersistCoCd.Name = "ToolStripMenuItemPersistCoCd"
        Me.ToolStripMenuItemPersistCoCd.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemPersistCoCd.Text = "Keep CoCd among Erps"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(196, 6)
        '
        'ToolStripMenuItemTopWindow
        '
        Me.ToolStripMenuItemTopWindow.Name = "ToolStripMenuItemTopWindow"
        Me.ToolStripMenuItemTopWindow.Size = New System.Drawing.Size(199, 22)
        Me.ToolStripMenuItemTopWindow.Text = "Keep window on top"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripDropDownButtonUsefullLinks
        '
        Me.ToolStripDropDownButtonUsefullLinks.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ToolStripDropDownButtonUsefullLinks.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemSuggestionsSP, Me.EntitiesSPListToolStripMenuItem, Me.CoCdsSPListToolStripMenuItem})
        Me.ToolStripDropDownButtonUsefullLinks.Image = CType(resources.GetObject("ToolStripDropDownButtonUsefullLinks.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButtonUsefullLinks.ImageTransparentColor = System.Drawing.Color.White
        Me.ToolStripDropDownButtonUsefullLinks.Name = "ToolStripDropDownButtonUsefullLinks"
        Me.ToolStripDropDownButtonUsefullLinks.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripDropDownButtonUsefullLinks.Text = "Usefull links"
        '
        'ToolStripMenuItemSuggestionsSP
        '
        Me.ToolStripMenuItemSuggestionsSP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItemSuggestionsSP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ToolStripMenuItemSuggestionsSP.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripMenuItemSuggestionsSP.Name = "ToolStripMenuItemSuggestionsSP"
        Me.ToolStripMenuItemSuggestionsSP.Size = New System.Drawing.Size(172, 22)
        Me.ToolStripMenuItemSuggestionsSP.Text = "Suggestions SP list"
        '
        'EntitiesSPListToolStripMenuItem
        '
        Me.EntitiesSPListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.EntitiesSPListToolStripMenuItem.Name = "EntitiesSPListToolStripMenuItem"
        Me.EntitiesSPListToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.EntitiesSPListToolStripMenuItem.Text = "Entities SP list"
        '
        'CoCdsSPListToolStripMenuItem
        '
        Me.CoCdsSPListToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.CoCdsSPListToolStripMenuItem.Name = "CoCdsSPListToolStripMenuItem"
        Me.CoCdsSPListToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CoCdsSPListToolStripMenuItem.Text = "CoCds SP list"
        '
        'ToolStripLabelMessages
        '
        Me.ToolStripLabelMessages.AutoSize = False
        Me.ToolStripLabelMessages.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStripLabelMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStripLabelMessages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabelMessages.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ToolStripLabelMessages.ForeColor = System.Drawing.Color.SeaGreen
        Me.ToolStripLabelMessages.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStripLabelMessages.Name = "ToolStripLabelMessages"
        Me.ToolStripLabelMessages.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.ToolStripLabelMessages.Size = New System.Drawing.Size(400, 22)
        Me.ToolStripLabelMessages.Text = "System messages"
        Me.ToolStripLabelMessages.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
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
        Me.AttachmentName.Width = 265
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 80
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
        Me.ListBoxPages.Size = New System.Drawing.Size(46, 139)
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
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(857, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Save pdf"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBoxSuggestions
        '
        Me.GroupBoxSuggestions.Controls.Add(Me.LabelEntity)
        Me.GroupBoxSuggestions.Controls.Add(Me.LabelDocType)
        Me.GroupBoxSuggestions.Controls.Add(Me.LabelTotal)
        Me.GroupBoxSuggestions.Controls.Add(Me.LabelPo)
        Me.GroupBoxSuggestions.Location = New System.Drawing.Point(773, 115)
        Me.GroupBoxSuggestions.Name = "GroupBoxSuggestions"
        Me.GroupBoxSuggestions.Size = New System.Drawing.Size(366, 109)
        Me.GroupBoxSuggestions.TabIndex = 15
        Me.GroupBoxSuggestions.TabStop = False
        Me.GroupBoxSuggestions.Text = "Suggestions"
        '
        'LabelEntity
        '
        Me.LabelEntity.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.LabelEntity.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.LabelEntity.ForeColor = System.Drawing.Color.White
        Me.LabelEntity.Location = New System.Drawing.Point(6, 74)
        Me.LabelEntity.Name = "LabelEntity"
        Me.LabelEntity.Size = New System.Drawing.Size(354, 32)
        Me.LabelEntity.TabIndex = 3
        Me.LabelEntity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelDocType
        '
        Me.LabelDocType.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.LabelDocType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.LabelDocType.ForeColor = System.Drawing.Color.White
        Me.LabelDocType.Location = New System.Drawing.Point(131, 19)
        Me.LabelDocType.Name = "LabelDocType"
        Me.LabelDocType.Size = New System.Drawing.Size(229, 24)
        Me.LabelDocType.TabIndex = 2
        Me.LabelDocType.Text = "DocType:"
        Me.LabelDocType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelTotal
        '
        Me.LabelTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.LabelTotal.ForeColor = System.Drawing.Color.White
        Me.LabelTotal.Location = New System.Drawing.Point(6, 46)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Size = New System.Drawing.Size(354, 24)
        Me.LabelTotal.TabIndex = 1
        Me.LabelTotal.Text = "Total:"
        Me.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelPo
        '
        Me.LabelPo.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.LabelPo.ForeColor = System.Drawing.Color.White
        Me.LabelPo.Location = New System.Drawing.Point(6, 19)
        Me.LabelPo.Name = "LabelPo"
        Me.LabelPo.Size = New System.Drawing.Size(119, 24)
        Me.LabelPo.TabIndex = 0
        Me.LabelPo.Text = "PO:"
        Me.LabelPo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelScan
        '
        Me.LabelScan.BackColor = System.Drawing.Color.Coral
        Me.LabelScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelScan.ForeColor = System.Drawing.Color.White
        Me.LabelScan.Location = New System.Drawing.Point(948, 90)
        Me.LabelScan.Name = "LabelScan"
        Me.LabelScan.Size = New System.Drawing.Size(38, 15)
        Me.LabelScan.TabIndex = 16
        Me.LabelScan.Text = "SCAN"
        Me.LabelScan.Visible = False
        '
        'DmtFormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1141, 564)
        Me.Controls.Add(Me.LabelScan)
        Me.Controls.Add(Me.GroupBoxSuggestions)
        Me.Controls.Add(Me.Button1)
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
        Me.TopMost = True
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.GroupBoxSuggestions.ResumeLayout(False)
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
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents ToolStripDropDownButtonUsefullLinks As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemSuggestionsSP As Windows.Forms.ToolStripMenuItem
    Friend WithEvents EntitiesSPListToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents CoCdsSPListToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemTopWindow As Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBoxSuggestions As Windows.Forms.GroupBox
    Friend WithEvents LabelDocType As Windows.Forms.Label
    Friend WithEvents LabelTotal As Windows.Forms.Label
    Friend WithEvents LabelPo As Windows.Forms.Label
    Friend WithEvents LabelEntity As Windows.Forms.Label
    Friend WithEvents LabelScan As Windows.Forms.Label
    Friend WithEvents ToolStripMenuItemSelectSuggestions As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemPersistCoCd As Windows.Forms.ToolStripMenuItem
End Class
