using System;
using System.IO;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Global;
using SFML.Graphics;
using Transform = CityBuilder.Scripts.Components.Positions.Transform;

namespace CityBuilder.Scripts.Components.Renderers
{
    class SpriteRenderer : Component
    {
        public Sprite _sprite;

        private Transform _transform;

        public override void Start()
        {
            _sprite = new Sprite();
            _transform = Entity.GetComponent<Transform>();
        }

        public override void Update()
        {
            _sprite.Position = _transform.GetPosition();

            try
            {
                WindowHandler.GetWindow().Draw(_sprite);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void SetSprite(Sprite sprite)
        {
            _sprite = sprite;
        }

        public void SetSprite(string textureLocation)
        {
            var Texture = new Texture(Directory.GetCurrentDirectory() + textureLocation);

            _sprite.Texture = Texture;
        }
    }
}
