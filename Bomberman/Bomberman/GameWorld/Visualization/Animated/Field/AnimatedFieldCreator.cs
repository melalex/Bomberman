using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Visualization.Animated.Field
{
    class AnimatedFieldCreator
    {
        static public AnimatedField CreateBomb(ContentManager content)
        {
            Texture2D[] frames = new Texture2D[3];

            frames[0] = content.Load<Texture2D>("Sprites\\Bomb\\Bomb_f01");
            frames[1] = content.Load<Texture2D>("Sprites\\Bomb\\Bomb_f02");
            frames[2] = content.Load<Texture2D>("Sprites\\Bomb\\Bomb_f03");

            return new AnimatedField(frames);
        }

        static public AnimatedField CreateFire(ContentManager content)
        {
            Texture2D[] frames = new Texture2D[5];

            frames[0] = content.Load<Texture2D>("Sprites\\Fire\\Flame_f00");
            frames[1] = content.Load<Texture2D>("Sprites\\Fire\\Flame_f01");
            frames[2] = content.Load<Texture2D>("Sprites\\Fire\\Flame_f02");
            frames[3] = content.Load<Texture2D>("Sprites\\Fire\\Flame_f03");
            frames[4] = content.Load<Texture2D>("Sprites\\Fire\\Flame_f04");

            return new AnimatedField(frames);
        }
    }
}
