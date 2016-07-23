using Bomberman.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Bomberman.GameWorld.LivingObjects;
using Bomberman.GameWorld.Environment;

namespace Bomberman.State.MVP.Model
{
    class GameModel : AbstractModel
    {
        private Map location;

        public Player Bomberman { get; private set; }
        public Player DarkBomberman { get; private set; }

        GameModel(Map location, Player bomberman, Player darkBomberman = null)
        {
            this.location = location;

            Bomberman = bomberman;
            DarkBomberman = darkBomberman;
        }

        private Monster[] monsters;

        private FieldWidget[] toUpdate;
        
        public void BombermanPlantsBomb()
        {

        }

        public void DarkBombermanPlantsBomb()
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (Monster monster in monsters)
            {
                monsters.Update();
            }
        }
    }
}
