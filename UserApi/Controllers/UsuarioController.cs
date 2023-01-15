using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using UserApi.Models;
using UserApi.Repository.Interfaces;

namespace UserApi.Controllers
{
    /// <summary>
    /// Essa classe controla as requisições e resposta a serem enviadas para uma camada de visualização ou outra API...
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Injeção de Dependência. Injeta a Interface como Dependência, e quando a requisição bate em um método da interface, o AddScoped
        // declarado em Program.cs instancia a classe UsuarioRepository e ativa o mesmo serviço.
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // O tipo Task é usado para referenciar um método assíncrono que retorna uma promisse, ou seja, um callback.
        // O tipo ActionResult é usado para dar tipos de retornos, como retornos de falha, de sucesso, de não encontrado e etc.
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> CadastrarUsuario([FromBody] UsuarioModel usuario)
        {
            var result = await _usuarioRepository.CadastrarUsuario(usuario);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> TrazerTodosUsuarios()
        {
            var result = await _usuarioRepository.TrazerTodosUsuarios();
            return Ok(result.Take(10));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> TrazerUsuarioPorId([FromRoute]int id)
        {
            var result = await _usuarioRepository.TrazerUsuarioPorId(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UsuarioModel>> EditarUsuario(int id, UsuarioModel usuario)
        {
            var result = await _usuarioRepository.EditarUsuario(id, usuario);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletarUsuarios(int id) {
            var result = await _usuarioRepository.DeletarUsuario(id);
            if (result)
                return Ok("Usuario excluído com sucesso!");
            return BadRequest();
        }
    }
}
