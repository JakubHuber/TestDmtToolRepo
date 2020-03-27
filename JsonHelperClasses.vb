Public Class Connection
    Public Property Name As String
    Public Property DmtServerName As String
    Public Property CoCdGUID As String
    Public Property ToolVersionGUID As String
    Public Property EntitiesGUID As String
    Public Property HelpersGUID As String
    Public Property TrackingGUID As String
End Class

Public Class RootObject
    Public Property Connection As List(Of Connection)
End Class


Module JsonHelperClasses

End Module
