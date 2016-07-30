using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.State.MVP.Model
{
    abstract class AbstractModel
    {
        abstract public void Update(GameTime gameTime);
    }
}
