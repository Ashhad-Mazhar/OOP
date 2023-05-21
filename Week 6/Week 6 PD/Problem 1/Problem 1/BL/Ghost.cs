using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.BL
{
    class Ghost
    {
        public int X;
        public int Y;
        public string ghostDirection;
        public char ghostCharacter;
        public float speed;
        public char previousItem;
        public float deltaChange;
        public Grid mazeGrid;
        public Ghost(int X, int Y, char ghostCharacter, string ghostDirection, float speed, char previousItem, Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.speed = speed;
            this.previousItem = previousItem;
            this.mazeGrid = mazeGrid;
        }
        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
        public void remove()
        {
            Grid.maze[Y, X].value = ' ';
        }
        public void draw()
        {
            Grid.maze[Y, X].value = ghostCharacter;
        }
        public char getCharacter()
        {
            return ghostCharacter;
        }
        public void ChangeDelta()
        {
            deltaChange = deltaChange + speed;
        }
        public float getDelta()
        {
            return deltaChange;
        }
        public void setDeltaZero()
        {
            deltaChange = 0;
        }
        public void move()
        {
            ChangeDelta();
            if (Math.Floor(getDelta()) == 1)
            {
                if (ghostCharacter == 'H')
                {
                    moveHorizontal();
                }
                if (ghostCharacter == 'V')
                {
                    moveVertical();
                }
                if (ghostCharacter == 'R')
                {
                    moveRandom();
                }
                if (ghostCharacter == 'C')
                {
                    moveSmart();
                }
                setDeltaZero();
            }
        }
        public void moveHorizontal()
        {
            if (ghostDirection == "left")
            {
                X -= 1;
            }
            else if (ghostDirection == "right")
            {
                X += 1;
            }
        }
        public void moveVertical()
        {
            if (ghostDirection == "up")
            {
                Y -= 1;
            }
            else if (ghostDirection == "down")
            {
                Y += 1;
            }
        }
        public int generateRandom()
        {
            Random random = new Random();
            return random.Next();
        }
        public void moveRandom()
        {
            int randomValue = generateRandom();
            if (randomValue % 2 == 0)
            {
                moveHorizontal();
            }
            else
            {
                moveVertical();
            }
        }
        public void moveSmart()
        {
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            if (Grid.maze[X, Y - 1].getValue() != '|' && Grid.maze[X, Y - 1].getValue() != '%')
            {
                distance[0] = (calculateDistance(X, Y - 1, pX, pY));
            }
            if (Grid.maze[X, Y + 1].getValue() != '|' && Grid.maze[X, Y + 1].getValue() != '%')
            {
                distance[1] = (calculateDistance(X, Y + 1, pX, pY));
            }
            if (Grid.maze[X + 1, Y].getValue() != '|' && Grid.maze[X + 1, Y].getValue() != '%' && Grid.maze[X + 1, Y].getValue() != '#')
            {
                distance[2] = (calculateDistance(X + 1, Y, pX, pY));
            }
            if (Grid.maze[X - 1, Y].getValue() != '|' && Grid.maze[X - 1, Y].getValue() != '%' && Grid.maze[X - 1, Y].getValue() != '#')
            {
                distance[3] = (calculateDistance(X - 1, Y, pX, pY));
            }
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                ghostDirection = "left";
                moveGhostInLine();
            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                ghostDirection = "right";
                moveGhostInLine();
            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                ghostDirection = "down";
                moveGhostInLine();
            }
            else
            {
                ghostDirection = "up";
                moveGhostInLine();
            } 
        }
        public bool moveGhostInLine()
        {
            if (Grid.maze[X, Y - 1].getValue() == 'P' || Grid.maze[X, Y + 1].getValue()  == 'P' || Grid.maze[X + 1, Y].getValue() == 'P' || Grid.maze[X - 1, Y].getValue() == 'P')
            {
                return false;
            }
            if (ghostDirection == "left" && (Grid.maze[X, Y - 1].getValue() == ' ' || Grid.maze[X, Y - 1].getValue() == '.'))
            {
                Grid.maze[X, Y].value = previousItem;
                Console.SetCursorPosition(Y, X);
                Console.Write(previousItem);

                Y = Y - 1;

                previousItem = Grid.maze[X, Y].getValue();
                Console.SetCursorPosition(Y, X);
                Console.Write("G");
                if (Grid.maze[X, Y - 1].getValue() == '|')
                {
                    ghostDirection = "right";
                }
            }
            else if (ghostDirection == "right" && (Grid.maze[X, Y + 1].getValue() == ' ' || Grid.maze[X, Y + 1].getValue() == '.'))
            {
                Grid.maze[X, Y].value = previousItem;
                Console.SetCursorPosition(Y, X);
                Console.Write(previousItem);

                Y = Y + 1;

                previousItem = Grid.maze[X, Y].getValue();
                Console.SetCursorPosition(Y, X);
                Console.Write("G");
                if (Grid.maze[X, Y + 1].getValue() == '|')
                {
                    ghostDirection = "left";
                }
            }
            else if (ghostDirection == "up" && (Grid.maze[X - 1, Y].getValue() == ' ' || Grid.maze[X - 1, Y].getValue() == '.'))
            {
                Grid.maze[X, Y].value = previousItem;
                Console.SetCursorPosition(Y, X);
                Console.Write(previousItem);

                X = X - 1;

                previousItem = Grid.maze[X, Y].getValue();
                Console.SetCursorPosition(Y, X);
                Console.Write("G");
                if (Grid.maze[X - 1, Y].getValue() == '%' || Grid.maze[X - 1, Y].getValue() == '#')
                {
                    ghostDirection = "down";
                }
            }
            else if (ghostDirection == "down" && (Grid.maze[X + 1, Y].getValue() == ' ' || Grid.maze[X + 1, Y].getValue() == '.'))
            {
                Grid.maze[X, Y].value = previousItem;
                Console.SetCursorPosition(Y, X);
                Console.Write(previousItem);

                X = X + 1;

                previousItem = Grid.maze[X, Y].getValue();
                Console.SetCursorPosition(Y, X);
                Console.Write("G");
                if (Grid.maze[X + 1, Y].getValue() == '%' || Grid.maze[X + 1, Y].getValue() == '#')
                {
                    ghostDirection = "up";
                }
            }
            return true;
        }
        public double calculateDistance(Cell current, Cell pacmanLocation)
        {
            double distance = Math.Sqrt(Math.Pow(pacmanLocation.Y - current.Y, 2) + Math.Pow(pacmanLocation.X - current.X, 2));
            return distance;
        }
    }
}