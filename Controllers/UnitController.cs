using Microsoft.AspNetCore.Mvc;
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

            return View();
        }

        private readonly InventoryContext _context;

        public UnitController(InventoryContext context)
        {
            _context = context;
        }

    }
}
