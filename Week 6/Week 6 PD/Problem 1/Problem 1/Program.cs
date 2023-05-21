using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Problem_1.BL;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "maze.txt";

            // Initializtion
            Grid mazeGrid = new Grid(24, 71, path);

            Pacman player = new Pacman(9, 32, mazeGrid);
            Ghost ghost1 = new Ghost(15, 39, 'H', "left", 0.1F, ' ', mazeGrid);
            Ghost ghost2 = new Ghost(20, 57, 'V', "up", 0.2F, ' ', mazeGrid);
            Ghost ghost3 = new Ghost(19, 26, 'R', "up", 1F, ' ', mazeGrid);
            Ghost ghost4 = new Ghost(18, 21, 'C', "up", 0.5F, ' ', mazeGrid);

            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            enemies.Add(ghost3);
            enemies.Add(ghost4);

            Grid.draw();
            player.draw();

            bool gameRunning = true;

            while(gameRunning)
            {
                Thread.Sleep(90);

                player.printScore();
                player.remove();
                player.move();
                player.draw();

                foreach (Ghost g in enemies)
                {
                    g.remove();
                    g.move();
                    g.draw();
                }

                if(mazeGrid.isStoppingCondition())
                {
                    gameRunning = false;
                }
            }
            Console.ReadKey();
        }
    }
}
