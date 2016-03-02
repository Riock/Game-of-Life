using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_of_Life.Classes;

namespace Game_of_Life
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Grid.FillGrid(15, 1280, 720);

            foreach (Cell c in Grid.Cells)
            {
                lbCells.Items.Add(c.ToString());
            }
        }

        private void pbGrid_Paint(object sender, PaintEventArgs e)
        {
            Draw.DrawGrid(e.Graphics);
            Draw.DrawCells(e.Graphics);
        }

        private void pbGrid_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Cell c in Grid.Cells)
            {
                if (c.Hitbox.Contains(e.Location))
                {
                    c.Clicked();
                    MessageBox.Show(c.IsEdge.ToString());
                    pbGrid.Refresh();
                    break;
                }
            }
        }
    }
}
