using Microsoft.EntityFrameworkCore;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Domain.Entities;
using Saul.Test.Persistence.Contexts;
using Saul.Test.Persistence.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Saul.Test.Persistence.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        public DiscountRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Insert(Discount entity)
        {
            _applicationDbContext.Add(entity);
            return await Task.FromResult(true);
        }

        public async Task<bool> Update(Discount discount)
        {
            var entity = await _applicationDbContext.Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(discount.Id));
            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            entity.Name = discount.Name;
            entity.Description = discount.Description;
            entity.Percent = discount.Percent;
            entity.Status = discount.Status;
            _applicationDbContext.Update(entity);

            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await _applicationDbContext.Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(int.Parse(id)));

            if (entity == null)
            {
                return await Task.FromResult(false);
            }

            _applicationDbContext.Remove(entity);
            return await Task.FromResult(true);

        }

        public async Task<List<Discount>> GetAll(CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Set<Discount>()
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Discount> Get(int id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext
                .Set<Discount>()
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }


        public Task<Discount> Get(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Discount>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var faker = new DiscountGetAllWithPaginationBogusConfig();
            var result = await Task.Run(() => faker.Generate(1000));
            return result.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        public async Task<int> Count()
        {
            return await Task.Run(() => 1000);
        }
        public Task<IEnumerable<Discount>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
