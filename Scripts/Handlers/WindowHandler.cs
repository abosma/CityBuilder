using SFML.Graphics;
using SFML.Window;

namespace CityBuilder.Scripts.Handlers
{
    public class WindowHandler
    {
        private static RenderWindow _window;

        public static void Initialize()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "Test");

            _window.SetFramerateLimit(60);

            _window.Closed += Window_Closed;
        }

        private static void Window_Closed(object sender, System.EventArgs e)
        {
            _window.Close();
        }

        public static RenderWindow GetWindow()
        {
            if (_window == null)
            {
                return null;
            }

            var renderWindow = _window.IsOpen ? _window : null;
            return renderWindow;
        }
    }
}
