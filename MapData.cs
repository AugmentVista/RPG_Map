using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Map
{
    public class MapData
    {
        static public char character;
        static int playerRow = 1; // Initial player position
        static int playerCol = 1;
        public static int scale;
        static char playerCharacter = '☻';
        static char enemyCharacter = '☺';
        public static char[,] map;

        static string[] border = new string[]
        {
          "╔","╗","╝","╚", "║","═"
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TxtFileToMapArray();


            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(0, 0);
                HandleKeyPress(keyInfo.Key);
                DrawMap();
                DrawPlayer();
                Buffer.DisplayBuffer(1);
                DrawBorder(1);
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static void TxtFileToMapArray()
        {
            string[] lines = File.ReadAllLines("Map.txt");

            map = new char[lines.GetLength(0), lines[0].Length];
            Buffer.firstBuffer = new char[lines.GetLength(0), lines[0].Length];
            Buffer.secondBuffer = new char[lines.GetLength(0), lines[0].Length];
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }
        }

        public static void DrawMap()
        {
            Array.Copy(map, Buffer.secondBuffer, map.Length);
        }
        public static void DrawPlayer()
        {
            Buffer.secondBuffer[playerCol, playerRow] = playerCharacter;
        }

        static void HandleKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.DownArrow:
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.LeftArrow:
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                    MovePlayer(1, 0);
                    break;

                case ConsoleKey.W:
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.S:
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.A:
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.D:
                    MovePlayer(1, 0);
                    break;
            }
        }

        static void MovePlayer(int rowChange, int columnChange)
        {
            Console.CursorVisible = false;
            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;

            if (IsValidMove(newRow, newCol))
            {
                // Update the player's position
                playerRow = newRow;
                playerCol = newCol;
            }
        }


        static bool IsValidMove(int newRow, int newCol)
        {
            if (newRow >= 0 && newRow < map.GetLength(1) && newCol >= 0 && newCol < map.GetLength(0))
            {
                switch (map[newCol, newRow])
                {
                    case ' ':
                    case '^':
                    case '~':
                    case '░':
                    case '†':
                        return true;
                    case '*':
                    case '█':
                        return false;
                }

            }
            return false;
        }

        static void DrawBorder(int scale)
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int HorizontalWall = 1;
            int VerticalWall = 1;
            int totalWidth = (mapWidth + 1 )* scale;
            int totalHeight = (mapHeight + 1) * scale;

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
            Console.SetCursorPosition(totalWidth, 0);
            Console.Write(border[1]);
            Console.SetCursorPosition(0, totalHeight);
            Console.Write(border[3]);
            Console.SetCursorPosition(totalWidth, totalHeight);
            Console.Write(border[2]);

        }
    }
}
