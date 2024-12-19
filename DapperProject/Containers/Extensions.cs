using DapperProject.Context;
using DapperProject.Repositories;
using System.Runtime.CompilerServices;

namespace DapperProject.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            
        }

    }
}
