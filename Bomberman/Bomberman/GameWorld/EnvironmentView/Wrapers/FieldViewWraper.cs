using Bomberman.GameWorld.Environment;
using Bomberman.GameWorld.EnvironmentView.Views;
using Bomberman.GameWorld.Factories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.EnvironmentView.Visitor;
using Microsoft.Xna.Framework.Graphics;

namespace Bomberman.GameWorld.EnvironmentView.Wrapers
{
    class FieldViewWraper : IViewWraper
    {
        private AbstractView view;
        private FactoriesCreator factoriesCreator;

        public FieldViewWraper(AbstractView view, FactoriesCreator factoriesCreator)
        {
            this.view = view;
            this.factoriesCreator = factoriesCreator;
        }

        public void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime)
        {
            view.Accept(drawer, spriteBatch, gameTime);
        }

        public void ViewChangeType(FieldWidget field)
        {
            ViewAbstractFactory factory = factoriesCreator.CreateFactory(field.FieldType);
            view = factory.CreateView(view.Position, view.FrameColor);
        }
    }
}
