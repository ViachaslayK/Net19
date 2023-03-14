﻿using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Enemies
{
    public abstract class BaseEnemy : BaseCharacter
    {
        public BaseEnemy(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public abstract void EndTurnActivity();
    }
}
