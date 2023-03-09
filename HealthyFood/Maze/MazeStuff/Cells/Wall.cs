﻿using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class Wall : MazeCell
    {
        public override CellType CellType => CellType.Wall;
        public ConsoleColor ConsoleColor { get; set; } = ConsoleColor.Gray;

        public override bool TryToStep(ICharacter character)
        {
            character.Hp--;
            return false;
        }
    }
}