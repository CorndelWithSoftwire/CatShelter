using System.Collections.Generic;
using System.Data.SqlClient;

namespace CatShelter.ConsoleApp
{
  public class DirectAccess
  {
    private readonly string connectionString =
      @"Data Source=localhost;Initial Catalog=CatShelter;Integrated Security=True";

    public IEnumerable<string> GetAllOwners()
    {
      using (var connection = new SqlConnection(connectionString))
      {
        var command = new SqlCommand("SELECT Name FROM Owners", connection);

        connection.Open();
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
          yield return reader.GetString(0);
        }

        reader.Close();
      }
    }
  }
}