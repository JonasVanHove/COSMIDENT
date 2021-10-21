using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT.Models
{
    //public enum SortOrder { Ascending=0,Descending=1}
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(35)]
        public string MobilePhone { get; set; }

        [StringLength(30)]
        public string Street { get; set; }

        [StringLength(10)]
        public string Number { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(35)]
        public string City { get; set; }

    }
}



