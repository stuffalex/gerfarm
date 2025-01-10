namespace GerFarm.Dominio.Pecuaria.Servicos
{
    public interface IServicoDeRegistroDeNascimento
    {
        public Bovino Registrar(Enum raca, decimal peso, string historicoDeSaude, string marca);
    }
}
