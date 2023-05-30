// See https://aka.ms/new-console-template for more information
Console.Write("Input a: ");
double a = double.Parse(Console.ReadLine());
Console.Write("Input b: ");
double b = double.Parse(Console.ReadLine());
Console.Write("Input c: ");
double c = double.Parse(Console.ReadLine());

double d = b * b - 4 * a * c;

if (d < 0)
{
    Console.WriteLine("Discriminant is less than 0. Equation has no real roots");
} else
{
    double x1, x2;
    d = Math.Sqrt(d);
    x1 = (-b + d) / 2;
    x2 = (-b - d) / 2;
    Console.WriteLine($"Discriminant={d}\nx1={x1}\nx2={x2}");
}