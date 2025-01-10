using System;

namespace GerFarm.Model.Pecuaria;
public class Bovino
{
    public Enum Raca { get; protected set; }
    public int Idade { get; protected set; }
    public decimal Peso { get; protected set; }
    public string HistoricoDeSaude { get; protected set; }
    public string Marca { get; protected set; }
    public bool Marcado => Marca != null && Marca != "";
    public bool Falecido { get; protected set; }

    public Bovino(Enum raca, int idade, decimal peso, string historicoDeSaude, string marca)
    {
        Raca = raca;
        Idade = idade;
        Peso = peso;
        HistoricoDeSaude = historicoDeSaude;
        Marca = marca;
    }
}