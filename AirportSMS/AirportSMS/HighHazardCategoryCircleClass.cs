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
            var tag = panel.Tag as Tuple<List<HazardCategory>, string>;
            if (tag == null) return;

            List<HazardCategory> data = tag.Item1;
            string centerText = tag.Item2;
            if (data == null || data.Count == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int panelW = panel.Width;
            int panelH = panel.Height;
            int minSide = Math.Min(panelW, panelH);

            // =========================
            // 1. FIXED SIZES
            // =========================
            int padding = 10;
            int availableRadius = (minSide / 2) - padding;

            int smallRadius = (int)(minSide * 0.12);       // ~10% of panel size
            int mainRadius = (int)(minSide * 0.20);       // ~18% of panel size
            int orbitRadius = mainRadius + smallRadius + 20; // 10 px gap for connector

            int centerX = panelW / 2;
            int centerY = panelH / 2;

            Color mainCircleColor = Color.FromArgb(236, 240, 253);
            Color smallCircleColor = Color.FromArgb(224, 249, 242);
            Color borderColor = Color.FromArgb(120, 130, 190);
            Color textColor = Color.FromArgb(60, 60, 60);

            using (Pen borderPen = new Pen(borderColor, 2))
            using (Pen linkPen = new Pen(borderColor, 1))
            using (SolidBrush mainBrush = new SolidBrush(mainCircleColor))
            using (SolidBrush smallBrush = new SolidBrush(smallCircleColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (Font centerFont = new Font("Segoe UI", minSide / 25f, FontStyle.Bold))
            using (Font smallFont = new Font("Segoe UI", 12f, FontStyle.Regular))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // --- MAIN CIRCLE ---
                g.FillEllipse(mainBrush, centerX - mainRadius, centerY - mainRadius, mainRadius * 2, mainRadius * 2);
                g.DrawEllipse(borderPen, centerX - mainRadius, centerY - mainRadius, mainRadius * 2, mainRadius * 2);
                g.DrawString(centerText, centerFont, textBrush,
                    new RectangleF(centerX - mainRadius, centerY - mainRadius, mainRadius * 2, mainRadius * 2), sf);

                // --- SMALL CIRCLES ---
                int count = data.Count;
                double angleStep = 360.0 / count;
                double startAngle = -90;

                for (int i = 0; i < count; i++)
                {
                    double angleDeg = startAngle + i * angleStep;
                    double angleRad = angleDeg * Math.PI / 180;

                    int x = centerX + (int)(orbitRadius * Math.Cos(angleRad));
                    int y = centerY + (int)(orbitRadius * Math.Sin(angleRad));

                    // connector line
                    g.DrawLine(linkPen,
                        centerX + (int)(mainRadius * Math.Cos(angleRad)),
                        centerY + (int)(mainRadius * Math.Sin(angleRad)),
                        x,
                        y);

                    // small circle
                    g.FillEllipse(smallBrush, x - smallRadius, y - smallRadius, smallRadius * 2, smallRadius * 2);
                    g.DrawEllipse(borderPen, x - smallRadius, y - smallRadius, smallRadius * 2, smallRadius * 2);

                    // text (wrap inside small circle)
                    string label = $"{data[i].Name}\n({data[i].Value:N0})";
                    RectangleF rect = new RectangleF(x - smallRadius + 2, y - smallRadius + 2, smallRadius * 2 - 4, smallRadius * 2 - 4);
                    g.DrawString(label, smallFont, textBrush, rect, sf);
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
