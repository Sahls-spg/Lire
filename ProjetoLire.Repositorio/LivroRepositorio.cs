using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoLire.Dominio.Entidades;
using ProjetoLire.Repositorio.Contexto;
using ProjetoLire.Repositorio.Interfaces;

namespace ProjetoLire.Repositorio
{
    public class LivroRepositorio : BaseRepositorio, ILivroRepositorio
    {
        public LivroRepositorio(ProjetoLireContexto contexto) :base(contexto)
        {
             
        }

        public async Task Cadastrar(Livro livro)
        {
            var parametros = new { livro.Titulo, livro.Autor, livro.GeneroLiterario, livro.QuantidadeDePaginas, livro.Sinopse, livro.ImagemCapa };
            await _contexto.Database.GetDbConnection().ExecuteAsync("spCadastrarLivros", parametros,commandType:CommandType.StoredProcedure);
        }

        public async Task Atualizar(Livro livro)
        {
            var parametros = new { livro.Id, livro.Titulo, livro.Autor, livro.GeneroLiterario, livro.QuantidadeDePaginas, livro.Sinopse };
            await _contexto.Database.GetDbConnection().ExecuteAsync("spAtualizarLivros", parametros,commandType:CommandType.StoredProcedure);
        }

        public async Task Deletar(Livro livro)
        {
            var parametros = new { Id = livro.Id};
            await _contexto.Database.GetDbConnection().ExecuteAsync("spDeletarLivros", parametros,commandType:CommandType.StoredProcedure);
        }

        public async Task<Livro> ObterPeloId(int livroId)
        {
            var parametros = new { LivroId = livroId};
            return await _contexto.Database.GetDbConnection().QueryFirstOrDefaultAsync<Livro>("spObterLivroPorID", parametros,commandType:CommandType.StoredProcedure);
        }

        public async Task<List<Livro>> Listar()
        {
            var livros = await _contexto.Database.GetDbConnection().QueryAsync<Livro>("SELECT * FROM vwListarLivros");
            return livros.ToList();
        }
    }
}