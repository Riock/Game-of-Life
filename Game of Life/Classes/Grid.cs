using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life.Classes
{
    static class Grid
    {
        public static List<Cell> Cells { get; private set; }

        public static int Width { get; private set; }
        public static int Height { get; private set; }
        public static int CellSize { get; private set; }

        public static void FillGrid(int size, int xMax, int yMax)
        {
            CellSize = size;
            Width = xMax;
            Height = yMax;
            Cells = new List<Cell>();

            for (int y = 1; y <= Height / size; y++)
            {
                for (int x = 1; x <= Width / size; x++)
                {
                    if (x * Grid.CellSize + Grid.CellSize < Grid.Width && y * Grid.CellSize + Grid.CellSize < Grid.Height)
                    {
                        Cells.Add(new Cell(x, y));
                    }                    
                }
            }
        }

        public static void Step()
        {
            //rules go here
        }

    }
}
