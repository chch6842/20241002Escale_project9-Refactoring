using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class DataPoint
{
  public string? label { get; set; }
  public string? legendText { get; set; }
  public double? y { get; set; }
  public double? x { get; set; }
  public double? z { get; set; }
  public DataPoint(double y, string label)
  {
    this.x = 0;
    this.y = y;
    this.z = 0;
    this.label = label;
    this.legendText = "";
  }

  public DataPoint(double y, string label, string legendText)
  {
    this.x = 0;
    this.y = y;
    this.z = 0;
    this.label = label;
    this.legendText = legendText;
  }

  public DataPoint(double x, double y)
  {
    this.x = x;
    this.y = y;
    this.z = 0;
    this.label = "";
    this.legendText = "";
  }


  public DataPoint(double x, double y, string label)
  {
    this.x = x;
    this.y = y;
    this.z = 0;
    this.label = label;
    this.legendText = "";
  }

  public DataPoint(double x, double y, double z)
  {
    this.x = x;
    this.y = y;
    this.z = z;
    this.label = "";
    this.legendText = "";
  }

  public DataPoint(double x, double y, double z, string label)
  {
    this.x = x;
    this.y = y;
    this.z = z;
    this.label = label;
    this.legendText = "";
  }
}
