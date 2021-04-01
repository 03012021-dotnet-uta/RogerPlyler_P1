using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Data;

namespace PizzaBox
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
            services.AddControllers();
            
            //MockDataScoped
            //services.AddScoped<ICustomerData, MockCustomerData>();
            //services.AddScoped<IItemData, MockItemData>();
            //services.AddScoped<IStoreData, MockStoreData>();
            //services.AddScoped<IOrderData, MockOrderData>();
            //services.AddScoped<IOrderDetail, MockOrderDetails>();
            //services.AddScoped<IInventoryDetail, MockInventoryDetail>();

            //Actual Data
            services.AddScoped<ICustomerData, AcustomerData>();
            services.AddScoped<IItemData, AitemData>();
            services.AddScoped<IStoreData, AstoreData>();
            services.AddScoped<IOrderData, AorderData>();
            services.AddScoped<IInventoryDetail, AinventoryData>();
            services.AddScoped<IOrderDetail, AorderdetailData>();
            services.AddScoped<IStoreDetailData, AStoreDetailData>();
            services.AddScoped<IItemDetailData, AItemDetailData>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            //use this to redirect to the index HTML for any random path
            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "index.html"));

            //use ,js static files
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
