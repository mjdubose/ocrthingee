using System;

namespace OCRTHINGEE
{
    public class Coord
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Distance { get; set; }
    }

    public class Trilateration
    {
        public double[] Trilateration3D(Coord p1, Coord p2, Coord p3, Coord p4)
        {
            var ex = VectorUnit(VectorDiff(p2, p1));
            var i = VectorDotProduct(ex, VectorDiff(p3, p1));
            var ey = VectorUnit(VectorDiff(VectorDiff(p3, p1), VectorMultiply(ex, i)));
            var ez = VectorCross(ex, ey);
            var d = VectorLength(p2, p1);
            var r1 = p1.Distance;
            var r2 = p2.Distance;
            var r3 = p3.Distance;
            var r4 = p4.Distance;
            if (d - r1 >= r2 || r2 >= d + r1)
            {
                return new double[3];
            }

            var j = VectorDotProduct(ey, VectorDiff(p3, p1));
            var x = ((r1*r1) - (r2*r2) + (d*d))/(2*d);
            var y = (((r1*r1) - (r3*r3) + (i*i) + (j*j))/(2*j)) - ((i*x)/j);
            var z = (r1*r1) - (x*x) - (y*y);
            if (z < 0)
            {
                return new double[3];
            }

            var z1 = Math.Sqrt(z);
            var z2 = z1*-1;

            var result1 = p1;
            result1 = VectorSum(result1, VectorMultiply(ex, x));
            result1 = VectorSum(result1, VectorMultiply(ey, y));
            result1 = VectorSum(result1, VectorMultiply(ez, z1));
            var result2 = p1;
            result2 = VectorSum(result2, VectorMultiply(ex, x));
            result2 = VectorSum(result2, VectorMultiply(ey, y));
            result2 = VectorSum(result2, VectorMultiply(ez, z2));
            r1 = VectorLength(p4, result1);
            r2 = VectorLength(p4, result2);
            var t1 = r1 - r4;
            var t2 = r2 - r4;
            var coords = Math.Abs(t1) < Math.Abs(t2)
                ? new[] {Math.Round(result1.X*32, 0)/32, Math.Round(result1.Y*32, 0)/32, Math.Round(result1.Z*32, 0)/32}
                : new[] {Math.Round(result2.X*32, 0)/32, Math.Round(result2.Y*32, 0)/32, Math.Round(result2.Z*32, 0)/32};

            return coords;
        }

        public double VectorLength(Coord p1, Coord p2)
        {
            var a1 = p1.X;
            var a2 = p2.X;
            var b1 = p1.Y;
            var b2 = p2.Y;
            var c1 = p1.Z;
            var c2 = p2.Z;

            var dist = Math.Sqrt(((a2 - a1)*(a2 - a1)) + ((b2 - b1)*(b2 - b1)) + ((c2 - c1)*(c2 - c1)));
            return Math.Round(dist, 3);
        }

        public Coord VectorSum(Coord v1, Coord v2)
        {
            var ret = new Coord {X = v1.X + v2.X, Y = v1.Y + v2.Y, Z = v1.Z + v2.Z};
            return ret;
        }

        public Coord VectorCross(Coord v1, Coord v2)
        {
            var ret = new Coord
            {
                X = (v1.Y*v2.Z) - (v1.Z*v2.Y),
                Y = (v1.Z*v2.X) - (v1.X*v2.Z),
                Z = (v1.X*v2.Y) - (v1.Y*v2.X)
            };
            return ret;
        }

        public Coord VectorMultiply(Coord v1, double i)
        {
            var ret = new Coord {X = v1.X*i, Y = v1.Y*i, Z = v1.Z*i};
            return ret;
        }

        public double VectorDotProduct(Coord v1, Coord v2)
        {
            return (v1.X*v2.X) + (v1.Y*v2.Y) + (v1.Z*v2.Z);
        }

        public Coord VectorDiff(Coord p1, Coord p2)
        {
            var ret = new Coord {X = p1.X - p2.X, Y = p1.Y - p2.Y, Z = p1.Z - p2.Z};
            return ret;
        }

        public double VectorNorm(Coord v)
        {
            return Math.Sqrt((v.X*v.X) + (v.Y*v.Y) + (v.Z*v.Z));
        }

        public Coord VectorDiv(Coord v, double l)
        {
            var ret = new Coord {X = v.X/l, Y = v.Y/l, Z = v.Z/l};
            return ret;
        }

        public Coord VectorUnit(Coord v)
        {
            var l = VectorNorm(v);
            return l == 0 ? null : VectorDiv(v, l);
        }
    }
}