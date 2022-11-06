
namespace Minesweeper
{
   public class Minesweeper
    {
        static void Main()
        {
            Console.WriteLine("This is you Minesweeper game. Let's Play");

            int Row = 5;
            int Column = 5;
            

            var minefield = new Minefield(Row,Column);
          
            Boolean StatusGame = true;
            while (StatusGame)
            {
                minefield.InitializeField();

                Console.WriteLine();
                Console.Write("Enter the Coordinates: (row,column)");

                var input = Console.ReadLine();

                var seprateCoord = input.Split(',');
                if (seprateCoord.Length < 2)
                {
                    Console.WriteLine("WrongInput");
                }
                else
                {
                    int row = int.Parse(seprateCoord[0]);
                    int column = int.Parse(seprateCoord[1]);
                    minefield.VisitedCell(row, column);
                    if (minefield.GameOver())
                    {
                        minefield.InitializeField();
                        Console.WriteLine("Sorry! You Lose the game");
                        System.Environment.Exit(1);

                    }
                    if (minefield.GameWin())
                    {
                        minefield.InitializeField();
                        Console.WriteLine("Congratulation ! You did it");
                        System.Environment.Exit(0);


                    }
                }
               

            }
            

        }

    }
    }


