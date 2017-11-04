namespace Add_Minion
{
    using System;
    using System.Data.SqlClient;

    public class Program
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS; Database = MinionsDB; Integrated Security = True");

            connection.Open();

            try
            {
                using (connection)
                {
                    string[] minionInfo = Console.ReadLine().Split(new[] { ' ', ';', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    string minionName = minionInfo[1];
                    int minionAge = int.Parse(minionInfo[2]);
                    string town = minionInfo[3];

                    string[] villianInfo = Console.ReadLine().Split(new[] { ' ', ';', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    string villianName = villianInfo[1];



                    SqlCommand cmdTown = new SqlCommand($"SELECT Name FROM Towns WHERE Name = '{town}'", connection);
                    string townName = (string)cmdTown.ExecuteScalar();

                    SqlCommand cmdVilian = new SqlCommand($"SELECT Name FROM Villains  WHERE Name = '{villianName}'", connection);
                    string villian = (string)cmdVilian.ExecuteScalar();

                    SqlCommand cmdMinion = new SqlCommand($"SELECT Name FROM Minions WHERE Name = '{minionName}' and age = {minionAge}", connection);
                    string minion = (string)cmdMinion.ExecuteScalar();


                    if (string.IsNullOrEmpty(townName))
                    {
                        string insertTownsSQL = $"INSERT INTO Towns (Name, CountryId) VALUES ('{town}',1)";
                        ExecuteCommand(insertTownsSQL, connection);
                    }

                    if (string.IsNullOrEmpty(minion))
                    {

                        SqlCommand cmdTown2 = new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{town}'", connection);

                        int townName2 = (int)cmdTown2.ExecuteScalar();

                        string insertMinionsSQL = $"INSERT INTO Minions (Name, Age, TownId) VALUES ('{minionName}',{minionAge},{townName2})";

                        ExecuteCommand(insertMinionsSQL, connection);
                    }

                    if (string.IsNullOrEmpty(villian))
                    {
                        string insertVillainsSQL = $"INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('{villian}', 4)";

                        ExecuteCommand(insertVillainsSQL, connection);
                        Console.WriteLine($"Villain {villian} was added to the database.");
                    }

                    Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

        }

        private static void ExecuteCommand(string command, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(command, connection);
            cmd.ExecuteNonQuery();

        }
    }
}
