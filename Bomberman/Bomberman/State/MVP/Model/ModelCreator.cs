using Bomberman.GameWorld;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.State.MVP.Model
{
    class ModelCreator
    {
        private MapsContainer _mapsContainer = null;
        private MapsContainer mapsContainer
        {
            get
            {
                if (_mapsContainer == null)
                {
                    _mapsContainer = new MapsContainer();
                }
                return _mapsContainer;
            }
        }

        public GameModel CreateTwoPlayersGameModel()
        {
            GameMapInformation twoPlayersMap = mapsContainer.NextTwoPlayersMap;
            Map location = new Map(twoPlayersMap.Map);

            GameModel model = new GameModel(location);

            model.Bomberman = new Player(twoPlayersMap.FirstPlayerPosition, location, GameObjectType.PLAYER1);
            model.DarkBomberman = new Player(twoPlayersMap.SecondPlayerPosition, location, GameObjectType.PLAYER2);

            List<Monster> creeps = new List<Monster>();
            Rectangle[] monstersPosition = twoPlayersMap.MonstersPositions;
            if (monstersPosition != null)
            {
                foreach (Rectangle position in monstersPosition)
                {
                    creeps.Add(new Monster(position, location));
                }
            }
            model.Creeps = creeps;

            return model;
        }

        public GameModel CreateOnePlayerGameModel()
        {
            GameMapInformation onePlayerMap = mapsContainer.NextOnePlayerMap;
            Map location = new Map(onePlayerMap.Map);

            GameModel model = new GameModel(location);

            model.Bomberman = new Player(onePlayerMap.FirstPlayerPosition, location, GameObjectType.PLAYER1);

            List<Monster> creeps = new List<Monster>();
            Rectangle[] monstersPosition = onePlayerMap.MonstersPositions;
            if (monstersPosition != null)
            {
                foreach (Rectangle position in monstersPosition)
                {
                    creeps.Add(new Monster(position, location));
                }
            }
            model.Creeps = creeps;

            return model;
        }
    }
}
