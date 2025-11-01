using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine()?.Trim();

        // Intentamos convertir a entero para evitar excepciones en tiempo de ejecución
        if (!int.TryParse(input, out int percent))
        {
            Console.WriteLine("Please enter a whole number (e.g., 87).");
            return;
        }

        // CORE: determinar la letra
        string letter;
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // STRETCH: determinar el signo (+ / -) con excepciones
        string sign = "";
        int lastDigit = Math.Abs(percent) % 10; // por si acaso hay negativos

        if (letter == "A")
        {
            // No existe A+; A- si el último dígito < 3 y percent >= 90
            if (lastDigit < 3 && percent >= 90)
            {
                sign = "-";
            }
        }
        else if (letter == "F")
        {
            // No existe F+ ni F-
            sign = "";
        }
        else
        {
            // Para B, C, D: + si >=7 ; - si <3 ; sin signo en otro caso
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Imprimir una sola vez la calificación con signo (core + stretch)
        Console.WriteLine($"Your grade is {letter}{sign}.");

        // Mensaje de aprobado/reprobado (core)
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard, you can do it next time!");
        }
    }
}
