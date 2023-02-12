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
