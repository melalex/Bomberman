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
        public override void EatPowerup(Enhance enhanceMethod)
        {
            throw new NotImplementedException();
        }

        public override void Kill()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
