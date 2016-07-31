using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.EnvironmentView.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bomberman.GameWorld.EnvironmentView.Visitor
{
    delegate Texture2D GetFrame(int index);

    class Drawer : IVisitor
    {
        public void visit(StaticFieldView element, SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(element.Sprite.GetSprite(), 
                             element.Position, 
                             null, 
                             element.FrameColor, 
                             0, 
                             new Vector2(0, 0), 
                             SpriteEffects.None, 
                             0);
        }

        public void visit(DinamicFieldView element, SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = null;

            element.TotalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (element.TotalTime > element.TimeForFrame)
            {
                element.FrameNumber++;
                element.FrameNumber = element.FrameNumber % (element.Animation.FrameCount - 1);
                element.TotalTime -= element.TimeForFrame;
            }

            texture = element.Animation.GetFrame(element.FrameNumber);

            spriteBatch.Draw(element.Background,
                             element.Position,
                             null,
                             Color.White,
                             0,
                             new Vector2(0, 0),
                             SpriteEffects.None,
                             0);

            spriteBatch.Draw(texture,
                             element.Position,
                             null,
                             element.FrameColor,
                             0,
                             new Vector2(0, 0),
                             SpriteEffects.None,
                             0);
        }

        public void visit(MoveableView element, SpriteBatch spriteBatch, GameTime gameTime)
        { 
            Texture2D texture = null;
            int frameCount = 0;
            GetFrame getFrame = null;
            SpriteEffects spriteEffects = SpriteEffects.None;

            switch (element.MyDirection)
            {
                case Direction.UP:
                    frameCount = element.Animation.BackFramesCount;
                    getFrame = element.Animation.GetBackFrame;
                    break;

                case Direction.DOWN:
                    frameCount = element.Animation.FrontFramesCount;
                    getFrame = element.Animation.GetFrontFrame;
                    break;

                case Direction.LEFT:
                    frameCount = element.Animation.SideFramesCount;
                    getFrame = element.Animation.GetSideFrames;
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    break;

                case Direction.RIGHT:
                    frameCount = element.Animation.SideFramesCount;
                    getFrame = element.Animation.GetSideFrames;
                    break;

                case Direction.STAND:
                    element.FrameNumber = 0;
                    element.TotalTime = 0;
                    frameCount = element.Animation.FrontFramesCount;
                    getFrame = element.Animation.GetFrontFrame;
                    break;
            }

            element.TotalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (element.TotalTime > element.TimeForFrame)
            {
                element.FrameNumber++;
                element.FrameNumber = element.FrameNumber % (frameCount - 1);
                element.TotalTime -= element.TimeForFrame;
            }

            element.MyDirection = Direction.STAND;

            texture = getFrame(element.FrameNumber);

            spriteBatch.Draw(texture,
                             element.Position,
                             null,
                             element.FrameColor,
                             0,
                             new Vector2(0, 0),
                             spriteEffects,
                             0);
        }

    }
}
