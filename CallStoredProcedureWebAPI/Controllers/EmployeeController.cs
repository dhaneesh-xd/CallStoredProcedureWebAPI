using CallStoredProcedureWebAPI.Data;
using CallStoredProcedureWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CallStoredProcedureWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly EmployeeDAL employeeDAL;

        public EmployeeController()
        {
            try
            {
                employeeDAL = new EmployeeDAL();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception in EmployeeController constructor: {ex.Message}");
                throw; // rethrow the exception or handle it appropriately
            }
        }

        [HttpPost]
        public IHttpActionResult InsertEmployee(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest("Employee object is null.");
            }

            try
            {
                employeeDAL.InsertEmployee(emp);
                return Ok("Employee inserted successfully.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}