using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Global;

namespace CityBuilder.Scripts.Components.MapGenerator
{
    class MapGenerator : Component
    {
        private Tile[,] _tiles;

        public int MapSize;

        public MapGenerator(int mapSize)
        {
            MapSize = mapSize;
        }

        public override void Start()
        {
            _tiles = new Tile[MapSize, MapSize];

            FillList();
            PrintList();
        }

        public override void Update()
        {
            
        }

        private void FillList()
        {
            for (var x = 0; x < MapSize; x++)
            {
                for (var y = 0; y < MapSize; y++)
                {
                    _tiles[x, y] = new Tile($"Tile{x}_{y}");
                }
            }
        }

        private void PrintList()
        {
            for (var x = 0; x < MapSize; x++)
            {
                for (var y = 0; y < MapSize; y++)
                {
                    GlobalConsole.WriteLine(_tiles[x, y].ToString());
                }
            }
        }
    }
}
