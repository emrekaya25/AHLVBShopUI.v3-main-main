using AHLVBShopUI.Core.DTO.Company;
using AHLVBShopUI.Core.DTO.Department;
using AHLVBShopUI.Core.DTO.Employee;
using AHLVBShopUI.Core.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShopUI.Core.Model
{
    public class EmployeeViewModel
    {
        public List<CompanyDTO> Companies { get; set; }
        public List<DepartmentDTO> Departments { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
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
