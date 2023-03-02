﻿using Maze.MazeStuff;

namespace Maze
{
    public class MazeBuilder
    {
        private MazeLevel _maze;

        public MazeLevel Build(int width = 10, int height = 5)
        {
            _maze = new MazeLevel()
            {
                Widht = width,
                Height = height,
            };

            BuildWall();
            BuildGround();

            return _maze;
        }

        private void BuildGround()
        {
            //Write code here
        }

        private void BuildWall()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Widht; x++)
                {
                    var cell = new MazeCell()
                    {
                        X = x,
                        Y = y,
                        CellType = CellType.Wall,
                    };

                    _maze.Cells.Add(cell);
                }
            }
        }
    }
}
