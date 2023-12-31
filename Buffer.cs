﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;


namespace RPG_Map
{
    // Checklist:
    // 1: Stop the character from leaving a trail when they move around the map. ♂
    // 2: Fix double buffering so it doesn't painfully flicker on every movement. ♂
    // 3: Prevent the character from traveling over certain characters. ♂
    // 4: Create an Enemy NPC that moves around with basic AI ♂
    // 5: Use the same logic to prevent the NPC's from moving through walls and terrain ♂
    // 6: Import and modify health system so that the NPC's damage you and vise versa ♂
    // 7: Define what happens when an enemy or the player dies. ♂

    internal class Buffer
    {
        public static char[,] firstBuffer;
        public static char[,] secondBuffer;

        public static void DisplayBuffer()
        {
            for (int Y = 0; Y < firstBuffer.GetLength(0); Y++)
            {

                for (int X = 0; X < firstBuffer.GetLength(1); X++)
                {
                    char MapElements = secondBuffer[Y, X];
                        
                    if (MapElements == firstBuffer[Y, X])
                    {
                        continue;
                    }
                    int Top = Y + 1;
                    int Left = X + 1;
                    switch (MapElements)
                    {
                        case '╭':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '─':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '╮':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '╯':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '╰':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '│':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┘':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┌':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┐':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '└':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '├':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┤':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┬':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '┴':
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case '☻':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case '☙':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case '♣':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case '⅛':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '⅜':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '⅝':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case '⅞':
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                    }
                    Console.SetCursorPosition(Left, Top);
                    Console.Write(MapElements); 
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("           ███████████████████████████████████████████████████");
            Console.WriteLine("           ████████           Map legend:             ████████");
            Console.WriteLine("           ████████       ☙ = Health Fruit            ████████");
            Console.WriteLine("           ████████       ♣ = Very Bad Guy            ████████");
            Console.WriteLine("           ████████           Health:" + Player.health + "                ████████");
            Console.WriteLine("           ████████       Remaining Enemies: " + EnemyManager.GetRemainingEnemies() + "       ████████");
            Console.WriteLine("           ████████            Score " + Player.Score + "                ████████");
            Console.WriteLine("           ████████ ⅛ = 1/8th chance to take damage   ████████");
            Console.WriteLine("           ████████ ⅜ = 3/8th chance to take damage   ████████");
            Console.WriteLine("           ████████ ⅝ = 5/8th chance to take damage   ████████");
            Console.WriteLine("           ████████ ⅞ = 7/8th chance to take damage   ████████");
            Console.WriteLine("           ███████████████████████████████████████████████████");
            Array.Copy(firstBuffer, secondBuffer, MapData.map.Length);
           }
        }
    }
