using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.EnvironmentView.Visitor;
using Bomberman.GameWorld.Visualization.Animated.Field;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bomberman.GameWorld.EnvironmentView.Views
{
    class DinamicFieldView : AbstractView
    {
        private float _timeForFrame;

        public Texture2D Background { get; }
        public AnimatedField Animation { get; }
        public int FrameNumber { get; set; } = 0;
        public float TotalTime { get; set; } = 0;
        public float TimeForFrame
        {
            get { return _timeForFrame; }
            set { _timeForFrame = 1f / value; }
        }
    
        public DinamicFieldView(Rectangle position, AnimatedField animation, int animationSpeed, Texture2D background, Color color)
        {
            Position = position;
            Background = background;
            Animation = animation;
            FrameColor = color;
            TimeForFrame = animationSpeed;
        }

        public override void Accept(IVisitor drawer, SpriteBatch spriteBatch, GameTime gameTime)
        {
            drawer.visit(this, spriteBatch, gameTime);
        }
    }
}
