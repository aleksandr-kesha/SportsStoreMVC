using System.Collections.Generic;
using System.Data.Entity;

namespace SportsStore.Domain.Models
{
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Kayak", Description = "Одноместная лодка", Category = "Watersports", Price = 275.00M },
                new Product { ProductId = 2, Name = "Lifejacket", Description = "Защищающий и модный", Category = "Watersports", Price = 48.95M },
                new Product { ProductId = 3, Name = "Soccer ball", Description = "Утвержденный ФИФА размер и вес", Category = "Soccer", Price = 19.50M },
                new Product { ProductId = 4, Name = "Corner Flags", Description = "Придаёт профессиональные штрихи вашему игровому полю", Category = "Soccer", Price = 34.95M },
                new Product { ProductId = 5, Name = "Stadium", Description = "Плоский стадион на 35000 мест", Category = "Soccer", Price = 79500.00M },
                new Product { ProductId = 6, Name = "Thinking Cup", Description = "Улучшает эффективность работы вашего мозга на 75%", Category = "Chess", Price = 16.00M },
                new Product { ProductId = 7, Name = "Unsteady Chair", Description = "Скрыто ставит соперника в неудобное положение", Category = "Chess", Price = 29.95M },
                new Product { ProductId = 8, Name = "Humas Chess Board", Description = "Забавная игра для всей семьи", Category = "Chess", Price = 75.00M },
                new Product { ProductId = 9, Name = "Blink-Blink King", Description = "Позолоченный, украшенный алмазами, король", Category = "Chess", Price = 1200.00M }
            };

            context.Products.AddRange(products);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
