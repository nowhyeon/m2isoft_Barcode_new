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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblAMHComment3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHComment2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHComment1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHResult = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox2 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAge, Me.lblBirth, Me.lblReceiptDate, Me.lblAcceptDate, Me.lblChartNo, Me.lblDoctor, Me.lblMedOffice, Me.lblPTNM})
        Me.TopMargin.HeightF = 220.625!
        Me.TopMargin.Name = "TopMargin"
        '
        'lblAge
        '
        Me.lblAge.LocationFloat = New DevExpress.Utils.PointFloat(514.5833!, 171.875!)
        Me.lblAge.Multiline = True
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAge.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblAge.Text = "lblAge"
        '
        'lblBirth
        '
        Me.lblBirth.LocationFloat = New DevExpress.Utils.PointFloat(514.5833!, 148.9583!)
        Me.lblBirth.Multiline = True
        Me.lblBirth.Name = "lblBirth"
        Me.lblBirth.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBirth.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblBirth.Text = "lblBirth"
        '
        'lblReceiptDate
        '
        Me.lblReceiptDate.LocationFloat = New DevExpress.Utils.PointFloat(514.5833!, 125.2083!)
        Me.lblReceiptDate.Multiline = True
        Me.lblReceiptDate.Name = "lblReceiptDate"
        Me.lblReceiptDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceiptDate.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblReceiptDate.Text = "lblReceiptDate"
        '
        'lblAcceptDate
        '
        Me.lblAcceptDate.LocationFloat = New DevExpress.Utils.PointFloat(514.5833!, 102.0834!)
        Me.lblAcceptDate.Multiline = True
        Me.lblAcceptDate.Name = "lblAcceptDate"
        Me.lblAcceptDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAcceptDate.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblAcceptDate.Text = "lblAcceptDate"
        '
        'lblChartNo
        '
        Me.lblChartNo.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 171.875!)
        Me.lblChartNo.Multiline = True
        Me.lblChartNo.Name = "lblChartNo"
        Me.lblChartNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblChartNo.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblChartNo.Text = "lblChartNo"
        '
        'lblDoctor
        '
        Me.lblDoctor.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 148.9583!)
        Me.lblDoctor.Multiline = True
        Me.lblDoctor.Name = "lblDoctor"
        Me.lblDoctor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDoctor.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblDoctor.Text = "lblDoctor"
        '
        'lblMedOffice
        '
        Me.lblMedOffice.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 125.2083!)
        Me.lblMedOffice.Multiline = True
        Me.lblMedOffice.Name = "lblMedOffice"
        Me.lblMedOffice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMedOffice.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblMedOffice.Text = "lblMedOffice"
        '
        'lblPTNM
        '
        Me.lblPTNM.LocationFloat = New DevExpress.Utils.PointFloat(162.5!, 102.0834!)
        Me.lblPTNM.Multiline = True
        Me.lblPTNM.Name = "lblPTNM"
        Me.lblPTNM.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPTNM.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblPTNM.Text = "lblPTNM"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAMHComment3, Me.lblAMHComment2, Me.lblAMHComment1, Me.lblAMHResult, Me.XrPictureBox2, Me.XrPictureBox1})
        Me.Detail.HeightF = 841.875!
        Me.Detail.Name = "Detail"
        '
        'lblAMHComment3
        '
        Me.lblAMHComment3.LocationFloat = New DevExpress.Utils.PointFloat(82.29166!, 693.9581!)
        Me.lblAMHComment3.Multiline = True
        Me.lblAMHComment3.Name = "lblAMHComment3"
        Me.lblAMHComment3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment3.SizeF = New System.Drawing.SizeF(688.5417!, 46.875!)
        Me.lblAMHComment3.Text = "lblAMHComment3"
        '
        'lblAMHComment2
        '
        Me.lblAMHComment2.LocationFloat = New DevExpress.Utils.PointFloat(82.29166!, 584.5834!)
        Me.lblAMHComment2.Multiline = True
        Me.lblAMHComment2.Name = "lblAMHComment2"
        Me.lblAMHComment2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment2.SizeF = New System.Drawing.SizeF(258.3333!, 76.04163!)
        Me.lblAMHComment2.Text = "lblAMHComment2"
        '
        'lblAMHComment1
        '
        Me.lblAMHComment1.LocationFloat = New DevExpress.Utils.PointFloat(82.29166!, 161.6667!)
        Me.lblAMHComment1.Multiline = True
        Me.lblAMHComment1.Name = "lblAMHComment1"
        Me.lblAMHComment1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment1.SizeF = New System.Drawing.SizeF(272.9167!, 138.5417!)
        Me.lblAMHComment1.Text = "lblAMHComment1"
        '
        'lblAMHResult
        '
        Me.lblAMHResult.LocationFloat = New DevExpress.Utils.PointFloat(207.2917!, 91.87502!)
        Me.lblAMHResult.Multiline = True
        Me.lblAMHResult.Name = "lblAMHResult"
        Me.lblAMHResult.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHResult.SizeF = New System.Drawing.SizeF(42.70831!, 23.95833!)
        Me.lblAMHResult.Text = "lblAMHResult"
        '
        'XrPictureBox2
        '
        Me.XrPictureBox2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash
        Me.XrPictureBox2.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
        Me.XrPictureBox2.ImageUrl = "C:\Users\M2I_SOFT\Desktop\Git\m2isoft_Barcode_new\Barcode\m2i_Blood\05.Rpt\AMH_Fo" &
    "rm_01\00.AMH_BACK_10.jpg"
        Me.XrPictureBox2.LocationFloat = New DevExpress.Utils.PointFloat(82.29166!, 393.9583!)
        Me.XrPictureBox2.Name = "XrPictureBox2"
        Me.XrPictureBox2.SizeF = New System.Drawing.SizeF(688.5416!, 153.1251!)
        Me.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.XrPictureBox2.StylePriority.UseBorderDashStyle = False
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
        Me.XrPictureBox1.ImageUrl = "C:\Users\M2I_SOFT\Desktop\Git\m2isoft_Barcode_new\Barcode\m2i_Blood\05.Rpt\AMH_Fo" &
    "rm_01\00.AMH_BACK_00.png"
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(372.9167!, 110.6251!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(397.9167!, 189.5833!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'Report_IF_AMH
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.DrawWatermark = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(0, 1, 221, 0)
        Me.Version = "18.2"
        Me.Watermark.Image = CType(resources.GetObject("Report_IF_AMH.Watermark.Image"), System.Drawing.Image)
        Me.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Stretch
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrPictureBox2 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
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
End Class
