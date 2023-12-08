using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Map
{
    internal class Player
    {
        public static int playerRow = 1; // Initial player position
        public static int playerCol = 1;
        static char playerCharacter = '☻';
        public static char Fruit = '☙';
        public static int health;
        public static bool dead;
        public const int maxHealth = 5;
        public static int Score;
        public static string[] EnvriomentHazard = new string[]
       {
          "⅛","⅜","⅝","⅞"
       };

        public static void Initialize()
        {
            playerRow = 4;
            playerCol = 4;
            health = maxHealth;
            dead = false;
            Score = 0;
        }

        public static void DrawPlayer()
        {
            Buffer.secondBuffer[playerCol, playerRow] = playerCharacter;
        }
        public static void HandleKeyPress(ConsoleKey key)
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
            EnemyManager.MoveEnemies();
            MapData.UpdateScore();
        }

        static void MovePlayer(int rowChange, int columnChange)
        {
            Console.CursorVisible = false;
            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;

            if (MapData.IsValidMove(newRow, newCol))
            {
                playerRow = newRow;
                playerCol = newCol;

                if (EnvriomentHazard.Contains(MapData.map[playerCol, playerRow].ToString()))
                {
                    Random random = new Random();
                    int damageChance = random.Next(8);

                    switch (MapData.map[playerCol, playerRow].ToString())
                    {
                        case "⅛":
                            if (damageChance == 0) // 1/8 probability
                            {
                                TakeDamage();
                            }
                            break;
                        case "⅜":
                            if (damageChance < 3) // 3/8 probability
                            {
                                TakeDamage();
                            }
                            break;
                        case "⅝":
                            if (damageChance < 5) // 5/8 probability
                            {
                                TakeDamage();
                            }
                            break;
                        case "⅞":
                            if (damageChance < 7) // 7/8 probability
                            {
                                TakeDamage();
                            }
                            break;
                    }
                }
            }
        }

        public static void GainHealth()
        {
            health++;

            if (health >= maxHealth)
            {
                health = maxHealth;
            }
        }
        public static void TakeDamage()
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
        }
        public static void Die()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ███████████████████████████████████████   YOU DIED    ███████████████████████████████████████");
            Console.ReadKey(true);
            dead = true;
        }
    }
}