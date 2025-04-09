using GerFarm.Dominio.Bovino;

namespace Testes.Pecuaria.Helper
{
    public class BovinoBuilder
    {
        private string _nome;
        private DateTime _dataDeNascimento;
        private Enum _raca;
        private decimal _peso;
        private string _historicoDeSaude;
        private string _marca;
        private bool _falecido;
        private DateTime? _dataDeFalecimento;
        private List<Bovino> _filhos = new List<Bovino>();
        private bool _mae;

        public Bovino Build()
        {
            return new Bovino
            {
                Nome = _nome,
                DataDeNascimento = _dataDeNascimento,
                Raca = _raca,
                Peso = _peso,
                HistoricoDeSaude = _historicoDeSaude,
                Marca = _marca,
                Falecido = _falecido,
                DataDeFalecimento = _dataDeFalecimento,
                Filhos = _filhos,
                Mae = _mae
            };
        }
        
        public static BovinoBuilder UmBovino()
        {
            return new BovinoBuilder
            {
                _nome = "Bovino Padrão",
                _dataDeNascimento = DateTime.Now.AddYears(-2),
                _raca = default(Enum),
                _peso = 500m,
                _historicoDeSaude = "Saudável",
                _marca = "Marca Padrão",
                _filhos = new List<Bovino>(),
                _mae = true
            };
        }
        
        public BovinoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public BovinoBuilder ComDataDeNascimento(DateTime dataDeNascimento)
        {
            _dataDeNascimento = dataDeNascimento;
            return this;
        }

        public BovinoBuilder ComRaca(Enum raca)
        {
            _raca = raca;
            return this;
        }

        public BovinoBuilder ComPeso(decimal peso)
        {
            _peso = peso;
            return this;
        }

        public BovinoBuilder ComHistoricoDeSaude(string historicoDeSaude)
        {
            _historicoDeSaude = historicoDeSaude;
            return this;
        }

        public BovinoBuilder ComMarca(string marca)
        {
            _marca = marca;
            return this;
        }

        public BovinoBuilder MarcadoComoFalecido(DateTime? dataDeFalecimento)
        {
            _falecido = true;
            _dataDeFalecimento = dataDeFalecimento;
            return this;
        }

        public BovinoBuilder ComFilhos(List<Bovino> filhos)
        {
            _filhos = filhos;
            return this;
        }

        public BovinoBuilder EhAMae()
        {
            _mae = true;
            return this;
        }
    }
}