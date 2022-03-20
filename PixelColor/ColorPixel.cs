using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace PixelColor
{
    static class ColorPixel
    {
        private static Dictionary<string, string> TableHexColor = new Dictionary<string, string>()
        {
            { "#CD5C5C", "IndianRed" },
            { "#F08080", "LightCoral" },
            { "#FA8072", "Salmon" },
            { "#E9967A", "DarkSalmon" },
            { "#FFA07A", "LightSalmon" },
            { "#DC143C", "Crimson" },
            { "#FF0000", "Red" },
            { "#B22222", "FireBrick" },
            { "#8B0000", "DarkRed" },
            { "#FFC0CB", "Pink" },
            { "#FFB6C1", "LightPink" },
            { "#FF69B4", "HotPink" },
            { "#FF1493", "DeepPink" },
            { "#C71585", "MediumVioletRed" },
            { "#DB7093", "PaleVioletRed" },
            { "#FF7F50", "Coral" },
            { "#FF6347", "Tomato" },
            { "#FF4500", "OrangeRed" },
            { "#FF8C00", "DarkOrange" },
            { "#FFA500", "Orange" },
            { "#FFD700", "Gold" },
            { "#FFFF00", "Yellow" },
            { "#FFFFE0", "LightYellow" },
            { "#FFFACD", "LemonChiffon" },
            { "#FAFAD2", "LightGoldenrodYellow" },
            { "#FFEFD5", "PapayaWhip" },
            { "#FFE4B5", "Moccasin" },
            { "#FFDAB9", "PeachPuff" },
            { "#EEE8AA", "PaleGoldenrod" },
            { "#F0E68C", "Khaki" },
            { "#BDB76B", "DarkKhaki" },
            { "#E6E6FA", "Lavender" },
            { "#D8BFD8", "Thistle" },
            { "#DDA0DD", "Plum" },
            { "#EE82EE", "Violet" },
            { "#DA70D6", "Orchid" },
            { "#FF00FF", "Magenta(Fuchsia)" },
            { "#BA55D3", "MediumOrchid" },
            { "#9370DB", "MediumPurple" },
            { "#8A2BE2", "BlueViolet" },
            { "#9400D3", "DarkViolet" },
            { "#9932CC", "DarkOrchid" },
            { "#8B008B", "DarkMagenta" },
            { "#800080", "Purple" },
            { "#4B0082", "Indigo" },
            { "#6A5ACD", "SlateBlue" },
            { "#483D8B", "DarkSlateBlue" },
            { "#FFF8DC", "Cornsilk" },
            { "#FFEBCD", "BlanchedAlmond" },
            { "#FFE4C4", "Bisque" },
            { "#FFDEAD", "NavajoWhite" },
            { "#F5DEB3", "Wheat" },
            { "#DEB887", "BurlyWood" },
            { "#D2B48C", "Tan" },
            { "#BC8F8F", "RosyBrown" },
            { "#F4A460", "SandyBrown" },
            { "#DAA520", "Goldenrod" },
            { "#B8860B", "DarkGoldenRod" },
            { "#CD853F", "Peru" },
            { "#D2691E", "Chocolate" },
            { "#8B4513", "SaddleBrown" },
            { "#A0522D", "Sienna" },
            { "#A52A2A", "Brown" },
            { "#800000", "Maroon" },
            { "#000000", "Black" },
            { "#808080", "Gray" },
            { "#C0C0C0", "Silver" },
            { "#FFFFFF", "White" },
            { "#808000", "Olive" },
            { "#00FF00", "Lime" },
            { "#008000", "Green" },
            { "#00FFFF", "Aqua(Cyan)" },
            { "#008080", "Teal" },
            { "#0000FF", "Blue" },
            { "#000080", "Navy" },
            { "#ADFF2F", "GreenYellow" },
            { "#7FFF00", "Chartreuse" },
            { "#7CFC00", "LawnGreen" },
            { "#32CD32", "LimeGreen" },
            { "#98FB98", "PaleGreen" },
            { "#90EE90", "LightGreen" },
            { "#00FA9A", "MediumSpringGreen" },
            { "#00FF7F", "SpringGreen" },
            { "#3CB371", "MediumSeaGreen" },
            { "#2E8B57", "SeaGreen" },
            { "#228B22", "ForestGreen" },
            { "#006400", "DarkGreen" },
            { "#9ACD32", "YellowGreen" },
            { "#6B8E23", "OliveDrab" },
            { "#556B2F", "DarkOliveGreen" },
            { "#66CDAA", "MediumAquamarine" },
            { "#8FBC8F", "DarkSeaGreen" },
            { "#20B2AA", "LightSeaGreen" },
            { "#008B8B", "DarkCyan" },
            { "#E0FFFF", "LightCyan" },
            { "#AFEEEE", "PaleTurquoise" },
            { "#7FFFD4", "Aquamarine" },
            { "#40E0D0", "Turquoise" },
            { "#48D1CC", "MediumTurquoise" },
            { "#00CED1", "DarkTurquoise" },
            { "#5F9EA0", "CadetBlue" },
            { "#4682B4", "SteelBlue" },
            { "#B0C4DE", "LightSteelBlue" },
            { "#B0E0E6", "PowderBlue" },
            { "#ADD8E6", "LightBlue" },
            { "#87CEEB", "SkyBlue" },
            { "#87CEFA", "LightSkyBlue" },
            { "#00BFFF", "DeepSkyBlue" },
            { "#1E90FF", "DodgerBlue" },
            { "#6495ED", "CornflowerBlue" },
            { "#7B68EE", "MediumSlateBlue" },
            { "#4169E1", "RoyalBlue" },
            { "#0000CD", "MediumBlue" },
            { "#00008B", "DarkBlue" },
            { "#191970", "MidnightBlue" },
            { "#FFFAFA", "Snow" },
            { "#F0FFF0", "Honeydew" },
            { "#F5FFFA", "MintCream" },
            { "#F0FFFF", "Azure" },
            { "#F0F8FF", "AliceBlue" },
            { "#F8F8FF", "GhostWhite" },
            { "#F5F5F5", "WhiteSmoke" },
            { "#FFF5EE", "Seashell" },
            { "#F5F5DC", "Beige" },
            { "#FDF5E6", "OldLace" },
            { "#FFFAF0", "FloralWhite" },
            { "#FFFFF0", "Ivory" },
            { "#FAEBD7", "AntiqueWhite" },
            { "#FAF0E6", "Linen" },
            { "#FFF0F5", "LavenderBlush" },
            { "#FFE4E1", "MistyRose" },
            { "#DCDCDC", "Gainsboro" },
            { "#D3D3D3", "LightGrey" },
            { "#A9A9A9", "DarkGray" },
            { "#696969", "DimGray" },
            { "#778899", "LightSlateGray" },
            { "#708090", "SlateGray" },
            { "#2F4F4F", "DarkSlateGray" }
        };

        public static void AddColors(string fileName)
        {
            if (!File.Exists(fileName)) return;
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] str = sr.ReadLine().Split();
                    if (str.Length > 1 && str[0].Length == 7 && str[0][0] == '#')
                    {
                        TableHexColor[str[0]] = str[1];
                    }
                }
            }
        }

        public static uint ColorToDec(Color color)
        {
            return (uint)(color.R << 16 | color.G << 8 | color.B);
        }

        public static int ColorToInt(Color color)
        {
            return color.A << 24 | color.R << 16 | color.G << 8 | color.B;
        }

        public static string GetNameByHex(string hex)
        {
            return TableHexColor.ContainsKey(hex) ? TableHexColor[hex] : "NoName";
        }

        public static string ColorToHex(Color color)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder("#", 7);
            if (color.R == 0) result.Append("00"); else result.AppendFormat("{0:X}", color.R);
            if (color.G == 0) result.Append("00"); else result.AppendFormat("{0:X}", color.G);
            if (color.B == 0) result.Append("00"); else result.AppendFormat("{0:X}", color.B);
            return result.ToString();
        }

        public static Color GetColor(int x, int y)
        {
            return GetColor(new Point(x, y));
        }

        public static Color GetColor(Point position)
        {
            try
            {
                using (Bitmap pixel = new Bitmap(1, 1))
                {
                    using (Graphics g = Graphics.FromImage(pixel))
                    {
                        g.CopyFromScreen(position, new Point(0, 0), pixel.Size);
                    }
                    return pixel.GetPixel(0, 0);
                }
            }
            catch (Exception) { }
            return new Color();
        }
    }
}
