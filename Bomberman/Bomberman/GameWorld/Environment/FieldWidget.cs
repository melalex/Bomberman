using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Environment
{
    delegate void FieldStateChange(int x, int y, AbstraktField newState);

    class FieldWidget
    {
        private AbstraktField currentState;

        private int posX;
        private int posY;
         
        public event FieldStateChange FieldStateChangeHendler;

        public GameObjectType FieldType
        {
            get { return currentState.FieldType; }
        }

        public FieldWidget(int posX, int posY, AbstraktField state)
        {
            this.posX = posX;
            this.posY = posY;

            currentState = state;
        }

        private void SetState(AbstraktField newState)
        {
            currentState = newState;
            FieldStateChangeHendler(posX, posY, newState);
        }

        public bool Update(GameTime gameTime)
        {
            return currentState.Update(gameTime);
        }

        public void Visit(LivingObject visitor)
        {
            currentState.Visit(visitor);
        }
    }
}
