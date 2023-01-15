using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;
using UserApi.Repository.Interfaces;

namespace UserApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // Injeção de Dependência do Contexto de Banco de Dados.
        private readonly DatabaseContext _databaseContext;
        public UsuarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // O _databaseContext.Usuarios é referenciado pela propriedade DbSet na classe DatabaseContext,
        // O método AddAsync adiciona o usuario fornecido no Banco de Dados,
        // O método SaveChages() serve para salvas as alterações impostas no Banco de Dados, pois toda a alteração antes é feita em memória e somente
        // com o SaveChanges as alterações são feitas no Banco de Dados.
        public async Task<UsuarioModel> CadastrarUsuario(UsuarioModel usuario)
        {
            await _databaseContext.Usuarios.AddAsync(usuario);
            await _databaseContext.SaveChangesAsync();
            return usuario;
        }

        // O método Remove exclui dados em memória.
        public async Task<bool> DeletarUsuario(int id)
        {
            var result = await TrazerUsuarioPorId(id);
            if (result == null)
                throw new ArgumentException("Usuário não encontrado");
            _databaseContext.Usuarios.Remove(result);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        // O método Update() atualiza objeto passado em memória.
        public async Task<UsuarioModel> EditarUsuario(int id, UsuarioModel usuario)
        {
            var findedusuario = await TrazerUsuarioPorId(id);
            if (findedusuario == null)
                throw new ArgumentException("Usuário não encontrado.");
            findedusuario.Name = usuario.Name;
            findedusuario.Email = usuario.Email;
            findedusuario.Password = usuario.Password;
            _databaseContext.Usuarios.Update(findedusuario);
            _databaseContext.SaveChanges();
            return findedusuario;
        }

        // Para consultas não é necessário colocar o SaveChanges pois consultas não alteram o Banco de Dados,
        // O método ToListAsync() serve para trazer todos os Dados do Banco de Dados.
        public async Task<List<UsuarioModel>> TrazerTodosUsuarios()
        {
            return await _databaseContext.Usuarios.ToListAsync();
        }

        // O método FisrtOrDefault() traz o primeiro resultado que for encontrado através do lambda.
        public async Task<UsuarioModel> TrazerUsuarioPorId(int id)
        {
            var result = await _databaseContext.Usuarios.FirstOrDefaultAsync(usuario => usuario.Id == id);
            if (result != null)
                return result;
            throw new ArgumentException("Usuário não encontrado.");
        }
    }
}
