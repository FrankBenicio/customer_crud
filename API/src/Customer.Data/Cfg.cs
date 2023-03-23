using Customer.Data.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Data
{
    public static class Cfg
    {
        public static void AddCfgData(this IServiceCollection services)
        {
            services.AddTransient<ICreateCustomer, CreateCustomerUseCase>();
            services.AddTransient<IUpdateCustomer, UpdateCustomerUseCase>();
            services.AddTransient<IGetAllCustomer, GetAllCustomerUseCase>();
            services.AddTransient<IRemoveCustomer, RemoveCustomerUseCase>();
            services.AddTransient<IGetByIdCustomer, GetByIdCustomerUseCase>();
            services.AddTransient<IGetByFilterCustomer, GetByFilterCustomerUseCase>();
        }
    }
}
