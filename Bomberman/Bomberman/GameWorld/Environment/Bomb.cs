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
        public int LethalArea { get; private set; }

        private float totalTime;
        private float dedetonationTime = Constants.Instance.DedetonationTime;

        public Bomb(int lethalArea)
        {
            FieldType = GameObjectType.BOMB;
            LethalArea = lethalArea;
        }

        public override bool Update(GameTime gameTime)
        {
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (totalTime > dedetonationTime)
            {
                ReiseEvents(new EmptyField());
            }

            return false;
        }

        public override void Visit(LivingObject visitor)
        {
            throw new NotImplementedException();
        }
    }
}
