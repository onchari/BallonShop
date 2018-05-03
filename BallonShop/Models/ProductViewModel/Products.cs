using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BallonShop.Models.ProductViewModel
{
    public class Products
    {
        public int ProductsId { get; set; }

        public int SubCategoryViewModelId { get; set; }
        public virtual SubCategoryViewModel SubCategoryViewModel{ get; set; }

        
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Range(0,10000,ErrorMessage ="Provide appropriate SKU num")]
        public int ProductSKUs { get; set; }
        public decimal ProductMarketPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQty { get; set; }

        
        public int ProductInventoryNumber { get; set; }
        public string ProductPhotoUrl { get; set; }
                
        public DateTime ProductPublishTime { get; set; }
        public bool? WhetherRecommended { get; set; }

        
    }
}
