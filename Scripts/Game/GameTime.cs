using System;
using CityBuilder.Scripts.Global;
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
            var Window = WindowHandler.Initialize();
            var GUI = GUIHandler.Initialize();
            var Clock = new Clock();

            new BasicScene();

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear();

                WorldCollision.CheckCollision();
                World.UpdateEntities();
                GlobalConsole.DrawConsole();

                GUI.Draw();
                Window.Display();

                var DeltaClock = Clock.Restart();
                deltaTime = DeltaClock.AsSeconds();
            }
        }
    }
}
