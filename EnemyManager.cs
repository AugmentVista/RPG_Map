using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPG_Map 
{
    internal class EnemyManager : MapData
    {
        public int remainingEnemies = GetRemainingEnemies();
        static int MapWidth = map.GetLength(1);
        static int MapHeight = map.GetLength(0);
        public static char enemyCharacter = '♣';
        public static int numberOfEnemies = 50; 
        static Random random = new Random();

        static public void EnemyPopulate()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int randomX, randomY;

                dos
                {
                    randomX = random.Next(MapWidth);
                    randomY = random.Next(MapHeight);
                } while (map[randomY, randomX] != ' ' || map[randomY, randomX] == '☻' || (randomX < 8 && randomY < 8));
                map[randomY, randomX] = enemyCharacter;
            }
        }
        static public void MoveEnemies()
        {
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    if (map[y, x] == enemyCharacter) 
                    {
                        int randomDirection = random.Next(4); 

                        int newX = x, newY = y;
                        switch (randomDirection) // 0: Up, 1: Right, 2: Down, 3: Left
                        {
                            case 0: // Up
                                newX = Math.Max(0, x - 1);
                                break;
                            case 1: // Right
                                newY = Math.Min(MapHeight - 1, y + 1);
                                break;
                            case 2: // Down
                                newX = Math.Min(MapWidth - 1, x + 1);
                                break;
                            case 3: // Left
                                newY = Math.Max(0, y - 1);
                                break;
                        }
                        if (Player.playerRow == newX && Player.playerCol == newY)
                        {
                            Player.TakeDamage();
                        }
                        else if (map[newY, newX] == ' ')
                        {
                            map[y, x] = ' '; 
                            map[newY, newX] = enemyCharacter; 
                        }
                    }
                }
            }
        }



        public static int GetRemainingEnemies()
        {
            int count = 0;

            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (map[y, x] == enemyCharacter)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}