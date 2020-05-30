using System.Collections.Generic;
using CityBuilder.Scripts.Components;
using CityBuilder.Scripts.Game;

namespace CityBuilder.Scripts.Entities
{
    public class Entity
    {
        public List<IComponent> Components = new List<IComponent>();

        public int EntityId;

        public Entity()
        {
            World.AddEntity(this);
        }

        public T GetComponent<T>() where T : IComponent
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

        public T AddComponent<T>(T t) where T : IComponent
        {
            Components.Add(t);

            t.Entity = this;
            t.Start();

            return t;
        }

        public virtual void Start()
        {
            
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
