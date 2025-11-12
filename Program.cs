using System;
using System.IO;
class Program
{
    static void checkAge(int age)
    {
        if (age < 18)
        {
            Console.WriteLine("Acesso negado - Menor de Idade");
        }
        else
        {
            Console.WriteLine("Acesso concedido - Maior de Idade");
        }
    }
    static void Main(string[] args)
    {
      
        checkAge(27);
        Console.ReadLine();
    }
}