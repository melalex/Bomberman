using Bomberman.GameWorld.EnvironmentView.Views;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.EnvironmentView.Visitor;
using Microsoft.Xna.Framework.Graphics;

namespace Bomberman.GameWorld.EnvironmentView.Wrapers
{
    class MoveableViewWraper : IViewWraper
    {
        private bool alive = true;

        private MoveableView view;

        public MoveableViewWraper(AbstractView view)
        {
            this.view = view as MoveableView;
        }

        public void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (alive)
            {
                view.Accept(drawer, spriteBatch, gameTime);
            }
        }

        public void ViewChangePosition(LivingObject sender)
        {
            if (sender.Alive)
            {
                Rectangle newPosition = sender.Position;
                newPosition.Offset(Constants.Instance.XGameMapPosition, Constants.Instance.YGameMapPosition);
                view.Position = newPosition;

                view.MyDirection = sender.MyDirection;
                view.TimeForFrame = sender.Velocity;
            }
            else
            {
                sender.PositionChangeHendler -= ViewChangePosition;
                alive = false;
            }
        }
    }
}
