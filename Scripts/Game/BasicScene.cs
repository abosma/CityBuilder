using System;
using CityBuilder.Scripts.Components;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Components.MapGenerator;
using CityBuilder.Scripts.Components.Positions;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Entities;
using SFML.System;

namespace CityBuilder.Scripts.Game
{
    class BasicScene
    {
        public BasicScene()
        {
            var Town = new Entity();
            var Town2 = new Entity();

            var TownTransform = Town.AddComponent(new Transform(10, 10));
            var TownCollider = Town.AddComponent(new Collider2D(32, 32));
            var TownRenderer = Town.AddComponent(new SpriteRenderer());

            var Town2Transform = Town2.AddComponent(new Transform(50, 50));
            var Town2Collider = Town2.AddComponent(new Collider2D(32, 32));
            var Town2Renderer = Town2.AddComponent(new SpriteRenderer());

            TownRenderer.SetSprite("\\Assets\\Textures\\Town.png");
            Town2Renderer.SetSprite("\\Assets\\Textures\\Town.png");

            TownTransform.Translate(25, 25, 0.1f);
            Town2Transform.Translate(25, 25, 0.1f);

            var MapEntity = new Entity();

            MapEntity.AddComponent(new MapGenerator(20));
        }
    }
}
