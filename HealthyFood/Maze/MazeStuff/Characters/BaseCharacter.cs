﻿using Maze.MazeStuff.Cells;

namespace Maze.MazeStuff.Characters
{
    public abstract class BaseCharacter : BaseCell, ICharacter
    {
        public BaseCharacter(int x, int y, MazeLevel level) : base(x, y, level)
        {
        }

        public string Name { get; set; }
        public int Hp { get; set; }
        public int Coins { get; set; }
        public int Experience { get; set; } = 0;
    }
}
