using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23._09._20_Interfaces
{
    class House
    {
        private List<IPart> _parts = new List<IPart>();

        public void Add(IPart part)
        {
            _parts.Add(part);
        }
        
        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < _parts.Count; i++)
            {
                str += _parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return $"House contains: {str}\n";
        }
    }
}
