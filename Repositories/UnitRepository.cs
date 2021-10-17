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
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;

        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Deleted;
            _context.SaveChanges();
            return unit;
        }

        public Unit Edit(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Modified;
            _context.SaveChanges();
            return unit;
        }

        public List<Unit> GetItems(string SortProperty, SortOrder sortOrder)
        {
            List<Unit> units = _context.Units.ToList();

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(n => n.Name).ToList();
                else
                {
                    units = units.OrderByDescending(n => n.Name).ToList();
                }
            }
            if (SortProperty.ToLower() == "description")
            {
                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(d => d.Description).ToList();
                else
                {
                    units = units.OrderByDescending(d => d.Description).ToList();
                }
            }
            if (SortProperty.ToLower() == "barcode")
            {
                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(b => b.Barcode).ToList();
                else
                {
                    units = units.OrderByDescending(b => b.Barcode).ToList();
                }
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    units = units.OrderBy(q => q.Quantity).ToList();
                else
                {
                    units = units.OrderByDescending(q => q.Quantity).ToList();
                }
            }
            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }

    }
}
