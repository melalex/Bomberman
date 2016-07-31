using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Bomberman.State.MVP.Model
{
    enum MenuEntryes : int
    {
        SELECTED,
        UNSELECTED,
    }

    class MenuModel : AbstractModel
    {
        public int SelectedMenuEntry { get; protected set; } = 0;

        private MenuEntryes[] menuEntryes;

        public MenuModel()
        {
            menuEntryes = new MenuEntryes[2];

            menuEntryes[0] = MenuEntryes.SELECTED;
            menuEntryes[1] = MenuEntryes.UNSELECTED;
        }

        public MenuEntryes GetMenuEntry(int index)
        {
            return menuEntryes[index];
        }

        public void GoUp()
        {
            menuEntryes[SelectedMenuEntry] = MenuEntryes.UNSELECTED;
            SelectedMenuEntry++;
            SelectedMenuEntry %= menuEntryes.Length;
            menuEntryes[SelectedMenuEntry] = MenuEntryes.SELECTED;
        }

        public void GoDown()
        {
            menuEntryes[SelectedMenuEntry] = MenuEntryes.UNSELECTED;
            SelectedMenuEntry--;
            if (SelectedMenuEntry < 0)
            {
                SelectedMenuEntry = menuEntryes.Length - 1;
            }
            menuEntryes[SelectedMenuEntry] = MenuEntryes.SELECTED;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
