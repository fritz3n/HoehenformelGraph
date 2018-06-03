using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HöhenformelGraph
{
    public partial class Form1 : Form
    {
        Höhenformel hFormel = new Höhenformel(new LinearTempProvider());

        Graph graph;
        bool ready = false;

        public Form1()
        {
            InitializeComponent();

            //TestSet test = new TestSet();
            //test.Area = new Area(0, 10000, 100);


            graph = new Graph(pictureBox, hFormel);

            hFormel.Area = new Area(0, 10000, 100);

            graph.Update();

            ready = true;
        }

        private void StartNum_ValueChanged(object sender, EventArgs e)
        {
            hFormel.Area.Start = (double)StartNum.Value;
        }

        private void EndNum_ValueChanged(object sender, EventArgs e)
        {
            hFormel.Area.End = (double)EndNum.Value;
        }

        private void DensityNum_ValueChanged(object sender, EventArgs e)
        {
            hFormel.Area.Density = (double)DensityNum.Value;
        }

        private void CalcButt_Click(object sender, EventArgs e)
        {
            graph.Update();
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            if(ready)
                graph.Update();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            graph.MousePoint = e.Location;
            graph.Draw();
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            graph.MouseActive = true;
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            graph.MouseActive = false;
        }
    }
}
