﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bomberman.GameWorld.EnvironmentView.Views;
using Microsoft.Xna.Framework;
using Bomberman.visualizationGameWorld;

namespace Bomberman.GameWorld.Factories
{
    class FireFactory : ViewAbstractFactory
    {
        public override AbstractView CreateView(Rectangle position, Color color)
        {
            return new DinamicFieldView(position, SpritePool.Instance.Fire, Constants.Instance.BurningAnimationSpeed, SpritePool.Instance.EmptyField.GetSprite(), color);
        }
    }
}
