using SFML.Graphics;

namespace CityBuilder.Scripts.Global
{
    public static class ViewHandler
    {
        public static View CreateView(FloatRect viewRect)
        {
            var View = new View(viewRect);

            return View;
        }
    }
}
