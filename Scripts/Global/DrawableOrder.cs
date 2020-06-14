using SFML.Graphics;

namespace CityBuilder.Scripts.Global
{
    public class DrawableOrder
    {
        public Drawable Drawable { get; set; }
        public int Order { get; set; }

        public DrawableOrder(Drawable drawable, int order)
        {
            Drawable = drawable;
            Order = order;
        }

        public override string ToString()
        {
            return $"Drawable: {Drawable}, Draw Order: {Order}";
        }
    }
}
