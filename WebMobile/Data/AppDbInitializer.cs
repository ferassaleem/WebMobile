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

                //Operating system
                if (!context.Operatings.Any())
                {
                    context.Operatings.AddRange(new List<Operating>()
                        {
                        new Operating()
                        {
                            OperatingPictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d7/Android_robot.svg/872px-Android_robot.svg.png",
                            OperatingName  = "Android"
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
                            CompanyPictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Samsung_Logo.svg/2560px-Samsung_Logo.svg.png",
                            CompanyName = "Samsung",
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
                            MobilePictureURL = "https://eshop.orange.jo/app-images/thumbs/0003255_galaxy-a23-4gb.jpeg",
                            MobileName = "A23",
                            Processor = "Octa-core Snapdragon 680 technology 6 nano",
                            RAM = "4/6 GB",
                            Camera = "Quad rear 50 + 5 + 2 + 2 MB",
                            Screen = "6.6 inches, with FHD",
                            Battery = "5000 mAh",
                            OperatingId =1, 
                            CompanyId = 1
                        }
                    });
                    context.SaveChanges();


                }
            }
        }
    }
}