using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT.Models
{
    public enum SortOrder { Ascending=0,Descending=1}
    public class Unit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Description { get; set; }

        [StringLength(50)]
        public string ArticleNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Barcode { get; set; }

        public int SupplierID { get; set; }

        public int Price { get; set; }

        public int VatRate { get; set; }

        public int DiscountRate { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}



