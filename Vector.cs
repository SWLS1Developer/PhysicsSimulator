using System;

public class Vector
{
    #region Private Vars
    private double _x, _y;
    #endregion
    #region Properties
    public double X
    {
        get
        {
            return _x;
        }
        set
        {
            _x = value;
        }
    }

    public double Y
    {
        get
        {
            return _y;
        }
        set
        {
            _y = value;
        }
    }

    public double Angle
    {
        get
        {
            return Math.Atan2(_y, _x);
        }
        set
        {
            double len = this.Length;
            _x = Math.Cos(value) * len;
            _y = Math.Sin(value) * len;
        }
    }

    public double Length
    {
        get
        {
            return Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
        }
        set
        {
            var angle = this.Angle;
            _x = Math.Cos(angle) * value;
            _y = Math.Sin(angle) * value;
        }
    }

    public int iX
    {
        get { return (int)_x; }
    }

    public int iY
    {
        get { return (int)_y; }
    }
    #endregion
    #region Constructors
    public Vector(double XComp, double YComp)
    {
        this.X = XComp;
        this.Y = YComp;
    }
    #endregion
    #region Operators
    public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);
    public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);
    public static Vector operator *(Vector v1, double multiplier) => new Vector(v1.X * multiplier, v1.Y * multiplier);
    public static Vector operator /(Vector v1, double d) => new Vector(v1.X / d, v1.Y / d);
    #endregion
    #region Methods
    public void AddTo(Vector V)
    {
        this._x += V.X;
        this._y += V.Y;
    }

    public void SubtractFrom(Vector V)
    {
        this._x -= V.X;
        this._y -= V.Y;
    }

    public void MultiplyBy(double Value)
    {
        this._x *= Value;
        this._y *= Value;
    }

    public void DivideBy(double Value)
    {
        this._x /= Value;
        this._y /= Value;
    }
    public double AngleTo(Vector vector)
    {
        return Math.Atan2(vector.Y - this.Y, vector.X - this.X);
    }
    public double DistanceTo(Vector vector)
    {
        var dx = vector.X - this.X;
        var dy = vector.Y - this.Y;

        return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
    }
    #endregion
}
