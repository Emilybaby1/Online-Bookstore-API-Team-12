using BookStore__Management_system.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using BC = BCrypt.Net.BCrypt;

namespace BookStore__Management_system.Helpers
{
    public class DbSeeder
    {
        public static void Seed(BookStoreContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            var executionStrategy = dbContext.Database.CreateExecutionStrategy();

            executionStrategy.Execute(
              () => {
                  using (var transaction = dbContext.Database.BeginTransaction())
                  {
                      try
                      {
                          // Seed Users
                          if (!dbContext.Users.Any())
                          {
                              var usersData = File.ReadAllText("./Resources/Users.json");
                              var parsedUsers = JsonConvert.DeserializeObject<User[]>(usersData);

                              foreach (var user in parsedUsers)
                              {
                                  user.Password = BC.HashPassword(user.Password);
                              }

                              dbContext.Users.AddRange(parsedUsers);
                              dbContext.SaveChanges();
                          }

                          // Seed Books
                          if (!dbContext.Books.Any())
                          {
                              var booksData = File.ReadAllText("./Resources/Books.json");
                              var parsedBooks = JsonConvert.DeserializeObject<Books[]>(booksData);

                              dbContext.Books.AddRange(parsedBooks);
                              dbContext.SaveChanges();
                          }

                          transaction.Commit();
                        }
                      catch (Exception ex)
                      {
                          transaction.Rollback();
                      }
                  }
              });
        }
    }
}
