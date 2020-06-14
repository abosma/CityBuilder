using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Global;
using SFML.Graphics;

namespace CityBuilder.Scripts.Components.MapGenerator
{
    class MapGenerator : Component
    {
        private Entity[,] _tiles;

        public int MapSize;

        public MapGenerator(int mapSize)
        {
            MapSize = mapSize;
        }

        public override void Start()
        {
            _tiles = new Entity[MapSize, MapSize];

            FillList();
        }

        public override void Update()
        {
            
        }

        public void SetTileToEntity(int tileX, int tileY, Entity newEntity)
        {
            _tiles[tileX, tileY] = newEntity;
        }

        public void SetTileToEntity(Entity oldEntity, Entity newEntity)
        {
            for (var x = 0; x < MapSize; x++)
            {
                for (var y = 0; y < MapSize; y++)
                {
                    var TileEntity = _tiles[x, y];

                    if (TileEntity.Equals(oldEntity))
                    {
                        _tiles[x, y] = newEntity;
                    }
                }
            }
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
                    var ToAddTile = new Tile(x, y, 32 * x, 32 * y, $"Tile{x}_{y}");
                    var TileRenderer = ToAddTile.AddComponent(new RectangleRenderer(32, 32));
                    
                    TileRenderer.SetColor(Color.Green);

                    ToAddTile.AddComponent(new Collider(32, 32));
                    ToAddTile.AddComponent(new TileControls());

                    _tiles[x, y] = ToAddTile;
                }
            }
        }
    }
}
