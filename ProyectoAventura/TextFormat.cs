using System;

namespace TextFormat
{
    internal class TextFormat
    {
        public static void Format(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, string horizontalAlignment, string verticalAlignment)
        {
            string[] lines = text.Split('\n');

            int startY;
            int startX = Console.WindowWidth / 2;

            switch (verticalAlignment.ToLower())
            {
                case "top":
                    startY = 0;
                    break;
                case "center":
                    startY = Console.WindowHeight / 2 - lines.Length / 2;
                    break;
                case "bottom":
                    startY = Console.WindowHeight - lines.Length;
                    break;
                default:
                    startY = Console.WindowHeight / 2 - lines.Length / 2;
                    break;
            }

            foreach (string line in lines)
            {
                switch (horizontalAlignment.ToLower())
                {
                    case "left":
                        startX = Console.WindowWidth / 5;
                        break;
                    case "center":
                        startX = Console.WindowWidth / 2 - line.Length / 2;
                        break;
                    case "right":
                        startX = Console.WindowWidth - line.Length - Console.WindowWidth / 5;
                        break;
                    default:
                        startX = Console.WindowWidth / 2;
                        break;
                }

                Console.SetCursorPosition(startX, startY);

                Console.ForegroundColor = foregroundColor;
                Console.BackgroundColor = backgroundColor;

                Console.Write(line);

                Console.ResetColor();

                startY++;
            }
        }
    }
}
