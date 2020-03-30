Imports Microsoft.Office.Tools.Ribbon

Public Class RibbonDmt



    Private Sub RibbonDmt_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonDmt_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonDmt.Click
        Dim oDmtFormMain As New DmtFormMain
        Dim oSpConnectionsForm As New FormSpConnections

        If My.Settings.firstRun Then
            oSpConnectionsForm.ShowDialog()
        End If


        If Not Globals.dmtAddin.FormLoaded Then
            oDmtFormMain.Show()
        End If
    End Sub

    Private Sub ButtonSpOption_Click(sender As Object, e As RibbonControlEventArgs) Handles ButtonSpOption.Click
        Dim oSpConnectionsForm As New FormSpConnections

        oSpConnectionsForm.ShowDialog()
    End Sub
End Class
