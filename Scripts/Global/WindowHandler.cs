using SFML.Graphics;
using SFML.Window;

namespace CityBuilder.Scripts.Global
{
    public class WindowHandler
    {
        private static RenderWindow _window;

        public static RenderWindow Initialize()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "Test");

            _window.SetFramerateLimit(60);

            _window.Closed += Window_Closed;

            return _window;
        }

        private static void Window_Closed(object sender, System.EventArgs e)
        {
            _window.Close();
        }

        public static RenderWindow GetWindow()
        {
            return _window ?? Initialize();
        }
    }
}
