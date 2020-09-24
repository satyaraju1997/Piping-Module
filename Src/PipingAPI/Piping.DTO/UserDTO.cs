using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }        
    }

    public class UserPasswordDTO
    {
        public String Username { get; set; }
        public String OldPassword { get; set; }
        public String NewPassword { get; set; }
    }

    public class UserRegisterDTO
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String EmpNo { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public string PhotoFilename { get; set; }
        public string PhotoName { get; set; }
        public byte[] PhotoContent { get; set; }
        public string CompanyCode { get; set; }
        public string DepartmentCode { get; set; }
        public string RoleCode { get; set; }
    }

    public class UserResponseDTO
    {
        public int UserID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        public String EmpNo { get; set; }
        public String EmpName { get; set; }
        public Byte[] EmpPhoto { get; set; }
        public String Company { get; set; }
        public String Department { get; set; }
    }

    public class UserLoginDTO
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserDetailDTO
    {
        public int UserID { get; set; }
        public String Username { get; set; }
        public String PasswordHash { get; set; }
        public String Role { get; set; }
        public String EmployeeNo { get; set; }
        public String EmployeeName { get; set; }
        public Byte[] EmployeePhoto { get; set; }
        public int CompanyID { get; set; }        
        public String CompanyName { get; set; }
        public Byte[] CompanyLogo { get; set; }
        public String Department { get; set; }
        public String Token { get; set; }
        public String Email { get; set; }
    }

    public class UserAlertDTO
    {
        public String Username { get; set; }
        public String CompanyName { get; set; }
        public String TemporaryPassword { get; set; }
        public String UserEmail { get; set; }        
    }
}
