using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _19._10._20_Serialization
{
    [Serializable]
    public class Ingredient
    {
        private string _component;
        private int _amount;
        private string _unit;

        public Ingredient() { }
        public Ingredient(string component, int amount, string unit)
        {
            _component = component;
            _amount = amount;
            _unit = unit;
        }
        [XmlElement(ElementName = "component")]
        public string Component
        {
            get => _component;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    _component = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlElement(ElementName = "amount")]
        public int Amount
        {
            get => _amount;
            set
            {
                try
                {
                    if (value < 1)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    _amount = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        [XmlElement(ElementName = "unit")]
        public string Unit
        {
            get => _unit;
            set
            {
                try
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Value cannot be null");
                    }
                    _unit = value;
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public override string ToString()
        {
            return $"{Component}, Amount: {Amount.ToString()}, Unit: {Unit}";
        }
    }
}
