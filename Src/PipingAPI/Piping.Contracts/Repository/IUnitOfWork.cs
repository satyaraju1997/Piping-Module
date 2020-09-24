using Piping.Entities;
using System.Threading.Tasks;

namespace Piping.Contracts.Repository
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        void SaveChanges();

        // User Management
        IGenericRepository<User> User { get; }
        IGenericRepository<Role> Role { get; }
        IGenericRepository<Menu> Menu { get; }
        IGenericRepository<UserRole> UserRole { get; }
        IGenericRepository<RoleMenuAction> RoleMenuAction { get; }
        IGenericRepository<UserAudit> UserAudit { get; }
        IGenericRepository<QuickLink> QuickLink { get; }
        IGenericRepository<RoleMenuQuickLink> RoleMenuQuickLink { get; }
        IGenericRepository<Department> Department { get; }
        IGenericRepository<Employee> Employee { get; }

        // Pipe Master
        IGenericRepository<Company> Company { get; }
        IGenericRepository<PlantMaster> Plant { get; }
        IGenericRepository<PipeMaster> PipeMaster { get; }
        IGenericRepository<DocumentMaster> DocumentMaster { get; }
        IGenericRepository<POFSCC> POFSCC { get; }
        IGenericRepository<POFODM> POFODM { get; }
        IGenericRepository<POFIC> POFIC { get; }
        IGenericRepository<POFEC> POFEC { get; }
        IGenericRepository<AlertMaster> AlertMaster { get; }
        IGenericRepository<POFMaster> POFMaster { get; }
        IGenericRepository<PipeMasterCOF> PipeMasterCOF { get; }
        IGenericRepository<TMLHistory> TMLHistory { get; }
        IGenericRepository<POF_IC> POF_IC { get; }
        IGenericRepository<POF_EC> POF_EC { get; }
        IGenericRepository<DMMaster> DMMaster { get; }

        // Pipe Report
        IGenericRepository<PipeReport> PipeReport { get; }
        IGenericRepository<InspectionConfidence> InspectionConfidence { get; }
        IGenericRepository<InspectionObservation> InspectionObservation { get; }

        IGenericRepository<InspectionRecommendation> InspectionRecommendation { get; }
        IGenericRepository<InspectionDistribution> InspectionDistribution { get; }
        IGenericRepository<InspectionProgram> InspectionProgram { get; }
        IGenericRepository<InspectionDocument> InspectionDocument { get; }
        IGenericRepository<TML> TML { get; }


        // Lookup Tables
        IGenericRepository<StructuralMinThk> StructuralMinThk { get; }
        IGenericRepository<InsulationType> InsulationType { get; }
        IGenericRepository<MaterialMaster> MaterialMaster { get; }
        IGenericRepository<MaterialCodes> MaterialCodes { get; }
        IGenericRepository<COP> COP { get; }
        IGenericRepository<PRP> PRP { get; }

        IGenericRepository<ExternalCorrosionRate> ExternalCorrosionRate { get; }
        IGenericRepository<ExternalSuceptability> ExternalSuceptablity { get; }
        IGenericRepository<CUICorrosionRate> CUICorrosionRate { get; }
        IGenericRepository<ExternalSeverityIndex> ExternalSeverityIndex { get; }
        IGenericRepository<CUISuceptability> CUISuceptablity { get; }

        IGenericRepository<TMLMaster> TMLMaster { get; }
        IGenericRepository<InspectionStrategy> InspectionStrategy { get; }
        IGenericRepository<ObservationMaster> ObservationMaster { get; }

        // Corrosion Study
        IGenericRepository<PipeCluster> PipeCluster { get; }
        IGenericRepository<CorrosionStudy> CorrosionStudy { get; }
        IGenericRepository<DMGuide> DMGuide { get; }
        IGenericRepository<PipeClusterPOF> PipeClusterPOF { get; }
        IGenericRepository<IOW> IOW { get; }
        IGenericRepository<COFMaster> COFMaster { get; }

        IGenericRepository<RiskAnalysis> RiskAnalysis { get; }
        IGenericRepository<RiskPriority> RiskPriority { get; }

        // COF
        IGenericRepository<COFFlammable> COFFlammable { get; }
        IGenericRepository<FlammableConstant> FlammableConstant { get; }
        IGenericRepository<FluidIC> FluidIC { get; }
        IGenericRepository<RepresentativeFluid> RepresentativeFluid { get; }
        IGenericRepository<FluidProperty> FluidProperty { get; }
        IGenericRepository<LDMax> LDMax { get; }
        IGenericRepository<FluidModel> FluidModel { get; }
        IGenericRepository<DetectionIsolation> DetectionIsolation { get; }
        IGenericRepository<MitigationSystem> MitigationSystem { get; }
        IGenericRepository<GFF> GFF { get; }
    }
}
