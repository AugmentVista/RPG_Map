using System.Reflection.PortableExecutable;

namespace RPG_Map
{
    internal class Program
    {
        static public char character;
        static void Main(string[] args)
        {
            DisplayMap(1);
            DrawBorder(1); 
            Console.ReadKey(true);
            Console.Clear();
            DisplayMap(2);
            DrawBorder(2);
            Console.ReadKey(true);
            Console.Clear();
            DisplayMap(3);
            DrawBorder(3);
            Console.ReadKey(true);
            Console.Clear();
            DisplayMap(4);
            DrawBorder(4);
            Console.ReadKey(true);
            Console.Clear();
            DisplayMap(5);
            DrawBorder(5);
            Console.ReadKey(true);
            Console.Clear();
            DisplayMap(6);
            DrawBorder(6);
            Console.ReadKey(true);
        }
        static char[,] map = new char[,] // dimensions defined by following data:
        {
        {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
        {'^','^','`','`','*','*','*','`','`','`','`','`','`','`','`','*','*','*','`','`','`','`','~','~','~','`','`','`','`','`'},
        {'^','`','`','`','`','*','`','`','`','`','`','`','`','`','*','`','`','`','*','`','`','`','`','~','`','`','`','`','`','`'},
        {'^','`','`','`','`','`','~','`','`','`','`','`','`','`','*','`','`','*','*','`','`','`','`','`','`','`','`','`','*','`'},
        {'^','`','`','`','~','~','~','`','`','`','`','`','`','`','*','`','`','`','`','`','`','`','`','`','`','`','`','`','*','`'},
        {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','*','`'},
        {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','^','^','`','`','`','`','`','`','~','^','^','^','`','`','`'},
        {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','^','`','`','`','`','`','`','~','~','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','~','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},

        };

        static string[] border = new string[]
        {
          "╔","╗","╝","╚", "║","═"
        };
        

        static void DrawBorder(int scale)
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int HorizontalWall = 1;
            int VerticalWall = 1;
            int totalWidth = mapWidth * scale;
            int totalHeight = mapHeight * scale;

            foreach (string ASCll in border)
            {
                switch (ASCll)
                {
                    case "╔":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "╗":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "╝":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "╚":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "║":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case "═":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(border[0]);
            Console.SetCursorPosition(totalWidth, 0);
            Console.Write(border[1]);

                if (HorizontalWall >= totalWidth)
                {
                    HorizontalWall = totalWidth;
                }
                if (VerticalWall >= totalHeight) 
                { 
                    VerticalWall = totalHeight; 
                }
                for (int i = 0; i < totalWidth; i++)
                {
                    Console.SetCursorPosition(HorizontalWall, 0); // ceiling
                    Console.Write(border[5]);
                    Console.SetCursorPosition(HorizontalWall, totalHeight); // floor
                    Console.Write(border[5]);
                    HorizontalWall++;
                }
                for (int j = 0; j < totalHeight; j++)
                {
                    Console.SetCursorPosition(0, VerticalWall); // lefthand wall 
                    Console.Write(border[4]);
                    Console.SetCursorPosition(totalWidth, VerticalWall); // righthand wall 
                    Console.Write(border[4]);
                    VerticalWall++;
                }
            Console.WriteLine(); // this is needed to prevent the map from overlapping with the border
            Console.SetCursorPosition(totalWidth, 0);
            Console.Write(border[1]);
            Console.SetCursorPosition(0, totalHeight);
            Console.Write(border[3]);
            Console.SetCursorPosition(totalWidth, totalHeight);
            Console.Write(border[2]);
        }  
        

        static void DisplayMap(int scale)
        {
            Console.Write(" "); // add a space before the first row
            for (int Y = 0; Y < map.GetLength(0); Y++)
            {

                for (int columnScale = 0; columnScale < scale; columnScale++)
                {
                    for (int X = 0; X < map.GetLength(1); X++)
                    {
                        char character = map[Y, X];
                        for (int rowScale = 0; rowScale < scale; rowScale++)
                        {
                            switch (character) 
                            {
                                case '`':
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                case '^':
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case '*':
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case '~':
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.Write(character);
                        }
                    }
                    Console.WriteLine();
                    Console.Write(" "); // adds a space before the start of each row after the first
                }
                Console.ResetColor();
            }
            Console.WriteLine("     Map legend:  ");
            Console.WriteLine("     ^ = mountain ");
            Console.WriteLine("     * = Tree     ");
            Console.WriteLine("     ` = grass    ");
            Console.WriteLine("     ~ = water    ");
        }
    }
}