using Bomberman.State.MVP.Model;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Bomberman.State.MVP.Presenter
{
    abstract class AbstractPresenter
    { 
        protected SpriteBatch view;

        public abstract void Draw(GameTime gameTime);
        public abstract void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState);
    }
}
