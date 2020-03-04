Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Office.Interop.Outlook
Imports System.Data.OleDb
Imports System.Data
Imports System.ComponentModel
Imports Acrobat

Enum DmtDocTypes
    ZMMINVOICE = 1
    ZMMCREDNOTE = 2
    ZMMURGTINV = 3
    ZFIINVOICE = 4
    ZFICREDNOTE = 5
    ZFIURGTINV = 6
    ZFICRNTIG = 7
    ZFIINVIG = 8
    ZFIURGIGIN = 9
    TP_PO_INVOICE_LIV = 10
    TP_NON_PO_INVOICE_FI = 11
    TP_PO_CREDITNOTE_LIV = 12
    TP_NON_PO_CREDITNOTE_FI = 13
    IG_PO_INVOICE_LIV = 14
    IG_NON_PO_INVOICE_FI = 15
End Enum

Public Enum DmtStatuses
    Complete = 0
    Check = 1
    Skip = 2
End Enum

Public Enum DmtDocStatuses
    Undefined = 0
    Invoice = 1
    CreditNote = 2
End Enum

Public Class DmtFormMain

    Dim DmtDataSet As New DataSet

    Dim regexPatternTotals As StringBuilder
    Dim regexPatternCreditNotes As StringBuilder

    Dim pdfDoc As New AcroAVDoc

    Private Sub DmtFormMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        txtFolderPath.Text = My.Settings.saveFolderPath.ToString

        SetUpTool()
        CheckCategories()
        RemoveAllPdfFiles()
        DownloadDataFromSP()
        GetAllAttachments()

    End Sub

    Private Sub GetAllAttachments()
        Dim i As Long
        Dim oMail As MailItem

        ClosePreviousOpenedPdf()
        RemoveAllPdfFiles()

        If Not Globals.dmtAddin.Application.ActiveExplorer Is Nothing Then
            If Globals.dmtAddin.Application.ActiveExplorer.Selection.Count > 0 Then

                ListViewAttachments.Items.Clear()
                ListViewAttachments.BeginUpdate()

                For i = 1 To Globals.dmtAddin.Application.ActiveExplorer.Selection.Count

                    If Globals.dmtAddin.Application.ActiveExplorer.Selection.Item(i).class = OlObjectClass.olMail Then

                        oMail = Globals.dmtAddin.Application.ActiveExplorer.Selection.Item(i)
                        AddAttachmentDetailsProperty(oMail)
                        PopulateListViewWithAttachments(oMail, i)
                        VerifyAttachmentsStatuses(oMail, i)

                    End If

                Next

                If ListViewAttachments.Items.Count = 1 Then ListViewAttachments.Items(0).Selected = True

                ListViewAttachments.EndUpdate()

            End If
        End If

    End Sub

    Private Sub AddAttachmentDetailsProperty(ByRef oMail As MailItem)
        Dim oProperty As UserProperty

        oProperty = oMail.UserProperties.Find(My.Resources.AttachmentDetailsProperty)

        If oProperty Is Nothing Then
            If needProperty(oMail) Then

                oProperty = oMail.UserProperties.Add(My.Resources.AttachmentDetailsProperty, OlUserPropertyType.olText, True, 1)

            End If
        End If

        If Not oProperty Is Nothing Then
            If oProperty.Value = vbNullString Then
                oProperty.Value = getAttachmentDetailsDefaultValues(oMail)
            End If
        End If

    End Sub

    Private Function needProperty(ByRef oMail As MailItem) As Boolean
        Dim oAttachment As Attachment
        Dim bFlag As Boolean

        For Each oAttachment In oMail.Attachments
            If oAttachment.FileName.Substring(oAttachment.FileName.Length - 4, 4).ToLower = ".pdf" Then

                bFlag = True
                oAttachment = Nothing
                Exit For

            End If

        Next

        Return bFlag
    End Function

    Private Sub PopulateListViewWithAttachments(ByRef oMail As MailItem, ByRef mailNumber As Long)
        Dim oAttachment As Attachment
        Dim attachmentSaveName As String
        Dim olistItem As ListViewItem
        Dim attachmentStatus As dmtStatuses
        Dim tempFolderCreated As Boolean = True

        If Not Directory.Exists(My.Resources.temporaryFolderPath) Then
            Try
                Directory.CreateDirectory(My.Resources.temporaryFolderPath)
            Catch exAccess As UnauthorizedAccessException
                tempFolderCreated = False
                MessageBox.Show("Cannot find C:\App folder. Please create it manually before you run program.", "Temporary path error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End Try

        End If

        If tempFolderCreated Then

            For Each oAttachment In oMail.Attachments

                If oAttachment.Type = OlAttachmentType.olByValue Then

                    If oAttachment.FileName.Substring(oAttachment.FileName.Length - 4, 4).ToLower = ".pdf" Then

                        attachmentSaveName = mailNumber & "_" & oAttachment.Index & "_" & oAttachment.FileName

                        oAttachment.SaveAsFile(Path.Combine(My.Resources.temporaryFolderPath, attachmentSaveName))

                        olistItem = New ListViewItem(mailNumber.ToString)
                        olistItem.SubItems.Add(oAttachment.FileName.ToString)

                        attachmentStatus = DirectCast(getAttachmentStatusByIndex(oAttachment.Index, oMail), dmtStatuses)
                        olistItem.SubItems.Add(attachmentStatus.ToString)
                        If attachmentStatus = dmtStatuses.Complete Then ColorListViewLine(olistItem)

                        olistItem.SubItems.Add(oAttachment.Index.ToString)
                        olistItem.SubItems.Add(oMail.EntryID.ToString)

                        ListViewAttachments.Items.Add(olistItem)

                    End If

                End If
            Next

        End If

    End Sub

    Private Sub VerifyAttachmentsStatuses(ByRef oMail As MailItem, ByRef mailIndex As Long)
        Dim IsMailCompleted As Boolean
        Dim mailCategories As String
        Dim oListItem As ListViewItem

        IsMailCompleted = True

        If ListViewAttachments.Items.Count > 0 Then

            For Each oListItem In ListViewAttachments.Items

                If oListItem.Text = mailIndex Then

                    If oListItem.SubItems(2).Text = dmtStatuses.Check.ToString Then
                        IsMailCompleted = False
                    End If

                End If

            Next

            mailCategories = oMail.Categories

            If IsMailCompleted Then

                If mailCategories.IndexOf("Check_Dmt") > -1 Then
                    mailCategories = mailCategories.Replace("Check_Dmt", "Completed_Dmt")
                ElseIf mailCategories.IndexOf("Completed_Dmt") = -1 Then
                    mailCategories = mailCategories & ";Completed_Dmt"
                End If

            Else

                If mailCategories = vbNullString Then
                    mailCategories = "Check_Dmt"
                End If
            End If

            oMail.Categories = mailCategories
            oMail.Save()

            'If Err.Number = -2147219956 Then
            '    'BUG problem with users OST file
            '    Debug.Print Err.Description
            'End If

        End If

    End Sub

    Function getAttachmentStatusByIndex(ByRef attachIndex As Long, ByRef oMail As MailItem) As Integer
        Dim oProperty As UserProperty
        Dim detailsText As String
        Dim attachProperties() As String
        Dim i As Long
        Dim vTemp() As String

        oProperty = oMail.UserProperties(My.Resources.AttachmentDetailsProperty)
        If Not oProperty Is Nothing Then

            If oProperty.Value <> vbNullString Then

                detailsText = oProperty.Value
                vTemp = detailsText.Split("$")

                For i = LBound(vTemp) To UBound(vTemp)
                    attachProperties = vTemp(i).Split(";")

                    If CLng(attachProperties(0)) = attachIndex Then

                        Return attachProperties(1)
                        Exit For

                    End If

                Next

            End If

        End If

    End Function

    Private Function getAttachmentDetailsDefaultValues(ByRef oMail As MailItem) As String
        Dim oAttachment As Attachment
        Dim detailText As StringBuilder = New StringBuilder

        For Each oAttachment In oMail.Attachments

            If oAttachment.FileName.Substring(oAttachment.FileName.Length - 4, 4).ToLower = ".pdf" Then
                detailText.Append(oAttachment.Index & ";" & dmtStatuses.Check & "$")
            End If

        Next

        Return detailText.ToString.Remove(detailText.Length - 1, 1)

    End Function

    Private Sub ClosePreviousOpenedPdf()

        If Not pdfDoc Is Nothing Then
            Try
                If pdfDoc.IsValid Then
                    pdfDoc.Close(True)
                End If

            Catch
                pdfDoc = New AcroAVDoc
            Finally
                pdfDoc.Close(True)
            End Try
        End If

    End Sub

    Private Sub ButtonOpenFolder_Click() Handles ButtonOpenFolder.Click
        Dim selectFolderDialog As New FolderBrowserDialog

        With selectFolderDialog
            .RootFolder = Environment.SpecialFolder.Desktop
            .SelectedPath = My.Settings.saveFolderPath.ToString
            If .ShowDialog = DialogResult.OK Then
                My.Settings.saveFolderPath = .SelectedPath
                txtFolderPath.Text = My.Settings.saveFolderPath
            End If
        End With

    End Sub
    Private Sub DownloadDataFromSP()

        SetUpTool()
        GetDataFromCoCd()
        GetDataFromDmtEntities()
        GetDataFromDmtHelpers()


    End Sub

    Private Sub SetUpTool()
        ToolStripMenuItemCenterFilter.Checked = My.Settings.centerFilter
        ToolStripMenuItemShowToolBar.Checked = My.Settings.pdfShowToolbar
        ToolStripMenuItemShowSuggestions.Checked = My.Settings.showSuggestions
        ToolStripMenuItemShowThumbs.Checked = My.Settings.pdfShowThumbs
        ToolStripMenuItemTopWindow.Checked = My.Settings.topWindow

        Me.TopMost = My.Settings.topWindow

        If My.Settings.pdfFit = 1 Then
            ToolStripMenuItemFitPage.Checked = True
            ToolStripMenuItemFitWidth.Checked = False
        Else
            ToolStripMenuItemFitWidth.Checked = True
            ToolStripMenuItemFitPage.Checked = False
        End If

        AddPictures()

        With ListViewAttachments
            .HeaderStyle = ColumnHeaderStyle.Nonclickable
            .HideSelection = False
            .ShowItemToolTips = False
            .Sorting = False
            '   .AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent)
        End With

    End Sub

    Private Sub AddPictures()
        Dim vPicture As stdole.IPictureDisp

        vPicture = Globals.dmtAddin.Application.ActiveExplorer.CommandBars.GetImageMso("AppointmentAttachment", 16, 16)
        ToolStripButtonGetAttachment.Image = Drawing.Image.FromHbitmap(vPicture.Handle, vPicture.hPal)
        vPicture = Globals.dmtAddin.Application.ActiveExplorer.CommandBars.GetImageMso("MoveToFolderFileMenu", 16, 16)
        ToolStripButtonSaveAttachment.Image = Drawing.Image.FromHbitmap(vPicture.Handle, vPicture.hPal)
        vPicture = Globals.dmtAddin.Application.ActiveExplorer.CommandBars.GetImageMso("SkipOccurrence", 16, 16)
        ToolStripButtonSetSkip.Image = Drawing.Image.FromHbitmap(vPicture.Handle, vPicture.hPal)
        vPicture = Globals.dmtAddin.Application.ActiveExplorer.CommandBars.GetImageMso("ApplicationOptionsDialog", 16, 16)
        ToolStripDropDownButtonOptions.Image = Drawing.Image.FromHbitmap(vPicture.Handle, vPicture.hPal)
        vPicture = Globals.dmtAddin.Application.ActiveExplorer.CommandBars.GetImageMso("Folder", 16, 16)
        ButtonOpenFolder.Image = Drawing.Image.FromHbitmap(vPicture.Handle, vPicture.hPal)
        vPicture = Globals.dmtAddin.Application.ActiveExplorer.CommandBars.GetImageMso("FileLinksToFiles", 16, 16)
        ToolStripDropDownButtonUsefullLinks.Image = Drawing.Image.FromHbitmap(vPicture.Handle, vPicture.hPal)

    End Sub

    Private Sub GetDataFromCoCd()
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;WSS; IMEX=2;RetrieveIDS=Yes;DATABASE=" & My.Resources.DmtServerName & ";LIST={" & My.Resources.CoCdGUID & "};"
        Dim SpConnection As New OleDbConnection(connString)
        Dim oCommand As New OleDbCommand()
        Dim oAdapter As New OleDbDataAdapter
        Dim sFilter As String = Globals.dmtAddin.Application.GetNamespace("MAPI").CurrentUser.AddressEntry.GetExchangeUser.Alias.Substring(0, 2)

        oCommand.Connection = SpConnection

        If My.Settings.centerFilter Then
            oCommand.CommandText = "SELECT [ERP], [CoCd], [CenterFilter] FROM [DmtCoCd] WHERE CenterFilter = '" & sFilter & "'"
        Else
            oCommand.CommandText = "SELECT [ERP], [CoCd], [CenterFilter] FROM [DmtCoCd]"
        End If

        oAdapter.SelectCommand = oCommand
        oAdapter.Fill(DmtDataSet, "CoCds")

        oCommand.CommandText = "SELECT DISTINCT [ERP] FROM [DmtCoCd]"
        oAdapter.Fill(DmtDataSet, "Erps")

        ListBoxErps.ValueMember = "ERP"
        ListBoxErps.DisplayMember = "ERP"
        ListBoxErps.DataSource = DmtDataSet.Tables("Erps")

    End Sub

    Private Sub GetDataFromDmtEntities()

        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;WSS; IMEX=2;RetrieveIDS=Yes;DATABASE=" & My.Resources.DmtServerName & ";LIST={" & My.Resources.EntitiesGUID & "};"
        Dim SpConnection As New OleDbConnection(connString)
        Dim oCommand As New OleDbCommand("SELECT [CoCd], [EntityName], [Regex] FROM [DmtEntities]", SpConnection)
        Dim oAdapter As New OleDbDataAdapter(oCommand)

        oAdapter.Fill(DmtDataSet, "Entities")

    End Sub

    Private Sub GetDataFromDmtHelpers()

        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;WSS; IMEX=2;RetrieveIDS=Yes;DATABASE=" & My.Resources.DmtServerName & ";LIST={" & My.Resources.HelpersGUID & "};"
        Dim SpConnection As New OleDbConnection(connString)
        Dim oCommand As New OleDbCommand("SELECT [Category], [ValueText] FROM [dmtHelper]", SpConnection)
        Dim oAdapter As New OleDbDataAdapter(oCommand)

        oAdapter.Fill(DmtDataSet, "Helpers")

        CreateRegexPatternTotals()
        CreateRegexPatternCreditNotes()

    End Sub

    Private Sub CreateRegexPatternTotals()
        Dim vRows As DataRow()
        Dim vRow As DataRow

        regexPatternTotals = New StringBuilder
        vRows = DmtDataSet.Tables("Helpers").Select("Category ='Totals'")

        regexPatternTotals.Append("\b(")

        For Each vRow In vRows
            regexPatternTotals.Append(vRow(1) & "|")
        Next

        regexPatternTotals.Remove(regexPatternTotals.Length - 1, 1)
        regexPatternTotals.Append(")\b(.*?)([-+(]?\d+(.*?)[^\d\s][\d),.-]+)")

    End Sub

    Private Sub CreateRegexPatternCreditNotes()
        Dim vRows As DataRow()
        Dim vRow As DataRow

        regexPatternCreditNotes = New StringBuilder

        vRows = DmtDataSet.Tables("Helpers").Select("Category ='CreditNotes'")

        For Each vRow In vRows
            regexPatternCreditNotes.Append(vRow(1) & "|")
        Next

        regexPatternCreditNotes.Remove(regexPatternCreditNotes.Length - 1, 1)

    End Sub

    Sub FillDocumentTypesComboBox()

        ListBoxDocumentTypes.Items.Clear()

        Select Case ListBoxErps.SelectedValue
            Case "P16", "P94"
                With ListBoxDocumentTypes.Items
                    .Add(dmtDocTypes.TP_PO_INVOICE_LIV.ToString)
                    .Add(dmtDocTypes.TP_NON_PO_INVOICE_FI.ToString)
                    .Add(dmtDocTypes.TP_PO_CREDITNOTE_LIV.ToString)
                    .Add(dmtDocTypes.TP_NON_PO_CREDITNOTE_FI.ToString)
                    .Add(dmtDocTypes.IG_PO_INVOICE_LIV.ToString)
                    .Add(dmtDocTypes.IG_NON_PO_INVOICE_FI.ToString)
                End With

            Case "P49", "P53"
                With ListBoxDocumentTypes.Items
                    .Add(dmtDocTypes.ZMMINVOICE.ToString)
                    .Add(dmtDocTypes.ZMMCREDNOTE.ToString)
                    .Add(dmtDocTypes.ZMMURGTINV.ToString)
                    .Add(dmtDocTypes.ZFIINVOICE.ToString)
                    .Add(dmtDocTypes.ZFICREDNOTE.ToString)
                    .Add(dmtDocTypes.ZFIURGTINV.ToString)
                    .Add(dmtDocTypes.ZFICRNTIG.ToString)
                    .Add(dmtDocTypes.ZFIINVIG.ToString)
                    .Add(dmtDocTypes.ZFIURGIGIN.ToString)
                End With
        End Select

    End Sub

    Private Sub ListBoxErps_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBoxErps.SelectedValueChanged
        Dim selectedRows As DataRow()
        Dim oRow As DataRow

        If Not ListBoxErps.SelectedValue Is Nothing Then
            ListBoxCoCds.Items.Clear()

            selectedRows = DmtDataSet.Tables("CoCds").Select("ERP ='" & ListBoxErps.SelectedValue & "'", "CoCd Asc")
            For Each oRow In selectedRows
                ListBoxCoCds.Items.Add(oRow(1).ToString)
            Next

        End If

        FillDocumentTypesComboBox()

    End Sub

    Private Sub CheckCategories()
        Dim categoryList As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        Dim oNameSpace As Microsoft.Office.Interop.Outlook.NameSpace = Globals.dmtAddin.Application.GetNamespace("MAPI")
        Dim pair As KeyValuePair(Of String, Integer)
        Dim oCategory As Category

        categoryList.Add("Completed_Dmt", 5)
        categoryList.Add("Check_Dmt", 3)

        For Each pair In categoryList
            oCategory = oNameSpace.Categories(pair.Key)
            If oCategory Is Nothing Then
                oNameSpace.Categories.Add(pair.Key, pair.Value)
            End If
        Next

    End Sub

    Private Sub RemoveAllPdfFiles()
        Dim oFile As String

        Dim oProcess As System.Diagnostics.Process

        If Directory.Exists(My.Resources.temporaryFolderPath) Then

            For Each oFile In Directory.GetFiles(My.Resources.temporaryFolderPath)
                Try
                    File.Delete(oFile)

                Catch ex As IOException

                    For Each oProcess In System.Diagnostics.Process.GetProcessesByName("Acrobat")
                        oProcess.Kill()
                        oProcess.WaitForExit()
                    Next

                Finally
                    File.Delete(oFile)
                End Try

            Next

        End If
    End Sub

    Private Sub ToolStripMenuItemCenterFilter_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCenterFilter.Click
        ToolStripMenuItemCenterFilter.Checked = Not ToolStripMenuItemCenterFilter.Checked
        My.Settings.centerFilter = ToolStripMenuItemCenterFilter.Checked
    End Sub

    Private Sub DmtFormMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        My.Settings.Save()

        ClosePreviousOpenedPdf()

        RemoveAllPdfFiles()

        Try
            pdfDoc.Close(True)
        Finally
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pdfDoc)
            pdfDoc = Nothing
        End Try

    End Sub

    Private Sub ToolStripButtonGetAttachment_Click(sender As Object, e As EventArgs) Handles ToolStripButtonGetAttachment.Click
        GetAllAttachments()
    End Sub

    Private Sub ToolStripButtonSetSkip_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSetSkip.Click
        Dim oMail As MailItem
        Dim oListItem As ListViewItem

        oListItem = ListViewAttachments.SelectedItems.Item(0)

        If Not oListItem Is Nothing Then

            oListItem.SubItems(2).Text = dmtStatuses.Skip.ToString
            oMail = Globals.dmtAddin.Application.GetNamespace("MAPI").GetItemFromID(oListItem.SubItems(4).Text)
            setAttachmentStatusByIndex(oMail, CLng(oListItem.SubItems(3).Text), dmtStatuses.Skip)
            VerifyAttachmentsStatuses(oMail, oListItem.Text)
        End If

    End Sub

    Private Sub SetAttachmentStatusByIndex(ByRef oMail As MailItem, ByRef attachIndex As Long, ByRef newStatus As dmtStatuses)
        Dim oProperty As UserProperty
        Dim detailsText As String
        Dim vTemp() As String
        Dim attachProperties() As String
        Dim i As Long
        Dim sBuilder As StringBuilder

        oProperty = oMail.UserProperties(My.Resources.AttachmentDetailsProperty)

        If Not oProperty Is Nothing Then

            sBuilder = New StringBuilder
            detailsText = oProperty.Value
            vTemp = detailsText.Split("$")

            For i = LBound(vTemp) To UBound(vTemp)
                attachProperties = vTemp(i).Split(";")

                If CLng(attachProperties(0)) = attachIndex Then
                    attachProperties(1) = newStatus
                End If
                'Roll back
                sBuilder.Append(attachProperties(0) & ";" & attachProperties(1) & "$")
            Next

            oProperty.Value = sBuilder.Remove(sBuilder.Length - 1, 1).ToString
            oMail.Save()
        End If

    End Sub

    Private Sub ListViewAttachments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListViewAttachments.SelectedIndexChanged
        Dim oListItem As ListViewItem
        Dim sFileName As String

        ToolStripLabelMessages.Text = vbNullString
        ToolStripLabelMessages.ForeColor = System.Drawing.Color.SeaGreen

        If ListViewAttachments.SelectedItems.Count = 1 Then
            oListItem = ListViewAttachments.SelectedItems(0)
            sFileName = oListItem.Text & "_" & oListItem.SubItems(3).Text & "_" & oListItem.SubItems(1).Text

            DisplayPdfInFrame(sFileName)
            DisplayPagesInListBox()
            txtFileName.Text = oListItem.SubItems(1).Text.Substring(0, oListItem.SubItems(1).Text.Length - 4)

            If My.Settings.showSuggestions Then DisplaySuggestions()

        End If
    End Sub

    Private Sub DisplayPdfInFrame(fileName As String)

        Try

            If pdfDoc.IsValid Then pdfDoc.Close(True)

            If My.Settings.pdfFit = 1 Then
                pdfDoc.OpenInWindowEx(Path.Combine(My.Resources.temporaryFolderPath, fileName), pdfControl.Handle, AVOpenParams.AV_DOC_VIEW, 1, 0, 0, AVZoomType.AVZoomFitPage, 0, 0, 0)
            Else
                pdfDoc.OpenInWindowEx(Path.Combine(My.Resources.temporaryFolderPath, fileName), pdfControl.Handle, AVOpenParams.AV_DOC_VIEW, 0, 0, 0, 0, 0, 0, 0)
            End If

            pdfDoc.SetViewMode(My.Settings.pdfShowThumbs)

        Catch

            pdfDoc = Nothing
            pdfDoc = New AcroAVDoc

        End Try

    End Sub
    Private Sub DisplayPagesInListBox()
        Dim i As Integer
        Dim activePdf As AcroPDDoc

        ListBoxPages.Items.Clear()

        Try
            activePdf = pdfDoc.GetPDDoc

            If Not activePdf Is Nothing Then
                For i = 0 To activePdf.GetNumPages - 1
                    ListBoxPages.Items.Add(i + 1)
                Next
            End If

        Catch
            ToolStripLabelMessages.Text = "Pdf err. Deselect and select attachment once again"
            ToolStripLabelMessages.ForeColor = System.Drawing.Color.DeepPink
        End Try


    End Sub

    Private Sub DisplaySuggestions()
        Dim extractorClass As PdfExtractor
        Dim shellEntity As Entity

        'Try
        If Not pdfDoc.GetPDDoc Is Nothing Then

            LabelEntity.Text = vbNullString
            extractorClass = New PdfExtractor

            With extractorClass

                If Not pdfDoc Is Nothing Then
                    .ExtractAllText(pdfDoc.GetPDDoc)

                    If Not .IsScan Then

                        .totalPattern = regexPatternTotals.ToString
                        .creditNotePattern = regexPatternCreditNotes.ToString

                        shellEntity = .findEntity(DmtDataSet.Tables("Entities").Rows)

                        If Not shellEntity Is Nothing Then

                            LabelEntity.Text = shellEntity.EntityName & " " & shellEntity.CoCd
                            If My.Settings.selectSuggestions Then
                                SelectCoCd(shellEntity.CoCd)
                            End If

                        End If

                        LabelScan.Visible = False
                        LabelPo.Text = "PO: " & .findPoNumber
                        LabelTotal.Text = "Total: " & .findTotal & " IsInvoice: " & .IsInvoice.ToString


                        If ListBoxErps.SelectedIndex > -1 Then

                            LabelDocType.Text = "Doc type: " & .guessDocType(ListBoxErps.SelectedValue)
                            If My.Settings.selectSuggestions Then
                                SelectCategory(.guessDocType(ListBoxErps.SelectedValue))
                            End If

                        End If

                    Else

                        LabelEntity.Text = vbNullString
                        LabelPo.Text = "PO: "
                        LabelTotal.Text = "Total: "
                        LabelDocType.Text = "Doc type: "
                        LabelScan.Visible = True

                        If ListBoxDocumentTypes.SelectedIndex > -1 Then ListBoxDocumentTypes.ClearSelected()
                        'If ListBoxCoCds.SelectedIndex > -1 Then ListBoxCoCds.SelectedIndex = False

                    End If

                End If

            End With

        End If

        'Catch

        'ToolStripLabelMessages.Text = "The remote server machine is unavailable"
        '    ToolStripLabelMessages.ForeColor = System.Drawing.Color.DeepPink

        'End Try

    End Sub

    Private Sub SelectCoCd(ByRef CoCdName As String)
        Dim CoCdTable As DataTable
        Dim oRows As DataRow()

        CoCdTable = DmtDataSet.Tables("CoCds")
        oRows = CoCdTable.Select("CoCd ='" & CoCdName & "'")

        ListBoxErps.SelectedValue = oRows(0)(0)
        'TODO Make item selected! - TEST!
        ListBoxCoCds.SelectedItem = CoCdName


    End Sub

    Private Sub SelectCategory(ByRef categoryName As String)

        ListBoxDocumentTypes.ClearSelected()
        ListBoxDocumentTypes.SelectedIndex = ListBoxDocumentTypes.FindStringExact(categoryName)

    End Sub
    Private Sub ToolStripMenuItemShowToolBar_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemShowToolBar.Click
        ToolStripMenuItemShowToolBar.Checked = Not ToolStripMenuItemShowToolBar.Checked
        My.Settings.pdfShowToolbar = ToolStripMenuItemShowToolBar.Checked
    End Sub

    Private Sub ToolStripMenuItemFitPage_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFitPage.Click
        ToolStripMenuItemFitWidth.Checked = False
        ToolStripMenuItemFitPage.Checked = True

        My.Settings.pdfFit = 1

    End Sub

    Private Sub ToolStripMenuItemFitWidth_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFitWidth.Click
        ToolStripMenuItemFitPage.Checked = False
        ToolStripMenuItemFitWidth.Checked = True

        My.Settings.pdfFit = 0

    End Sub

    Private Sub ToolStripMenuItemShowSuggestions_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemShowSuggestions.Click
        ToolStripMenuItemShowSuggestions.Checked = Not ToolStripMenuItemShowSuggestions.Checked
        My.Settings.showSuggestions = ToolStripMenuItemShowSuggestions.Checked
    End Sub

    Private Sub ToolStripButtonSaveAttachment_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSaveAttachment.Click
        Dim oMail As MailItem
        Dim oListItem As ListViewItem
        Dim OneFileSelected As Boolean

        ToolStripLabelMessages.Text = vbNullString
        ToolStripLabelMessages.ForeColor = System.Drawing.Color.SeaGreen

        If checks() Then

            If ListViewAttachments.SelectedItems.Count = 1 Then OneFileSelected = True


            For Each oListItem In ListViewAttachments.SelectedItems

                oMail = Globals.dmtAddin.Application.GetNamespace("MAPI").GetItemFromID(oListItem.SubItems(4).Text)

                If SaveFile(OneFileSelected, oListItem) Then

                    ChangeStatus(oMail, oListItem)
                    ColorListViewLine(oListItem)
                    AddToTracking(oMail, OneFileSelected, oListItem)

                End If

                VerifyAttachmentsStatuses(oMail, oListItem.Text)

                oListItem.Selected = False
                oMail = Nothing

            Next

        End If

        ListBoxDocumentTypes.SelectedIndex = -1

    End Sub

    Private Sub AddToTracking(oMail As MailItem, OneFileSelected As Boolean, oListItem As ListViewItem)
        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;WSS; IMEX=0;RetrieveIDS=Yes;DATABASE=" & My.Resources.DmtServerName & ";LIST={" & My.Resources.TrackingGUID & "};"
        Dim insertQuery As String
        Dim rowsAffected As Integer
        Dim fileName As String

        If OneFileSelected Then
            fileName = txtFileName.Text
        Else
            fileName = oListItem.SubItems(1).Text
        End If

        insertQuery = "INSERT INTO [" & My.Resources.TrackingGUID & "] "
        insertQuery += "([ConversationID], [DocName], [DocCategory], [CoCd], [Erp], [RecivedDate], [From], [DmtUserName], [Subject]) "
        insertQuery += "VALUES('" & oMail.ConversationID & "','" & fileName & "','" & ListBoxDocumentTypes.SelectedItem & "', '"
        insertQuery += ListBoxCoCds.SelectedItem & " ','" & ListBoxErps.SelectedValue & "','" & oMail.ReceivedTime.ToString("yyyy-MM-dd") & "', '"
        insertQuery += oMail.SenderName & "','" & Globals.dmtAddin.Application.GetNamespace("MAPI").CurrentUser.AddressEntry.GetExchangeUser.PrimarySmtpAddress & "','" & oMail.Subject & "');"

        Using SpConnection As New OleDbConnection(connString)
            Using oCommand As New OleDbCommand()

                oCommand.CommandText = insertQuery
                oCommand.Connection = SpConnection

                Try
                    SpConnection.Open()
                    rowsAffected = oCommand.ExecuteNonQuery()
                Catch ex As OleDbException
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                End Try

            End Using
        End Using

    End Sub

    Private Sub ColorListViewLine(oListItem As ListViewItem)
        oListItem.UseItemStyleForSubItems = True
        oListItem.BackColor = Drawing.Color.YellowGreen
    End Sub

    Private Function SaveFile(OneFileSelected As Boolean, oListItem As ListViewItem) As Boolean
        Dim folderName As String
        'Dim destinationFolderPath As String
        Dim destinationFilePath As String
        Dim sourceFilePath As String
        Dim tempfileName As String

        folderName = ListBoxCoCds.SelectedItem.ToString & "_" & ListBoxDocumentTypes.SelectedItem.ToString
        'destinationFolderPath = Path.Combine(txtFolderPath.Text, folderName)

        If OneFileSelected Then
            destinationFilePath = Path.Combine({txtFolderPath.Text, folderName, txtFileName.Text & ".pdf"})
        Else
            destinationFilePath = Path.Combine({txtFolderPath.Text, folderName, oListItem.SubItems(1).Text})
        End If

        tempfileName = oListItem.Text & "_" & oListItem.SubItems(3).Text & "_" & oListItem.SubItems(1).Text
        sourceFilePath = Path.Combine(My.Resources.temporaryFolderPath, tempfileName)

        If Not Directory.Exists(Path.Combine(txtFolderPath.Text, folderName)) Then
            Directory.CreateDirectory(Path.Combine(txtFolderPath.Text, folderName))
        End If

        Try
            File.Copy(sourceFilePath, destinationFilePath)
            Return True
        Catch ex As IOException
            MessageBox.Show(ex.Message, "Cannot copy file", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try


    End Function

    Private Sub ChangeStatus(oMail As MailItem, oListItem As ListViewItem)
        oListItem.SubItems(2).Text = dmtStatuses.Complete.ToString
        setAttachmentStatusByIndex(oMail, oListItem.SubItems(3).Text, dmtStatuses.Complete)
    End Sub

    Private Function Checks() As Boolean
        Dim sMessage As String = vbNullString
        Dim vChecks As Boolean = True

        If ListViewAttachments.SelectedItems.Count = 0 Then
            vChecks = False
            sMessage = "Please select attachment" & vbCrLf
        End If

        If ListBoxCoCds.SelectedItem = Nothing Then
            vChecks = False
            sMessage = sMessage & "Please select CoCd" & vbCrLf
        End If

        If ListBoxDocumentTypes.SelectedItem = Nothing Then
            vChecks = False
            sMessage = sMessage & "Please select Document Type" & vbCrLf
        End If

        If txtFileName.Text = vbNullString Then
            vChecks = False
            sMessage = sMessage & "Document name cannot be empty" & vbCrLf
        End If

        If Not vChecks Then
            MessageBox.Show(sMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return vChecks
    End Function

    Private Sub ToolStripMenuItemShowThumbs_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemShowThumbs.Click
        ToolStripMenuItemShowThumbs.Checked = Not ToolStripMenuItemShowThumbs.Checked

        If ToolStripMenuItemShowThumbs.Checked Then
            My.Settings.pdfShowThumbs = 2
        Else
            My.Settings.pdfShowThumbs = 0
        End If
    End Sub

    Private Sub ButtonOpenFolder_Click(sender As Object, e As EventArgs) Handles ButtonOpenFolder.Click
        Dim selectFolderDialog As New FolderBrowserDialog

        With selectFolderDialog
            .RootFolder = Environment.SpecialFolder.Desktop
            .SelectedPath = My.Settings.saveFolderPath.ToString
            If .ShowDialog = DialogResult.OK Then
                My.Settings.saveFolderPath = .SelectedPath
                txtFolderPath.Text = My.Settings.saveFolderPath
            End If
        End With

    End Sub

    Private Sub ButtonMovePage_Click(sender As Object, e As EventArgs) Handles ButtonMovePage.Click
        Dim activePdf As AcroPDDoc
        Dim i As Integer
        Dim counter As Integer = -1
        Dim saveFileName As String
        Dim oListItem As ListViewItem
        Dim IsSaved As Boolean

        activePdf = pdfDoc.GetPDDoc

        If ListBoxPages.SelectedIndices.Count > 0 Then

            oListItem = ListViewAttachments.SelectedItems(0)
            saveFileName = oListItem.Text & "_" & oListItem.SubItems(3).Text & "_" & oListItem.SubItems(1).Text

            For Each i In ListBoxPages.SelectedIndices

                activePdf.MovePage(counter, i)
                counter += 1
                'ListBoxPages.SetSelected(i, False)

            Next

            IsSaved = activePdf.Save(PDSaveFlags.PDSaveFull, Path.Combine(My.Resources.temporaryFolderPath, saveFileName))

            If IsSaved <> -1 Then

                ToolStripLabelMessages.Text = "Acrobat does not support editing"
                ToolStripLabelMessages.ForeColor = System.Drawing.Color.DeepPink

            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim activePdf As AcroPDDoc
        Dim oListItem As ListViewItem
        Dim saveFileName As String
        Dim IsSaved As Boolean

        activePdf = pdfDoc.GetPDDoc

        If ListViewAttachments.SelectedItems.Count = 1 Then

            oListItem = ListViewAttachments.SelectedItems(0)
            saveFileName = oListItem.Text & "_" & oListItem.SubItems(3).Text & "_" & oListItem.SubItems(1).Text

            IsSaved = activePdf.Save(PDSaveFlags.PDSaveFull, Path.Combine(My.Resources.temporaryFolderPath, saveFileName))
            If IsSaved <> -1 Then

                ToolStripLabelMessages.Text = "Acrobat does not support editing"
                ToolStripLabelMessages.ForeColor = System.Drawing.Color.DeepPink

            End If
        Else

            ToolStripLabelMessages.Text = "To save select only one item"
            ToolStripLabelMessages.ForeColor = System.Drawing.Color.DeepPink

        End If

    End Sub

    Private Sub ToolStripMenuItemSuggestionsSP_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSuggestionsSP.Click
        Try
            System.Diagnostics.Process.Start("https://eu001-sp.shell.com/sites/AAAAA4854/GlobalProjects/TMToolkit/myRTV/Global-RTV-Repository/Lists/dmtHelper/AllItems.aspx")
        Catch

        End Try
    End Sub

    Private Sub EntitiesSPListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EntitiesSPListToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("https://eu001-sp.shell.com/sites/AAAAA4854/GlobalProjects/TMToolkit/myRTV/Global-RTV-Repository/Lists/DmtEntities/AllItems.aspx")
        Catch

        End Try
    End Sub

    Private Sub CoCdsSPListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoCdsSPListToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("https://eu001-sp.shell.com/sites/AAAAA4854/GlobalProjects/TMToolkit/myRTV/Global-RTV-Repository/Lists/DmtCoCd/AllItems.aspx")
        Catch

        End Try
    End Sub

    Private Sub ToolStripMenuItemTopWindow_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTopWindow.Click
        ToolStripMenuItemTopWindow.Checked = Not ToolStripMenuItemTopWindow.Checked
        My.Settings.topWindow = ToolStripMenuItemTopWindow.Checked
    End Sub

    Private Sub ToolStripMenuItemSelectSuggestions_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSelectSuggestions.Click
        If ToolStripMenuItemShowSuggestions.Checked Then
            ToolStripMenuItemSelectSuggestions.Enabled = True
            ToolStripMenuItemSelectSuggestions.Checked = Not ToolStripMenuItemSelectSuggestions.Checked
            My.Settings.selectSuggestions = ToolStripMenuItemSelectSuggestions.Checked
        End If
    End Sub
End Class