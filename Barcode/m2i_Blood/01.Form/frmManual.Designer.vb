<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManual
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim WindowsUIButtonImageOptions1 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManual))
        Dim WindowsUIButtonImageOptions2 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim WindowsUIButtonImageOptions3 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Dim WindowsUIButtonImageOptions4 As DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions = New DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnFileOpen = New DevExpress.XtraEditors.SimpleButton()
        Me.menuBtn = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Me.txtBarcodeNo = New DevExpress.XtraEditors.TextEdit()
        Me.memoComment = New DevExpress.XtraEditors.MemoEdit()
        Me.txtFileNM = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtBarcodeNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.memoComment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFileNM.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnFileOpen)
        Me.LayoutControl1.Controls.Add(Me.menuBtn)
        Me.LayoutControl1.Controls.Add(Me.txtBarcodeNo)
        Me.LayoutControl1.Controls.Add(Me.memoComment)
        Me.LayoutControl1.Controls.Add(Me.txtFileNM)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(433, 492)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnFileOpen
        '
        Me.btnFileOpen.Location = New System.Drawing.Point(394, 12)
        Me.btnFileOpen.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFileOpen.Name = "btnFileOpen"
        Me.btnFileOpen.Size = New System.Drawing.Size(27, 29)
        Me.btnFileOpen.StyleController = Me.LayoutControl1
        Me.btnFileOpen.TabIndex = 9
        Me.btnFileOpen.Text = "..."
        '
        'menuBtn
        '
        WindowsUIButtonImageOptions1.SvgImage = CType(resources.GetObject("WindowsUIButtonImageOptions1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsUIButtonImageOptions1.SvgImageSize = New System.Drawing.Size(20, 20)
        WindowsUIButtonImageOptions2.SvgImage = CType(resources.GetObject("WindowsUIButtonImageOptions2.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsUIButtonImageOptions2.SvgImageSize = New System.Drawing.Size(20, 20)
        WindowsUIButtonImageOptions3.SvgImage = CType(resources.GetObject("WindowsUIButtonImageOptions3.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsUIButtonImageOptions3.SvgImageSize = New System.Drawing.Size(20, 20)
        WindowsUIButtonImageOptions4.SvgImage = CType(resources.GetObject("WindowsUIButtonImageOptions4.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        WindowsUIButtonImageOptions4.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.menuBtn.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("단일출력", True, WindowsUIButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, "print", -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("저장", True, WindowsUIButtonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, "Save", -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("새로고침", True, WindowsUIButtonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, "Clear", -1, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("닫기", True, WindowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, "close", -1, False)})
        Me.menuBtn.ContentAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.menuBtn.Location = New System.Drawing.Point(12, 382)
        Me.menuBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.menuBtn.Name = "menuBtn"
        Me.menuBtn.Size = New System.Drawing.Size(409, 98)
        Me.menuBtn.TabIndex = 6
        Me.menuBtn.Text = "btnPrt"
        '
        'txtBarcodeNo
        '
        Me.txtBarcodeNo.Location = New System.Drawing.Point(85, 45)
        Me.txtBarcodeNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBarcodeNo.Name = "txtBarcodeNo"
        Me.txtBarcodeNo.Size = New System.Drawing.Size(336, 24)
        Me.txtBarcodeNo.StyleController = Me.LayoutControl1
        Me.txtBarcodeNo.TabIndex = 4
        '
        'memoComment
        '
        Me.memoComment.Location = New System.Drawing.Point(85, 73)
        Me.memoComment.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.memoComment.Name = "memoComment"
        Me.memoComment.Size = New System.Drawing.Size(336, 305)
        Me.memoComment.StyleController = Me.LayoutControl1
        Me.memoComment.TabIndex = 5
        '
        'txtFileNM
        '
        Me.txtFileNM.Location = New System.Drawing.Point(85, 12)
        Me.txtFileNM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFileNM.Name = "txtFileNM"
        Me.txtFileNM.Size = New System.Drawing.Size(305, 24)
        Me.txtFileNM.StyleController = Me.LayoutControl1
        Me.txtFileNM.TabIndex = 7
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(433, 492)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtBarcodeNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 33)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(413, 28)
        Me.LayoutControlItem1.Text = "│ 바코드 : "
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(70, 18)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.memoComment
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 61)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(413, 309)
        Me.LayoutControlItem2.Text = "│ 코멘트 :"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(70, 18)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.menuBtn
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 370)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(5, 78)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(413, 102)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtFileNM
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(382, 33)
        Me.LayoutControlItem4.Text = "│ 파일 : "
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(70, 18)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnFileOpen
        Me.LayoutControlItem6.Location = New System.Drawing.Point(382, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(31, 33)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(31, 33)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(31, 33)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'frmManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 492)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmManual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "바코드 수동 출력"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtBarcodeNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.memoComment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFileNM.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtBarcodeNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents memoComment As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents menuBtn As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFileNM As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnFileOpen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
End Class
