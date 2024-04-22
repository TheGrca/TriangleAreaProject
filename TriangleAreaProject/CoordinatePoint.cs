using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleAreaProject
{
    public class CoordinatePoint //Pomocna klasa koja nam cuva podatke o tackama u koordinatnom sistemu
    {
        public double X {  get; set; } //Property za X osu
        public double Y { get; set; } // Property za Y osu

        public CoordinatePoint(double x, double y) //Konstruktor za klasu koja za parametre prima X i Y koordinate
        {
            this.X = x;
            this.Y = y;
        }
    }
}
