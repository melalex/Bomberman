using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Bomberman.GameWorld.Visualization.Animated.Field
{
    class AnimatedField : AbstractSprite
    {
        private Texture2D[] frames;

        public int FrameCount
        {
            get { return frames.Length; }
        } 
        
        public AnimatedField(Texture2D[] frames)
        {
            this.frames = frames;
        }

        public Texture2D GetFrame(int frameNumber)
        {
            return frames[frameNumber];
        }
    }
}
