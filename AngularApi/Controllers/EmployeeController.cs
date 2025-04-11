using System.Web;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Repository.Interface;
using UIAPI.FileHelpers.Interface;

namespace AngularApi.Controllers
{
    [EnableCors("AllowAll")]
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepo _employeeRepo;
        private readonly IFileHelpers _fileHelpers;

        public EmployeeController(IEmployeeRepo employeeRepo, IFileHelpers fileHelpers)
        {
            _employeeRepo = employeeRepo;
            _fileHelpers = fileHelpers;
        }


        [HttpGet("EmployeeDetails")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<EmployeeView>> EmployeeDetails()
        {
            var ListEmployee = _employeeRepo.EmployeeList();

            if (ListEmployee != null && ListEmployee.Any())
            {
                return Ok(ListEmployee);
            }

            return NoContent();

        }

        //[HttpGet(Employee"{id}")]
        [HttpGet("Employee/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployeeById(string id)
        {
            var employee = _employeeRepo.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        [HttpPost("CreateEmployee")]
        //[Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateEmployee([FromBody] EmployeeModel model)
        {
            try
            {
                EmployeeMaster emp = new EmployeeMaster
                {
                    EmployeeCode = model.EmployeeCode,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EmailAddress = model.EmailAddress,
                    MobileNumber = model.MobileNumber,
                    PanNumber = model.PanNumber,
                    PassportNumber = model.PassportNumber,
                    ProfileImage = model.ProfileImage,
                    DateOfBirth = model.DateOfBirth,
                    DateOfJoinee = model.DateOfJoinee,
                    Gender = (byte)model.Gender,
                    IsActive = model.IsActive,
                    CountryId = model.CountryId,
                    StateId = model.StateId,
                    CityId = model.CityId

                };

                bool result = _employeeRepo.CreateEmployee(emp);

                if (result)
                {
                    return CreatedAtAction(nameof(GetEmployeeById), new { id = emp.EmployeeCode }, emp);
                }
                else
                {
                    return BadRequest("Failed to create the employee.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("DeleteEmployee/{employeeCode}/{profileImage}")]
        public ActionResult DeleteEmployee(string employeeCode, string profileImage)
        {
            bool data = _employeeRepo.DeleteEmployee(employeeCode);
            //profileImage = profileImage.Replace("%2", "/");
            profileImage = HttpUtility.UrlDecode(profileImage);

            bool IsfileDeleted= _fileHelpers.DeleteFile(profileImage);

            if (data && IsfileDeleted )
            {
            
                return Ok(new { Details = "The employee was deleted successfully." }); 
            }
            return StatusCode(StatusCodes.Status404NotFound, "Employee not found");
        }



        [HttpPut("EditEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            try
            {
                
                EmployeeMaster employee = _employeeRepo.GetEmployeeById(model.EmployeeCode);
                //if (!ModelState.IsValid)
                //return BadRequest(ModelState);


                employee.EmployeeCode = model.EmployeeCode;
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.EmailAddress = model.EmailAddress;
                employee.MobileNumber = model.MobileNumber;
                employee.PanNumber = model.PanNumber;
                employee.PassportNumber = model.PassportNumber;
                employee.ProfileImage = model.ProfileImage;
                employee.DateOfBirth = model.DateOfBirth;
                employee.DateOfJoinee = model.DateOfJoinee;
                employee.Gender = (byte)model.Gender;
                employee.IsActive = model.IsActive;
                employee.CountryId = model.CountryId;
                employee.StateId = model.StateId;
                employee.CityId = model.CityId;

               

                bool isEdit = _employeeRepo.UpdateEmployee(employee);

                if (isEdit)
                {
                    return Ok(new { Messagae="Employee Updated Successfully"});
                }

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

        }

    }
}
