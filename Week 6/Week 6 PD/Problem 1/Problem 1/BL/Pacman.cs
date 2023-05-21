using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.BL
{
    class Pacman
    {
        public int X;
        public int Y;
        public int score;
        public Grid mazeGrid;
        public Pacman (int X, int Y, Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.mazeGrid = mazeGrid;
        }
        public void remove()
        {
            Grid.maze[Y, X].value = ' ';
        }
        public void draw()
        {
            Grid.maze[Y, X].value = 'P';
        }
        public void moveLeft(Cell current)
        {
            X = current.X - 1;
        }
        public void moveRight(Cell current)
        {
            X = current.X + 1;
        }
        public void moveUp(Cell current)
        {
            Y = current.Y - 1;
        }
        public void moveDown(Cell current)
        {
            Y = current.Y + 1;
        }
        public void move()
        {

        }
        public void printScore()
        {
            Console.SetCursorPosition(36, 28);
            Console.Write("Score: " + score);
        }
    }
}
