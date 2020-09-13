using AutoMapper;

using Locadora.Domain.Features.Rents;
using Locadora.Infra.Data.Contexts;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Features.Rents
{
    public class RentRepository : IRentRepository
    {
        private readonly RentalContext rentalContext;
        private readonly IMapper mapper;

        public RentRepository(RentalContext rentalContext, IMapper mapper)
        {
            this.rentalContext = rentalContext;
            this.mapper = mapper;
        }

        public async Task<int> Add(Rent entity)
        {
            rentalContext.Rents.Add(entity);

            await rentalContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(int id)
        {
            Rent rent = await GetById(id);

            rentalContext.Rents.Remove(rent);

            await rentalContext.SaveChangesAsync();
        }

        public async Task Delete(IEnumerable<int> ids)
        {
            rentalContext.Rents.RemoveRange(rentalContext.Rents.Where(r => ids.Contains(r.Id)));

            await rentalContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await rentalContext.Rents
                                        .Include(r => r.RentMovies)
                                        .Include(r => r.Customer)
                                        .ToListAsync();
        }

        public Task<Rent> GetById(int id)
        {
            return rentalContext.Rents.Include(r => r.RentMovies).Include(r => r.Customer).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rent> Update(Rent entity)
        {
            Rent rentInstance = await GetById(entity.Id);

            if (rentInstance != null)
            {
                mapper.Map(entity, rentInstance);

                rentalContext.Rents.Update(rentInstance);

                await rentalContext.SaveChangesAsync();
            }

            return rentInstance;
        }
    }
}
