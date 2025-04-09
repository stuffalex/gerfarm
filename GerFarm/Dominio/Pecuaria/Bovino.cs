using GerFarm.Dominio.Base;

namespace GerFarm.Dominio.Pecuaria;
public class Bovino : EntidadeBase<Bovino>
{
    public Enum Raca { get; private set; }
    public int Idade => CalculaIdade();
    public string IdadeDetalhada => CalculaIdadeDetalhada();
    public DateTime DataDeNascimento { get; private set; }
    public decimal Peso { get; private set; }
    public string HistoricoDeSaude { get; private set; }
    public string Marca { get; private set; }
    public bool Marcado => Marca != null && Marca != "";
    public bool Falecido { get; private set; }
    public DateTime? DataDeFalecimento { get; private set; }
    public List<Bovino> Filhos { get; private set; } = new List<Bovino>();
    public bool EhMae => Filhos.Count > 0;
    public Bovino? Mae { get; private set; }

    public Bovino(Enum raca, DateTime dataDeNascimento, decimal peso, string historicoDeSaude, string marca)
    {
        Raca = raca;
        DataDeNascimento = dataDeNascimento;
        Peso = peso;
        HistoricoDeSaude = historicoDeSaude;
        Marca = marca;
    }

    public void RegistrarFalecimento()
    {
        Falecido = true;
        DataDeFalecimento = DateTime.Now;
    }

    private int CalculaIdade()
    {
        var hoje = DateTime.Today;
        var idade = hoje.Year - DataDeNascimento.Year;

        // Ajusta a idade se a pessoa ainda n�o fez anivers�rio no ano atual.
        if (DataDeNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }

        return idade;
    }

    private string CalculaIdadeDetalhada()
    {
        var hoje = DateTime.Today;

        // Calcula a diferen�a de anos, meses e dias
        int anos = hoje.Year - DataDeNascimento.Year;
        int meses = hoje.Month - DataDeNascimento.Month;
        int dias = hoje.Day - DataDeNascimento.Day;

        // Ajusta os meses se necess�rio
        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        // Ajusta os dias se necess�rio
        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(hoje.Year, hoje.Month == 1 ? 12 : hoje.Month - 1);
        }

        return $"{anos} ano(s), {meses} mes(es) e {dias} dia(s)";
    }

    public void RegistrarFilho(Bovino filhote){
        ValidacaoDeDominio.Quando(filhote == null, "Filhote não pode ser vazio ou nulo.");

        if(!Filhos.Contains(filhote)){
            Filhos.add(filhote);
            filhote.DefinirMae(this);
        }
    }

    private void DefinirMae(Bovino mae)
    {
        this.Mae = mae;
    }
}