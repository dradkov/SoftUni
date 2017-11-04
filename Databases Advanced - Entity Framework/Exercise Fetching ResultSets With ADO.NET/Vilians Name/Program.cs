namespace Vilians_Name
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS;Database = MinionsDB;Integrated Security = True");


            connection.Open();

            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT  v.Name as Name,COUNT(*) AS  [Number Of Minions] from MinionsVillains AS mv " +
                "INNER JOIN Minions AS M ON m.Id = mv.MinionId " +
                "INNER JOIN Villains AS V ON v.Id = mv.VillainId " +
                "GROUP BY v.Name " +
                "ORDER BY[Number OF Minions] DESC",connection);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var villainsName = (string) reader["Name"];
                    int minionsCount = (int) reader["Number Of Minions"];

                    Console.WriteLine($"{villainsName} - {minionsCount}");


                }

            }

        }
    }
}
