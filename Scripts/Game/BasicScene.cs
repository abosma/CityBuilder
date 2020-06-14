using CityBuilder.Scripts.Components.Camera;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Components.MapGenerator;
using CityBuilder.Scripts.Components.Renderers;
using CityBuilder.Scripts.Components.Town;
using CityBuilder.Scripts.Entities;
using CityBuilder.Scripts.Global;
using SFML.Graphics;

namespace CityBuilder.Scripts.Game
{
    class BasicScene
    {
        public BasicScene()
        {
            InitializeMap();
            InitializeCamera();

            //var Town1 = new Entity(default, default, "Town 1");
            //var Town1Renderer = Town1.AddComponent(new RectangleRenderer(50, 50));
            //var Town1Collider = Town1.AddComponent(new Collider(50, 50));
            //var Town1HoverInformation = Town1.AddComponent(new HoverInformation());

            //var Town2 = new Entity(50, 50, "Town 2");
            //var Town2Renderer = Town2.AddComponent(new RectangleRenderer(50, 50));
            //var Town2Collider = Town2.AddComponent(new Collider(50, 50));
            //var Town2HoverInformation = Town2.AddComponent(new HoverInformation());
            //var Town2Input = Town2.AddComponent(new TownControls());

            //Town1Renderer.SetColor(Color.White);
            //Town2Renderer.SetColor(Color.Red);

            //World.AddEntity(Town1);
            //World.AddEntity(Town2);
        }

        private void InitializeCamera()
        {
            var CameraEntity = new Entity();
            var View = ViewHandler.CreateView(new FloatRect(0, 0, 800, 600));
            CameraEntity.AddComponent(new Camera(View));
            CameraEntity.AddComponent(new RTSCamera());

            World.AddEntity(CameraEntity);
        }

        private void InitializeMap()
        {
            var MapEntity = new Entity();
            var MapGenerator = MapEntity.AddComponent(new MapGenerator(10));
        }
    }
}
