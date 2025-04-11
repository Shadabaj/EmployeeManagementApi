using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Interface;

namespace Repository.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly AppDbContext _db;

        public EmployeeRepo(AppDbContext db)
        {
            _db = db;
        }

        public bool CreateEmployee(EmployeeMaster employee)
        {
            try
            {
                employee.CreatedDate = DateTime.UtcNow;
                _db.EmployeeMasters.Add(employee);
                _db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteEmployee(string ID)
        {
            EmployeeMaster data = _db.EmployeeMasters.Where(emp => emp.EmployeeCode == ID).FirstOrDefault();

            if (data!=null)
            {
                _db.EmployeeMasters.Remove(data);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<EmployeeView> EmployeeList()
        {
            try
            {
            IList<EmployeeView> EmployeeDetails = _db.EmployeeMasters.Select(emp => new EmployeeView
                {

                    RowId = emp.RowId,
                    EmployeeCode = emp.EmployeeCode,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    EmailAddress = emp.EmailAddress,
                    MobileNumber = emp.MobileNumber,
                    PanNumber = emp.PanNumber,
                    PassportNumber = emp.PassportNumber,
                    Gender = emp.Gender == 1 ? "Male" : "Female",
                    CountryName = emp.Country.CountryName,
                    StateName = emp.State.StateName,
                    CityName = emp.City.CityName,
                    DateOfJoinee = emp.DateOfJoinee,
                    DateOfBirth = emp.DateOfBirth,
                    ProfileImage = emp.ProfileImage,
                    IsActive = emp.IsActive,
                    CreatedDate = (DateTime)emp.CreatedDate

                }).ToList();

                return EmployeeDetails;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public EmployeeMaster GetEmployeeById(string id)
        {
            EmployeeMaster employee = _db.EmployeeMasters.Where(emp => emp.EmployeeCode == id).FirstOrDefault();
                                       

            return employee; 
        }

        public bool UpdateEmployee(EmployeeMaster employee)
        {
            try
            {
                employee.UpdatedDate = DateTime.UtcNow;
                employee.IsDeleted = false;
                //_db.Entry(employee).State = EntityState.Modified;
                _db.Update(employee);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
