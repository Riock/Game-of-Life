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
        public static int CellWidth { get; private set; }
        public static int CellHeight { get; private set; }
        public static int CellSize { get; private set; }

        public static void FillGrid(int size, int xMax, int yMax)
        {
            CellSize = size;
            Width = xMax;
            Height = yMax;
            Cells = new List<Cell>();
            CellWidth = 0;
            CellHeight = 0;

            for (int y = 1; y <= Height / size; y++)
            {
                for (int x = 1; x <= Width / size; x++)
                {
                    if (x * Grid.CellSize + Grid.CellSize < Grid.Width && y * Grid.CellSize + Grid.CellSize < Grid.Height)
                    {
                        Cells.Add(new Cell(x, y));

                        if (x > CellWidth)
                        {
                            CellWidth = x;
                        }
                        if (y > CellHeight)
                        {
                            CellHeight = y;
                        }
                    }
                }
            }
        }

        public static void Step()
        {
            foreach (Cell c in Cells)
            {
                Cell[] Area = new Cell[8]; 

                //for loop looks for 8 neighbours, starting at the top left clockwise
                for (int i = 0; i < 8; i++)
                {
                    if (i == 0)
                    {
                        Area[i] = FindCell(c.X - 1, c.Y - 1);
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                    else if (i == 1)
                    {
                        Area[i] = FindCell(c.X, c.Y - 1);
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                    else if (i == 2)
                    {
                        Area[i] = FindCell(c.X + 1, c.Y - 1);
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                    else if (i == 3)
                    {
                        Area[i] = FindCell(c.X + 1, c.Y);
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                    else if (i == 4)
                    {
                        Area[i] = FindCell(c.X + 1, c.Y + 1);
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                    else if (i == 5)
                    {
                        Area[i] = FindCell(c.X, c.Y + 1);
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                    else if (i == 6)
                    {
                        Area[i] = FindCell(c.X - 1, c.Y + 1);
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                    else if (i == 7)
                    {
                        Area[i] = FindCell(c.X - 1, c.Y );
                        if (Area[i] == null)
                        {
                            Area[1] = new Cell();
                        }
                    }
                }

                //life check logic here

                //count life in area
                int liveInArea = 0;
                foreach (Cell a in Area)
                {
                    if (a == null)
                    {
                        //just so I could use the else. sloppy I know
                    }
                    else if (a.Life)
                    {
                        liveInArea++;
                    }
                }
                
                //update current cell
                if (c.Life && liveInArea < 2)
                {
                    c.LifeNew = false;
                }
                else if (c.Life && liveInArea >= 2 && liveInArea <= 3)
                {
                    c.LifeNew = true;
                }
                else if (c.Life && liveInArea > 3)
                {
                    c.LifeNew = false;
                }
                else if (!c.Life && liveInArea == 3)
                {
                    c.LifeNew = true;
                }
            }
            UpdateCells();
        }

        /// <summary>
        /// Returns the cell at the specified coordinates
        /// </summary>
        /// <param name="x">x coordinate within the cell grid</param>
        /// <param name="y">y coordinate within the cell grid</param>
        /// <returns>returns the cell, or null if there is no cell at the specified coordinates</returns>
        private static Cell FindCell(int x, int y)
        {
            Cell ret = null;

            foreach (Cell c in Cells)
            {
                if (c.X == x && c.Y == y)
                {
                    ret = c;
                    break;
                }
            }
            return ret;
        }

        private static void UpdateCells()
        {
            foreach (Cell c in Cells)
            {
                c.Life = c.LifeNew;
            }
        }
    }
}
