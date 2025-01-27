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

        // Ajusta a idade se a pessoa ainda não fez aniversário no ano atual.
        if (DataDeNascimento.Date > hoje.AddYears(-idade))
        {
            idade--;
        }

        return idade;
    }

    private string CalculaIdadeDetalhada()
    {
        var hoje = DateTime.Today;

        // Calcula a diferença de anos, meses e dias
        int anos = hoje.Year - DataDeNascimento.Year;
        int meses = hoje.Month - DataDeNascimento.Month;
        int dias = hoje.Day - DataDeNascimento.Day;

        // Ajusta os meses se necessário
        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        // Ajusta os dias se necessário
        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(hoje.Year, hoje.Month == 1 ? 12 : hoje.Month - 1);
        }

        return $"{anos} ano(s), {meses} mes(es) e {dias} dia(s)";
    }
}