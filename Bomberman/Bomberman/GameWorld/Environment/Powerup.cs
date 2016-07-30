using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Bomberman.GameWorld.LivingObjects;

namespace Bomberman.GameWorld.Environment
{
    delegate void Enhance(Player player);

    class Powerup : AbstraktField
    {
        private Enhance enhanceMethod;

        public Powerup(Enhance enhanceMethod, GameObjectType fieldType, FieldWidget field)
        {
            this.enhanceMethod = enhanceMethod;
            this.field = field;
            this.FieldType = fieldType;
        }

        public override void Destroy()
        {
            field.SetState(field.FireState.SetNextState(field.EmptyFieldState));
        }

        public override void Visit(LivingObject visitor)
        {
            visitor.EatPowerup(enhanceMethod);
            field.SetState(field.EmptyFieldState);
        }
    }
}
