using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
namespace TitanPlanner
{
    public class Vector2
    {
        public float X;
        public float Y;
        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(float _X, float _Y)
        {
            X = _X;
            Y = _Y;
        }

        public Point GetPoint()
        {
            return new Point(Convert.ToInt16(X), Convert.ToInt16(Y));
        }

        public string GetString()
        {
            return "Vector2 X: " + X + ", Y: " + Y;
        }
    }
    class FieldMath
    {

        public const float FIELD_SIZE = 1000;
        public const float MAP_SIZE = 700;




        public static Vector2 ConvertScreenToCoord(Vector2 ScreenCoord)
        {
            Vector2 _out = new Vector2();
            // 0 - 700
            // 0 - 1000

            float Multiple = FIELD_SIZE / MAP_SIZE;

            _out.X = ScreenCoord.X * Multiple;
            _out.Y = ScreenCoord.Y * Multiple;
                
            return _out;
        }

        public static Vector2 ConvertCoordToScreen(Vector2 Coord)
        {
            Vector2 _out = new Vector2();
            // 0 - 700
            // 0 - 1000

            float Multiple = MAP_SIZE / FIELD_SIZE;

            _out.X = Coord.X * Multiple;
            _out.Y = Coord.Y * Multiple;

            return _out;
        }

      


    }
}
