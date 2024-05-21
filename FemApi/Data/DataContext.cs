using FemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FemApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddSeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }



        private static void AddSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Name = "Jackets", Price = 100, Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_0.jpg?raw=true" },
                new Item { Id = 2, Name = "Pink Jacket", Price = 90, Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_1.jpg?raw=true" },
                new Item { Id = 3, Name = "Blue Bag ", Price = 40, Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_2.jpg?raw=true" },
                new Item { Id = 4, Name = "Purple dress", Price = 70, Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_3.jpg?raw=true" },
                new Item { Id = 5, Name = "Jackets 2", Price = 150, Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_4.jpg?raw=true" },
                new Item { Id = 6, Name = "Blue & White Bag", Price = 45, Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_6.jpg?raw=true" },
                new Item { Id = 7, Name = "Blue Jacket", Price = 80, Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_7.jpg?raw=true" }
            );
        }


    }


}
