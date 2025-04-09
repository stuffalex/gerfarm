using GerFarm.Dominio.Pecuaria;
using GerFarm.Dominio.Pecuaria.Servicos;

namespace Testes.Pecuaria.Servicos
{
    [TestFixture]
    public class ServicoDeRegistroDeNascimentoTeste
    {
        private Raca _raca;
        private DateTime _dataDeNascimento;
        private decimal _peso;
        private string _historicoDeSaude;
        private string _marca;
        private IServicoDeRegistroDeNascimento _servico;
        private Bovino _mae;

        [SetUp]
        public void Setup()
        {
            _raca = Raca.Angus;
            _peso = 150.350m;
            _historicoDeSaude = "lorem ipsum, saudável";
            _marca = "G";
            _dataDeNascimento = DateTime.Today;
            _servico = new ServicoDeRegistroDeNascimento(); 
            _mae = BovinoBuilder.UmBovino().Build();
        }

        [Test]
        public void DeveRegistrarOFilhote()
        {
            var filhote = _servico.RegistrarFilho(_mae, _raca, _peso, _historicoDeSaude, _marca);

            Assert.Multiple(() =>
            {
                Assert.That(filhote, Is.Not.Null);
                Assert.That(filhote.Mae, Is.EqualTo(_mae));
                Assert.That(_mae.Filhos, Contains.Item(filhote));
            });
        }

        [Test]
        public void DeveEstabelecerRelacaoMaeFilhoCorretamente()
        {
            var mae = new Bovino(Raca.Angus, DateTime.Today.AddYears(-5), 600, "Saudável", "M1");
            
            var filhote = _servico.Registrar(mae, Raca.Angus, 35, "Saudável", "F1");
            
            Assert.Multiple(() =>
            {
                Assert.That(filhote.Mae, Is.EqualTo(mae));
                Assert.That(mae.Filhos, Contains.Item(filhote));
                Assert.That(mae.EhMae, Is.True);
            });
        }

        [Test]
        public void DeveLancarExcecaoQuandoMaeEhNula()
        {
            var ex = Assert.Throws<ValidacaoDeDominio>(() => _servico.Registrar(null, _raca, _peso, _historicoDeSaude, _marca));
            
            Assert.That(ex.Message, Is.EqualTo("Mãe não pode ser vazio ou nulo."));
        }

        [Test]
        public void DeveDefinirDataDeNascimentoComoDataAtual()
        {
            var filhote = _servico.Registrar(_mae, _raca, _peso, _historicoDeSaude, _marca);

            Assert.That(filhote.DataDeNascimento, Is.EqualTo(DateTime.Today));
        }
    }
}
