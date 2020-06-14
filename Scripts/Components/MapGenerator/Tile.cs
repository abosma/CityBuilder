using CityBuilder.Scripts.Components.Positions;
using CityBuilder.Scripts.Entities;

namespace CityBuilder.Scripts.Components.MapGenerator
{
    class Tile : Entity
    {
        public TileType TileType;
        public int MapLocationX;
        public int MapLocationY;

        public Tile(int mapLocationX, int mapLocationY, int x = 0, int y = 0, string name = "DefaultName")
        {
            Transform = AddComponent(new Transform(x, y));
            Name = name;
            MapLocationX = mapLocationX;
            MapLocationY = mapLocationY;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    enum TileType
    {
        Water,
        Ground,
        Grass
    }
}
