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

        #region Controls
        public void GoUp(GameTime gameTime)
        {
            Rectangle next = Position;
            int dy = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(0, -dy);

            if (Location.IsPassable(XPositionOnMap, YPositionOnMap - 1) || next.Top > YPositionOnMap * Constants.Instance.SideOfASprite)
            {
                Position = next;
                MyDirection = Direction.UP;
                PositionDidChange(this);
            }
        }

        public void GoDown(GameTime gameTime)
        {
            Rectangle next = Position;
            int dy = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(0, dy);

            if (Location.IsPassable(XPositionOnMap, YPositionOnMap + 1) || next.Bottom < (YPositionOnMap + 1) * Constants.Instance.SideOfASprite)
            {
                Position = next;
                MyDirection = Direction.DOWN;
                PositionDidChange(this);
            }
        }

        public void GoLeft(GameTime gameTime)
        {
            Rectangle next = Position;
            int dx = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(-dx, 0);

            if (Location.IsPassable(XPositionOnMap - 1, YPositionOnMap) || next.Left > XPositionOnMap * Constants.Instance.SideOfASprite)
            {
                Position = next;
                MyDirection = Direction.LEFT;
                PositionDidChange(this);
            }
        }

        public void GoRight(GameTime gameTime)
        {
            Rectangle next = Position;
            int dx = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(dx, 0);

            if (Location.IsPassable(XPositionOnMap + 1, YPositionOnMap) || next.Right < (XPositionOnMap + 1) * Constants.Instance.SideOfASprite)
            {
                Position = next;
                MyDirection = Direction.RIGHT;
                PositionDidChange(this);
            }
        }

        #endregion Controls

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
            if (bombCount > 0 && Location[YPositionOnMap, XPositionOnMap].FieldType != GameObjectType.BOMB)
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

        }
    }
}
