using System.Collections.Generic;
using System.IO;
using System.Linq;
using SFML.Graphics;
using SFML.System;

namespace CityBuilder.Scripts.Global
{
    public static class DrawableHandler
    {
        private static readonly string FontFolder = Directory.GetCurrentDirectory() + "\\Assets\\Fonts\\";
        private static readonly List<DrawableOrder> Drawables = new List<DrawableOrder>();
        private static readonly RenderWindow Window;

        static DrawableHandler()
        {
            Window = WindowHandler.GetWindow();
        }

        public static void AddDrawable(DrawableOrder drawableOrder)
        {
            Drawables.Add(drawableOrder);
        }

        public static void AddDrawable(Drawable drawable, int drawOrder)
        {
            var DrawableOrder = new DrawableOrder(drawable, drawOrder);

            Drawables.Add(DrawableOrder);
        }

        public static void RemoveDrawable(Drawable drawable)
        {
            for (int i = 0; i < Drawables.Count; i++)
            {
                var ListDrawable = Drawables[i];

                if (ListDrawable.Drawable.Equals(drawable))
                {
                    Drawables.Remove(Drawables[i]);
                    break;
                }
            }
        }

        public static void Draw()
        {
            var OrderedList = Drawables.OrderBy(x => x.Order).ToList();

            for (int i = 0; i < OrderedList.Count; i++)
            {
                Window.Draw(OrderedList[i].Drawable);
            }
        }

        public static Text CreateDrawableText(string font, uint fontSize, Color fontColor, Text.Styles fontStyle)
        {
            var Text = new Text
            {
                Font = new Font(FontFolder + font),
                CharacterSize = fontSize,
                FillColor = fontColor,
                Style = fontStyle
            };

            return Text;
        }

        public static RectangleShape CreateDrawableRectangleShape(float width = 0, float height = 0)
        {
            return new RectangleShape(new Vector2f(width, height));
        }
    }
}
