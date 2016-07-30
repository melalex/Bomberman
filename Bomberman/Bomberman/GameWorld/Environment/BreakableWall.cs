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
        public BreakableWall(FieldWidget field)
        {
            this.field = field;
            FieldType = GameObjectType.BREAKABLE_WALL;
        }

        public override void Destroy()
        {
            Random randomState = new Random();
            AbstraktField nextState;
            int state = randomState.Next(100);

            if (state < 20)
            {
                nextState = field.FireState.SetNextState(field.LethalAreaBoostState);
            }
            else if (state < 40)
            {
                nextState = field.FireState.SetNextState(field.BombCountBoostState);
            }
            else if (state < 60)
            {
                nextState = field.FireState.SetNextState(field.SpeedBoostState);
            }
            else
            {
                nextState = field.FireState.SetNextState(field.EmptyFieldState);
            }

            field.SetState(nextState);
        }

        public override void Visit(LivingObject player)
        {
            throw new NotImplementedException();
        }
    }
}
