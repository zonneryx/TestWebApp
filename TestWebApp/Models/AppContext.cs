using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users  { get; set; }
        public DbSet<Event> Events  { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// Обновляет событие
        /// </summary>
        /// <param name="event">Событие</param>
        /// <param name="userIds">Список Id пользователей</param>
        public void UpdateEvent(Event @event, int[] userIds = null)
        {
            
            var oldEntity = Events.First(e => e.Id == @event.Id);
            oldEntity.Date = @event.Date;
            oldEntity.Name = @event.Name;
            oldEntity.Place = @event.Place;
            if (userIds != null)
            {
                var addedUsers = Users.Where(g => userIds.Any(i => g.Id == i)).ToList().Except(oldEntity.Users);
                var removeUsers = oldEntity.Users.Where(u => !userIds.Contains(u.Id));
                oldEntity.Users = oldEntity.Users.Concat(addedUsers).ToList();
                oldEntity.Users = oldEntity.Users.Except(removeUsers).ToList();
            } else
            {
                oldEntity.Users = @event.Users;
            }
            SaveChanges();
        }
        /// <summary>
        /// Добавляет новое событие
        /// </summary>
        /// <param name="event">Событие</param>
        /// <param name="userIds">Список Id пользователей</param>
        public void AddEvent(Event @event, int[] userIds = null)
        {

            var newEntity = new Event();
            newEntity.Date = @event.Date;
            newEntity.Name = @event.Name;
            newEntity.Place = @event.Place;
            if (userIds != null)
            {
                newEntity.Users = Users.Where(g => userIds.Any(i => g.Id == i)).ToList();
            }
            else
            {
                newEntity.Users = @event.Users;
            }
            Events.Add(newEntity);
            SaveChanges();
        }
    }
}