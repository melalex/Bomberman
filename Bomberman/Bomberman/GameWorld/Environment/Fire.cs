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

        public Fire(FieldWidget field)
        {
            this.field = field;
            this.nextState = field.EmptyFieldState;
            FieldType = GameObjectType.FIRE;
        }

        public Fire SetNextState(AbstraktField nextState)
        {
            this.nextState = nextState;
            return this;
        }

        public override void Update(GameTime gameTime)
        {
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (totalTime > burningTime)
            {
                totalTime = 0;
                field.SetState(nextState);
            }
        }

        public override void Destroy()
        {
            totalTime = 0;
        }

        public override void Visit(LivingObject visitor)
        {
            visitor.Kill();
        }
    }
}
