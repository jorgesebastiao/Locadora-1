using Locadora.Domain.Features.Genres;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Genres
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public Task<int> Add(Genre entity)
        {
            /* Por enquanto não estamos fazendo nada além de retornar o id do genêro inserido no repositório.
            * Mas esse serviço é responsável por mapear a entidade se ela não estiver no formato esperado pelo repositório,
            * se vier no formato do CQRS por exemplo.
            * Aqui também é o local responsável por chamar outros repositórios caso seja necessário.
            */

            return genreRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            return genreRepository.Delete(id);
        }

        public Task Delete(IEnumerable<int> ids)
        {
            return genreRepository.Delete(ids);
        }

        public Task<IEnumerable<Genre>> GetAll()
        {
            return genreRepository.GetAll();
        }

        public Task<Genre> GetById(int id)
        {
            return genreRepository.GetById(id);
        }

        public Task<Genre> Update(Genre entity)
        {
            return genreRepository.Update(entity);
        }
    }
}
