namespace GerFarm.Dominio.Pecuaria.Servicos
{
    public interface IServicoDeRegistroDeNascimento
    {
        public Bovino Registrar(Bovino mae, Enum raca, decimal peso, string historicoDeSaude, string marca);
    }
}
