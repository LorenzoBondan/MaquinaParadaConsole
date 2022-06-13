using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaquinaParada.Entities.Exceptions;
using MaquinaParada.Entities;
using System.Linq.Expressions;

namespace MaquinaParada
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Parada> lista = new List<Parada>();

            Console.WriteLine("Quantas paradas?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                try
                {
                    Console.Write($"Número da parada {i}: ");
                    int numero = int.Parse(Console.ReadLine());

                    Console.Write($"Horário de início da parada {i}: ");
                    DateTime inicio = DateTime.Parse(Console.ReadLine());

                    Console.Write($"Horário de término da parada {i}: ");
                    DateTime final = DateTime.Parse(Console.ReadLine());

                    Parada parada = new Parada(numero, inicio, final);

                    lista.Add(parada);

                }
                catch (FormatException e) // colocar letra ao invés de número
                {
                    Console.WriteLine("Erro de inserção de dados: " + e.Message);
                }
                catch (DomainException e)
                {
                    Console.WriteLine("Erro de tempo de parada: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro não esperado: " + e.Message);
                }
            }

            // imprimindo 
            Console.WriteLine();
            foreach (Parada p in lista)
            {
                Console.WriteLine(p);
            }

            int maiorparada = (int)lista.Max(t => t.Duracao()); // SÓ TRAZ A DURAÇÃO
            Console.WriteLine("\nMaior parada: " + maiorparada);

            Console.ReadKey();
        }
    }
}
