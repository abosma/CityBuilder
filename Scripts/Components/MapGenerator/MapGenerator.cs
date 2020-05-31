using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Global;
using SFML.Graphics;

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
            
        }

        public override void Update()
        {
            
        }

        public void PrintTileList()
        {
            for (var x = 0; x < MapSize; x++)
            {
                for (var y = 0; y < MapSize; y++)
                {
                    GlobalConsole.WriteLine(_tiles[x, y].ToString());
                }
            }
        }

        private void FillList()
        {
            for (var x = 0; x < MapSize; x++)
            {
                for (var y = 0; y < MapSize; y++)
                {
                    var ToAddTile = new Tile($"Tile{x}_{y}");
                    ToAddTile.Transform.SetPosition(32 * x, 32 * y);

                    var TileRenderer = ToAddTile.AddComponent(new SpriteRenderer());
                    TileRenderer.SetSprite("\\Assets\\Textures\\Town.png");

                    _tiles[x, y] = ToAddTile;
                }
            }
        }
    }
}
