using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine()?.Trim();

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Please enter a whole number.");
                continue;
            }

            if (value == 0)
            {
                // No agregamos el 0 a la lista; termina la captura
                break;
            }

            numbers.Add(value);
        }

        // Si el usuario no ingresó nada (solo 0), evitamos divisiones por cero
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // ----- Core: suma, promedio, máximo -----
        int sum = 0;
        int max = numbers[0];

        foreach (int n in numbers)
        {
            sum += n;
            if (n > max)
            {
                max = n;
            }
        }

        double average = sum / (double)numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // ----- Stretch: menor positivo -----
        int smallestPositive = int.MaxValue;
        foreach (int n in numbers)
        {
            if (n > 0 && n < smallestPositive)
            {
                smallestPositive = n;
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There is no positive number in the list.");
        }

        // ----- Stretch: lista ordenada -----
        numbers.Sort(); // orden ascendente in-place
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}
