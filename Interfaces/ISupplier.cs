using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSMIDENT.Models;

namespace COSMIDENT.Interfaces
{
    public interface ISupplier
    {
        List<Supplier> GetItems(string SortProperty, SortOrder sortOrder);
        Supplier GetSupplier(int id);
        Supplier Create(Supplier supplier);
        Supplier Edit(Supplier supplier);
        Supplier Delete(Supplier supplier);
    }
}
