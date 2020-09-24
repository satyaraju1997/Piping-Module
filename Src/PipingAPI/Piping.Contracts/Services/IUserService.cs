using Piping.DTO;
using System.Collections.Generic;
using Piping.Entities;

namespace Piping.Contracts.Services
{
    public interface IUserService
    {
        bool UserExists(string username);
        User Register(UserRegisterDTO userRegisterDTO);
        UserDetailDTO Login(string username);
        void Logout(string username);
        List<MenuDTO> GetTopMenu(int UserID);
        List<QuickLinkDTO> GetQuickLink(int UserID, int MenuID);
        List<MenuDTO> GetPlantMenu(int CompanyID);
        List<MenuDTO> GetPipeMasterMenu(int CompanyID);
        List<MenuDTO> GetLeftMenu(int CompanyID);

        void ResetPasswordByEmail(string Email);
        void ResetPasswordByUsername(string Username);
        void ChangePassword(UserPasswordDTO userPasswordDTO);

        MenuDTO GetPipeMasterPreviousMenu(int UnitID);
        MenuDTO GetPipeMasterNextMenu(int UnitID);
        MenuDTO GetPipeMasterCurrentMenu(int UnitID);
    }
}
