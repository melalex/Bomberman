using Bomberman.GameWorld;
using Bomberman.GameWorld.LivingObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.State.MVP.Model
{
    class ModelCreator
    {
        public GameModel CreateTwoPlayersGameModel()
        {
            Map location = new Map(Constants.Instance.SimpleMap);

            GameModel model = new GameModel(location);

            model.Bomberman = new Player(3 * Constants.Instance.SideOfASprite, 3 * Constants.Instance.SideOfASprite, location, GameObjectType.PLAYER1);
            model.DarkBomberman = new Player(6 * Constants.Instance.SideOfASprite, 3 * Constants.Instance.SideOfASprite, location, GameObjectType.PLAYER2);

            model.Creeps = new List<Monster>();

            return model;
        }

        public GameModel CreateOnePlayerGameModel()
        {
            Map location = new Map(Constants.Instance.SimpleMap);

            GameModel model = new GameModel(location);

            model.Bomberman = new Player(3 * Constants.Instance.SideOfASprite, 3 * Constants.Instance.SideOfASprite, location, GameObjectType.PLAYER1);

            List<Monster> creepsList = new List<Monster>();
            creepsList.Add(new Monster(16 * Constants.Instance.SideOfASprite, 3 * Constants.Instance.SideOfASprite, location));
            model.Creeps = creepsList;

            return model;
        }
    }
}
