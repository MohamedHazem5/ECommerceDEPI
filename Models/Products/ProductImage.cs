using ECommerce.Models.Products;
using System;
using System.Collections.Generic;

namespace ECommerce.Models
{

    public partial class ProductImage
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public byte[] ImageData { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
