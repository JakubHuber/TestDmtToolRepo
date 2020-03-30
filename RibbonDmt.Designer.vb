Partial Class RibbonDmt
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabDmt = Me.Factory.CreateRibbonTab
        Me.groupDmt = Me.Factory.CreateRibbonGroup
        Me.ButtonDmt = Me.Factory.CreateRibbonButton
        Me.ButtonSpOption = Me.Factory.CreateRibbonButton
        Me.tabDmt.SuspendLayout()
        Me.groupDmt.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDmt
        '
        Me.tabDmt.Groups.Add(Me.groupDmt)
        Me.tabDmt.Label = "Dmt"
        Me.tabDmt.Name = "tabDmt"
        Me.tabDmt.Position = Me.Factory.RibbonPosition.AfterOfficeId("TabMail")
        '
        'groupDmt
        '
        Me.groupDmt.Items.Add(Me.ButtonDmt)
        Me.groupDmt.Items.Add(Me.ButtonSpOption)
        Me.groupDmt.Label = "Dmt tools"
        Me.groupDmt.Name = "groupDmt"
        '
        'ButtonDmt
        '
        Me.ButtonDmt.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.ButtonDmt.Label = "Dmt"
        Me.ButtonDmt.Name = "ButtonDmt"
        Me.ButtonDmt.OfficeImageId = "GroupPivotTableSort"
        Me.ButtonDmt.ShowImage = True
        '
        'ButtonSpOption
        '
        Me.ButtonSpOption.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.ButtonSpOption.Label = "SP connection"
        Me.ButtonSpOption.Name = "ButtonSpOption"
        Me.ButtonSpOption.OfficeImageId = "GroupSharepointLists"
        Me.ButtonSpOption.ShowImage = True
        '
        'RibbonDmt
        '
        Me.Name = "RibbonDmt"
        Me.RibbonType = "Microsoft.Outlook.Explorer"
        Me.Tabs.Add(Me.tabDmt)
        Me.tabDmt.ResumeLayout(False)
        Me.tabDmt.PerformLayout()
        Me.groupDmt.ResumeLayout(False)
        Me.groupDmt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabDmt As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents groupDmt As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents ButtonDmt As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents ButtonSpOption As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property RibbonDmt() As RibbonDmt
        Get
            Return Me.GetRibbon(Of RibbonDmt)()
        End Get
    End Property
End Class
