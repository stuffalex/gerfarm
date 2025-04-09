namespace GerFarm.Dominio.Pecuaria.Servicos
{
    public class ServicoDeRegistroDeNascimento : IServicoDeRegistroDeNascimento
    {
        //To Do: deve obter a mae por "codigo" para realizar o registro do filho
        public Bovino Registrar(Bovino mae, Enum raca, decimal peso, string historicoDeSaude, string marca)
        {
            if (mae == null)
                throw new ValidacaoDeDominio.Quando(mae == null, "Mãe não pode ser vazio ou nulo.");

            var filhote = new Bovino(raca, DateTime.Today, peso, historicoDeSaude, marca);
            mae.RegistrarFilho(filhote);
            return filhote;
        }
    }
}
