using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using CatShelter.ConsoleApp.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;

namespace CatShelter.ConsoleApp
{
  public class ORMAccess
  {
    private readonly string connectionString =
      new SqlConnectionStringBuilder
      {
        DataSource = "localhost",
        IntegratedSecurity = true,
        InitialCatalog = "CatShelter"
      }.ConnectionString;

    public IEnumerable<Location> GetAllLocations()
    {
      using (var connection = new SqlConnection(connectionString))
      {
        return connection.Query<Location>("SELECT * FROM Locations");
      }
    }

    public IEnumerable<Cat> GetAllCats()
    {
      using (var connection = new SqlConnection(connectionString))
      {
        return connection.Query<Cat, Owner>("SELECT * FROM Cats JOIN Owners ON Cats.OwnerId = Owners.Id");
      }
    }

    public Cat GetCat(string id)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        return connection.Query<Cat, Owner>(
          "SELECT * FROM Cats JOIN Owners ON Cats.OwnerId = Owners.Id WHERE Cats.Id = @id",
          new { id }).Single();
      }
    }

    public Cat GetCatWithoutWritingSql(int id)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        return connection.Get<Cat>(id);
      }
    }

    public void UpdateCat(Cat cat)
    {
      using (var connection = new SqlConnection(connectionString))
      {
        connection.Update(cat);
      }
    }
  }
}