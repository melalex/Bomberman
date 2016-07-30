using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;

namespace Bomberman.GameWorld.Environment
{
    class Bomb : AbstraktField
    {
        private float totalTime = 0;
        private float detonationTime = Constants.Instance.DetonationTime;

        public Bomb(int lethalArea, FieldWidget field)
        {
            FieldType = GameObjectType.BOMB;
            this.field = field;
        }

        public override void Update(GameTime gameTime)
        {
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (totalTime > detonationTime)
            {
                totalTime = 0;
                field.BombExploded();
            }
        }
         
        public override void Destroy()
        {
            totalTime = detonationTime;
        }

        public override void Visit(LivingObject visitor)
        {
            
        }

    }
}
