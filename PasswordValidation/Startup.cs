using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordValidation.Rules;
using PasswordValidation.Rules.Implementations;
using PasswordValidation.Rules.Interfaces;
using PasswordValidation.Specifications.Implementation;
using PasswordValidation.Specifications.Interfaces;

namespace PasswordValidation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
            services.AddControllers();
            
            // add dependency injections here
            
            // Specifications
            services.AddTransient<IHasAtLeastOneDigit, HasAtLeastOneDigit>();
            services.AddTransient<IHasAtLeastOneLetter, HasAtLeastOneLetter>();
            services.AddTransient<ILengthMinimumFiveMaximumTwelve, LengthMinimumFiveMaximumTwelve>();
            services.AddTransient<ILowercaseLettersOnly, LowercaseLettersOnly>();

            // Rules
            services.AddTransient<IHasAtLeastOneDigitRule, HasAtLeastOneDigitRule>();
            services.AddTransient<IHasAtLeastOneLetterRule, HasAtLeastOneLetterRule>();
            services.AddTransient<ILengthMinimumFiveMaximumTwelveRule, LengthMinimumFiveMaximumTwelveRule>();
            services.AddTransient<ILowercaseLettersOnlyRule, LowercaseLettersOnlyRule>();

            // Validator
            services.AddTransient<IValidator<string>, PasswordValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
