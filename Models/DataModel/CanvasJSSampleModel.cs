using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// CanvasJS 範例資料
/// </summary>
public class CanvasJSSampleModel : BaseClass
{
  private Random random = new Random(DateTime.Now.Millisecond);

  /// <summary>
  /// Column 長條圖範例資料
  /// </summary>
  /// <returns></returns>
  /// <summary>
  /// Column 長條圖範例資料庫資料
  /// </summary>
  /// <returns></returns>
  public List<DataPoint> ColumnDatabaseData()
  {
    using var dpr = new DapperRepository();
    List<DataPoint> result = new List<DataPoint>();
    string str_query = @"
      SELECT
          RecordDate,
          Grains,
          Protein,
          Dairy,
          Vegetables,
          Fruits,
          OilsNuts
      FROM
          ScaleData
      WHERE
          RecordDate BETWEEN @startDate AND @endDate
      ORDER BY
          RecordDate;";

    var data = dpr.ReadAll<DatabasePoint>(str_query);
    if (data != null)
    {
      string str_label = "";
      int int_value = 0;
      double dbl_value = 0;
      foreach (var item in data)
      {
        str_label = item.LabelText;
        int_value = item.IntValueY;
        dbl_value = Convert.ToDouble(int_value);
        result.Add(new DataPoint(dbl_value, str_label));
      }
    }
    return result;
  }
}
