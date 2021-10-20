using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;

namespace ingenium.probe
{
    class Program
    {
        static void Main(string[] args)
        {
            //A simple line connected from one coordinate to the next
            //Example: A route that goes from LA to San Fran
            //Note: Have to have atleast two points you know because its a LINEstring

            

            var polygon = new Polygon(new LinearRing(new Coordinate[]
            {
                new Coordinate(1.0, 1.0),
                new Coordinate(1.05, 1.1),
                new Coordinate(1.1, 1.1),
                new Coordinate(1.1, 1.05),
                new Coordinate(1, 1),
            }));

            var simplePolygon = new GeoJsonWriter().Write(polygon);

            LineString ls1 = GetSimpleLineString();
            LineString ls2 = GetSimpleLineString();
            LineString ls3 = GetSimpleLineString();

            LineString[] lsArr = new LineString[] { ls1, ls2, ls3 };
            MultiLineString mls = new MultiLineString(lsArr);

            var mslStr = new GeoJsonWriter().Write(mls);

        }

        public static LineString GetSimpleLineString() {
            Coordinate coord1 = new Coordinate(74.6523332, 21.213213);
            Coordinate coord2 = new Coordinate(80.2321312, 25.563213);
            Coordinate coord3 = new Coordinate(85.6522352, 25.983223);

            Coordinate[] coordArr = new Coordinate[] { coord1, coord2, coord3 };

            return new LineString(coordArr);
        }
    }
}
