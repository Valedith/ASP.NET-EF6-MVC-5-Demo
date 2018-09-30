using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Demo_Restaurant.DAL
{
    public class RestaurantInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RestaurantContext>
    {
        protected override void Seed(RestaurantContext context)
        {
            var recipes = new List<Models.Recipe>
            {
            new Models.Recipe{ID=1,RecipeName="FrenchFries",Quantity=41,isAvailable=true,RegisterDate=DateTime.ParseExact("2009-09-28", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            new Models.Recipe{ID=2,RecipeName="Spaghetti",Quantity=31,isAvailable=true,RegisterDate=DateTime.ParseExact("2002-08-03", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            new Models.Recipe{ID=3,RecipeName="Pizza",Quantity=0,isAvailable=false,RegisterDate=DateTime.ParseExact("2011-09-02", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            new Models.Recipe{ID=4,RecipeName="Curry",Quantity=50,isAvailable=true,RegisterDate=DateTime.ParseExact("2006-01-01", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            new Models.Recipe{ID=5,RecipeName="Baguette",Quantity=60,isAvailable=true,RegisterDate=DateTime.ParseExact("1980-04-04", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            new Models.Recipe{ID=6,RecipeName="Mashed Potato",Quantity=57,isAvailable=true,RegisterDate=DateTime.ParseExact("2005-10-10", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            new Models.Recipe{ID=7,RecipeName="Lasagna",Quantity=0,isAvailable=false,RegisterDate=DateTime.ParseExact("2007-09-09", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            new Models.Recipe{ID=8,RecipeName="Ravioli",Quantity=88,isAvailable=true,RegisterDate=DateTime.ParseExact("2011-01-09", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)},
            };

            recipes.ForEach(s => context.Recipes.Add(s));
            context.SaveChanges();           
        }
    }
}