﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Product.Classes.Mongo;
using Config.Product.Dependencies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Product.Barton
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString
                    = Configuration.GetSection("ConnectionStrings:Connection").Value;
                options.Database
                    = Configuration.GetSection("ConnectionStrings:DataBase").Value;
            });

            services.AddSwaggerDocument();
            services.AddCors(options =>
            {

                options.AddPolicy("VmallPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            Container.Register(services, Configuration);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi3();
            app.UseCors();
        }
    }
}
