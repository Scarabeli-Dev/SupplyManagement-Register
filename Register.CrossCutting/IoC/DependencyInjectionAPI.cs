using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Register.Application.Mappings;
using Register.Application.Services;
using Register.Application.Services.Interfaces;
using Register.Infrastructure.Context;
using Register.Infrastructure.Repositories;
using Register.Infrastructure.Repositories.Interfaces;

namespace Register.CrossCutting.IoC;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<RegisterApiContext>(options =>
           options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                 new MySqlServerVersion(new Version(8, 0, 33))));

        //Auto Mapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        //Services
        services.AddScoped<IAddressingService, AddressingService>();
        services.AddScoped<IInventoryMovementService, InventoryMovementService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IItemsAddressingsService, ItemsAddressingsService>();
        services.AddScoped<IWarehouseService, WarehouseService>();

        //Repositories
        services.AddScoped<IGeneralRepository, GeneralRepository>();
        services.AddScoped<IAddressingRepository, AddressingRepository>();
        services.AddScoped<IInventoryMovementRepository, InventoryMovementRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemsAddressingsRepository, ItemsAddressingsRepository>();
        services.AddScoped<IWarehouseRepository, WarehouseRepository>();

        return services;
    }
}
