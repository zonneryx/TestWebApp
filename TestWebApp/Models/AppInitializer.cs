using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace TestWebApp.Models
{
    public class AppContextInitializer : DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext context)
        {
           
            #region Init Users
            var users  = new []{ new User()
                {
                    Name = "Nckemased",
                    Age = 23,
                    Email = "Nckemased@gmail.com"
                },
                new User()
                {
                    Name = "Amilball",
                    Age = 26,
                    Email = "Amilball@gmail.com"
                }
                ,
                new User()
                {
                    Name = "Horil",
                    Age = 35,
                    Email = "Horil@gmail.com"
                }
                ,
                new User()
                {
                    Name = "Zarl",
                    Age = 17,
                    Email = "Zarl@gmail.com"
                }
                ,
                new User()
                {
                    Name = "Eenie",
                    Age = 23,
                    Email = "Eenie@gmail.com"
                }
                ,
                new User()
                {
                    Name = "Iunannyeg",
                    Age = 23,
                    Email = "Iunannyeg@gmail.com"
                }
                };
            #endregion
            context.Users.AddRange(users);
            #region Init Events
            context.Events.AddRange(new[] {
                new Event() {
                    Name = "Встреча с заказчиком",
                    Place = "Переговорная",
                    Date = new DateTime(2017, 06, 10, 13,00,00),
                    Users = new [] {users.First() }
                },
                new Event() {
                    Name = "Мозговой штурм",
                    Place = "Офис",
                    Date = new DateTime(2017, 06, 09, 15,00,00),
                    Users = new [] {users.First(),
                                    users.Last() }
                },
                new Event() {
                    Name = "Планирование дальнейшей стратегии компании",
                    Place = "Офис",
                    Date = new DateTime(2017, 06, 01, 11,00,00),
                    Users = users.ToArray()
                },
            });
            #endregion
            context.SaveChanges();
        }
    }
}