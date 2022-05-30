using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Setup
        string[] save = File.ReadAllLines("map.txt");
        int NumberOfRows = save.Length;
        char[][] mapRows = new char[NumberOfRows][];

        for (int i = 0; i < NumberOfRows; i++)
        {
            mapRows[i] = save[i].ToCharArray();
        }

        // Variables
        int MoveSpeed = 0; 
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
        bool IsNotDone = true;          // The values of this variables are irrelevant as they will change when the program is run
        int score = 0;
        bool won = true;
        int saveY = Console.CursorTop;
        int saveX = Console.CursorLeft;
        
        const char ghost = 'O';


        //Enmey 1 variables
        int enemyY = 4;
        int enemyX = 11;
        int SaveEnemyX = 888;
        int SaveEnemyY = 889;

        // Enemy 2 variables
        int enemyY2 = 5;
        int enemyX2 = 19;
        int SaveEnemyX2 = 888;
        int SaveEnemyY2 = 889;



        // Enemy 2 methods
        void SaveEnemyPosition2()
        {
            SaveEnemyY2 = enemyY2;
            SaveEnemyX2 = enemyX2;
        }

        void ReturnEnemyToSave2()
        {
            enemyY2 = SaveEnemyY2;
            enemyX2 = SaveEnemyX2;
        }


        bool TryEnemyMove2(string direction)
        {
            SavePosition();
            Console.CursorTop = enemyY2;
            Console.CursorLeft = enemyX2;
            SaveEnemyPosition2();
            if (direction == "north")
            {
                Console.CursorTop--;
                enemyY2--;
            }
            if (direction == "south")
            {
                Console.CursorTop++;
                enemyY2++;
            }
            if (direction == "east")
            {
                Console.CursorLeft++;
                enemyX2++;
            }
            if (direction == "west")
            {
                Console.CursorLeft--;
                enemyX2--;
            }

            if ((mapRows[enemyY2][enemyX2]) == '#')
            {
                ReturnEnemyToSave2();
                ReturnToSave();
                return false;
            }

            ReturnToSave();
            return true;

        }
        
        void TestTryEnemyMoveMethods(){

            Debug.Assert(TryEnemyMove("north"));
            Debug.Assert(TryEnemyMove("south"));
            Debug.Assert(TryEnemyMove("east"));
            Debug.Assert(TryEnemyMove("west"));

            Debug.Assert(TryEnemyMove2("north"));
            Debug.Assert(TryEnemyMove2("south"));
            Debug.Assert(TryEnemyMove2("east"));
            Debug.Assert(TryEnemyMove2("west"));
        }


        void PrintEnemy2(int Y, int X)
        {
            SavePosition();

            mapRows[SaveEnemyY2][SaveEnemyX2] = ' ';
            Console.CursorTop = SaveEnemyY2;
            Console.CursorLeft = SaveEnemyX2;
            Console.Write(' ');

            mapRows[Y][X] = ghost; ///
            Console.CursorTop = Y;
            Console.CursorLeft = X;
            Console.Write(ghost); ////

            enemyY2 = Y;
            enemyX2 = X;

            ReturnToSave();
        }


        // Action to move Enemy2
        Action MoveEnemy2 = () =>
        {
            Console.CursorTop = 1;
            Console.CursorLeft = 1;
            Thread.Sleep(100);


            while (IsNotDone)
            {
                Random number2 = new Random();
                int number2XD = number2.Next(1, 5);

                switch (number2XD)
                {
                    case 1:
                        {
                            while (TryEnemyMove2("north"))
                            {
                                PrintEnemy2(SaveEnemyY2 - 1, SaveEnemyX2);
                                if (TouchedEnemy(enemyY2, enemyX2)) break;
                                Thread.Sleep(MoveSpeed);
                            }
                            break;
                        }

                    case 2:
                        {
                            while (TryEnemyMove2("south"))
                            {
                                PrintEnemy2(SaveEnemyY2 + 1, SaveEnemyX2);
                                if (TouchedEnemy(enemyY2, enemyX2)) break;
                                Thread.Sleep(MoveSpeed);
                            }
                            break;
                        }

                    case 3:
                        {
                            while (TryEnemyMove2("west"))
                            {
                                PrintEnemy2(SaveEnemyY2, SaveEnemyX2 - 1);
                                if (TouchedEnemy(enemyY2, enemyX2)) break;
                                Thread.Sleep(MoveSpeed);
                            }
                            break;
                        }

                    case 4:
                        {
                            while (TryEnemyMove2("east"))
                            {
                                PrintEnemy2(SaveEnemyY2, SaveEnemyX2 + 1);
                                if (TouchedEnemy(enemyY2, enemyX2)) break;
                                Thread.Sleep(MoveSpeed);

                            }
                            break;
                        }

                }
            }
            EndGame();

        };





        // Enemy1 methdos
        void PrintEnemy(int Y, int X)
        {
            SavePosition();

            mapRows[SaveEnemyY][SaveEnemyX] = ' ';
            Console.CursorTop = SaveEnemyY;
            Console.CursorLeft = SaveEnemyX;
            Console.Write(' ');

            mapRows[Y][X] = ghost; ///
            Console.CursorTop = Y;
            Console.CursorLeft = X;
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(ghost); ////
            //Console.ForegroundColor = ConsoleColor.White;

            enemyY = Y;
            enemyX = X;

            ReturnToSave();
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



        bool TryEnemyMove(string direction)
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
                Console.CursorLeft++;
                enemyX++;
            }
            if (direction == "west")
            {
                Console.CursorLeft--;
                enemyX--;
            }

            if ((mapRows[enemyY][enemyX]) == '#')
            {
                ReturnEnemyToSave();
                ReturnToSave();
                return false;
            }

            ReturnToSave();
            return true;

        }
        Debug.Assert(TryEnemyMove("north"));
        Debug.Assert(TryEnemyMove("south"));
        Debug.Assert(TryEnemyMove("east"));
        Debug.Assert(TryEnemyMove("west"));

        // Action to move enemy1
        Action MoveEnemy = () =>
        {

            Console.CursorTop = 1;
            Console.CursorLeft = 1;
            int Speed = MoveSpeed;
            
            while (IsNotDone)
            {
                Random number = new Random();
                int numberXD = number.Next(1, 5);

                switch (numberXD)
                {
                    case 1:
                        {
                            while (TryEnemyMove("north"))
                            {
                                PrintEnemy(SaveEnemyY - 1, SaveEnemyX);
                                if (TouchedEnemy(enemyY, enemyX)) break;
                                Thread.Sleep(Speed);
                            }
                            break;
                        }

                    case 2:
                        {
                            while (TryEnemyMove("south"))
                            {
                                PrintEnemy(SaveEnemyY + 1, SaveEnemyX);
                                if (TouchedEnemy(enemyY, enemyX)) break;
                                Thread.Sleep(Speed);
                            }
                            break;
                        }

                    case 3:
                        {
                            while (TryEnemyMove("west"))
                            {
                                PrintEnemy(SaveEnemyY, SaveEnemyX - 1);
                                if (TouchedEnemy(enemyY, enemyX)) break;
                                Thread.Sleep(Speed);
                            }
                            break;
                        }

                    case 4:
                        {
                            while (TryEnemyMove("east"))
                            {
                                PrintEnemy(SaveEnemyY, SaveEnemyX + 1);
                                if (TouchedEnemy(enemyY, enemyX)) break;
                                Thread.Sleep(Speed);
                            }
                            break;
                        }

                }
            }
            EndGame();

        };





        // Methods that control the game

        void EndGame()
        {
            IsNotDone = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
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


        void PrintScore()
        {
            SavePosition();
            Console.CursorTop = NumberOfRows + 1;
            Console.CursorLeft = NumberOfRows;
            Console.WriteLine($"Score: {score}");
            ReturnToSave();
        }


        bool TouchedEnemy(int Yaxis, int Xaxis)
        {
            if (y == Yaxis && x == Xaxis)
            {
                IsNotDone = false;
                won = false;
                return true;
            }
            else return false;
        }
        Debug.Assert(!TouchedEnemy(enemyY + 1, enemyX));


        void CheckIfDone()
        {
            try
            {
                if (mapRows[y][x] == '*')
                    IsNotDone = false;
            }
            catch { };
        }


        void UpdateScore()
        {
            try
            {
                if (mapRows[y][x] == '$')
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    SavePosition();
                    score++;
                    Console.CursorTop = NumberOfRows + 1;
                    Console.CursorLeft = NumberOfRows;
                    Console.WriteLine($"Score: {score}");
                    ReturnToSave();
                    mapRows[y][x] = ' ';
                    Console.Write(" ");
                    Console.CursorLeft--;
                    Console.ForegroundColor = ConsoleColor.Red;
                }

            }
            catch { };
        }

        void PostMoveChecks()
        {
            SavePosition();
            CheckIfDone();
            UpdateScore();
            TouchedEnemy(enemyY, enemyX);
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


        void PrintMap()
        {
            Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            SavePosition();

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < mapRows[i].Length; j++)
                {
                    Console.Write(mapRows[i][j]);
                }
                Console.WriteLine(" ");
            }
            ReturnToSave();

            TestTryEnemyMoveMethods();
        }


        void ColorObjects()
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < mapRows[i].Length; j++)
                {
                    if (mapRows[i][j] == '$') ///
                    {
                        SavePosition();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.CursorTop = i;
                        Console.CursorLeft = j;
                        Console.Write('$');
                        Console.ForegroundColor = ConsoleColor.White;
                        ReturnToSave();
                    }
                    //try
                    if ((mapRows[i][j] == '*'))
                    {
                        SavePosition();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.CursorTop = i;
                        Console.CursorLeft = j;
                        Console.Write('*');
                        Console.ForegroundColor = ConsoleColor.White;
                        ReturnToSave();
                    }
                }
            }
        }

        //Merthod that lets the user move
        void ReadKey()
        {
            do
            {
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


                if (Key == ConsoleKey.DownArrow && Console.CursorTop < NumberOfRows && IsNotDone)
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
        }

        // Method that runs the program
        void Run()
        {
            Console.Clear();

            Console.WriteLine("\n\nWelcome to the maze!\n");
            Console.WriteLine("In this game you will control a cursor which is placed in a map bordered by walls '#'. You will move the cursor using the up/down right/left keys. Your goal is to dodge the enemies 'O' while you try to pick the star '*'. If you touch one of the enemies, you will lose the game. You may pick cash '$' to increase your score, but if the enemies pick them before you, they will be gone forever.\n");
            Console.WriteLine("Whenever you are ready, press 'S' to select the level of difficulty. Good luck! ");

            ConsoleKey Key = ConsoleKey.L;
            do 
            {
                Key = Console.ReadKey(true).Key;
                if (Key == ConsoleKey.S)
                {

                    Console.Clear();

                    Console.WriteLine("\n\nUse the keyboard to pick the level of difficulty:\n ");
                    Console.WriteLine("A: Easy");
                    Console.WriteLine("B: Medium");
                    Console.WriteLine("C: Hard");
                    Console.WriteLine("D: Impossible ");

                    do 
                    {
                        ConsoleKey Key2 = Console.ReadKey(true).Key;

                        if (Key2 == ConsoleKey.A)
                        {
                            Thread.Sleep(500);
                            Console.Clear();

                            MoveSpeed = 375;
                            PrintMap();
                            PrintScore();
                            ColorObjects();
                            

                            SavePosition();
                            Console.CursorTop = enemyY2;
                            Console.CursorLeft = enemyX2;
                            Console.Write(' ');
                            mapRows[enemyY2][enemyX2] = ' ';
                            ReturnToSave();
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.CursorTop = 1;
                            Console.CursorLeft = 1;

                            Task.Run(MoveEnemy);
                            //Task.Run(MoveEnemy2);
                            ReadKey();

                            EndGame();
                        }

                        if (Key2 == ConsoleKey.B)
                        {
                            Thread.Sleep(500);
                            Console.Clear();

                            MoveSpeed = 500;
                            PrintMap();
                            PrintScore();
                            ColorObjects();
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.CursorTop = 1;
                            Console.CursorLeft = 1;

                            Task.Run(MoveEnemy);
                            Task.Run(MoveEnemy2);
                            ReadKey();

                            EndGame();
                        }


                        if (Key2 == ConsoleKey.C)
                        {
                            Thread.Sleep(500);
                            Console.Clear();

                            MoveSpeed = 250;
                            PrintMap();
                            PrintScore();
                            ColorObjects();
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.CursorTop = 1;
                            Console.CursorLeft = 1;

                            Task.Run(MoveEnemy);
                            Task.Run(MoveEnemy2);
                            ReadKey();

                            EndGame();
                        }


                        if (Key2 == ConsoleKey.D)
                        {
                            Thread.Sleep(500);
                            Console.Clear();

                            MoveSpeed = 25;
                            PrintMap();
                            PrintScore();
                            ColorObjects();
                            Console.ForegroundColor = ConsoleColor.Red;

                            SavePosition();
                            Console.CursorTop = enemyY2;
                            Console.CursorLeft = enemyX2;
                            Console.Write(' ');
                            mapRows[enemyY2][enemyX2] = ' ';
                            ReturnToSave();

                            Console.CursorTop = 1;
                            Console.CursorLeft = 1;

                            Task.Run(MoveEnemy);
                            
                            ReadKey();

                            EndGame();
                        }
                    } while (Key != ConsoleKey.A && Key != ConsoleKey.B && Key != ConsoleKey.C && Key != ConsoleKey.D );
                }
            } while (Key != ConsoleKey.S);
        }
        Run();
    }
}


