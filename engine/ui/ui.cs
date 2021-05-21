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

                        // print result
                        Console.WriteLine(connection.IO("SHOW DATABASES").Replace(";","\n"));

                        // pause
                        Pause();
                        break;
                    // show all tables
                    case ConsoleKey.D2:
                        //clean console
                        Console.Clear();

                        // show databases
                        Console.WriteLine(connection.IO("SHOW DATABASES").Replace(";","\n") + "\n");

                        // Print message
                        Console.Write("Database name: ");

                        // try exeption
                        try {
                            // print result
                            Console.WriteLine(connection.IO($"SHOW TABLES FROM {Console.ReadLine().Trim()}").Replace(";","\n"));
                        }
                        //error message
                        catch {
                            Console.WriteLine("Database not found");
                        }

                        // pause
                        Pause();
                        break;

                    // show table
                    case ConsoleKey.D3:
                        //clean console
                        Console.Clear();

                        // show databases
                        Console.WriteLine(connection.IO("SHOW DATABASES").Replace(";","\n") + "\n");

                        // Print message
                        Console.Write("Database name: ");

                        // get database name from user
                        string databaseNameFour = Console.ReadLine().Trim(); //TODO

                        //clean console
                        Console.Clear();

                        // try exeption
                        try {
                            // print result
                            Console.WriteLine(connection.IO($"SHOW TABLES FROM {databaseNameFour}").Replace(";","\n") + "\n");
                        }
                        //error message
                        catch {
                            Console.WriteLine("Database not found");

                            //pause
                            Pause();

                            break;
                        }

                        // Print message
                        Console.Write("Table name: ");

                        // get table name
                        string tableNameFour = Console.ReadLine().Trim(); //TODO

                        //clean console
                        Console.Clear();

                        // try exeption
                        try {
                            // print result
                            Console.WriteLine(connection.IO($"SELECT * FROM {databaseNameFour}.{tableNameFour}"));
                        }
                        //error message
                        catch {
                            Console.WriteLine("Table not found");
                        }

                        // show table

                        //pause
                        Pause();

                        break;

                    // creating database
                    case ConsoleKey.D4: 
                        //clean console
                        Console.Clear();

                        // Print message
                        Console.Write("Database name: ");

                        // try exeption
                        try {
                            // make request
                            connection.I($"CREATE DATABASE {Console.ReadLine().Trim()}");

                            // print status message
                            Console.WriteLine("Database created!");
                        }
                        catch {
                            // print status message
                            Console.WriteLine("Database is alredy exist!");
                        }

                        // pause
                        Pause();
                        break;
                    
                    // creating table
                    case ConsoleKey.D5: 
                        //clean console
                        Console.Clear();

                        // show databases
                        Console.WriteLine(connection.IO("SHOW DATABASES").Replace(";","\n") + "\n");

                        // Print message
                        Console.Write("Database name: ");

                        // get database name from user
                        string databaseName = Console.ReadLine().Trim();

                        // try exeption
                        try {
                            // print result
                            Console.WriteLine(connection.IO($"SHOW TABLES FROM {databaseName}").Replace(";","\n") + "\n");
                        }
                        //error message
                        catch {
                            Console.WriteLine("Database not found");

                            //pause
                            Pause();

                            break;
                        }

                        //clean console
                        Console.Clear();

                        // Print message
                        Console.Write("Table name: ");

                        // get table name
                        string tableName = Console.ReadLine().Trim();

                        // Print message
                        Console.Write("Amount colums: ");

                        // amount colums
                        int amountColums = int.Parse(Console.ReadLine());

                        string sqlRequest = $"CREATE TABLE {databaseName}.{tableName} (";

                        // get datatypes for colums
                        for (int i = 0; i < amountColums; i++){
                            // print message
                            Console.Write($"Column {i + 1} name: ");

                            // add column name
                            sqlRequest += Console.ReadLine().Trim() + " ";

                            // print message
                            Console.Write($"Column {i + 1} type: ");

                            // add column type
                            sqlRequest += Console.ReadLine().Trim();

                            // add separator if not last
                            if (i + 1 < amountColums) {
                                sqlRequest += ",";
                            }
                        }

                        // finish sql request
                        sqlRequest += ")";

                        // try exeption
                        try {
                            // make request
                            connection.I(sqlRequest);

                            // print status message
                            Console.WriteLine("Table created!");
                        }
                        catch {
                            // print status message
                            Console.WriteLine("Error. Check inputed data. Table not created.");
                        }

                        // pause
                        Pause();
                        break;

                    case ConsoleKey.D6:
                        //clean console
                        Console.Clear();

                        // show databases
                        Console.WriteLine(connection.IO("SHOW DATABASES").Replace(";","\n") + "\n");

                        // Print message
                        Console.Write("Database name: ");

                        // get database name from user
                        string databaseNameTwo = Console.ReadLine().Trim(); // TODO change to method

                        //clean console
                        Console.Clear();

                        // try exeption
                        try {
                            // print result
                            Console.WriteLine(connection.IO($"SHOW TABLES FROM {databaseNameTwo}").Replace(";","\n") + "\n");
                        }
                        //error message
                        catch {
                            Console.WriteLine("Table not found");

                            //pause
                            Pause();

                            break;
                        }


                        // Print message
                        Console.Write("Table name: ");

                        // get table name
                        string tableNameTwo = Console.ReadLine().Trim(); // TODO change to method

                        //clean console
                        Console.Clear();

                        // try exept
                        try {
                            string[] responseString = connection.IO($"DESCRIBE {databaseNameTwo}.{tableNameTwo}").Split(";");
                            // values string
                            string values = "";

                            // get data from user
                            foreach (var item in responseString)
                            {
                                // separating data
                                string[] dataArr = item.Split(",");

                                // print message
                                Console.Write($"{dataArr[0]}({dataArr[1]}): ");

                                // add to values
                                values += "'" + Console.ReadLine() + "',";
                            }

                            // delete last coma
                            values = values.Substring(0, values.Length - 1);

                            // sql request string
                            connection.I($"INSERT INTO {databaseNameTwo}.{tableNameTwo} VALUES ({values})");

                            // status message
                            Console.WriteLine("Data wat added");

                            // pause
                            Pause();
                        }
                        catch {
                            //message
                            Console.WriteLine("Incorrect input. Try again");

                            // pause
                            Pause();

                            break;
                        }
                        break;

                    // delete table
                    case ConsoleKey.D7:
                        //clean console
                        Console.Clear();

                        // show databases
                        Console.WriteLine(connection.IO("SHOW DATABASES").Replace(";","\n") + "\n");

                        // Print message
                        Console.Write("Database name: ");

                        // get database name from user
                        string databaseNameThree = Console.ReadLine().Trim(); // TODO change to method

                        //clean console
                        Console.Clear();
                        
                        // try exeption
                        try {
                            // print result
                            Console.WriteLine(connection.IO($"SHOW TABLES FROM {databaseNameThree}").Replace(";","\n") + "\n");
                        }
                        //error message
                        catch {
                            Console.WriteLine("Table not found");

                            //pause
                            Pause();

                            break;
                        }

                        // Print message
                        Console.Write("Table name: ");

                        // get table name
                        string tableNameThree = Console.ReadLine().Trim(); // TODO change to method

                        // try exeption
                        try {
                            // make request
                            connection.I($"DROP TABLE {databaseNameThree}.{tableNameThree}");

                            // print status message
                            Console.WriteLine($"Table {tableNameThree} from {databaseNameThree} deleted!");
                        }
                        catch {
                            // print status message
                            Console.WriteLine("Error. Check inputed data. Table not deleted.");
                        }

                        // pause
                        Pause();
                        break;

                    // delete database
                    case ConsoleKey.D8:
                        //clean console
                        Console.Clear();

                        // show databases
                        Console.WriteLine(connection.IO("SHOW DATABASES").Replace(";","\n") + "\n");

                        // Print message
                        Console.Write("Database name: ");

                        // try exeption
                        try {
                            // make request
                            connection.I($"DROP DATABASE {Console.ReadLine().Trim()}");

                            // print status message
                            Console.WriteLine($"DATABASE deleted!");
                        }
                        catch {
                            // print status message
                            Console.WriteLine("Error. Check inputed data. Database not deleted.");
                        }

                        // pause
                        Pause();
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
            Console.WriteLine("Press 3 to show table");
            Console.WriteLine("Press 4 to create database");
            Console.WriteLine("Press 5 to create table");
            Console.WriteLine("Press 6 to insert data in table");
            Console.WriteLine("Press 7 to delete table");
            Console.WriteLine("Press 8 to delete database");
            Console.WriteLine("Press v to show DB version");
        }

        // pause
        public void Pause(){
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}