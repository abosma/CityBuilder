using System.Collections.Generic;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Components.Positions;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Global;
using SFML.System;

namespace CityBuilder.Scripts.Entities
{
    public class Entity
    {
        public List<Component> Components = new List<Component>();

        public int EntityId;

        public string Name;

        public bool IsActive = true;

        public Transform Transform;

        public Entity(int x = 0, int y = 0, string name = "DefaultName")
        {
            Transform = AddComponent(new Transform(x, y));
            Name = name;
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

        public virtual void SetActive(bool active)
        {
            IsActive = active;
        }

        public virtual void Destroy()
        {
            for (var i = 0; i < Components.Count; i++)
            {
                var Component = Components[i];

                if (Component.GetType() == typeof(Collider))
                {
                    WorldCollision.RemoveCollider((Collider)Component);
                }

                if (Component.GetType() == typeof(Renderer))
                {
                    var Renderer = (Renderer) Component;

                    DrawableHandler.RemoveDrawable(Renderer.Drawable);
                }
            }

            World.RemoveEntity(this);
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
