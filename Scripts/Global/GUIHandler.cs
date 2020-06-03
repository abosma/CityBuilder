using SFML.Graphics;
using TGUI;

namespace CityBuilder.Scripts.Global
{
    public static class GUIHandler
    {
        private static Gui _gui;

        public static Gui Initialize()
        {
            var RenderWindow = WindowHandler.GetWindow();
            
            _gui = new Gui(RenderWindow);

            return _gui;
        }

        public static Gui GetGUI()
        {
            return _gui ?? Initialize();
        }
    }
}
