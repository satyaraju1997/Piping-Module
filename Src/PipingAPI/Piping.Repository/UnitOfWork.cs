
using Piping.Contracts.Repository;
using Piping.Entities;
using System;
using System.Threading.Tasks;

namespace Piping.Repository
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PipingContext _context;
        public UnitOfWork(PipingContext context)
        {
            _context = context;
        }

        public IGenericRepository<User> User => new GenericRepository<User>(_context);
        public IGenericRepository<Role> Role => new GenericRepository<Role>(_context);
        public IGenericRepository<Menu> Menu => new GenericRepository<Menu>(_context);
        public IGenericRepository<UserRole> UserRole => new GenericRepository<UserRole>(_context);
        public IGenericRepository<RoleMenuAction> RoleMenuAction => new GenericRepository<RoleMenuAction>(_context);
        public IGenericRepository<UserAudit> UserAudit => new GenericRepository<UserAudit>(_context);

        public IGenericRepository<QuickLink> QuickLink => new GenericRepository<QuickLink>(_context);
        public IGenericRepository<RoleMenuQuickLink> RoleMenuQuickLink => new GenericRepository<RoleMenuQuickLink>(_context);
        public IGenericRepository<Company> Company => new GenericRepository<Company>(_context);
        public IGenericRepository<PlantMaster> Plant => new GenericRepository<PlantMaster>(_context);
        public IGenericRepository<Department> Department => new GenericRepository<Department>(_context);
        public IGenericRepository<Employee> Employee => new GenericRepository<Employee>(_context);

        // PipeMaster
        public IGenericRepository<PipeMaster> PipeMaster => new GenericRepository<PipeMaster>(_context);
        public IGenericRepository<PipeMasterCOF> PipeMasterCOF => new GenericRepository<PipeMasterCOF>(_context);
        public IGenericRepository<POFSCC> POFSCC => new GenericRepository<POFSCC>(_context);
        public IGenericRepository<POFODM> POFODM => new GenericRepository<POFODM>(_context);
        public IGenericRepository<POFIC> POFIC => new GenericRepository<POFIC>(_context);
        public IGenericRepository<POFEC> POFEC => new GenericRepository<POFEC>(_context);
        public IGenericRepository<AlertMaster> AlertMaster => new GenericRepository<AlertMaster>(_context);
        //public IGenericRepository<Alert> Alert => new GenericRepository<Alert>(_context);
        public IGenericRepository<DocumentMaster> DocumentMaster => new GenericRepository<DocumentMaster>(_context);
        public IGenericRepository<InspectionStrategy> InspectionStrategy => new GenericRepository<InspectionStrategy>(_context);
        public IGenericRepository<DMMaster> DMMaster => new GenericRepository<DMMaster>(_context);

        public IGenericRepository<POFMaster> POFMaster => new GenericRepository<POFMaster>(_context);
        public IGenericRepository<TMLMaster> TMLMaster => new GenericRepository<TMLMaster>(_context);
        public IGenericRepository<TMLHistory> TMLHistory => new GenericRepository<TMLHistory>(_context);      
        public IGenericRepository<POF_IC> POF_IC => new GenericRepository<POF_IC>(_context);
        public IGenericRepository<POF_EC> POF_EC => new GenericRepository<POF_EC>(_context);

        // Pipe Report
        public IGenericRepository<PipeReport> PipeReport => new GenericRepository<PipeReport>(_context);
        public IGenericRepository<InspectionConfidence> InspectionConfidence => new GenericRepository<InspectionConfidence>(_context);
        public IGenericRepository<InspectionObservation> InspectionObservation => new GenericRepository<InspectionObservation>(_context);
        
        public IGenericRepository<InspectionRecommendation> InspectionRecommendation => new GenericRepository<InspectionRecommendation>(_context);
        public IGenericRepository<InspectionDistribution> InspectionDistribution => new GenericRepository<InspectionDistribution>(_context);
        public IGenericRepository<InspectionProgram> InspectionProgram => new GenericRepository<InspectionProgram>(_context);
        public IGenericRepository<InspectionDocument> InspectionDocument => new GenericRepository<InspectionDocument>(_context);
        public IGenericRepository<TML> TML => new GenericRepository<TML>(_context);
        

        //Lookup Tables

        public IGenericRepository<StructuralMinThk> StructuralMinThk => new GenericRepository<StructuralMinThk>(_context);
        public IGenericRepository<InsulationType> InsulationType => new GenericRepository<InsulationType>(_context);
        public IGenericRepository<MaterialCodes> MaterialCodes => new GenericRepository<MaterialCodes>(_context);
        public IGenericRepository<MaterialMaster> MaterialMaster => new GenericRepository<MaterialMaster>(_context);
        public IGenericRepository<COP> COP => new GenericRepository<COP>(_context);
        public IGenericRepository<PRP> PRP => new GenericRepository<PRP>(_context);

        public IGenericRepository<ExternalCorrosionRate> ExternalCorrosionRate => new GenericRepository<ExternalCorrosionRate>(_context);
        public IGenericRepository<ExternalSuceptability> ExternalSuceptablity => new GenericRepository<ExternalSuceptability>(_context);
        public IGenericRepository<CUICorrosionRate> CUICorrosionRate => new GenericRepository<CUICorrosionRate>(_context);
        public IGenericRepository<ExternalSeverityIndex> ExternalSeverityIndex => new GenericRepository<ExternalSeverityIndex>(_context);
        public IGenericRepository<CUISuceptability> CUISuceptablity => new GenericRepository<CUISuceptability>(_context);
        public IGenericRepository<ObservationMaster> ObservationMaster => new GenericRepository<ObservationMaster>(_context);

        // Corrosion Study
        public IGenericRepository<PipeCluster> PipeCluster => new GenericRepository<PipeCluster>(_context);
        public IGenericRepository<CorrosionStudy> CorrosionStudy => new GenericRepository<CorrosionStudy>(_context);
        public IGenericRepository<DMGuide> DMGuide => new GenericRepository<DMGuide>(_context);
        public IGenericRepository<PipeClusterPOF> PipeClusterPOF => new GenericRepository<PipeClusterPOF>(_context);
        public IGenericRepository<IOW> IOW => new GenericRepository<IOW>(_context);
        public IGenericRepository<COFMaster> COFMaster => new GenericRepository<COFMaster>(_context);

        public IGenericRepository<RiskAnalysis> RiskAnalysis => new GenericRepository<RiskAnalysis>(_context);
        public IGenericRepository<RiskPriority> RiskPriority => new GenericRepository<RiskPriority>(_context);

        // COF
        public IGenericRepository<COFFlammable> COFFlammable => new GenericRepository<COFFlammable>(_context);
        public IGenericRepository<FlammableConstant> FlammableConstant => new GenericRepository<FlammableConstant>(_context);
        public IGenericRepository<FluidIC> FluidIC => new GenericRepository<FluidIC>(_context);
        public IGenericRepository<RepresentativeFluid> RepresentativeFluid => new GenericRepository<RepresentativeFluid>(_context);
        public IGenericRepository<FluidProperty> FluidProperty => new GenericRepository<FluidProperty>(_context);
        public IGenericRepository<LDMax> LDMax => new GenericRepository<LDMax>(_context);
        public IGenericRepository<FluidModel> FluidModel => new GenericRepository<FluidModel>(_context);
        public IGenericRepository<DetectionIsolation> DetectionIsolation => new GenericRepository<DetectionIsolation>(_context);
        public IGenericRepository<MitigationSystem> MitigationSystem => new GenericRepository<MitigationSystem>(_context);
        public IGenericRepository<GFF> GFF => new GenericRepository<GFF>(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}