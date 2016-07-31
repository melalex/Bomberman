using Bomberman.GameWorld.Environment;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.LivingObjects
{
    class Player : LivingObject
    {
        public int LethalArea { get; private set; } = Constants.Instance.DefaultLethalArea;

        private int bombCount = Constants.Instance.DefaultBombCount;

        public Player(int x, int y, Map location, GameObjectType playerType)
        {
            Position = new Rectangle(x, y, Constants.Instance.SideOfASprite, Constants.Instance.SideOfASprite);
            Type = playerType;
            this.Location = location;

            Velocity = Constants.Instance.DefaultVelocity;
        }

        #region powerups

        public void IncreaseSpeed()
        {
            Velocity++;
        }

        public void IncreaseLethalArea()
        {
            LethalArea++;
        }

        public void IncreaseBombCount()
        {
            bombCount++;
        }

        #endregion powerups

        public FieldWidget CreateBomb()
        {
            FieldWidget fieldOfNewBomb = null;
            if (Alive && bombCount > 0 && Location[YPositionOnMap, XPositionOnMap].FieldType != GameObjectType.BOMB)
            {
                fieldOfNewBomb = Location[YPositionOnMap, XPositionOnMap];
                Bomb newBomb = new Bomb(LethalArea, fieldOfNewBomb);
                fieldOfNewBomb.SetState(newBomb);
                fieldOfNewBomb.FieldStateChangeHendler += bombExplosed;
                bombCount--;
            }
            return fieldOfNewBomb;
        }

        private void bombExplosed(FieldWidget field)
        {
            bombCount++;
            field.FieldStateChangeHendler -= bombExplosed;
        }

        public override void EatPowerup(Enhance enhanceMethod)
        {
            enhanceMethod(this);
        }

        public override void Kill()
        {
            Alive = false;
            PositionDidChange(this);
            CharacterDidDie(this);
        }
    }
}
