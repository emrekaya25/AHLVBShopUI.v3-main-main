using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShopUI.Core.DTO.Employee
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid DepartmentId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeUserName { get; set; }
        public string EmployeePassword { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
