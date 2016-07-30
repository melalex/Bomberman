using Bomberman.GameWorld.Environment;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.LivingObjects
{
    delegate void PositionChange(LivingObject sender);

    abstract class LivingObject
    {
        public event PositionChange PositionChangeHendler;

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

        protected virtual void PositionDidChange(LivingObject sender)
        {
            PositionChange handler = PositionChangeHendler;
            if (handler != null)
            {
                handler(this);
            }
        }

        abstract public void EatPowerup(Enhance enhanceMethod);

        abstract public void Kill();
    }
}
