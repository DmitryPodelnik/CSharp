using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _19._10._20_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Recipe> recipes = new List<Recipe>
                  {
                new Recipe(1, "1", 3, "Junior", "1:00")
                  };

                List<Ingredient> ingredients = new List<Ingredient>
                  {
                new Ingredient("Component1",2,"g"),
                new Ingredient("Component2",3,"g"),
                new Ingredient("Component3",4,"g")
                  };
                recipes[0].Ingredients = ingredients;

                List<string> additionalFeatures = new List<string>
                 {
                "Addional Feature 1",
                "Addional Feature 2"
                   };
                recipes[0].AdditionalFeatures = additionalFeatures;

                List<string> preparations = new List<string>
                 {
                "Step 1",
                "Step 2",
                "Step 3",
                "Step 4",
                "Step 5"
                 };
                recipes[0].Preparation = preparations;

                Console.WriteLine(recipes[0].ToString());

                /// SERIALIZATION

                XmlSerializer serializer = new XmlSerializer(recipes.GetType(), new XmlRootAttribute("Catalog"));

                using (FileStream stream = new FileStream("recipes.xml", FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(stream, recipes);
                }

                using (FileStream stream = File.OpenRead("recipes.xml"))
                {
                    List<Recipe> list = (List<Recipe>)serializer.Deserialize(stream);

                    foreach (var p in list)
                    {
                        Console.WriteLine(p);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
