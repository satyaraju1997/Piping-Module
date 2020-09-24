using AutoMapper;
using Piping.Contracts.Services;
using Piping.Contracts.Repository;
using Piping.Repository;
using Piping.DTO;
using Piping.Entities;
using Piping.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;
using System.IO;

namespace Piping.Services
{
    public class CompanyService : ICompanyService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<CompanyDTO> GetAll()
        {
            return (from p in _unitOfWork.Company.FindAll()
                    select new CompanyDTO
                    {
                        ID = p.ID,
                        Code = p.Code,
                        Name = p.Name,
                        LogoName = p.LogoName,
                        LogoContent = p.LogoContent,
                        Address = p.Address,
                        Website = p.Website,
                        Email = p.Email,
                        Phone = p.Phone,
                        Active = p.Active,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    })
                .ToList();
        }

        public CompanyDTO GetByCompanyID(int ID)
        {
            return (from p in _unitOfWork.Company.FindAll().Where(p => p.ID == ID)
                    select new CompanyDTO
                    {
                        ID = p.ID,
                        Code = p.Code,
                        Name = p.Name,
                        LogoName = p.LogoName,
                        LogoContent = p.LogoContent,
                        Address = p.Address,
                        Website = p.Website,
                        Email = p.Email,
                        Phone = p.Phone,
                        Active = p.Active,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    })
                .FirstOrDefault();
        }

        public void CreateCompany(CompanyRequestDTO companyDTO)
        {
            string logoName = "";
            byte[] logoContent = null;

            if (!string.IsNullOrWhiteSpace(companyDTO.LogoFilename))
            {
                logoName = Path.GetFileName(companyDTO.LogoFilename);
                logoContent = Utility.ConvertImageToByteArray(companyDTO.LogoFilename);
            }
            else
            {
                logoName = companyDTO.LogoName;
                logoContent = null;
            }
            var obj = new Company()
            {
                Code = companyDTO.Code,
                Name = companyDTO.Name,
                LogoName = logoName,
                LogoContent = logoContent,
                Active = true,
                Address = companyDTO.Address,
                Website = companyDTO.Website,
                Email = companyDTO.Email,
                Phone = companyDTO.Phone,

                CreatedBy = "SYSADMIN",
                CreatedDate = DateTime.Now
            };

            if (!string.IsNullOrWhiteSpace(companyDTO.LogoFilename))
            {
                obj.LogoName = Path.GetFileName(companyDTO.LogoFilename);
                obj.LogoContent = Utility.ConvertImageToByteArray(companyDTO.LogoFilename);
            }

            _unitOfWork.Company.Create(obj);
            _unitOfWork.SaveChanges();
        }
        public void UpdateCompany(CompanyRequestDTO companyDTO)
        {
            var response = _unitOfWork.Company.FindById(companyDTO.ID);
            if (response != null)
            {
                response.Code = companyDTO.Code;
                response.Name = companyDTO.Name;
                response.LogoName = companyDTO.LogoName;
                
                if (!string.IsNullOrWhiteSpace(companyDTO.LogoFilename))
                {
                    response.LogoName = Path.GetFileName(companyDTO.LogoFilename);
                    response.LogoContent = Utility.ConvertImageToByteArray(companyDTO.LogoFilename);
                }
                response.Address = companyDTO.Address;
                response.Website = companyDTO.Website;
                response.Email = companyDTO.Email;
                response.Phone = companyDTO.Phone;
                response.Active = companyDTO.Active;                
            }
            _unitOfWork.Company.Update(response);
            _unitOfWork.SaveChanges();
        }
        public void DeleteCompany(int ID)
        {
            var entity = _unitOfWork.Company.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.Company.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }
       
    }
}
