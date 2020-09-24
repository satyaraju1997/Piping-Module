using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IDocumentService
    {
        List<DocumentDTO> GetByReferenceNo(string documentType, string ReferenceNo);
        DocumentDTO GetByID(int ID);

        void Create(DocumentDTO documentDTO);

        void Update(DocumentDTO documentDTO);

        void Delete(int ID);
    }
}
