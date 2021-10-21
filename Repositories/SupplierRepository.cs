using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSMIDENT.Data;
using COSMIDENT.Interfaces;
using COSMIDENT.Models;
using Microsoft.EntityFrameworkCore;

namespace COSMIDENT.Repositories
{
    public class SupplierRepository : ISupplier
    {
        private readonly InventoryContext _context;

        public SupplierRepository(InventoryContext context)
        {
            _context = context;
        }

        public Supplier Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }

        public Supplier Delete(Supplier supplier)
        {
            _context.Suppliers.Attach(supplier);
            _context.Entry(supplier).State = EntityState.Deleted;
            _context.SaveChanges();
            return supplier;
        }

        public Supplier Edit(Supplier supplier)
        {
            _context.Suppliers.Attach(supplier);
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
            return supplier;
        }

        public List<Supplier> GetItems(string SortProperty, SortOrder sortOrder)
        {
            List<Supplier> suppliers = _context.Suppliers.ToList();

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    suppliers = suppliers.OrderBy(n => n.SupplierName).ToList();
                else
                {
                    suppliers = suppliers.OrderByDescending(n => n.SupplierName).ToList();
                }
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    suppliers = suppliers.OrderBy(e => e.Email).ToList();
                else
                {
                    suppliers = suppliers.OrderByDescending(e => e.Email).ToList();
                }
            }
            return suppliers;
        }

        public Supplier GetSupplier(int id)
        {
            Supplier supplier = _context.Suppliers.Where(s => s.Id == id).FirstOrDefault();
            return supplier;
        }

    }
}
