//Lab 9, Maze. Produced by Agustin on march the 24th.

class MazeProgram
{
    static void Main()
    {
        //Console.WriteLine("Welcome to the Maze. Your role is to navigate the maze using the arrows in the keyboard and try to pick the star. Good Luck!");

        string[] save = File.ReadAllLines("map.txt");
        int NumberOfRows = save.Length;
        char[][] mapRows = new char[NumberOfRows][];

        for (int i = 0; i < NumberOfRows; i++)
        {
            mapRows[i] = save[i].ToCharArray();
        }

        Console.Clear();
        //print map

        void PrintMap()
        {
            SavePosition();
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < mapRows[i].Length; j++)
                {
                    Console.Write(mapRows[i][j]);
                }
                Console.WriteLine(" ");
            }
            ReturnToSave();
        }
        PrintMap();
        //variables
        Console.CursorTop = 0;
        Console.CursorLeft = 0;
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
        bool IsNotDone = true;
        int score = 0;
        int saveY = Console.CursorTop;
        int saveX = Console.CursorLeft;
        int enemyY = 9999;
        int enemyX = 9999;
        int SaveEnemyY = 0;
        int SaveEnemyX = 0;
        bool won = true;
        bool CanEnemyMove = false;
        string DirectionToMove = "xxxx";

        //print score
        SavePosition();
        Console.CursorTop = NumberOfRows + 1;
        Console.CursorLeft = NumberOfRows;
        Console.WriteLine($"Score: {score}");
        ReturnToSave();

        //methods
        void LocateEnemy()
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < mapRows[i].Length; j++)
                {
                    if (mapRows[i][j] == '%')
                    {
                        enemyY = i;
                        enemyX = j;
                    }
                }
            }
        }

        void SaveEnemyPosition()
        {
            SaveEnemyY = enemyY;
            SaveEnemyX = enemyX;
        }

        void ReturnEnemyToSave()
        {
            enemyY = SaveEnemyY;
            enemyX = SaveEnemyX;
        }

        void TouchedEnemy()
        {
            SavePosition();
            if (y == enemyY && x == enemyX)
            {
                IsNotDone = false;
                won = false;
            }
        }

        void TryEnemyMove(string direction)
        {
            SavePosition();
            Console.CursorTop = enemyY;
            Console.CursorLeft = enemyX;
            SaveEnemyPosition();
            if (direction == "north")
            {
                Console.CursorTop--;
                enemyY--;
            }
            if (direction == "south")
            {
                Console.CursorTop++;
                enemyY++;
            }
            if (direction == "east")
            {
                Console.CursorLeft--;
                enemyX--;
            }
            if (direction == "west")
            {
                Console.CursorLeft++;
                enemyX++;
            }

            if ((mapRows[enemyY][enemyX]) == '#')
            {
                CanEnemyMove = false;
                ReturnEnemyToSave();
            }
            else CanEnemyMove = true;
        }

        void PrintEnemy()
        {
            //SavePosition();
            mapRows[enemyY][enemyX] = '%';
            Console.CursorTop = enemyY;
            Console.CursorLeft = enemyX;

            Console.Write('%');
            ReturnToSave();
        }

        void MoveEnemy()
        {
            LocateEnemy();

            TryEnemyMove("north");
            if (CanEnemyMove)
            {
                mapRows[enemyY][enemyX] = ' ';
                //Console.CursorTop--;
                //PrintEnemy();
                PrintMap();
                ReturnToSave();
            }
            // TryEnemyMove("south");
            // if (CanEnemyMove) Console.CursorTop++;

            // TryEnemyMove("east");
            // if (CanEnemyMove) Console.CursorLeft--;

            // TryEnemyMove("west");
            // if (CanEnemyMove) Console.CursorLeft--;

            // PrintEnemy();
            // ReturnToSave();
        }
        //remember to create a new method to save the enemy's position

        void CheckIfDone()
        {
            if (mapRows[y][x] == '*')
                IsNotDone = false;
        }

        void SavePosition()
        {
            saveY = Console.CursorTop;
            saveX = Console.CursorLeft;
        }

        void ReturnToSave()
        {
            Console.CursorTop = saveY;
            Console.CursorLeft = saveX;
        }

        void UpdateScore()
        {
            if (mapRows[y][x] == '$')
            {
                SavePosition();
                score++;
                Console.CursorTop = NumberOfRows + 1;
                Console.CursorLeft = NumberOfRows;
                Console.WriteLine($"Score: {score}");
                ReturnToSave();
                mapRows[y][x] = ' ';
                Console.Write(" ");
                Console.CursorLeft--;
            }
        }

        void PostMoveChecks()
        {
            SavePosition();
            CheckIfDone();
            UpdateScore();
            TouchedEnemy();
            //MoveEnemy();
        }

        //program
        do
        {
            LocateEnemy();

            ConsoleKey Key = Console.ReadKey(true).Key;
            if (Key == ConsoleKey.UpArrow && Console.CursorTop > 0 && IsNotDone)
            {
                Console.CursorTop--;
                x = Console.CursorLeft;
                y = Console.CursorTop;
                if (mapRows[y][x] == '#')
                {
                    Console.CursorTop++;
                }
            }
            PostMoveChecks();

            if (mapRows[y][x] == '$')
            {
                score++;
            }
            else if (Key == ConsoleKey.DownArrow && Console.CursorTop < NumberOfRows && IsNotDone)
            {
                Console.CursorTop++;
                x = Console.CursorLeft;
                y = Console.CursorTop;
                if (mapRows[y][x] == '#')
                {
                    Console.CursorTop--;
                }
            }
            PostMoveChecks();

            if (Key == ConsoleKey.RightArrow && Console.CursorLeft < mapRows[Console.CursorTop].Length && IsNotDone)
            {
                Console.CursorLeft++;
                x = Console.CursorLeft;
                y = Console.CursorTop;
                if (mapRows[y][x] == '#')
                {
                    Console.CursorLeft--;
                }
            }
            PostMoveChecks();

            if (Key == ConsoleKey.LeftArrow && Console.CursorLeft > 0 && IsNotDone)
            {
                Console.CursorLeft--;
                x = Console.CursorLeft;
                y = Console.CursorTop;
                if (mapRows[y][x] == '#')
                {
                    Console.CursorLeft++;
                }
            }
            PostMoveChecks();

        } while (IsNotDone);

        Console.Clear();
        if (won)
        {
            Console.WriteLine("\nYou have won the game!");
            Console.WriteLine($"\nYour score was {score}!\n\n");
        }
        else
        {
            Console.WriteLine("\nYou have lost the game.");
            Console.WriteLine($"\nYour score was {score}.\n\n");
        }
    }

    void LeaderBoard()
    { 
        Console.WriteLine("Enter your name bro: ");    
        string name = Console.ReadLine();
    }
}