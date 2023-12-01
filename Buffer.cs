using System;
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
    // 8: Create a camera that follows the player so that they may navigate a map larger than the available screen size
    // 9: Adjust the code that creates the map to function without the need of cursor position as this likely screws with the camera.

    internal class Buffer
    {
        public static char[,] firstBuffer;
        public static char[,] secondBuffer;

        public static void DisplayBuffer(int scale)
        {
            
            for (int Y = 0; Y < firstBuffer.GetLength(0); Y++)
            {
                for (int columnScale = 0; columnScale < scale; columnScale++)
                {
                    for (int X = 0; X < firstBuffer.GetLength(1); X++)
                    {
                        char MapElements = secondBuffer[Y, X];
                        
                        if (MapElements == firstBuffer[Y, X])
                        {
                            continue;
                        }
                        for (int rowScale = 0; rowScale < scale; rowScale++)
                        {
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
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }
                            Console.SetCursorPosition((X + 1) * scale + columnScale, (Y + 1) * scale + rowScale);
                            Console.Write(MapElements);
                        }
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("           ████████     Map legend:     ████████ ");
            Console.WriteLine("           ████████   ☙ = Health Fruit  ████████      ");
            Console.WriteLine("           ████████   ♣ = Very Bad Guy  ████████");
            Console.WriteLine("                Health: " + Player.health);

            Array.Copy(firstBuffer, secondBuffer, MapData.map.Length);
        }
    }
}

    //public class TextRPG
    //{
    //    #region Declarations


    //    public static int lives = 3; // having these as static means that other scripts can change them
    //    public static int level = 1;
    //    public int score = 0;
    //    public int health = 100;
    //    public static int Damage = 0;
    //    public static int enemyDamage;
    //    public static int enemyHealth = 50;
    //    public int enemyRemainingHealth;
    //    public int shield = 100;
    //    public int leftOverDamage;
    //    public static int scoreMult = 1 * level;
    //    public string playername;

    //    #endregion

    //    static void Main(string[] args)
    //    {
    //        PlayerClasses1 player = new PlayerClasses1();
    //        string studioName = "NameWasTakenStudios";
    //        string playerName;
    //        Console.WriteLine("Brought to you by " + studioName);
    //        Console.WriteLine();
    //        Console.WriteLine();
    //        Console.WriteLine("Welcome player please enter your name");
    //        playerName = Console.ReadLine();
    //        Console.WriteLine("Hello " + playerName);
    //        Console.WriteLine("Begin!");
    //        player.KeyInput();
    //        Character playerCharacter = PlayerClasses1.SelectedCharacter;
    //        Begin();
    //    }

    //    public static void Begin()
    //    {
    //        TextRPG game = new TextRPG();
    //        game.Start();
    //    }

    //    public void Start()
    //    {
    //        Enemies Enemy = new Enemies();

    //        Enemy.SpawnEnemy(1);
    //        ShowHUD();
    //        Combat();
    //        Combat();
    //        Combat();
    //    }

    //    public void Combat()
    //    {
    //        ShowHUD();
    //        Character playerCharacter = PlayerClasses1.SelectedCharacter;

    //        Console.WriteLine("# of Attacks you have " + playerCharacter.PlayerAttacks);
    //        Random rnd = new Random();
    //        Console.WriteLine("# of Attacks you have0 " + playerCharacter.PlayerAttacks);
    //        switch (playerCharacter.CharacterChoice)
    //        {
    //            case 1:
    //                Damage += rnd.Next(1, 20);
    //                Console.WriteLine("# of Attacks you have1 " + playerCharacter.PlayerAttacks);
    //                break;

    //            case 2:
    //                Damage += rnd.Next(1, 6);
    //                Console.WriteLine("# of Attacks you have2 " + playerCharacter.PlayerAttacks);
    //                break;

    //            case 3:
    //                Damage += rnd.Next(3, 12);
    //                Console.WriteLine("# of Attacks you have3 " + playerCharacter.PlayerAttacks);
    //                break;
    //        }

    //        for (int i = 0; i < Enemies.NumberOfEnemyAttacks; i++)
    //        {
    //            TakeDamage(enemyDamage);
    //        }

    //        for (int i = 0; i < playerCharacter.PlayerAttacks; i++)
    //        {
    //            DealDamage(Damage);
    //        }
    //    }

    //    void DealDamage(int damage)
    //    {
    //        Enemies Enemy = new Enemies();

    //        Console.WriteLine("You have Dealt " + damage + " damage");
    //        enemyHealth -= (damage);
    //        if (enemyHealth <= 0) // TODO reset enemy health or declare all enemies have been killed and stop assigning damage
    //        {
    //            score += 100;
    //            level++;
    //            Console.WriteLine("You have slain an enemy");
    //        }
    //        Enemy.ShowEnemyHUD();
    //    }


    //    void TakeDamage(int damage)

    //    {
    //        if (damage <= -1)
    //        {
    //            Console.WriteLine("Player tried to take " + damage + " damage");
    //            Console.WriteLine("You cannot take a negative amount of damage");
    //            return;
    //        }

    //        Console.WriteLine("You have taken " + damage + " damage");
    //        shield = shield - damage;
    //        if (shield <= 0)
    //        {
    //            health = health + shield;
    //            if (health <= 0)
    //            {
    //                health = 0;
    //                //Revive();
    //            }
    //            LivesCheck();
    //            shield = 0;
    //        }
    //        ShowHUD();
    //    }

    //    void RegenerateShield(int Shield)
    //    {
    //        if (Shield <= -1)
    //        {
    //            Console.WriteLine("Player tried to gain " + Shield + " shields");
    //            Console.WriteLine("You cannot gain a negative amount of shield");
    //            return;
    //        }
    //        if (shield <= 100)
    //        {
    //            Console.WriteLine("You have gained " + Shield + " shields");
    //            shield = shield + Shield;
    //        }
    //        else if (shield >= 100)
    //        {
    //            shield = 100;
    //            Console.WriteLine("You cannot have greater than 100 shield");
    //        }

    //    }

    //    public void Heal(int Health)
    //    {
    //        if (Health <= -1)
    //        {
    //            Console.WriteLine("Player tried to gain " + Health + " health");
    //            Console.WriteLine("You cannot gain a negative amount of health");
    //            return;
    //        }
    //        if (health <= 100)
    //        {
    //            Console.WriteLine("You have gained " + Health + " health");
    //            if (Health >= 100)
    //            {
    //                Console.WriteLine("You cannot have more than 100 health");
    //            }
    //            health = health + Health;
    //            if (health >= 100)
    //            {
    //                health = 100;
    //            }
    //        }
    //        else if (health >= 100)
    //        {
    //            health = 100;
    //            Console.WriteLine("You cannot have greater than 100 health");
    //        }
    //    }

    //    void LivesCheck()
    //    {
    //        if (lives <= 0)
    //        {
    //            health = 0;
    //            shield = 0;
    //            Console.WriteLine(playername + " HAS DIED ");
    //        }
    //    }

    //    void Revive()
    //    {
    //        Console.WriteLine("You've lost a life, your health and shields have been restored");
    //        lives--;
    //        health = 100;
    //        shield = 100;
    //    }

    //    void ResetGame()
    //    {
    //        Console.WriteLine("Your progress has been reset");
    //        scoreMult = 1;
    //        lives = 3;
    //        level = 1;
    //        score = 0;
    //        health = 100;
    //        Damage = 0;
    //        enemyDamage = 0;
    //        enemyHealth = 50;
    //        enemyRemainingHealth = 0;
    //        shield = 100;
    //        leftOverDamage = 0;
    //        ShowHUD();
    //    }

    //    public void ShowHUD()
    //    {
    //        Console.WriteLine("Score: " + score + " Health: " + health + " Lives: " + lives + " Shield " + shield + " Bonus Damage " + Damage);
    //        Console.WriteLine("LEVEL " + level);
    //        Console.ReadKey();

    //    }


