using AutoMapper;
using Piping.Contracts.Services;
using Piping.Contracts.Repository;
using Piping.Repository;
using Piping.DTO;
using Piping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;
using System.IO;
using Piping.Common.Enums;
using Piping.Common;
using Microsoft.AspNetCore.Identity;

namespace Piping.Services
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public bool UserExists(string username)
        {
            bool isExists = false;
            var user = (from u in _unitOfWork.User.FindAll().Where(t => t.Username == username) select u).FirstOrDefault();
            if (user != null)
                isExists = true;
            return isExists;
        }

        public User Register(UserRegisterDTO user)
        {
            try
            {
                Department department = (from d in _unitOfWork.Department.FindAll().Where(d => d.Code == user.DepartmentCode)
                                         //&& c.Code == user.CompanyCode)
                                         join c in _context.Company on d.CompanyID equals c.ID                                         
                                         select d).FirstOrDefault();
                Role role = (from r in _unitOfWork.Role.FindAll().Where(r => r.Code == user.RoleCode) select r).FirstOrDefault();

                User usr = new User()
                {
                    ID = 0,
                    Username = user.Username,
                    // Password = user.Password,
                    Password = (new Piping.Helper.PasswordHasher()).Hash(user.Password),
                    PasswordHash = (new Piping.Helper.PasswordHasher()).Hash(user.Password),
                    CompanyID = department.Company.ID,
                    Email = user.Email,
                    IsExpired = false,
                    Active = true,
                    IsLocked = false,
                    CreatedBy = "SYSADMIN",
                    CreatedDate = DateTime.Now
                };
                _unitOfWork.User.Create(usr);
                _unitOfWork.SaveChanges();

                Employee emp = new Employee()
                {
                    ID = 0,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = GenderEnum.M,
                    EmployeeNo = user.EmpNo,
                    EmployeeType = EmployeeTypeEnum.Permanent,
                    Designation = DesignationEnum.AssetIntegritySpecialist,
                    Department = department,
                    Email = user.Email,
                    Phone = user.Phone,
                    Active = true,
                    CreatedBy = "SYSADMIN",
                    CreatedDate = DateTime.Now
                };
                _unitOfWork.Employee.Create(emp);
                _unitOfWork.SaveChanges();

                UserRole userRole = new UserRole()
                {
                    ID = 0,
                    UserID = usr.ID,
                    RoleID = role.ID,
                    Active = true,
                    CreatedBy = "SYSADMIN",
                    CreatedDate = DateTime.Now
                };

                _unitOfWork.UserRole.Create(userRole);
                _unitOfWork.SaveChanges();

                return usr;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void ResetPasswordByUsername(string Username)
        {
            string companyName = "";
            string username = "";
            string temporaryPassword = "";
            string email = "";
            User user = (from u in _unitOfWork.User.FindAll().Where(u => u.Username == Username && u.Active == true) select u).FirstOrDefault();
            if (user != null)
            {
                companyName = user.Company.Name;
                username = user.Username;
                email = user.Email;
                temporaryPassword = Utility.GenerateRandomPassword();
                user.Password = temporaryPassword;
                user.PasswordChangedDate = DateTime.Now;
                user.ModifiedBy = Username;
                user.ModifiedDate = DateTime.Now;

                _unitOfWork.User.Update(user);
                _unitOfWork.SaveChanges();

                // Create Alert
                UserAlertDTO document = new UserAlertDTO();
                document.Username = username;
                document.TemporaryPassword = temporaryPassword;
                document.CompanyName = companyName;
                document.UserEmail = email;
                AlertMaster alert = (from a in _unitOfWork.AlertMaster.FindAll().Where(a => a.Code == "RP" && a.Active == true) select a).FirstOrDefault();
                string emailFrom = alert.EmailFrom;
                string emailSubject = StringifyContent(document, alert.EmailSubject);
                string emailContent = StringifyContent(document, alert.EmailContent);
                string emailTo = StringifyContent(document, alert.EmailTo);

                Utility.SendEmail("192.168.1.20", emailFrom, emailTo, "", emailSubject, emailContent);
            }
        }

        public void ResetPasswordByEmail(string Email)
        {
            string companyName = "";
            string username = "";
            string temporaryPassword = "";
            string email = "";
            User user = (from u in _unitOfWork.User.FindAll().Where(u => u.Email == Email && u.Active == true) select u).FirstOrDefault();
            if (user != null)
            {
                companyName = user.Company.Name;
                username = user.Username;
                email = user.Email;
                temporaryPassword = Utility.GenerateRandomPassword();
                user.Password = temporaryPassword;
                user.PasswordChangedDate = DateTime.Now;
                user.ModifiedBy = user.Username;
                user.ModifiedDate = DateTime.Now;

                _unitOfWork.User.Update(user);
                _unitOfWork.SaveChanges();

                // Create Alert
                UserAlertDTO document = new UserAlertDTO();
                document.Username = username;
                document.TemporaryPassword = temporaryPassword;
                document.CompanyName = companyName;
                document.UserEmail = email;
                AlertMaster alert = (from a in _unitOfWork.AlertMaster.FindAll().Where(a => a.Code == "RP" && a.Active == true) select a).FirstOrDefault();
                string emailFrom = alert.EmailFrom;
                string emailSubject = StringifyContent(document, alert.EmailSubject);
                string emailContent = StringifyContent(document, alert.EmailContent);
                string emailTo = StringifyContent(document, alert.EmailTo);

                Utility.SendEmail("192.168.1.20", emailFrom, emailTo, "", emailSubject, emailContent);
            }
        }

        public void ChangePassword(UserPasswordDTO userPasswordDTO)
        {
            string companyName = "";
            string username = "";
            string newPassword = "";
            string email = "";
            User user = (from u in _unitOfWork.User.FindAll().Where(u => u.Username == userPasswordDTO.Username && u.Password == userPasswordDTO.OldPassword && u.Active == true) select u).FirstOrDefault();
            if (user != null)
            {
                companyName = user.Company.Name;
                username = user.Username;
                email = user.Email;
                newPassword = userPasswordDTO.NewPassword;
                user.Password = newPassword;
                user.PasswordChangedDate = DateTime.Now;
                user.ModifiedBy = user.Username;
                user.ModifiedDate = DateTime.Now;

                _unitOfWork.User.Update(user);
                _unitOfWork.SaveChanges();

                // Create Alert
                UserAlertDTO document = new UserAlertDTO();
                document.Username = username;
                document.CompanyName = companyName;
                document.UserEmail = email;
                AlertMaster alert = (from a in _unitOfWork.AlertMaster.FindAll().Where(a => a.Code == "CP" && a.Active == true) select a).FirstOrDefault();
                string emailFrom = alert.EmailFrom;
                string emailSubject = StringifyContent(document, alert.EmailSubject);
                string emailContent = StringifyContent(document, alert.EmailContent);
                string emailTo = StringifyContent(document, alert.EmailTo);

                Utility.SendEmail("192.168.1.20", emailFrom, emailTo, "", emailSubject, emailContent);
            }
        }

        public UserDetailDTO Login(string username)
        {
            UserDetailDTO userDetail =  (from u in _unitOfWork.User.FindAll().Where(u => u.Username == username)
                    //join ur in _context.UserRole on u.ID equals ur.UserID
                    //join r in _context.Role on ur.RoleID equals r.ID
                    join e in _context.Employee on u.Username equals e.EmployeeNo
                    join d in _context.Department on e.DepartmentID equals d.ID
                    join c in _context.Company on d.CompanyID equals c.ID
                    select new UserDetailDTO
                    {
                        UserID = u.ID,
                        Username = u.Username,
                        PasswordHash = u.PasswordHash,
                      //  Role = r.Name,
                        Email = u.Email,
                        EmployeeNo = e.EmployeeNo,
                        EmployeeName = e.FirstName + " " + e.LastName,
                        EmployeePhoto = e.PhotoContent,
                        CompanyID = c.ID,
                        CompanyName = c.Name,
                        CompanyLogo = c.LogoContent,
                        Department = d.Name

                    }).FirstOrDefault();

            if (userDetail != null)
            {
                userDetail.Role = string.Join(", ", (from ur in _unitOfWork.UserRole.FindAll().Where(ur => ur.UserID == userDetail.UserID)
                                                    join r in _context.Role on ur.RoleID equals r.ID
                                                    select(r.Name)));
            }

            return userDetail;
        }

        public void Logout(string username)
        {

        }

        public List<MenuDTO> GetTopMenu(int CompanyID)
        {
            //List<MenuDTO> menuTreeView = new List<MenuDTO>();

            List<MenuDTO> menuData = (from m in _unitOfWork.Menu.GenerateEntityAsIQueryable().Where(c=> c.ParentMenuID.HasValue == false)                                   
                                      orderby m.DisplayOrder
                                      select new MenuDTO()
                                      {
                                          ID = m.ID.ToString(),
                                          ParentID = (m.ParentMenuID.HasValue ? m.ParentMenuID.Value.ToString() : "0"),
                                          Code = m.Code,
                                          Name = m.Name,
                                          Path = m.Path,
                                          Icon = m.Icon,
                                          DisplayOrder = m.DisplayOrder
                                      }).Distinct().ToList();

            //if (menuData != null && menuData.Count() > 0)
            //{
            //    menuTreeView = menuData.Where(menu => menu.ParentID == "0").ToList();

            //    foreach (var menuItem in menuTreeView)
            //    {
            //        BuildTreeviewMenu(menuItem, menuData);
            //    }
            //}
            //else
            //    menuTreeView = new List<MenuDTO>();

            return menuData.OrderBy(m => m.DisplayOrder).ToList();
        }

        private void BuildTreeviewMenu(MenuDTO menuItem, List<MenuDTO> menuData)
        {
            List<MenuDTO> _menuItems;

            _menuItems = menuData.Where(menu => menu.ParentID == menuItem.ID).ToList();

            if (_menuItems != null && _menuItems.Count() > 0)
            {
                foreach (var item in _menuItems)
                {
                    menuItem.SubMenu.Add(item);
                    BuildTreeviewMenu(item, menuData);
                }
                if (menuItem.SubMenu != null && menuItem.SubMenu.Count > 0)
                    menuItem.SubMenu = menuItem.SubMenu.OrderBy(m => m.DisplayOrder).ToList();
            }
        }

        public List<QuickLinkDTO> GetQuickLink(int UserID, int MenuID)
        {
            return (from q in _unitOfWork.QuickLink.GenerateEntityAsIQueryable()
                    join rmq in _unitOfWork.RoleMenuQuickLink.GenerateEntityAsIQueryable() on q.ID equals rmq.QuickLinkID
                    join ur in _unitOfWork.UserRole.GenerateEntityAsIQueryable() on rmq.RoleID equals ur.RoleID
                    where ur.UserID == UserID && rmq.MenuID == MenuID
                    select new QuickLinkDTO()
                    {
                        QuickLinkID = q.ID,
                        QuickLinkName = q.Name,
                        QuickLinkUrl = string.Format("?DocumentType={0}&{1}=", q.DestinationTable, q.DestinationTableColumn),
                        QuickLinkIcon = q.Icon
                    }).Distinct().ToList();
        }

        public List<MenuDTO> GetPlantMenu(int CompanyID)
        {
            List<MenuDTO> menuTreeView = new List<MenuDTO>();

            List<MenuDTO> menuData = (from p in _unitOfWork.Plant.GenerateEntityAsIQueryable()
                                      where p.CompanyID == CompanyID
                                      select new MenuDTO()
                                      {
                                          ID = p.ID.ToString(),
                                          ParentID = (p.ParentPlantID.HasValue ? p.ParentPlantID.Value.ToString() : "0"),
                                          Name = p.Name,
                                          Icon = p.Icon,
                                          Path = ""
                                      }).Distinct().ToList();

            if (menuData != null && menuData.Count() > 0)
            {
                List<MenuDTO> childPlants = menuData.Where(menu => menu.ParentID != "0").ToList();

                foreach (var menuItem in childPlants)
                {
                    MenuDTO fluid = new MenuDTO()
                    {
                        ID = menuItem.ID.ToString() + "_Fluid",
                        ParentID = menuItem.ID,
                        Name = "Fluid",
                        Icon = "",
                        Path = ""
                    };
                    menuData.Add(fluid);
                }

                menuTreeView = menuData.Where(menu => menu.ParentID == "0").ToList();


                    foreach (var menuItem in menuTreeView)
                {
                    BuildTreeMenu(menuItem, menuData);
                }
            }
            else
                menuTreeView = new List<MenuDTO>();

            return menuTreeView.OrderBy(m => m.ID).ToList();
        }

        public List<MenuDTO> GetPipeMasterMenu(int CompanyID)
        {
            // List<MenuDTO> menuDTOList = new List<MenuDTO>();
            List<MenuDTO> menuData = new List<MenuDTO>();
            List<PipeMasterMenuDTO> pipeMasterDTOList = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                                                         join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                                                         join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                                                         join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                                                         //  into pm from pmm in pm.DefaultIfEmpty()
                                                         where p.CompanyID == CompanyID
                                                         select new PipeMasterMenuDTO()
                                                         {
                                                             CompanyID = p.CompanyID,
                                                             CompanyName = c.Name,
                                                             PlantID = p.ID,
                                                             PlantCode = p.Code,
                                                             PlantName = p.Name,
                                                             ParentPlantID = p.ParentPlantID.Value,
                                                             ParentPlantName = pp.Name,
                                                             Fluid = m.Fluid,
                                                             PipeMasterID = m.ID,
                                                             EquipmentNo = m.EquipmentNo,
                                                         }).Distinct().ToList();


            if (pipeMasterDTOList != null && pipeMasterDTOList.Count() > 0)
            {
                List<int> plants = pipeMasterDTOList.Select(p => p.PlantID).Distinct().ToList();
                foreach (int plant in plants)
                {
                    List<PipeMasterMenuDTO> plantDTOList = pipeMasterDTOList.Where(p => p.PlantID == plant).ToList();

                    if (plantDTOList != null && plantDTOList.Count > 0)
                    {
                        // Fluids
                        List<string> fluids = plantDTOList.Select(p => p.Fluid).Distinct().ToList();
                        fluids.Sort();

                        foreach (string item in fluids)
                        {
                            MenuDTO fluid = new MenuDTO()
                            {
                                ID = plant.ToString() + "_" + item,
                                ParentID = plant.ToString() + "_Fluid",
                                //ParentID = plant.ToString(),
                                Code = item,
                                Name = item,
                                Icon = "",
                                Path = "",
                                BreadCrumb = ""
                            };

                            List<MenuDTO> items = plantDTOList.Where(p => p.Fluid == item)
                                .Select(p => new MenuDTO()
                                {
                                    ID = p.PipeMasterID.ToString(),
                                    ParentID = plant.ToString() + "_" + item,
                                    Code = p.EquipmentNo,
                                    Name = p.EquipmentNo,
                                    Icon = "",
                                    Path = p.EquipmentNo,
                                    BreadCrumb = p.ParentPlantName + " » " + p.PlantName + " » " + item + " » " + p.EquipmentNo
                                }).OrderBy(m => m.Name).ToList();

                            fluid.SubMenu.AddRange(items);
                            menuData.Add(fluid);
                        }
                    }
                }
            }

            return menuData;
        }
        public MenuDTO GetPipeMasterCurrentMenu(int UnitID)
        {
            MenuDTO currentItem = new MenuDTO();
            PipeMasterMenuDTO nextMenuData = new PipeMasterMenuDTO();
            nextMenuData = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                            join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                            join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                            join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                            //  into pm from pmm in pm.DefaultIfEmpty()
                            where m.ID == UnitID 
                            select new PipeMasterMenuDTO()
                            {
                                CompanyID = p.CompanyID,
                                CompanyName = c.Name,
                                PlantID = p.ID,
                                PlantCode = p.Code,
                                PlantName = p.Name,
                                ParentPlantID = p.ParentPlantID.Value,
                                ParentPlantName = pp.Name,
                                Fluid = m.Fluid,
                                PipeMasterID = m.ID,
                                EquipmentNo = m.EquipmentNo,
                            }).Distinct().FirstOrDefault();
           
            if (nextMenuData != null)
            {
                currentItem = new MenuDTO()
                {
                    ID = nextMenuData.PipeMasterID.ToString(),
                    ParentID = nextMenuData.PlantID.ToString() + "_" + nextMenuData.Fluid,
                    Code = nextMenuData.EquipmentNo,
                    Name = nextMenuData.EquipmentNo,
                    Icon = "",
                    Path = nextMenuData.EquipmentNo,
                    BreadCrumb = nextMenuData.ParentPlantName + " » " + nextMenuData.PlantName + " » " + nextMenuData.Fluid + " » " + nextMenuData.EquipmentNo
                };
            }

            return currentItem;
        }

        public MenuDTO GetPipeMasterNextMenu(int UnitID)
        {
            MenuDTO nextItem = new MenuDTO();
            List<PipeMasterMenuDTO> menuData = new List<PipeMasterMenuDTO>();
            PipeMasterMenuDTO currentMenuData = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                            join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                            join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                            join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                            //  into pm from pmm in pm.DefaultIfEmpty()
                            where m.ID == UnitID
                            select new PipeMasterMenuDTO()
                            {
                                CompanyID = p.CompanyID,
                                CompanyName = c.Name,
                                PlantID = p.ID,
                                PlantCode = p.Code,
                                PlantName = p.Name,
                                ParentPlantID = p.ParentPlantID.Value,
                                ParentPlantName = pp.Name,
                                Fluid = m.Fluid,
                                PipeMasterID = m.ID,
                                EquipmentNo = m.EquipmentNo,
                            }).Distinct().FirstOrDefault();

            menuData = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                            join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                            join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                            join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                            //  into pm from pmm in pm.DefaultIfEmpty()
                            where
                            p.CompanyID == currentMenuData.CompanyID
                            && p.ParentPlantID == currentMenuData.ParentPlantID  
                            && p.ID  == currentMenuData.PlantID
                            && m.Fluid == currentMenuData.Fluid
                        select new PipeMasterMenuDTO()
                            {
                                CompanyID = p.CompanyID,
                                CompanyName = c.Name,
                                PlantID = p.ID,
                                PlantCode = p.Code,
                                PlantName = p.Name,
                                ParentPlantID = p.ParentPlantID.Value,
                                ParentPlantName = pp.Name,
                                Fluid = m.Fluid,
                                PipeMasterID = m.ID,
                                EquipmentNo = m.EquipmentNo,
                            }).ToList();

            if (menuData != null)
            {
                menuData = menuData.OrderBy(p => p.PlantName).ThenBy(p => p.Fluid).ThenBy(p => p.EquipmentNo).ToList();
                bool flag = false;
                foreach(PipeMasterMenuDTO nextMenuData in menuData)
                {
                    if(flag == true)
                    {
                        nextItem = new MenuDTO()
                        {
                            ID = nextMenuData.PipeMasterID.ToString(),
                            ParentID = nextMenuData.PlantID.ToString() + "_" + nextMenuData.Fluid,
                            Code = nextMenuData.EquipmentNo,
                            Name = nextMenuData.EquipmentNo,
                            Icon = "",
                            Path = nextMenuData.EquipmentNo,
                            BreadCrumb = nextMenuData.ParentPlantName + " » " + nextMenuData.PlantName + " » " + nextMenuData.Fluid + " » " + nextMenuData.EquipmentNo
                        };
                        return nextItem;
                    }
                    if(flag == false && nextMenuData.PipeMasterID == UnitID)
                    {
                        flag = true;
                        continue;
                    }
                }
            }
               
            if (currentMenuData != null)
            {
                nextItem = new MenuDTO()
                {
                    ID = currentMenuData.PipeMasterID.ToString(),
                    ParentID = currentMenuData.PlantID.ToString() + "_" + currentMenuData.Fluid,
                    Code = currentMenuData.EquipmentNo,
                    Name = currentMenuData.EquipmentNo,
                    Icon = "",
                    Path = currentMenuData.EquipmentNo,
                    BreadCrumb = currentMenuData.ParentPlantName + " » " + currentMenuData.PlantName + " » " + currentMenuData.Fluid + " » " + currentMenuData.EquipmentNo
                };
            }

            return nextItem;
        }

        public MenuDTO GetPipeMasterPreviousMenu(int UnitID)
        {
            MenuDTO previousItem = new MenuDTO();
            List<PipeMasterMenuDTO> menuData = new List<PipeMasterMenuDTO>();
            PipeMasterMenuDTO currentMenuData = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                                                 join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                                                 join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                                                 join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                                                 //  into pm from pmm in pm.DefaultIfEmpty()
                                                 where m.ID == UnitID
                                                 select new PipeMasterMenuDTO()
                                                 {
                                                     CompanyID = p.CompanyID,
                                                     CompanyName = c.Name,
                                                     PlantID = p.ID,
                                                     PlantCode = p.Code,
                                                     PlantName = p.Name,
                                                     ParentPlantID = p.ParentPlantID.Value,
                                                     ParentPlantName = pp.Name,
                                                     Fluid = m.Fluid,
                                                     PipeMasterID = m.ID,
                                                     EquipmentNo = m.EquipmentNo,
                                                 }).Distinct().FirstOrDefault();

            menuData = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                        join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                        join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                        join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                        //  into pm from pmm in pm.DefaultIfEmpty()
                        where
                        p.CompanyID == currentMenuData.CompanyID
                        && p.ParentPlantID == currentMenuData.ParentPlantID
                        && p.ID == currentMenuData.PlantID
                        && m.Fluid == currentMenuData.Fluid
                        select new PipeMasterMenuDTO()
                        {
                            CompanyID = p.CompanyID,
                            CompanyName = c.Name,
                            PlantID = p.ID,
                            PlantCode = p.Code,
                            PlantName = p.Name,
                            ParentPlantID = p.ParentPlantID.Value,
                            ParentPlantName = pp.Name,
                            Fluid = m.Fluid,
                            PipeMasterID = m.ID,
                            EquipmentNo = m.EquipmentNo,
                        }).ToList();

            if (menuData != null)
            {
                menuData = menuData.OrderBy(p => p.PlantName).ThenBy(p => p.Fluid).ThenBy(p => p.EquipmentNo).ToList();
                bool flag = false;
                PipeMasterMenuDTO tempData = new PipeMasterMenuDTO();
                int itemOrder = 0;
                foreach (PipeMasterMenuDTO nextMenuData in menuData)
                {                   
                    if (nextMenuData.PipeMasterID == UnitID  )
                    {
                        if (itemOrder == 0)
                            break;
                        else
                        {
                            previousItem = new MenuDTO()
                            {
                                ID = tempData.PipeMasterID.ToString(),
                                ParentID = tempData.PlantID.ToString() + "_" + nextMenuData.Fluid,
                                Code = tempData.EquipmentNo,
                                Name = tempData.EquipmentNo,
                                Icon = "",
                                Path = tempData.EquipmentNo,
                                BreadCrumb = tempData.ParentPlantName + " » " + tempData.PlantName + " » " + tempData.Fluid + " » " + tempData.EquipmentNo
                            };
                            return previousItem;
                        }                        
                    }
                    else
                    {
                        tempData = new PipeMasterMenuDTO()
                        {                            
                            CompanyID = nextMenuData.CompanyID,
                            CompanyName = nextMenuData.CompanyName,
                            PlantID = nextMenuData.PlantID,
                            PlantCode = nextMenuData.PlantCode,
                            PlantName = nextMenuData.PlantName,
                            ParentPlantID = nextMenuData.ParentPlantID,
                            ParentPlantName = nextMenuData.ParentPlantName,
                            Fluid = nextMenuData.Fluid,
                            PipeMasterID = nextMenuData.PipeMasterID,
                            EquipmentNo = nextMenuData.EquipmentNo
                        };                            
                            
                        itemOrder = itemOrder + 1;
                    }           

                }                
            }

            if (currentMenuData != null)
            {
                previousItem = new MenuDTO()
                {
                    ID = currentMenuData.PipeMasterID.ToString(),
                    ParentID = currentMenuData.PlantID.ToString() + "_" + currentMenuData.Fluid,
                    Code = currentMenuData.EquipmentNo,
                    Name = currentMenuData.EquipmentNo,
                    Icon = "",
                    Path = currentMenuData.EquipmentNo,
                    BreadCrumb = currentMenuData.ParentPlantName + " » " + currentMenuData.PlantName + " » " + currentMenuData.Fluid + " » " + currentMenuData.EquipmentNo
                };
            }

            return previousItem;
        }

        public List<MenuDTO> GetLeftMenu(int CompanyID)
        {
            List<MenuDTO> menuDTOList = new List<MenuDTO>();

            List<MenuDTO> menuData = new List<MenuDTO>();

            List<MenuDTO> plantMasterData = (from p in _unitOfWork.Plant.GenerateEntityAsIQueryable()
                                             where p.CompanyID == CompanyID
                                             select new MenuDTO()
                                             {
                                                 ID = "Plant_" + p.ID.ToString(),
                                                 ParentID = (p.ParentPlantID.HasValue ? "Plant_" + p.ParentPlantID.Value.ToString() : "0"),
                                                 Code = p.Code,
                                                 Name = p.Name,
                                                 Icon = p.Icon,
                                                 Path = "",
                                                 BreadCrumb = p.Name
                                             }).Distinct().ToList();

            List<PipeMasterMenuDTO> pipeMasterMenuDTOList = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                                                             join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                                                             join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                                                             join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                                                             //  into pm from pmm in pm.DefaultIfEmpty()
                                                             where p.CompanyID == CompanyID
                                                             select new PipeMasterMenuDTO()
                                                             {
                                                                 CompanyID = p.CompanyID,
                                                                 CompanyName = c.Name,
                                                                 PlantID = p.ID,
                                                                 PlantCode = p.Code,
                                                                 PlantName = p.Name,
                                                                 ParentPlantID = p.ParentPlantID.Value,
                                                                 ParentPlantName = pp.Name,
                                                                 Fluid = m.Fluid,
                                                                 PipeMasterID = m.ID,
                                                                 EquipmentNo = m.EquipmentNo,
                                                             }).Distinct().ToList();


            if (plantMasterData != null && plantMasterData.Count() > 0)
            {
                menuData.AddRange(plantMasterData);

                List<MenuDTO> childPlantDTOList = plantMasterData.Where(menu => menu.ParentID != "0").ToList();
                foreach (var menuItem in childPlantDTOList)
                {
                    List<PipeMasterMenuDTO> plantDTOList = pipeMasterMenuDTOList.Where(p => p.PlantCode == menuItem.Code).ToList();

                    if (plantDTOList != null && plantDTOList.Count > 0)
                    {
                        // Components
                        MenuDTO component = new MenuDTO()
                        {
                            ID = menuItem.ID + "_COMPONENT",
                            ParentID =  menuItem.ID,
                            Code = "Fluid",
                            Name = "Fluid",
                            Icon = "",
                            Path = "",
                            BreadCrumb = ""
                        };
                        menuData.Add(component);

                        // Fluids
                        List<string> fluids = plantDTOList.Select(p => p.Fluid).Distinct().ToList();

                        foreach (string item in fluids)
                        {
                            MenuDTO fluid = new MenuDTO()
                            {
                                ID = menuItem.ID + "_FLUID_" + item,
                                ParentID = menuItem.ID + "_COMPONENT",
                                Code = item,
                                Name = item,
                                Icon = "",
                                Path = "",
                                BreadCrumb = ""
                            };
                            menuData.Add(fluid);

                            List<MenuDTO> items = plantDTOList.Where(p => p.Fluid == item)
                                .Select(p => new MenuDTO()
                                {
                                    //   ID = menuItem.ID + "_FLUID_" + item + "_" + p.PipeMasterID.ToString(),
                                    ID = p.PipeMasterID.ToString(),
                                    ParentID = menuItem.ID + "_FLUID_" + item,
                                    Code = p.EquipmentNo,
                                    Name = p.EquipmentNo,
                                    Icon = "",
                                    Path = p.EquipmentNo,
                                    BreadCrumb = p.ParentPlantName + " » " + p.PlantName + " » " + item + " » " + p.EquipmentNo
                                }).ToList();

                            menuData.AddRange(items);
                        }
                    }
                }
            }


            if (menuData != null && menuData.Count() > 0)
            {
                menuDTOList = menuData.Where(menu => menu.ParentID == "0").ToList();

                foreach (var menuItem in menuDTOList)
                {
                    BuildTreeMenu(menuItem, menuData);
                }
            }
            else
                menuDTOList = new List<MenuDTO>();

            return menuDTOList.OrderBy(m => m.ID).ToList();
        }
        public List<PipeMasterMenuDTO> GetPipeMaster(int CompanyID)
        {
            List<PipeMasterMenuDTO> pipeMasterMenuDTOList = new List<PipeMasterMenuDTO>();

            pipeMasterMenuDTOList = (from m in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                                     join p in _unitOfWork.Plant.GenerateEntityAsIQueryable() on m.PlantCode equals p.Code
                                     join c in _unitOfWork.Company.GenerateEntityAsIQueryable() on p.CompanyID equals c.ID
                                     join pp in _unitOfWork.Plant.GenerateEntityAsIQueryable() on p.ParentPlantID equals pp.ID
                                     //  into pm from pmm in pm.DefaultIfEmpty()
                                     where p.CompanyID == CompanyID
                                     select new PipeMasterMenuDTO()
                                     {
                                         CompanyID = p.CompanyID,
                                         CompanyName = c.Name,
                                         PlantID = p.ID,
                                         PlantName = p.Name,
                                         ParentPlantID = p.ParentPlantID.Value,
                                         ParentPlantName = pp.Name,
                                         Fluid = m.Fluid,
                                         PipeMasterID = m.ID,
                                         EquipmentNo = m.EquipmentNo,
                                     }).Distinct().ToList();

            return pipeMasterMenuDTOList;
        }

        private void BuildTreeMenu(MenuDTO menuItem, List<MenuDTO> menuData)
        {
            List<MenuDTO> _menuItems;

            _menuItems = menuData.Where(menu => menu.ParentID == menuItem.ID).ToList();

            if (_menuItems != null && _menuItems.Count() > 0)
            {
                foreach (var item in _menuItems)
                {
                    menuItem.SubMenu.Add(item);
                    BuildTreeMenu(item, menuData);
                }

                if (menuItem.SubMenu != null && menuItem.SubMenu.Count > 0)
                    menuItem.SubMenu = menuItem.SubMenu.OrderBy(m => m.Name).ToList();
            }
        }

        private String StringifyContent(UserAlertDTO document, String content)
        {
            String result = content;
            result = result.Replace("{{CompanyName}}", document.CompanyName);
            result = result.Replace("{{Username}}", document.Username);
            result = result.Replace("{{TemporaryPassword}}", document.TemporaryPassword);
            return result;
        }
    }
}

