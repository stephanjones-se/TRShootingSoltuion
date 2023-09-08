

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace WinFormsApp2
{

    public partial class MainForm : Form
    {
        //Bitmap MemoryImage;
        const double moaMM = 26.5938;
        public MainForm()
        {
            InitializeComponent();

            definedTargets.DataSource = Program.definedTargets.Select(l => l.Name).ToList();
        }

        static void DrawLetters(string letter, Graphics G, int x, int y, int fontSize = 9)
        {
            Font font = new Font("Arial", fontSize);
            G.DrawString(letter,
                        font,
                        Brushes.Black,
                        new PointF(x, y));
        }
        static void DrawLettersNarrow(string letter, Graphics G, int x, int y, int fontSize = 9)
        {
            Font font = new Font("Arial Narrow", fontSize);
            G.DrawString(letter,
                        font,
                        Brushes.Black,
                        new PointF(x, y));
        }

        private void DrawTarget(PaintEventArgs eu)
        {
            Target selectedTarget = Program.definedTargets.FirstOrDefault(o => o.Name == definedTargets.SelectedItem);
            double range = selectedTarget.Distance / 100;
            pictureBox1.Image = new Bitmap(300, 300);

            double scalex = (double)(300 / selectedTarget.ROTxInMetric);

            var scaley = 300 / selectedTarget.ROTxInMetric;
            var centerpoint = 300 / 2;

            //aiming mark
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                var aimMark = (double)selectedTarget.AimInMetric * scalex;
                var x = (pictureBox1.Width - (int)aimMark) / 2;
                var y = (pictureBox1.Height - (int)aimMark) / 2;

                G.FillEllipse(new SolidBrush(Color.LightGray), x, y, (int)aimMark, (int)aimMark);

            }
            //outer
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                var aimMark = (double)selectedTarget.OuterInMetric * scalex;
                var x = (pictureBox1.Width - (int)aimMark) / 2;
                var y = (pictureBox1.Height - (int)aimMark) / 2;

                G.DrawEllipse(new Pen(Color.Black, 1), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }


            //magpie
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                var aimMark = (double)selectedTarget.MagpieInMetric * scalex;
                var x = (pictureBox1.Width - (int)aimMark) / 2;
                var y = (pictureBox1.Height - (int)aimMark) / 2;

                G.DrawEllipse(new Pen(Color.Black, 1), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //inner
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                var aimMark = (double)selectedTarget.InnerInMetric * scalex;
                var x = (pictureBox1.Width - (int)aimMark) / 2;
                var y = (pictureBox1.Height - (int)aimMark) / 2;

                G.DrawEllipse(new Pen(Color.Black, 1), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            ////bull
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                var aimMark = (double)selectedTarget.BullInMetric * scalex;
                var x = (pictureBox1.Width - (int)aimMark) / 2;
                var y = (pictureBox1.Height - (int)aimMark) / 2;

                G.DrawEllipse(new Pen(Color.Black, 1), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //vbull
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                var aimMark = (double)selectedTarget.VBullInMetric * scalex;
                var x = (pictureBox1.Width - (int)aimMark) / 2;
                var y = (pictureBox1.Height - (int)aimMark) / 2;
                var pen = new Pen(Color.Black, 1);
                pen.DashStyle = DashStyle.Dash;
                G.DrawEllipse(pen, x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //draw the Moa lines
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                Pen blackPen = new Pen(Color.Black, 1);
                int lenght = 0;
                blackPen.DashStyle = DashStyle.Dot;
                for (int i = 1; i < 5; i++)
                {
                    G.DrawLine(blackPen, new Point(centerpoint, 0), new Point(centerpoint, 600));
                    G.DrawLine(blackPen, new Point(0, centerpoint), new Point(600, centerpoint));
                    var shift = (i * moaMM * range) * scalex;

                    G.DrawLine(blackPen, new Point(centerpoint + (int)shift, 0), new Point(centerpoint + (int)shift, 600));
                    G.DrawLine(blackPen, new Point(centerpoint - (int)shift, 0), new Point(centerpoint - (int)shift, 600));

                    G.DrawLine(blackPen, new Point(0, centerpoint + (int)shift), new Point(600, centerpoint + (int)shift));
                    G.DrawLine(blackPen, new Point(0, centerpoint - (int)shift), new Point(600, centerpoint - (int)shift));
                    lenght = centerpoint + (50 * i) * (int)scalex;

                }



            }

        }

        private void definedTargets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            Target selectedTarget = Program.definedTargets.Where(o => o.Name == cmb.SelectedItem).FirstOrDefault();
            rot.Value = (decimal)selectedTarget.ROTx;
            roty.Value = (decimal)selectedTarget.ROTy;
            aim.Value = (decimal)selectedTarget.Aim;
            outer.Value = (decimal)selectedTarget.Outer;
            magpie.Value = (decimal)selectedTarget.Magpie;
            inner.Value = (decimal)selectedTarget.Inner;
            bull.Value = (decimal)selectedTarget.Bull;
            vbull.Value = (decimal)selectedTarget.VBull;
            //pictureBox1.Invalidate();
            this.DrawTarget(new PaintEventArgs(this.CreateGraphics(), this.pictureBox1.DisplayRectangle));
            plottingDiagram.Invalidate();



        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            Bitmap MemoryImage;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter writer = new PdfWriter(sfd.FileName);
                    PdfDocument pdf = new PdfDocument(writer);
                    Document document = new Document(pdf, iText.Kernel.Geom.PageSize.LETTER);
                    iText.Kernel.Geom.Rectangle aoeu = document.GetPageEffectiveArea(iText.Kernel.Geom.PageSize.LETTER);
                    var half = (aoeu.GetHeight() / 2) + 40;


                    try
                    {
                        plottingDiagram.AutoSize = true;
                        plottingDiagram.Refresh();

                        int width = plottingDiagram.Width;
                        int height = plottingDiagram.Height;

                        MemoryImage = new Bitmap(width, height);
                        System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, width, height);
                        plottingDiagram.DrawToBitmap(MemoryImage, new System.Drawing.Rectangle(0, 0, width, height));

                        MemoryStream stream = new MemoryStream();
                        MemoryImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        Byte[] bytes = stream.ToArray();


                        iText.IO.Image.ImageData imageData = iText.IO.Image.ImageDataFactory.Create(bytes);


                        iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData).ScaleToFit(600, 640).SetFixedPosition(1, 0, 0);
                        iText.Layout.Element.Image image1 = new iText.Layout.Element.Image(imageData).ScaleToFit(600, 640).SetFixedPosition(1, 0, half);
                        document.Add(image).Add(image1);

                        MemoryImage.Save("C:\\temp\\ttt.png"); // Pour voir l'image qui devrait être ajoutée dans le PDF

                        //Save pdf file

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        document.Close();
                    }
                }
            }
            //PdfWriter writer = new PdfWriter("C:\\temp\\demo.pdf");
            //PdfDocument pdf = new PdfDocument(writer);
            //Document document = new Document(pdf);

            // Load image from disk
            //ImageData imageData = ImageDataFactory.Create(ImageToByte(plottingDiagram));
            // Create layout image object and provide parameters. Page number = 1
            //iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData).ScaleAbsolute(100, 200).SetFixedPosition(1, 25, 25);
            //iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData).SetFixedPosition(1, 25, 25);
            //iText.Layout.Element.Image image2 = new iText.Layout.Element.Image(imageData).SetFixedPosition(1, 25, 550);
            // This adds the image to the page
            //document.Add(image);
            //   .Add(image2);

            // Don't forget to close the document.
            // When you use Document, you should close it rather than PdfDocument instance
            //document.Close();

        }
        private void DrawPanel(object sender, PaintEventArgs e)
        {
            //plottingDiagram.Image = new Bitmap(1200, 780);
            int yTop = 90;
            int scoringYTop = 20;
            int xTop = 90;
            int diagramWidth = 680;
            int diagramHeight = 500;
            Pen blackPen = new Pen(Color.Black, 1);
            Pen blackPenThick = new Pen(Color.Black, 2);
            Pen skinnyPen = new Pen(Color.LightGray, (float).5);

            Target selectedTarget = Program.definedTargets.FirstOrDefault(o => o.Name == definedTargets.SelectedItem);
            double range = selectedTarget.Distance / 100;
            double scalex = (double)(680 / selectedTarget.ROTxInMetric) * ((double)zoomValue.Value / 100);

            var scaley = 680 / selectedTarget.ROTxInMetric;
            var centerpoint = 680 / 2;
            var centerpointy = 500 / 2;

            //draw the scoring area
            //start x,y = 900,ytop
            int scoringX = 970;

            using (Graphics G = e.Graphics)
            {
                var h = 633;
                var w = 220;

                for (int i = 0; i < 17; i++)
                {
                    Pen a;
                    if (i == 1 || i == 11 || i == 15)
                    {
                        a = (Pen)blackPen.Clone();
                    }
                    else
                    {
                        a = (Pen)skinnyPen.Clone();
                    }
                    switch (i)
                    {
                        case 0:
                            DrawLetters("A", G, scoringX + 6, 96 + i * 33, 14);
                            break;
                        case 1:
                            DrawLetters("B", G, scoringX + 6, 96 + i * 33, 14);
                            break;

                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            DrawLetters((i - 1).ToString(), G, scoringX + 6, 96 + i * 33, 14);
                            break;
                        default:
                            DrawLetters((i - 1).ToString(), G, scoringX, 96 + i * 33, 14);
                            break; break;
                    }
                    G.DrawLine(a, new Point(scoringX, 124 + i * 33), new Point(scoringX + w, 124 + i * 33));

                }

                G.DrawRectangle(blackPenThick, new Rectangle(scoringX, scoringYTop, w, h));
                G.DrawLine(blackPenThick, new Point(scoringX, 90), new Point(scoringX + w, 90));

                //middle line

                var middlexAxs = scoringX + (w / 2) - 8;
                var xAxs = middlexAxs - 18;
                DrawLetters("WIND", G, xAxs, scoringYTop + 6, 9);
                xAxs = middlexAxs - 22;
                DrawLetters("L", G, xAxs, scoringYTop + 48, 9);
                xAxs = middlexAxs + 12;
                DrawLetters("R", G, xAxs, scoringYTop + 48, 9);
                G.DrawLine(blackPen, new Point(middlexAxs, 90), new Point(middlexAxs, h + scoringYTop));


                //l wind
                xAxs = middlexAxs - 36;
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, h + scoringYTop));
                //r wind
                xAxs = middlexAxs + 36;
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, h + scoringYTop));

                //elevation
                xAxs = middlexAxs - 60;
                DrawLetters("E", G, xAxs, scoringYTop + 6, 9);
                DrawLetters("L", G, xAxs, scoringYTop + 20, 9);
                DrawLetters("E", G, xAxs, scoringYTop + 34, 9);
                DrawLetters("V", G, xAxs, scoringYTop + 48, 9);
                xAxs = middlexAxs - 72;
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, h + scoringYTop));
                //call
                xAxs = middlexAxs + 48;
                DrawLetters("C", G, xAxs, scoringYTop + 6, 9);
                DrawLetters("A", G, xAxs, scoringYTop + 20, 9);
                DrawLetters("L", G, xAxs, scoringYTop + 34, 9);
                DrawLetters("L", G, xAxs, scoringYTop + 48, 9);
                xAxs = middlexAxs + 72;
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, h + scoringYTop));
                xAxs = middlexAxs + 88;
                DrawLetters("S", G, xAxs, scoringYTop + 3, 9);
                DrawLetters("C", G, xAxs, scoringYTop + 17, 9);
                DrawLetters("O", G, xAxs, scoringYTop + 29, 9);
                DrawLetters("R", G, xAxs, scoringYTop + 41, 9);
                DrawLetters("E", G, xAxs, scoringYTop + 53, 9);




                //draw summary area

                w = 220;
                h = 111;
                middlexAxs = scoringX + (w / 2) - 8;
                var summaryY = scoringYTop + 633;

                G.DrawRectangle(blackPenThick, new Rectangle(scoringX, summaryY, w, h));
                G.DrawLine(blackPen, new Point(scoringX, summaryY + 37), new Point(scoringX + w, summaryY + 37));
                G.DrawLine(blackPen, new Point(scoringX, summaryY + 73), new Point(scoringX + w, summaryY + 73));
                xAxs = middlexAxs + 36;
                G.DrawLine(blackPen, new Point(xAxs, summaryY), new Point(xAxs, summaryY + h));
                xAxs = middlexAxs - 36;
                G.DrawLine(blackPen, new Point(xAxs, summaryY), new Point(xAxs, summaryY + h));
                DrawLetters("Rifle", G, scoringX, summaryY + 2, 8);
                DrawLetters("Ammo", G, scoringX + 68, summaryY + 2, 8);
                DrawLetters("Total", G, scoringX + 140, summaryY + 2, 8);
                DrawLetters("Weather", G, scoringX, summaryY + 37, 8);
                DrawLetters("Light", G, scoringX + 68, summaryY + 37, 8);
                DrawLetters("Filter", G, scoringX + 140, summaryY + 37, 8);
                DrawLetters("R sight", G, scoringX, summaryY + 73, 8);
                DrawLetters("F sight", G, scoringX + 68, summaryY + 73, 8);
                DrawLetters("F app", G, scoringX + 140, summaryY + 73, 8);



                //graphing lines
                int graphingX = 800;
                int graphingY = yTop + diagramHeight + 20;
                int graphspace = 9;
                int nbrGraphLines = 16;
                int totalGraphWidth = graphspace * nbrGraphLines;


                for (int i = 0; i <= nbrGraphLines; i++)
                {
                    Pen a;
                    if (i == 0 || i == 2 || i == 7 || i == 12)
                    {
                        a = (Pen)blackPen.Clone();
                    }
                    else
                    {
                        a = (Pen)skinnyPen.Clone();
                    }
                    //vertical
                    G.DrawLine(a, new Point(graphingX + (i * graphspace), yTop), new Point(graphingX + (i * graphspace), diagramHeight + yTop));
                    //horizontal
                    G.DrawLine(a, new Point(xTop, graphingY + (i * graphspace)), new Point(diagramWidth + xTop, graphingY + (i * graphspace)));
                }



                //center of the Vertical graph
                int centerVertGraph = yTop + (diagramHeight / 2);
                int centerHorizonalGraph = xTop + (diagramWidth / 2);


                //draw MOA on Graph

                G.DrawLine(blackPen, new Point(graphingX, centerVertGraph), new Point(graphingX + totalGraphWidth, centerVertGraph));
                G.DrawLine(blackPen, new Point(centerHorizonalGraph, graphingY), new Point(centerHorizonalGraph, graphingY + totalGraphWidth));
                double shift = 0;
                for (int i = 1; (centerVertGraph + (int)shift) < diagramHeight; i++)
                {
                    shift = (i * moaMM * range) * scalex;

                    G.DrawLine(blackPen, new Point(graphingX, centerVertGraph + (int)shift), new Point(graphingX + totalGraphWidth, centerVertGraph + (int)shift));
                    G.DrawLine(blackPen, new Point(graphingX, centerVertGraph - (int)shift), new Point(graphingX + totalGraphWidth, centerVertGraph - (int)shift));
                }

                shift = 0;
                for (int i = 1; (centerHorizonalGraph + (int)shift) < diagramWidth; i++)
                {
                    shift = (i * moaMM * range) * scalex;

                    G.DrawLine(blackPen, new Point(centerHorizonalGraph + (int)shift, graphingY), new Point(centerHorizonalGraph + (int)shift, graphingY + totalGraphWidth));
                    G.DrawLine(blackPen, new Point(centerHorizonalGraph - (int)shift, graphingY), new Point(centerHorizonalGraph - (int)shift, graphingY + totalGraphWidth));

                }



                //adding letters to graphing lines


                G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                int xstart = 794;
                int ystart = yTop + 2;
                G.FillRectangle(new SolidBrush(Color.White), new Rectangle(xstart, yTop, totalGraphWidth + 10, 15));
                DrawLetters("A", G, xstart, ystart);
                xstart = xstart + 19;
                DrawLetters("1", G, xstart, ystart);
                xstart = xstart + 18;
                DrawLetters("3", G, xstart, ystart);
                xstart += 18;
                DrawLetters("5", G, xstart, ystart);
                xstart += 18;
                DrawLetters("7", G, xstart, ystart);
                xstart += 18;
                DrawLetters("9", G, xstart, ystart);
                xstart += 18;
                DrawLetters("1", G, xstart, ystart);
                xstart += 18;
                DrawLetters("3", G, xstart, ystart);
                xstart += 18;
                DrawLetters("5", G, xstart, ystart);

                ystart = graphingY - 8;
                xstart = xTop;
                G.FillRectangle(new SolidBrush(Color.White), new Rectangle(xTop, ystart, 15, totalGraphWidth + 10));
                DrawLetters("A", G, xstart, ystart);
                ystart += 19;
                DrawLetters("1", G, xstart, ystart);
                ystart += 18;
                DrawLetters("3", G, xstart, ystart);
                ystart += 18;
                DrawLetters("5", G, xstart, ystart);
                ystart += 18;
                DrawLetters("7", G, xstart, ystart);
                ystart += 18;
                DrawLetters("9", G, xstart, ystart);
                ystart += 18;
                DrawLetters("1", G, xstart, ystart);
                ystart += 18;
                DrawLetters("3", G, xstart, ystart);
                ystart += 18;
                DrawLetters("5", G, xstart, ystart);





                G.DrawRectangle(blackPenThick, new Rectangle(xTop, scoringYTop, diagramWidth + 200, 70));

                DrawLetters("Date:", G, xTop, 24, 12);
                DrawLetters("Time:", G, xTop, 66, 12);

                xAxs = xTop + 120;
                DrawLetters("Event:", G, xAxs, 24, 12);
                DrawLetters("Range:", G, xAxs, 66, 12);
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, scoringYTop + 70));

                xAxs = xTop + 300;
                DrawLetters("Comments:", G, xTop + 300, 24, 12);
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, scoringYTop + 70));

                xAxs = xTop + 660;
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, scoringYTop + 70));
                DrawLetters("Target #", G, xAxs, 24, 12);
                xAxs = xTop + diagramWidth + 60;
                G.DrawLine(blackPenThick, new Point(xAxs, scoringYTop), new Point(xAxs, scoringYTop + 70));


                string rangeStr = selectedTarget.Distance.ToString();
                DrawLettersNarrow(rangeStr, G, xTop + diagramWidth + 60, 20, 48);
                int rangeLetterXval = xTop + diagramWidth + 180;
                if (rangeStr.Length == 3)
                    rangeLetterXval = xTop + diagramWidth + 155;
                DrawLettersNarrow("y", G, rangeLetterXval, 50, 24);
            }


            targetDiagram.Image = new Bitmap(680, 500);
            targetDiagram.Location = new Point(xTop, yTop);
            //aiming mark
            using (Graphics G = Graphics.FromImage(targetDiagram.Image))
            {
                var aimMark = (double)selectedTarget.AimInMetric * scalex;
                var x = (targetDiagram.Width - (int)aimMark) / 2;
                var y = (targetDiagram.Height - (int)aimMark) / 2;

                G.FillEllipse(new SolidBrush(Color.LightGray), x, y, (int)aimMark, (int)aimMark);

            }
            //outer
            using (Graphics G = Graphics.FromImage(targetDiagram.Image))
            {
                var aimMark = (double)selectedTarget.OuterInMetric * scalex;
                var x = (targetDiagram.Width - (int)aimMark) / 2;
                var y = (targetDiagram.Height - (int)aimMark) / 2;
                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                G.DrawEllipse(new Pen(Color.Black, 2), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //magpie
            using (Graphics G = Graphics.FromImage(targetDiagram.Image))
            {
                var aimMark = (double)selectedTarget.MagpieInMetric * scalex;
                var x = (targetDiagram.Image.Width - (int)aimMark) / 2;
                var y = (targetDiagram.Image.Height - (int)aimMark) / 2;
                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                G.DrawEllipse(new Pen(Color.Black, 2), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //inner
            using (Graphics G = Graphics.FromImage(targetDiagram.Image))
            {
                var aimMark = (double)selectedTarget.InnerInMetric * scalex;
                var x = (targetDiagram.Image.Width - (int)aimMark) / 2;
                var y = (targetDiagram.Image.Height - (int)aimMark) / 2;
                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                G.DrawEllipse(new Pen(Color.Black, 2), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //bull
            using (Graphics G = Graphics.FromImage(targetDiagram.Image))
            {
                var aimMark = (double)selectedTarget.BullInMetric * scalex;
                var x = (targetDiagram.Image.Width - (int)aimMark) / 2;
                var y = (targetDiagram.Image.Height - (int)aimMark) / 2;
                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                G.DrawEllipse(new Pen(Color.Black, 2), x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //vbull
            using (Graphics G = Graphics.FromImage(targetDiagram.Image))
            {
                float[] dashValues = { 5, 3 };

                var aimMark = (double)selectedTarget.VBullInMetric * scalex;
                var x = (targetDiagram.Image.Width - (int)aimMark) / 2;
                var y = (targetDiagram.Image.Height - (int)aimMark) / 2;
                var pen = new Pen(Color.Black, 2);
                pen.DashPattern = dashValues;

                G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                G.DrawEllipse(pen, x, y, (int)Math.Round(aimMark), (int)Math.Round(aimMark));

            }
            //draw the Moa lines
            using (Graphics G = Graphics.FromImage(targetDiagram.Image))
            {
                //Pen blackPen = new Pen(Color.Black, 1);
                int lenght = 0;
                blackPen.DashStyle = DashStyle.Dot;
                double shift = 0;
                for (int i = 1; (centerpoint + (int)shift) < targetDiagram.Width; i++)
                {
                    //cross lines
                    G.DrawLine(blackPen, new Point(centerpoint, 0), new Point(centerpoint, 680));
                    G.DrawLine(blackPen, new Point(0, centerpointy), new Point(680, centerpointy));
                    shift = (i * moaMM * range) * scalex;

                    G.DrawLine(blackPen, new Point(centerpoint + (int)shift, 0), new Point(centerpoint + (int)shift, 500));
                    G.DrawLine(blackPen, new Point(centerpoint - (int)shift, 0), new Point(centerpoint - (int)shift, 500));

                    G.DrawLine(blackPen, new Point(0, centerpointy + (int)shift), new Point(680, centerpointy + (int)shift));
                    G.DrawLine(blackPen, new Point(0, centerpointy - (int)shift), new Point(680, centerpointy - (int)shift));
                    lenght = centerpoint + (50 * i) * (int)scalex;

                }



            }

        }

        private void zoomValue_ValueChanged(object sender, EventArgs e)
        {
            plottingDiagram.Invalidate();
        }
    }


}