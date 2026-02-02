using Xunit;
using QuadraticApp.Logic; 

namespace QuadraticApp.Tests;

public class QuadraticTests
{
    // 1. Test braku pierwiastków (Assert.Empty)
    [Fact]
    public void TestBrakPierwiastkow()
    {
        var wynik = QuadraticSolver.Solve(1, 0, 1);
        Assert.Empty(wynik); // Sprawdzenie pustej kolekcji
    }

    // 2. Test liczby i wartości pierwiastków 
    [Theory]
    [InlineData(1, -5, 6, 2, 3)]   // 2 pierwiastki: 2 i 3
    [InlineData(1, 2, -15, 3, -5)] // 2 pierwiastki: 3 i -5
    public void TestDwaPierwiastki(double a, double b, double c, double x1, double x2)
    {
        var wynik = QuadraticSolver.Solve(a, b, c);
        
        Assert.Equal(2, wynik.Length);
        Assert.Contains(x1, wynik); // Sprawdza, czy x1 jest w tablicy
        Assert.Contains(x2, wynik); // Sprawdza, czy x2 jest w tablicy
    }

    // 3. Test jednego pierwiastka 
    [Theory]
    [InlineData(1, -2, 1, 1)] // (x-1)^2 = 0
    public void TestJedenPierwiastek(double a, double b, double c, double spodziewany)
    {
        var wynik = QuadraticSolver.Solve(a, b, c);
        
        Assert.Single(wynik); // Sprawdza, czy kolekcja ma DOKŁADNIE 1 element
        Assert.Equal(spodziewany, wynik[0]);
    }

    // 4. Test wyjątku 
    [Fact]
    public void TestGdyParametrAJestZerem()
    {
        Assert.Throws<ArgumentException>(() => QuadraticSolver.Solve(0, 1, 1));
    }
}