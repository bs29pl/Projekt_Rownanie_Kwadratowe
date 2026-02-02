using System;

namespace QuadraticApp.Logic;
    /// <summary>
    /// Klasa odpowiedzialna za matematyczne obliczenia równań kwadratowych.
    /// </summary>
    public static class QuadraticSolver
    {
        /// <summary>
        /// Rozwiązuje równanie kwadratowe ax^2 + bx + c = 0.
        /// </summary>
        /// <param name="a">Współczynnik przy x^2 (nie może być zerem).</param>
        /// <param name="b">Współczynnik przy x.</param>
        /// <param name="c">Wyraz wolny.</param>
        /// <returns>Tablica pierwiastków (0, 1 lub 2 elementy).</returns>
        /// <exception cref="ArgumentException">Rzucany, gdy a jest równe 0.</exception>
        public static double[] Solve(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("To nie jest równanie kwadratowe (a nie może być równe 0).");
            }

            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                return Array.Empty<double>();
            }
            else if (delta == 0)
            {
                return new double[] { -b / (2 * a) };
            }
            else
            {
                double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                return new double[] { x1, x2 };
            }
        }
    }
