using BookStore__Management_system.Data;

namespace BookStore__Management_system.Helpers
{
    public static class DBInitializerExtension
    {
        public static IApplicationBuilder UseSeedDB(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<BookStoreContext>();
            DbSeeder.Seed(context);

            return app;
        }
    }
}
