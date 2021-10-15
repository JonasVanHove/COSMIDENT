﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using COSMIDENT.Data;
using COSMIDENT.Models;

namespace COSMIDENT.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index()
        {
            List<Unit> units = _context.Units.ToList();

            return View(units);
        }

        private readonly InventoryContext _context;

        public UnitController(InventoryContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            Unit unit = new Unit();
            return View(unit);
        }

        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
                _context.Units.Add(unit);
                _context.SaveChanges();
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                _context.Units.Attach(unit);
                _context.Entry(unit).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                _context.Units.Attach(unit);
                _context.Entry(unit).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch
            {

            }

            return RedirectToAction(nameof(Index));
        }

/*        public IActionResult Plus(int id)
        {
            Unit unit = GetUnit(id);
            try
            {
                _context.Units.Attach(unit);
                _context.Entry(unit).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {

            }
            return View(unit);
        }*/

        private Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(u => u.Id == id).FirstOrDefault();
            return unit;
        }
    }
}
