using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Interface;

namespace Repository
{
   public class ConfigureService
    {
        public static void RegisteredService(IServiceCollection Services,IConfiguration Configuration )
        {
            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
            });


            Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            Services.AddScoped<IRegionsRepo, RegionsRepo>();

        }
    }
}
