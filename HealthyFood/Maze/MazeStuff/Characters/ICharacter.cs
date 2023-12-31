﻿using Maze.MazeStuff.Cells;

namespace Maze.MazeStuff.Characters
{
    public interface ICharacter : IBaseCell
    {
        string Name { get; set; }
        int Hp { get; set; }
        int Coins { get; set; }
        int Experience { get; set; }
    }
}
