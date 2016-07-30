using Bomberman.GameWorld.EnvironmentView.Visitor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.EnvironmentView.Views
{
    abstract class AbstractView
    {
        public Rectangle Position { get; set; }
        public Color FrameColor { get; protected set; }

        abstract public void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime);
    }
}
