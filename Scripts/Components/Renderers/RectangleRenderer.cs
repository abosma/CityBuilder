using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Global;
using SFML.Graphics;
using SFML.System;

namespace CityBuilder.Scripts.Components.Renderers
{
    class RectangleRenderer : Component
    {
        public RectangleShape Rectangle;

        public RectangleRenderer(float width = 0, float height = 0)
        {
            Rectangle = DrawableHandler.CreateDrawableRectangleShape(width, height);
        }

        public override void Start()
        {
            DrawableHandler.AddDrawable(Rectangle, 0);
        }

        public override void Update()
        {
            Rectangle.Position = Entity.Transform.GetPosition();
        }

        public void SetColor(Color color)
        {
            Rectangle.FillColor = color;
        }

        public Color GetColor()
        {
            return Rectangle.FillColor;
        }

        public void SetSize(Vector2f newSize)
        {
            Rectangle.Size = newSize;
        }

        public void SetSize(float x, float y)
        {
            Rectangle.Size = new Vector2f(x, y);
        }
    }
}
