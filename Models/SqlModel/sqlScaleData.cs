using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace escale.Models
{
  public class z_sqlScaleData : DapperSql<ScaleData>
  {
    public z_sqlScaleData()
    {
      OrderByColumn = SessionService.SortColumn;
      OrderByDirection = SessionService.SortDirection;
      DefaultOrderByColumn = "ScaleData.RecordDate";
      DefaultOrderByDirection = "ASC";
      if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
      if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public List<DataPoint> GetColumnData(string startDate, string endDate)
    {
      List<DataPoint> result = new List<DataPoint>();
      DateTime dtm_start = Convert.ToDateTime(startDate + " 00:00:00");
      DateTime dtm_end = Convert.ToDateTime(endDate + " 23:59:59");
      using var dpr = new DapperRepository();
      string str_query = @"
      SELECT
          sum(Grains) AS Grains,
          sum(Protein) AS Protein,
          sum(Dairy) AS Dairy,
          sum(Vegetables) AS Vegetables,
          sum(Fruits) AS Fruits,
          sum(OilsNuts) AS OilsNuts
      FROM
          ScaleData
      WHERE
          RecordDate BETWEEN @startDate AND @endDate
";

      DynamicParameters parm = new DynamicParameters();
      parm.Add("@startDate", dtm_start);
      parm.Add("@endDate", dtm_end);
      var data = dpr.ReadSingle<ScaleData>(str_query, parm);

      if (data != null)
      {
        double dbl_grains = Convert.ToDouble(data.Grains);
        double dbl_protein = Convert.ToDouble(data.Protein);
        double dbl_dairy = Convert.ToDouble(data.Dairy);
        double dbl_vegetables = Convert.ToDouble(data.Vegetables);
        double dbl_fruits = Convert.ToDouble(data.Fruits);
        double dbl_oilsnuts = Convert.ToDouble(data.OilsNuts);
        result.Add(new DataPoint(dbl_grains, "穀物"));
        result.Add(new DataPoint(dbl_protein, "蛋白質"));
        result.Add(new DataPoint(dbl_dairy, "乳製品"));
        result.Add(new DataPoint(dbl_vegetables, "蔬菜"));
        result.Add(new DataPoint(dbl_fruits, "水果"));
        result.Add(new DataPoint(dbl_oilsnuts, "油堅果"));
      }
      return result;
    }
  }
}
