// libs
using System;
using engine.connection;

// namespace
namespace engine.ui
{
    // class for insterface
    class Interface
    {
        // variables
        private bool isRunning = true;
        private MysqlConnection connection;


        // constructor
        public Interface () {

            // open connection to db
            connection = new MysqlConnection();

            // start
            Start();
        }

        // methods

        // method for start interface
        private void Start() {
            // main interface loop
            while (isRunning) {

                // show controll
                ShowControll();

                // get user action
                switch(Console.ReadKey().Key) {

                    // "esc" close app
                    case ConsoleKey.Escape:

                        //clean console
                        Console.Clear();

                        //message
                        Console.WriteLine("You really want to exit?");
                        Console.Write("Y/N: ");

                        //check key
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            isRunning = false;

                            //clean console
                            Console.Clear();
                        }

                        break;
                    
                    // show all databases
                    case ConsoleKey.D1:
                        //clean console
                        Console.Clear();

                        connection.IO("SHOW DATABASES");

                        // pause
                        Pause();
                        break;

                    // creating database
                    case ConsoleKey.D3: 
                        //clean console
                        Console.Clear();

                        // Print message
                        Console.Write("Database name: ");

                        // get database name from user
                        string databaseName = Console.ReadLine().Trim();

                        // make request
                        connection.I($"CREATE DATABASE {databaseName}");
                        break;

                    case ConsoleKey.V:
                        //clean console
                        Console.Clear();

                        // show version
                        Console.WriteLine(connection.Version());

                        // pause
                        Pause();
                        break;


                }
                //clean console
                Console.Clear();

            }
        }

        // method for show controll
        public void ShowControll()
        {
            Console.WriteLine("Press ESC to exit");
            Console.WriteLine("Press 1 to show all databases");
            Console.WriteLine("Press 2 to show all tables");
            Console.WriteLine("Press 3 to create database");
            Console.WriteLine("Press 4 to create table");
            Console.WriteLine("Press 5 to insert data in table");
            Console.WriteLine("Press 6 to delete table");
            Console.WriteLine("Press 7 to delete database");
            Console.WriteLine("Press 9 to change database");
            Console.WriteLine("Press v to show DB version");
        }

        // pause
        public void Pause(){
            Console.WriteLine("\nPress any key to continnue");
            Console.ReadKey();
        }
    }
}