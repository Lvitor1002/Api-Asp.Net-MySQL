using WebApplicationMYSQL.Models;

namespace WebApplicationMYSQL.Repository.Interfaces
{
    public interface IColaboradoRepository
    {
        Task<Colaborador> Adicionar(Colaborador colaborador);
        Task<Colaborador> BuscarColaborador(int id);
        Task<List<Colaborador>> BuscarTodosColaboradores(int numeroDaPagina, int qtdDados);
        Task<Colaborador> AtualizarColaborador(Colaborador colaboradorModel, int id);
        Task<bool> RemoverColaborador(int id);
    }
}
