using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPG_Map 
{
    internal class EnemyManager : MapData
    {

        static int MapWidth = map.GetLength(1);
        static int MapHeight = map.GetLength(0);
        public static char enemyCharacter = '♣';
        static int numberOfEnemies = 500; 
        static Random random = new Random();

        // Populate the map with enemies
        static public void EnemyPopulate()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int randomX, randomY;

                do
                {
                    randomX = random.Next(MapWidth);
                    randomY = random.Next(MapHeight);
                } while (map[randomY, randomX] != ' ' || map[randomY, randomX] == '☻' || (randomX < 10 && randomY < 10));

                // Place the enemy on the map
                map[randomY, randomX] = enemyCharacter;
            }
        }

        // Move enemies on the map
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
    }
}