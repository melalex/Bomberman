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
        public UnbreakableWall(FieldWidget field)
        {
            this.field = field;
            FieldType = GameObjectType.UNBREAKABLE_WALL;
        }

        public override void Destroy()
        { 

        }

        public override void Visit(LivingObject visitor)
        {
            throw new NotImplementedException();
        }
    }
}
