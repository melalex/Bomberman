using Bomberman.State.MVP.Presenter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.State
{
    delegate void Exit();

    class GameWidget
    {
        private KeyboardState previousState;

        private AbstractPresenter currentPresenter;
        private SpriteBatch spriteBatch;

        public Exit ExitGame;

        private MenuPresenter _menuPresenter;
        private GamePresenter _gamePresenter;
        private EditorPresenter _editorPresenter;

        public MenuPresenter MenuPresenter
        {
            get
            {
                if (_menuPresenter == null)
                {
                    _menuPresenter = new MenuPresenter(spriteBatch, this);
                }
                return _menuPresenter;
            }
        }
        public GamePresenter GamePresenter
        {
            get
            {
                if (_gamePresenter == null)
                {
                    _gamePresenter = new GamePresenter(spriteBatch, this);
                }
                return _gamePresenter;
            }
        }
        public EditorPresenter EditorPresenter
        {
            get
            {
                if (_editorPresenter == null)
                {
                    _editorPresenter = new EditorPresenter();
                }
                return _editorPresenter;
            }
        }

        public GameWidget(SpriteBatch spriteBatch, Exit exitGame)
        { 
            this.spriteBatch = spriteBatch;
            ExitGame = exitGame;
        }

        public void SetCurrentPresenter(AbstractPresenter newState)
        {
            currentPresenter = newState;
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {
            if (!(previousState == keyboardState && keyboardState.IsKeyDown(Keys.Escape)))
            { 
                currentPresenter.Update(gameTime, keyboardState, mouseState);
            }

            previousState = keyboardState;
        }

        public void Draw(GameTime gameTime)
        {
            currentPresenter.Draw(gameTime);
        }
    }
}
