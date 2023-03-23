using AutoFixture;
using Customer.Data.Tests.Context;
using Customer.Data.UseCases;

namespace Customer.Data.Tests.CustumerUseCaseTests
{
    public class CreateCustomerUseCaseTests
    {
        [Fact]
        public async Task ShouldCreateCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            var useCase = new CreateCustomerUseCase(mockDatabase);

            var result = await useCase.Execute(customerFixture);

            Assert.True(result.Result);
        }

        [Fact]
        public async Task ShouldNotCreateCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();
            customerFixture.Name = string.Empty;

            var useCase = new CreateCustomerUseCase(mockDatabase);

            var result = await useCase.Execute(customerFixture);

            Assert.False(result.Result);
        }
    }
}
