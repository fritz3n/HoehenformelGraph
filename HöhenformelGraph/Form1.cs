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
            graph.Update();
        }

        private void EndNum_ValueChanged(object sender, EventArgs e)
        {
            hFormel.Area.End = (double)EndNum.Value;
            graph.Update();
        }

        private void DensityNum_ValueChanged(object sender, EventArgs e)
        {
            hFormel.Area.Density = (double)DensityNum.Value;
            graph.Update();
        }

        private void ZeroPressureNum_ValueChanged(object sender, EventArgs e)
        {
            hFormel.ZeroPressure = (double)ZeroPressureNum.Value;
            graph.Update();
        }

        private void ZeroTempNum_ValueChanged(object sender, EventArgs e)
        {
            hFormel.Temp.ZeroTemp = (double)ZeroTempNum.Value;
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            if(ready)
                graph.Draw();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
    }
