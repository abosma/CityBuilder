using System;
using System.Collections.Generic;
using System.IO;
using SFML.Graphics;
using SFML.System;
using TGUI;

namespace CityBuilder.Scripts.Global
{
    public static class GlobalConsole
    {
        private static TextBox _textBox;
        private static List<string> _toDisplayStringList = new List<string>();

        static GlobalConsole()
        {
            _textBox = new TextBox
            {
                PositionLayout = new Layout2d(new Layout(0), new Layout("(&.size - size)"))
            };

            GUIHandler.GetGUI().Add(_textBox);
        }

        public static void Write(string toWriteText)
        {
            _toDisplayStringList.Add(toWriteText);
        }

        public static void WriteLine(string toWriteText)
        {
            _toDisplayStringList.Add($"\n{toWriteText}");
        }

        public static void DrawConsole()
        {
            var ToDisplayString = string.Empty;

            for (var i = 0; i < _toDisplayStringList.Count; i++)
            {
                ToDisplayString += _toDisplayStringList[i];
            }

            _textBox.Text = ToDisplayString;
        }
    }
}
