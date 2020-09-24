using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class CompanyDTO
    {
        public int ID { get; set; }        
        public string Code { get; set; }       
        public string Name { get; set; }        
        public string LogoFilename { get; set; }
        public string LogoName { get; set; }
        public byte[] LogoContent { get; set; }      
        public string Address { get; set; }       
        public string Website { get; set; }       
        public string Email { get; set; }       
        public string Phone { get; set; }       
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class CompanyRequestDTO
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LogoFilename { get; set; }
        public string LogoName { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }       
    }
}
