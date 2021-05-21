// libs
using System;
using MySql.Data.MySqlClient;

// namespace
namespace engine.connection {

    // class for open connection
    class MysqlConnection
    {
        // variables
        string settingsSting;
        MySqlConnection connection;

        // constructor
        public MysqlConnection(string settings = "server=10.0.0.2;userid=root;password=dbnmjr031193;") 
        {
            this.settingsSting = settings;

            // open connection
            Open();
        }

        // method for open connection
        public void Open () {
            connection = new MySqlConnection(settingsSting);
            connection.Open();
        }

        // method for send sql requst
        public void I (string sqlRequest) {
            // make command
            MySqlCommand cmd = new MySqlCommand(sqlRequest ,this.connection);
            
            //send command
            cmd.ExecuteNonQuery();
        }

        // method for send sql request and get response
        public string IO (string sqlRequest){
            // make command
            MySqlCommand cmd = new MySqlCommand(sqlRequest ,this.connection);

            // send command and get data
            MySqlDataReader response = cmd.ExecuteReader();

            // buffer string 
            string bufferString = "";

            while (response.Read()){
                bufferString += $"{response[0]},";
            }

            // close connection
            response.Close();

            return bufferString;
        }

        // show connection version
        public string Version() {
            return connection.ServerVersion;
        }
    }
}