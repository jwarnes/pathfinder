using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace a_star
{
    public partial class main : Form
    {
        public Graphics g;
        float size = 5f;
        public List<Node> nodemap = new List<Node>();
        public List<Node> path = new List<Node>();
        public main()
        {
            InitializeComponent();
            nodemap.Add(new Node(10, 20));
            nodemap.Add(new Node(30, 25));
            nodemap.Add(new Node(40, 40));
            nodemap.Add(new Node(100, 20));

            Node.Connect(nodemap[0], nodemap[1]);
            Node.Connect(nodemap[0], nodemap[2]);
            Node.Connect(nodemap[1], nodemap[2]);
            Node.Connect(nodemap[2], nodemap[3]);

            numEnd.Maximum = nodemap.Count-1;
            numStart.Maximum = nodemap.Count-1;
        }


        public void Redraw()
        {
            pic.Image = new Bitmap(panel1.Width, panel1.Height);
            g = Graphics.FromImage(pic.Image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Draw();

        }
        public void Draw()
        {
            g.Clear(Color.CornflowerBlue);
            foreach (var n in nodemap)
            {
                var pen = Pens.Blue; var brush = Brushes.Blue;

                g.DrawRectangle(pen, n.x - (size / 2), n.y - (size / 2), size,size);
                g.FillRectangle(brush, n.x - (size / 2), n.y - (size / 2), size,size);
                foreach(var c in n.connected)
                {
                    g.DrawLine(pen, n.x, n.y, c.x, c.y);
                }
            }
            Node lastNode = path.First();
            foreach(var n in path)
            {
                var pen = Pens.LimeGreen; var brush = Brushes.LimeGreen;

                g.DrawRectangle(pen, n.x - (size / 2), n.y - (size / 2), size, size);
                g.FillRectangle(brush, n.x - (size / 2), n.y - (size / 2), size, size);
                g.DrawLine(pen, n.x, n.y, lastNode.x, lastNode.y);
                lastNode = n;
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            Redraw();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            path = Pathfinder.findPath(nodemap[(int)numStart.Value], nodemap[(int)numEnd.Value]);

            Redraw();
        }
    }
}
