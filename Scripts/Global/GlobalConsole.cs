using System;
using System.Collections.Generic;
using System.IO;
using SFML.Graphics;
using SFML.System;

namespace CityBuilder.Scripts.Global
{
    public static class GlobalConsole
    {
        private static Text _text;
        private static List<string> _toDisplayStringList = new List<string>();

        static GlobalConsole()
        {
            _text = new Text
            {
                Font = new Font(Directory.GetCurrentDirectory() + "\\Assets\\Fonts\\Ubuntu-Regular.ttf"),
                CharacterSize = 12,
                FillColor = Color.White,
                Style = Text.Styles.Regular,
                Position = new Vector2f(0, 500)
            };
        }

        public static void Write(string toWriteText)
        {
            if (_toDisplayStringList.Count < 6)
            {
                _toDisplayStringList.Add(toWriteText);
            }
            else
            {
                _toDisplayStringList.RemoveAt(0);
                _toDisplayStringList.Add(toWriteText);
            }
        }

        public static void WriteLine(string toWriteText)
        {
            if (_toDisplayStringList.Count < 6)
            {
                _toDisplayStringList.Add($"\n{toWriteText}");
            }
            else
            {
                _toDisplayStringList.RemoveAt(0);
                _toDisplayStringList.Add($"\n{toWriteText}");
            }
        }

        public static void DrawConsole()
        {
            var ToDisplayString = string.Empty;

            for (var i = 0; i < _toDisplayStringList.Count; i++)
            {
                ToDisplayString += _toDisplayStringList[i];
            }

            _text.DisplayedString = ToDisplayString;

            WindowHandler.GetWindow().Draw(_text);
        }
    }
}
