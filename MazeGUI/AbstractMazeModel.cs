﻿using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    public class AbstractMazeModel
    {
        private Maze maze;
        private string mazeString;

        public AbstractMazeModel(Maze m)
        {
            maze = m;
            mazeString = String.Join("", maze.ToString().Split('\r', '\n'));
        }

        public string MazeName
        {
            get { return maze.Name; }
        }

        public int Cols
        {
            get { return maze.Cols; }
        }

        public int Rows
        {
            get { return maze.Rows; }
        }

        public string MazeString
        {
            get { return mazeString; }
        }

        public Position MazeStartPoint
        {
            get { return maze.InitialPos; }
        }

        public Position MazeEndPoint
        {
            get { return maze.GoalPos; }
        }

        public bool IsMoveOk(Position mazeStartPoint, Direction direct)
        {
            int row = mazeStartPoint.Row;
            int col = mazeStartPoint.Col;
            switch (direct)
            {
                case Direction.Right:
                    {
                        return ((col + 1) < maze.Cols)
                            && (maze[row, (col + 1)] == CellType.Free);
                    }
                case Direction.Up:
                    {
                        return ((row - 1) >= 0)
                            && (maze[row - 1, col] == CellType.Free);
                    }
                case Direction.Down:
                    {
                        return ((row + 1) < maze.Rows)
                            && (maze[row + 1, col] == CellType.Free);
                    }
                case Direction.Left:
                    {
                        return ((col - 1) >= 0)
                            && (maze[row, (col - 1)] == CellType.Free);
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
