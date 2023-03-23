using AutoFixture;
using Customer.Data.Tests.Context;
using Customer.Data.UseCases;

namespace Customer.Data.Tests.CustumerUseCaseTests
{
    public class GetAllCustomerUseCaseTests
    {
        [Fact]
        public async Task ShouldGetAllCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            mockDatabase.Add(customerFixture);
            await mockDatabase.SaveChangesAsync();

            var useCase = new GetAllCustomerUseCase(mockDatabase);

            var result = await useCase.Execute();

            Assert.Single(result.Result);
        }

        [Fact]
        public async Task ShouldNotGetAllCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();

            var useCase = new GetAllCustomerUseCase(mockDatabase);

            var result = await useCase.Execute();

            Assert.Empty(result.Result);
        }
    }
}
