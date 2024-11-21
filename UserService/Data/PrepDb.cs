namespace UserService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                //SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                Console.WriteLine("Seeding data in progress...");

                context.Users.AddRange(
                    new Models.User() { Name="Staff", NIM= "0000000000", Password="12345678", Role=true },
                    new Models.User() { Name = "Idjiot Sandwiches", NIM = "2118033615", Password="12345678", Role = false },
                    new Models.User() { Name = "Sabun Idjiot", NIM = "2118033614", Password= "12345678", Role = false }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already in Database!");
            }
        }
    }
}
