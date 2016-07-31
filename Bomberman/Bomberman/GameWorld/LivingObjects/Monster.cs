using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.Environment;

namespace Bomberman.GameWorld.LivingObjects
{
    class Monster : LivingObject
    {

        public Monster(int x, int y, Map location)
        {
            Position = new Rectangle(x, y, Constants.Instance.SideOfASprite, Constants.Instance.SideOfASprite);
            Type = GameObjectType.MONSTER;
            this.Location = location;

            Velocity = Constants.Instance.DefaultVelocity;
        }

        public override void EatPowerup(Enhance enhanceMethod)
        { 

        }

        public override void Kill()
        {
            Alive = false;
            PositionDidChange(this);
            CharacterDidDie(this);
        }

        public void Update(GameTime gameTime)
        {
            switch (MyDirection)
            {
                case Direction.STAND:
                case Direction.UP:
                    if (!GoUp(gameTime))
                    {
                        MyDirection = Direction.LEFT;
                    }
                    break;

                case Direction.LEFT:
                    if (!GoLeft(gameTime))
                    {
                        MyDirection = Direction.DOWN;
                    }
                    break;

                case Direction.DOWN:
                    if (!GoDown(gameTime))
                    {
                        MyDirection = Direction.RIGHT;
                    }
                    break;

                case Direction.RIGHT:
                    if (!GoRight(gameTime))
                    {
                        MyDirection = Direction.UP;
                    }
                    break;
            }
        }
    }
}
