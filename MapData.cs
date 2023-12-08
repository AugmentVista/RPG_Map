using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Map
{
    public class MapData
    {

        public static int scale;
        public static char[,] map;
        public static int score;

        static string[] border = new string[]
        {
          "╔","╗","╝","╚", "║","═"
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            score = 0;

            TxtFileToMapArray();
            //LoadMap2();
            EnemyManager.EnemyPopulate();
            Player.Initialize();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                Console.SetCursorPosition(0, 0);
                if (keyInfo.Key == ConsoleKey.Enter || GetCurrentFruit() <= 0)
                {
                    Console.Clear();
                    LoadMap2();
                    EnemyManager.EnemyPopulate();
                    Player.Initialize();
                }
                Player.HandleKeyPress(keyInfo.Key);
                DrawMap();
                Player.DrawPlayer();
                Buffer.DisplayBuffer(1);
                DrawBorder(1);
            } while (keyInfo.Key != ConsoleKey.Escape && !Player.dead);
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
        public static void LoadMap2()
        {
            string[] lines = File.ReadAllLines("Map2.txt");

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

        public static bool IsValidMove(int newRow, int newCol)
        {
            if (newRow >= 0 && newRow < map.GetLength(1) && newCol >= 0 && newCol < map.GetLength(0))
            {
                switch (map[newCol, newRow])
                {
                    case ' ':
                        return true;
                    case '╭':
                    case '─':
                    case '╮':
                    case '╯':
                    case '╰':
                    case '│':
                    case '┘':
                    case '┌':
                    case '┐':
                    case '└':
                    case '├':
                    case '┤':
                    case '┬':
                    case '┴':
                        return false;
                }
                if (map[newCol, newRow] == EnemyManager.enemyCharacter)
                {
                    map[newCol, newRow] = ' ';
                }
                if (map[newCol, newRow] == Player.Fruit && Player.health < Player.maxHealth)
                {
                    map[newCol, newRow] = ' ';
                    Player.GainHealth();
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

        public static int GetCurrentFruit()
        {
            int totalFruit = 0;
            int MapWidth = map.GetLength(1);
            int MapHeight = map.GetLength(0);

            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (map[y, x] == Player.Fruit)
                    {
                        totalFruit++;
                    }
                }
            }
            return totalFruit;
        }
        
        public static int UpdateScore()
        {
            int score = EnemyManager.numberOfEnemies - EnemyManager.GetRemainingEnemies();
            Player.Score = score;
            return score;
        }
    }
}