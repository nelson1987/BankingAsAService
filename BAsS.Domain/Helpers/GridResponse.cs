using System;
using System.Collections.Generic;
using System.Linq;

namespace Baas.Domain.Helpers
{
    public static class GridResponse<T> where T : class
    {
        public static IEnumerable<T> Get(IEnumerable<T> products, string page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = products.Count();
            int totalPages = (int)Math.Ceiling(totalRecords / (float)pageSize);

            var result = (from produto in products
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                          select produto);
            return result;
        }
    }
}