using FluentMigrator;

namespace CatShelter.Migrations
{
  [Migration(20170131102400)]
  public class CreateCatFoodStorage : Migration
  {
    public override void Up()
    {
      Create.Table("CatFoods")
        .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
        .WithColumn("Name").AsString().NotNullable();

      Insert.IntoTable("CatFoods")
        .Row(new {Name = "Yummies"})
        .Row(new {Name = "Crunchies"});

      Create.Column("FavouriteFoodId").OnTable("Cats").AsInt32().Nullable()
        .ForeignKey("FK_Cats_FavouriteFood", "CatFoods", "Id");
    }

    public override void Down()
    {
      Delete.ForeignKey("FK_Cats_FavouriteFood").OnTable("Cats");
      Delete.Column("FavouriteFoodId").FromTable("Cats");
      Delete.Table("CatFoods");
    }
  }
}
