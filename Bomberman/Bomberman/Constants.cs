using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman
{
    class Constants
    {
        private static readonly Constants instance = new Constants();

        public static Constants Instance
        {
            get { return instance; }
        }

        protected Constants() { }


        public int DefaultVelocity { get; } = 10;
        public int DefaultBombCount { get; } = 1;
        public int DefaultLethalArea { get; } = 2;


        public float Scale { get; } = 0.5f;
        public int SideOfASprite { get; } = 32;

        public int GameMapHeight { get; } = 15;
        public int GameMapWidth { get; } = 20;

        public int PreferredBackBufferWidth { get; } = 740;
        public int PreferredBackBufferHeight { get; } = 520;

        public int XGameMapPosition { get; } = 50;
        public int YGameMapPosition { get; } = 20;

        public float BurningTime { get; } = 1f;
        public float DetonationTime { get; } = 3f;

        public int BurningAnimationSpeed { get; } = 15;
        public int DedetonationAnimationSpeed { get; } = 10;

        public PlayerKeys Player1 { get; } = new PlayerKeys(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space);
        public PlayerKeys Player2 { get; } = new PlayerKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.RightControl);
    }

    class PlayerKeys
    {
        public Keys GoUpKey { get; private set; }
        public Keys GoDownKey { get; private set; }
        public Keys GoLeftKey { get; private set; }
        public Keys GoRightKey { get; private set; }
        public Keys PlantBombKey { get; private set; }

        public PlayerKeys(Keys goUpKey, Keys goDownKey, Keys goLeftKey, Keys goRightKey, Keys plantBombKey)
        {
            GoUpKey = goUpKey;
            GoDownKey = goDownKey;
            GoLeftKey = goLeftKey;
            GoRightKey = goRightKey;
            PlantBombKey = plantBombKey;
        }
    }

    enum GameObjectType : int
    {
        BOMB,
        FIRE,
        UNBREAKABLE_WALL,
        BREAKABLE_WALL,
        EMPTY_FIELD,
        BOMB_POWERUP,
        FIRE_POWERUP,
        SPEED_POWERUP,
        PLAYER1,
        PLAYER2,
        MONSTER
    }

    enum Direction : int
    {
        STAND,
        UP,
        DOWN,
        RIGHT,
        LEFT
    }
}
