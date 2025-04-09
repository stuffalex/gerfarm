namespace Testes.Pecuaria;
using GerFarm.Dominio.Pecuaria;
using NUnit.Framework;

[TestFixture]
public class BovinoTeste
{
    private Bovino _bovino;
    private Raca _raca;
    private DateTime _dataDeNascimento;
    private decimal _peso;
    private string _historicoDeSaude;
    private string _marca;

    [SetUp]
    public void Setup()
    {
        _raca = Raca.Angus;
        _peso = 150.350m;
        _historicoDeSaude = "lorem ipsum, saudável";
        _marca = "G";
        _dataDeNascimento = new DateTime(2024, 10, 10);
        _bovino = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, _marca);
    }

    [Test]
    public void DeveCriarComRaca()
    {
        var raca = Raca.Nelore;

        var bovino = new Bovino(raca, _dataDeNascimento, _peso, _historicoDeSaude, _marca);

        Assert.That(raca, Is.EqualTo(bovino.Raca));
    }

    [Test]
    public void DeveCriarComPeso()
    {
        var peso = 200;

        var bovino = new Bovino(_raca, _dataDeNascimento, peso, _historicoDeSaude, _marca);

        Assert.That(peso, Is.EqualTo(bovino.Peso));
    }

    [Test]
    public void DeveCriarComDataDeNascimento()
    {
        var dataDeNascimento = new DateTime(10, 09, 2024);

        var bovino = new Bovino(_raca, dataDeNascimento, _peso, _historicoDeSaude, _marca);

        Assert.That(dataDeNascimento, Is.EqualTo(bovino.DataDeNascimento));
    }

    [Test]
    public void DeveCriarComHistoricoDeSaude()
    {
        var historicoDeSaude = "Com historico";

        var bovino = new Bovino(_raca, _dataDeNascimento, _peso, historicoDeSaude, _marca);

        Assert.That(historicoDeSaude, Is.EqualTo(bovino.HistoricoDeSaude));
    }

    [Test]
    public void DeveCriarComMarca()
    {
        var marca = "JJ";

        var bovino = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, marca);

        Assert.That(marca, Is.EqualTo(bovino.Marca));
    }

    [Test]
    public void DeveRetornarSeBovinoEstaMarcado()
    {
        var bovino = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, _marca);

        Assert.That(true, Is.EqualTo(bovino.Marcado));
    }

    [Test]
    public void DeveRetornarQueBovinoNaoEstaMarcado()
    {
        var marcaVazia = "";

        var bovino = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, marcaVazia);

        Assert.That(false, Is.EqualTo(bovino.Marcado));
    }

    [Test]
    public void DeveMarcarFalecimento()
    {
        _bovino.RegistrarFalecimento();

        Assert.That(true, Is.EqualTo(_bovino.Falecido));
    }

    [Test]
    public void DeveCalcularAIdadeDoBovino()
    {
        var idade = 3;
        var dataDeNascimento = DateTime.Now.AddYears(-3);

        var bovino = new Bovino(_raca, dataDeNascimento, _peso, _historicoDeSaude, _marca);

        Assert.That(idade, Is.EqualTo(bovino.Idade));
    }

    [Test]
    public void DeveCalcularAIdadeDetalhadaDoBovino()
    {
        var idade = "3 ano(s), 1 mes(es) e 0 dia(s)";
        var dataDeNascimento = DateTime.Now.AddYears(-3).AddMonths(-1);

        var bovino = new Bovino(_raca, dataDeNascimento, _peso, _historicoDeSaude, _marca);

        Assert.That(idade, Is.EqualTo(bovino.IdadeDetalhada));
    }

    [Test]
    public void DeveRetornarTrueQuandoTemFilhos(){
        var mae = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, _marca);
        var filhote = new Bovino(_raca, DateTime.Today, 30m, "Saudável", "F1");

        mae.RegistrarFilho(filhote);

        Assert.That(mae.EhMae, Is.True);
    }

    [Test]
    public void DeveRetornarFalseQuandoNaoTemFilhos(){
        var mae = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, _marca);

        Assert.That(mae.EhMae, Is.True);
    }

    [Test]
    public void NaoDeveAdicionarFilhoDuplicado(){
        var mae = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, _marca);
        var filhote = new Bovino(_raca, DateTime.Today, 30m, "Saudável", "F1");

        mae.RegistrarFilho(filhote);
        mae.RegistrarFilho(filhote);

        Assert.That(mae.Filhos.Count, Is.EqualTo(1));
    }

    [Test]
    public void DeveLancarExcecaoQuandoFilhoEhNulo()
    {
        var mae = new Bovino(_raca, _dataDeNascimento, _peso, _historicoDeSaude, _marca);

        Assert.Throws<ArgumentNullException>(() => mae.RegistrarFilho(null));
    }
}
