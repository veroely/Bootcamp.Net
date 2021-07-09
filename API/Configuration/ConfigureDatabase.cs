using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Data;

namespace API.Configuration
{
    public static class ConfigureDatabase
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<ToDoContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("BootcampToDo")));
    }
}
