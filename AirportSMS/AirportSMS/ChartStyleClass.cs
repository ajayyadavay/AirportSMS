using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static AirportSMS.FrmHazardMonitoring;
using sctplot = ScottPlot;
using sctplotwin = ScottPlot.WinForms;

namespace AirportSMS
{
    internal class ChartStyleClass
    {
        public class SeriesStyleConfig
        {
            public bool ShowSeries { get; set; } = true;        // NEW
            public bool ShowValueLabel { get; set; } = false;
            public string LegendText { get; set; } = null;
            public SeriesChartType ChartType { get; set; } = SeriesChartType.Line;
            public string ScottPlot_Chart_Type { get; set; } = "LINE";

            // NEW → Area fill direction relative to data line
            public bool AreaFillAbove { get; set; } = false; // default = below

            // ✅ DATA (added, not renamed)
            public double[] YValues { get; set; }
        }

        public void ScottPlotStyle(sctplotwin.FormsPlot formsPlot1, string[] XLabels, double[] XPos, double maxCurrObsVal,
           string Chart_Title, string Y_axis_title, string X_axis_title, int X_axis_label_Rotation,
           Dictionary<string, SeriesStyleConfig> seriesConfig)
        {

            System.Drawing.Color[] modernColors =
            {
                System.Drawing.Color.FromArgb(237, 125, 49),    // Red (231, 76, 60)
                System.Drawing.Color.FromArgb(46, 204, 113),   // Green 
                System.Drawing.Color.FromArgb(52, 152, 219),   // Blue
                System.Drawing.Color.FromArgb(241, 196, 15),   // Yellow
                System.Drawing.Color.FromArgb(155, 89, 182)    // Purple
            };

            int ci = 0;
            //s.Color = modernColors[ci % modernColors.Length];


            var plt = formsPlot1.Plot;
            plt.Clear();

            foreach (var kvp in seriesConfig)
            {
                var cfg = kvp.Value;
                if (!cfg.ShowSeries || cfg.YValues == null) continue;

                var drawingColor = modernColors[ci % modernColors.Length];
                var spColor = sctplot.Color.FromColor(drawingColor);

                string type = cfg.ScottPlot_Chart_Type?.ToUpperInvariant();

                switch (type)
                {
                    case "LINE":
                        {
                            // In ScottPlot 5, Scatter takes double[] or List<double>
                            var p = plt.Add.Scatter(XPos, cfg.YValues);
                            p.LegendText = cfg.LegendText;
                            p.LineWidth = 2;
                            p.MarkerSize = 5;
                            p.Color = spColor;

                            if (cfg.ShowValueLabel)
                            {
                                for (int i = 0; i < cfg.YValues.Length; i++)
                                {
                                    var txt = plt.Add.Text(
                                        cfg.YValues[i].ToString("F0"),
                                        XPos[i],
                                        cfg.YValues[i]
                                    );
                                    txt.Alignment = ScottPlot.Alignment.LowerCenter;
                                    txt.LabelFontColor = spColor;
                                }
                            }



                        }
                        break;

                    case "AREA":
                        {
                            //double baseline = cfg.AreaFillAbove ? 0 : cfg.YValues.Min();
                            //double baseline = cfg.AreaFillAbove ? cfg.YValues.Max(v => Math.Min(v, 0)) : cfg.YValues.Min();

                            // ScottPlot 5 FillY requires a generic collection or coordinates
                            //var fill = plt.Add.FillY(XPos, cfg.YValues, Enumerable.Repeat(baseline, cfg.YValues.Length).ToArray());

                            //double baseline;
                            double[] boundaryValues;

                            if (cfg.AreaFillAbove)
                            {
                                // To fill "Above", we need a ceiling. 
                                // We set the boundary to the maximum value in the dataset (or slightly higher)
                                //double maxVal = cfg.YValues.Max();
                                double maxVal = maxCurrObsVal;
                                boundaryValues = Enumerable.Repeat(maxVal * 1.2, cfg.YValues.Length).ToArray();
                            }
                            else
                            {
                                // To fill "Below", we fill down to 0
                                boundaryValues = Enumerable.Repeat(0.0, cfg.YValues.Length).ToArray();
                            }

                            var fill = plt.Add.FillY(XPos, cfg.YValues, boundaryValues);

                            // Correction: Use ScottPlot.Color (note the spelling) and FromArgb
                            //fill.FillStyle.Color = ScottPlot.Colors.Blue.WithAlpha(120);
                            fill.FillStyle.Color = spColor.WithAlpha(120); // Use WithAlpha for transparency
                            fill.LineStyle.Width = 0; // Removes the border around the area
                            fill.LegendText = cfg.LegendText;

                            if (cfg.ShowValueLabel)
                            {
                                for (int i = 0; i < cfg.YValues.Length; i++)
                                {
                                    var txt = plt.Add.Text(
                                        cfg.YValues[i].ToString("F0"),
                                        XPos[i],
                                        cfg.YValues[i]
                                    );
                                    txt.Alignment = ScottPlot.Alignment.LowerCenter;
                                    txt.LabelFontColor = spColor.WithAlpha(120);
                                }
                            }


                        }
                        break;
                    case "COLUMN":
                        {
                            // Determine if this is the first or second series for clustering
                            // This assumes your dictionary is iterated in order.
                            int seriesIndex = seriesConfig.Keys.ToList().IndexOf(kvp.Key);
                            double barWidth = 0.35; // Narrower width so two bars fit in 1.0 unit
                            double offset = (seriesIndex == 0) ? -barWidth / 2 : barWidth / 2;

                            // 1. Create the series
                            var barPlot = plt.Add.Bars(XPos, cfg.YValues);

                            // 2. Set legend and color
                            barPlot.LegendText = cfg.LegendText;
                            barPlot.Color = spColor;

                            // 3. Adjust width and shift positions
                            for (int i = 0; i < barPlot.Bars.Count; i++)
                            {
                                var bar = barPlot.Bars[i];
                                bar.Size = barWidth;
                                bar.LineStyle.Width = 0;

                                // Manual offset: Shift bars left or right of the center XPos
                                bar.Position = XPos[i] + offset;
                            }

                            if (cfg.ShowValueLabel)
                            {
                                for (int i = 0; i < cfg.YValues.Length; i++)
                                {
                                    var txt = plt.Add.Text(
                                        cfg.YValues[i].ToString("F0"),
                                        barPlot.Bars[i].Position, // Use the shifted position for labels
                                        cfg.YValues[i]
                                    );
                                    txt.Alignment = sctplot.Alignment.LowerCenter;
                                    txt.LabelFontColor = spColor;
                                }
                            }
                        }
                        break;

                        /*case "COLUMN":
                            {
                                // 1. Create the series as a single object
                                var barPlot = plt.Add.Bars(XPos, cfg.YValues);

                                // 2. Set the legend text for the entire series (only shows once)
                                barPlot.LegendText = cfg.LegendText;

                                // 3. Set the color for all bars in this series
                                // In ScottPlot 5, use .Color to set the fill color for the whole group
                                //barPlot.Color = ScottPlot.Colors.Green.WithAlpha(120);
                                barPlot.Color = spColor;

                                // 4. Adjust width for all bars
                                foreach (var bar in barPlot.Bars)
                                {
                                    bar.Size = 0.6;
                                    bar.LineStyle.Width = 0;
                                }

                                if (cfg.ShowValueLabel)
                                {
                                    for (int i = 0; i < cfg.YValues.Length; i++)
                                    {
                                        var txt = plt.Add.Text(
                                            cfg.YValues[i].ToString(),
                                            XPos[i],
                                            cfg.YValues[i]
                                        );
                                        txt.Alignment = ScottPlot.Alignment.LowerCenter;
                                        txt.LabelFontColor = spColor;
                                    }
                                }



                            }
                            break;*/
                }

                ci++;
            }

            // Titles
            //plt.Title(TxtSPI_Name.Text == "" ? "Monthly performance overview" : TxtSPI_Name.Text);
            //plt.YLabel(Txt_SPI_Unit.Text == "" ? "Number or Number per .... FMs" : Txt_SPI_Unit.Text);
            //plt.XLabel("Month");

            plt.Title(Chart_Title);
            plt.YLabel(Y_axis_title);
            plt.XLabel(X_axis_title);

            // X-axis string labels
            plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(positions: XPos, labels: XLabels);


            //plt.Axes.Bottom.TickLabelStyle.Rotation = X_axis_label_Rotation;

            // 1. Set the rotation and alignment
            plt.Axes.Bottom.TickLabelStyle.Rotation = X_axis_label_Rotation;
            // Use MiddleLeft for positive rotation (e.g. 45) or MiddleRight for negative (-45)
            // This ensures the label starts at the tick and grows AWAY from the plot.
            plt.Axes.Bottom.TickLabelStyle.Alignment = ScottPlot.Alignment.MiddleRight;

            // 2. Increase the axis size to accommodate the long text
            // You can set this to a fixed pixel value (e.g., 100) or calculate it dynamically.
            //plt.Axes.Bottom.MinimumSize = 100;

            float largestLabelWidth = 0;
            using (sctplot.Paint paint = sctplot.Paint.NewDisposablePaint())
            {
                foreach (string label in XLabels)
                {
                    // Measure the size of the text
                    sctplot.PixelSize size = plt.Axes.Bottom.TickLabelStyle.Measure(label, paint).Size;

                    // Find the largest width (which becomes height when rotated)
                    if (size.Width > largestLabelWidth)
                    {
                        largestLabelWidth = size.Width;
                    }
                }
            }


            // Ensure the axis area is at least as large as the longest rotated label
            plt.Axes.Bottom.MinimumSize = largestLabelWidth;

            // FORCE Y AXIS BASELINE
            //plt.Axes.SetLimitsY(min: 0);
            // This forces the bottom of the viewport to 0
            // but allows the top to expand to fit your data.
            plt.Axes.AutoScale(false);
            plt.Axes.SetLimits(bottom: 0.0);

            // Legend
            // 1. Enable the legend
            plt.Legend.IsVisible = true;

            var existingLegends = plt.Axes.GetPanels().Where(p => p is sctplot.Panels.LegendPanel).ToList();
            foreach (var leg in existingLegends)
                plt.Axes.Remove(leg);

            // 2. Move the legend to the TOP Edge (outside the data area)
            plt.ShowLegend(Edge.Top);

            // 3. Set items to flow horizontally like Excel
            plt.Legend.Orientation = ScottPlot.Orientation.Horizontal;

            // 4. Center the legend relative to the plot
            plt.Legend.Alignment = ScottPlot.Alignment.UpperCenter;

            // Optional: Give it a clean Excel look by removing the shadow/border if desired
            plt.Legend.OutlineWidth = 0;

            
            plt.Legend.BackgroundColor = ScottPlot.Colors.Transparent;
            plt.Legend.OutlineColor = ScottPlot.Colors.Transparent;
            plt.Legend.ShadowColor = ScottPlot.Colors.Transparent; // Important for full transparency

            //plt.Legend.BackgroundFillStyle() = ScottPlot.Colors.Transparent;




            //plt.Legend(location: sctplot.Alignment.UpperRight);
            // Use the Alignment property on the Legend object

            ////////plt.Legend.Alignment = ScottPlot.Alignment.UpperRight;

            // Ensure it is visible
            ////////plt.Legend.IsVisible = true;

            //plt.Axes.SetLimits(bottom: 0);
        }


    }
}
