using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._09._20_Structures
{
    class Application
    {
        private AbstractFactory _factory;
        private IDrawable _figure;
      //  private Rectangle _rectangle;
       // private Triangle _triangle;
      //  private Trapezoid _trapezoid;
       // private Polygon _polygon;

        public Application(AbstractFactory factory)
        {
            _factory = factory;
        }
        public void CreateDiamond(Size size, Point point)
        {
            _figure = _factory.CreateDiamond(size, point);
        }
        public void CreateRectangle(Size size, Point point)
        {
            _figure = _factory.CreateRectangle(size, point);
        }
        public void CreateTriangle(Size size, Point point)
        {
            _figure = _factory.CreateTriangle(size, point);
        }
        public void CreateTrapezoid(Size size, Point point)
        {
            _figure = _factory.CreateTrapezoid(size, point);
        }
        public void CreatePolygon(Size size, Point point)
        {
            _figure = _factory.CreatePolygon(size, point);
        }
        public void Paint()
        {
            _figure.Draw();
        }



    }
}
