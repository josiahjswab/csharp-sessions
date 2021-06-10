using System;
using System.Collections.Generic;

namespace ClassLibrary1 // Ctr + R, G cleans up unused using statments
{
    public class OpeningDimensions
    {
        public double Width { get; set; }
        public int Panels { get; set; }
        public double Profile { get; set; }


    }

    public class Vertical
    {
        public double Xcoordinate { get; set; }
    }

    public class DrawingGenerator
    {
        public static List<Vertical> Generate(OpeningDimensions oDTest)
        {
                List<Vertical> result = new List<Vertical>();
                double last = oDTest.Width - oDTest.Profile;
                double first = 0;
                result.Add(new Vertical() {Xcoordinate=first});
                var foo = last / oDTest.Panels - 1;
                for (int i = 1; i < oDTest.Panels; i++)
                {
                    result.Add(new Vertical() { Xcoordinate = foo * i });
                }
                result.Add(new Vertical() {Xcoordinate=last});
            return result;
        }
    }
}
