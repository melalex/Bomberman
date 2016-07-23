using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;

namespace Bomberman.GameWorld.Environment
{
    class BreakableWall : AbstraktField
    {
        public BreakableWall()
        {
            FieldType = GameObjectType.BREAKABLE_WALL;
        }

        public override bool Update(GameTime gameTime)
        {
            Random randomState = new Random();
            AbstraktField nextState;
            int state = randomState.Next(100);

            if (state < 20)
            { 
                nextState = new Fire(new Powerup((Player player) => player.IncreaseBombCount(), GameObjectType.BOMB_POWERUP));
            }
            else if (state < 40)
            {
                nextState = new Fire(new Powerup((Player player) => player.IncreaseSpeed(), GameObjectType.SPEED_POWERUP));
            }
            else if (state < 60)
            {
                nextState = new Fire(new Powerup((Player player) => player.IncreaseLethalArea(), GameObjectType.FIRE_POWERUP));
            }
            else
            {
                nextState = new Fire(new EmptyField());
            }

            ReiseEvents(nextState);

            return false;
        }

        public override void Visit(LivingObject player)
        {
            throw new NotImplementedException();
        }
    }
}
