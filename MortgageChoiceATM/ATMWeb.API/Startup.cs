using System.Text.Json.Serialization;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MediatR;

using ATMWeb.Persistence;
using ATMWeb.Application.Accounts.Queries.GetAccountDetail;
using ATMWeb.Application.Accounts.Queries.BalanceInquiry;

using ATMWeb.Application.Accounts.Command.Deposit;
using ATMWeb.Application.Accounts.Command.Withdrawal;

using ATMWeb.API.Interfaces;
using ATMWeb.API.Services;

namespace ATMWeb.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<ATMWebContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ATMWebConnection"));
            }, ServiceLifetime.Transient);


            services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
             });

            services.AddMvc(option => option.EnableEndpointRouting = false);

            //for testing only, needs to be secured
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200",
                                        "http://localhost:44309",
                                        "http://localhost:49932",
                                        "http://localhost:5000",
                                        "http://localhost:5001"
                                        )
                            .AllowAnyHeader()
                            .AllowAnyMethod()                            
                            .AllowCredentials();
                    
                });
            });

            //Scoped objects are the same within a request, but different across different requests.            
            services.AddScoped<IGetAccountDetail, GetAccountDetail>();            
            services.AddScoped<IAccountDeposit, AccountDeposit>();
            services.AddScoped<IAccountWithdrawal, AccountWithdrawal>();
            services.AddScoped<IBalanceInquiry, BalanceInquiry>();

            //for registering interface and service
            services.AddScoped<IAccountService, AccountService>();

            //for using mediatr
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            //enable cross-origin request
            app.UseCors(AllowSpecificOrigins);            

            app.UseMvc();

            //app.UseRouting();
            //app.UseAuthorization();

        }
    }
}

