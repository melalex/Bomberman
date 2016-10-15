using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld
{
    class MapsContainer
    {
        static private int onePlayerStartupCount = 0;
        private GameMapInformation[] _onePlayerMaps = null;
        public GameMapInformation NextOnePlayerMap
        {
            get
            {
                if (_onePlayerMaps == null)
                {
                    _onePlayerMaps = createOnePlayerMaps();
                }
                return _onePlayerMaps[onePlayerStartupCount++ % _onePlayerMaps.Length];
            }
        }

        static private int twoPlayersStartupCount = 0;
        private GameMapInformation[] _twoPlayersMaps = null;
        public GameMapInformation NextTwoPlayersMap
        {
            get
            {
                if (_twoPlayersMaps == null)
                {
                    _twoPlayersMaps = createTwoPlayersMaps();
                }
                return _twoPlayersMaps[twoPlayersStartupCount++ % _twoPlayersMaps.Length];
            }
        }

        #region maps

        private int[,] SimpleMap1 = { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, };

        private int[,] SimpleMap2 = { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 0, 2, 1, 1, 2, 0, 0, 2, 1, 1, 2, 0, 0, 2, 1, 1, 2, 0, 2 },
                                      { 2, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 2 },
                                      { 2, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 2 },
                                      { 2, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 2 },
                                      { 2, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 2 },
                                      { 2, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 2 },
                                      { 2, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 2 },
                                      { 2, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 2 },
                                      { 2, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 2 },
                                      { 2, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 2 },
                                      { 2, 0, 2, 1, 1, 2, 0, 0, 2, 1, 1, 2, 0, 0, 2, 1, 1, 2, 0, 2 },
                                      { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
                                      { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, };

        private int[,] SimpleMap3 = { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
                                      { 2, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0, 2 },
                                      { 2, 0, 2, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 2, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
                                      { 2, 0, 2, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 2, 0, 2 },
                                      { 2, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0, 2 },
                                      { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, };
        #endregion


        private GameMapInformation[] createOnePlayerMaps()
        {
            GameMapInformation[] result = new GameMapInformation[3];

            Rectangle firstPlayerPosition = createPosition(1, 1);

            Rectangle[] monsterPositions1 = new Rectangle[4];
            monsterPositions1[0] = createPosition(6, 1);
            monsterPositions1[1] = createPosition(16, 1);
            monsterPositions1[2] = createPosition(6, 13);
            monsterPositions1[3] = createPosition(16, 13);

            result[0] = new GameMapInformation(SimpleMap1, firstPlayerPosition, monsterPositions1);

            Rectangle[] monsterPositions2 = new Rectangle[4];
            monsterPositions2[0] = createPosition(18, 2);
            monsterPositions2[1] = createPosition(3, 3);
            monsterPositions2[2] = createPosition(9, 3);
            monsterPositions2[3] = createPosition(15, 3);
            result[1] = new GameMapInformation(SimpleMap2, firstPlayerPosition, monsterPositions2);

            Rectangle[] monsterPositions3 = new Rectangle[4];
            monsterPositions3[0] = createPosition(1, 13);
            monsterPositions3[1] = createPosition(18, 1);
            monsterPositions3[2] = createPosition(18, 13);
            monsterPositions3[3] = createPosition(9, 7);
            result[2] = new GameMapInformation(SimpleMap3, firstPlayerPosition, monsterPositions3);

            return result;
        }

        private GameMapInformation[] createTwoPlayersMaps()
        {
            GameMapInformation[] result = new GameMapInformation[3];
            Rectangle firstPlayerPosition = createPosition(1, 1);
            Rectangle secondPlayerPosition = createPosition(18, 13);

            result[0] = new GameMapInformation(SimpleMap1, firstPlayerPosition, secondPlayerPosition);
            result[1] = new GameMapInformation(SimpleMap2, firstPlayerPosition, secondPlayerPosition);
            result[2] = new GameMapInformation(SimpleMap3, firstPlayerPosition, secondPlayerPosition);
            return result;
        }

        private Rectangle createPosition(int x, int y)
        {
            return new Rectangle(
                    x * Constants.Instance.SideOfASprite,
                    y * Constants.Instance.SideOfASprite,
                    Constants.Instance.SideOfASprite,
                    Constants.Instance.SideOfASprite
                );
        }
    }
}
