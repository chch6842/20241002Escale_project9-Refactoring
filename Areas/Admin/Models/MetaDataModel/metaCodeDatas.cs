using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace escale.Areas.Admin.Models
{
    [ModelMetadataType(typeof(z_metaCodeDatas))]
    public partial class CodeDatas
    {
    }
}

public class z_metaCodeDatas
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "啟用")]
    public bool IsEnabled { get; set; }
    [Display(Name = "主檔代號")]
    public string? BaseNo { get; set; }
    [Display(Name = "父階代號")]
    public string? ParentNo { get; set; }
    [Display(Name = "排序")]
    public string? SortNo { get; set; }
    [Display(Name = "代號")]
    [Required(ErrorMessage = "代號不可空白!!")]
    public string? CodeNo { get; set; }
    [Display(Name = "名稱")]
    [Required(ErrorMessage = "名稱不可空白!!")]
    public string? CodeName { get; set; }
    [Display(Name = "值")]
    public string? CodeValue { get; set; }
    [Display(Name = "備註")]
    public string? Remark { get; set; }
}