using System;
using System.Collections.Generic;
using SFML.Window;
using static SFML.Window.Keyboard;
using static SFML.Window.Mouse;

namespace CityBuilder.Scripts.Global
{
    static class InputHandler
    {
        public static event EventHandler MouseLeftDown;
        public static event EventHandler MouseLeftUp;
        private static bool _leftMouseDown = false;

        public static event EventHandler MouseRightDown;
        public static event EventHandler MouseRightUp;
        private static bool _rightMouseDown = false;

        public static void UpdateInputs()
        {
            var LeftButtonPressed = Mouse.IsButtonPressed(Button.Left);
            var RightButtonPressed = Mouse.IsButtonPressed(Button.Right);


            if (!_leftMouseDown && !LeftButtonPressed)
            {
                _leftMouseDown = false;
            }

            if (!_rightMouseDown && !RightButtonPressed)
            {
                _rightMouseDown = false;
            }

            if (!_leftMouseDown && LeftButtonPressed)
            {
                _leftMouseDown = true;

                OnMouseLeftDown();
            }

            if (_leftMouseDown && !LeftButtonPressed)
            {
                _leftMouseDown = false;

                OnMouseLeftUp();
            }

            if (!_rightMouseDown && RightButtonPressed)
            {
                _rightMouseDown = true;
                
                OnMouseRightDown();
            }

            if (_rightMouseDown && !RightButtonPressed)
            {
                _rightMouseDown = false;

                OnMouseRightUp();
            }
        }

        private static void OnMouseLeftDown()
        {
            MouseLeftDown?.Invoke(null, EventArgs.Empty);
        }

        private static void OnMouseLeftUp()
        {
            MouseLeftUp?.Invoke(null, EventArgs.Empty);
        }

        private static void OnMouseRightDown()
        {
            MouseRightDown?.Invoke(null, EventArgs.Empty);
        }

        private static void OnMouseRightUp()
        {
            MouseRightUp?.Invoke(null, EventArgs.Empty);
        }
    }
}
