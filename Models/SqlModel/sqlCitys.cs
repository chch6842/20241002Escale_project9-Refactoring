using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escale.Models
{
    public class z_sqlCitys : DapperSql<Citys>
    {
        public z_sqlCitys()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "Citys.SortNo,Citys.CityName";
            DefaultOrderByDirection = "ASC,ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }
    }
}