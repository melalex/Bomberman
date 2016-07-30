using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Visualization.Animated.Character
{
    class AnimatedCharacter : AbstractSprite
    {
        private Texture2D[] backFrames;
        private Texture2D[] frontFrames;
        private Texture2D[] sideFrames;

        public int BackFramesCount
        {
            get { return backFrames.Length; }
        }
        public int FrontFramesCount
        {
            get { return frontFrames.Length; }
        }
        public int SideFramesCount
        {
            get { return sideFrames.Length; }
        }

        public AnimatedCharacter(Texture2D[] backFrames, Texture2D[] frontFrames, Texture2D[] sideFrames)
        {
            this.backFrames = backFrames;
            this.frontFrames = frontFrames;
            this.sideFrames = sideFrames;
        }

        public Texture2D GetBackFrame(int frameNumber)
        {
            return backFrames[frameNumber];
        }

        public Texture2D GetFrontFrame(int frameNumber)
        {
            return frontFrames[frameNumber];
        }

        public Texture2D GetSideFrames(int frameNumber)
        {
            return sideFrames[frameNumber];
        }
    }
}
