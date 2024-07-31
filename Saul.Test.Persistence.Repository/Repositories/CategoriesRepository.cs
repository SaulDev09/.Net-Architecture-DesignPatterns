using Dapper;
using Saul.Test.Application.Interface.Persistence;
using Saul.Test.Domain.Entity;
using Saul.Test.Persistence.Contexts;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Saul.Test.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT CategoryID, CategoryName, Description, Picture FROM dbo.Categories";
                var result = await connection.QueryAsync<Category>(query, commandType: CommandType.Text);
                return result;
            }
        }
    }
}
