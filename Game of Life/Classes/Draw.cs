using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Game_of_Life.Classes
{
    static class Draw
    {
        public static void DrawGrid(Graphics g)
        {
            Pen line = new Pen(Color.Gray, 1);

            foreach (Cell c in Grid.Cells)
            {
                if (c.X * Grid.CellSize + Grid.CellSize < Grid.Width && c.Y * Grid.CellSize + Grid.CellSize < Grid.Height )
                {
                    g.DrawRectangle(line, c.X * Grid.CellSize, c.Y * Grid.CellSize, Grid.CellSize, Grid.CellSize);
                }               
            }
        }

        public static void DrawCells(Graphics g)
        {
            foreach (Cell c in Grid.Cells)
            {
                if (c.X * Grid.CellSize + Grid.CellSize < Grid.Width && c.Y * Grid.CellSize + Grid.CellSize < Grid.Height)
                {
                    if (c.Life)
                    {
                        //g.FillRectangle(new SolidBrush(Color.Black), c.X * Grid.CellSize + 1, c.Y * Grid.CellSize + 1, Grid.CellSize - 1, Grid.CellSize - 1);

                        g.FillRectangle(new SolidBrush(Color.Black), c.Hitbox);
                    }
                    else if (!c.Life)
                    {
                        //g.FillRectangle(new SolidBrush(Color.White), c.X * Grid.CellSize + 1, c.Y * Grid.CellSize + 1, Grid.CellSize - 1, Grid.CellSize - 1);

                        g.FillRectangle(new SolidBrush(Color.White), c.Hitbox);
                    }
                }                
            }
        }
    }
}
