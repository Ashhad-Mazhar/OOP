using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Problem_1.BL
{
    class Grid
    {
        public static Cell[,] maze;
        public static int rowSize;
        public static int colSize;
        public Grid(int RowSize, int ColSize, string path)
        {
            rowSize = RowSize;
            colSize = ColSize;
            StreamReader file = new StreamReader(path);
            string record;
            while (file.EndOfStream)
            {
                for (int i = 0; i < 24; i++)
                {
                    record = file.ReadLine();
                    int x;
                    int y;
                    char value;
                    for (int j = 0; j < 71; j++)
                    {
                        value = record[j];
                        x = j;
                        y = i;
                        Cell c = new Cell(value, x, y);
                        maze[j, i] = c;
                    }
                }
            }
            file.Close();
        }
        public static Cell getLeftCell(Cell c)
        {
            int resultX = c.X - 1;
            int resultY = c.Y;
            char resultValue = maze[resultY, resultX].value;
            Cell Result = new Cell(resultValue, resultX, resultY);
            return Result;
        }
        public static Cell getRightCell(Cell c)
        {
            int resultX = c.X + 1;
            int resultY = c.Y;
            char resultValue = maze[resultY, resultX].value;
            Cell Result = new Cell(resultValue, resultX, resultY);
            return Result;
        }
        public static Cell getUpCell(Cell c)
        {
            int resultX = c.X;
            int resultY = c.Y - 1;
            char resultValue = maze[resultY, resultX].value;
            Cell Result = new Cell(resultValue, resultX, resultY);
            return Result;
        }
        public static Cell getDownCell(Cell c)
        {
            int resultX = c.X;
            int resultY = c.Y + 1;
            char resultValue = maze[resultY, resultX].value;
            Cell Result = new Cell(resultValue, resultX, resultY);
            return Result;
        }
        public static Cell findPacman()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 71; j++)
                {
                    if (maze[j, i].value == 'P')
                    {
                        return maze[j, i];
                    }
                }
            }
            return null;
        }
        public static Cell findGhost(char ghostCharacter)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 71; j++)
                {
                    if (maze[j, i].value == ghostCharacter)
                    {
                        return maze[j, i];
                    }
                }
            }
            return null;
        }
        public bool isStoppingCondition()
        {

        }
        public static void draw()
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 71; j++)
                {
                    Console.Write(maze[j, i].value);
                }
                Console.WriteLine();
            }
        }
    }
}