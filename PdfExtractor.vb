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
    Public IsInvoice As dmtStatuses
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
        Dim i As Long
        Dim j As Long

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

    Public Function getPattern(ByRef sText As String, ByRef sPattern As String) As String
        Dim oMatch As Match

        oMatch = oRegEx.Match(sText, sPattern, RegexOptions.IgnoreCase)

        If oMatch.Success Then
            Return oMatch.Value.ToString
        End If

    End Function

End Class
