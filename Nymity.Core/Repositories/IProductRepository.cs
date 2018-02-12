using Nymity.Core.Entities;
using System.Collections.Generic;

namespace Nymity.Core.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Get(int id);
    }
}
