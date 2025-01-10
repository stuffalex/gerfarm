namespace Testes;
using NUnit.Framework;
using GerFarm.Model.Pecuaria;

[TestFixture]
public class BovinoTeste
{
    private Bovino _bovino;
    private Raca _raca;

    private int _idade;
    private decimal _peso;
    private string _historicoDeSaude;
    private string _marca;

    [SetUp]
    public void Setup()
    {
        _idade = 5;
        _raca = Raca.Angus;
        _peso = 150.350m;
        _historicoDeSaude = "lorem ipsum, saudável";
        _marca = "G";
        _bovino = new Bovino(_raca, _idade, _peso, _historicoDeSaude, _marca);
    }

    [Test]
    public void DeveCriarComRaca()
    {
        var raca = Raca.Nelore;

        Bovino bovino = new Bovino(raca, _idade, _peso, _historicoDeSaude, _marca);

        Assert.That(raca, Is.EqualTo(bovino.Raca));
    }

    [Test]
    public void DeveCriarComPeso()
    {
        var peso = 200;

        Bovino bovino = new Bovino(_raca, _idade, peso, _historicoDeSaude, _marca);

        Assert.That(peso, Is.EqualTo(bovino.Peso));
    }

    [Test]
    public void DeveCriarComIdade()
    {
        var idade = 2;

        Bovino bovino = new Bovino(_raca, idade, _peso, _historicoDeSaude, _marca);

        Assert.That(idade, Is.EqualTo(bovino.Idade));
    }

    [Test]
    public void DeveCriarComHistoricoDeSaude()
    {
        var historicoDeSaude = "Com historico";

        Bovino bovino = new Bovino(_raca, _idade, _peso, historicoDeSaude, _marca);

        Assert.That(historicoDeSaude, Is.EqualTo(bovino.HistoricoDeSaude));
    }

    [Test]
    public void DeveCriarComMarca()
    {
        var marca = "JJ";

        Bovino bovino = new Bovino(_raca, _idade, _peso, _historicoDeSaude, marca);

        Assert.That(marca, Is.EqualTo(bovino.Marca));
    }

    [Test]
    public void DeveRetornarSeBovinoEstaMarcado()
    {
        Bovino bovino = new Bovino(_raca, _idade, _peso, _historicoDeSaude, _marca);

        Assert.That(true, Is.EqualTo(bovino.Marcado));
    }

    [Test]
    public void DeveRetornarQueBovinoNaoEstaMarcado()
    {
        var marcaVazia = "";

        Bovino bovino = new Bovino(_raca, _idade, _peso, _historicoDeSaude, marcaVazia);

        Assert.That(false, Is.EqualTo(bovino.Marcado));
    }

}
