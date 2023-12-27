<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainNew
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainNew))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarDockingMenuItem1 = New DevExpress.XtraBars.BarDockingMenuItem()
        Me.BarDockingMenuItem2 = New DevExpress.XtraBars.BarDockingMenuItem()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarDockingMenuItem3 = New DevExpress.XtraBars.BarDockingMenuItem()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.accMain = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.aceBarcode = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.aceAMH = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlSeparator3 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        Me.aceSetup = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.aceTestCode = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.aceComm = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlSeparator1 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        Me.AccordionControlElement8 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.aceHomePage = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.aceRemote = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.DocumentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.TabView = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement4 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement5 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlSeparator2 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.BarDockingMenuItem1, Me.BarDockingMenuItem2, Me.BarSubItem1, Me.BarDockingMenuItem3})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 5
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Size = New System.Drawing.Size(1498, 67)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        '
        'BarDockingMenuItem1
        '
        Me.BarDockingMenuItem1.Caption = "BarDockingMenuItem1"
        Me.BarDockingMenuItem1.Id = 1
        Me.BarDockingMenuItem1.Name = "BarDockingMenuItem1"
        '
        'BarDockingMenuItem2
        '
        Me.BarDockingMenuItem2.Caption = "BarDockingMenuItem2"
        Me.BarDockingMenuItem2.Id = 2
        Me.BarDockingMenuItem2.Name = "BarDockingMenuItem2"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "BarSubItem1"
        Me.BarSubItem1.Id = 3
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarDockingMenuItem3)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarDockingMenuItem3
        '
        Me.BarDockingMenuItem3.Caption = "BarDockingMenuItem3"
        Me.BarDockingMenuItem3.Id = 4
        Me.BarDockingMenuItem3.Name = "BarDockingMenuItem3"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 972)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(1498, 27)
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.DockPanel1.Appearance.Options.UseBackColor = True
        Me.DockPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DockPanel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DockPanel1.ID = New System.Guid("eee295a0-fdfc-4187-8e13-b5e290e234c2")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 67)
        Me.DockPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.AllowDockAsTabbedDocument = False
        Me.DockPanel1.Options.AllowDockBottom = False
        Me.DockPanel1.Options.AllowDockFill = False
        Me.DockPanel1.Options.AllowDockRight = False
        Me.DockPanel1.Options.AllowDockTop = False
        Me.DockPanel1.Options.AllowFloating = False
        Me.DockPanel1.Options.FloatOnDblClick = False
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.Options.ShowMaximizeButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(301, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(301, 905)
        Me.DockPanel1.Text = "작업메뉴"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.AccordionControl1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(5, 48)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(289, 852)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.accMain, Me.AccordionControlSeparator3, Me.aceSetup, Me.AccordionControlSeparator1, Me.AccordionControlElement8})
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.Size = New System.Drawing.Size(289, 852)
        Me.AccordionControl1.TabIndex = 0
        Me.AccordionControl1.Text = "AccordionControl1"
        '
        'accMain
        '
        Me.accMain.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.aceBarcode, Me.aceAMH})
        Me.accMain.Expanded = True
        Me.accMain.ImageOptions.ImageLayoutMode = DevExpress.XtraBars.Navigation.ImageLayoutMode.Stretch
        Me.accMain.ImageOptions.SvgImage = CType(resources.GetObject("accMain.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.accMain.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.accMain.Name = "accMain"
        Me.accMain.Text = "Main"
        '
        'aceBarcode
        '
        Me.aceBarcode.Appearance.Disabled.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceBarcode.Appearance.Disabled.Options.UseFont = True
        Me.aceBarcode.Appearance.Hovered.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceBarcode.Appearance.Hovered.Options.UseFont = True
        Me.aceBarcode.Appearance.Normal.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceBarcode.Appearance.Normal.Options.UseFont = True
        Me.aceBarcode.HeaderTemplate.AddRange(New DevExpress.XtraBars.Navigation.HeaderElementInfo() {New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)})
        Me.aceBarcode.Name = "aceBarcode"
        Me.aceBarcode.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.aceBarcode.Text = "      Barcode"
        '
        'aceAMH
        '
        Me.aceAMH.Appearance.Normal.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceAMH.Appearance.Normal.Options.UseFont = True
        Me.aceAMH.Name = "aceAMH"
        Me.aceAMH.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.aceAMH.Text = "      AMH"
        '
        'AccordionControlSeparator3
        '
        Me.AccordionControlSeparator3.Name = "AccordionControlSeparator3"
        '
        'aceSetup
        '
        Me.aceSetup.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.aceTestCode, Me.aceComm})
        Me.aceSetup.Expanded = True
        Me.aceSetup.ImageOptions.SvgImage = CType(resources.GetObject("aceSetup.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.aceSetup.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.aceSetup.Name = "aceSetup"
        Me.aceSetup.Text = "Setup"
        '
        'aceTestCode
        '
        Me.aceTestCode.Appearance.Disabled.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceTestCode.Appearance.Disabled.Options.UseFont = True
        Me.aceTestCode.Appearance.Normal.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceTestCode.Appearance.Normal.Options.UseFont = True
        Me.aceTestCode.Name = "aceTestCode"
        Me.aceTestCode.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.aceTestCode.Text = "      검사항목"
        '
        'aceComm
        '
        Me.aceComm.Appearance.Disabled.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceComm.Appearance.Disabled.Options.UseFont = True
        Me.aceComm.Appearance.Normal.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceComm.Appearance.Normal.Options.UseFont = True
        Me.aceComm.Name = "aceComm"
        Me.aceComm.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.aceComm.Text = "      통신설정"
        '
        'AccordionControlSeparator1
        '
        Me.AccordionControlSeparator1.Name = "AccordionControlSeparator1"
        '
        'AccordionControlElement8
        '
        Me.AccordionControlElement8.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.aceHomePage, Me.aceRemote})
        Me.AccordionControlElement8.Expanded = True
        Me.AccordionControlElement8.ImageOptions.SvgImage = CType(resources.GetObject("AccordionControlElement8.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.AccordionControlElement8.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.AccordionControlElement8.Name = "AccordionControlElement8"
        Me.AccordionControlElement8.Text = "Support"
        '
        'aceHomePage
        '
        Me.aceHomePage.Appearance.Normal.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceHomePage.Appearance.Normal.Options.UseFont = True
        Me.aceHomePage.Name = "aceHomePage"
        Me.aceHomePage.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.aceHomePage.Text = "      (주)엠투아이소프트 홈페이지"
        '
        'aceRemote
        '
        Me.aceRemote.Appearance.Normal.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aceRemote.Appearance.Normal.Options.UseFont = True
        Me.aceRemote.Name = "aceRemote"
        Me.aceRemote.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.aceRemote.Text = "      원격요청"
        '
        'DocumentManager1
        '
        Me.DocumentManager1.MdiParent = Me
        Me.DocumentManager1.MenuManager = Me.RibbonControl
        Me.DocumentManager1.View = Me.TabView
        Me.DocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabView})
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement4, Me.AccordionControlElement5, Me.AccordionControlSeparator2})
        Me.AccordionControlElement3.Expanded = True
        Me.AccordionControlElement3.ImageOptions.ImageLayoutMode = DevExpress.XtraBars.Navigation.ImageLayoutMode.Stretch
        Me.AccordionControlElement3.ImageOptions.SvgImage = CType(resources.GetObject("AccordionControlElement3.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Text = "Main"
        '
        'AccordionControlElement4
        '
        Me.AccordionControlElement4.HeaderTemplate.AddRange(New DevExpress.XtraBars.Navigation.HeaderElementInfo() {New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl), New DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)})
        Me.AccordionControlElement4.Name = "AccordionControlElement4"
        Me.AccordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement4.Text = "      Barcode"
        '
        'AccordionControlElement5
        '
        Me.AccordionControlElement5.Name = "AccordionControlElement5"
        Me.AccordionControlElement5.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement5.Text = "      AMH"
        '
        'AccordionControlSeparator2
        '
        Me.AccordionControlSeparator2.Name = "AccordionControlSeparator2"
        '
        'frmMainNew
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1498, 999)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMainNew"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "M2ISOFT"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents BarDockingMenuItem1 As DevExpress.XtraBars.BarDockingMenuItem
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DocumentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents TabView As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents BarDockingMenuItem2 As DevExpress.XtraBars.BarDockingMenuItem
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarDockingMenuItem3 As DevExpress.XtraBars.BarDockingMenuItem
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents accMain As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents aceBarcode As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents aceSetup As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents aceTestCode As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents aceComm As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement4 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement5 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Private WithEvents AccordionControlSeparator2 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents aceAMH As DevExpress.XtraBars.Navigation.AccordionControlElement
    Private WithEvents AccordionControlSeparator3 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Private WithEvents AccordionControlSeparator1 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents AccordionControlElement8 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents aceHomePage As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents aceRemote As DevExpress.XtraBars.Navigation.AccordionControlElement
End Class
