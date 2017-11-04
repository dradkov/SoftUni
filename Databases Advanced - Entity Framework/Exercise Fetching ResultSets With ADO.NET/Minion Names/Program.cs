using System;

namespace Minion_Names
{
    using System.Data.SqlClient;

    public class Program
    {
      public  static void Main(string[] args)
        {
           SqlConnection connection = new SqlConnection("Server=.\\SQLEXPRESS; Database = MinionsDB; Integrated Security = True");

            connection.Open();

            using (connection)
            {
                int viliansId = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand($"SELECT Name FROM Villains WHERE Id = {viliansId}",connection);

                string vilianName = (string)cmd.ExecuteScalar();


                SqlCommand cmdMinions = new SqlCommand(
                    "SELECT m.Name AS  [Name],m.Age AS [Age] from MinionsVillains AS mv " +
                    "INNER JOIN Minions AS M ON m.Id = mv.MinionId " +
                    "INNER JOIN Villains AS V ON v.Id = mv.VillainId " +
                    "GROUP BY m.Name, m.Age, v.Id " +
                    $"HAVING v.Id = {viliansId} " +
                    "ORDER BY[Name] ", connection);


                SqlDataReader reader = cmdMinions.ExecuteReader();

                int counter = 1;

                Console.WriteLine($"Villain: {vilianName}");

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int age = (int) reader["Age"];

                    Console.WriteLine($"{counter}. {minionName} {age}");
                    counter++;

                }


            }


        }
    }
}
