using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class DocumentDTO
    {
        public int ID { get; set; }        
        public string DocumentNo { get; set; }       
        public string Description { get; set; }        
        public string FileName { get; set; }
        public string Format { get; set; }
        public byte[] Content { get; set; }      
        public string DocumentType { get; set; }       
        public string ReferenceNo { get; set; }        
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
