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
        public EmptyField(FieldWidget field)
        {
            this.field = field;
            FieldType = GameObjectType.EMPTY_FIELD;
        }

        public override void Destroy()
        {
            field.SetState(field.FireState.SetNextState(field.EmptyFieldState));
        }

        public override void Visit(LivingObject visitor)
        {
             
        }
    }
}
