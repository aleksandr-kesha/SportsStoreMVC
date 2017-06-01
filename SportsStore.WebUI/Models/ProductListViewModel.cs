using System.Collections.Generic;
using SportsStore.Domain.Models;

namespace SportsStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; } 

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}