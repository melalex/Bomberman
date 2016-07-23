using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld
{
    enum GameObjectType : int
    {
        BOMB,
        FIRE,
        UNBREAKABLE_WALL,
        BREAKABLE_WALL,
        EMPTY_FIELD,
        POWERUP,
        PLAYER1,
        PLAYER2,
        MONSTER
    }
}
