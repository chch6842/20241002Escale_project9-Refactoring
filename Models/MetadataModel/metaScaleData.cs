using System;
using System.Collections.Generic;

namespace escale.Models
{
  [ModelMetadataType(typeof(z_metaScaleData))]
  public partial class ScaleData
  {

  }
}

public class z_metaScaleData
{
  [Key]
  public int Id { get; set; }
  [Display(Name = "日期")]
  public DateTime RecordDate { get; set; }
  [Display(Name = "用戶編號")]
  public string? UserNo { get; set; }
  [Display(Name = "熱量")]
  public decimal? Grains { get; set; }
  [Display(Name = "蛋白質")]
  public decimal? Protein { get; set; }
  [Display(Name = "乳製品")]
  public decimal? Dairy { get; set; }
  [Display(Name = "蔬菜")]
  public decimal? Vegetables { get; set; }
  [Display(Name = "水果")]
  public decimal? Fruits { get; set; }
  [Display(Name = "油脂及堅果")]
  public decimal? OilsNuts { get; set; }
}

