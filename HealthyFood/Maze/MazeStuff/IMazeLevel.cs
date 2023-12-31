﻿using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff.Enemies;

namespace Maze.MazeStuff
{
    public interface IMazeLevel
    {
        List<BaseCell> Cells { get; set; }
        List<BaseEnemy> Enemies { get; set; }
        ICharacter GreedyHealer { get; set; }
        int Height { get; set; }
        ICharacter Hero { get; set; }
        int Widht { get; set; }

        void ReplaceCell(BaseCell newCell);
        void ReplaceToGround(BaseCell currentCell);
    }
}