using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Components.Renderers;
using SFML.Graphics;

namespace CityBuilder.Scripts.Components.MapGenerator
{
    class TileControls : Component
    {
        private Collider _collider;
        private RectangleRenderer _rectangleRenderer;
        private Color _oldColor;

        public override void Start()
        {
            _collider = Entity.GetComponent<Collider>();
            _rectangleRenderer = Entity.GetComponent<RectangleRenderer>();
            _oldColor = _rectangleRenderer.GetColor();

            _collider.MouseEnter += _collider_MouseEnter;
            _collider.MouseExit += _collider_MouseExit;
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
