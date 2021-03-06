using COSMIDENT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT.Data
{
    public class InventoryContext:DbContext
    {
        public InventoryContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }
}
