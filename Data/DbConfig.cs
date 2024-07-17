using CustomerService.Model;

namespace CustomerService.Data
{
    public static class DbConfig
    {
        public static void ConfigPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Customers.Any())
            {
                Console.WriteLine("Criando dados");
                context.Customers.AddRange(
                    new Customer() { Name = "Bruno", Score = 900 },
                    new Customer() { Name = "Joaozinho", Score = 200 },
                    new Customer() { Name = "Mariazinha", Score = 410 }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ja temos dados");
            }
        }
    }
}
