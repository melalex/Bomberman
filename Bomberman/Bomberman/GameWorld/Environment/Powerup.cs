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

        public Powerup(Enhance enhanceMethod, GameObjectType fieldType)
        {
            this.enhanceMethod = enhanceMethod;
            this.FieldType = fieldType;
        }

        public override bool Update(GameTime gameTime)
        {
            ReiseEvents(new Fire(new EmptyField()));

            return false;
        }

        public override void Visit(LivingObject visitor)
        {
            visitor.EatPowerup(enhanceMethod);
            ReiseEvents(new EmptyField());
        }
    }
}
