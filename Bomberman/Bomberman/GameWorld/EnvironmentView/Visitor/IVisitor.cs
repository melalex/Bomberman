using Bomberman.GameWorld.EnvironmentView.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.EnvironmentView.Visitor
{
    interface IVisitor
    {
        void visit(DinamicFieldView element, SpriteBatch spriteBatch, GameTime gameTime);
        void visit(StaticFieldView element, SpriteBatch spriteBatch, GameTime gameTime);
        void visit(MoveableView element, SpriteBatch spriteBatch, GameTime gameTime);
    }
}
