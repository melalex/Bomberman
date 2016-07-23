using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;

namespace Bomberman.GameWorld.Environment
{
    class UnbreakableWall : AbstraktField
    {
        public UnbreakableWall()
        {
            FieldType = GameObjectType.UNBREAKABLE_WALL;
        }

        public override bool Update(GameTime gameTime)
        {
            return false;
        }

        public override void Visit(LivingObject visitor)
        {
            throw new NotImplementedException();
        }
    }
}
