using System.IO;
using SFML.Graphics;
using TGUI;

namespace CityBuilder.Scripts.Global
{
    public static class GUIHandler
    {
        private static Gui _gui;
        private static readonly string FontFolder = Directory.GetCurrentDirectory() + "\\Assets\\Fonts\\";

        public static Gui Initialize()
        {
            var RenderWindow = WindowHandler.GetWindow();

            _gui = new Gui(RenderWindow)
            {
                Font = new Font(FontFolder + "munro.ttf"),
                TextSize = 10
            };

            return _gui;
        }

        public static Gui GetGUI()
        {
            return _gui ?? Initialize();
        }
    }
}
