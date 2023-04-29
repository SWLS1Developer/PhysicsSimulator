using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

public class Particle
{
    #region Public Vars
    public Vector Position;
    public Vector Velocity;
    public double Gravity
    {
        get { return _g.Y; }
        set
        {
            if (_g == null)
                _g = new Vector(0, value);
            else
                _g.Y = value;
        }
    }
    public object Data;
    public double Mass;
    public double Radius;
    public SizeF Boundry;
    public double Bounce;
    public double Friction;
    public List<Particle> Gravitations;
    public Emitter Emitter;

    public delegate void ParticleOutOfBoundsEventHandler(Particle particle, BoundLocation BState);
    public delegate void ParticleCollisionEventHandler(Particle particle, BoundLocation BState);
    public event ParticleOutOfBoundsEventHandler ParticleOutOfBounds;
    public event ParticleCollisionEventHandler ParticleCollide;

    public bool IsParticleOutOfBoundry;
    #endregion
    #region PrivateVars
    private Vector _g = null;
    #endregion
    #region Constructors
    public Particle(double XComp, double YComp, double Speed, double Direction, double Gravity = 0.0d)
    {
        this.Position = new Vector(XComp, YComp);
        this.Velocity = new Vector(0, 0);
        this.Velocity.Length = Speed;
        this.Velocity.Angle = Direction;
        this._g = new Vector(0, Gravity);
        this.Mass = 1;
        this.Radius = 0;
        this.Boundry = new SizeF(0, 0);
        this.Bounce = 0;
        this.Friction = 1;
        this.Gravitations = new List<Particle>();
        this.Emitter = null;
    }
    #endregion
    #region Enums
    public enum BoundLocation
    {
        Top = 0,
        Bottom = 1,
        Left = 2,
        Right = 3
    }
    #endregion
    #region Public Functions
    public Particle Clone()
    {
        Particle clone = (Particle)this.MemberwiseClone();
        clone.Gravitations = new List<Particle>(this.Gravitations.Count);
        foreach (Particle gravitation in this.Gravitations)
        {
            clone.Gravitations.Add(gravitation.Clone());
        }
        return clone;
    }
    public void Accelerate(Vector AccelerationVector)
    {
        this.Velocity.AddTo(AccelerationVector);
    }
    public void Update(bool CheckBoundry = false) // CheckBoundry: Go from one side come from other side
    {
        if (!(this.Boundry.Width <= 0 || this.Boundry.Height <= 0))
        {
            this.CheckBoundry(CheckBoundry);
            this.CheckCollisions();
        }

        this.HandleGravitations();
        this.Velocity.AddTo(_g);
        this.Position.AddTo(this.Velocity);

        if (this.Velocity.Length > 0)
        this.Velocity.MultiplyBy(this.Friction);
    }
    public double AngleTo(Particle p2) => Math.Atan2(p2.Position.Y - this.Position.Y, p2.Position.X - this.Position.X);
    public double AngleTo(Vector v) => Math.Atan2(v.Y - this.Position.Y, v.X - this.Position.X);
    public double DistanceTo(Particle p2)
    {
        var dx = p2.Position.X - this.Position.X;
        var dy = p2.Position.Y - this.Position.Y;

        return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
    }
    public double DistanceTo(Vector v)
    {
        var dx = v.X - this.Position.X;
        var dy = v.Y - this.Position.Y;

        return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
    }
    public void GravitateTo(Particle p2)
    {
        var grav = new Vector(0, 0);
        var dist = this.DistanceTo(p2);

        grav.Length = (p2.Mass / (dist * dist));
        grav.Angle = this.AngleTo(p2);

        this.Velocity.AddTo(grav);
    }
    public void WithBoundry(double W, double H)
    {
        this.Boundry.Width = (float)W;
        this.Boundry.Height = (float)H;
    }
    #endregion
    #region Private Functions
    //private void HandleSprings()
    //{
    //    for (int i = 0; i < Springs.Count; ++i)
    //    {
    //        var s = Springs[i];
    //        var distance = (s.Point - this.Position);
    //        distance.Length -= s.Length;
    //        this.Velocity.AddTo(distance * s.K);
    //    }
    //}
    private void HandleGravitations()
    {
        for (int i = 0; i < Gravitations.Count; ++i)
        {
            var g = Gravitations[i];
            this.GravitateTo(g);
        }
    }
    
    private void CheckBoundry(bool tAction = true)
    {
        int s = 0;

        if (this.Position.X - this.Radius > this.Boundry.Width)
        {
            IsParticleOutOfBoundry = true;

            if (ParticleOutOfBounds != null)
                ParticleOutOfBounds(this, BoundLocation.Right);

            if (tAction)
                this.Position.X = -this.Radius;
        }
        else
            s++;
        if (this.Position.Y - this.Radius > this.Boundry.Height)
        {
            IsParticleOutOfBoundry = true;

            if (ParticleOutOfBounds != null)
                ParticleOutOfBounds(this, BoundLocation.Bottom);

            if (tAction)
                this.Position.Y = -this.Radius;
        }
        else
            s++;
        if (this.Position.X + this.Radius < 0)
        {
            IsParticleOutOfBoundry = true;

            if (ParticleOutOfBounds != null)
                ParticleOutOfBounds(this, BoundLocation.Left);

            if (tAction)
                this.Position.X = this.Boundry.Width + this.Radius;
        }
        else
            s++;
        if (this.Position.Y + this.Radius < 0)
        {
            IsParticleOutOfBoundry = true;

            if (ParticleOutOfBounds != null)
                ParticleOutOfBounds(this, BoundLocation.Top);

            if (tAction)
                this.Position.Y = this.Boundry.Height + this.Radius;
        }else
            s++;

        if (s == 4)
            IsParticleOutOfBoundry = false;
    }
    private void CheckCollisions()
    {
        if (this.Position.X + this.Radius >= this.Boundry.Width)
        {
            if (ParticleCollide != null)
                ParticleCollide(this, BoundLocation.Right);

            if (this.Bounce != 0)
            {
                this.Position.X = this.Boundry.Width - this.Radius;
                this.Velocity.X *= this.Bounce;
            }
        }
        if (this.Position.Y + this.Radius >= this.Boundry.Height)
        {
            if (ParticleCollide != null)
                ParticleCollide(this, BoundLocation.Bottom);

            if (this.Bounce != 0)
            {
                this.Position.Y = this.Boundry.Height - this.Radius;
                this.Velocity.Y *= this.Bounce;
            }
        }
        if (this.Position.X - this.Radius <= 0)
        {
            if (ParticleCollide != null)
                ParticleCollide(this, BoundLocation.Left);

            if (this.Bounce != 0)
            {
                this.Position.X = this.Radius;
                this.Velocity.X *= this.Bounce;
            }
        }
        if (this.Position.Y - this.Radius <= 0)
        {
            if (ParticleCollide != null)
                ParticleCollide(this, BoundLocation.Top);

            if (this.Bounce != 0)
            {
                this.Position.Y = this.Radius;
                this.Velocity.Y *= this.Bounce;
            }
        }
    }
    #endregion
}
