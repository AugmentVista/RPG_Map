﻿using System;
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
        public static int health;
        public static bool dead;
        const int maxHealth = 5;

        public static void Initialize()
        {
            health = maxHealth;
            dead = false;
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
        }

        static void MovePlayer(int rowChange, int columnChange)
        {
            Console.CursorVisible = false;
            int newRow = playerRow + rowChange;
            int newCol = playerCol + columnChange;

            if (MapData.IsValidMove(newRow, newCol))
            {
                // Update the player's position
                playerRow = newRow;
                playerCol = newCol;
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

        static void Die()
        {
            dead = true;
        }
    }
}