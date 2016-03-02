using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Game_of_Life.Classes;

namespace Game_of_Life
{
    public partial class MainForm : Form
    {
        Thread StepThread = new Thread(new ThreadStart(Grid.Step));

        public MainForm()
        {
            InitializeComponent();
            
            Grid.FillGrid(15, 1280, 720);
            //Grid.FillGrid(200, 1000, 800);

            lblWorking.Visible = false;
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
                    pbGrid.Refresh();
                    break;
                }
            }
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            lblWorking.Visible = true;
            Grid.Step();
            pbGrid.Refresh();
            lblWorking.Visible = false;
        }
    }
}
