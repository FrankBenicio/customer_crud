using AutoFixture;
using Customer.Data.Tests.Context;
using Customer.Data.UseCases;

namespace Customer.Data.Tests.CustumerUseCaseTests
{
    public class RemoveCustomerUseCaseTests
    {
        [Fact]
        public async Task ShouldRemoveCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            mockDatabase.Add(customerFixture);
            await mockDatabase.SaveChangesAsync();

            var useCase = new RemoveCustomerUseCase(mockDatabase);

            var result = await useCase.Execute(customerFixture.Id);

            Assert.True(result.Result);
        }

        [Fact]
        public async Task ShouldNotRemoveCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            mockDatabase.Add(customerFixture);
            await mockDatabase.SaveChangesAsync();

            var useCase = new RemoveCustomerUseCase(mockDatabase);

            var result = await useCase.Execute(Guid.NewGuid());

            Assert.False(result.Result);
        }
    }
}
