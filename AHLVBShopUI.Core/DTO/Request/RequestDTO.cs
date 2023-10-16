using AHLVBShopUI.Core.DTO.Employee;
using AHLVBShopUI.Core.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShopUI.Core.DTO.Request
{
    public class RequestDTO
    {
        public Guid Id { get; set; }
        public string RequestTitle { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }


    }
}
