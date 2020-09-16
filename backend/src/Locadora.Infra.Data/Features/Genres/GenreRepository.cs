using Dapper;

using Locadora.Domain.Features.Genres;

using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Infra.Data
{
    public sealed class GenreRepository : IGenreRepository, IDisposable
    {
        // Utilizando dapper para fazer as consultas no banco de dados
        private readonly SqlConnection sqlConnection;
        private bool disposed;

        public GenreRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public Task<int> Add(Genre entity)
        {
            return sqlConnection.QuerySingleAsync<int>(@"insert into Genres(Name, CreationDate, Active) values (@Name, @CreationDate, @Active);
                                                select cast(SCOPE_IDENTITY() as int)", entity);
        }

        public Task Delete(int id)
        {
            return sqlConnection.ExecuteAsync("delete from Genres where Id = @Id", new { Id = id });
        }

        public Task Delete(IEnumerable<int> ids)
        {
            return sqlConnection.ExecuteAsync("delete from Genres where Id in @Ids", new { Ids = ids });
        }

        public void Dispose()
        {
            if (!disposed)
            {
                sqlConnection.Dispose();
            }

            disposed = true;
        }

        public Task<IEnumerable<Genre>> GetAll()
        {
            return sqlConnection.QueryAsync<Genre>("select * from Genres");
        }

        public Task<Genre> GetById(int id)
        {
            return sqlConnection.QuerySingleAsync<Genre>("select * from Genres where Id = @Id", new { Id = id });
        }

        public async Task<Genre> Update(Genre entity)
        {
            await sqlConnection.ExecuteAsync("update Genres set Name = @Name, CreationDate = @CreationDate, Active = @Active where Id = @Id", entity);

            return await GetById(entity.Id);
        }
    }
}
