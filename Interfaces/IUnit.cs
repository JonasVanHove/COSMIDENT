using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COSMIDENT.Models;

namespace COSMIDENT.Interfaces
{
    public interface IUnit
    {
        PaginatedList<Unit> GetItems(string SortProperty, SortOrder sortOrder, string SearchText="", int pageIndex = 1, int pageSize = 5);
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);
        Unit Delete(Unit unit);
        Unit Update(Unit unit);
        Unit Plus(Unit unit);
        Unit Min(Unit unit);
    }
}
