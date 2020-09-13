using Locadora.Domain;
using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Features.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IGenreRepository genreRepository;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            this.movieRepository = movieRepository;
            this.genreRepository = genreRepository;
        }

        public async Task<int> Add(Movie entity)
        {
            entity.Genre = await genreRepository.GetById(entity.Genre.Id);

            return await movieRepository.Add(entity);
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

        public Task Update(Movie entity)
        {
            return movieRepository.Update(entity);
        }
    }
}
