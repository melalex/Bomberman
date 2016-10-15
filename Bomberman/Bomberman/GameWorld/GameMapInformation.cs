using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld
{
    class GameMapInformation
    {
        public Rectangle FirstPlayerPosition { get; private set; }
        public Rectangle SecondPlayerPosition { get; private set; }
        public Rectangle[] MonstersPositions { get; private set; }
        public int[,] Map { get; private set; }

        public GameMapInformation(int[,] map, Rectangle firstPlayerPosition, Rectangle secondPlayerPosition, Rectangle[] monstersPositions = null) : 
            this(map, firstPlayerPosition, monstersPositions)
        {
            SecondPlayerPosition = secondPlayerPosition;
        }

        public GameMapInformation(int[,] map, Rectangle firstPlayerPosition, Rectangle[] monstersPositions = null)
        {
            Map = map;
            FirstPlayerPosition = firstPlayerPosition;
            MonstersPositions = monstersPositions;
        }
    }
}
