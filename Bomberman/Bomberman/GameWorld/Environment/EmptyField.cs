using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;

namespace Bomberman.GameWorld.Environment
{
    class EmptyField : AbstraktField
    {
        public EmptyField()
        {
            FieldType = GameObjectType.EMPTY_FIELD;
        }

        public override bool Update(GameTime gameTime)
        {
            ReiseEvents(new Fire(this));

            return true;
        }

        public override void Visit(LivingObject visitor)
        {
            throw new NotImplementedException();
        }
    }
}
