using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.EnvironmentView.Visitor;
using Bomberman.GameWorld.Visualization.Animated.Character;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bomberman.GameWorld.EnvironmentView.Views
{
    class MoveableView : AbstractView
    {
        private float _timeForFrame;

        public AnimatedCharacter Animation { get; }

        public int FrameNumber { get; set; } = 0;
        public float TotalTime { get; set; } = 0;

        public float TimeForFrame
        {
            get { return _timeForFrame; }
            set { _timeForFrame = (1f / (value * 10)); }
        }

        public Direction MyDirection { get; set; }

        public MoveableView(Rectangle position, AnimatedCharacter animation, Color color)
        {
            Position = position;
            Animation = animation;
            FrameColor = color;
            TimeForFrame = Constants.Instance.DefaultVelocity;
        }

        public override void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime)
        {
            drawer.visit(this, spriteBatch, gameTime);
        }
    }
}
