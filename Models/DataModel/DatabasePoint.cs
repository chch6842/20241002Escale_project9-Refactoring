using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// CanvasJS 資料庫讀取格式
/// </summary>
public class DatabasePoint
{
  public string? LabelText { get; set; } = "";
  public string? LegendText { get; set; } = "";
  public int IntValueX { get; set; } = 0;
  public int IntValueY { get; set; } = 0;
  public int IntValueZ { get; set; } = 0;
  public double DoubleValueX { get; set; } = 0;
  public double DoubleValueY { get; set; } = 0;
  public double DoubleValueZ { get; set; } = 0;
}
