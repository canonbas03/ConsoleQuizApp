using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net; // for WebUtility.HtmlDecode
using System.IO;
using System.Linq;

class Program
{
    // Predefined ConsoleColor -> approximate RGB values (common mapping)
    static readonly Dictionary<ConsoleColor, (int r, int g, int b)> ConsoleRgb = new()
    {
        { ConsoleColor.Black, (0,0,0) },
        { ConsoleColor.DarkBlue, (0,0,139) },
        { ConsoleColor.DarkGreen, (0,100,0) },
        { ConsoleColor.DarkCyan, (0,128,128) },
        { ConsoleColor.DarkRed, (139,0,0) },
        { ConsoleColor.DarkMagenta, (139,0,139) },
        { ConsoleColor.DarkYellow, (169,169,0) },
        { ConsoleColor.Gray, (192,192,192) },
        { ConsoleColor.DarkGray, (128,128,128) },
        { ConsoleColor.Blue, (0,0,255) },
        { ConsoleColor.Green, (0,255,0) },
        { ConsoleColor.Cyan, (0,255,255) },
        { ConsoleColor.Red, (255,0,0) },
        { ConsoleColor.Magenta, (255,0,255) },
        { ConsoleColor.Yellow, (255,255,0) },
        { ConsoleColor.White, (255,255,255) }
    };

    static void Main(string[] args)
    {
        // Ensure utf-8 output (helps with special chars)
        Console.OutputEncoding = Encoding.UTF8;
        Thread.Sleep(2000);
        Console.Beep(500,200);

        // Option A: put your HTML string here (for quick test)
        string html = null;

        // Option B: read from file "art.html" if exists
        string path = "art2.html";
        if (File.Exists(path))
        {
            html = File.ReadAllText(path, Encoding.UTF8);
        }

        // If you didn't provide file, paste your long HTML string into html variable (or pass via args)
        if (string.IsNullOrEmpty(html))
        {
            Console.WriteLine("No art.html found. Paste your HTML into the program's html variable or create an art.html file.");
            return;
        }

        // Normalize: replace CRLF with \n for consistent processing
        html = html.Replace("\r\n", "\n").Replace("\r", "\n");

        // A regex that matches <span ...>text</span>, <br>, or plain text chunks
        var pattern = @"(?<span><span\b[^>]*style\s*=\s*""(?<style>[^""]*)""[^>]*>(?<inner>.*?)<\/span>)|(?<br>\<br\s*\/?\>)|(?<text>[^<]+)";
        var rx = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);

        // Walk matches in order
        foreach (Match m in rx.Matches(html))
        {
            if (m.Groups["br"].Success)
            {
                Console.ResetColor();
                //Console.WriteLine();
                continue;
            }

            if (m.Groups["span"].Success)
            {
                string style = m.Groups["style"].Value;
                string inner = m.Groups["inner"].Value;

                // decode HTML entities like &#160;
                inner = WebUtility.HtmlDecode(inner);

                // parse color/background-color from style
                var fgHex = ExtractHexColor(style, "color");
                var bgHex = ExtractHexColor(style, "background-color");

                // Map hex to ConsoleColor
                var fg = fgHex != null ? HexToConsoleColor(fgHex) : (ConsoleColor?)null;
                var bg = bgHex != null ? HexToConsoleColor(bgHex) : (ConsoleColor?)null;

                if (fg.HasValue) Console.ForegroundColor = fg.Value;
                if (bg.HasValue) Console.BackgroundColor = bg.Value;

                // Write the inner text exactly (preserves spaces)
                Console.Write(inner);

                // Reset colors after each span to avoid bleeding
                Console.ResetColor();
                continue;
            }

            if (m.Groups["text"].Success)
            {
                string txt = WebUtility.HtmlDecode(m.Groups["text"].Value);
                // plain text may contain newlines
                var parts = txt.Split('\n');
                for (int i = 0; i < parts.Length; i++)
                {
                    Console.Write(parts[i]);
                    if (i < parts.Length - 1) Console.WriteLine();
                }
            }
        }

        // final reset
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("-- done --");
    }

    // Extracts a hex color (#rrggbb or #rgb) from style value for the given property name
    static string ExtractHexColor(string style, string propName)
    {
        // simple regex for property: color:#rrggbb or color: #abc; and also allows background-color
        var rx = new Regex(propName + @"\s*:\s*(#([0-9a-fA-F]{3}|[0-9a-fA-F]{6}))", RegexOptions.IgnoreCase);
        var m = rx.Match(style);
        if (!m.Success) return null;
        string hex = m.Groups[1].Value;
        // expand shorthand #abc -> #aabbcc
        if (hex.Length == 4)
        {
            char r = hex[1], g = hex[2], b = hex[3];
            hex = $"#{r}{r}{g}{g}{b}{b}";
        }
        return hex.ToLowerInvariant();
    }

    // Find nearest ConsoleColor to a hex string like "#aabbcc"
    static ConsoleColor HexToConsoleColor(string hex)
    {
        // parse hex
        int r = Convert.ToInt32(hex.Substring(1, 2), 16);
        int g = Convert.ToInt32(hex.Substring(3, 2), 16);
        int b = Convert.ToInt32(hex.Substring(5, 2), 16);

        double bestDist = double.MaxValue;
        ConsoleColor best = ConsoleColor.White;

        foreach (var kv in ConsoleRgb)
        {
            var c = kv.Value;
            double dist = ColorDistance(r, g, b, c.r, c.g, c.b);
            if (dist < bestDist)
            {
                bestDist = dist;
                best = kv.Key;
            }
        }
        return best;
    }

    static double ColorDistance(int r1, int g1, int b1, int r2, int g2, int b2)
    {
        double dr = r1 - r2;
        double dg = g1 - g2;
        double db = b1 - b2;
        return dr * dr + dg * dg + db * db; // squared Euclidean distance
    }
}
