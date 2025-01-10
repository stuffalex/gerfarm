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

        [SetUp]
        public void Setup()
        {
            _raca = Raca.Angus;
            _peso = 150.350m;
            _historicoDeSaude = "lorem ipsum, saudável";
            _marca = "G";
            _dataDeNascimento = DateTime.Today;
            _servico = new ServicoDeRegistroDeNascimento();
        }

        [Test]
        public void DeveCriarUmBovino()
        {
            var bovino = _servico.Registrar(_raca, _peso, _historicoDeSaude, _marca);

            Assert.Multiple(() =>
            {
                Assert.That(bovino.Raca, Is.EqualTo(_raca), "A raça do bovino está incorreta.");
                Assert.That(bovino.Peso, Is.EqualTo(_peso), "O peso do bovino está incorreto.");
                Assert.That(bovino.HistoricoDeSaude, Is.EqualTo(_historicoDeSaude), "O histórico de saúde do bovino está incorreto.");
                Assert.That(bovino.Marca, Is.EqualTo(_marca), "A marca do bovino está incorreta.");
                Assert.That(bovino.DataDeNascimento, Is.EqualTo(_dataDeNascimento), "A data de nascimento do bovino está incorreta.");
            });
        }
    }
}
