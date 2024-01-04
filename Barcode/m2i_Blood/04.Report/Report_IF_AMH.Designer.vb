<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Report_IF_AMH
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Report_IF_AMH))
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.lblAge = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBirth = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReceiptDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAcceptDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblChartNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDoctor = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMedOffice = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPTNM = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.lblAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.picAFC = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.AMHResultLine = New DevExpress.XtraReports.UI.XRLine()
        Me.lblAMHComment3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHComment2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHComment1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHResult = New DevExpress.XtraReports.UI.XRLabel()
        Me.picAMHResult = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAge, Me.lblBirth, Me.lblReceiptDate, Me.lblAcceptDate, Me.lblChartNo, Me.lblDoctor, Me.lblMedOffice, Me.lblPTNM})
        Me.TopMargin.Font = New System.Drawing.Font("맑은 고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TopMargin.HeightF = 277.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.StylePriority.UseFont = False
        '
        'lblAge
        '
        Me.lblAge.LocationFloat = New DevExpress.Utils.PointFloat(491.67!, 232.0!)
        Me.lblAge.Multiline = True
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAge.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        '
        'lblBirth
        '
        Me.lblBirth.LocationFloat = New DevExpress.Utils.PointFloat(491.67!, 206.0!)
        Me.lblBirth.Multiline = True
        Me.lblBirth.Name = "lblBirth"
        Me.lblBirth.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBirth.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        '
        'lblReceiptDate
        '
        Me.lblReceiptDate.LocationFloat = New DevExpress.Utils.PointFloat(491.6669!, 181.6666!)
        Me.lblReceiptDate.Multiline = True
        Me.lblReceiptDate.Name = "lblReceiptDate"
        Me.lblReceiptDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceiptDate.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        '
        'lblAcceptDate
        '
        Me.lblAcceptDate.LocationFloat = New DevExpress.Utils.PointFloat(491.6669!, 158.5417!)
        Me.lblAcceptDate.Multiline = True
        Me.lblAcceptDate.Name = "lblAcceptDate"
        Me.lblAcceptDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAcceptDate.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        '
        'lblChartNo
        '
        Me.lblChartNo.LocationFloat = New DevExpress.Utils.PointFloat(127.0833!, 232.0!)
        Me.lblChartNo.Multiline = True
        Me.lblChartNo.Name = "lblChartNo"
        Me.lblChartNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblChartNo.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        '
        'lblDoctor
        '
        Me.lblDoctor.LocationFloat = New DevExpress.Utils.PointFloat(127.0833!, 206.0!)
        Me.lblDoctor.Multiline = True
        Me.lblDoctor.Name = "lblDoctor"
        Me.lblDoctor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDoctor.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        '
        'lblMedOffice
        '
        Me.lblMedOffice.LocationFloat = New DevExpress.Utils.PointFloat(127.0833!, 181.6666!)
        Me.lblMedOffice.Multiline = True
        Me.lblMedOffice.Name = "lblMedOffice"
        Me.lblMedOffice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMedOffice.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        '
        'lblPTNM
        '
        Me.lblPTNM.LocationFloat = New DevExpress.Utils.PointFloat(127.0833!, 158.5416!)
        Me.lblPTNM.Multiline = True
        Me.lblPTNM.Name = "lblPTNM"
        Me.lblPTNM.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPTNM.SizeF = New System.Drawing.SizeF(150.0!, 20.00006!)
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAddress})
        Me.BottomMargin.HeightF = 41.0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'lblAddress
        '
        Me.lblAddress.LocationFloat = New DevExpress.Utils.PointFloat(236.1665!, 0!)
        Me.lblAddress.Multiline = True
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAddress.SizeF = New System.Drawing.SizeF(494.1666!, 38.20668!)
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.picAFC, Me.XrLabel1, Me.AMHResultLine, Me.lblAMHComment3, Me.lblAMHComment2, Me.lblAMHComment1, Me.lblAMHResult, Me.picAMHResult})
        Me.Detail.HeightF = 837.6267!
        Me.Detail.Name = "Detail"
        '
        'picAFC
        '
        Me.picAFC.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("picAFC.ImageSource"))
        Me.picAFC.LocationFloat = New DevExpress.Utils.PointFloat(40.41667!, 412.5!)
        Me.picAFC.Name = "picAFC"
        Me.picAFC.SizeF = New System.Drawing.SizeF(677.7083!, 173.3333!)
        Me.picAFC.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(307.5!, 303.4167!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(346.8137!, 15.71082!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "* AMH 결과가 빨간색 선으로 표시됩니다"
        '
        'AMHResultLine
        '
        Me.AMHResultLine.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Top
        Me.AMHResultLine.BorderWidth = 1.0!
        Me.AMHResultLine.ForeColor = System.Drawing.Color.Red
        Me.AMHResultLine.LineWidth = 2.0!
        Me.AMHResultLine.LocationFloat = New DevExpress.Utils.PointFloat(334.0!, 130.0!)
        Me.AMHResultLine.Name = "AMHResultLine"
        Me.AMHResultLine.SizeF = New System.Drawing.SizeF(362.0!, 22.92!)
        Me.AMHResultLine.StylePriority.UseBorderWidth = False
        Me.AMHResultLine.StylePriority.UseForeColor = False
        '
        'lblAMHComment3
        '
        Me.lblAMHComment3.LocationFloat = New DevExpress.Utils.PointFloat(40.41667!, 740.3351!)
        Me.lblAMHComment3.Multiline = True
        Me.lblAMHComment3.Name = "lblAMHComment3"
        Me.lblAMHComment3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment3.SizeF = New System.Drawing.SizeF(677.7083!, 46.875!)
        '
        'lblAMHComment2
        '
        Me.lblAMHComment2.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblAMHComment2.LocationFloat = New DevExpress.Utils.PointFloat(40.41667!, 623.96!)
        Me.lblAMHComment2.Multiline = True
        Me.lblAMHComment2.Name = "lblAMHComment2"
        Me.lblAMHComment2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment2.SizeF = New System.Drawing.SizeF(253.125!, 76.04163!)
        Me.lblAMHComment2.StylePriority.UseFont = False
        '
        'lblAMHComment1
        '
        Me.lblAMHComment1.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblAMHComment1.LocationFloat = New DevExpress.Utils.PointFloat(40.41667!, 147.7916!)
        Me.lblAMHComment1.Multiline = True
        Me.lblAMHComment1.Name = "lblAMHComment1"
        Me.lblAMHComment1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment1.SizeF = New System.Drawing.SizeF(249.1667!, 130.2084!)
        Me.lblAMHComment1.SnapLineMargin = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 10, 0, 100.0!)
        Me.lblAMHComment1.StylePriority.UseFont = False
        Me.lblAMHComment1.StylePriority.UseTextAlignment = False
        Me.lblAMHComment1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAMHResult
        '
        Me.lblAMHResult.Font = New System.Drawing.Font("맑은 고딕", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblAMHResult.ForeColor = System.Drawing.Color.Red
        Me.lblAMHResult.LocationFloat = New DevExpress.Utils.PointFloat(172.7466!, 103.0!)
        Me.lblAMHResult.Multiline = True
        Me.lblAMHResult.Name = "lblAMHResult"
        Me.lblAMHResult.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHResult.SizeF = New System.Drawing.SizeF(37.80635!, 23.95832!)
        Me.lblAMHResult.StylePriority.UseFont = False
        Me.lblAMHResult.StylePriority.UseForeColor = False
        Me.lblAMHResult.Text = "lblAMHResult"
        '
        'picAMHResult
        '
        Me.picAMHResult.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
        Me.picAMHResult.ImageUrl = "C:\Users\M2I_SOFT\Desktop\Git\m2isoft_Barcode_new\Barcode\m2i_Blood\05.Rpt\AMH_Fo" &
    "rm_01\00.AMH_BACK_00.png"
        Me.picAMHResult.LocationFloat = New DevExpress.Utils.PointFloat(307.5!, 103.0!)
        Me.picAMHResult.Name = "picAMHResult"
        Me.picAMHResult.SizeF = New System.Drawing.SizeF(397.9167!, 189.5833!)
        Me.picAMHResult.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'Report_IF_AMH
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.DrawWatermark = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(33, 40, 277, 41)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "18.2"
        Me.Watermark.Image = CType(resources.GetObject("Report_IF_AMH.Watermark.Image"), System.Drawing.Image)
        Me.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Stretch
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents picAMHResult As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents lblAge As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBirth As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReceiptDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAcceptDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblChartNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDoctor As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMedOffice As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPTNM As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAMHComment3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAMHComment2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAMHComment1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAMHResult As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents AMHResultLine As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents picAFC As DevExpress.XtraReports.UI.XRPictureBox
End Class
