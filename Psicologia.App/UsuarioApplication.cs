using Psicologia.Database.Repositorios;
using Psicologia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psicologia.App
{
    public class UsuarioApplication
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        public UsuarioApplication(UsuarioRepositorio leilaoRepositorio)
        {
            _usuarioRepositorio = leilaoRepositorio;
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            try
            {
                var lista = await _usuarioRepositorio.ListarUsuarios();
                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}
