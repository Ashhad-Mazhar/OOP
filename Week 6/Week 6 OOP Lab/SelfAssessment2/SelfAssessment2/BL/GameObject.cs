using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfAssessment2.BL
{
    class GameObject
    {
        public void Move()
        {
            if (Direction == "LeftToRight")
            {
                MoveLeftToRight();
            }
            else if (Direction == "RightToLeft")
            {
                MoveRightToLeft();
            }

            else if (Direction == "Patrol")
            {
                MovePatrol();
            }

            else if (Direction == "Diagonal")
            {
                MoveDiagonal();
            }

            else if (Direction == "Projectile")
            {
                Projectile();
            }
        }


        public void Projectile()
        {
            if (StartPoint.x >= 0 || StartPoint.x <= 0)
            {
                if (d2 < 6)
                {
                    if (StartPoint.x < Premises.topRight.x)
                    {
                        StartPoint.y++;
                        StartPoint.x--;
                        d2++;
                    }
                }
                if (d2 >= 6 && d2 < 9)
                {
                    if (StartPoint.y < Premises.topRight.x)
                    {
                        StartPoint.y++;
                        d2++;
                    }
                }
                if (d2 >= 9 && d2 < 13)
                {
                    if (StartPoint.x <= Premises.bottomRight.y)
                    {
                        StartPoint.y++;
                        StartPoint.x++;
                        d2++;
                    }
                }

            }
        }
        public void MoveDiagonal()
        {
            if (StartPoint.x <= Premises.bottomRight.y)
            {
                StartPoint.y++;
                StartPoint.x++;
            }
        }
        public void MovePatrol()
        {

            if (d == "left")
            {
                if (StartPoint.y > Premises.topLeft.x)
                {
                    StartPoint.y--;
                }
                else
                {
                    d = "right";
                }
            }
            else if (d == "right")
            {
                if (StartPoint.y >= Premises.topLeft.x)
                {
                    StartPoint.y++;
                }
                else
                {
                    d = "left";
                }
            }
        }
        public void MoveRightToLeft()
        {
            if (StartPoint.y > Premises.topLeft.x)
            {
                StartPoint.y--;
            }
        }
        public void MoveLeftToRight()
        {

            if (StartPoint.y <= Premises.topRight.x)
            {
                StartPoint.y++;
            }
        }
        public void Remove()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(StartPoint.y + j, StartPoint.x + i);
                    Console.Write(" ");
                }
            }
        }

        public void Draw()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    Console.SetCursorPosition(StartPoint.y + j, StartPoint.x + i);
                    Console.Write(Shape[i, j]);
                }
            }
        }
        public GameObject(char[,] Shape, Point StartPoint, Boundary Premises, string Direction)
        {
            this.Shape = Shape;
            this.StartPoint = StartPoint;
            this.Premises = Premises;
            this.Direction = Direction;
        }
        public GameObject()
        {
            Shape = new char[1, 3] { { '-', '-', '-' } };
            StartPoint = new Point();
            Premises = new Boundary();
            Direction = "LeftToRight";
        }
        public char[,] Shape;
        public Point StartPoint;
        public Boundary Premises;
        public string Direction;
        public string d = "left";
        public int d2 = 0;
    }
}
