using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirportSMS
{
    internal class HighHazardCategoryCircleClass
    {

        public class HazardCategory
        {
            public string Name { get; set; }
            public double Value { get; set; }
        }

        public void DrawHazardCircle(
            Panel panel,
            DataGridView dgv,
            int fromRowIndex,
            int toRowIndex,
            int HazCatNameColIndex,
            int HazCatValColIndex,
            string centerText = "Hazard Category")
        {
            List<HazardCategory> data = new List<HazardCategory>();

            if (dgv == null || dgv.Rows.Count == 0) return;

            toRowIndex = Math.Min(toRowIndex, dgv.Rows.Count - 1);

            for (int i = fromRowIndex; i <= toRowIndex; i++)
            {
                if (dgv.Rows[i].IsNewRow) continue;

                string name = dgv.Rows[i].Cells[HazCatNameColIndex].Value?.ToString();

                if (string.IsNullOrWhiteSpace(name)) continue;

                if (!double.TryParse(
                        dgv.Rows[i].Cells[HazCatValColIndex].Value?.ToString(),
                        out double value))
                    continue;

                data.Add(new HazardCategory
                {
                    Name = name,
                    Value = value
                });
            }

            if (data.Count == 0) return;

            panel.Paint -= PanelHazard_Paint;
            panel.Paint += PanelHazard_Paint;

            //panel.Tag = data;     // Store data for paint event
            panel.Tag = Tuple.Create(data, centerText);
            panel.Invalidate();   // Redraw
        }

        private void PanelHazard_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            //List<HazardCategory> data = panel.Tag as List<HazardCategory>;
            var tag = panel.Tag as Tuple<List<HazardCategory>, string>;
            if (tag == null) return;

            List<HazardCategory> data = tag.Item1;
            string centerText = tag.Item2;


            if (data == null || data.Count == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            // Base scaling factor from panel size
            float baseSize = Math.Min(panel.Width, panel.Height);

            //int centerX = panel.Width / 2;
            //int centerY = panel.Height / 2;

            /*int mainRadius = Math.Min(panel.Width, panel.Height) / 4;
            int orbitRadius = mainRadius + 70;
            int smallRadius = 40;*/

            int mainRadius = Math.Min(panel.Width, panel.Height) / 4;

            // Orbit radius: distance from center to small circles
            int orbitRadius = mainRadius + (int)(Math.Min(panel.Width, panel.Height) * 0.18);

            // Small circle radius
            //int smallRadius = (int)(Math.Min(panel.Width, panel.Height) * 0.10);


            // Base small circle radius
            int smallRadius = (int)(Math.Min(panel.Width, panel.Height) * 0.10);

            /*using (Font smallFont = new Font("Segoe UI", baseSize / 40f, FontStyle.Regular))
            // Adjust radius if text is too long
            using (Graphics gMeasure = panel.CreateGraphics())
            {
                foreach (var item in data)
                {
                    string label = string.Format("{0}\n({1:N0})", item.Name, item.Value);
                    SizeF size = gMeasure.MeasureString(label, smallFont);

                    // Add padding of 6 pixels
                    float requiredRadius = Math.Max(size.Width, size.Height) / 2 + 6;

                    if (requiredRadius > smallRadius)
                        smallRadius = (int)requiredRadius;
                }
            }*/



            // Center position
            int centerX = panel.Width / 2;
            int centerY = orbitRadius + smallRadius + 8;  // 10 px padding from top

            Color mainCircleColor = Color.FromArgb(236, 240, 253);
            Color smallCircleColor = Color.FromArgb(224, 249, 242);
            Color borderColor = Color.FromArgb(120, 130, 190);
            Color textColor = Color.FromArgb(60, 60, 60);

            

            

            using (Pen borderPen = new Pen(borderColor, 2))
            using (Pen linkPen = new Pen(borderColor, 1))
            using (SolidBrush mainBrush = new SolidBrush(mainCircleColor))
            using (SolidBrush smallBrush = new SolidBrush(smallCircleColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            //using (Font centerFont = new Font("Segoe UI", 12, FontStyle.Bold))
            //using (Font smallFont = new Font("Segoe UI", 9, FontStyle.Regular))
            // Center text font (bigger, bold)
            using (Font centerFont = new Font("Segoe UI", baseSize / 25f, FontStyle.Bold))
            // Small circles font (smaller, regular)
            using (Font smallFont = new Font("Segoe UI", baseSize / 40f, FontStyle.Regular))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // -------- Main Circle --------
                g.FillEllipse(
                    mainBrush,
                    centerX - mainRadius,
                    centerY - mainRadius,
                    mainRadius * 2,
                    mainRadius * 2);

                g.DrawEllipse(
                    borderPen,
                    centerX - mainRadius,
                    centerY - mainRadius,
                    mainRadius * 2,
                    mainRadius * 2);

                g.DrawString(
                    //"High Category\nHazard",
                    centerText,
                    centerFont,
                    textBrush,
                    new RectangleF(
                        centerX - mainRadius,
                        centerY - mainRadius,
                        mainRadius * 2,
                        mainRadius * 2),
                    sf);

                // -------- Small Circles --------
                int count = data.Count;
                double angleStep = 360.0 / count;
                double startAngle = -90;

                for (int i = 0; i < count; i++)
                {
                   
                    double angleDeg = startAngle + i * angleStep;
                    double angleRad = angleDeg * Math.PI / 180;

                    int x = centerX + (int)(orbitRadius * Math.Cos(angleRad));
                    int y = centerY + (int)(orbitRadius * Math.Sin(angleRad));

                    // Connector line
                    g.DrawLine(
                        linkPen,
                        centerX + (int)(mainRadius * Math.Cos(angleRad)),
                        centerY + (int)(mainRadius * Math.Sin(angleRad)),
                        x,
                        y);

                    // Small circle
                    g.FillEllipse(
                        smallBrush,
                        x - smallRadius,
                        y - smallRadius,
                        smallRadius * 2,
                        smallRadius * 2);

                    g.DrawEllipse(
                        borderPen,
                        x - smallRadius,
                        y - smallRadius,
                        smallRadius * 2,
                        smallRadius * 2);

                    // Text
                    string label = string.Format(
                        "{0}\n({1:N0})",
                        data[i].Name,
                        data[i].Value);

                    g.DrawString(
                        label,
                        smallFont,
                        textBrush,
                        new RectangleF(
                            x - smallRadius,
                            y - smallRadius,
                            smallRadius * 2,
                            smallRadius * 2),
                        sf);


                    /*// Start with original smallFont
                    Font drawFont = smallFont;
                    SizeF textSize = g.MeasureString(label, drawFont);

                    // Reduce font until it fits inside circle
                    while ((textSize.Width > smallRadius * 2 - 4 || textSize.Height > smallRadius * 2 - 4) && drawFont.Size > 4)
                    {
                        drawFont = new Font(drawFont.FontFamily, drawFont.Size - 0.5f, drawFont.Style);
                        textSize = g.MeasureString(label, drawFont);
                    }

                    // Draw the text
                    g.DrawString(label, drawFont, textBrush, new RectangleF(x - smallRadius, y - smallRadius, smallRadius * 2, smallRadius * 2), sf);
                    */




                }
            }
        }

        public void SavePanelAsImage(Panel panel, string filePath)
        {
            // Create bitmap the size of the panel
            using (Bitmap bmp = new Bitmap(panel.Width, panel.Height))
            {
                // Draw the panel into the bitmap
                panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                // Save to file
                bmp.Save(filePath);
            }
        }












    }
}
