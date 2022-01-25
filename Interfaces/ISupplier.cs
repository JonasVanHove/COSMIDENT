using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSMIDENT.Models;

namespace COSMIDENT.Interfaces
{
    public interface ISupplier
    {
        List<Supplier> GetSuppliers(string SortProperty, SortOrder sortOrder, string SearchText="");
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplier(int id);
        Supplier Create(Supplier supplier);
        Supplier Edit(Supplier supplier);
        Supplier Delete(Supplier supplier);
    }
}
