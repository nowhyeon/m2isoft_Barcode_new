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
        Me.XrChart2 = New DevExpress.XtraReports.UI.XRChart()
        Me.AMHResultLine = New DevExpress.XtraReports.UI.XRLine()
        Me.XrChart1 = New DevExpress.XtraReports.UI.XRChart()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHComment3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHComment2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHComment1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHResult = New DevExpress.XtraReports.UI.XRLabel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.XrCrossBandBox1 = New DevExpress.XtraReports.UI.XRCrossBandBox()
        Me.XrCrossBandBox2 = New DevExpress.XtraReports.UI.XRCrossBandBox()
        CType(Me.XrChart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrChart1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrChart2, Me.AMHResultLine, Me.XrChart1, Me.XrLabel1, Me.lblAMHComment3, Me.lblAMHComment2, Me.lblAMHComment1, Me.lblAMHResult})
        Me.Detail.HeightF = 837.6267!
        Me.Detail.Name = "Detail"
        '
        'XrChart2
        '
        Me.XrChart2.BorderColor = System.Drawing.Color.Black
        Me.XrChart2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrChart2.Legend.Name = "Default Legend"
        Me.XrChart2.LocationFloat = New DevExpress.Utils.PointFloat(45.0!, 421.96!)
        Me.XrChart2.Name = "XrChart2"
        Me.XrChart2.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.XrChart2.SizeF = New System.Drawing.SizeF(667.7084!, 159.375!)
        '
        'AMHResultLine
        '
        Me.AMHResultLine.BorderColor = System.Drawing.Color.DarkRed
        Me.AMHResultLine.BorderWidth = 2.0!
        Me.AMHResultLine.ForeColor = System.Drawing.Color.Red
        Me.AMHResultLine.LineWidth = 3.0!
        Me.AMHResultLine.LocationFloat = New DevExpress.Utils.PointFloat(413.0!, 148.0!)
        Me.AMHResultLine.Name = "AMHResultLine"
        Me.AMHResultLine.SizeF = New System.Drawing.SizeF(279.1667!, 14.58334!)
        Me.AMHResultLine.StylePriority.UseBorderColor = False
        Me.AMHResultLine.StylePriority.UseBorderWidth = False
        Me.AMHResultLine.StylePriority.UseForeColor = False
        '
        'XrChart1
        '
        Me.XrChart1.BorderColor = System.Drawing.Color.Black
        Me.XrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrChart1.Legend.Name = "Default Legend"
        Me.XrChart1.LocationFloat = New DevExpress.Utils.PointFloat(289.5834!, 134.7059!)
        Me.XrChart1.Name = "XrChart1"
        Me.XrChart1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.XrChart1.SizeF = New System.Drawing.SizeF(415.0!, 200.4167!)
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(508.8114!, 335.1226!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(195.772!, 15.71082!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "* AMH 결과가 빨간색 선으로 표시됩니다"
        '
        'lblAMHComment3
        '
        Me.lblAMHComment3.LocationFloat = New DevExpress.Utils.PointFloat(40.41668!, 743.46!)
        Me.lblAMHComment3.Multiline = True
        Me.lblAMHComment3.Name = "lblAMHComment3"
        Me.lblAMHComment3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment3.SizeF = New System.Drawing.SizeF(677.7083!, 46.875!)
        '
        'lblAMHComment2
        '
        Me.lblAMHComment2.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblAMHComment2.LocationFloat = New DevExpress.Utils.PointFloat(50.83334!, 628.1266!)
        Me.lblAMHComment2.Multiline = True
        Me.lblAMHComment2.Name = "lblAMHComment2"
        Me.lblAMHComment2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment2.SizeF = New System.Drawing.SizeF(238.5417!, 76.04163!)
        Me.lblAMHComment2.StylePriority.UseFont = False
        '
        'lblAMHComment1
        '
        Me.lblAMHComment1.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.lblAMHComment1.LocationFloat = New DevExpress.Utils.PointFloat(50.83334!, 147.7916!)
        Me.lblAMHComment1.Multiline = True
        Me.lblAMHComment1.Name = "lblAMHComment1"
        Me.lblAMHComment1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment1.SizeF = New System.Drawing.SizeF(226.25!, 130.2084!)
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
        'XrCrossBandBox1
        '
        Me.XrCrossBandBox1.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrCrossBandBox1.BorderColor = System.Drawing.Color.Navy
        Me.XrCrossBandBox1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrCrossBandBox1.BorderWidth = 3.0!
        Me.XrCrossBandBox1.EndBand = Me.Detail
        Me.XrCrossBandBox1.EndPointFloat = New DevExpress.Utils.PointFloat(413.0!, 307.0!)
        Me.XrCrossBandBox1.Name = "XrCrossBandBox1"
        Me.XrCrossBandBox1.StartBand = Me.Detail
        Me.XrCrossBandBox1.StartPointFloat = New DevExpress.Utils.PointFloat(413.0!, 154.0!)
        Me.XrCrossBandBox1.WidthF = 45.0!
        '
        'XrCrossBandBox2
        '
        Me.XrCrossBandBox2.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrCrossBandBox2.BorderColor = System.Drawing.Color.Navy
        Me.XrCrossBandBox2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrCrossBandBox2.BorderWidth = 3.0!
        Me.XrCrossBandBox2.EndBand = Me.Detail
        Me.XrCrossBandBox2.EndPointFloat = New DevExpress.Utils.PointFloat(45.00008!, 550.7083!)
        Me.XrCrossBandBox2.Name = "XrCrossBandBox2"
        Me.XrCrossBandBox2.StartBand = Me.Detail
        Me.XrCrossBandBox2.StartPointFloat = New DevExpress.Utils.PointFloat(45.00008!, 512.7083!)
        Me.XrCrossBandBox2.WidthF = 667.7083!
        '
        'Report_IF_AMH
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.BorderWidth = 2.0!
        Me.CrossBandControls.AddRange(New DevExpress.XtraReports.UI.XRCrossBandControl() {Me.XrCrossBandBox2, Me.XrCrossBandBox1})
        Me.DrawWatermark = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(33, 40, 277, 41)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.Version = "18.2"
        Me.Watermark.Image = CType(resources.GetObject("Report_IF_AMH.Watermark.Image"), System.Drawing.Image)
        Me.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Stretch
        CType(Me.XrChart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrChart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
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
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrChart1 As DevExpress.XtraReports.UI.XRChart
    Friend WithEvents AMHResultLine As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrCrossBandBox1 As DevExpress.XtraReports.UI.XRCrossBandBox
    Friend WithEvents XrChart2 As DevExpress.XtraReports.UI.XRChart
    Friend WithEvents XrCrossBandBox2 As DevExpress.XtraReports.UI.XRCrossBandBox
End Class
