using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Bomberman.State.MVP.Model;
using Microsoft.Xna.Framework.Graphics;
using Bomberman.GameWorld.Visualization.Static;
using Microsoft.Xna.Framework.Content;

namespace Bomberman.State.MVP.Presenter
{
    class MenuPresenter : AbstractPresenter
    {
        private MenuModel model = new MenuModel();

        private KeyboardState previousState;

        private ModelCreator modelCreator = new ModelCreator();

        private Texture2D onePlayerHover;
        private Texture2D onePlayerNormal;
        private Texture2D twoPlayersHover;
        private Texture2D twoPlayersNormal;
        private Texture2D title;
         
        private Rectangle onePlayerPosicion = new Rectangle(294, 260, 132, 27);
        private Rectangle twoPlayersPosicion = new Rectangle(294, 300, 132, 27);
        private Rectangle titlePosicion = new Rectangle(77, -40, 576, 576);

        public MenuPresenter(SpriteBatch spriteBatch, GameWidget game)
        {
            view = spriteBatch;
            this.game = game;
        }

        public void InitTextures(ContentManager content)
        {
            onePlayerHover = content.Load<Texture2D>("Sprites\\Menu\\One_Player_Hover");
            onePlayerNormal = content.Load<Texture2D>("Sprites\\Menu\\One_Player_Normal");
            twoPlayersHover = content.Load<Texture2D>("Sprites\\Menu\\Two_Players_Hover");
            twoPlayersNormal = content.Load<Texture2D>("Sprites\\Menu\\Two_Players_Normal");
            title = content.Load<Texture2D>("Sprites\\Menu\\title_titletext");
        }

        public override void Draw(GameTime gameTime)
        {
            Texture2D onePlayerTexture = model.GetMenuEntry(0) == MenuEntryes.SELECTED ? onePlayerHover : onePlayerNormal;
            Texture2D twoPlayerTexture = model.GetMenuEntry(1) == MenuEntryes.SELECTED ? twoPlayersHover : twoPlayersNormal;

            view.Draw(onePlayerTexture, onePlayerPosicion, Color.White);
            view.Draw(twoPlayerTexture, twoPlayersPosicion, Color.White);
            view.Draw(title, titlePosicion, Color.White);
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {
            if (previousState != keyboardState && (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)))
            {
                model.GoUp();
            }
            else if (previousState != keyboardState && (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)))
            {
                model.GoDown();
            }
            else if (previousState != keyboardState && keyboardState.IsKeyDown(Keys.Enter))
            {
                switch (model.SelectedMenuEntry)
                {
                    case 0:
                        game.SetCurrentPresenter(game.GamePresenter.SetModel(modelCreator.CreateOnePlayerGameModel()));
                        break;

                    case 1:
                        game.SetCurrentPresenter(game.GamePresenter.SetModel(modelCreator.CreateTwoPlayersGameModel()));
                        break;
                }
            }
            else if (previousState != keyboardState && keyboardState.IsKeyDown(Keys.Escape))
            {
                game.ExitGame();
            }
             
            previousState = keyboardState;
        }
    }
}
