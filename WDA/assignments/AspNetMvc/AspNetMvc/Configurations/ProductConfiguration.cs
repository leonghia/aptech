using AspNetMvc.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetMvc.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Apple iMac 27\"\"",
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/products/imac-front-image.png",
                    CategoryId = 1,
                    Price = 799.88m,
                    Stock = 95,
                    SalesPerDay = 1.47,
                    SalesPerMonth = 0.47,
                    Rating = 5,
                    Sales = 1_600_000,
                    Revenue = 3_200_000
                },
                new Product
                {
                    Id = 2,
                    Name = "Apple iMac 20\"\"",
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/products/imac-front-image.png",
                    CategoryId = 1,
                    Price = 799.88m,
                    Stock = 108,
                    SalesPerDay = 1.15,
                    SalesPerMonth = 0.32,
                    Rating = 5,
                    Sales = 6_000_000,
                    Revenue = 785_000
                },
                new Product
                {
                    Id = 3,
                    Name = "Apple iPhone 14",
                    Price = 593.00m,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-iphone-14.png",
                    CategoryId = 2,
                    Stock = 24,
                    SalesPerDay = 1.00,
                    SalesPerMonth = 0.95,
                    Rating = 4.0f,
                    Sales = 1_200_000,
                    Revenue = 3_200_000,

                },
                new Product
                {
                    Id = 4,
                    Name = "Apple iPad Air",
                    Price = 559.00m,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-ipad-air.png",
                    CategoryId = 3,
                    Stock = 287,
                    SalesPerDay = 0.47,
                    SalesPerMonth = 1.00,
                    Rating = 4.0f,
                    Sales = 298_000,
                    Revenue = 425_000
                },
                new Product
                {
                    CategoryId = 4,
                    Id = 5,
                    Name = "Xbox Series S",
                    Price = 274.99m,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/xbox-series-s.png",
                    Stock = 450,
                    SalesPerDay = 1.61,
                    SalesPerMonth = 0.30,
                    Rating = 5.0f,
                    Sales = 99,
                    Revenue = 345_000
                },
                new Product
                {
                    Id = 6,
                    Name = "PlayStation 5",
                    Price = 479.00m,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/playstation-5.png",
                    CategoryId = 4,
                    Stock = 2345,
                    SalesPerDay = 1.41,
                    SalesPerMonth = 0.11,
                    Rating = 4.0f,
                    Sales = 2_100_000,
                    Revenue = 4_200_000
                },
                new Product
                {
                    Id = 7,
                    Name = "Xbox Series X",
                    Price = 489.99m,
                    CategoryId = 4,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/xbox-series-x.png",
                    Stock = 235,
                    SalesPerDay = 7.09,
                    SalesPerMonth = 3.32,
                    Rating = 5.0f,
                    Sales = 989_000,
                    Revenue = 2_270_000
                },
                new Product
                {
                    Id = 8,
                    Name = "Apple Watch SE",
                    Price = 201.48m,
                    CategoryId = 5,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-watch-se.png",
                    Stock = 433,
                    SalesPerDay = 4.96,
                    SalesPerMonth = 0.74,
                    Rating = 5.0f,
                    Sales = 102,
                    Revenue = 45_000
                },
                new Product
                {
                    Id = 9,
                    Name = "NIKON D850",
                    Price = 2_496.95m,
                    CategoryId = 6,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/nikon-d850.png",
                    Stock = 351,
                    SalesPerDay = 0.20,
                    SalesPerMonth = 0.74,
                    Rating = 3.0f,
                    Sales = 1_200_000,
                    Revenue = 1_520_000
                },
                new Product
                {
                    Id = 10,
                    Name = "Monitor BENQ EX2710Q",
                    CategoryId = 7,
                    Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/benq-ex2710q.png",
                    Price = 349.99m,
                    Stock = 1242,
                    SalesPerDay = 4.12,
                    SalesPerMonth = 0.30,
                    Rating = 4.0f,
                    Sales = 211_000,
                    Revenue = 1_200_000
                }
                );
        }
    }
}
