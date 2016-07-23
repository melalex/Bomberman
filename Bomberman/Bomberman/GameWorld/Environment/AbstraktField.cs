using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Environment
{
    delegate void Notification(AbstraktField field);

    abstract class AbstraktField : AbstractGameObject
    {
        public event Notification NotificationHendler;
        
        public GameObjectType FieldType { get; protected set; }

        protected void ReiseEvents(AbstraktField eventArgument)
        {
            Notification hendler = NotificationHendler;
            if (hendler != null)
            {
                hendler(eventArgument);
            }
        }

        abstract public bool Update(GameTime gameTime);

        abstract public void Visit(LivingObject visitor);
    }
}
