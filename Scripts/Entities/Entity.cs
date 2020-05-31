using System.Collections.Generic;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Game;
using CityBuilder.Scripts.Global;

namespace CityBuilder.Scripts.Entities
{
    public class Entity
    {
        public List<Component> Components = new List<Component>();

        public int EntityId;

        public Entity()
        {
            World.AddEntity(this);
        }

        public T GetComponent<T>() where T : Component
        {
            for (var i = 0; i < Components.Count; i++)
            {
                var Component = Components[i];

                if (Component.GetType() == typeof(T))
                {
                    return (T)Component;
                }
            }

            return default(T);
        }

        public T AddComponent<T>(T t) where T : Component
        {
            Components.Add(t);

            t.Entity = this;
            t.Start();

            return t;
        }

        public virtual void Update()
        {
            for (var i = 0; i < Components.Count; i++)
            {
                var Component = Components[i];

                Component.Update();
            }
        }
    }
}
