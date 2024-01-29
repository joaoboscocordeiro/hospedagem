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
            var capacidade = Suite.Capacidade >= hospedes.Count;
            if (capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("A capacidade de hospedes indisponível, entrar em contato com a recepção.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int propriedade = Hospedes.Count;
            return propriedade;
        }

        public decimal CalcularValorDiaria()
        {
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            var desconto = DiasReservados >= 10;
            if (desconto)
            {
                valor = valor * 0.90M;
            }

            return valor;
        }
    }
}