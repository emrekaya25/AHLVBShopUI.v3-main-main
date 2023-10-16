using AHLVBShopUI.Core.DTO.Brand;
using AHLVBShopUI.Core.DTO.Category;
using AHLVBShopUI.Core.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShopUI.Core.Model
{
    public class ProductViewModel
    {
        public List<ProductDTO> Products { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<BrandDTO> Brands { get; set; }
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
