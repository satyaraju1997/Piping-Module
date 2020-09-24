using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class PlantDTO
    {
        public int PlantID { get; set; }
        public String PlantCode { get; set; }
        public String PlantName { get; set; }
        public bool PlantActive { get; set; }
        public int? ParentPlantID { get; set; }
        public String ParentPlantCode { get; set; }
        public String ParentPlantName { get; set; }
        public bool ParentPlantActive { get; set; }
    }
}
