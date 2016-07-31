using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman
{
    class Fonts
    {
        private static readonly Fonts instance = new Fonts();

        public static Fonts Instance
        {
            get { return instance; }
        }

        protected Fonts() { }

        public SpriteFont ResultFont { get; private set; }

        public void InitFonts(ContentManager content)
        {
            ResultFont = content.Load<SpriteFont>("Fonts\\SpriteFont1");
        }
    }
}
