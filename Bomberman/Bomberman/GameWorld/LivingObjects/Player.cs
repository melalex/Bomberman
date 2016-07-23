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
        private int lethalArea = Constants.Instance.DefaultLethalArea;
        private int bombCount = Constants.Instance.DefaultBombCount;

        private Rectangle position;
        private int velocity = Constants.Instance.DefaultVelocity;

        public int XPositionOnMap
        {
            get { return position.Center.X / Constants.Instance.SideOfASprite; }
        }

        public int YPositionOnMap
        {
            get { return position.Center.Y / Constants.Instance.SideOfASprite; }
        }

        public Player(int x, int y,)
        {
            position = new Rectangle(x, y, Constants.Instance.SideOfASprite, Constants.Instance.SideOfASprite);
        }

        #region Controls
        public void GoUp()
        {

        }

        public void GoDown()
        {

        }

        public void GoLeft()
        {

        }

        public void GoRight()
        {

        }

        #endregion Controls

        #region powerups

        public void IncreaseSpeed()
        {

        }

        public void IncreaseLethalArea()
        {
            lethalArea++;
        }

        public void IncreaseBombCount()
        {
            bombCount++;
        }

        #endregion powerups

        public Bomb CreateBomb(FieldWidget field)
        {
            Bomb newBomb = null;
            if (bombCount > 0)
            {
                newBomb = new Bomb(lethalArea, field);
            }
            return newBomb;
        }

        public override void EatPowerup(Enhance enhanceMethod)
        {
            throw new NotImplementedException();
        }

        public override void Kill()
        {
            throw new NotImplementedException();
        }
    }
}
