using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Components.Base
{
    public abstract class Component
    {
        public Entity Entity;

        public abstract void Start();
        public abstract void Update();
    }
}
