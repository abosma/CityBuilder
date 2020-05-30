using System;
using CityBuilder.Scripts.Handlers;
using SFML.System;

namespace CityBuilder.Scripts.Game
{
    class GameTime
    {
        public static float deltaTime = 0.0f;

        public GameTime()
        {
            GameLoop();
        }

        private static void GameLoop()
        {
            WindowHandler.Initialize();

            new BasicScene();

            var Window = WindowHandler.GetWindow();
            var Clock = new Clock();

            var deltaClock = Clock.Restart();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear();

                World.UpdateEntities();

                Window.Display();

                deltaClock = Clock.Restart();
                deltaTime = deltaClock.AsSeconds();
            }
        }
    }
}
