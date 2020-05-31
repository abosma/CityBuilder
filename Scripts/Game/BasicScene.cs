using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Global;
using SFML.Graphics;

namespace CityBuilder.Scripts.Game
{
    class BasicScene
    {
        public BasicScene()
        {
            var Town1 = new Entity();
            var Town1Renderer = Town1.AddComponent(new RectangleRenderer(10, 10));
            var Town1Collider = Town1.AddComponent(new Collider(10, 10));
            
            Town1Renderer.SetColor(Color.White);
            
            Town1Collider.MouseEnter += (sender, args) => GlobalConsole.WriteLine("Mouse Enter Town1");
            Town1Collider.MouseExit += (sender, args) => GlobalConsole.WriteLine("Mouse Exit Town1");

            World.AddEntity(Town1);

            //Town1.Transform.Translate(25, 25, 0.5f);

            //var Town2 = new Entity(50, 50);
            //var Town2Renderer = Town2.AddComponent(new RectangleRenderer(10, 10));
            //var Town2Collider = Town2.AddComponent(new Collider(10, 10));

            //Town2Renderer.SetColor(Color.White);
            //Town2.Transform.Translate(25, 25, 0.5f);

            //Town1Collider.CollidedWithEntity += entity => GlobalConsole.WriteLine($"Collided with {entity.EntityId}");

            //var MapEntity = new Entity();
            //var MapGenerator = MapEntity.AddComponent(new MapGenerator(10));
        }
    }
}
