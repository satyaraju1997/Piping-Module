using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class MenuDTO
    {
        public string ID { get; set; }        
        public string Code { get; set; }
        public string Name { get; set; }        
        public string Path { get; set; }
        public string BreadCrumb { get; set; }
        public string Icon { get; set; }
        public string ParentID { get; set; }
        public int DisplayOrder { get; set; }
        public List<MenuDTO> SubMenu { get; set; }

        public MenuDTO()
        {
            SubMenu = new List<MenuDTO>();
        }
    }
}
