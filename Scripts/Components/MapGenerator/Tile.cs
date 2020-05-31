using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Components.MapGenerator
{
    class Tile : Entity
    {
        public string Name;

        public Tile(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
