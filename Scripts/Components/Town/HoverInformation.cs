using System;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Components.Colliders;
using CityBuilder.Scripts.Global;
using SFML.Graphics;
using SFML.System;
using TGUI;

namespace CityBuilder.Scripts.Components.Town
{
    class HoverInformation : Component
    {
        private string _townName;
        private Collider _collider;
        private Text _text;

        public override void Start()
        {
            _townName = Entity.Name;

            _collider = Entity.GetComponent<Collider>();

            _collider.MouseEnter += ColliderOnMouseEnter;
            _collider.MouseOver += ColliderOnMouseOver;
            _collider.MouseExit += ColliderOnMouseExit;

            _text = DrawableHandler.CreateDrawableText("munro.ttf", 20, Color.Cyan, Text.Styles.Regular);
        }

        private void ColliderOnMouseEnter(object sender, EventArgs e)
        {
            var InformationText = $"Town: {_townName}";
            var MousePosition = WindowHandler.GetMousePositionRelativeToWindow();
            var TextPosition = new Vector2f(MousePosition.X + 20, MousePosition.Y);

            _text.DisplayedString = InformationText;
            _text.Position = TextPosition;

            DrawableHandler.AddDrawable(_text, 1);
        }

        private void ColliderOnMouseExit(object sender, EventArgs e)
        {
            DrawableHandler.RemoveDrawable(_text);
        }

        private void ColliderOnMouseOver(object sender, EventArgs e)
        {
            var MousePosition = WindowHandler.GetMousePositionRelativeToWindow();
            var TextPosition = new Vector2f(MousePosition.X + 20, MousePosition.Y);

            _text.Position = TextPosition;
        }

        public override void Update()
        {
            
        }
    }
}
