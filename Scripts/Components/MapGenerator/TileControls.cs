using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Components.Town;
using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Global;
using SFML.Graphics;
using SFML.Window;

namespace CityBuilder.Scripts.Components.MapGenerator
{
    class TileControls : Component
    {
        private Collider _collider;
        private RectangleRenderer _rectangleRenderer;
        private Color _oldColor;
        private MapGenerator _mapGenerator;
        private Tile _tile;

        public override void Start()
        {
            _collider = Entity.GetComponent<Collider>();
            _rectangleRenderer = Entity.GetComponent<RectangleRenderer>();
            _mapGenerator = World.GetEntity("MapGenerator").GetComponent<MapGenerator>();
            _tile = (Tile) Entity;
            _oldColor = _rectangleRenderer.GetColor();

            _collider.MouseEnter += _collider_MouseEnter;
            _collider.MouseOver += _collider_MouseOver;
            _collider.MouseExit += _collider_MouseExit;
        }

        private void _collider_MouseOver(object sender, EventArgs e)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                var xPos = (int)Entity.Transform.Position.X;
                var yPos = (int)Entity.Transform.Position.Y;

                var Town2 = new Entity(xPos, yPos, "Town 2");
                var Town2Renderer = Town2.AddComponent(new RectangleRenderer(32, 32));
                var Town2Collider = Town2.AddComponent(new Collider(32, 32));
                var Town2HoverInformation = Town2.AddComponent(new HoverInformation());
                var Town2Input = Town2.AddComponent(new TownControls());

                _mapGenerator.SetTileToEntity(_tile, Town2);
                Entity.Destroy();
            }
        }

        private void _collider_MouseExit(object sender, EventArgs e)
        {
            _rectangleRenderer.SetColor(_oldColor);
        }

        private void _collider_MouseEnter(object sender, EventArgs e)
        {
            _rectangleRenderer.SetColor(Color.Red);
        }

        public override void Update()
        {
            
        }
    }
}
