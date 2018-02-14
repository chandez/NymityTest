using Dapper;
using Nymity.Core.Entities;
using Nymity.Core.Infrastructure;
using System.Collections.Generic;
using System.Data;

namespace Nymity.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        IConnectionFactory _connectionFactory;

        public ProductRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<Product> Get()
        {
            var query = @"SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM [dbo].[Products] ORDER BY ProductID";

            IEnumerable<Product> products;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                products = SqlMapper.Query<Product>(connection, query);
            }

            return products;
        }

        public Product Get(int id)
        {
            var query = @"SELECT ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued FROM [dbo].[Products] WHERE ProductID = @id";

            Product product;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                product = SqlMapper.QueryFirstOrDefault<Product>(connection, query, new { id });
            }

            return product;
        }
    }
}
