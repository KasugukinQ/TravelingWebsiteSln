using Microsoft.EntityFrameworkCore;

namespace TravelingWebsite.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<StoreDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Packages.Any())
            {
                context.Packages.AddRange(
                    new Package
                    {
                        Name = "Package A",
                        Description = "Embark on guided hikes through the breathtaking mountain ranges of Luzon, including the famous Mt. Pulag and Mt. Pinatubo. Enjoy scenic vistas, camp under the stars, and immerse yourself in the natural beauty of the Philippines.",
                        Category = "Hiking Adventures",
                        Price = 499.95m
                    },
                    new Package
                    {
                        Name = "Package B",
                        Description = "Discover the stunning landscapes of the Bicol Region on a bike. Our tours cover routes through picturesque towns, rolling hills, and along beautiful coastlines, with plenty of stops for local delicacies.",
                        Category = "Cycling Tours",
                        Price = 249.95m
                    },
                    new Package
                    {
                        Name = "Package C",
                        Description = "Savor the flavors of Cebu with a guided culinary tour. Visit local markets, try street food, and dine in acclaimed restaurants, all while learning about the rich food culture of the region.",
                        Category = "Gastro Traveling",
                        Price = 399.95m
                    },
                    new Package
                    {
                        Name = "Package D",
                        Description = "Engage with the locals in the Visayas region. This tour includes intimate interviews and storytelling sessions with indigenous people, community leaders, and artisans, offering a deep dive into local life and traditions.",
                        Category = "Cultural Immersion",
                        Price = 999.95m
                    },
                    new Package
                    {
                        Name = "Package E",
                        Description = "For adrenaline junkies, Mindanao offers a range of extreme sports. From white-water rafting in Cagayan de Oro to paragliding over Davao's landscapes, experience the thrill of extreme sports in the Philippines.",
                        Category = "Extreme Traveling",
                        Price = 999.95m
                    },
                    new Package
                    {
                        Name = "Package F",
                        Description = "Explore the eco-friendly side of Bohol with tours focusing on sustainable tourism. Visit the Chocolate Hills, cruise the Loboc River, and learn about conservation efforts to protect local wildlife.",
                        Category = "Eco-Tourism",
                        Price = 699.95m
                    },

                    new Package
                    {
                        Name = "Package G",
                        Description = "Take on a series of crazy challenges set on the beautiful islands of Palawan. Activities include island hopping, underwater cave explorations, and beach obstacle courses, perfect for adventurous spirits.",
                        Category = "Crazy Challenges",
                        Price = 399.95m
                    },
                    new Package
                    {
                        Name = "Package H",
                        Description = "Enjoy a family-friendly vacation in the stunning island of Boracay. Activities include beach games, child-friendly water sports, and family excursions, ensuring fun for all ages.",
                        Category = "Traveling with Kids",
                        Price = 299.95m
                    },
                    new Package
                    {
                        Name = "Package I",
                        Description = "Catch the best waves in Siargao, the surfing capital of the Philippines. Our surf safaris cater to all skill levels and include professional coaching, equipment rental, and guided surf sessions.",
                        Category = "Surfing Adventures",
                        Price = 2199.95m
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
