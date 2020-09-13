using AutoMapper;

using Locadora.Domain;
using Locadora.Domain.Features.Movies;
using Locadora.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Features.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly RentalContext rentalContext;
        private readonly IMapper mapper;

        public MovieRepository(RentalContext rentalContext, IMapper mapper)
        {
            this.rentalContext = rentalContext;
            this.mapper = mapper;
        }

        public async Task<int> Add(Movie entity)
        {
            rentalContext.Movies.Add(entity);

            await rentalContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(int id)
        {
            Movie movie = await GetById(id);

            if (movie != null)
            {
                rentalContext.Movies.Remove(movie);

                await rentalContext.SaveChangesAsync();
            }
        }

        public async Task Delete(IEnumerable<int> ids)
        {
            foreach (int id in ids)
            {
                await Delete(id);
            }
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await rentalContext.Movies.ToListAsync();
        }

        public Task<Movie> GetById(int id)
        {
            return rentalContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(Movie entity)
        {
            Movie movieInstance = await GetById(entity.Id);

            if (movieInstance != null)
            {
                mapper.Map(entity, movieInstance);

                rentalContext.Movies.Update(movieInstance);

                await rentalContext.SaveChangesAsync();
            }
        }
    }
}
