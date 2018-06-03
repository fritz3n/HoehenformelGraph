using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HöhenformelGraph
{
    class Graph
    {
        private PictureBox box;

        private IDataset _dataset;
        public IDataset Dataset { get { return _dataset;  } set { _dataset = value;  } } // Multitasking zeugs

        public Graph(PictureBox box, IDataset dataset)
        {
            this.box = box;
            Dataset = dataset;

            dataset.Draw += DrawEvent;
        }
        
        public void Update()
        {
            Dataset.Update();
        }

        private void DrawEvent(object sender, EventArgs e)
        {
            Draw();
        }

        public void Draw()
        {
            double[] data  = Dataset.Data; // data aus dem dataset hollen
            Area area = Dataset.Area; // arae aus dem dataset hollen

            int width = box.Width; // breite aus der PictureBox hollen
            int height = box.Height; // hhe aus der PictureBox hollen

            double min = data.Min(); // minimalen wert aus data hollen
            double max = data.Max(); // maximalen wert aus data hollen
            

            Bitmap bmp = new Bitmap(width, height); //neue Bitmap erstellen

            using (Graphics g = Graphics.FromImage(bmp)) // Grafik objekt zum zeichnen auf der Bitmap erstellen
            {
                Pen r = new Pen(Color.Red); // neeuen roten Pen erstellen

                

                Brush brush = new SolidBrush(Color.White); // die bitmap mit weiss füllen
                Rectangle rect = new Rectangle(0, 0, width, height);
                g.FillRectangle(brush, rect);
                

                Pen b = new Pen(Color.Black); // neuen schwarzen Pen zum zeichnen von Linien erstellen
                Brush bBrush = new SolidBrush(Color.Black); // neue Schawrze Brush zum zeichnen von Text erstellen

                int maxInt = (int)Math.Ceiling(max); // längsten string der x Achse speichern
                string MaxIntS = maxInt.ToString();

                FontFamily fontFamily = new FontFamily("Arial"); // Font erstellen
                Font font = new Font( 
                   fontFamily,
                   16,
                   FontStyle.Regular,
                   GraphicsUnit.Pixel);

                double xLGap = g.MeasureString(MaxIntS, font).Width + 15; // lücke auf der Linken mit der Breite von MaxIntS und weiteren 15px berechnen
                double xRGap = g.MeasureString(area.Map(area.Count).ToString(), font).Width / 2 + 5; // lücke auf der rechten seite berechnen
                
                double yTGap = 13; // obere und untere lücken sind festgelegt
                double yBGap = 31;

                double xRange = width - xRGap - xLGap; // effektiven platz zum zeichnen berechnen
                double yRange = height - yTGap - yBGap;

                // x- und y-Achsen zeichnen
                g.DrawLine(b,
                    new Point((int) xLGap, (int) yTGap),
                    new Point((int) xLGap, height - (int) yBGap));

                g.DrawLine(b,
                    new Point((int)xLGap, height - (int)yBGap),
                    new Point(width - (int)xRGap, height - (int)yBGap));

                double vScale = yRange / (max); // vertikaler scalierungswert wird durch teilen von yRange durch den maximalen wert aus Data berechnet

                double hScale = (xRange) / (double)data.Length; // horizontaler scalierungswert wird durch teilen von xRange durch die Zahl an Elementen in Data berechnet

                StringFormat format = new StringFormat(); // garantiert, dass die String-Mitte auf dem angegeben Vektor liegt
                format.Alignment = StringAlignment.Center;

                
                int yNum = (int)Math.Floor(yRange / 40); // nummer von vertikalen Achsenbeschriftungen wird berechnet
                double yStep = yRange / yNum; // Distanz zwischen Achsenbeschriftungen

                int num = 0;
                double relY = 0; // relative Y-Position im kommendem while-loop

                while (num < yNum + 1)
                {
                    num++;

                    float curY = (float)(height - relY - yBGap - 8); // y-Position berechnen
                    float curX = (float)(xLGap - 15) / 2 + 5; // x-Position berechnen

                    int val = (int)Math.Round((double)relY / vScale); // zu zeichnende Zahl berechnen

                    string text = val.ToString();

                    g.DrawString(text, font, bBrush, curX, curY, format); // Text zeichnen

                    g.DrawLine(b,
                    new Point((int)xLGap - 5, (int) curY + 8),
                    new Point((int)xLGap + 5, (int) curY + 8)); // dazu gehörenden Strich zeichnen

                    
                    if (relY == yRange) // wenn relY an der Position ist, an der maxInt geschrieben wird, ist der loop fertig
                    {
                        break;
                    }

                    relY += yStep; // relY um die Distanz zwischen Beschriftungen erhöhen
                    //height - relY - yBGap - 8
                    if (relY >= yRange) // wenn die künftige zeichen-position gleich / über der maximalen höhe ist:
                    {
                        relY = yRange; // zu der Postion gehen, an der maxInt geschrieben wird gehen, danach wird der loop ein paar zeilen vorher beendet
                        continue;
                    }

                    
                    
                }


                double relX = 0; // relative X-Position im kommendem while-loop

                int xNum = (int)Math.Floor(xRange / (xLGap + 10)); // nummer an X-Achsen Bschriftungen berechnen
                double xStep = (xRange) / xNum; // Distanz zwischen Beschriftungen
                num = 0;

                while (num < xNum + 1)
                {
                    num++;
                    float curX = (float)(relX + xLGap); // x-Position berechnen
                    int val = (int)Math.Round(area.Map(relX / hScale)); // zu zeichnende Zahl berechnen

                    string text = val.ToString();

                    float curY = (float)(height - 21); // y-Position berechnen
                    
                    g.DrawString(text, font, bBrush, curX, curY, format); // Text zeichnen

                    g.DrawLine(b,
                    new Point((int)curX, (int)height - 36),
                    new Point((int)curX, (int)height - 26)); // zugehötige Linie zeichnen

                    if (relX == xRange) // wenn relX an der Position ist, an der Area.End geschrieben wird, ist der loop fertig
                    {
                        break;
                    }

                    relX += xStep;

                    if (relX >= xRange) // wenn die künftige zeichen-position gleich / über der maximalen Breite ist:
                    {
                        relX = xRange; // zu der Postion gehen, an der Area.End geschrieben wird gehen, danach wird der loop ein paar zeilen vorher beendet
                        continue;
                    }



                }

                Point cur; // temporäre Variable für den Punkt, an dem zu zeichnen ist

                Point last = new Point((int) xLGap, height - (int)Math.Max(data[0] * vScale + yTGap + 18, 1)); // ersten Punkt berechnen

                for (int i = 0; i < data.Length; i++)
                {
                    cur = new Point((int)(i * hScale + xLGap), height - (int)Math.Max(data[i] * vScale + yTGap + 18, 1)); // jetzigen Punkt berechnen
                    
                    g.DrawLine(r, last, cur); // Linie zeichnen

                    last = cur;
                    
                }
            }

            //bmp.Save(@"C:\Users\fritzen\Desktop\bmp.png");
            //Console.WriteLine("test");

            box.Image = bmp; // Bild der Picturebox zu dem gerade erstellten Bild setzten
        }

        private void InvokeBox(Action action) // Multitasking zeugs
        {
            if (box.InvokeRequired)
            {
                box.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}
