using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IInspectionDocumentService
    {
        List<InspectionDocumentDTO> GetAll();
        InspectionDocumentDTO GetByID(int ID);
        InspectionDocumentDTO Create(InspectionDocumentDTO obj);
        InspectionDocumentDTO Update(InspectionDocumentDTO obj);
        void Delete(int ID);        
    }
}
