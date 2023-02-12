# Class: Vector

A C# class representing a mathematical vector with 2 components (X and Y) and provides methods and operators to perform basic vector arithmetic.

## Properties
- `X`: double type representing the X component of the vector.
- `Y`: double type representing the Y component of the vector.
- `Angle`: double type representing the angle of the vector with respect to X-axis.
- `Length`: double type representing the magnitude of the vector.

## Constructors
- `Vector(double XComp, double YComp)`: Initializes a new instance of the Vector class with X and Y components passed as arguments.

## Operators
- `+`: Adds two vectors and returns the result as a new Vector instance.
- `-`: Subtracts two vectors and returns the result as a new Vector instance.
- `*`: Multiplies a vector with a scalar and returns the result as a new Vector instance.
- `/`: Divides a vector with a scalar and returns the result as a new Vector instance.

## Methods
- `AddTo(Vector V)`: Adds the given Vector instance to the current Vector instance.
- `SubtractFrom(Vector V)`: Subtracts the given Vector instance from the current Vector instance.
- `MultiplyBy(double Value)`: Multiplies the current Vector instance with the given scalar.
- `DivideBy(double Value)`: Divides the current Vector instance by the given scalar.

## Example

```csharp
 Vector v1 = new Vector(3, 4);
 Console.WriteLine("Vector v1: " + v1.X + ", " + v1.Y);
 Console.WriteLine("Angle of v1: " + v1.Angle);
 Console.WriteLine("Length of v1: " + v1.Length);

 Vector v2 = new Vector(5, 12);
 Console.WriteLine("Vector v2: " + v2.X + ", " + v2.Y);
 Console.WriteLine("Angle of v2: " + v2.Angle);
 Console.WriteLine("Length of v2: " + v2.Length);

 Vector v3 = v1 + v2;
 Console.WriteLine("Vector v3 (v1 + v2): " + v3.X + ", " + v3.Y);
 Console.WriteLine("Angle of v3: " + v3.Angle);
 Console.WriteLine("Length of v3: " + v3.Length);

 Vector v4 = v2 - v1;
 Console.WriteLine("Vector v4 (v2 - v1): " + v4.X + ", " + v4.Y);
 Console.WriteLine("Angle of v4: " + v4.Angle);
 Console.WriteLine("Length of v4: " + v4.Length);

 Vector v5 = v2 * 2;
 Console.WriteLine("Vector v5 (v2 * 2): " + v5.X + ", " + v5.Y);
 Console.WriteLine("Angle of v5: " + v5.Angle);
 Console.WriteLine("Length of v5: " + v5.Length);

 Vector v6 = v5 / 2;
 Console.WriteLine("Vector v6 (v5 / 2): " + v6.X + ", " + v6.Y);
 Console.WriteLine("Angle of v6: " + v6.Angle);
 Console.WriteLine("Length of v6: " + v6.Length);
 ```
            
# Class: Particle

This class is a representation of a particle in a 2D space. It contains properties such as position, velocity, gravity, and mass, as well as methods for simulating physical interactions such as acceleration and collision detection. 

## Properties

- `Position`: A `Vector` representing the particle's current position in the 2D space.
- `Velocity`: A `Vector` representing the particle's current velocity.
- `Gravity`: A `double` representing the particle's gravity in the Y direction. This value can be set and retrieved using the getter and setter.
- `Data`: An `object` property that can be used to store any additional information associated with the particle.
- `Mass`: A `double` representing the particle's mass.
- `Radius`: A `double` representing the particle's radius.
- `Boundry`: A `SizeF` representing the boundaries of the 2D space in which the particle exists.
- `Bounce`: A `double` representing the particle's bounce factor when it collides with a boundary.

## Events

- `ParticleOutOfBounds`: An event that is raised when the particle goes out of bounds. The event handler receives the particle and the location of the out of bounds event as a `BoundLocation` enum value.
- `ParticleCollide`: An event that is raised when the particle collides with a boundary. The event handler receives the particle and the location of the collision as a `BoundLocation` enum value.

```csharp
 static void Main(string[] args)
 {
   Particle particle = new Particle();
   particle.ParticleCollide += Particle_ParticleCollided;
   particle.ParticleOutOfBounds += Particle_ParticleOutOfBounds;
 }

 private static void Particle_ParticleCollided(Particle Particle, BoundLocation bLoc)
 {
   
 }
 
  private static void Particle_ParticleOutOfBounds(Particle Particle, BoundLocation bLoc)
 {
   
 }
```

## Enums

- `BoundLocation`: An enum representing the possible locations of a boundary. The values are `Top`, `Bottom`, `Left`, and `Right`.

## Constructor

The `Particle` class has a constructor that takes in the following parameters:

- `XComp`: A `double` representing the X component of the particle's initial position.
- `YComp`: A `double` representing the Y component of the particle's initial position.
- `Speed`: A `double` representing the particle's initial speed.
- `Direction`: A `double` representing the particle's initial direction in radians.
- `Gravity` (optional): A `double` representing the particle's initial gravity in the Y direction. The default value is `0.0d`.

## Methods

- `Accelerate`: A method that takes in a `Vector` representing the acceleration and adds it to the particle's velocity.
- `Update`: A method that updates the particle's position and velocity based on its current velocity and gravity. It also checks for out of bounds and collisions if the boundaries have been set.
- `AngleTo`: A method that returns the angle in radians between the particle and another particle.
- `DistanceTo`: A method that returns the distance between the particle and another particle.
- `GravitateTo`: A method that causes the particle to gravitate towards another particle based on their masses and distance.
- `WithBoundry`: A method that sets the boundaries of the 2D space in which the particle exists.
- `CheckBoundry`: A private method that checks if the particle is out of bounds and raises the `ParticleOutOfBounds` event if necessary.
- `CheckCollisions`: A private method that checks if the particle has collided with a boundary and raises the `ParticleCollide` event if necessary.
