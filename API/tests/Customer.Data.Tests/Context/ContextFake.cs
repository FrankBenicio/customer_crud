using Customer.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Tests.Context
{
    public static class ContextFake
    {
        public static async Task<CustomerContext> Gerar()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new CustomerContext(options);

            return await Task.FromResult(context);
        }
    }
}
