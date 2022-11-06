namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private HashSet<string> veiculos = new HashSet<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            int numeroDeVagas = 5;

            if (veiculos.Count == numeroDeVagas)
            {
                Console.WriteLine("Desculpe. O estacionamento está lotado.");
            }
            else
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine();

                if(veiculos.Contains(placa))
                {
                    Console.WriteLine("Um veículo com esta placa já está estacionado aqui. \nConfira se digitou a placa corretamente");
                }
                veiculos.Add(placa);
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                decimal horas = 0m;
                bool validarHoras = Decimal.TryParse(Console.ReadLine(), out horas);

                if(validarHoras)
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas; 
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, informe um número válido");
                }

            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
