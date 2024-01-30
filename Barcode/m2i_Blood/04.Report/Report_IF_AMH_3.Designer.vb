<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Report_IF_AMH_3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Report_IF_AMH_3))
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblAMHComment1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAMHResult = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAge = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBirth = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReceiptDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblChartNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPTNM = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblHosNM = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrChart1 = New DevExpress.XtraReports.UI.XRChart()
        Me.XrChart2 = New DevExpress.XtraReports.UI.XRChart()
        Me.lblAMHComment2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrChart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAMHComment2, Me.XrLabel22, Me.XrChart2, Me.XrChart1, Me.lblAMHComment1, Me.lblAMHResult, Me.lblAge, Me.lblBirth, Me.lblReceiptDate, Me.lblChartNo, Me.lblPTNM, Me.lblHosNM})
        Me.Detail.HeightF = 979.1667!
        Me.Detail.Name = "Detail"
        '
        'lblAMHComment1
        '
        Me.lblAMHComment1.LocationFloat = New DevExpress.Utils.PointFloat(61.33342!, 244.1667!)
        Me.lblAMHComment1.Multiline = True
        Me.lblAMHComment1.Name = "lblAMHComment1"
        Me.lblAMHComment1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment1.SizeF = New System.Drawing.SizeF(290.8333!, 113.3333!)
        Me.lblAMHComment1.Text = "lblAMHComment1"
        '
        'lblAMHResult
        '
        Me.lblAMHResult.Font = New System.Drawing.Font("나눔바른고딕", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblAMHResult.ForeColor = System.Drawing.Color.Red
        Me.lblAMHResult.LocationFloat = New DevExpress.Utils.PointFloat(228.3333!, 193.9999!)
        Me.lblAMHResult.Multiline = True
        Me.lblAMHResult.Name = "lblAMHResult"
        Me.lblAMHResult.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHResult.SizeF = New System.Drawing.SizeF(69.16669!, 30.0!)
        Me.lblAMHResult.StylePriority.UseFont = False
        Me.lblAMHResult.StylePriority.UseForeColor = False
        Me.lblAMHResult.Text = "2.14"
        '
        'lblAge
        '
        Me.lblAge.Font = New System.Drawing.Font("나눔바른고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblAge.LocationFloat = New DevExpress.Utils.PointFloat(509.1667!, 110.6667!)
        Me.lblAge.Multiline = True
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAge.SizeF = New System.Drawing.SizeF(147.5!, 21.66667!)
        Me.lblAge.StylePriority.UseFont = False
        '
        'lblBirth
        '
        Me.lblBirth.Font = New System.Drawing.Font("나눔바른고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblBirth.LocationFloat = New DevExpress.Utils.PointFloat(509.1667!, 80.83334!)
        Me.lblBirth.Multiline = True
        Me.lblBirth.Name = "lblBirth"
        Me.lblBirth.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBirth.SizeF = New System.Drawing.SizeF(147.5!, 21.66667!)
        Me.lblBirth.StylePriority.UseFont = False
        '
        'lblReceiptDate
        '
        Me.lblReceiptDate.Font = New System.Drawing.Font("나눔바른고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblReceiptDate.LocationFloat = New DevExpress.Utils.PointFloat(509.1667!, 51.66667!)
        Me.lblReceiptDate.Multiline = True
        Me.lblReceiptDate.Name = "lblReceiptDate"
        Me.lblReceiptDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceiptDate.SizeF = New System.Drawing.SizeF(147.5!, 21.66667!)
        Me.lblReceiptDate.StylePriority.UseFont = False
        '
        'lblChartNo
        '
        Me.lblChartNo.Font = New System.Drawing.Font("나눔바른고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblChartNo.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 110.6667!)
        Me.lblChartNo.Multiline = True
        Me.lblChartNo.Name = "lblChartNo"
        Me.lblChartNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblChartNo.SizeF = New System.Drawing.SizeF(147.5!, 21.66667!)
        Me.lblChartNo.StylePriority.UseFont = False
        '
        'lblPTNM
        '
        Me.lblPTNM.Font = New System.Drawing.Font("나눔바른고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblPTNM.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 80.83334!)
        Me.lblPTNM.Multiline = True
        Me.lblPTNM.Name = "lblPTNM"
        Me.lblPTNM.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPTNM.SizeF = New System.Drawing.SizeF(147.5!, 22.33333!)
        Me.lblPTNM.StylePriority.UseFont = False
        '
        'lblHosNM
        '
        Me.lblHosNM.Font = New System.Drawing.Font("나눔바른고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblHosNM.LocationFloat = New DevExpress.Utils.PointFloat(135.0!, 51.66667!)
        Me.lblHosNM.Multiline = True
        Me.lblHosNM.Name = "lblHosNM"
        Me.lblHosNM.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblHosNM.SizeF = New System.Drawing.SizeF(147.5!, 21.66667!)
        Me.lblHosNM.StylePriority.UseFont = False
        '
        'XrChart1
        '
        Me.XrChart1.BorderColor = System.Drawing.Color.Black
        Me.XrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrChart1.Legend.Name = "Default Legend"
        Me.XrChart1.LocationFloat = New DevExpress.Utils.PointFloat(363.3333!, 244.1667!)
        Me.XrChart1.Name = "XrChart1"
        Me.XrChart1.PaletteName = "Palette 1"
        Me.XrChart1.PaletteRepository.Add("Custom", New DevExpress.XtraCharts.Palette("Custom", DevExpress.XtraCharts.PaletteScaleMode.Extrapolate, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer)))}))
        Me.XrChart1.PaletteRepository.Add("Palette 1", New DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer)))}))
        Me.XrChart1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.XrChart1.SizeF = New System.Drawing.SizeF(367.5!, 212.4999!)
        '
        'XrChart2
        '
        Me.XrChart2.AppearanceNameSerializable = "Pastel Kit"
        Me.XrChart2.BorderColor = System.Drawing.Color.Black
        Me.XrChart2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrChart2.Legend.Name = "Default Legend"
        Me.XrChart2.LocationFloat = New DevExpress.Utils.PointFloat(40.20833!, 772.0!)
        Me.XrChart2.Name = "XrChart2"
        Me.XrChart2.PaletteName = "Custom"
        Me.XrChart2.PaletteRepository.Add("Custom", New DevExpress.XtraCharts.Palette("Custom", DevExpress.XtraCharts.PaletteScaleMode.Extrapolate, New DevExpress.XtraCharts.PaletteEntry() {New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(255, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer))), New DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer)))}))
        Me.XrChart2.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.XrChart2.SizeF = New System.Drawing.SizeF(690.625!, 81.04172!)
        '
        'lblAMHComment2
        '
        Me.lblAMHComment2.Font = New System.Drawing.Font("KaiGen Gothic K Regular", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMHComment2.LocationFloat = New DevExpress.Utils.PointFloat(40.20833!, 856.6667!)
        Me.lblAMHComment2.Multiline = True
        Me.lblAMHComment2.Name = "lblAMHComment2"
        Me.lblAMHComment2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAMHComment2.SizeF = New System.Drawing.SizeF(341.8333!, 46.66675!)
        Me.lblAMHComment2.StylePriority.UseFont = False
        '
        'XrLabel22
        '
        Me.XrLabel22.Font = New System.Drawing.Font("KaiGen Gothic K Regular", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(394.5418!, 856.6667!)
        Me.XrLabel22.Multiline = True
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(336.2915!, 46.66675!)
        Me.XrLabel22.StylePriority.UseFont = False
        '
        'Report_IF_AMH_3
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.DrawWatermark = True
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(42, 44, 100, 0)
        Me.Version = "18.2"
        Me.Watermark.Image = CType(resources.GetObject("Report_IF_AMH_3.Watermark.Image"), System.Drawing.Image)
        Me.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Zoom
        CType(Me.XrChart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrChart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents lblAMHResult As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAge As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBirth As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReceiptDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblChartNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPTNM As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblHosNM As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAMHComment1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrChart1 As DevExpress.XtraReports.UI.XRChart
    Friend WithEvents XrChart2 As DevExpress.XtraReports.UI.XRChart
    Friend WithEvents lblAMHComment2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
End Class
