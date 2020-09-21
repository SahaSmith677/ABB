using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ABB.Entity;
using ABB.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service = null;
        public EmployeeController(IEmployeeService employeeService)
        {
            _service = employeeService;
        }
        /// <summary>
        /// Get all employess
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            List<EmployeeEntity> result= await _service.GetAllEmployee();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No employee records found");
            }
           
        }
        /// <summary>
        /// Get Specific employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetEmployeeById")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            EmployeeEntity result= await _service.GetEmployeeById(id);
            if (result == null)
            {
                return NotFound("No employee found for the given id");
            }
            return Ok(result);
        }
        /// <summary>
        /// Create a new employee. Not required to send employeeid property. send it as 0
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("AddEmployee")]
        public async Task<ActionResult> AddEmployee(EmployeeEntity entity)
        {
            ApiResponse apiResponse = null;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            EmployeeEntity result =await _service.Add(entity);

            if(result != null)
            {
                apiResponse = new ApiResponse()
                {
                    HttpStatusCode=HttpStatusCode.OK,
                    Message="Employee has been added successfully.",
                    Data= result
                };
            }
            else
            {
                apiResponse = new ApiResponse()
                {
                    HttpStatusCode = HttpStatusCode.InternalServerError,
                    Message = "Something went wrong. Please try again.",
                    Data = null
                };
            }

            return Ok(apiResponse);
        }
        /// <summary>
        /// Update an employee. Please provide a valid employeeid in the request body
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee(EmployeeEntity entity)
        {
            ApiResponse apiResponse = null;

            if (!ModelState.IsValid)
            {
                return BadRequest();

                
            }
           
            if (entity.EmployeeId == 0)
            {
                return BadRequest("Please provide a valid employeeId");
            }

            bool result = await _service.Update(entity);
            if (result)
            {
                apiResponse = new ApiResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Message = "Employee has been updated successfully."
                    
                };
            }
            else
            {
                apiResponse = new ApiResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Message = "Failed to update employee data."

                };
            }

            return Ok(apiResponse);
        }
        /// <summary>
        /// Delete a specific employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            ApiResponse apiResponse = null;
            bool result = await _service.Delete(id);
            if (result)
            {
                apiResponse = new ApiResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Message = "Employee has been deleted successfully."

                };
            }
            else
            {
                apiResponse = new ApiResponse()
                {
                    HttpStatusCode = HttpStatusCode.OK,
                    Message = "Failed to delete employee data."

                };
            }

            return Ok(apiResponse);
        }
     }
}
