using Bomberman.GameWorld.Environment;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.LivingObjects
{
    delegate void PositionChange(LivingObject sender);
    delegate void CharacterDidDie(LivingObject sender);

    abstract class LivingObject
    {
        public event PositionChange PositionChangeHendler;
        public event CharacterDidDie CharacterDidDieHendler;

        public bool Alive { get; protected set; } = true;

        public int Velocity { get; protected set; }

        public Map Location { get; protected set; }

        public GameObjectType Type { get; protected set; }

        public Rectangle Position { get; protected set; }

        public int XPositionOnMap
        {
            get { return Position.Center.X / Constants.Instance.SideOfASprite; }
        }

        public int YPositionOnMap
        {
            get { return (Position.Bottom + Position.Center.Y) / 2 / Constants.Instance.SideOfASprite; }
        }

        public Direction MyDirection { get; protected set; } = Direction.STAND;

        #region Controls
        public bool GoUp(GameTime gameTime)
        {
            bool result = false;

            Rectangle next = Position;
            int dy = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(0, -dy);

            if (Location.IsPassable(XPositionOnMap, YPositionOnMap - 1) || next.Top > YPositionOnMap * Constants.Instance.SideOfASprite)
            {
                result = true;
                Position = next;
                MyDirection = Direction.UP;
                PositionDidChange(this);
            }

            return result;
        }

        public bool GoDown(GameTime gameTime)
        {
            bool result = false;

            Rectangle next = Position;
            int dy = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(0, dy);

            if (Location.IsPassable(XPositionOnMap, YPositionOnMap + 1) || next.Bottom < (YPositionOnMap + 1) * Constants.Instance.SideOfASprite)
            {
                result = true;
                Position = next;
                MyDirection = Direction.DOWN;
                PositionDidChange(this);
            }

            return result;
        }

        public bool GoLeft(GameTime gameTime)
        {
            bool result = false;

            Rectangle next = Position;
            int dx = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(-dx, 0);

            if (Location.IsPassable(XPositionOnMap - 1, YPositionOnMap) || next.Left > XPositionOnMap * Constants.Instance.SideOfASprite)
            {
                result = true;
                Position = next;
                MyDirection = Direction.LEFT;
                PositionDidChange(this);
            }

            return result;
        }

        public bool GoRight(GameTime gameTime)
        {
            bool result = false;

            Rectangle next = Position;
            int dx = Velocity * gameTime.ElapsedGameTime.Milliseconds / 100;
            next.Offset(dx, 0);

            if (Location.IsPassable(XPositionOnMap + 1, YPositionOnMap) || next.Right < (XPositionOnMap + 1) * Constants.Instance.SideOfASprite)
            {
                result = true;
                Position = next;
                MyDirection = Direction.RIGHT;
                PositionDidChange(this);
            }
            return result;
        }

        #endregion Controls

        protected virtual void PositionDidChange(LivingObject sender)
        {
            PositionChange handler = PositionChangeHendler;
            if (handler != null)
            {
                handler(this);
            }
        }

        protected virtual void CharacterDidDie(LivingObject sender)
        {
            CharacterDidDie handler = CharacterDidDieHendler;
            if (handler != null)
            {
                handler(this);
            }
        }

        abstract public void EatPowerup(Enhance enhanceMethod);

        abstract public void Kill();
    }
}
