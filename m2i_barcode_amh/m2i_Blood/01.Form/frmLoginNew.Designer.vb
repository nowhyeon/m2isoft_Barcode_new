<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoginNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginNew))
        Me.picLogin = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.chkSaveYN = New System.Windows.Forms.CheckBox()
        Me.lblUsernm = New System.Windows.Forms.Label()
        Me.txtUserID = New DevExpress.XtraEditors.TextEdit()
        Me.txtPassword = New DevExpress.XtraEditors.TextEdit()
        Me.btnLogin = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.layoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.layoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.cboSkin = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnExit = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.picLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSkin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picLogin
        '
        Me.picLogin.Cursor = System.Windows.Forms.Cursors.Default
        Me.picLogin.Location = New System.Drawing.Point(12, 12)
        Me.picLogin.Name = "picLogin"
        Me.picLogin.Size = New System.Drawing.Size(263, 465)
        Me.picLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogin.TabIndex = 0
        Me.picLogin.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(295, 16)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(263, 76)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(295, 96)
        Me.SeparatorControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Padding = New System.Windows.Forms.Padding(10, 12, 10, 12)
        Me.SeparatorControl2.Size = New System.Drawing.Size(263, 28)
        Me.SeparatorControl2.TabIndex = 9
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AutoSize = True
        Me.GroupControl1.Controls.Add(Me.LayoutControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(295, 129)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(263, 222)
        Me.GroupControl1.TabIndex = 10
        Me.GroupControl1.Text = "※ 사용자 인증"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.chkSaveYN)
        Me.LayoutControl1.Controls.Add(Me.lblUsernm)
        Me.LayoutControl1.Controls.Add(Me.txtUserID)
        Me.LayoutControl1.Controls.Add(Me.txtPassword)
        Me.LayoutControl1.Controls.Add(Me.btnLogin)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(2, 26)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(754, 239, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(259, 194)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'chkSaveYN
        '
        Me.chkSaveYN.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSaveYN.Location = New System.Drawing.Point(79, 126)
        Me.chkSaveYN.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSaveYN.Name = "chkSaveYN"
        Me.chkSaveYN.Size = New System.Drawing.Size(168, 25)
        Me.chkSaveYN.TabIndex = 5
        Me.chkSaveYN.Text = "로그인 저장"
        Me.chkSaveYN.UseVisualStyleBackColor = True
        '
        'lblUsernm
        '
        Me.lblUsernm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUsernm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblUsernm.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.lblUsernm.Location = New System.Drawing.Point(12, 45)
        Me.lblUsernm.Name = "lblUsernm"
        Me.lblUsernm.Size = New System.Drawing.Size(235, 44)
        Me.lblUsernm.TabIndex = 4
        Me.lblUsernm.Text = "사용자"
        Me.lblUsernm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtUserID.Properties.ContextImageOptions.SvgImage = CType(resources.GetObject("txtUserID.Properties.ContextImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.txtUserID.Properties.ContextImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.txtUserID.Size = New System.Drawing.Size(235, 29)
        Me.txtUserID.StyleController = Me.LayoutControl1
        Me.txtUserID.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.EditValue = ""
        Me.txtPassword.Location = New System.Drawing.Point(12, 93)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPassword.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtPassword.Properties.ContextImageOptions.SvgImage = CType(resources.GetObject("txtPassword.Properties.ContextImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.txtPassword.Properties.ContextImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.txtPassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(235, 29)
        Me.txtPassword.StyleController = Me.LayoutControl1
        Me.txtPassword.TabIndex = 2
        '
        'btnLogin
        '
        Me.btnLogin.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.btnLogin.Appearance.Options.UseFont = True
        Me.btnLogin.ImageOptions.Image = CType(resources.GetObject("btnLogin.ImageOptions.Image"), System.Drawing.Image)
        Me.btnLogin.Location = New System.Drawing.Point(12, 155)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(235, 27)
        Me.btnLogin.StyleController = Me.LayoutControl1
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Sign in"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlItem1, Me.layoutControlItem2, Me.layoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(259, 194)
        '
        'layoutControlItem1
        '
        Me.layoutControlItem1.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.layoutControlItem1.AppearanceItemCaption.Options.UseFont = True
        Me.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = True
        Me.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.layoutControlItem1.Control = Me.txtUserID
        Me.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.layoutControlItem1.CustomizationFormText = "layoutControlItem1"
        Me.layoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.layoutControlItem1.Name = "layoutControlItem1"
        Me.layoutControlItem1.Size = New System.Drawing.Size(239, 33)
        Me.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Left
        Me.layoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem1.TextVisible = False
        '
        'layoutControlItem2
        '
        Me.layoutControlItem2.AppearanceItemCaption.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.layoutControlItem2.AppearanceItemCaption.Options.UseFont = True
        Me.layoutControlItem2.AppearanceItemCaption.Options.UseTextOptions = True
        Me.layoutControlItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.layoutControlItem2.Control = Me.txtPassword
        Me.layoutControlItem2.CustomizationFormText = "layoutControlItem2"
        Me.layoutControlItem2.Location = New System.Drawing.Point(0, 81)
        Me.layoutControlItem2.Name = "layoutControlItem2"
        Me.layoutControlItem2.Size = New System.Drawing.Size(239, 33)
        Me.layoutControlItem2.Text = "암호 : "
        Me.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left
        Me.layoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem2.TextVisible = False
        '
        'layoutControlItem4
        '
        Me.layoutControlItem4.Control = Me.btnLogin
        Me.layoutControlItem4.CustomizationFormText = "layoutControlItem4"
        Me.layoutControlItem4.Location = New System.Drawing.Point(0, 143)
        Me.layoutControlItem4.Name = "layoutControlItem4"
        Me.layoutControlItem4.Size = New System.Drawing.Size(239, 31)
        Me.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left
        Me.layoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.layoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.lblUsernm
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 33)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(239, 48)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.chkSaveYN
        Me.LayoutControlItem5.Location = New System.Drawing.Point(67, 114)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(172, 29)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 114)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(67, 29)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(295, 354)
        Me.SeparatorControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Padding = New System.Windows.Forms.Padding(10, 12, 10, 12)
        Me.SeparatorControl1.Size = New System.Drawing.Size(263, 30)
        Me.SeparatorControl1.TabIndex = 11
        '
        'cboSkin
        '
        Me.cboSkin.Location = New System.Drawing.Point(393, 459)
        Me.cboSkin.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cboSkin.Name = "cboSkin"
        Me.cboSkin.Properties.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.cboSkin.Properties.Appearance.Options.UseFont = True
        Me.cboSkin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSkin.Properties.ContextImageOptions.SvgImage = CType(resources.GetObject("cboSkin.Properties.ContextImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cboSkin.Properties.ContextImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.cboSkin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboSkin.Size = New System.Drawing.Size(186, 29)
        Me.cboSkin.TabIndex = 14
        Me.cboSkin.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!)
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(338, 423)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(175, 20)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "Help Desk 0505-707-1515"
        '
        'btnExit
        '
        Me.btnExit.Appearance.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Appearance.Options.UseFont = True
        Me.btnExit.ImageOptions.SvgImage = CType(resources.GetObject("btnExit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnExit.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.btnExit.Location = New System.Drawing.Point(309, 387)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(235, 29)
        Me.btnExit.TabIndex = 16
        Me.btnExit.Text = "종료"
        '
        'frmLoginNew
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(579, 489)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.cboSkin)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.picLogin)
        Me.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoginNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.picLogin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSkin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picLogin As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents chkSaveYN As CheckBox
    Friend WithEvents lblUsernm As Label
    Friend WithEvents txtUserID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnLogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents layoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents layoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents cboSkin As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
