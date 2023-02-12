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
