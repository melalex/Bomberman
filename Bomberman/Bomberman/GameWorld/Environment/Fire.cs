using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;

namespace Bomberman.GameWorld.Environment
{
    class Fire : AbstraktField
    {
        private AbstraktField nextState;

        private float totalTime;
        private float burningTime = Constants.Instance.BurningTime;

        public Fire(AbstraktField nextState)
        {
            this.nextState = nextState;
            FieldType = GameObjectType.FIRE;
        }

        public override bool Update(GameTime gameTime)
        {
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (totalTime > burningTime)
            {
                ReiseEvents(nextState);
            }

            return true;
        }

        public override void Visit(LivingObject visitor)
        {
            visitor.Kill();
        }
    }
}
