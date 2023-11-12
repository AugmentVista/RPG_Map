using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
// create a start menu that asks the player to select the scale and reject all input that isnt't 1~5, then set the public int scale to their answer
namespace RPG_Map
{


    internal class Buffer
    {
        static char[,] offScreenBuffer = new char[MapData.map.GetLength(0), MapData.map.GetLength(1)];

        public static void DrawToBuffer()
        {
            Array.Copy(MapData.map, offScreenBuffer, MapData.map.Length);

        }
        public static void ResetPlayerPosition(int playerRow, int playerCol)
        {
            // Replace the '@' character with the original character in the off-screen buffer
            if (offScreenBuffer[playerRow, playerCol] == '@')
            {
                offScreenBuffer[playerRow, playerCol] = MapData.map[playerRow, playerCol];
            }
        }
        public static void DisplayBuffer(int scale)
        {
            Console.Write(" "); // add a space before the first row
            for (int Y = 0; Y < offScreenBuffer.GetLength(0); Y++)
            {
                for (int columnScale = 0; columnScale < scale; columnScale++)
                {
                    for (int X = 0; X < offScreenBuffer.GetLength(1); X++)
                    {
                        char MapElements = offScreenBuffer[Y, X];
                        for (int rowScale = 0; rowScale < scale; rowScale++)
                        {
                            switch (MapElements)
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
                            Console.Write(MapElements);
                        }
                    }
                    Console.WriteLine();
                    Console.Write(" "); // adds a space before the start of each row after the first
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write('@');
            Console.ResetColor();
            Console.WriteLine("     Map legend:  ");
            Console.WriteLine("     ^ = mountain ");
            Console.WriteLine("     * = Tree     ");
            Console.WriteLine("     ` = grass    ");
            Console.WriteLine("     ~ = water    ");
        }
    }









    public class MapData
    {
        static public char character;

        static int playerRow = 1; // Initial player position
        static int playerCol = 1;
        public static int scale;
        static char playerCharacter = '@';

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                HandleKeyPress(keyInfo.Key);

                // Draw the map and the border
                Buffer.DrawToBuffer();
                Buffer.DisplayBuffer(2);
                DrawBorder(2);
            } while (keyInfo.Key != ConsoleKey.Escape);
                
            

            static void HandleKeyPress(ConsoleKey key)
            {
                
                // Handle player movement based on the key pressed
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        MovePlayer(-1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        MovePlayer(1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        MovePlayer(0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        MovePlayer(0, 1);
                        break;
                }
            }

            static void MovePlayer(int rowChange, int colChange)
            {
                // Check if the new position is within the bounds of the map
                int newRow = playerRow + rowChange;
                int newCol = playerCol + colChange;

                if (IsValidMove(newRow, newCol))
                {
                    // Reset the previous player position on the map
                    map[playerRow, playerCol] = GetOriginalMapCharacter(playerRow, playerCol);

                    // Update the player's position
                    playerRow = newRow;
                    playerCol = newCol;

                    // Place the player character on the new position
                    map[playerRow, playerCol] = playerCharacter;
                }
            }

            static bool IsValidMove(int newRow, int newCol)
            {
                // Check if the new position is within the bounds of the map
                return newRow >= 0 && newRow < map.GetLength(0) && newCol >= 0 && newCol < map.GetLength(1);
            }

            static char GetOriginalMapCharacter(int row, int col)
            {
                // Return the original character at the specified position
                return map[row, col];
            }
        }
        public static char[,] map = new char[,] 
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