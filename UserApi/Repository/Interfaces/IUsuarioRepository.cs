using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        //POST
        public Task<UsuarioModel> CadastrarUsuario(UsuarioModel usuario);
        //GET
        public Task<UsuarioModel> TrazerUsuarioPorId(int id);
        //GET
        public Task<List<UsuarioModel>> TrazerTodosUsuarios();
        //DELETE
        public Task<bool> DeletarUsuario(int id);
        //PUT
        public Task<UsuarioModel> EditarUsuario(int id, UsuarioModel usuario);

    }
}
