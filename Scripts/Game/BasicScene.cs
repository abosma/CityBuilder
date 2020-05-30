using System;
using CityBuilder.Scripts.Components;
using CityBuilder.Scripts.Components.Colliders;
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
            var town = new Town();
            var town2 = new Town();

            var TownTransform = town.AddComponent(new Transform(10, 10));
            var TownCollider = town.AddComponent(new Collider2D(32, 32));
            var TownRenderer = town.AddComponent(new SpriteRenderer());

            var Town2Transform = town2.AddComponent(new Transform(50, 50));
            var Town2Collider = town2.AddComponent(new Collider2D(32, 32));
            var Town2Renderer = town2.AddComponent(new SpriteRenderer());

            TownRenderer.SetSprite("\\Assets\\Textures\\Town.png");
            Town2Renderer.SetSprite("\\Assets\\Textures\\Town.png");

            TownTransform.Translate(25, 25, 0.1f);
            Town2Transform.Translate(25, 25, 0.1f);

            TownCollider.AddEntityToCollisionList(town2);
        }
    }
}
