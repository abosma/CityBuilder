using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityBuilder.Scripts.Components.Base;
using CityBuilder.Scripts.Game;
using CityBuilder.Scripts.Global;
using SFML.Graphics;
using SFML.System;

namespace CityBuilder.Scripts.Components.Camera
{
    class RTSCamera : Component
    {
        private static float _scrollSpeed = 500;
        private static float _zoomSpeed = 5;
        private static int _scrollWidth = 30;
        private static Camera _camera;

        public override void Start()
        {
            _camera = Entity.GetComponent<Camera>();
        }

        public override void Update()
        {
            var Window = WindowHandler.GetWindow();
            var MousePosition = SFML.Window.Mouse.GetPosition(Window);
            var ViewSize = Window.Size;

            Window.MouseWheelScrolled += RTSCamera_MouseWheelScrolled;

            if (MousePosition.X >= 0 && MousePosition.X < _scrollWidth)
            {
                Entity.Transform.Position.X -= _scrollSpeed * GameTime.deltaTime;
            }
            else if (MousePosition.X <= ViewSize.X && MousePosition.X > ViewSize.X - _scrollWidth)
            {
                Entity.Transform.Position.X += _scrollSpeed * GameTime.deltaTime;
            }

            if (MousePosition.Y >= 0 && MousePosition.Y < _scrollWidth)
            {
                Entity.Transform.Position.Y -= _scrollSpeed * GameTime.deltaTime;
            }
            else if (MousePosition.Y <= ViewSize.Y && MousePosition.Y > ViewSize.Y - _scrollWidth)
            {
                Entity.Transform.Position.Y += _scrollSpeed * GameTime.deltaTime;
            }
        }

        private void RTSCamera_MouseWheelScrolled(object sender, SFML.Window.MouseWheelScrollEventArgs e)
        {
            var ViewSize = _camera.GetSize();
            
            var newSizeX = ViewSize.X - (e.Delta * GameTime.deltaTime) * _zoomSpeed;
            var newSizeY = ViewSize.Y - (e.Delta * GameTime.deltaTime) * _zoomSpeed;

            _camera.SetSize(newSizeX, newSizeY);
            ForceAspectRatio();
        }

        //Copied from https://github.com/SFML/SFML/wiki/Source%3A-Letterbox-effect-using-a-view
        private void ForceAspectRatio()
        {
            var ViewSize = _camera.GetSize();
            var Window = WindowHandler.GetWindow().Size;

            var WindowRatio = Window.X / (float)Window.Y;
            var ViewRatio = ViewSize.X / (float)ViewSize.Y;

            float SizeX = 1;
            float SizeY = 1;
            float PosX = 0;
            float PosY = 0;

            var HorizontalSpacing = !(WindowRatio < ViewRatio);

            if (HorizontalSpacing)
            {
                SizeX = ViewRatio / WindowRatio;
                PosX = (1 - SizeX) / 2f;
            }
            else
            {
                SizeY = WindowRatio / ViewRatio;
                PosY = (1 - SizeY) / 2f;
            }

            _camera.CameraView.Viewport = new FloatRect(PosX, PosY, SizeX, SizeY);
        }
    }
}
