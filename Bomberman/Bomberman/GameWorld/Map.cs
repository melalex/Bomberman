using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Bomberman.GameWorld.Environment;

namespace Bomberman.GameWorld
{
    class Map : IEnumerable
    {
        private FieldWidget[,] location = new FieldWidget[Constants.Instance.GameMapHeight, Constants.Instance.GameMapWidth];

        public FieldWidget GetObjectAt(int x, int y)
        {
            return location[y, x];
        }
        public FieldWidget this[int i, int j]
        {
            get { return location[i, j]; } 
        }

        public void SetMap(int[,] map)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    location[i, j] = new FieldWidget(j, i);
                    switch (map[i, j])
                    {
                        case 0:
                            location[i, j].SetState(location[i, j].EmptyFieldState);
                            break;

                        case 1:
                            location[i, j].SetState(location[i, j].BreakableWallState);
                            break;

                        case 2:
                            location[i, j].SetState(location[i, j].UnbreakableWallState);
                            break;
                    }
                    
                }
            }
        }

        public FieldWidget GetFieldByPosition(int x, int y)
        {
            return location[y / Constants.Instance.SideOfASprite, x / Constants.Instance.SideOfASprite];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (FieldWidget obj in location)
            {
                yield return obj;
            }
        }
    }
}
