using System;
using System.Linq;
using CatShelter.ConsoleApp.Models;

namespace CatShelter.ConsoleApp
{
  class Program
  {
    static void Main()
    {
      GetOwnersDirectFromTheDatabase();

      GetLocationsViaAnORM();

      EditCatsViaAnORM();
    }

    private static void GetOwnersDirectFromTheDatabase()
    {
      var directAccess = new DirectAccess();

      Console.WriteLine("Owners");
      Console.WriteLine("------");

      foreach (string owner in directAccess.GetAllOwners())
      {
        Console.WriteLine(owner);
      }
    }

    private static void GetLocationsViaAnORM()
    {
      var ormAccess = new ORMAccess();
      Console.WriteLine();
      Console.WriteLine("Locations");
      Console.WriteLine("---------");

      foreach (Location location in ormAccess.GetAllLocations())
      {
        Console.WriteLine($"{location.Id}: {location.StreetAddress}, {location.City}, {location.PostCode}");
      }
    }

    private static void EditCatsViaAnORM()
    {
      while (true)
      {
        var ormAccess = new ORMAccess();
        Console.WriteLine();
        Console.WriteLine("Cats");
        Console.WriteLine("----");

        var allTheCats = ormAccess.GetAllCats().ToList();

        foreach (Cat cat in allTheCats)
        {
          Console.WriteLine($"{cat.Id}: {cat.Name}, age {cat.Age?.ToString() ?? "unknown"}, owned by {cat.Owner.Name}");
        }

        Console.WriteLine();

        Console.Write("Enter cat ID to edit: ");
        var catId = Console.ReadLine();

        var catToEdit = ormAccess.GetCat(catId);
        catToEdit.Age = catToEdit.Age.HasValue ? catToEdit.Age + 1 : 1;
        ormAccess.UpdateCat(catToEdit);
      }
    }
  }
}
