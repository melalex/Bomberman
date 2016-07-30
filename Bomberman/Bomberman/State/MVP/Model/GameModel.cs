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
        private HashSet<FieldWidget> toUpdate = new HashSet<FieldWidget>();

        public Map Location { get; }

        public Player Bomberman { get; set; }
        public Player DarkBomberman { get; set; }
        public Monster[] Creeps { get; set; }

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

        #endregion bombermanControls

        #region darkBombermanControls

        public void DarkBombermanGoUp()
        {

        }

        public void DarkBombermanGoDown()
        {

        }

        public void DarkBombermanGoLeft()
        {

        }

        public void DarkBombermanGoRight()
        {

        }

        public void DarkBombermanPlantsBomb()
        {

        }

        #endregion bombermanControls


        public override void Update(GameTime gameTime)
        {
            foreach (Monster creep in Creeps)
            {
                creep.Update(gameTime);
                Location[creep.YPositionOnMap, creep.XPositionOnMap].Visit(creep);
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
