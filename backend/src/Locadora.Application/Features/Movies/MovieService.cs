using Locadora.Domain;
using Locadora.Domain.Features.Movies;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public Task<int> Add(Movie entity)
        {
            /* Por enquanto não estamos fazendo nada além de retornar o id do genêro inserido no repositório.
            * Mas esse serviço é responsável por mapear a entidade se ela não estiver no formato esperado pelo repositório,
            * se vier no formato do CQRS por exemplo.
            * Aqui também é o local responsável por chamar outros repositórios caso seja necessário.
            */

            return movieRepository.Add(entity);
        }

        public Task Delete(int id)
        {
            return movieRepository.Delete(id);
        }

        public Task Delete(IEnumerable<int> ids)
        {
            return movieRepository.Delete(ids);
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            return movieRepository.GetAll();
        }

        public Task<Movie> GetById(int id)
        {
            return movieRepository.GetById(id);
        }

        public Task<Movie> Update(Movie entity)
        {
            return movieRepository.Update(entity);
        }
    }
}
