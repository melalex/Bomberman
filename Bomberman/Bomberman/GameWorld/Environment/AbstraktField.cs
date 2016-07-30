using Bomberman.GameWorld.LivingObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomberman.GameWorld.Environment
{ 
    abstract class AbstraktField
    {
        private WeakReference _field;
        protected FieldWidget field
        {
            set { _field = new WeakReference(value); }
            get { return _field.Target as FieldWidget; }
        }
        
        public GameObjectType FieldType { get; protected set; }

        virtual public void Update(GameTime gameTime)
        {
            Destroy();
        }

        abstract public void Destroy();

        abstract public void Visit(LivingObject visitor);
    }
}
