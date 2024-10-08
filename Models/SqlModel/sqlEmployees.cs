using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escale.Models
{
    public class z_sqlEmployees : DapperSql<Employees>
    {
        public z_sqlEmployees()
        {
            OrderByColumn = SessionService.SortColumn;
            OrderByDirection = SessionService.SortDirection;
            DefaultOrderByColumn = "Employees.EmpNo";
            DefaultOrderByDirection = "ASC";
            if (string.IsNullOrEmpty(OrderByColumn)) OrderByColumn = DefaultOrderByColumn;
            if (string.IsNullOrEmpty(OrderByDirection)) OrderByDirection = DefaultOrderByDirection;
        }

        public override string GetSQLSelect()
        {
            string str_query = @"
SELECT Employees.Id, Employees.IsValid, Employees.EmpNo, Employees.EmpName, 
Employees.GenderCode, vi_CodeGender.CodeName AS GenderName, Employees.DeptNo, 
Departments.DeptName, Employees.TitleNo, Titles.TitleName, Employees.Birthday, 
Employees.OnboardDate, Employees.LeaveDate, Employees.ContactEmail, 
Employees.ContactTel, Employees.ContactAddress, 
Employees.Remark 
FROM Employees 
LEFT OUTER JOIN Titles ON Employees.TitleNo = Titles.TitleNo 
LEFT OUTER JOIN Departments ON Employees.DeptNo = Departments.DeptNo 
LEFT OUTER JOIN vi_CodeGender ON Employees.GenderCode = vi_CodeGender.CodeNo 
";
            return str_query;
        }

        public override List<string> GetSearchColumns()
        {
            List<string> searchColumn = dpr.GetStringColumnList(EntityObject);
            searchColumn.Add("vi_CodeGender.CodeName");
            searchColumn.Add("Titles.TitleName");
            searchColumn.Add("Departments.DeptName");
            return searchColumn;
        }
    }
}