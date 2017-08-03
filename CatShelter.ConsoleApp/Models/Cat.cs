using System;
using System.Collections;
using Dapper.Contrib.Extensions;

namespace CatShelter.ConsoleApp.Models
{
  public class Cat
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int? Age { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [Write(false)]
    public Owner Owner { get; set; }
  }
}