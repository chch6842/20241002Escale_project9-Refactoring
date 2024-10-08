using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escale.Areas.Admin.Models
{
    public class z_sqlTitles : DapperSql<Titles>
    {
        public z_sqlTitles()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "Titles.TitleNo";
            DefaultOrderByDirection = "ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }
    }
}
