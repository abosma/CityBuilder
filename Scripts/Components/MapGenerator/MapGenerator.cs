using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Colliders;
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
                    
                    var TileRenderer = ToAddTile.AddComponent(new RectangleRenderer(32, 32));
                    TileRenderer.SetColor(Color.Green);

                    ToAddTile.Transform.SetPosition(32 * x, 32 * y);

                    ToAddTile.AddComponent(new Collider(32, 32));
                    ToAddTile.AddComponent(new TileControls());

                    World.AddEntity(ToAddTile);

                    _tiles[x, y] = ToAddTile;
                }
            }
        }
    }
}
