using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicologia.App;

namespace ExemploApiNetCore8.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioApplication _usuarioApplication;

        public UsuarioController(UsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [Route("listar")]
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var listaUsuarios = await _usuarioApplication.ListarUsuarios();
                return Ok(listaUsuarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
