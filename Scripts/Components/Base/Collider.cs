using System;
using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Components.Base
{
    public abstract class Collider : Component
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public event Action<Entity> CollidedWithEntity;

        public abstract bool IsCollidingWithEntity(Entity entity);
        public abstract void OnCollidedWithEntity(Entity entity);
    }
}
