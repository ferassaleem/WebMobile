using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using WebMobile.Models;

namespace WebMobile.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                /*
                //Operating system
                if (!context.Operatings.Any())
                {
                    context.Operatings.AddRange(new List<Operating>()
                        {
                        new Operating()
                        {

                        }
                    });
                    context.SaveChanges();

                }
                //Company
                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(new List<Company>()
                        {
                        new Company()
                        {

                        }
                    });
                    context.SaveChanges();

                }
                //Mobile
                if (!context.Mobiles.Any())
                {
                    context.Mobiles.AddRange(new List<Mobile>()
                        {
                        new Mobile()
                        {

                        }
                    });
                    context.SaveChanges();


                }
                */
            }
        }
    }
}