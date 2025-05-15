using Microsoft.EntityFrameworkCore;
using WebApplicationMYSQL.Data;
using WebApplicationMYSQL.Models;
using WebApplicationMYSQL.Repository.Interfaces;
namespace WebApplicationMYSQL.Repository
{
    public class ColaboradorRepository : IColaboradoRepository
    {
        private readonly ColaboradoresDB _colaboradoresDB;

        public ColaboradorRepository(ColaboradoresDB colaboradoresDB)
        {
            _colaboradoresDB = colaboradoresDB;
        }


        public async Task<Colaborador> Adicionar(Colaborador colaborador)
        {
            await _colaboradoresDB.AddAsync(colaborador);
            await _colaboradoresDB.SaveChangesAsync();
            return colaborador;
        }
        public async Task<Colaborador> BuscarColaborador(int id)
        {
            return await _colaboradoresDB.Colaborador.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Colaborador>> BuscarTodosColaboradores(int numeroDaPagina, int qtdDados)
        {
            //numeroDaPagina*quantidadePaginas <- Paginação. Trás exatamente o n° de páginas desejada
            return await _colaboradoresDB.Colaborador.Skip((numeroDaPagina-1) * qtdDados).Take(qtdDados).ToListAsync();
        }

        public async Task<Colaborador> AtualizarColaborador(Colaborador colaboradorModel,int id)
        {
            Colaborador colaborador_Id = await BuscarColaborador(id);
            if (colaborador_Id == null) {
                throw new Exception($"Colaborador de id '{id}' não encontrado no banco de dados.");
            }

            colaborador_Id.Id = colaboradorModel.Id;
            colaborador_Id.Nome = colaboradorModel.Nome;
            colaborador_Id.Idade = colaboradorModel.Idade;

            _colaboradoresDB.Colaborador.Update(colaborador_Id);
            await _colaboradoresDB.SaveChangesAsync();
            return colaborador_Id;

        }


        public async Task<bool> RemoverColaborador(int id)
        {
            Colaborador colaborador_Id = await BuscarColaborador(id);
            if (colaborador_Id == null) {
                throw new Exception($"Colaborador de id '{id}' não encontrado no banco de dados");
            }
            _colaboradoresDB.Colaborador.Remove(colaborador_Id);
            await _colaboradoresDB.SaveChangesAsync();
            return true;
        }
    }
}
