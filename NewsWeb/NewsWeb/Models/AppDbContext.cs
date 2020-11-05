using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace NewsWeb.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Title = "Thời sự", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Title = "Thể thao", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s" });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Title = "Giải trí", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s" });


            modelBuilder.Entity<PostTag>().HasKey(protag => new { protag.PostId, protag.TagId });

            //Seeder data tag
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 1,
               Title= "Viet Nam",
               Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"


            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 2,
                Title = "USA",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
            });
            modelBuilder.Entity<Tag>().HasData(new Tag
            {
                Id = 3,
                Title = "France",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s"
            });

        }
    }
}
