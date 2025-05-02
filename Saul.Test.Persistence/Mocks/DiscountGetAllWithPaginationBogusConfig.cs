using Bogus;
using Saul.Test.Domain.Entities;
using Saul.Test.Domain.Enums;

namespace Saul.Test.Persistence.Mocks
{
    public class DiscountGetAllWithPaginationBogusConfig : Faker<Discount>
    {
        public DiscountGetAllWithPaginationBogusConfig()
        {
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
            RuleFor(p => p.Percent, f => f.Random.Int(70, 90));
            RuleFor(p => p.Status, f => f.PickRandom<DiscountStatus>());
        }
    }
}
