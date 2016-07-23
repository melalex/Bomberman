using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Bomberman.State.MVP.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bomberman.State.MVP.Presenter
{
    class GamePresenter : AbstractPresenter
    {
        private GameModel model;
        private KeyboardState previousState;

        public GamePresenter(SpriteBatch spriteBatch)
        {
            model = new GameModel();
            view = spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {
            if (keyboardState.IsKeyDown(Keys.W))
            {
                model.Bomberman.GoUp();
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                model.Bomberman.GoDown();
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                model.Bomberman.GoLeft();
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                model.Bomberman.GoRight();
            }

            if (previousState != keyboardState && keyboardState.IsKeyDown(Keys.Space))
            {
                model.BombermanPlantsBomb();
            }

            model.Update(gameTime);
        }
    }
}
