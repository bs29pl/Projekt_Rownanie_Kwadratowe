using System;
using QuadraticApp.Logic;

namespace QuadraticApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Kalkulator równań kwadratowych ===");
            Console.WriteLine("Równanie ma postać: ax² + bx + c = 0\n");

            double a = ReadDouble("Podaj a: ");
            double b = ReadDouble("Podaj b: ");
            double c = ReadDouble("Podaj c: ");

            try
            {
                double[] roots = QuadraticSolver.Solve(a, b, c);

                Console.WriteLine("\nWynik:");

                if (roots.Length == 0)
                {
                    Console.WriteLine("Brak rozwiązań rzeczywistych.");
                }
                else if (roots.Length == 1)
                {
                    Console.WriteLine($"Jedno rozwiązanie: x = {roots[0]}");
                }
                else
                {
                    Console.WriteLine($"Dwa rozwiązania: x₁ = {roots[0]}, x₂ = {roots[1]}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nBłąd: {ex.Message}");
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }

        private static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }

                Console.WriteLine("Niepoprawna wartość. Spróbuj ponownie.\n");
            }
        }
    }
}
