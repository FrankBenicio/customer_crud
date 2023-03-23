using AutoFixture;
using Customer.Data.Tests.Context;
using Customer.Data.UseCases;

namespace Customer.Data.Tests.CustumerUseCaseTests
{
    public class GetByIdCustomerUseCaseTests
    {
        [Fact]
        public async Task ShouldGetByIdCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            mockDatabase.Add(customerFixture);
            await mockDatabase.SaveChangesAsync();

            var useCase = new GetByIdCustomerUseCase(mockDatabase);

            var result = await useCase.Execute(customerFixture.Id);

            Assert.NotNull(result.Result);
        }

        [Fact]
        public async Task ShouldNotGetByIdCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();

            var useCase = new GetByIdCustomerUseCase(mockDatabase);

            var result = await useCase.Execute(Guid.NewGuid());

            Assert.Null(result.Result);
        }
    }
}
