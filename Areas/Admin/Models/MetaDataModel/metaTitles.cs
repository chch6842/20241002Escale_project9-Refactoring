using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace escale.Areas.Admin.Models
{
    [ModelMetadataType(typeof(z_metaTitles))]
    public partial class Titles
    {
    }
}

public class z_metaTitles
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "職稱代號")]
    [Required(ErrorMessage = "職稱代號不可空白!!")]
    public string? TitleNo { get; set; }
    [Display(Name = "職稱")]
    [Required(ErrorMessage = "職稱不可空白!!")]
    public string? TitleName { get; set; }
    [Display(Name = "備註")]
    public string? Remark { get; set; }
}