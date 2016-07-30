using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Environment
{
    delegate void FieldStateChange(FieldWidget field);
    delegate void Explosion();

    class FieldWidget
    {
        private EmptyField _emptyFieldState;
        private BreakableWall _breakableWallState;
        private UnbreakableWall _unbreakableWallState;
        private Fire _fireState;
        private Powerup _speedBoostState;
        private Powerup _bombCountBoostState;
        private Powerup _lethalAreaBoostState;

        public EmptyField EmptyFieldState
        {
            get
            {
                if (_emptyFieldState == null)
                {
                    _emptyFieldState = new EmptyField(this);
                }
                return _emptyFieldState;
            }
        }
        public BreakableWall BreakableWallState
        {
            get
            {
                if (_breakableWallState == null)
                {
                    _breakableWallState = new BreakableWall(this); ;
                }
                return _breakableWallState;
            }
        }
        public UnbreakableWall UnbreakableWallState
        {
            get
            {
                if (_unbreakableWallState == null)
                {
                    _unbreakableWallState = new UnbreakableWall(this);
                }
                return _unbreakableWallState;
            }
        }
        public Fire FireState
        {
            get
            {
                if (_fireState == null)
                {
                    _fireState = new Fire(this);
                }
                return _fireState;
            }
        }
        public Powerup SpeedBoostState
        {
            get
            {
                if (_speedBoostState == null)
                {
                    _speedBoostState = new Powerup((Player player) => player.IncreaseSpeed(), GameObjectType.SPEED_POWERUP, this);
                }
                return _speedBoostState;
            }
        }
        public Powerup BombCountBoostState
        {
            get
            {
                if (_bombCountBoostState == null)
                {
                    _bombCountBoostState = new Powerup((Player player) => player.IncreaseBombCount(), GameObjectType.BOMB_POWERUP, this);
                }
                return _bombCountBoostState;
            }
        }
        public Powerup LethalAreaBoostState
        {
            get
            {
                if (_lethalAreaBoostState == null)
                {
                    _lethalAreaBoostState = new Powerup((Player player) => player.IncreaseLethalArea(), GameObjectType.FIRE_POWERUP, this);
                }
                return _lethalAreaBoostState;
            }
        }

        private AbstraktField currentState;
         
        public event FieldStateChange FieldStateChangeHendler;
        public event Explosion ExplosionHendler;

        public int XMapCoordinate { get; }
        public int YMapCoordinate { get; }

        public int NotificationCount { get; set; } = 0;

        public GameObjectType FieldType
        {
            get { return currentState.FieldType; }
        }
         
        public FieldWidget(int x, int y)
        {
            XMapCoordinate = x;
            YMapCoordinate = y;
        }

        public void SetState(AbstraktField newState)
        {
            currentState = newState;
            if (FieldStateChangeHendler != null)
            {
                FieldStateChangeHendler(this);
            }
        }

        public void BombExploded()
        {
            if (ExplosionHendler != null)
            {
                ExplosionHendler();
                ExplosionHendler = null;
            }
            SetState(FireState.SetNextState(EmptyFieldState));
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Destroy()
        {
            currentState.Destroy();
        }

        public void Visit(LivingObject visitor)
        {
            currentState.Visit(visitor);
        }
    }
}
