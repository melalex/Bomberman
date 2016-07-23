using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Visualization.Animated.Character
{
    class AnimatedCharacterCreator
    {
        public static AnimatedCharacter PlayerOneCreator(ContentManager content)
        {
            Texture2D[] backFrames = new Texture2D[8];
            Texture2D[] frontFrames = new Texture2D[8];
            Texture2D[] leftFrames = new Texture2D[8];
            Texture2D[] rightFrames = new Texture2D[8];

            return new AnimatedCharacter(backFrames, frontFrames, leftFrames, rightFrames);
        }

        public static AnimatedCharacter PlayerTwoCreator(ContentManager content)
        {
            Texture2D[] backFrames = new Texture2D[8];
            Texture2D[] frontFrames = new Texture2D[8];
            Texture2D[] leftFrames = new Texture2D[8];
            Texture2D[] rightFrames = new Texture2D[8];

            return new AnimatedCharacter(backFrames, frontFrames, leftFrames, rightFrames);
        }

        public static AnimatedCharacter MonsterCreator(ContentManager content)
        {
            Texture2D[] backFrames = new Texture2D[6];
            Texture2D[] frontFrames = new Texture2D[6];
            Texture2D[] sideFrames = new Texture2D[7];
            Texture2D[] rightFrames = new Texture2D[7];

            backFrames[0] = content.Load<Texture2D>("Monster//Back//Creep_B_f00.png");
            backFrames[1] = content.Load<Texture2D>("Monster//Back//Creep_B_f01.png");
            backFrames[2] = content.Load<Texture2D>("Monster//Back//Creep_B_f02.png");
            backFrames[3] = content.Load<Texture2D>("Monster//Back//Creep_B_f03.png");
            backFrames[4] = content.Load<Texture2D>("Monster//Back//Creep_B_f04.png");
            backFrames[5] = content.Load<Texture2D>("Monster//Back//Creep_B_f05.png");

            frontFrames[0] = content.Load<Texture2D>("Monster//Front//Creep_F_f00.png");
            frontFrames[1] = content.Load<Texture2D>("Monster//Front//Creep_F_f01.png");
            frontFrames[2] = content.Load<Texture2D>("Monster//Front//Creep_F_f02.png");
            frontFrames[3] = content.Load<Texture2D>("Monster//Front//Creep_F_f03.png");
            frontFrames[4] = content.Load<Texture2D>("Monster//Front//Creep_F_f04.png");
            frontFrames[5] = content.Load<Texture2D>("Monster//Front//Creep_F_f05.png");

            sideFrames[0] = content.Load<Texture2D>("Monster//LeftSide//Creep_S_f00.png");
            sideFrames[1] = content.Load<Texture2D>("Monster//LeftSide//Creep_S_f01.png");
            sideFrames[2] = content.Load<Texture2D>("Monster//LeftSide//Creep_S_f02.png");
            sideFrames[3] = content.Load<Texture2D>("Monster//LeftSide//Creep_S_f03.png");
            sideFrames[4] = content.Load<Texture2D>("Monster//LeftSide//Creep_S_f04.png");
            sideFrames[5] = content.Load<Texture2D>("Monster//LeftSide//Creep_S_f05.png");
            sideFrames[6] = content.Load<Texture2D>("Monster//LeftSide//Creep_S_f06.png");

            rightFrames[0] = content.Load<Texture2D>("Monster//RightSide//Creep_S_f00.png");
            rightFrames[1] = content.Load<Texture2D>("Monster//RightSide//Creep_S_f01.png");
            rightFrames[2] = content.Load<Texture2D>("Monster//RightSide//Creep_S_f02.png");
            rightFrames[3] = content.Load<Texture2D>("Monster//RightSide//Creep_S_f03.png");
            rightFrames[4] = content.Load<Texture2D>("Monster//RightSide//Creep_S_f04.png");
            rightFrames[5] = content.Load<Texture2D>("Monster//RightSide//Creep_S_f05.png");
            rightFrames[6] = content.Load<Texture2D>("Monster//RightSide//Creep_S_f06.png");

            return new AnimatedCharacter(backFrames, frontFrames, sideFrames, rightFrames);
        }
    }
}
