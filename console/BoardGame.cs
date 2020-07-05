namespace console
{
    using System;
    using System.Threading;

    public class BoardGame
    {
        public int PlayerChance = 1;
        public int Turns = 0;
        public int Flag = 0;
        public string[,] grid = new string[3, 3] { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

        public void Start()
        {
            do
            {
                CheckTurn();
                LoadBoard();
                var input = Console.ReadLine();

                if (CheckInput(input))
                {
                    Movement(input);
                }
                else
                {
                    Console.WriteLine("Input is wrong, try again.");
                }
                Turns++;
            }
            while (Turns < 9 && Flag != 1 && Flag != 2);
        }

        public void LoadBoard()
        {
            Console.WriteLine("Please enter a number that's on the grid or you'll upset the game. \n");
            Console.WriteLine("  {0}  |  {1}  |  {2}", grid[0, 0], grid[0, 1], grid[0, 2]);
            Console.WriteLine("  {0}  |  {1}  |  {2}", grid[1, 0], grid[1, 1], grid[1, 2]);
            Console.WriteLine("  {0}  |  {1}  |  {2}", grid[2, 0], grid[2, 1], grid[2, 2]);
        }

        public void UpdateGrid(string choice)
        {
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == choice)
                    {
                        if (PlayerChance % 2 == 0)
                        {
                            grid[i, j] = "O";
                            PlayerChance++;
                        }
                        else
                        {
                            grid[i, j] = "X";
                            PlayerChance++;
                        }
                    }
                }
            }
        }

        public void CheckTurn()
        {
            if (PlayerChance % 2 == 0)
            {
                Console.WriteLine("Player 2 Chance");
            }
            else
            {
                Console.WriteLine("Player 1 Chance");
            }
        }

        public void Movement(string choice)
        {
            UpdateGrid(choice);
            Console.WriteLine("\n");
            Console.WriteLine("Board is loading...");
            Thread.Sleep(1000);
            CheckWin();
        }

        public bool CheckInput(string input)
        {
            int num;
            bool result = int.TryParse(input, out num);
            if (result)
            {
                result = num < 10 && num > 0;
            } 
            return result;
        }

        public void CheckWin()
        {
            CheckDiagonal();
            if (Flag == 0)
            {
                CheckHorizontal();
            }
            if (Flag == 1)
            {
                if (PlayerChance - 1 % 2 == 0)
                {
                    Console.WriteLine("Player 2 has won.");
                }
                else
                {
                    Console.WriteLine("Player 1 has won.");
                }
            }
            if (Flag == 2)
            {
                Console.WriteLine("Player 1 and 2 have drawn.");
            }
        }

//check horizontal and check verticle could be improved
        public void CheckHorizontal()
        {
            if (grid[0, 1] == grid[0, 0] && grid[0, 0] == grid[0, 2])
            {
                Flag = 1;
            }
            if (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2])
            {
                Flag = 1;
            }
            if (grid[2, 1] == grid[2, 0] && grid[2, 0] == grid[2, 2])
            {
                Flag = 1;
            }
        }

        public void CheckVertical()
        {
            if (grid[0, 0] == grid[1, 0] && grid[0, 0] == grid[2, 0])
            {
                Flag = 1;
            }
            if (grid[1, 1] == grid[0, 1] && grid[1, 1] == grid[2, 1])
            {
                Flag = 1;
            }
            if (grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 2])
            {
                Flag = 1;
            }
        }

// needs improvement
        public void CheckDiagonal()
        {
            if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2] ||
            grid[0, 2] == grid[1, 2] && grid[1, 2] == grid[2, 0])
            {
                Flag = 2;
            }
        }
    }
}