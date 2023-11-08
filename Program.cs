namespace RPG_Map
{
    internal class Program
    {
        static public char character;
        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            DisplayMap(1);
            Console.ReadKey(true);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            DisplayMap(2);
            Console.ReadKey(true); // test
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            DisplayMap(3);
            Console.ReadKey(true);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            DisplayMap(4);
            Console.ReadKey(true);
        }
        static char[,] map = new char[,] // dimensions defined by following data:
        {
        {'^','^','^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'^','^','`','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`'},
        {'^','^','`','`','`','*','*','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','~','~','~','`','`','`','`','`'},
        {'^','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','`','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`','`','`'},
        {'`','`','`','`','`','~','~','~','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','^','^','^','^','`','`','`'},
        {'`','`','`','`','`','`','`','~','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        {'`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`','`'},
        };

        static void Border()
        {
        // damn 
        
        }
        

        static void DisplayMap(int scale)
        {
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
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    break;
                                case '^':
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case '*':
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case '~':
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                            }
                            Console.Write(character);
                        }
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
            
            Console.WriteLine("     Map legend: ");
            Console.WriteLine("     ^ = mountain ");
            Console.WriteLine("     ` = grass");
            Console.WriteLine("     ~ = water ");
        }

    }
}