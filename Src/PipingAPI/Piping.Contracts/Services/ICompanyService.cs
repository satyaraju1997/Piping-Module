using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface ICompanyService
    {
        List<CompanyDTO> GetAll();
        CompanyDTO GetByCompanyID(int ID);

        void CreateCompany(CompanyRequestDTO companyRequestDTO);

        void UpdateCompany(CompanyRequestDTO companyRequestDTO);

        void DeleteCompany(int ID);
    }
}
