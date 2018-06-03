using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HöhenformelGraph
{
    class TestSet : IDataset
    {
        public Area Area { get; set; }

        public double[] Data { get; set; }

        public event EventHandler Draw;

        public void Update()
        {
            Data = new double[Area.Count];

            for (int i = 0; i < Area.Count; i++)
            {
                Data[i] = 10000 - Area.Map(i);
            }

            CallDraw();
        }

        private void CallDraw() // Ruft das Draw event auf
        {
            Draw?.Invoke(this, EventArgs.Empty);
        }
    }
}
