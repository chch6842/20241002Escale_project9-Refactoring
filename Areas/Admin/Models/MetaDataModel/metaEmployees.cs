using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace escale.Areas.Admin.Models
{
    [ModelMetadataType(typeof(z_metaEmployees))]
    public partial class Employees
    {
        [NotMapped]
        [Display(Name = "性別")]
        public string? GenderName { get; set; }
        [NotMapped]
        [Display(Name = "部門代號")]
        public string? DeptName { get; set; }
        [NotMapped]
        [Display(Name = "職稱代號")]
        public string? TitleName { get; set; }
        [NotMapped]
        [Display(Name = "通訊地址")]
        public string? ContactFullAddress { get; set; }
    }
}

public class z_metaEmployees
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "合法")]
    public bool IsValid { get; set; }
    [Display(Name = "員工編號")]
    [Required(ErrorMessage = "員工編號不可空白!!")]
    public string? EmpNo { get; set; }
    [Display(Name = "姓名")]
    [Required(ErrorMessage = "姓名不可空白!!")]
    public string? EmpName { get; set; }
    [Display(Name = "性別")]
    public string? GenderCode { get; set; }
    [Display(Name = "部門代號")]
    public string? DeptNo { get; set; }
    [Display(Name = "職稱代號")]
    public string? TitleNo { get; set; }
    [Display(Name = "出生日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? Birthday { get; set; }
    [Display(Name = "到職日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? OnboardDate { get; set; }
    [Display(Name = "離職日期")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? LeaveDate { get; set; }
    [Display(Name = "電子信箱")]
    [EmailAddress(ErrorMessage = "電子信箱格式不正確!!")]
    public string? ContactEmail { get; set; }
    [Display(Name = "連絡電話")]
    public string? ContactTel { get; set; }
    [Display(Name = "縣市")]
    public string? CityName { get; set; }
    [Display(Name = "鄉鎮區")]
    public string? CityArea { get; set; }
    [Display(Name = "通訊地址")]
    public string? ContactAddress { get; set; }
    [Display(Name = "備註")]
    public string? Remark { get; set; }
}