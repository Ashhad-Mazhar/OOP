using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Threading;

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

            char[,] enemyA = new char[,]
            {
                { ' ', ' ', '_', '_', '_', ' ' },
                { ' ', '(', 'O', 'v', 'O', ')' },
                { '<', '-', '|', ' ', '|', ' ' },
                { ' ', ' ', '|', '_', '|', ' ' }
            };

            MainPlayer s = new MainPlayer();
            Enemy EnemyA = new Enemy();

            int timer = 0;

            char[,] maze = new char[47, 142];

            ReadData(maze);
            PrintMaze(maze);
            PrintPlayer(maze, ref s, mainPlayer);
            while (true)
            {
                PrintScore(ref s.score);
                PrintBulletsRemaining(ref s.bulletsRemaining);
                PrintPlayerHealth(ref s.playerHealth);
                Console.SetCursorPosition(0, 0);
                PrintMaze(maze);
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    MovePlayerLeft(maze, ref s, mainPlayer);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    MovePlayerRight(maze, ref s, mainPlayer);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    MovePlayerUp(maze, ref s, mainPlayer);
                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    MovePlayerDown(maze, ref s, mainPlayer);
                }

                if (timer % 3 == 0)
                {
                    MoveEnemyA(maze, ref EnemyA, enemyA);
                }
                timer++;
                Thread.Sleep(1);
                if (s.playerHealth <= 0)
                {
                    GameOverScreen(ref s.score);
                    break;
                }
            }
        }

        static void PrintScore(ref int score)
        {
            //Used to print the player's curent score
            Console.SetCursorPosition(65, 94);
            Console.Write("Score: " + score);
        }

        static void MoveEnemyA(char[,] maze, ref Enemy EnemyA, char[,] enemy)
        {
            // Used to change enemy's position
            if (EnemyA.EnemyDirection == "Up")
            {
                if (maze[EnemyA.EnemyY - 1, EnemyA.EnemyX] == ' ')
                {
                    EraseEnemy(maze, ref EnemyA);
                    EnemyA.EnemyY--;
                    PrintEnemy(maze, ref EnemyA, enemy);
                }
                if (maze[EnemyA.EnemyY - 1, EnemyA.EnemyX] == '#')
                {
                    EnemyA.EnemyDirection = "Down";
                }
            }
            if (EnemyA.EnemyDirection == "Down")
            {
                if (maze[EnemyA.EnemyY + 4, EnemyA.EnemyX] == ' ')
                {
                    EraseEnemy(maze, ref EnemyA);
                    EnemyA.EnemyY++;
                    PrintEnemy(maze, ref EnemyA, enemy);
                }
                if (maze[EnemyA.EnemyY + 4, EnemyA.EnemyX] == '#')
                {
                    EnemyA.EnemyDirection = "Up";
                }
            }
        }

        static void PrintEnemy(char[,] maze, ref Enemy EnemyA, char[,] enemy)
        {
            // Used to display enemy on the screen
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    maze[EnemyA.EnemyY + i, EnemyA.EnemyX + j] = enemy[i, j];
                }
            }
        }

        static void EraseEnemy(char[,] maze, ref Enemy EnemyA)
        {
            // Used to erase the enemy from the screen
            for (int i = 0; i < 4; i++)
            {
                for (int index = 0; index < 6; index++)
                {
                    maze[EnemyA.EnemyY + i, EnemyA.EnemyX + index] = ' ';
                }
            }
        }

        static void MovePlayerUp(char[,] maze, ref MainPlayer s, char[,] mainPlayer)
        {
            // Used to move the player one space upward
            if (maze[s.mainPlayerY - 1, s.mainPlayerX] == ' ')
            {
                ErasePlayer(maze, ref s);
                s.DecrementMainPlayerY();
                PrintPlayer(maze, ref s, mainPlayer);
            }
        }
        static void MovePlayerDown(char[,] maze, ref MainPlayer s, char[,] mainPlayer)
        {
            // Used to move the player one space downward
            if (maze[s.mainPlayerY + 1, s.mainPlayerX] == ' ')
            {
                ErasePlayer(maze, ref s);
                s.IncrementMainPlayerY();
                PrintPlayer(maze, ref s, mainPlayer);
            }
        }
        static void MovePlayerLeft(char[,] maze, ref MainPlayer s, char[,] mainPlayer)
        {
            // Used to move the player one space left
            if (maze[s.mainPlayerY, s.mainPlayerX - 1] == ' ')
            {
                ErasePlayer(maze, ref s);
                s.DecrementMainPlayerX();
                PrintPlayer(maze, ref s, mainPlayer);
            }
        }
        static void MovePlayerRight(char[,] maze, ref MainPlayer s, char[,] mainPlayer)
        {
            // Used to move the player one space right
            if (maze[s.mainPlayerX + 1, s.mainPlayerY] == ' ')
            {
                ErasePlayer(maze, ref s);
                s.IncrementMainPlayerX();
                PrintPlayer(maze, ref s, mainPlayer);
            }
        }

        static void PrintPlayer(char[,] maze, ref MainPlayer s, char[,] mainPlayer)
        {
            // Used to display the player on the screen
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    maze[s.mainPlayerY + i, s.mainPlayerX + j] = mainPlayer[i, j];
                }
            }
        }

        static void ErasePlayer(char[,] maze, ref MainPlayer s)
        {
            // Used to erase the player from the screen
            for (int i = 0; i < 4; i++)
            {
                for (int index = 0; index < 6; index++)
                {
                    maze[s.mainPlayerY + i, s.mainPlayerX + index] = ' ';
                }
            }
        }

        static void PrintMaze(char[,] maze)
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

        static void ReadData(char[,] maze)
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

        static void PrintBulletsRemaining(ref int bulletsRemaining)
        {
            // Used to display the number of bullets remaining
            Console.SetCursorPosition(65, 96);
            Console.Write("Bullets:          ");
            Console.SetCursorPosition(65, 96);
            Console.Write("Bullets: " + bulletsRemaining);
        }

        static void PrintPlayerHealth(ref int playerHealth)
        {
            // Used to display the player's health
            Console.SetCursorPosition(65, 98);
            Console.Write("Health:           ");
            Console.SetCursorPosition(65, 98);
            Console.Write("Health: " + playerHealth);
        }

        static void GameOverScreen(ref int score)
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
        class MainPlayer
        {
            public int mainPlayerX;
            public int mainPlayerY;
            public int playerHealth;
            public int bulletsRemaining;
            public int score;
            public MainPlayer()
            {
                mainPlayerX = 10;
                mainPlayerY = 42;
                playerHealth = 100;
                score = 0;
                bulletsRemaining = 100;
            }
            public void DecrementMainPlayerY()
            {
                mainPlayerY--;
            }
            public void IncrementMainPlayerY()
            {
                mainPlayerY++;
            }
            public void DecrementMainPlayerX()
            {
                mainPlayerX--;
            }
            public void IncrementMainPlayerX()
            {
                mainPlayerX++;
            }
        }

        class Enemy
        {
            public int EnemyX;
            public int EnemyY;
            public string EnemyDirection;
            public Enemy()
            {
                EnemyX = 30;
                EnemyY = 10;
                EnemyDirection = "Up";
            }
        }
    }
}