using Bomberman.GameWorld.EnvironmentView.Views;
using Bomberman.GameWorld.EnvironmentView.Visitor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.EnvironmentView.Wrapers
{
    interface IViewWraper
    {
        void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime);
    }
}
