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
        private MoveableView view;

        public MoveableViewWraper(AbstractView view)
        {
            this.view = view as MoveableView;
        }

        public void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime)
        {
            view.Accept(drawer, spriteBatch, gameTime);
        }

        public void ViewChangePosition(LivingObject sender)
        {
            Rectangle newPosition = sender.Position;
            newPosition.Offset(Constants.Instance.XGameMapPosition, Constants.Instance.YGameMapPosition);
            view.Position = newPosition;

            view.MyDirection = sender.MyDirection;
            view.TimeForFrame = sender.Velocity;
        }
    }
}
