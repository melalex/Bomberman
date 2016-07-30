using Bomberman.GameWorld.Environment;
using Bomberman.GameWorld.EnvironmentView.Views;
using Bomberman.GameWorld.Factories;
using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.EnvironmentView.Wrapers
{
    class ViewWraperFactory
    {
        private FactoriesCreator factoriesCreator;

        public ViewWraperFactory(FactoriesCreator factoriesCreator)
        {
            this.factoriesCreator = factoriesCreator;
        }

        public IViewWraper CreateWraper(FieldWidget field)
        {
            ViewAbstractFactory factory = factoriesCreator.CreateFactory(field.FieldType);

            int sideOfASprite = Constants.Instance.SideOfASprite;
            Rectangle position = new Rectangle(field.XMapCoordinate * sideOfASprite,
                                               field.YMapCoordinate * sideOfASprite,
                                               sideOfASprite,
                                               sideOfASprite);

            position.Offset(Constants.Instance.XGameMapPosition, Constants.Instance.YGameMapPosition);

            FieldViewWraper fieldViewWraper = new FieldViewWraper(factory.CreateView(position, Color.White), factoriesCreator);

            field.FieldStateChangeHendler += fieldViewWraper.ViewChangeType;

            return fieldViewWraper;
        }

        public IViewWraper CreateWraper(LivingObject moveable)
        {
            GameObjectType playerType = moveable.Type;
            ViewAbstractFactory factory = factoriesCreator.CreateFactory(playerType);
            Color color = playerType == GameObjectType.PLAYER2 ? Color.Red : Color.White;

            int sideOfASprite = Constants.Instance.SideOfASprite;
            Rectangle position = moveable.Position;

            position.Offset(Constants.Instance.XGameMapPosition, Constants.Instance.YGameMapPosition);

            MoveableViewWraper moveableViewWraper = new MoveableViewWraper(factory.CreateView(position, color));

            moveable.PositionChangeHendler += moveableViewWraper.ViewChangePosition;

            return moveableViewWraper;
        }
    }
}
