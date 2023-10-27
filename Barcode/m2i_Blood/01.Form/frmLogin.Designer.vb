<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.picAD = New System.Windows.Forms.PictureBox()
        Me.picLogo = New DevExpress.XtraEditors.PictureEdit()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtUserID = New DevExpress.XtraEditors.TextEdit()
        Me.txtPW = New DevExpress.XtraEditors.TextEdit()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.txtID = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.lblLink = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.picAD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPW.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picAD
        '
        Me.picAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picAD.Location = New System.Drawing.Point(12, 13)
        Me.picAD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picAD.Name = "picAD"
        Me.picAD.Size = New System.Drawing.Size(270, 430)
        Me.picAD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picAD.TabIndex = 13
        Me.picAD.TabStop = False
        '
        'picLogo
        '
        Me.picLogo.EditValue = CType(resources.GetObject("picLogo.EditValue"), Object)
        Me.picLogo.Location = New System.Drawing.Point(304, 13)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.picLogo.Properties.InitialImageOptions.Image = CType(resources.GetObject("PictureEdit1.Properties.InitialImageOptions.Image"), System.Drawing.Image)
        Me.picLogo.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image
        Me.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.picLogo.Size = New System.Drawing.Size(237, 84)
        Me.picLogo.TabIndex = 14
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AutoSize = True
        Me.GroupControl1.Controls.Add(Me.LayoutControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(304, 143)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(239, 193)
        Me.GroupControl1.TabIndex = 15
        Me.GroupControl1.Text = "사용자 인증"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.lblUser)
        Me.LayoutControl1.Controls.Add(Me.txtUserID)
        Me.LayoutControl1.Controls.Add(Me.txtPW)
        Me.LayoutControl1.Controls.Add(Me.btnLogin)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 29)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(492, 0, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(235, 162)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("돋움", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(12, 40)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(211, 51)
        Me.lblUser.TabIndex = 4
        Me.lblUser.Text = "사용자"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUserID
        '
        Me.txtUserID.EditValue = ""
        Me.txtUserID.Location = New System.Drawing.Point(12, 12)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.Appearance.Options.UseTextOptions = True
        Me.txtUserID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtUserID.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtUserID.Size = New System.Drawing.Size(211, 24)
        Me.txtUserID.StyleController = Me.LayoutControl1
        Me.txtUserID.TabIndex = 0
        '
        'txtPW
        '
        Me.txtPW.EditValue = ""
        Me.txtPW.Location = New System.Drawing.Point(12, 95)
        Me.txtPW.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPW.Name = "txtPW"
        Me.txtPW.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPW.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPW.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtPW.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPW.Size = New System.Drawing.Size(211, 24)
        Me.txtPW.StyleController = Me.LayoutControl1
        Me.txtPW.TabIndex = 2
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(12, 123)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(211, 27)
        Me.btnLogin.StyleController = Me.LayoutControl1
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Sign in"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.txtID, Me.layoutControlItem2, Me.layoutControlItem4, Me.LayoutControlItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(235, 162)
        '
        'txtID
        '
        Me.txtID.Control = Me.txtUserID
        Me.txtID.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.txtID.CustomizationFormText = "layoutControlItem1"
        Me.txtID.Location = New System.Drawing.Point(0, 0)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(215, 28)
        Me.txtID.TextLocation = DevExpress.Utils.Locations.Left
        Me.txtID.TextSize = New System.Drawing.Size(0, 0)
        Me.txtID.TextVisible = False
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.Control = Me.txtPW
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(0, 83)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Size = New System.Drawing.Size(215, 28)
        Me.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextVisible = False
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.btnLogin
        Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem4.Location = New System.Drawing.Point(0, 111)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Size = New System.Drawing.Size(215, 31)
        Me.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lblUser
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(215, 55)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(302, 105)
        Me.SeparatorControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Padding = New System.Windows.Forms.Padding(10, 12, 10, 12)
        Me.SeparatorControl2.Size = New System.Drawing.Size(239, 30)
        Me.SeparatorControl2.TabIndex = 16
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(304, 344)
        Me.SeparatorControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(10, 12, 10, 12)
        Me.SeparatorControl1.Size = New System.Drawing.Size(242, 30)
        Me.SeparatorControl1.TabIndex = 17
        '
        'lblLink
        '
        Me.lblLink.Appearance.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblLink.Appearance.Options.UseForeColor = True
        Me.lblLink.Location = New System.Drawing.Point(320, 425)
        Me.lblLink.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblLink.Name = "lblLink"
        Me.lblLink.Size = New System.Drawing.Size(224, 18)
        Me.lblLink.TabIndex = 19
        Me.lblLink.Text = "개발사 홈페이지(www.m2isoft.com)"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(373, 399)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(168, 18)
        Me.LabelControl1.TabIndex = 18
        Me.LabelControl1.Text = "Help Desk 0505-707-1515"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 456)
        Me.Controls.Add(Me.lblLink)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.picAD)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "로그인"
        CType(Me.picAD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPW.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picAD As PictureBox
    Friend WithEvents picLogo As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents lblUser As Label
    Friend WithEvents txtUserID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPW As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtID As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents lblLink As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
