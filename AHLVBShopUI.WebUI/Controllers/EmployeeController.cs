using AHLVBShopUI.Core.DTO.Company;
using AHLVBShopUI.Core.DTO.Department;
using AHLVBShopUI.Core.DTO.Employee;
using AHLVBShopUI.Core.DTO.Role;
using AHLVBShopUI.Core.Model;
using AHLVBShopUI.Core.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AHLVBShopUI.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet("/Employees")]
        public async Task<IActionResult> Index()
        {
            EmployeeViewModel employeeViewModel = new()
            {
                Departments = await GetDepartments(),
                Companies = await GetCompanies(),
                Employees = await GetEmployees(),
                Roles = await GetRoles()
                
            };
            return View(employeeViewModel);
        }

        [HttpGet]
        public async Task<List<DepartmentDTO>> GetDepartments()
        {
            var url = "http://localhost:5070/Departments";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<DepartmentDTO>>>(response.Content);

            var departmentList = responseObject.Data;

            return departmentList;
        }

        [HttpGet]
        public async Task<List<CompanyDTO>> GetCompanies()
        {
            var url = "http://localhost:5070/GetCompanies";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<CompanyDTO>>>(response.Content);

            var companyList = responseObject.Data;

            return companyList;
        }

        [HttpGet]
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            var url = "http://localhost:5070/Employees";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<EmployeeDTO>>>(response.Content);

            var employeeList = responseObject.Data;

            return employeeList;
        }

        [HttpGet]
        public async Task<List<RoleDTO>> GetRoles()
        {
            var url = "http://localhost:5070/Roles";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Content-Type", "application/json");

            RestResponse response = await client.ExecuteAsync(request);
            var responseObject = JsonConvert.DeserializeObject<ApiResult<List<RoleDTO>>>(response.Content);

            var roleList = responseObject.Data;

            return roleList;
        }


    }
}
