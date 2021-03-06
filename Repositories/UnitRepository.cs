using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSMIDENT.Data;
using COSMIDENT.Interfaces;
using COSMIDENT.Models;
using COSMIDENT.Services;
using Microsoft.EntityFrameworkCore;

namespace COSMIDENT.Repositories
{
    public class UnitRepository : IUnit
    {
        private readonly InventoryContext _context;
        private readonly IMailService _mailService;

        public UnitRepository(InventoryContext context, IMailService mailService)
        {
            _context = context;
            _mailService = mailService;
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

        public void Add(int id, int value)
        {
            var unit = GetUnit(id);
            unit.Quantity += value;
            _context.Units.Update(unit);
            _context.SaveChanges();
        }

        public void Plus(int id)
        {
            var unit = GetUnit(id);
            unit.Quantity++;
            _context.Units.Update(unit);
            _context.SaveChanges();
        }

        public void Min(int id)
        {
            var unit = GetUnit(id);
            unit.Quantity--;
            _context.Units.Update(unit);
            _context.SaveChanges();
        }

        public void CheckStock()
        { if (_context.Units.Any(x => x.Quantity < 4)) {
                MailRequest mailRequest = new MailRequest()
                {
                    Body = _mailService.CreateEmailBody(_context.Units.Where(x => x.Quantity < 4).ToList()),
                    Subject = "Stockbeheer Cosmident",
                    ToEmail = "r0450988@student.thomasmore.be"
                };
                _mailService.SendEmail(mailRequest);
            }
        }

        private List<Unit> DoSort(List<Unit> units, string SortProperty, SortOrder sortOrder)
        {
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
        public PaginatedList<Unit> GetItems(string SortProperty, SortOrder sortOrder,string SearchText="", int pageIndex=1, int pageSize=5)
        {
            List<Unit> units;

            if(SearchText != "" && SearchText!=null)
            {
                units = _context.Units.Where(n=>n.Name.Contains(SearchText) || n.Description.Contains(SearchText) || n.Barcode.Contains(SearchText)).ToList();
            }
            else
                units = _context.Units.ToList();

            units = DoSort(units, SortProperty, sortOrder);

            PaginatedList<Unit> retUnits = new PaginatedList<Unit>(units, pageIndex, pageSize);

            return retUnits;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }
    }
}
