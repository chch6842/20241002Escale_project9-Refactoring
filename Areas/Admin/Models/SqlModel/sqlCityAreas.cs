using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace escale.Areas.Admin.Models
{
    public class z_sqlCityAreas : DapperSql<CityAreas>
    {
        public z_sqlCityAreas()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "CityAreas.AreaName";
            DefaultOrderByDirection = "ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public List<CityAreas> GetCityAreaList(string cityName)
        {

            string str_query = GetSQLSelect();
            str_query += " WHERE CityAreas.CityName = @CityName ";
            str_query += GetSQLOrderBy();
            DynamicParameters parm = new DynamicParameters();
            parm.Add("CityName", cityName);
            var model = dpr.ReadAll<CityAreas>(str_query, parm);
            return model;
        }

        public List<SelectListItem> GetDropDownList(string cityName)
        {
            string str_query = "SELECT AreaName AS Value, AreaName AS Text FROM CityAreas WHERE CityName = @CityName ORDER BY AreaName";
            DynamicParameters parm = new DynamicParameters();
            parm.Add("CityName", cityName);
            var model = dpr.ReadAll<SelectListItem>(str_query, parm);
            return model;
        }
    }
}