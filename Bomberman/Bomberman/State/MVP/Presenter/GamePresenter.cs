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

        private Drawer drawer = new Drawer();
        private LinkedList<IViewWraper> toDraw;

        public GamePresenter(SpriteBatch spriteBatch)
        {
            ModelCreator modelCreator = new ModelCreator();

            view = spriteBatch;
            model = modelCreator.CreateGameModel();
            
            ViewWraperFactory factory = new ViewWraperFactory(new GameWorld.Factories.FactoriesCreator());
            toDraw = new LinkedList<IViewWraper>();

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
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (IViewWraper viewWraper in toDraw)
            {
                viewWraper.Accept(drawer, view, gameTime);
            }
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState, MouseState mouseState)
        {
            PlayerKeys playerKeys = Constants.Instance.Player1;

            if (keyboardState.IsKeyDown(playerKeys.GoUpKey))
            {
                model.BombermanGoUp(model.Bomberman, gameTime);
            }
            else if (keyboardState.IsKeyDown(playerKeys.GoDownKey))
            {
                model.BombermanGoDown(model.Bomberman, gameTime);
            }
            else if (keyboardState.IsKeyDown(playerKeys.GoLeftKey))
            {
                model.BombermanGoLeft(model.Bomberman, gameTime);
            }
            else if (keyboardState.IsKeyDown(playerKeys.GoRightKey))
            {
                model.BombermanGoRight(model.Bomberman, gameTime);
            }

            if (previousState != keyboardState && keyboardState.IsKeyDown(playerKeys.PlantBombKey))
            {
                model.BombermanPlantsBomb(model.Bomberman);
            }

            model.Update(gameTime);

            previousState = keyboardState;
        }
    }
}
