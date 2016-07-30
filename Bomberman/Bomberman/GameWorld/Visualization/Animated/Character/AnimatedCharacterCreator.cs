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
        public static AnimatedCharacter PlayerCreator(ContentManager content)
        {
            Texture2D[] backFrames = new Texture2D[8];
            Texture2D[] frontFrames = new Texture2D[8];
            Texture2D[] sideFrames = new Texture2D[8];

            backFrames[0] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f00");
            backFrames[1] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f01");
            backFrames[2] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f02");
            backFrames[3] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f03");
            backFrames[4] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f04");
            backFrames[5] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f05");
            backFrames[6] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f06");
            backFrames[7] = content.Load<Texture2D>("Sprites\\Bomberman\\Back\\Bman_B_f07");

            frontFrames[0] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f00");
            frontFrames[1] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f01");
            frontFrames[2] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f02");
            frontFrames[3] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f03");
            frontFrames[4] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f04");
            frontFrames[5] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f05");
            frontFrames[6] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f06");
            frontFrames[7] = content.Load<Texture2D>("Sprites\\Bomberman\\Front\\Bman_F_f07");

            sideFrames[0] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f00");
            sideFrames[1] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f01");
            sideFrames[2] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f02");
            sideFrames[3] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f03");
            sideFrames[4] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f04");
            sideFrames[5] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f05");
            sideFrames[6] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f06");
            sideFrames[7] = content.Load<Texture2D>("Sprites\\Bomberman\\Side\\Bman_F_f07");

            return new AnimatedCharacter(backFrames, frontFrames, sideFrames);
        }

        public static AnimatedCharacter MonsterCreator(ContentManager content)
        {
            Texture2D[] backFrames = new Texture2D[6];
            Texture2D[] frontFrames = new Texture2D[6];
            Texture2D[] sideFrames = new Texture2D[7];

            backFrames[0] = content.Load<Texture2D>("Sprites\\Monster\\Back\\Creep_B_f00");
            backFrames[1] = content.Load<Texture2D>("Sprites\\Monster\\Back\\Creep_B_f01");
            backFrames[2] = content.Load<Texture2D>("Sprites\\Monster\\Back\\Creep_B_f02");
            backFrames[3] = content.Load<Texture2D>("Sprites\\Monster\\Back\\Creep_B_f03");
            backFrames[4] = content.Load<Texture2D>("Sprites\\Monster\\Back\\Creep_B_f04");
            backFrames[5] = content.Load<Texture2D>("Sprites\\Monster\\Back\\Creep_B_f05");

            frontFrames[0] = content.Load<Texture2D>("Sprites\\Monster\\Front\\Creep_F_f00");
            frontFrames[1] = content.Load<Texture2D>("Sprites\\Monster\\Front\\Creep_F_f01");
            frontFrames[2] = content.Load<Texture2D>("Sprites\\Monster\\Front\\Creep_F_f02");
            frontFrames[3] = content.Load<Texture2D>("Sprites\\Monster\\Front\\Creep_F_f03");
            frontFrames[4] = content.Load<Texture2D>("Sprites\\Monster\\Front\\Creep_F_f04");
            frontFrames[5] = content.Load<Texture2D>("Sprites\\Monster\\Front\\Creep_F_f05");

            sideFrames[0] = content.Load<Texture2D>("Sprites\\Monster\\Side\\Creep_S_f00");
            sideFrames[1] = content.Load<Texture2D>("Sprites\\Monster\\Side\\Creep_S_f01");
            sideFrames[2] = content.Load<Texture2D>("Sprites\\Monster\\Side\\Creep_S_f02");
            sideFrames[3] = content.Load<Texture2D>("Sprites\\Monster\\Side\\Creep_S_f03");
            sideFrames[4] = content.Load<Texture2D>("Sprites\\Monster\\Side\\Creep_S_f04");
            sideFrames[5] = content.Load<Texture2D>("Sprites\\Monster\\Side\\Creep_S_f05");
            sideFrames[6] = content.Load<Texture2D>("Sprites\\Monster\\Side\\Creep_S_f06");

            return new AnimatedCharacter(backFrames, frontFrames, sideFrames);
        }
    }
}
