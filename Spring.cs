using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Spring
{
    public Vector Point;
    public double K;
    public double Length;

    public Spring(Vector Point, double K, double len)
    {
        this.Point = Point;
        this.K = K;
        this.Length = len;
    }
}
