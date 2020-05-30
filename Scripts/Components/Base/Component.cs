using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Components
{
    public interface IComponent
    {
        Entity Entity { get; set; }

        void Start();
        void Update();
    }
}
