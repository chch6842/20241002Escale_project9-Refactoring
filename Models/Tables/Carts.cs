using System;
using System.Collections.Generic;

namespace escale.Models;

public partial class Carts
{
  public int Id { get; set; }

  // public int ProductId { get; set; }  // 外键，指向 Product 表的 Id
  // public string Remark { get; set; }   // 直接存储 Product 的 Remark

  public string? LotNo { get; set; }

  public string? MemberNo { get; set; }

  public string? VendorNo { get; set; }

  public string? CategoryNo { get; set; }

  public string? CategoryName { get; set; }

  public string? ProdNo { get; set; }

  public string? ProdName { get; set; }

  public string? ProdSpec { get; set; }

  public int OrderQty { get; set; }

  public int OrderPrice { get; set; }

  public int OrderAmount { get; set; }

  public DateTime CreateTime { get; set; }

  public string? Remark { get; set; }
}
