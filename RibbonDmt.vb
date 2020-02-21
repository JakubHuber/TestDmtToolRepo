Imports Microsoft.Office.Tools.Ribbon

Public Class RibbonDmt

    Private Sub RibbonDmt_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonDmt_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonDmt.Click
        Dim oDmtFormMain As New DmtFormMain

        oDmtFormMain.Show()

    End Sub
End Class
