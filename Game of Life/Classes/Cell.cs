using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game_of_Life.Classes
{
    class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool Life { get; private set; }
        public Rectangle Hitbox { get; private set; }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Life = false;
            this.Hitbox = new Rectangle(X * Grid.CellSize + 1, Y * Grid.CellSize + 1, Grid.CellSize - 1, Grid.CellSize - 1);
        }

        public void Clicked()
        {
            this.Life = !Life;
        }

        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ")";
        } 
    }
}
