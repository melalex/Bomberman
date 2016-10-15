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
        public event Action GameOverHandler;

        private HashSet<FieldWidget> toUpdate = new HashSet<FieldWidget>();

        public Map Location { get; }

        private Player _bomberman = null;
        private Player _darkBomberman = null;
        private List<Monster> _creeps= null;

        public Player Bomberman
        {
            get
            {
                return _bomberman;
            }
            set
            {
                _bomberman = value;
                _bomberman.CharacterDidDieHendler += characterDidDieHendler;
            }
        }
        public Player DarkBomberman
        {
            get
            {
                return _darkBomberman;
            }
            set
            {
                _darkBomberman = value;
                _darkBomberman.CharacterDidDieHendler += characterDidDieHendler;
            }
        }
        public List<Monster> Creeps
        {
            get
            {
                return _creeps;
            }
            set
            {
                _creeps = value;
                foreach (Monster creep in _creeps)
                {
                    creep.CharacterDidDieHendler += characterDidDieHendler;
                }
            }
        }
        public GameModel(Map location)
        {
            this.Location = location;
        }

        #region bombermanControls

        public void BombermanGoUp(Player player, GameTime gameTime)
        {
            player.GoUp(gameTime);
        }

        public void BombermanGoDown(Player player, GameTime gameTime)
        {
            player.GoDown(gameTime);
        }

        public void BombermanGoLeft(Player player, GameTime gameTime)
        {
            player.GoLeft(gameTime);
        }

        public void BombermanGoRight(Player player, GameTime gameTime)
        {
            player.GoRight(gameTime);
        }

        public void BombermanPlantsBomb(Player player)
        {
            FieldWidget bombedField = player.CreateBomb();
            if (bombedField != null)
            {
                FieldWidget fieldBuffer = null;

                int lethalArea = player.LethalArea;

                int bombermanPosX = player.XPositionOnMap;
                int bombermanPosY = player.YPositionOnMap;

                bombedField.FieldStateChangeHendler += BombDidExplose;
                toUpdate.Add(bombedField);

                for (int i = 1; i < lethalArea && (bombermanPosY - i) >= 0; i++)
                {
                    fieldBuffer = Location[bombermanPosY - i, bombermanPosX];

                    if (fieldBuffer.FieldType == GameObjectType.UNBREAKABLE_WALL)
                    {
                        break;
                    }

                    bombedField.ExplosionHendler += fieldBuffer.Destroy;
                    fieldBuffer.FieldStateChangeHendler += StateDidChange;
                    fieldBuffer.NotificationCount++;

                    if (fieldBuffer.FieldType == GameObjectType.BREAKABLE_WALL)
                    {
                        break;
                    }
                }

                for (int i = 1; i < lethalArea && (bombermanPosY + i) < Constants.Instance.GameMapHeight; i++)
                {
                    fieldBuffer = Location[bombermanPosY + i, bombermanPosX];

                    if (fieldBuffer.FieldType == GameObjectType.UNBREAKABLE_WALL)
                    {
                        break;
                    }

                    bombedField.ExplosionHendler += fieldBuffer.Destroy;
                    fieldBuffer.FieldStateChangeHendler += StateDidChange;
                    fieldBuffer.NotificationCount++;

                    if (fieldBuffer.FieldType == GameObjectType.BREAKABLE_WALL)
                    {
                        break;
                    }
                }

                for (int i = 1; i < lethalArea && (bombermanPosX - i) >= 0; i++)
                {
                    fieldBuffer = Location[bombermanPosY, bombermanPosX - i];

                    if (fieldBuffer.FieldType == GameObjectType.UNBREAKABLE_WALL)
                    {
                        break;
                    }

                    bombedField.ExplosionHendler += fieldBuffer.Destroy;
                    fieldBuffer.FieldStateChangeHendler += StateDidChange;
                    fieldBuffer.NotificationCount++;

                    if (fieldBuffer.FieldType == GameObjectType.BREAKABLE_WALL)
                    {
                        break;
                    }
                }

                for (int i = 1; i < lethalArea && (bombermanPosX + i) < Constants.Instance.GameMapWidth; i++)
                {
                    fieldBuffer = Location[bombermanPosY, bombermanPosX + i];

                    if (fieldBuffer.FieldType == GameObjectType.UNBREAKABLE_WALL)
                    {
                        break;
                    }

                    bombedField.ExplosionHendler += fieldBuffer.Destroy;
                    fieldBuffer.FieldStateChangeHendler += StateDidChange;
                    fieldBuffer.NotificationCount++;

                    if (fieldBuffer.FieldType == GameObjectType.BREAKABLE_WALL)
                    {
                        break;
                    }
                }
            }
        }

        #endregion bombermanControls

        private void BombDidExplose(FieldWidget field)
        {
            toUpdate.Remove(field);
            field.FieldStateChangeHendler -= BombDidExplose;
            field.FieldStateChangeHendler += StateDidChange;
            toUpdate.Add(field);
        }

        private void StateDidChange(FieldWidget field)
        {
            if (field.FieldType == GameObjectType.FIRE)
            {
                toUpdate.Add(field);
            }
            else
            {
                toUpdate.Remove(field);
                field.NotificationCount--;

                if (field.NotificationCount == 0)
                {
                    field.FieldStateChangeHendler -= StateDidChange;
                }
            }
        }

         
        private void characterDidDieHendler(LivingObject sender)
        {
            sender.CharacterDidDieHendler -= characterDidDieHendler;
            if (sender.Type == GameObjectType.MONSTER)
            {
                Creeps.Remove(sender as Monster);

                if (Creeps.Count == 0)
                {
                    GameOverHandler();
                }
            }
            else
            {
                GameOverHandler();
            }
        }


        public override void Update(GameTime gameTime)
        {
            foreach (Monster creep in Creeps.ToArray())
            {
                creep.Update(gameTime);
                Location[creep.YPositionOnMap, creep.XPositionOnMap].Visit(creep);

                if (creep.XPositionOnMap == Bomberman.XPositionOnMap && creep.YPositionOnMap == Bomberman.YPositionOnMap)
                {
                    Bomberman.Kill();
                }

                if (DarkBomberman != null && creep.XPositionOnMap == DarkBomberman.XPositionOnMap && creep.YPositionOnMap == DarkBomberman.YPositionOnMap)
                {
                    DarkBomberman.Kill();
                }
            }
            
            foreach (FieldWidget field in toUpdate.ToArray())
            {
                field.Update(gameTime);
            }

            Location[Bomberman.YPositionOnMap, Bomberman.XPositionOnMap].Visit(Bomberman);

            if (DarkBomberman != null)
            {
                Location[DarkBomberman.YPositionOnMap, DarkBomberman.XPositionOnMap].Visit(DarkBomberman);
            }
        }
    }
}
