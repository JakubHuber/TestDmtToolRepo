Imports Newtonsoft.Json

Public Class FormSpConnections
    Private Sub FormSpConnections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oConn As Connection

        Dim oSpConnections As RootObject = JsonConvert.DeserializeObject(Of RootObject)(My.Resources.jsonConnections)

        For Each oConn In oSpConnections.Connection
            cmbConnectionNames.Items.Add(oConn.Name)
        Next

    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click

        If cmbConnectionNames.Text = vbNullString Then
            MsgBox("Please, choose connection before leaving", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        My.Settings.connName = cmbConnectionNames.Text
        My.Settings.firstRun = False

        Me.Close()
    End Sub
End Class