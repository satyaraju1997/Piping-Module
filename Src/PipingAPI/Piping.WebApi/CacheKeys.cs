using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piping.WebApi.Controllers
{
    public static class CacheKeys
    {
        public const int CACHING_EXPIRATION = 3600;
        public const int MIN_CACHING_EXPIRATION = 360;

        //Material Codes Controller
        public const string MATERIAL_CODES_DROPDOWN_LIST = "MeterialCodesDropdownList";

        //Insulation Type Controller
        public const string INSULATION_TYPE_DROPDOWN_LIST = "InsulationTypeDropdownList";

        //Structural Min Thk Controller
        public const string STRUCTURAL_MIN_THK_DROPDOWN_LIST = "StructuralMinThkDropdownList";

        //Material Master Controller
        public const string MATERIAL_STD_DROPDOWN_LIST = "MaterialStdDropdownList";
        public const string MATERIAL_GRADE_DROPDOWN_LIST = "MaterialGradeDropdownList";

    }
}