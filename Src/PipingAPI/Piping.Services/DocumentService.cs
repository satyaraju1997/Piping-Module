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
using Piping.Common.Enums;

namespace Piping.Services
{
    public class DocumentService : IDocumentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public DocumentService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<DocumentDTO> GetByReferenceNo(string documentType, string ReferenceNo)
        {
            return (from d in _unitOfWork.DocumentMaster.GenerateEntityAsIQueryable().Where(d =>  d.ReferenceNo == ReferenceNo)
                    select new DocumentDTO
                    {
                        ID = d.ID,
                        DocumentNo = d.DocumentNo,
                        Description = d.Description,
                        FileName = d.FileName,
                        Content = d.Content,
                        Format = d.Format,
                        Active = d.Active,
                        DocumentType = d.DocumentType.ToString(),
                        ReferenceNo = d.ReferenceNo,
                        CreatedBy = d.CreatedBy,
                        CreatedDate = d.CreatedDate,
                        ModifiedBy = d.ModifiedBy,
                        ModifiedDate = d.ModifiedDate
                    })
                .ToList();
        }
        public DocumentDTO GetByID(int ID)
        {
            return (from d in _unitOfWork.DocumentMaster.GenerateEntityAsIQueryable().Where(d => d.ID == ID)
                    select new DocumentDTO
                    {
                        ID = d.ID,
                        DocumentNo = d.DocumentNo,
                        Description = d.Description,
                        FileName = d.FileName,
                        Content = d.Content,
                        Format = d.Format,                       
                        Active = d.Active,
                        DocumentType =d.DocumentType.ToString(),
                        ReferenceNo = d.ReferenceNo,
                        CreatedBy = d.CreatedBy,
                        CreatedDate = d.CreatedDate,
                        ModifiedBy = d.ModifiedBy,
                        ModifiedDate = d.ModifiedDate
                    })
                .FirstOrDefault();
        }
        public void Create(DocumentDTO documentDTO)
        {
            DocumentMaster obj = _mapper.Map<DocumentMaster>(documentDTO);
            obj.CreatedDate = DateTime.Now;
            _unitOfWork.DocumentMaster.Create(obj);
            _unitOfWork.SaveChanges();           
        }
        public void Update(DocumentDTO documentDTO)
        {
            var response = _unitOfWork.DocumentMaster.FindById(documentDTO.ID);
            if (response != null)
            {
                response.DocumentNo = documentDTO.DocumentNo;
                response.Description = documentDTO.Description;
                response.FileName = documentDTO.FileName;
                response.Content = documentDTO.Content;
                response.Format = documentDTO.Format;
                response.DocumentType = DocumentTypeEnum.PipingMaster;
                response.ReferenceNo = documentDTO.ReferenceNo;                
                response.Active = documentDTO.Active;               
                response.ModifiedBy = documentDTO.ModifiedBy;
                response.ModifiedDate = DateTime.Now;
            }
            _unitOfWork.DocumentMaster.Update(response);
            _unitOfWork.SaveChanges();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.DocumentMaster.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.DocumentMaster.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }
       
    }
}
