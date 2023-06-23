using System;
using System.Diagnostics;

public class PrintMenu
{
    public static void MainMenu()
    {
        Console.Clear();
        TextFormat.TextFormat.Format("----------Circuito Aventura ----------\n        SELECCIONE UNA OPCIÓN\n\n1 - Entrada Individual\n2 - Pasaporte Grupal\n3 - Mostrar Caja\n4 - Cerrar aplicación", ConsoleColor.Blue, ConsoleColor.Black, "left", "center");
    }

    public static void IndividualEntry()
    {
        Console.Clear();
        TextFormat.TextFormat.Format("Seleccionaste ENTRADA INDIVIDUAL", ConsoleColor.Blue, ConsoleColor.Black, "center", "top");
        TextFormat.TextFormat.Format("\nA continuación ingrese los datos, o '0' para finalizar el proceso", ConsoleColor.Blue, ConsoleColor.Black, "left", "top");
    }

    public static void PassportEntry()
    {
        Console.Clear();
        TextFormat.TextFormat.Format("Seleccionaste PASAPORTE GRUPAL", ConsoleColor.Blue, ConsoleColor.Black, "center", "top");
        TextFormat.TextFormat.Format("\nA continuación ingrese la cantidad de integrantes del grupo, o '0' para finalizar el proceso", ConsoleColor.Blue, ConsoleColor.Black, "left", "top");

    }

    public static class TextFormatting
    {
        public static void Format(string text, string horizontalAlignment, string verticalAlignment)
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
                Console.WriteLine(line);

                startY++;
            }
        }
    }
}
