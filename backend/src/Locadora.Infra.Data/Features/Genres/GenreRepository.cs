using AutoMapper;

using Locadora.Domain.Features.Genres;
using Locadora.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Infra.Data
{
    public class GenreRepository : IGenreRepository
    {
        // Não é necessário chamar o dispose do context pois a injeção de depêndencia vai tratar isso automaticamente
        private readonly RentalContext rentalContext;
        private readonly IMapper mapper;

        public GenreRepository(RentalContext rentalContext, IMapper mapper)
        {
            this.rentalContext = rentalContext;
            this.mapper = mapper;
        }

        public async Task<int> Add(Genre entity)
        {
            rentalContext.Genres.Add(entity);

            await rentalContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(int id)
        {
            Genre genreInstance = await GetById(id);

            if (genreInstance != null)
            {
                rentalContext.Genres.Remove(genreInstance);

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

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await rentalContext.Genres.ToListAsync();
        }

        public Task<Genre> GetById(int id)
        {
            return rentalContext.Genres.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task Update(Genre entity)
        {
            Genre genreInstance = await GetById(entity.Id);

            if (genreInstance != null)
            {
                mapper.Map(entity, genreInstance);

                await rentalContext.SaveChangesAsync();
            }
        }
    }
}
