using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Cell
    {
        public bool hasBomb { get; set; }
        public bool cellcovered { get; set; }
        public int adjacentNeighbour { get; set; }

        public Cell()
        {

            hasBomb = false;
            cellcovered = true;
            adjacentNeighbour = 0;

        }
        public String Create()
        {
            String result;
            if (cellcovered == true)
            {
                result = "?"; //covered cell
            }
            else
            {
                if (hasBomb == true)
                {
                    result = "*"; //Bomb
                }
                else
                {
                    if (adjacentNeighbour == 0)
                    {
                        result = " "; // uncovered cell
                    }
                    else
                    {
                        result = adjacentNeighbour.ToString();
                    }
                }
            }
            return result;
        }



        public void AddNearbyValue()
        {
            adjacentNeighbour++;
        }

        public void Visited()
        {
            cellcovered = false;
        }

    }
}


