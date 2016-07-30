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

        public FieldWidget this[int i, int j]
        {
            get { return location[i, j]; } 
        }

        public Map(int[,] map)
        {
            for (int i = 0; i < Constants.Instance.GameMapHeight; i++)
            {
                for (int j = 0; j < Constants.Instance.GameMapWidth; j++)
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

        public bool IsPassable(int j, int i)
        {
            bool result = true;

            if (j < 0 || j > Constants.Instance.GameMapWidth ||
                i < 0 || i > Constants.Instance.GameMapHeight ||
                location[i, j].FieldType == GameObjectType.BREAKABLE_WALL ||
                location[i, j].FieldType == GameObjectType.UNBREAKABLE_WALL ||
                location[i, j].FieldType == GameObjectType.BOMB)
            {
                result = false;
            }

            return result;
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
