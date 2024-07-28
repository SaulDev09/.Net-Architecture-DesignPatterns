using Dapper;
using Saul.Test.Domain.Entity;
using Saul.Test.Infrastructure.Data;
using Saul.Test.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Saul.Test.Infrastructure.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;

        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "SELECT CategoryID, CategoryName, Description, Picture FROM dbo.Categories";
                var result = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
                return result;
            }
        }
    }
}
