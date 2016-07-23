using Bomberman.State.MVP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.State.MVP.Presenter
{
    class AbstractPresenter : IGameState
    {
        protected AbstractModel model;
        protected SpriteBatch view;
    }
}
