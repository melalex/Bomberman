using Bomberman.GameWorld.EnvironmentView.Views;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Factories
{
    abstract class ViewAbstractFactory
    {
        abstract public AbstractView CreateView(Rectangle position, Color color);
    }
}
