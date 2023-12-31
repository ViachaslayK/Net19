﻿using Maze.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeStuff.Cells
{
    public class PileOfCoins : BaseCell
    {
        private Random random = new Random();

        public PileOfCoins(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.PileOfCoins;

        public override bool TryToStep(ICharacter character)
        {
            var randomAmountOfCoins = random.Next(2, 10);
            character.Coins += randomAmountOfCoins;
            this.Level.ReplaceToGround(this);
            return true;
        }
    }
}
