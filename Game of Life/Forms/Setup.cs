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

namespace Game_of_Life.Forms
{
    public partial class Setup : Form
    {
        MainForm Main;
        public Setup(MainForm main)
        {
            InitializeComponent();
            Main = main;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Grid.FillGrid(Convert.ToInt32(nudCellSize.Value), Convert.ToInt32(nudWidth.Value), Convert.ToInt32(nudHeight.Value));
            Main.Refresh();
            this.Close();
        }
    }
}
