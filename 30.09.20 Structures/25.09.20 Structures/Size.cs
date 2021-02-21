using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    struct Size
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            set => _width = value;
        }
        public double Height
        {
            get => _height;
            set => _height = value;
        }
        public Size(double width, double height)
        {
            _width = width;
            _height = height;
        }
    }
}
