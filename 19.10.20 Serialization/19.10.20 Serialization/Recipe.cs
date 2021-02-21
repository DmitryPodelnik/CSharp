using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _19._10._20_Serialization
{
    [Serializable]
    public class Recipe
    {
        private int _id;
        private string _name;
        private List<Ingredient> _ingredients;
        private List<string> _preparation;
        private int _serves;
        private string _complexity;
        private string _preparationTime;
        private List<string> _additionalFeatures;

        public Recipe() { }
        public Recipe(int id, string name, int serves, string complexity, string preparationTime)
        {
            Id = id;
            Name = name;
            Serves = serves;
            Complexity = complexity;
            PreparationTime = preparationTime;
        }

        [XmlAttribute]
        public int Id
        {
            get => _id;
            set
            {
                try
                {
                    if (value < 1)
                    {
                        throw new ArgumentException("ID must be bigger than 0");
                    }
                    _id = value;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlElement(ElementName = "name")]
        public string Name
        {
            get => _name;
            set
            {
                try
                {
                    if (value.Length == 0)
                    {
                        throw new ArgumentNullException("Name cannot be null");
                    }
                    _name = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlArray("ingredients"), XmlArrayItem("ingredient")]
        public List<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    if (_ingredients != null)
                    {
                        _ingredients.Clear();
                    }
                    _ingredients = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlArray("preparation"), XmlArrayItem("step")]
        public List<string> Preparation
        {
            get => _preparation;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    if (_preparation != null)
                    {
                        _preparation.Clear();
                    }
                    _preparation = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlElement(ElementName = "serves")]
        public int Serves
        {
            get => _serves;
            set
            {
                try
                {
                    if (value < 1)
                    {
                        throw new ArgumentNullException("Serves must be bigger than 0");
                    }
                    _serves = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlAttribute(AttributeName = "complexity")]
        public string Complexity
        {
            get => _complexity;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    if (value != "Junior" && value != "Middle" && value != "Senior")
                    {
                        throw new ArgumentException("Incorrect value");
                    }
                    _complexity = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlAttribute(AttributeName ="time")]
        public string PreparationTime
        {
            get => _preparationTime;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    _preparationTime = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlAttribute(AttributeName = "description")]
        public List<string> AdditionalFeatures
        {
            get => _additionalFeatures;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    if (_additionalFeatures != null)
                    {
                        _additionalFeatures.Clear();
                    }
                    _additionalFeatures = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public override string ToString()
        {
            try
            {
                string preparation = "Preparation: ";
                for (int i = 0; i < _preparation.Count; i++)
                {
                    preparation += _preparation[i];
                    preparation += ", ";
                }
                preparation = preparation.Remove(preparation.Length - 2, 2) + ".";

                string additionalFeatures = "Additional Features: ";
                for (int i = 0; i < _additionalFeatures.Count; i++)
                {
                    additionalFeatures += _additionalFeatures[i];
                    additionalFeatures += ", ";
                }
                additionalFeatures = additionalFeatures.Remove(additionalFeatures.Length - 2, 2) + ".";

                string ingredients = "Ingredients: \n";
                for (int i = 0; i < _ingredients.Count; i++)
                {
                    ingredients += _ingredients[i];
                    ingredients += ".\n";
                }

                return $"ID: {Id}, Name: {Name}, Serves: {_serves}, Complexity: {_complexity}, Preparation Time: {_preparationTime}.\n"
                       + preparation + "\n" + additionalFeatures + "\n" + ingredients;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}
