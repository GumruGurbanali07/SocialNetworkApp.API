
using SocialNetwork.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Entities.Concrete;
using SocialNetwork.Core.Entities.Concrete;

namespace SocialNetwork.Core.Configuration
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FriendList> FriendLists { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

    }
}