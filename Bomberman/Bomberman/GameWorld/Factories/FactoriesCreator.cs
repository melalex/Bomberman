using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Factories
{
    class FactoriesCreator
    {
        private BombFactory _bombFactory;
        private BombCountPowerupFactory _bombCountPowerupFactory;
        private BreakableWallFactory _breakableWallFactory;
        private EmptyFieldFactory _emptyFieldFactory;
        private FireFactory _fireFactory;
        private LethalAreaPowerupFactory _lethalAreaPowerupFactory;
        private MonsterFactory _monsterFactory;
        private PlayerFactory _playerFactory;
        private SpeedPowerupFactory _speedPowerupFactory;
        private UnbreakableWallFactory _unbreakableWallFactory;

        private BombFactory BombFactory
        {
            get
            {
                if (_bombFactory == null)
                {
                    _bombFactory = new BombFactory();
                }
                return _bombFactory;
            }
        }
        private BombCountPowerupFactory BombCountPowerupFactory
        {
            get
            {
                if (_bombCountPowerupFactory == null)
                {
                    _bombCountPowerupFactory = new BombCountPowerupFactory();
                }
                return _bombCountPowerupFactory;
            }
        }
        private BreakableWallFactory BreakableWallFactory
        {
            get
            {
                if (_breakableWallFactory == null)
                {
                    _breakableWallFactory = new BreakableWallFactory();
                }
                return _breakableWallFactory;
            }
        }
        private EmptyFieldFactory EmptyFieldFactory
        {
            get
            {
                if (_emptyFieldFactory == null)
                {
                    _emptyFieldFactory = new EmptyFieldFactory();
                }
                return _emptyFieldFactory;
            }
        }
        private FireFactory FireFactory
        {
            get
            {
                if (_fireFactory == null)
                {
                    _fireFactory = new FireFactory();
                }
                return _fireFactory;
            }
        }
        private LethalAreaPowerupFactory LethalAreaPowerupFactory
        {
            get
            {
                if (_lethalAreaPowerupFactory == null)
                {
                    _lethalAreaPowerupFactory = new LethalAreaPowerupFactory();
                }
                return _lethalAreaPowerupFactory;
            }
        }
        private MonsterFactory MonsterFactory
        {
            get
            {
                if (_monsterFactory == null)
                {
                    _monsterFactory = new MonsterFactory();
                }
                return _monsterFactory;
            }
        }
        private PlayerFactory PlayerFactory
        {
            get
            {
                if (_playerFactory == null)
                {
                    _playerFactory = new PlayerFactory();
                }
                return _playerFactory;
            }
        }
        private SpeedPowerupFactory SpeedPowerupFactory
        {
            get
            {
                if (_speedPowerupFactory == null)
                {
                    _speedPowerupFactory = new SpeedPowerupFactory();
                }
                return _speedPowerupFactory;
            }
        }
        private UnbreakableWallFactory UnbreakableWallFactory
        {
            get
            {
                if (_unbreakableWallFactory == null)
                {
                    _unbreakableWallFactory = new UnbreakableWallFactory();
                }
                return _unbreakableWallFactory;
            }
        }

        public ViewAbstractFactory CreateFactory(GameObjectType productType)
        {
            ViewAbstractFactory result = null;
            
            switch (productType)
            {
                case GameObjectType.BOMB:
                    result = this.BombFactory;
                    break;

                case GameObjectType.BOMB_POWERUP:
                    result = this.BombCountPowerupFactory;
                    break;

                case GameObjectType.BREAKABLE_WALL:
                    result = this.BreakableWallFactory;
                    break;

                case GameObjectType.EMPTY_FIELD:
                    result = this.EmptyFieldFactory;
                    break;

                case GameObjectType.FIRE:
                    result = this.FireFactory;
                    break;

                case GameObjectType.FIRE_POWERUP:
                    result = this.LethalAreaPowerupFactory;
                    break;

                case GameObjectType.MONSTER:
                    result = this.MonsterFactory;
                    break;

                case GameObjectType.PLAYER1:
                case GameObjectType.PLAYER2:
                    result = this.PlayerFactory;
                    break;

                case GameObjectType.SPEED_POWERUP:
                    result = this.SpeedPowerupFactory;
                    break;

                case GameObjectType.UNBREAKABLE_WALL:
                    result = this.UnbreakableWallFactory;
                    break;    
            }

            return result;
        }
    }
}
