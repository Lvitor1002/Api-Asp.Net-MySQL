using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMYSQL.Models;
using WebApplicationMYSQL.Repository.Interfaces;

namespace WebApplicationMYSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {

        private readonly IColaboradoRepository _colaboradoRepository;

        public ColaboradorController(IColaboradoRepository colaboradoRepository)
        {
            _colaboradoRepository = colaboradoRepository;
        }


        // POST: Enviar dados ao servidor
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Colaborador>> Adicionar([FromBody] Colaborador colaboradorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Colaborador colaborador = await _colaboradoRepository.Adicionar(colaboradorModel);
            return Ok(colaborador);
        }


        // GET: Buscar ÚNICO usuários
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborador>> BuscarColaborador(int id)
        {
            Colaborador unico = await _colaboradoRepository.BuscarColaborador(id);
            return Ok(unico);
        }


        // GET: Buscar TODOS usuários
        [HttpGet]
        public async Task<ActionResult<List<Colaborador>>> BuscarTodosColaboradores(int numeroDaPagina, int qtdDados) {

            List<Colaborador> listaColaboradores = await _colaboradoRepository.BuscarTodosColaboradores(numeroDaPagina, qtdDados);
            return Ok(listaColaboradores);
        }


        // PUT: Atualizar dados
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Colaborador>> AtualizarColaborador([FromBody] Colaborador colaboradorModel, int id)
        {
            colaboradorModel.Id = id;
            Colaborador colaborador = await _colaboradoRepository.AtualizarColaborador(colaboradorModel, id);
            return Ok(colaborador);
        }


        // DELETE: Apagar dados
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> RemoverColaborador(int id)
        {
            bool apagado = await _colaboradoRepository.RemoverColaborador(id);
            return Ok(apagado);
        }
    }
}
