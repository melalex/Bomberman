using Bomberman.GameWorld;
using Bomberman.GameWorld.Visualization;
using Bomberman.GameWorld.Visualization.Animated.Character;
using Bomberman.GameWorld.Visualization.Animated.Field;
using Bomberman.GameWorld.Visualization.Static;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.visualizationGameWorld
{
    class SpritePool
    {
        private static readonly SpritePool instance = new SpritePool();

        private Dictionary<GameObjectType, AbstractSprite> spritePool = new Dictionary<GameObjectType, AbstractSprite>();

        public static SpritePool Instance
        {
            get { return instance; }
        }

        //private StaticSprite _emptyField;
        //private StaticSprite _unbreakableWall;
        //private StaticSprite _breakableWall;

        //private StaticSprite _bombPowerUp;
        //private StaticSprite _firePowerUp;
        //private StaticSprite _speedPowerUp;

        //private AnimatedField _bomb;
        //private AnimatedField _fire;

        //private AnimatedCharacter _player;
        //private AnimatedCharacter _monster;

        public StaticSprite EmptyField
        {
            get { return spritePool[GameObjectType.EMPTY_FIELD] as StaticSprite; }
        }
        public StaticSprite UnbreakableWall
        {
            get { return spritePool[GameObjectType.UNBREAKABLE_WALL] as StaticSprite; }
        }
        public StaticSprite BreakableWall
        {
            get { return spritePool[GameObjectType.BREAKABLE_WALL] as StaticSprite; }
        }

        public StaticSprite BombPowerUp
        {
            get { return spritePool[GameObjectType.BOMB_POWERUP] as StaticSprite; }
        }
        public StaticSprite FirePowerUp
        {
            get { return spritePool[GameObjectType.FIRE_POWERUP] as StaticSprite; }
        }
        public StaticSprite SpeedPowerUp
        {
            get { return spritePool[GameObjectType.SPEED_POWERUP] as StaticSprite; }
        }

        public AnimatedField Bomb
        {
            get { return spritePool[GameObjectType.BOMB] as AnimatedField; }
        }
        public AnimatedField Fire
        {
            get { return spritePool[GameObjectType.FIRE] as AnimatedField; }
        }

        public AnimatedCharacter Player
        {
            get { return spritePool[GameObjectType.PLAYER1] as AnimatedCharacter; }
        }
        public AnimatedCharacter Monster
        {
            get { return spritePool[GameObjectType.MONSTER] as AnimatedCharacter; }
        }

        public void InitSpritePool(ContentManager content)
        {
            spritePool.Add(GameObjectType.EMPTY_FIELD, new StaticSprite(content.Load<Texture2D>("Sprites\\Blocks\\BackgroundTile")));
            spritePool.Add(GameObjectType.UNBREAKABLE_WALL, new StaticSprite(content.Load<Texture2D>("Sprites\\Blocks\\SolidBlock")));
            spritePool.Add(GameObjectType.BREAKABLE_WALL, new StaticSprite(content.Load<Texture2D>("Sprites\\Blocks\\ExplodableBlock")));

            spritePool.Add(GameObjectType.BOMB_POWERUP, new StaticSprite(content.Load<Texture2D>("Sprites\\Powerups\\BombPowerup")));
            spritePool.Add(GameObjectType.FIRE_POWERUP, new StaticSprite(content.Load<Texture2D>("Sprites\\Powerups\\FlamePowerup")));
            spritePool.Add(GameObjectType.SPEED_POWERUP, new StaticSprite(content.Load<Texture2D>("Sprites\\Powerups\\SpeedPowerup")));

            spritePool.Add(GameObjectType.BOMB, AnimatedFieldCreator.CreateBomb(content));
            spritePool.Add(GameObjectType.FIRE, AnimatedFieldCreator.CreateFire(content));

            spritePool.Add(GameObjectType.PLAYER1, AnimatedCharacterCreator.PlayerCreator(content));
            spritePool.Add(GameObjectType.MONSTER, AnimatedCharacterCreator.MonsterCreator(content));
        }
    }
}
