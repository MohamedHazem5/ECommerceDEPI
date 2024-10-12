using ECommerce.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{

    public partial class ProductImage
    {
        public int Id { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; } // = null!;
        public int ProductID { get; set; }
        public byte[] ImageData { get; set; }
    }
}
