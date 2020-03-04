Imports Acrobat
Imports System.Text.RegularExpressions
Imports System.Data

Public Class PdfExtractor
    Dim opdf As AcroPDDoc
    Dim oRegEx As Regex

    Public rawPdfText As StringBuilder
    Dim textLines() As String
    Public textNoSpecialChars As String
    Public POnumber As String

    Dim docTotal As Double
    Public IsUrgent As Boolean
    Public IsScan As Boolean
    Public IsInvoice As DmtDocStatuses
    Public docCurrency As String

    Public totalPattern As String
    Public creditNotePattern As String

    Public Sub New()
        IsScan = True
        Me.IsInvoice = DmtDocStatuses.Undefined
    End Sub

    Public Function findEntity(ByRef Entities As DataRowCollection) As Entity
        Dim vEntity As Entity = Nothing
        Dim EntityFound As Boolean
        Dim oRow As DataRow
        Dim matchRow As DataRow = Nothing

        oRegEx = New Regex("[^a-z0-9]+", RegexOptions.IgnoreCase)

        textNoSpecialChars = oRegEx.Replace(textNoSpecialChars, String.Empty)

        If Entities.Count > 0 Then

            For Each oRow In Entities

                oRegEx = New Regex(oRow(2).ToString, RegexOptions.IgnoreCase)

                If oRegEx.IsMatch(textNoSpecialChars) Then
                    EntityFound = True
                    matchRow = oRow
                    Exit For
                End If

            Next

        End If

        If EntityFound Then

            vEntity = New Entity
            vEntity.CoCd = matchRow(0)
            vEntity.EntityName = matchRow(1)

        End If

        Return vEntity

    End Function

    Public Sub ExtractAllText(ByRef vPdf As AcroPDDoc)
        Dim oHilite As AcroHiliteList
        Dim oPage As AcroPDPage
        Dim oSelectedText As AcroPDTextSelect
        Dim i As Integer
        Dim j As Integer

        opdf = vPdf
        oHilite = New AcroHiliteList
        oHilite.Add(0, 32767)
        rawPdfText = New StringBuilder

        For i = i To opdf.GetNumPages - 1

            oPage = opdf.AcquirePage(i)
            oSelectedText = oPage.CreatePageHilite(oHilite)

            If Not oSelectedText Is Nothing Then

                IsScan = False

                For j = 0 To oSelectedText.GetNumText - 1
                    rawPdfText.Append(oSelectedText.GetText(j).ToLower)
                Next

            End If

        Next

        textLines = rawPdfText.ToString.Split(vbCrLf)
        textNoSpecialChars = removeSpecialChars(rawPdfText.ToString)

    End Sub

    Private Function removeSpecialChars(ByRef sText As String) As String

        oRegEx = New Regex("[^0-9a-z-.,()+]+", RegexOptions.IgnoreCase And RegexOptions.Multiline)

        Return oRegEx.Replace(sText, " ")

    End Function

    Public Function findPoNumber() As String
        POnumber = vbNullString

        POnumber = getPattern(rawPdfText.ToString, "\b((45|47|49)\d{8}|(421|100)\d{7})\b")

        Return POnumber

    End Function

    Public Function findTotal() As String
        Dim vTotal As String

        vTotal = findTotalInArray(totalPattern)
        If vTotal = vbNullString Then

            vTotal = getPattern(textNoSpecialChars, totalPattern)

        End If

        If vTotal <> vbNullString Then
            docTotal = textCurrencyToDouble(vTotal)
        End If

        If docTotal > 0 Then IsInvoice = getDocumentStatusByWords()

        Return docTotal

    End Function

    Private Function findTotalInArray(ByRef sPattern As String) As String
        Dim i As Long
        Dim totalFound As String = vbNullString

        oRegEx = New Regex(sPattern, RegexOptions.IgnoreCase)

        If textLines.Length > 0 Then

            For i = 0 To UBound(textLines)

                If oRegEx.IsMatch(textLines(i)) Then
                    totalFound = oRegEx.Match(textLines(i)).Value.ToString
                    Exit For
                End If

            Next

        End If

        Return totalFound

    End Function

    Private Function getDocumentStatusByWords() As DmtDocStatuses
        oRegEx = New Regex(creditNotePattern, RegexOptions.IgnoreCase)

        If oRegEx.IsMatch(textNoSpecialChars) Then
            Return DmtDocStatuses.CreditNote
        Else
            Return DmtDocStatuses.Invoice
        End If

    End Function

    Public Function textCurrencyToDouble(ByRef currencyValue As String) As Double
        Dim decimalPlaces As Integer
        Dim cleanNumber As Double
        Dim IsNegative As Boolean
        Dim oMatch As Match
        Dim decimalSeparator As String

        'Leave only total part
        oRegEx = New Regex("([-+(]?\d+(.*?)[^\d\s][\d),.-]+)", RegexOptions.IgnoreCase)
        oMatch = oRegEx.Match(currencyValue)
        currencyValue = oMatch.Value
        'Check +/-
        If currencyValue.Substring(currencyValue.Length - 1, 1) = "-" Or currencyValue.Substring(currencyValue.Length - 1, 1) = "(" Then IsNegative = True
        'Get decimal separator
        decimalSeparator = getDecimalPlaceSeparator(currencyValue)
        'Get decimal places
        oRegEx = New Regex("\" & decimalSeparator & "(\d+)", RegexOptions.IgnoreCase)
        oMatch = oRegEx.Match(currencyValue)
        If oMatch.Success Then decimalPlaces = oMatch.Length - 1
        'Remove all dots, comas
        If currencyValue <> vbNullString Then
            oRegEx = New Regex("[^0-9]", RegexOptions.IgnoreCase)
            cleanNumber = (oRegEx.Replace(currencyValue, String.Empty)) / 10 ^ decimalPlaces

            If IsNegative Then
                cleanNumber = -1 * cleanNumber
                IsInvoice = DmtDocStatuses.CreditNote
            Else
                IsInvoice = DmtDocStatuses.Invoice
            End If

            Return cleanNumber

        Else
            Return 0
        End If

    End Function

    Private Function getDecimalPlaceSeparator(value As String) As String
        Dim comaPosition As Integer = -1
        Dim dotPosition As Integer = -1

        comaPosition = value.Length - value.IndexOf(",")
        comaPosition = value.Length - value.IndexOf(".")

        If comaPosition < dotPosition Then
            Return ","
        Else
            Return "."
        End If

    End Function

    Public Function getPattern(ByRef sText As String, ByRef sPattern As String) As String
        Dim oMatch As Match

        oMatch = oRegEx.Match(sText, sPattern, RegexOptions.IgnoreCase)

        If oMatch.Success Then
            Return oMatch.Value.ToString
        End If

    End Function

    Function guessDocType(erpValue As String) As String
        Dim guess As String = vbNullString

        If POnumber <> vbNullString And IsInvoice = DmtDocStatuses.Invoice Then

            Select Case erpValue
                Case "P16", "P94"
                    guess = DmtDocTypes.TP_PO_INVOICE_LIV.ToString
                Case "P49", "P53"
                    guess = DmtDocTypes.ZMMINVOICE.ToString
            End Select

        ElseIf POnumber <> vbNullString And IsInvoice = DmtDocStatuses.CreditNote Then

            Select Case erpValue
                Case "P16", "P94"
                    guess = DmtDocTypes.TP_PO_CREDITNOTE_LIV.ToString
                Case "P49", "P53"
                    guess = DmtDocTypes.ZMMCREDNOTE.ToString
            End Select

        ElseIf POnumber = vbNullString And IsInvoice = DmtDocStatuses.Invoice Then

            Select Case erpValue
                Case "P16", "P94"
                    guess = DmtDocTypes.TP_NON_PO_INVOICE_FI.ToString
                Case "P49", "P53"
                    guess = DmtDocTypes.ZFIINVOICE.ToString
            End Select

        ElseIf POnumber = vbNullString And IsInvoice = DmtDocStatuses.CreditNote Then

            Select Case erpValue
                Case "P16", "P94"
                    guess = DmtDocTypes.TP_NON_PO_CREDITNOTE_FI.ToString
                Case "P49", "P53"
                    guess = DmtDocTypes.ZFICREDNOTE
            End Select

        End If

        Return guess

    End Function

End Class
