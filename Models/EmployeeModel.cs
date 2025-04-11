

using System.Reflection;

namespace Models
{
    //public class EmployeeModel
    // {
    //     public int RowId { get; set; }

    //     public string EmployeeCode { get; set; }

    //     public string FirstName { get; set; }

    //     public string LastName { get; set; }

    //     public int? CountryId { get; set; }

    //     public int? StateId { get; set; }

    //     public int? CityId { get; set; }

    //     public string EmailAddress { get; set; }

    //     public string MobileNumber { get; set; }

    //     public string PanNumber { get; set; }

    //     public string PassportNumber { get; set; }

    //     public string ProfileImage { get; set; }

    //     public byte? Gender { get; set; }

    //     public bool IsActive { get; set; }

    //     public DateOnly DateOfBirth { get; set; }

    //     public DateOnly DateOfJoinee { get; set; }
    // }

    public class EmployeeModel
    {
        public int RowId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string PanNumber { get; set; }
        public string PassportNumber { get; set; }
        public string ProfileImage { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfJoinee { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
    }

    public enum Gender
    {
        
        Female =0,
        Male = 1
    }
}
