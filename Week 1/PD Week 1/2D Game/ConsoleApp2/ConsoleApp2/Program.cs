using System;
using System.Threading;
using EZInput;
using System.IO;

namespace _2D_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] mainPlayer = new char[,]
            {
                { ' ', '_', '_', '_', ' ', ' ' },
                { '(', 'O', 'v', 'O', ')', ' ' },
                { ' ', '|', ' ', '|', '-', '>' },
                { ' ', '|', '_', '|', ' ', ' ' }
            };

            char[,] enemy = new char[,]
            {
                { ' ', ' ', '_', '_', '_', ' ' },
                { ' ', '(', 'O', 'v', 'O', ')' },
                { '<', '-', '|', ' ', '|', ' ' },
                { ' ', ' ', '|', '_', '|', ' ' }
            };

            int mainPlayerX = 10;
            int mainPlayerY = 42;
            int enemyX = 30;
            int enemyY = 10;

            int playerHealth = 100;
            int enemyHealth = 50;

            string enemyDirection = "Up";

            int timer = 0;

            int score = 0;

            int bulletsRemaining = 100;

            char[,] maze = new char[47, 142];

            readData(maze);
            printMaze(maze);
            printPlayer(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
            while (true)
            {
                printScore(ref score);
                printBulletsRemaining(ref bulletsRemaining);
                printPlayerHealth(ref playerHealth);
                Console.SetCursorPosition(0, 0);
                printMaze(maze);
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    movePlayerLeft(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    movePlayerRight(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    movePlayerUp(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    movePlayerDown(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
                }

                if (timer % 3 == 0)
                {
                    moveEnemy(maze, ref enemyX, ref enemyY, ref enemyDirection, enemy);
                }
                timer++;
                Thread.Sleep(1);
                if (s.playerHealth <= 0)
                {
                    gameOverScreen(ref s.score);
                    break;
                }
            }
        }

        static void printScore(ref int score)
        {
            //Used to print the player's curent score
            Console.SetCursorPosition(65, 94);
            Console.Write("Score: " + score);
        }

        static void moveEnemy(char[,] maze, ref int enemyX, ref int enemyY, ref string enemyDirection, char[,] enemy)
        {
            // Used to change enemy's position
            if (enemyDirection == "Up")
            {
                if (maze[enemyY - 1, enemyX] == ' ')
                {
                    eraseEnemy(maze, ref enemyX, ref enemyY);
                    enemyY--;
                    printEnemy(maze, ref enemyX, ref enemyY, enemy);
                }
                if (maze[enemyY - 1, enemyX] == '#')
                {
                    enemyDirection = "Down";
                }
            }
            if (enemyDirection == "Down")
            {
                if (maze[enemyY + 4, enemyX] == ' ')
                {
                    eraseEnemy(maze, ref enemyX, ref enemyY);
                    enemyY++;
                    printEnemy(maze, ref enemyX, ref enemyY, enemy);
                }
                if (maze[enemyY + 4, enemyX] == '#')
                {
                    enemyDirection = "Up";
                }
            }
        }

        static void printEnemy(char[,] maze, ref int enemyX, ref int enemyY, char[,] enemy)
        {
            // Used to display enemy on the screen
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    maze[enemyY + i, enemyX + j] = enemy[i, j];
                }
            }
        }

        static void eraseEnemy(char[,] maze, ref int enemyX, ref int enemyY)
        {
            // Used to erase the enemy from the screen
            for (int i = 0; i < 4; i++)
            {
                for (int index = 0; index < 6; index++)
                {
                    maze[enemyY + i, enemyX + index] = ' ';
                }
            }
        }

        static void movePlayerUp(char[,] maze, ref int mainPlayerX, ref int mainPlayerY, char[,] mainPlayer)
        {
            // Used to move the player one space upward
            if (maze[mainPlayerY - 1, mainPlayerX] == ' ')
            {
                erasePlayer(maze, ref mainPlayerX, ref mainPlayerY);
                mainPlayerY--;
                printPlayer(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
            }
        }
        static void movePlayerDown(char[,] maze, ref int mainPlayerX, ref int mainPlayerY, char[,] mainPlayer)
        {
            // Used to move the player one space downward
            if (maze[mainPlayerY + 1, mainPlayerX] == ' ')
            {
                erasePlayer(maze, ref mainPlayerX, ref mainPlayerY);
                mainPlayerY++;
                printPlayer(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
            }
        }
        static void movePlayerLeft(char[,] maze, ref int mainPlayerX, ref int mainPlayerY, char[,] mainPlayer)
        {
            // Used to move the player one space left
            if (maze[mainPlayerY, mainPlayerX - 1] == ' ')
            {
                erasePlayer(maze, ref mainPlayerX, ref mainPlayerY);
                mainPlayerX--;
                printPlayer(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
            }
        }
        static void movePlayerRight(char[,] maze, ref int mainPlayerX, ref int mainPlayerY, char[,] mainPlayer)
        {
            // Used to move the player one space right
            if (maze[mainPlayerX + 1, mainPlayerY] == ' ')
            {
                erasePlayer(maze, ref mainPlayerX, ref mainPlayerY);
                mainPlayerX = mainPlayerX + 1;
                printPlayer(maze, ref mainPlayerX, ref mainPlayerY, mainPlayer);
            }
        }

        static void printPlayer(char[,] maze, ref int mainPlayerX, ref int mainPlayerY, char[,] mainPlayer)
        {
            // Used to display the player on the screen
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    maze[mainPlayerY + i, mainPlayerX + j] = mainPlayer[i, j];
                }
            }
        }

        static void erasePlayer(char[,] maze, ref int mainPlayerX, ref int mainPlayerY)
        {
            // Used to erase the player from the screen
            for (int i = 0; i < 4; i++)
            {
                for (int index = 0; index < 6; index++)
                {
                    maze[mainPlayerY + i, mainPlayerX + index] = ' ';
                }
            }
        }

        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }

        static void readData(char[,] maze)
        {
            StreamReader fp = new StreamReader("maze.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 142; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }
            fp.Close();
        }

        static void printBulletsRemaining(ref int bulletsRemaining)
        {
            // Used to display the number of bullets remaining
            Console.SetCursorPosition(65, 96);
            Console.Write("Bullets:          ");
            Console.SetCursorPosition(65, 96);
            Console.Write("Bullets: " + bulletsRemaining);
        }

        static void printPlayerHealth(ref int playerHealth)
        {
            // Used to display the player's health
            Console.SetCursorPosition(65, 98);
            Console.Write("Health:           ");
            Console.SetCursorPosition(65, 98);
            Console.Write("Health: " + playerHealth);
        }

        static void gameOverScreen(ref int score)
        {
            // Used to print the game over screen
            Console.Clear();
            Console.WriteLine("      _____                  ");
            Console.WriteLine("     / ___/ ___ _  __ _  ___ ");
            Console.WriteLine("    / (_ / / _ `/ /  ' \\/ -_)");
            Console.WriteLine("    \\___/  \\_,_/ /_/_/_/\\__/ ");
            Console.WriteLine(" ");
            Console.WriteLine("      ____                   ");
            Console.WriteLine("     / __ \\ _  __ ___   ____ ");
            Console.WriteLine("    / /_/ /| |/ // -_) / __/ ");
            Console.WriteLine("    \\____/ |___/ \\__/ /_/    ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("     Your score: " + score);
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
