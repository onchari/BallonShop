using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BallonShop.Models.ProductViewModel
{
    public class SubCategoryViewModel
    {
        public int SubCategoryViewModelId { get; set; }
        public string Name { get; set; }

        public int MainCategoryViewModelId { get; set; }
        public virtual MainCategoryViewModel MainCategoryViewModel { get; set; }

       
    }
}
