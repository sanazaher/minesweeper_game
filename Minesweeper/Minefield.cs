using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
   public class Minefield
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Cell[,] cells { get; set; }

        public GameStatus state;
        public int mines;

        public Minefield(int rows, int columns)
        {
            state = GameStatus.RUNNING;
            cells = new Cell[Rows, Columns];
            mines = 5;
          
            Rows = rows;
            Columns = columns;
            cells = CreateEmptyField(Rows, Columns);
            SetBomb(0, 0);
            SetBomb(0, 1);
            SetBomb(1, 1);
            SetBomb(1, 4);
            SetBomb(4, 2);
        }

        private Cell[,] CreateEmptyField(int rows, int columns)
        {

            Cell[,] cell = new Cell[rows, columns];
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Columns; c++)
                {
                    cell[r, c] = new Cell();
                }
            return cell;
        }

        public void SetBomb(int r, int c)
        {
           
           cells[r, c].hasBomb = true;
             
           AddAdjacentValue(r, c);
        }
        public void InitializeField()
        {
            String str;
            for (int r = 0; r < Rows; r++)
            {
                Console.Write("\n");
                for (int c = 0; c < Columns; c++)
                {
                    Cell cell = cells[r, c];
                    str = cell.Create();
                    Console.Write(str);
                }
            }

        }

        public void AddAdjacentValue(int rows, int columns)
        {
            Boolean firstCol = (columns == 0);
            Boolean lastCol = (columns == Columns - 1);
            Boolean firstRow = (rows == 0);
            Boolean lastRow = (rows == Rows - 1);

            if (firstCol == false) { cells[rows, columns - 1].AddNearbyValue(); }

            if (lastCol == false) { cells[rows, columns + 1].AddNearbyValue(); }

            if (firstRow == false) { cells[rows - 1, columns].AddNearbyValue();

                if (firstCol == false) { cells[rows - 1, columns - 1].AddNearbyValue(); }

                if (lastCol == false) { cells[rows - 1, columns + 1].AddNearbyValue(); }
            }

            if (lastRow == false) { cells[rows + 1, columns].AddNearbyValue();
                if (firstCol == false) { cells[rows + 1, columns - 1].AddNearbyValue(); }
            
                if (lastCol == false) { cells[rows + 1, columns + 1].AddNearbyValue(); }
             
            }

        }

        public void VisitedCell(int rows, int columns)
        {
            cells[rows, columns].Visited();
            if (cells[rows, columns].adjacentNeighbour == 0)
            {
                OpenNeighboursValues(rows, columns);
            }
            CheckStatus(rows, columns);
        }
       public Boolean GameOver()
        {
            return state == GameStatus.LOSE;
        }

        public Boolean GameWin()
        {
            return state == GameStatus.WIN;
        }

        public void CheckStatus(int rows, int columns)
        {
            if (cells[rows,columns].hasBomb)
            {
                this.state = GameStatus.LOSE;   
            }
            else { 
       
            if(RemainingCell() == mines){

                this.state = GameStatus.WIN;
                }
            }
        }
        private int RemainingCell()
        {
            int remaining = 0;
            for (int i = 0; i < Rows; i++)
         
                for (int j = 0; j < Columns; j++)
                {
                    if (cells[i, j].cellcovered)
                    {
                        remaining++;
                    }
            }
            return remaining;
        }
        public void OpenUnHide(int rows, int columns)
        {
            if (cells[rows, columns].adjacentNeighbour == 0 && cells[rows - 1, columns].cellcovered == true)
            {
                OpenNeighboursValues(rows, columns);
            }
            cells[rows, columns].Visited();
        }
        public void OpenNeighboursValues(int rows, int columns)
        {
            Boolean firstCol = (columns == 0);
            Boolean lastCol = (columns == Columns - 1);
            Boolean firstRow = (rows == 0);
            Boolean lastRow = (rows == Rows - 1);

            if (firstCol == false) //left
            {
                OpenUnHide(rows, columns - 1);
            }
            if (lastCol == false)  //right
            {
                OpenUnHide(rows, columns + 1);
            }

            if (firstRow == false)
            {
                OpenUnHide(rows - 1, columns);

                if (firstCol == false)
                {
                    OpenUnHide(rows - 1, columns - 1);
                }
                if (lastCol == false)
                {
                    OpenUnHide(rows - 1, columns + 1);
                }
            }

            if (lastRow == false)
            {
                OpenUnHide(rows + 1, columns);

                if (firstCol == false)
                {
                    OpenUnHide(rows + 1, columns - 1);
                }
                if (lastCol == false)
                {
                    OpenUnHide(rows + 1, columns + 1);
                }
            }
        }
        public bool IsPrime(int candidate)
        {
            throw new NotImplementedException("Not implemented.");
        }
    }
    }

   


