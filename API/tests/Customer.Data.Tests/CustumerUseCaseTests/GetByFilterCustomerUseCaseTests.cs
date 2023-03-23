using AutoFixture;
using Customer.Data.Tests.Context;
using Customer.Data.UseCases;
using Customer.Domain.DTO;

namespace Customer.Data.Tests.CustumerUseCaseTests
{
    public class GetByFilterCustomerUseCaseTests
    {
        [Fact]
        public async Task ShouldGetByFilterCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            mockDatabase.Add(customerFixture);
            await mockDatabase.SaveChangesAsync();

            var useCase = new GetByFilterCustomerUseCase(mockDatabase);

            var query = new CustomerQuery
            {
                Cpf = customerFixture.Cpf,
                Name = customerFixture.Name,
            };

            var result = await useCase.Execute(query);

            Assert.Single(result.Result);
        }

        [Fact]
        public async Task ShouldNotGetByFilterCustomer()
        {
            var mockDatabase = await ContextFake.Gerar();
            var fixture = new Fixture();
            var useCase = new GetByFilterCustomerUseCase(mockDatabase);
            var customerFixture = fixture.Create<Customer.Domain.Models.Customer>();

            mockDatabase.Add(customerFixture);
            await mockDatabase.SaveChangesAsync();
            var query = new CustomerQuery
            {
                Cpf = "001001000100",
                Name = "test",
            };

            var result = await useCase.Execute(query);

            Assert.Empty(result.Result);
        }
    }
}
