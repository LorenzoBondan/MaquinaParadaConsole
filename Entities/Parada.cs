using MaquinaParada.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaParada.Entities
{
    class Parada
    {
        public int Numero { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Final { get; set; }

        public Parada() { }

        public Parada(int numero, DateTime inicio, DateTime final)
        {
            if (final <= inicio)
            {
                throw new DomainException("O horário final deve ser maior que o inicial.");
            }

            Numero = numero;
            Inicio = inicio;
            Final = final;
        }

        public double Duracao()
        {
            TimeSpan duracao = Final.Subtract(Inicio);
            return (int)duracao.TotalMinutes;
        }

        public override string ToString()
        {
            return "\nParada: " + Numero
                + " - Início: " + Inicio.ToString("HH:mm")
                + " - Final: " + Final.ToString("HH:mm")
                + " - Duração: " + Duracao() + " minutos.";
        }


    }
}
