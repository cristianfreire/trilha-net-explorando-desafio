using System.ComponentModel.DataAnnotations;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            int qtdHospedes = hospedes.Count();
            int capacSuite = Suite.Capacidade;

            if (capacSuite >= qtdHospedes)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade da Suíte insuficiente");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                decimal desconto = valor / 100 * 10;
                valor = valor - desconto;
            }

            return valor;
        }
    }
}