using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Bomberman.State.MVP.Model;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Bomberman.GameWorld.LivingObjects;
using Bomberman.GameWorld;
using Bomberman.GameWorld.EnvironmentView.Wrapers;
using Bomberman.GameWorld.Environment;
using Bomberman.GameWorld.EnvironmentView.Visitor;

namespace Bomberman.State.MVP.Presenter
{
    class GamePresenter : AbstractPresenter
    {
        private GameModel model;
        private KeyboardState previousState;
        private bool isOver = false;
        private string result;

        private Drawer drawer = new Drawer();
        private LinkedList<IViewWraper> toDraw;

        private ModelCreator modelCreator = new ModelCreator();

        public GamePresenter(SpriteBatch spriteBatch, GameWidget game)
        {
            view = spriteBatch;

            this.game = game;

            toDraw = new LinkedList<IViewWraper>();
        }

        public GamePresenter SetModel(GameModel gameModel)
        {
            model = gameModel;
            isOver = false;
            ViewWraperFactory factory = new ViewWraperFactory(new GameWorld.Factories.FactoriesCreator());

            foreach (FieldWidget field in model.Location)
            {
                toDraw.AddLast(factory.CreateWraper(field));
            }

            foreach (Monster creep in model.Creeps)
            {
                toDraw.AddLast(factory.CreateWraper(creep));
            }

            toDraw.AddLast(factory.CreateWraper(model.Bomberman));

            if (model.DarkBomberman != null)
            {
                toDraw.AddLast(factory.CreateWraper(model.DarkBomberman));
            }

            model.GameOverHandler += gameOver;

            return this;
        }

        private void gameOver()
        {
            isOver = true;

            if (model.Bomberman.Alive)
            {
                result = "Player 1 Won!!!";
            }
            else if (model.DarkBomberman != null && model.DarkBomberman.Alive)
            {
                result = "Player 2 Won!!!";
            }
            else
            {
                result = "Monsters Won!!!";
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (IViewWraper viewWraper in toDraw)
            {
                viewWraper.Accept(drawer, view, gameTime);
            }

            if (isOver)
            {
                view.DrawString(Fonts.Instance.ResultFont, result, new Vector2(10, 10), Color.Red);
            }

        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {
            if (!isOver)
            {
                PlayerKeys player1Keys = Constants.Instance.Player1;
                PlayerKeys player2Keys = Constants.Instance.Player2;

                if (keyboardState.IsKeyDown(player1Keys.GoUpKey))
                {
                    model.BombermanGoUp(model.Bomberman, gameTime);
                }
                else if (keyboardState.IsKeyDown(player1Keys.GoDownKey))
                {
                    model.BombermanGoDown(model.Bomberman, gameTime);
                }
                else if (keyboardState.IsKeyDown(player1Keys.GoLeftKey))
                {
                    model.BombermanGoLeft(model.Bomberman, gameTime);
                }
                else if (keyboardState.IsKeyDown(player1Keys.GoRightKey))
                {
                    model.BombermanGoRight(model.Bomberman, gameTime);
                }

                if (previousState != keyboardState && keyboardState.IsKeyDown(player1Keys.PlantBombKey))
                {
                    model.BombermanPlantsBomb(model.Bomberman);
                }

                if (model.DarkBomberman != null)
                {
                    if (keyboardState.IsKeyDown(player2Keys.GoUpKey))
                    {
                        model.BombermanGoUp(model.DarkBomberman, gameTime);
                    }
                    else if (keyboardState.IsKeyDown(player2Keys.GoDownKey))
                    {
                        model.BombermanGoDown(model.DarkBomberman, gameTime);
                    }
                    else if (keyboardState.IsKeyDown(player2Keys.GoLeftKey))
                    {
                        model.BombermanGoLeft(model.DarkBomberman, gameTime);
                    }
                    else if (keyboardState.IsKeyDown(player2Keys.GoRightKey))
                    {
                        model.BombermanGoRight(model.DarkBomberman, gameTime);
                    }

                    if (previousState != keyboardState && keyboardState.IsKeyDown(player2Keys.PlantBombKey))
                    {
                        model.BombermanPlantsBomb(model.DarkBomberman);
                    }
                }
                 
                model.Update(gameTime);
            }
            else
            {
                if (previousState != keyboardState && keyboardState.IsKeyDown(Keys.Enter))
                {
                    if (model.DarkBomberman == null)
                    {
                        SetModel(modelCreator.CreateOnePlayerGameModel());
                    }
                    else
                    {
                        SetModel(modelCreator.CreateTwoPlayersGameModel());
                    }
                }
            }

            if (previousState != keyboardState && keyboardState.IsKeyDown(Keys.Escape))
            {
                game.SetCurrentPresenter(game.MenuPresenter);
            }

            previousState = keyboardState;
        }
    }
}
