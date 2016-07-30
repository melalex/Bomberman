using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.EnvironmentView.Visitor;
using Bomberman.GameWorld.Visualization.Static;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bomberman.GameWorld.EnvironmentView.Views
{
    class StaticFieldView : AbstractView
    {
        public StaticSprite Sprite { get; }

        public StaticFieldView(Rectangle position, StaticSprite sprite, Color color)
        {
            Position = position;
            Sprite = sprite;
            FrameColor = color;
        }

        public override void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime)
        {
            drawer.visit(this, spriteBatch, gameTime);
        }
    }
}
