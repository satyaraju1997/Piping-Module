using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class PipeMasterMenuDTO
    {
        public int PipeMasterID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }        
        public int ParentPlantID { get; set; }
        public string ParentPlantName { get; set; }
        public int PlantID { get; set; }
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public string Fluid { get; set; }
        public string EquipmentNo { get; set; }
    }
}
