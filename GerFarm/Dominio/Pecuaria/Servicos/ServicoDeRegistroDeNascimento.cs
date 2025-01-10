namespace GerFarm.Dominio.Pecuaria.Servicos
{
    public class ServicoDeRegistroDeNascimento : IServicoDeRegistroDeNascimento
    {
        public Bovino Registrar(Enum raca, decimal peso, string historicoDeSaude, string marca)
        {
            return new Bovino(raca, DateTime.Today, peso, historicoDeSaude, marca);
        }
    }
}
