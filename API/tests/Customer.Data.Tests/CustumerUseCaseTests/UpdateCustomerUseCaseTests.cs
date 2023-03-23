using AutoFixture;
using Customer.Data.Tests.Context;
using Customer.Data.UseCases;

namespace Customer.Data.Tests.CustumerUseCaseTests
{
    public class UpdateCustomerUseCaseTests
    {
        [Fact]
        public async Task ShouldUpdateCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            mockDatabase.Add(customerFixture);
            await mockDatabase.SaveChangesAsync();

            var useCase = new UpdateCustomerUseCase(mockDatabase);

            customerFixture.Name= "test";

            var result = await useCase.Execute(customerFixture);

            Assert.True(result.Result);
        }

        [Fact]
        public async Task ShouldNotUpdateCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();
            customerFixture.Id = Guid.Empty;

            var useCase = new UpdateCustomerUseCase(mockDatabase);

            var result = await useCase.Execute(customerFixture);

            Assert.False(result.Result);
        }
    }
}
