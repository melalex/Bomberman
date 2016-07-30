using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Bomberman.GameWorld.Visualization.Static
{
    class StaticSprite : AbstractSprite
    {
        private Texture2D sprite;

        public StaticSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
         
        public Texture2D GetSprite()
        {
            return sprite;
        }
    }
}
