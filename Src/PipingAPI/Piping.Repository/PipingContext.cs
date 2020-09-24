using Microsoft.EntityFrameworkCore;
using Piping.Entities;
using System;
using System.IO;
using System.Linq;
using System.Drawing;
using Piping.Common.Enums;
using Piping.Common;

namespace Piping.Repository
{
    public class PipingContext : DbContext
    {
        const string EMPPHOTO= "Photo.png";
        const string COMPANYLOGO = "Logo.png";
        const string EMAILFROM = "praveen.mondithoka@senecaglobal.com";
        public PipingContext(DbContextOptions<PipingContext> options) : base(options)
        {
            Database.SetCommandTimeout(600000);
        }

        // User Management
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Piping.Entities.Action> Action { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RoleMenuAction> RoleMenuAction { get; set; }
        public DbSet<UserAudit> UserAudit { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<PlantMaster> Plant { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        
        // Master
        public DbSet<MaterialMaster> MaterialMaster { get; set; }
        public DbSet<COP> COP { get; set; }
        public DbSet<PRP> PRP { get; set; }
        public DbSet<StructuralMinThk> StructuralMinThk { get; set; }
        public DbSet<ExternalCorrosionRate> ExternalCorrosionRate { get; set; }
        public DbSet<ExternalSuceptability> ExternalSuceptability { get; set; }
        public DbSet<CUICorrosionRate> CUICorrosionRate { get; set; }
        public DbSet<CUISuceptability> CUISuceptability { get; set; }
        public DbSet<ExternalSeverityIndex> ExternalSeverityIndex { get; set; }
        public DbSet<ObservationMaster> ObservationMaster { get; set; }
        

        // Pipe Master
        public DbSet<PipeMaster> PipeMaster { get; set; }
        public DbSet<PipeMasterCOF> PipeMasterCOF { get; set; }
        public DbSet<DocumentMaster> DocumentMaster { get; set; }
        public DbSet<POFSCC> POFSCC { get; set; }
        public DbSet<POFODM> POFODM { get; set; }
        public DbSet<POFIC> POFIC { get; set; }
        public DbSet<POFEC> POFEC { get; set; }        
        public DbSet<POFMaster> POFMaster { get; set; }
        public DbSet<TMLHistory> TMLMaster { get; set; }
        public DbSet<TMLHistory> TMLHistory { get; set; }
        public DbSet<POF_IC> POF_IC { get; set; }
        public DbSet<POF_EC> POF_EC { get; set; }
        public DbSet<InspectionStrategy> InspectionStrategy { get; set; }
        public DbSet<DMMaster> DMMaster { get; set; }


        // Pipe Report
        public DbSet<PipeReport> PipeReport { get; set; }
        public DbSet<TML> TML { get; set; }        
        public DbSet<InspectionObservation> InspectionObservation { get; set; }        
        public DbSet<InspectionDocument> InspectionDocument { get; set; }
        public DbSet<InspectionRecommendation> InspectionRecommendation { get; set; }
        public DbSet<InspectionConfidence> InspectionConfidence { get; set; }
        public DbSet<InspectionDistribution> InspectionDistribution { get; set; }
        public DbSet<InspectionProgram> InspectionProgram { get; set; }

        // Corrosion Study
        public DbSet<PipeCluster> PipeCluster { get; set; }
        public DbSet<CorrosionStudy> CorrosionStudy { get; set; }
        public DbSet<DMGuide> DMGuide { get; set; }
        public DbSet<PipeClusterPOF> PipeClusterPOF { get; set; }
        public DbSet<IOW> IOW { get; set; }
        public DbSet<COFMaster> COFMaster { get; set; }

        public DbSet<RiskAnalysis> RiskAnalysis { get; set; }
        public DbSet<RiskPriority> RiskPriority { get; set; }

        // COF

        public DbSet<COFFlammable> COFFlammable { get; set; }
        public DbSet<FlammableConstant> FlammableConstant { get; set; }
        public DbSet<FluidIC> FluidIC { get; set; }
        public DbSet<RepresentativeFluid> RepresentativeFluid { get; set; }
        public DbSet<FluidProperty> FluidProperty { get; set; }
        public DbSet<LDMax> LDMax { get; set; }
        public DbSet<FluidModel> FluidModel { get; set; }
        public DbSet<DetectionIsolation> DetectionIsolation { get; set; }
        public DbSet<MitigationSystem> MitigationSystem { get; set; }
        public DbSet<GFF> GFF { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Employee>()
                .Property(e => e.Gender)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeType)
                .HasConversion<string>();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Designation)
                .HasConversion<string>();

            modelBuilder.Entity<DocumentMaster>()
               .Property(e => e.DocumentType)
               .HasConversion<string>();

            modelBuilder.Entity<Role>()
        .HasData(
            new Role { ID = 1, Code = "ADM", Name = "Admin", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
            new Role
            {
                ID = 2,
                Code = "INS",
                Name = "Inspector",
                Active = true,
                CreatedBy = "SYSADMIN",
                CreatedDate = DateTime.Now
            },
            new Role
            {
                ID = 3,
                Code = "INE",
                Name = "Integrity Engineer",
                Active = true,
                CreatedBy = "SYSADMIN",
                CreatedDate = DateTime.Now
            },
            new Role
            {
                ID = 4,
                Code = "HOI",
                Name = "Head of Integrity",
                Active = true,
                CreatedBy = "SYSADMIN",
                CreatedDate = DateTime.Now
            },
            new Role
            {
                ID = 5,
                Code = "MNT",
                Name = "Maintenance",
                Active = true,
                CreatedBy = "SYSADMIN",
                CreatedDate = DateTime.Now
            },
            new Role
            {
                ID = 6,
                Code = "OPR",
                Name = "Operation",
                Active = true,
                CreatedBy = "SYSADMIN",
                CreatedDate = DateTime.Now
            },
             new Role
             {
                 ID = 7,
                 Code = "GEN",
                 Name = "General",
                 Active = true,
                 CreatedBy = "SYSADMIN",
                 CreatedDate = DateTime.Now
             }
        );

            modelBuilder.Entity<Piping.Entities.Action>()
      .HasData(
          new Piping.Entities.Action
          {
              ID = 1,
              Code = "N",
              Name = "Not visible",
              Active = true,
              CreatedBy = "SYSADMIN",
              CreatedDate = DateTime.Now
          },
          new Piping.Entities.Action
          {
              ID = 2,
              Code = "V",
              Name = "View only",
              Active = true,
              CreatedBy = "SYSADMIN",
              CreatedDate = DateTime.Now
          },
          new Piping.Entities.Action
          {
              ID = 3,
              Code = "U",
              Name = "Update",
              Active = true,
              CreatedBy = "SYSADMIN",
              CreatedDate = DateTime.Now
          },
          new Piping.Entities.Action
          {
              ID = 4,
              Code = "A",
              Name = "Add",
              Active = true,
              CreatedBy = "SYSADMIN",
              CreatedDate = DateTime.Now
          },
          new Piping.Entities.Action
          {
              ID = 5,
              Code = "C",
              Name = "Complete access",
              Active = true,
              CreatedBy = "SYSADMIN",
              CreatedDate = DateTime.Now
          },
          new Piping.Entities.Action
          {
              ID = 6,
              Code = "P",
              Name = "Print",
              Active = true,
              CreatedBy = "SYSADMIN",
              CreatedDate = DateTime.Now
          }
      );

            modelBuilder.Entity<Menu>()
     .HasData(
         new Menu { ID = 1, Code = "SE", Name = "Static Equipment", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 2, Code = "PI", Name = "Piping", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 3, Code = "ST", Name = "Storage Tanks", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 4, Code = "PRD", Name = "Pressure Relieving devices", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 5, Code = "HCK", Name = "Home with configurable KIPs", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 6, Code = "RPT", Name = "Reports", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 6, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 7, Code = "AFU", Name = "Action Follow up", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 7, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 8, Code = "IMS", Name = "Integrity management statistics", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 8, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 9, Code = "IOW", Name = "IOWs", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 9, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 10, Code = "PM", Name = "Project Management", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 10, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 11, Code = "WQC", Name = "Welding Quality control", ParentMenuID = null, Path = "", Icon = "fa fa-home", DisplayOrder = 11, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

         new Menu { ID = 12, Code = "PMAST", Name = "Piping Master", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 201, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 13, Code = "PRGEN", Name = "Piping Report-Gen", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 202, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 14, Code = "PRTML", Name = "Piping Report-TML", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 203, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 15, Code = "PRCON", Name = "Piping Report-Confidence", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 204, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 16, Code = "PROBS", Name = "Piping Report-Observations", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 205, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 17, Code = "PRRCM", Name = "Piping Report-Recommendations", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 206, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 18, Code = "PRRST", Name = "Piping Report-Reom-Status", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 207, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 19, Code = "PRRST", Name = "Corrosion Study", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 207, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 20, Code = "PCLST", Name = "Piping Cluster", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 208, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 21, Code = "POFCL", Name = "POF calculation", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 209, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 22, Code = "COFCL", Name = "COF calculation", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 210, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 23, Code = "INPRG", Name = "Inspection Program", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 211, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 24, Code = "MNGMT", Name = "Management", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 212, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 25, Code = "PTORG", Name = "Plant Organisation", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 213, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 26, Code = "PTDST", Name = "Plant Distribution", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 214, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 27, Code = "SBCFG", Name = "Dashboard configuration", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 215, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new Menu { ID = 28, Code = "TCREF", Name = "Table cross reference", ParentMenuID = 2, Path = "", Icon = "fa fa-file", DisplayOrder = 216, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
         );

            modelBuilder.Entity<RoleMenuAction>().HasData
            (
                //1. Admin
                new RoleMenuAction { ID = 1, RoleID = 1, MenuID = 1, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 2, RoleID = 1, MenuID = 2, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 3, RoleID = 1, MenuID = 3, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 4, RoleID = 1, MenuID = 4, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 5, RoleID = 1, MenuID = 5, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 6, RoleID = 1, MenuID = 6, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 7, RoleID = 1, MenuID = 7, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 8, RoleID = 1, MenuID = 8, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 9, RoleID = 1, MenuID = 9, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 10, RoleID = 1, MenuID = 10, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 11, RoleID = 1, MenuID = 11, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                new RoleMenuAction { ID = 12, RoleID = 1, MenuID = 12, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 13, RoleID = 1, MenuID = 13, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 14, RoleID = 1, MenuID = 14, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 15, RoleID = 1, MenuID = 15, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 16, RoleID = 1, MenuID = 16, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 17, RoleID = 1, MenuID = 17, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 18, RoleID = 1, MenuID = 18, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 19, RoleID = 1, MenuID = 19, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 20, RoleID = 1, MenuID = 20, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 21, RoleID = 1, MenuID = 21, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 22, RoleID = 1, MenuID = 22, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 23, RoleID = 1, MenuID = 23, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 24, RoleID = 1, MenuID = 24, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 25, RoleID = 1, MenuID = 25, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 26, RoleID = 1, MenuID = 26, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 27, RoleID = 1, MenuID = 27, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 28, RoleID = 1, MenuID = 28, ActionID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                //2. Inspector
                new RoleMenuAction { ID = 29, RoleID = 2, MenuID = 1, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 30, RoleID = 2, MenuID = 2, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 31, RoleID = 2, MenuID = 3, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 32, RoleID = 2, MenuID = 4, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 33, RoleID = 2, MenuID = 5, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 34, RoleID = 2, MenuID = 6, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 35, RoleID = 2, MenuID = 7, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 36, RoleID = 2, MenuID = 8, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 37, RoleID = 2, MenuID = 9, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 38, RoleID = 2, MenuID = 10, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 39, RoleID = 2, MenuID = 11, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                new RoleMenuAction { ID = 40, RoleID = 2, MenuID = 12, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 41, RoleID = 2, MenuID = 13, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 42, RoleID = 2, MenuID = 14, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 43, RoleID = 2, MenuID = 15, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 44, RoleID = 2, MenuID = 16, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 45, RoleID = 2, MenuID = 17, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 46, RoleID = 2, MenuID = 18, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 47, RoleID = 2, MenuID = 19, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 48, RoleID = 2, MenuID = 20, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 49, RoleID = 2, MenuID = 21, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 50, RoleID = 2, MenuID = 22, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 51, RoleID = 2, MenuID = 23, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 52, RoleID = 2, MenuID = 24, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 53, RoleID = 2, MenuID = 25, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 54, RoleID = 2, MenuID = 26, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 55, RoleID = 2, MenuID = 27, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 56, RoleID = 2, MenuID = 28, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                //3. Integrity Engineer 

                new RoleMenuAction { ID = 57, RoleID = 3, MenuID = 1, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 58, RoleID = 3, MenuID = 2, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 59, RoleID = 3, MenuID = 3, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 60, RoleID = 3, MenuID = 4, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 61, RoleID = 3, MenuID = 5, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 62, RoleID = 3, MenuID = 6, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 63, RoleID = 3, MenuID = 7, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 64, RoleID = 3, MenuID = 8, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 65, RoleID = 3, MenuID = 9, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 66, RoleID = 3, MenuID = 10, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 67, RoleID = 3, MenuID = 11, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                new RoleMenuAction { ID = 68, RoleID = 3, MenuID = 14, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 69, RoleID = 3, MenuID = 15, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 70, RoleID = 3, MenuID = 16, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 71, RoleID = 3, MenuID = 17, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 72, RoleID = 3, MenuID = 18, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 73, RoleID = 3, MenuID = 19, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 74, RoleID = 3, MenuID = 20, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 75, RoleID = 3, MenuID = 21, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 76, RoleID = 3, MenuID = 22, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 77, RoleID = 3, MenuID = 23, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 78, RoleID = 3, MenuID = 24, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 79, RoleID = 3, MenuID = 25, ActionID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 80, RoleID = 3, MenuID = 26, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 81, RoleID = 3, MenuID = 27, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 82, RoleID = 3, MenuID = 25, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 83, RoleID = 3, MenuID = 26, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 84, RoleID = 3, MenuID = 27, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 85, RoleID = 3, MenuID = 14, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 86, RoleID = 3, MenuID = 15, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 87, RoleID = 3, MenuID = 16, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 88, RoleID = 3, MenuID = 18, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 89, RoleID = 3, MenuID = 19, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 90, RoleID = 3, MenuID = 21, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 91, RoleID = 3, MenuID = 22, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 92, RoleID = 3, MenuID = 23, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 93, RoleID = 3, MenuID = 24, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 94, RoleID = 3, MenuID = 25, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                //4. Head of Integrity
                new RoleMenuAction { ID = 95, RoleID = 4, MenuID = 1, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 96, RoleID = 4, MenuID = 2, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 97, RoleID = 4, MenuID = 3, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 98, RoleID = 4, MenuID = 4, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 99, RoleID = 4, MenuID = 5, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 100, RoleID = 4, MenuID = 6, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 101, RoleID = 4, MenuID = 7, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 102, RoleID = 4, MenuID = 8, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 103, RoleID = 4, MenuID = 9, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 104, RoleID = 4, MenuID = 10, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 105, RoleID = 4, MenuID = 11, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                new RoleMenuAction { ID = 106, RoleID = 4, MenuID = 12, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 107, RoleID = 4, MenuID = 13, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 108, RoleID = 4, MenuID = 14, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 109, RoleID = 4, MenuID = 15, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 110, RoleID = 4, MenuID = 16, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 111, RoleID = 4, MenuID = 17, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 112, RoleID = 4, MenuID = 18, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 113, RoleID = 4, MenuID = 19, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 114, RoleID = 4, MenuID = 20, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 115, RoleID = 4, MenuID = 21, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 116, RoleID = 4, MenuID = 22, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 117, RoleID = 4, MenuID = 23, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 118, RoleID = 4, MenuID = 24, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 119, RoleID = 4, MenuID = 25, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 120, RoleID = 4, MenuID = 26, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 121, RoleID = 4, MenuID = 27, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 122, RoleID = 4, MenuID = 28, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                //5. Maintenance
                new RoleMenuAction { ID = 123, RoleID = 5, MenuID = 1, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 124, RoleID = 5, MenuID = 2, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 125, RoleID = 5, MenuID = 3, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 126, RoleID = 5, MenuID = 4, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 127, RoleID = 5, MenuID = 5, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 128, RoleID = 5, MenuID = 6, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 129, RoleID = 5, MenuID = 7, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 130, RoleID = 5, MenuID = 8, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 131, RoleID = 5, MenuID = 9, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 132, RoleID = 5, MenuID = 10, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 133, RoleID = 5, MenuID = 11, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                new RoleMenuAction { ID = 134, RoleID = 5, MenuID = 12, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 135, RoleID = 5, MenuID = 13, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 136, RoleID = 5, MenuID = 14, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 137, RoleID = 5, MenuID = 15, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 138, RoleID = 5, MenuID = 16, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 139, RoleID = 5, MenuID = 17, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 140, RoleID = 5, MenuID = 18, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 141, RoleID = 5, MenuID = 19, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 142, RoleID = 5, MenuID = 20, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 143, RoleID = 5, MenuID = 21, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 144, RoleID = 5, MenuID = 22, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 145, RoleID = 5, MenuID = 23, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 146, RoleID = 5, MenuID = 24, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 147, RoleID = 5, MenuID = 25, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 148, RoleID = 5, MenuID = 26, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 149, RoleID = 5, MenuID = 27, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 150, RoleID = 5, MenuID = 28, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 151, RoleID = 5, MenuID = 18, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                //6. Operation
                new RoleMenuAction { ID = 152, RoleID = 6, MenuID = 1, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 153, RoleID = 6, MenuID = 2, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 154, RoleID = 6, MenuID = 3, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 155, RoleID = 6, MenuID = 4, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 156, RoleID = 6, MenuID = 5, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 157, RoleID = 6, MenuID = 6, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 158, RoleID = 6, MenuID = 7, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 159, RoleID = 6, MenuID = 8, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 160, RoleID = 6, MenuID = 9, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 161, RoleID = 6, MenuID = 10, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 162, RoleID = 6, MenuID = 11, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                new RoleMenuAction { ID = 163, RoleID = 6, MenuID = 12, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 164, RoleID = 6, MenuID = 13, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 165, RoleID = 6, MenuID = 14, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 166, RoleID = 6, MenuID = 15, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 167, RoleID = 6, MenuID = 16, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 168, RoleID = 6, MenuID = 17, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 169, RoleID = 6, MenuID = 18, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 170, RoleID = 6, MenuID = 19, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 171, RoleID = 6, MenuID = 20, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 172, RoleID = 6, MenuID = 21, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 173, RoleID = 6, MenuID = 22, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 174, RoleID = 6, MenuID = 23, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 175, RoleID = 6, MenuID = 24, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 176, RoleID = 6, MenuID = 25, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 177, RoleID = 6, MenuID = 26, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 178, RoleID = 6, MenuID = 27, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 180, RoleID = 6, MenuID = 28, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 181, RoleID = 6, MenuID = 18, ActionID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                //7. General
                new RoleMenuAction { ID = 182, RoleID = 7, MenuID = 1, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 183, RoleID = 7, MenuID = 2, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 184, RoleID = 7, MenuID = 3, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 185, RoleID = 7, MenuID = 4, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 186, RoleID = 7, MenuID = 5, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 187, RoleID = 7, MenuID = 6, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 188, RoleID = 7, MenuID = 7, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 189, RoleID = 7, MenuID = 8, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 190, RoleID = 7, MenuID = 9, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 191, RoleID = 7, MenuID = 10, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 192, RoleID = 7, MenuID = 11, ActionID = null, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

                new RoleMenuAction { ID = 193, RoleID = 7, MenuID = 12, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 194, RoleID = 7, MenuID = 13, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 195, RoleID = 7, MenuID = 14, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 196, RoleID = 7, MenuID = 15, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 197, RoleID = 7, MenuID = 16, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 198, RoleID = 7, MenuID = 17, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 199, RoleID = 7, MenuID = 18, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 200, RoleID = 7, MenuID = 19, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 201, RoleID = 7, MenuID = 20, ActionID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 202, RoleID = 7, MenuID = 21, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 203, RoleID = 7, MenuID = 22, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 204, RoleID = 7, MenuID = 23, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 205, RoleID = 7, MenuID = 24, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 206, RoleID = 7, MenuID = 25, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 207, RoleID = 7, MenuID = 26, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 208, RoleID = 7, MenuID = 27, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                new RoleMenuAction { ID = 209, RoleID = 7, MenuID = 28, ActionID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<QuickLink>()
     .HasData(
         new QuickLink { ID = 1, Name = "Piping Reports", Icon = "assets/icons/Piping_QuickLink_PipingReports_Icon_Gray.svg", SourceTable = "PipeMaster", SourceTableColumn = "EquipmentNo", DestinationTable = "PipeReport", DestinationTableColumn = "EquipmentNo", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new QuickLink { ID = 2, Name = "COF Master Records", Icon = "assets/icons/Piping_QuickLink_COFMaster_Icon_Gray.svg", SourceTable = "PipeMaster", SourceTableColumn = "EquipmentNo", DestinationTable = "COFMaster", DestinationTableColumn = "EquipmentNo", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new QuickLink { ID = 3, Name = "POF Master Records", Icon = "assets/icons/Piping_QuickLink_POFMaster_Icon_Gray.svg", SourceTable = "PipeMaster", SourceTableColumn = "EquipmentNo", DestinationTable = "POFMaster", DestinationTableColumn = "EquipmentNo", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new QuickLink { ID = 4, Name = "Corrosion Study", Icon = "assets/icons/Piping_QuickLink_CorrosionStudy_Icon_Gray.svg", SourceTable = "CorrosionStudy", SourceTableColumn = "EquipmentNo", DestinationTable = "PipeReport", DestinationTableColumn = "EquipmentNo", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new QuickLink { ID = 5, Name = "Lookup Tables", Icon = "assets/icons/Piping_QuickLink_LookupTables_Icon_Gray.svg", SourceTable = "LookupTables", SourceTableColumn = "EquipmentNo", DestinationTable = "COFMaster", DestinationTableColumn = "EquipmentNo", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new QuickLink { ID = 6, Name = "Risk Analysis", Icon = "assets/icons/Piping_QuickLink_RiskAnalysis_Icon_Gray.svg", SourceTable = "RiskAnalysis", SourceTableColumn = "EquipmentNo", DestinationTable = "POFMaster", DestinationTableColumn = "EquipmentNo", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new QuickLink { ID = 7, Name = "Inspection Program", Icon = "assets/icons/Piping_QuickLink_InspectionProgram_Icon_Gray.svg", SourceTable = "InspectionProgram", SourceTableColumn = "EquipmentNo", DestinationTable = "POFMaster", DestinationTableColumn = "EquipmentNo", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
         );

            modelBuilder.Entity<PlantMaster>()
   .HasData(
         new PlantMaster { ID = 1, Code = "Ammonia", Name = "Ammonia", Icon = "assets/Ammonia.svg", ParentPlantID = null, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 2, Code = "Urea", Name = "Urea", Icon = "assets/Urea.svg", ParentPlantID = null, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 3, Code = "Melamine", Name = "Melamine", Icon = "assets/Melamine.svg", ParentPlantID = null, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 4, Code = "Compressor", Name = "Compressor House", Icon = "assets/Compressor.svg", ParentPlantID = null, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 5, Code = "Utilits", Name = "Utilits", Icon = "assets/Utillits.svg", ParentPlantID = null, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 6, Code = "Others", Name = "Others", Icon = "assets/Others.svg", ParentPlantID = null, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },


         new PlantMaster { ID = 7, Code = "A1", Name = "Ammonia 01", Icon = null, ParentPlantID = 1, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 8, Code = "A2", Name = "Ammonia 02", Icon = null, ParentPlantID = 1, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 9, Code = "A3", Name = "Ammonia 03", Icon = null, ParentPlantID = 1, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 10, Code = "A4", Name = "Ammonia 04", Icon = null, ParentPlantID = 1, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 11, Code = "A5", Name = "Ammonia 05", Icon = null, ParentPlantID = 1, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 12, Code = "A6", Name = "Ammonia 06", Icon = null, ParentPlantID = 1, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 13, Code = "QPNT", Name = "QPNT", Icon = null, ParentPlantID = 1, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

         new PlantMaster { ID = 14, Code = "CH1", Name = "Compressor House 01", Icon = null, ParentPlantID = 4, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 15, Code = "CH2", Name = "Compressor House 02", Icon = null, ParentPlantID = 4, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 16, Code = "CH3", Name = "Compressor House 03", Icon = null, ParentPlantID = 4, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 17, Code = "CH4", Name = "Compressor House 04", Icon = null, ParentPlantID = 4, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 18, Code = "CH5", Name = "Compressor House 05", Icon = null, ParentPlantID = 4, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new PlantMaster { ID = 19, Code = "CH6", Name = "Compressor House 06", Icon = null, ParentPlantID = 4, CompanyID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
       );

            modelBuilder.Entity<RoleMenuQuickLink>().HasData
         (
             //1. Admin
             new RoleMenuQuickLink { ID = 1, RoleID = 1, MenuID = 12, QuickLinkID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 2, RoleID = 1, MenuID = 12, QuickLinkID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 3, RoleID = 1, MenuID = 12, QuickLinkID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 22, RoleID = 1, MenuID = 12, QuickLinkID = 4, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 23, RoleID = 1, MenuID = 12, QuickLinkID = 5, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 24, RoleID = 1, MenuID = 12, QuickLinkID = 6, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 25, RoleID = 1, MenuID = 12, QuickLinkID = 7, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             //2. Inspector
             new RoleMenuQuickLink { ID = 4, RoleID = 2, MenuID = 12, QuickLinkID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 5, RoleID = 2, MenuID = 12, QuickLinkID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 6, RoleID = 2, MenuID = 12, QuickLinkID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

             //3. Integrity Engineer 
             new RoleMenuQuickLink { ID = 7, RoleID = 3, MenuID = 12, QuickLinkID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 8, RoleID = 3, MenuID = 12, QuickLinkID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 9, RoleID = 3, MenuID = 12, QuickLinkID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

             //4. Head of Integrity
             new RoleMenuQuickLink { ID = 10, RoleID = 4, MenuID = 12, QuickLinkID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 11, RoleID = 4, MenuID = 12, QuickLinkID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 12, RoleID = 4, MenuID = 12, QuickLinkID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

             //5. Maintenance
             new RoleMenuQuickLink { ID = 13, RoleID = 5, MenuID = 12, QuickLinkID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 14, RoleID = 5, MenuID = 12, QuickLinkID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 15, RoleID = 5, MenuID = 12, QuickLinkID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             //6. Operation
             new RoleMenuQuickLink { ID = 16, RoleID = 6, MenuID = 12, QuickLinkID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 17, RoleID = 6, MenuID = 12, QuickLinkID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 18, RoleID = 6, MenuID = 12, QuickLinkID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             //7. General
             new RoleMenuQuickLink { ID = 19, RoleID = 7, MenuID = 12, QuickLinkID = 1, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 20, RoleID = 7, MenuID = 12, QuickLinkID = 2, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
             new RoleMenuQuickLink { ID = 21, RoleID = 7, MenuID = 12, QuickLinkID = 3, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }

             );

            modelBuilder.Entity<Company>()
             .HasData(
                 new Company
                 {
                     ID = 1,
                     Code = "OGC",
                     Name = "OIL & GAS",
                     LogoName = Path.GetFileName(COMPANYLOGO),
                     LogoContent = null,
                     //Utility.ConvertImageToByteArray(COMPANYLOGO),
                     Active = true,
                     Address = "",
                     Website = "",
                     Email = "",
                     Phone = "",
                     CreatedBy = "SYSADMIN",
                     CreatedDate = DateTime.Now
                 }
                 );

            modelBuilder.Entity<Department>()
       .HasData(
           new Department
           {
               ID = 1,
               Code = "QLT",
               Name = "Quality",
               CompanyID = 1,
               Active = true,
               CreatedBy = "SYSADMIN",
               CreatedDate = DateTime.Now
           },
           new Department
           {
               ID = 2,
               Code = "PRD",
               Name = "Production",
               CompanyID = 1,
               Active = true,
               CreatedBy = "SYSADMIN",
               CreatedDate = DateTime.Now
           },
           new Department
           {
               ID = 3,
               Code = "OPR",
               Name = "Operation",
               CompanyID = 1,
               Active = true,
               CreatedBy = "SYSADMIN",
               CreatedDate = DateTime.Now
           },
           new Department
           {
               ID = 4,
               Code = "MNT",
               Name = "Maintenance",
               CompanyID = 1,
               Active = true,
               CreatedBy = "SYSADMIN",
               CreatedDate = DateTime.Now
           }
           );

            modelBuilder.Entity<Employee>()
     .HasData(
         new Employee
         {
             ID = 1,
             FirstName = "GIRIDHARA",
             LastName = "DATLA",
             Gender = GenderEnum.M,
             EmployeeNo = "E0001",
             EmployeeType = EmployeeTypeEnum.Permanent,
             Designation = DesignationEnum.AssetIntegritySpecialist,
             DepartmentID = 1,
             PhotoName = Path.GetFileName(EMPPHOTO),
             PhotoContent = null,
             //Utility.ConvertImageToByteArray(EMPPHOTO),            
             Email = "",
             Phone = "",
             Active = true,
             CreatedBy = "SYSADMIN",
             CreatedDate = DateTime.Now
         }
         );

            modelBuilder.Entity<User>()
    .HasData(
        new User
        {
            ID = 1,
            Username = "E0001",
            Password = @"10000.4UHjc0+Y83AmfG8z6oLsEQ==.pA2/E7H6cE3e6028FpnZXkNjM6d18MOUuXc7tCRUilc=",
            PasswordHash = @"10000.4UHjc0+Y83AmfG8z6oLsEQ==.pA2/E7H6cE3e6028FpnZXkNjM6d18MOUuXc7tCRUilc=",
            Email = "praveen.mondithoka@senecaglobal.com",
            CompanyID = 1,
            IsExpired = false,
            Active = true,
            IsLocked = false,
            CreatedBy = "SYSADMIN",
            CreatedDate = DateTime.Now
        }
        ); ;

            modelBuilder.Entity<UserRole>()
    .HasData(
        new UserRole
        {
            ID = 1,
            UserID = 1,
            RoleID = 1,
            Active = true,
            CreatedBy = "SYSADMIN",
            CreatedDate = DateTime.Now
        }
        );

            modelBuilder.Entity<AlertMaster>()
    .HasData(
        new AlertMaster
        {
            ID = 1,
            Code = "UC",
            Name = "User Creation",
            EmailSubject = "{{CompanyName}} - User Account Created",
            EmailContent = @"<html>  <body>  User <b>[{{Username}}] </b> is created  </body>  </html>",
            EmailFrom = EMAILFROM,
            EmailTo = "{{UserEmail}}",
            EmailCc = "",
            EmailBcc = "",
            Active = true,
            CreatedBy = "SYSADMIN",
            CreatedDate = DateTime.Now
        },
         new AlertMaster
         {
             ID = 2,
             Code = "RP",
             Name = "Reset Password",
             EmailSubject = "{{CompanyName}} - {{Username}} - Reset Password",
             EmailContent = @"<html>  <body>  Password is reset to  <b>{{UserPassword}} </b>  </body>  </html>",
             EmailFrom = EMAILFROM,
             EmailTo = "{{UserEmail}}",
             EmailCc = "",
             EmailBcc = "",
             Active = true,
             CreatedBy = "SYSADMIN",
             CreatedDate = DateTime.Now
         },
          new AlertMaster
          {
              ID = 3,
              Code = "CP",
              Name = "Change Password",
              EmailSubject = "{{CompanyName}} - {{Username}} - Change Password",
              EmailContent = @"<html>  <body>  Password is changed successfully. </body>  </html>",
              EmailFrom = EMAILFROM,
              EmailTo = "{{UserEmail}}",
              EmailCc = "",
              EmailBcc = "",
              Active = true,
              CreatedBy = "SYSADMIN",
              CreatedDate = DateTime.Now
          }
        );

            modelBuilder.Entity<StructuralMinThk>()
    .HasData(
new StructuralMinThk { ID = 1, ComponentType = "1/4\" Pipe", OutsideDiameterInches = 0.302M, OutsideDiameterMM = 7.6708M, StructureWallThicknessMM = 1.5748M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 2, ComponentType = "1/2\" Pipe", OutsideDiameterInches = 0.84M, OutsideDiameterMM = 21.336M, StructureWallThicknessMM = 1.5748M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 3, ComponentType = "3/4\" Pipe", OutsideDiameterInches = 1.05M, OutsideDiameterMM = 26.67M, StructureWallThicknessMM = 1.5748M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 4, ComponentType = "1\" Pipe", OutsideDiameterInches = 1.315M, OutsideDiameterMM = 33.401M, StructureWallThicknessMM = 1.5748M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 5, ComponentType = "1.25\" Pipe", OutsideDiameterInches = 1.315M, OutsideDiameterMM = 33.401M, StructureWallThicknessMM = 1.5748M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 6, ComponentType = "1.5\" Pipe", OutsideDiameterInches = 1.9M, OutsideDiameterMM = 48.26M, StructureWallThicknessMM = 1.5748M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 7, ComponentType = "2\" Pipe", OutsideDiameterInches = 2.375M, OutsideDiameterMM = 60.325M, StructureWallThicknessMM = 2.3876M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 8, ComponentType = "2.5\" Pipe", OutsideDiameterInches = 2.875M, OutsideDiameterMM = 73.025M, StructureWallThicknessMM = 2.3876M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 9, ComponentType = "3\" Pipe", OutsideDiameterInches = 3.5M, OutsideDiameterMM = 88.9M, StructureWallThicknessMM = 2.3876M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 10, ComponentType = "4\" Pipe", OutsideDiameterInches = 4.5M, OutsideDiameterMM = 114.3M, StructureWallThicknessMM = 2.3876M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 11, ComponentType = "5\" Pipe", OutsideDiameterInches = 5.563M, OutsideDiameterMM = 141.3002M, StructureWallThicknessMM = 2.3876M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 12, ComponentType = "6\" Pipe", OutsideDiameterInches = 6.625M, OutsideDiameterMM = 168.275M, StructureWallThicknessMM = 2.3876M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 13, ComponentType = "8\" Pipe", OutsideDiameterInches = 8.625M, OutsideDiameterMM = 219.075M, StructureWallThicknessMM = 2.3876M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 14, ComponentType = "10\" Pipe", OutsideDiameterInches = 10.75M, OutsideDiameterMM = 273.05M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 15, ComponentType = "2050NB", OutsideDiameterInches = 10.75M, OutsideDiameterMM = 273.05M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 16, ComponentType = "12\" Pipe", OutsideDiameterInches = 12.75M, OutsideDiameterMM = 323.85M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 17, ComponentType = "14\" Pipe", OutsideDiameterInches = 14M, OutsideDiameterMM = 355.6M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 18, ComponentType = "16\" Pipe", OutsideDiameterInches = 16M, OutsideDiameterMM = 406.4M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 19, ComponentType = "18\" Pipe", OutsideDiameterInches = 18M, OutsideDiameterMM = 457.2M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 20, ComponentType = "20\" Pipe", OutsideDiameterInches = 20M, OutsideDiameterMM = 508M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 21, ComponentType = "24\" Pipe", OutsideDiameterInches = 24M, OutsideDiameterMM = 609.6M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 22, ComponentType = "26\" Pipe", OutsideDiameterInches = 25.25M, OutsideDiameterMM = 641.35M, StructureWallThicknessMM = 4.064M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 23, ComponentType = "28\" Pipe", OutsideDiameterInches = 28M, OutsideDiameterMM = 711.2M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 24, ComponentType = "28\" Pipe", OutsideDiameterInches = 28M, OutsideDiameterMM = 711.2M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 25, ComponentType = "30\" Pipe", OutsideDiameterInches = 30M, OutsideDiameterMM = 762M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 26, ComponentType = "32\" Pipe", OutsideDiameterInches = 32M, OutsideDiameterMM = 812.8M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 27, ComponentType = "36\" Pipe", OutsideDiameterInches = 36M, OutsideDiameterMM = 914.4M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 28, ComponentType = "38\" Pipe", OutsideDiameterInches = 37.25M, OutsideDiameterMM = 946.15M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 29, ComponentType = "40\" Pipe", OutsideDiameterInches = 40M, OutsideDiameterMM = 1016M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 30, ComponentType = "42\" Pipe", OutsideDiameterInches = 42M, OutsideDiameterMM = 1066.8M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 31, ComponentType = "48\" Pipe", OutsideDiameterInches = 48M, OutsideDiameterMM = 1219.2M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 32, ComponentType = "54\" Pipe", OutsideDiameterInches = 54M, OutsideDiameterMM = 1371.6M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 33, ComponentType = "56\" Pipe", OutsideDiameterInches = 55M, OutsideDiameterMM = 1397M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 34, ComponentType = "60\" Pipe", OutsideDiameterInches = 60M, OutsideDiameterMM = 1524M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new StructuralMinThk { ID = 35, ComponentType = "> 60\" Pipe", OutsideDiameterInches = 102M, OutsideDiameterMM = 2590.8M, StructureWallThicknessMM = 3.175M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }

        );

            modelBuilder.Entity<InsulationType>()
.HasData(
new InsulationType { ID = 1, Name = "Unknown/Unspecified", AdjustmentFactor = 1.25M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new InsulationType { ID = 2, Name = "Foamglass", AdjustmentFactor = 0.75M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new InsulationType { ID = 3, Name = "Pearlite", AdjustmentFactor = 1M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new InsulationType { ID = 4, Name = "Fiberglass", AdjustmentFactor = 1.25M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new InsulationType { ID = 5, Name = "Mineral Wool", AdjustmentFactor = 1.25M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new InsulationType { ID = 6, Name = "Calcium Silicate", AdjustmentFactor = 1.25M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new InsulationType { ID = 7, Name = "Asbestos", AdjustmentFactor = 1.25M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
);
            modelBuilder.Entity<MaterialCodes>()
           .HasData(
           new MaterialCodes { ID = 1, Name = "CS", Code = "CS", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 2, Name = "LAS-P1", Code = "LAS-P1", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 3, Name = "LAS-P11", Code = "LAS-P11", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 4, Name = "LAS-P12", Code = "LAS-P12", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 5, Name = "LAS-P22", Code = "LAS-P22", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 6, Name = "LAS-P5", Code = "LAS-P5", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 7, Name = "LAS-P91", Code = "LAS-P91", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 8, Name = "SS-300", Code = "SS-300", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 9, Name = "SS-400", Code = "SS-400", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 10, Name = "SS-Aus", Code = "SS-Aus", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 11, Name = "SS-SDup", Code = "SS-SDup", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 12, Name = "SS-Dup", Code = "SS-Dup", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 13, Name = "NBA-800", Code = "NBA-800", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new MaterialCodes { ID = 14, Name = "NBA-600", Code = "NBA-600", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
           );

            modelBuilder.Entity<ExternalCorrosionRate>()
          .HasData(
          new ExternalCorrosionRate { ID = 1, OperatingTemperatureInDegC = -12M, Driver = "M", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 2, OperatingTemperatureInDegC = -12M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 3, OperatingTemperatureInDegC = -12M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 4, OperatingTemperatureInDegC = -12M, Driver = "S", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

          new ExternalCorrosionRate { ID = 5, OperatingTemperatureInDegC = -8M, Driver = "M", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 6, OperatingTemperatureInDegC = -8M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 7, OperatingTemperatureInDegC = -8M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 8, OperatingTemperatureInDegC = -8M, Driver = "S", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

          new ExternalCorrosionRate { ID = 9, OperatingTemperatureInDegC = 6M, Driver = "M", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 10, OperatingTemperatureInDegC = 6M, Driver = "T", CorrosionRate = 0.076M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 11, OperatingTemperatureInDegC = 6M, Driver = "D", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 12, OperatingTemperatureInDegC = 6M, Driver = "S", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

          new ExternalCorrosionRate { ID = 13, OperatingTemperatureInDegC = 32M, Driver = "M", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 14, OperatingTemperatureInDegC = 32M, Driver = "T", CorrosionRate = 0.076M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 15, OperatingTemperatureInDegC = 32M, Driver = "D", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 16, OperatingTemperatureInDegC = 32M, Driver = "S", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

          new ExternalCorrosionRate { ID = 17, OperatingTemperatureInDegC = 71M, Driver = "M", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 18, OperatingTemperatureInDegC = 71M, Driver = "T", CorrosionRate = 0.051M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 19, OperatingTemperatureInDegC = 71M, Driver = "D", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 20, OperatingTemperatureInDegC = 71M, Driver = "S", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

          new ExternalCorrosionRate { ID = 21, OperatingTemperatureInDegC = 107M, Driver = "M", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 22, OperatingTemperatureInDegC = 107M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 23, OperatingTemperatureInDegC = 107M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 24, OperatingTemperatureInDegC = 107M, Driver = "S", CorrosionRate = 0.051M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

          new ExternalCorrosionRate { ID = 25, OperatingTemperatureInDegC = 121M, Driver = "M", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 26, OperatingTemperatureInDegC = 121M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 27, OperatingTemperatureInDegC = 121M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
          new ExternalCorrosionRate { ID = 28, OperatingTemperatureInDegC = 121M, Driver = "S", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
          );

            modelBuilder.Entity<CUICorrosionRate>()
      .HasData(
      new CUICorrosionRate { ID = 1, OperatingTemperatureInDegC = -12M, Driver = "M", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 2, OperatingTemperatureInDegC = -12M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 3, OperatingTemperatureInDegC = -12M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 4, OperatingTemperatureInDegC = -12M, Driver = "S", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 5, OperatingTemperatureInDegC = -8M, Driver = "M", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 6, OperatingTemperatureInDegC = -8M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 7, OperatingTemperatureInDegC = -8M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 8, OperatingTemperatureInDegC = -8M, Driver = "S", CorrosionRate = 0.076M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 9, OperatingTemperatureInDegC = 6M, Driver = "M", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 10, OperatingTemperatureInDegC = 6M, Driver = "T", CorrosionRate = 0.076M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 11, OperatingTemperatureInDegC = 6M, Driver = "D", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 12, OperatingTemperatureInDegC = 6M, Driver = "S", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 13, OperatingTemperatureInDegC = 32M, Driver = "M", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 14, OperatingTemperatureInDegC = 32M, Driver = "T", CorrosionRate = 0.076M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 15, OperatingTemperatureInDegC = 32M, Driver = "D", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 16, OperatingTemperatureInDegC = 32M, Driver = "S", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 17, OperatingTemperatureInDegC = 71M, Driver = "M", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 18, OperatingTemperatureInDegC = 71M, Driver = "T", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 19, OperatingTemperatureInDegC = 71M, Driver = "D", CorrosionRate = 0.051M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 20, OperatingTemperatureInDegC = 71M, Driver = "S", CorrosionRate = 0.508M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 21, OperatingTemperatureInDegC = 107M, Driver = "M", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 22, OperatingTemperatureInDegC = 107M, Driver = "T", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 23, OperatingTemperatureInDegC = 107M, Driver = "D", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 24, OperatingTemperatureInDegC = 107M, Driver = "S", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 25, OperatingTemperatureInDegC = 135M, Driver = "M", CorrosionRate = 0.051M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 26, OperatingTemperatureInDegC = 135M, Driver = "T", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 27, OperatingTemperatureInDegC = 135M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 28, OperatingTemperatureInDegC = 135M, Driver = "S", CorrosionRate = 0.254M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 29, OperatingTemperatureInDegC = 162M, Driver = "M", CorrosionRate = 0.025M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 30, OperatingTemperatureInDegC = 162M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 31, OperatingTemperatureInDegC = 162M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 32, OperatingTemperatureInDegC = 162M, Driver = "S", CorrosionRate = 0.127M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

      new CUICorrosionRate { ID = 33, OperatingTemperatureInDegC = 176M, Driver = "M", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 34, OperatingTemperatureInDegC = 176M, Driver = "T", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 35, OperatingTemperatureInDegC = 176M, Driver = "D", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
      new CUICorrosionRate { ID = 36, OperatingTemperatureInDegC = 176M, Driver = "S", CorrosionRate = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
      );

            modelBuilder.Entity<ExternalSuceptability>()
.HasData(
new ExternalSuceptability { ID = 1, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "M", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 2, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "T", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 3, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "D", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 4, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "S", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

new ExternalSuceptability { ID = 5, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "M", Suceptability = "L", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 6, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "T", Suceptability = "M", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 7, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "D", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 8, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "S", Suceptability = "H", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

new ExternalSuceptability { ID = 9, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "M", Suceptability = "L", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 10, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "T", Suceptability = "L", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 11, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "D", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 12, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "S", Suceptability = "M", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

new ExternalSuceptability { ID = 13, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "M", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 14, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "T", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 15, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "D", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSuceptability { ID = 16, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "S", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
);

            modelBuilder.Entity<CUISuceptability>()
.HasData(
new CUISuceptability { ID = 1, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "M", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 2, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "T", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 3, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "D", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 4, OperatingTemperatureInDegC_From = -99999M, OperatingTemperatureInDegC_To = 49M, Driver = "S", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

new CUISuceptability { ID = 5, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "M", Suceptability = "M", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 6, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "T", Suceptability = "H", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 7, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "D", Suceptability = "L", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 8, OperatingTemperatureInDegC_From = 49M, OperatingTemperatureInDegC_To = 93M, Driver = "S", Suceptability = "H", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

new CUISuceptability { ID = 9, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "M", Suceptability = "L", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 10, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "T", Suceptability = "M", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 11, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "D", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 12, OperatingTemperatureInDegC_From = 93M, OperatingTemperatureInDegC_To = 149M, Driver = "S", Suceptability = "H", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

new CUISuceptability { ID = 13, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "M", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 14, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "T", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 15, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "D", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new CUISuceptability { ID = 16, OperatingTemperatureInDegC_From = 149M, OperatingTemperatureInDegC_To = 99999M, Driver = "S", Suceptability = "N", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
);

            modelBuilder.Entity<ExternalSeverityIndex>()
.HasData(
new ExternalSeverityIndex { ID = 1, Suceptability = "H", SeverityIndex = 50M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSeverityIndex { ID = 2, Suceptability = "M", SeverityIndex = 10M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSeverityIndex { ID = 3, Suceptability = "L", SeverityIndex = 1M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new ExternalSeverityIndex { ID = 4, Suceptability = "N", SeverityIndex = 0M, Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
);

            modelBuilder.Entity<ObservationMaster>()
            .HasData(
            new ObservationMaster { ID = 1, Description = "Inspection done as per the program and no major abnormalities found.", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
            new ObservationMaster { ID = 2, Description = "Visual inspection done and paint damage seen at marked location in the attached drawing.", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
            new ObservationMaster { ID = 3, Description = "Visual inspection done and insulation damage seen at marked location in the attached drawing.", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
            new ObservationMaster { ID = 4, Description = "Support system found defective.", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
            new ObservationMaster { ID = 5, Description = "Line found vibration.", Active = true, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<DMGuide>()
           .HasData(
           new DMGuide { ID = 1, DMCode = "IC", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.02", Source = "Ammonia", FluidName = "Natural Gas", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 2, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Mixed Feed", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 3, DMCode = "Erosion", DMType = "IC", DMDescription = "Erosion", DMRate = "0.1", Source = "Ammonia", FluidName = "Mixed Feed", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "At Steam Injection area", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 4, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Primary Reformed Gas", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 5, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Process Air", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 6, DMCode = "Under deposit corrosion", DMType = "IC", DMDescription = "Under deposit corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "Process Air", MaterialCode = "CS", SubFluid = "", SpecialCondition = "Convection coil combustion air pre heater cold side", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 7, DMCode = "Condensation Internal corrosion", DMType = "IC", DMDescription = "Condensation Internal corrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "Process Air", MaterialCode = "CS", SubFluid = "", SpecialCondition = "Process air interstage coolers and lines", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 8, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Secondary Reforming", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 9, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "CO-CONVERSION", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 10, DMCode = "Condensation Internal corrosion", DMType = "IC", DMDescription = "Condensation Internal corrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "CO-CONVERSION", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "If condensation possible", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 11, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE Corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "Benfield Solution", MaterialCode = "CS", SubFluid = "CO2-Rich", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 12, DMCode = "Erosion", DMType = "IC", DMDescription = "AMINE Corrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "Benfield Solution", MaterialCode = "CS", SubFluid = "CO2-Rich", SpecialCondition = "High erosion possible on local areas if vel >2 m/s", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 13, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE Corrosion", DMRate = "0.03", Source = "Ammonia", FluidName = "Benfield Solution", MaterialCode = "CS", SubFluid = "CO2-LEAN", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 14, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE Corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "Benfield Solution", MaterialCode = "CS", SubFluid = "CO2-Semi Lean", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 15, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "CO2 Corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "CO2", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 16, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Methanated Gas", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 17, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Synthesis Gas Compressor", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 18, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Synthesis Loop", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 19, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0", Source = "Ammonia", FluidName = "Ammonia Processing", MaterialCode = "CS/LTCS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 20, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0", Source = "Ammonia", FluidName = "Ammonia Processing", MaterialCode = "CS/LTCS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 21, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0", Source = "Ammonia", FluidName = "Purge Gas", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 22, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.02", Source = "Ammonia", FluidName = "Amm Recovery", MaterialCode = "CS", SubFluid = "", SpecialCondition = "Alchaline corrosion due to higher Ammonia", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 23, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "BF Water", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 24, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Condensate", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 25, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "HP Steam", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 26, DMCode = "Under deposit corrosion", DMType = "IC", DMDescription = "Under deposit corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "HP Steam", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "Tubes in vertical exchangers like waste heat boiler", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 27, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "LP/MP Steam", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 28, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "DM Water", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 29, DMCode = "Micro biological corrosion", DMType = "IC", DMDescription = "Micro biological corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "DM Water", MaterialCode = "CS", SubFluid = "", SpecialCondition = "generally happened with few years of commissioning.", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 30, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Process Condensate", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 31, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.5", Source = "Ammonia", FluidName = "Sea Water", MaterialCode = "CS", SubFluid = "", SpecialCondition = "Depends on coating/lining condition", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 32, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "General Internal corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "Closed Cooling Water", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 33, DMCode = "Micro biological corrosion", DMType = "IC", DMDescription = "Micro biological corrosion", DMRate = "0.2", Source = "Ammonia", FluidName = "Closed Cooling Water", MaterialCode = "CS", SubFluid = "", SpecialCondition = "In case of improper treatment", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 34, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "Benfield Solution", MaterialCode = "CS", SubFluid = "H2S-RICH", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 35, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "Benfield Solution", MaterialCode = "CS", SubFluid = "H2S-Semi lean", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 36, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "Benfield Solution", MaterialCode = "CS", SubFluid = "H2S-Lean", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 37, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "Wet CO2 corrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "H2S + CO2", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 38, DMCode = "Wet CO2 corrosion", DMType = "IC", DMDescription = "Wet CO2 corrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "H2S + CO2", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 39, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "Atmospheric Corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "Atmosphere", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 40, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "MDEA", MaterialCode = "CS", SubFluid = "H2S-RICH", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 41, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "MDEA", MaterialCode = "CS", SubFluid = "H2S-Semi lean", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 42, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.02", Source = "Ammonia", FluidName = "MDEA", MaterialCode = "CS", SubFluid = "H2S-Lean", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 43, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "Flue Gas Corrosion", DMRate = "0.01", Source = "Ammonia", FluidName = "Convection Coils- External", MaterialCode = "All", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 44, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "CO2 Corrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "CO2-RICH AMINE-aMDEA", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 45, DMCode = "Erosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.1", Source = "Ammonia", FluidName = "MDEA", MaterialCode = "CS", SubFluid = "CO2-Rich", SpecialCondition = "High erosion possible on local areas if vel >2 m/s", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 46, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.03", Source = "Ammonia", FluidName = "MDEA", MaterialCode = "CS", SubFluid = "CO2-LEAN", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 47, DMCode = "General Internal corrosion", DMType = "IC", DMDescription = "AMINE COrrosion", DMRate = "0.05", Source = "Ammonia", FluidName = "MDEA", MaterialCode = "CS", SubFluid = "CO2-Semi Lean", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 48, DMCode = "Wet H2S Cracking", DMType = "SCC", DMDescription = "Wet H2S Cracking", DMRate = "LOW", Source = "Ammonia", FluidName = "Natural Gas", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "See the charts", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 49, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "CO2-RICH AMINE-BS", MaterialCode = "CS", SubFluid = "CO2-Rich", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 50, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "CO2-LEAN AMINE-BS", MaterialCode = "CS", SubFluid = "CO2-LEAN", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 51, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "CO2-SEMI LEAN AMINE-BS", MaterialCode = "CS", SubFluid = "CO2-Semi Lean", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 52, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "CO2", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 53, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "Methanated Gas", MaterialCode = "CS/LAS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 54, DMCode = "SCC-Amm", DMType = "SCC", DMDescription = "SCC-Amm", DMRate = "LOW", Source = "Ammonia", FluidName = "Ammonia Processing", MaterialCode = "CS/LTCS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 55, DMCode = "SCC-Amm", DMType = "SCC", DMDescription = "SCC-Amm", DMRate = "LOW", Source = "Ammonia", FluidName = "Ammonia Processing", MaterialCode = "CS/LTCS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 56, DMCode = "Corr-Fatigue", DMType = "SCC", DMDescription = "Corr-Fatigue", DMRate = "LOW", Source = "Ammonia", FluidName = "Purge Gas", MaterialCode = "CS", SubFluid = "", SpecialCondition = "Non PWHT ", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 57, DMCode = "SCC-Alkhaline", DMType = "SCC", DMDescription = "SCC-Alkhaline", DMRate = "LOW", Source = "Ammonia", FluidName = "Amm Recovery", MaterialCode = "CS", SubFluid = "", SpecialCondition = "Alchaline corrosion due to higher Ammonia", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 58, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "MED", Source = "Ammonia", FluidName = "H2S-RICH AMINE-BS", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 59, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "MED", Source = "Ammonia", FluidName = "H2S-SEMI LEAN AMINE-BS", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 60, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "MED", Source = "Ammonia", FluidName = "H2S- LEAN AMINE-BS", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 61, DMCode = "West H2S Cracking", DMType = "SCC", DMDescription = "West H2S Cracking", DMRate = "MED", Source = "Ammonia", FluidName = "H2S + CO2", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 62, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "H2S-RICH AMINE-MDEA", MaterialCode = "CS", SubFluid = "", SpecialCondition = "PWHT is required", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 63, DMCode = "AMINE cracking", DMType = "SCC", DMDescription = "AMINE cracking", DMRate = "LOW", Source = "Ammonia", FluidName = "H2S-SEMI LEAN AMINE-MDEA", MaterialCode = "CS", SubFluid = "", SpecialCondition = "PWHT is required", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 64, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "CO2-RICH AMINE-aMDEA", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 65, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "CO2-LEAN AMINE-aMDEA", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new DMGuide { ID = 66, DMCode = "Carbonate SCC", DMType = "SCC", DMDescription = "Carbonate SCC", DMRate = "LOW", Source = "Ammonia", FluidName = "CO2-SEMI LEAN AMINE-aMDEA", MaterialCode = "CS", SubFluid = "", SpecialCondition = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }

           );

            modelBuilder.Entity<RiskPriority>()
          .HasData(
           new RiskPriority { ID = 1, COF = "A", POF = 1, Priority = 1, Risk = "HIGH", Financial = 1000000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 2, COF = "A", POF = 2, Priority = 3, Risk = "HIGH", Financial = 100000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 3, COF = "A", POF = 3, Priority = 5, Risk = "HIGH", Financial = 10000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 4, COF = "A", POF = 4, Priority = 10, Risk = "MEDIUM HIGH", Financial = 1000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 5, COF = "A", POF = 5, Priority = 12, Risk = "MEDIUM HIGH", Financial = 100, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 6, COF = "B", POF = 1, Priority = 2, Risk = "HIGH", Financial = 1000000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 7, COF = "B", POF = 2, Priority = 6, Risk = "MEDIUM HIGH", Financial = 100000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 8, COF = "B", POF = 3, Priority = 9, Risk = "MEDIUM HIGH", Financial = 1000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 9, COF = "B", POF = 4, Priority = 15, Risk = "MEDIUMH", Financial = 100, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 10, COF = "B", POF = 5, Priority = 19, Risk = "MEDIUM", Financial = 10, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 11, COF = "C", POF = 1, Priority = 4, Risk = "HIGH", Financial = 10000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 12, COF = "C", POF = 2, Priority = 8, Risk = "MEDIUM HIGH", Financial = 1000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 13, COF = "C", POF = 3, Priority = 14, Risk = "MEDIUM", Financial = 100, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 14, COF = "C", POF = 4, Priority = 18, Risk = "MEDIUM", Financial = 10, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 15, COF = "C", POF = 5, Priority = 22, Risk = "LOW", Financial = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

           new RiskPriority { ID = 16, COF = "D", POF = 1, Priority = 7, Risk = "MEDIUM HIGH", Financial = 1000, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 17, COF = "D", POF = 2, Priority = 13, Risk = "MEDIUM", Financial = 100, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 18, COF = "D", POF = 3, Priority = 17, Risk = "MEDIUM", Financial = 10, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 19, COF = "D", POF = 4, Priority = 21, Risk = "LOW", Financial = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 20, COF = "D", POF = 5, Priority = 24, Risk = "LOW", Financial = 0, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },

           new RiskPriority { ID = 21, COF = "E", POF = 1, Priority = 11, Risk = "MEDIUM HIGH", Financial = 100, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 22, COF = "E", POF = 2, Priority = 16, Risk = "MEDIUM", Financial = 10, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 23, COF = "E", POF = 3, Priority = 20, Risk = "LOW", Financial = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 24, COF = "E", POF = 4, Priority = 23, Risk = "LOW", Financial = 0, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
           new RiskPriority { ID = 25, COF = "E", POF = 5, Priority = 25, Risk = "LOW", Financial = 0, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
           );


            modelBuilder.Entity<FluidModel>()
       .HasData(
        new FluidModel { ID = 1, FluidStoredPhase = "Gas", FluidReleasePhase = "Gas", Model = "Gas", NBP= "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
        new FluidModel { ID = 2, FluidStoredPhase = "Gas", FluidReleasePhase = "Liquid", Model = "Gas", NBP = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
        new FluidModel { ID = 3, FluidStoredPhase = "Liquid", FluidReleasePhase = "Gas", Model = "Gas", NBP = "<=27", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
        new FluidModel { ID = 4, FluidStoredPhase = "Liquid", FluidReleasePhase = "Gas", Model = "Liquid", NBP = ">27", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
        new FluidModel { ID = 5, FluidStoredPhase = "Liquid", FluidReleasePhase = "Liquid", Model = "Liquid", NBP = "", CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
        );

            modelBuilder.Entity<RepresentativeFluid>()
   .HasData(
    new RepresentativeFluid { ID = 1, Fluid = "Natural Gas", RepresentFluid = "C1-C2", DisplayOrder = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new RepresentativeFluid { ID = 2, Fluid = "Methane", RepresentFluid = "C3-C4", DisplayOrder = 2,  CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new RepresentativeFluid { ID = 3, Fluid = "Hydrogen", RepresentFluid = "H2", DisplayOrder = 3, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }    
    );

            modelBuilder.Entity<FluidProperty>()
  .HasData(
   new FluidProperty { ID = 1, RepresentativeFluid = "C1-C2", MolecularWeight = 23M, LiquidDensity = 250.512M, NBP = -125M, SpecificHeatCapacityRatio=1.1M, AIT =558M, FluidReleasePhase="Gas", FluidType ="TYPE 0", Flammable="Y", Toxic="N", NFNT="N", K= 1.3M, DisplayOrder = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
   new FluidProperty { ID = 2, RepresentativeFluid = "C3-C4", MolecularWeight = 51M, LiquidDensity = 538.379M, NBP = -21M, SpecificHeatCapacityRatio = 1.05M, AIT = 369M, FluidReleasePhase = "Gas", FluidType = "TYPE 0", Flammable = "Y", Toxic = "N", NFNT = "N", K = 1.1M, DisplayOrder = 2, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
   new FluidProperty { ID = 3, RepresentativeFluid = "H2", MolecularWeight = 2M, LiquidDensity = 71.012M, NBP = -253M, SpecificHeatCapacityRatio = 1.38M, AIT = 400M, FluidReleasePhase = "Gas", FluidType = "TYPE 0", Flammable = "Y", Toxic = "N", NFNT = "N", K = 1.2M, DisplayOrder = 3, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
   new FluidProperty { ID = 4, RepresentativeFluid = "Ammonia", MolecularWeight = 0M, LiquidDensity = 0M, NBP = 0M, SpecificHeatCapacityRatio = 0M, AIT = 0M, FluidReleasePhase = "Gas", FluidType = "TYPE 0", Flammable = "N", Toxic = "Y", NFNT = "N", K = 1.3M, DisplayOrder = 4, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
   
   );

            modelBuilder.Entity<FlammableConstant>()
.HasData(
new FlammableConstant { ID = 1, Fluid = "C1-C2", FluidModel= "Gas", CAINL_A_cmd = 8.669M, CAINL_B_cmd = 0.98M, IAINL_A_cmd = 6.469M, IAINL_B_cmd = 0.67M, CAIL_A_cmd = 55.13M, CAIL_B_cmd = 0.95M, IAIL_A_cmd = 163.7M, IAIL_B_cmd = 0.62M, CAINL_A_pi = 21.83M, CAINL_B_pi = 0.96M, IAINL_A_pi = 12.46M, IAINL_B_pi = 0.67M, CAIL_A_pi = 143.2M, CAIL_B_pi = 0.92M, IAIL_A_pi = 473.9M, IAIL_B_pi = 0.63M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new FlammableConstant { ID = 2, Fluid = "C1-C2", FluidModel = "Liquid", CAINL_A_cmd = 0M, CAINL_B_cmd = 0M, IAINL_A_cmd = 0M, IAINL_B_cmd = 0M, CAIL_A_cmd = 0M, CAIL_B_cmd = 0M, IAIL_A_cmd = 0M, IAIL_B_cmd = 0M, CAINL_A_pi = 0M, CAINL_B_pi = 0M, IAINL_A_pi = 0M, IAINL_B_pi = 0M, CAIL_A_pi = 0M, CAIL_B_pi = 0M, IAIL_A_pi = 0M, IAIL_B_pi = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new FlammableConstant { ID = 3, Fluid = "C3-C4", FluidModel = "Gas", CAINL_A_cmd = 0M, CAINL_B_cmd = 0M, IAINL_A_cmd = 0M, IAINL_B_cmd = 0M, CAIL_A_cmd = 0M, CAIL_B_cmd = 0M, IAIL_A_cmd = 0M, IAIL_B_cmd = 0M, CAINL_A_pi = 0M, CAINL_B_pi = 0M, IAINL_A_pi = 0M, IAINL_B_pi = 0M, CAIL_A_pi = 0M, CAIL_B_pi = 0M, IAIL_A_pi = 0M, IAIL_B_pi = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
new FlammableConstant { ID = 4, Fluid = "Ammonia", FluidModel = "Gas", CAINL_A_cmd = 0M, CAINL_B_cmd = 0M, IAINL_A_cmd = 0M, IAINL_B_cmd = 0M, CAIL_A_cmd = 0M, CAIL_B_cmd = 0M, IAIL_A_cmd = 0M, IAIL_B_cmd = 0M, CAINL_A_pi = 0M, CAINL_B_pi = 0M, IAINL_A_pi = 0M, IAINL_B_pi = 0M, CAIL_A_pi = 0M, CAIL_B_pi = 0M, IAIL_A_pi = 0M, IAIL_B_pi = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }                    

);


            modelBuilder.Entity<FluidIC>()
   .HasData(
    new FluidIC { ID = 1, FluidType = "Type 0", ReleaseType = "CONTINUOUS", FactIC = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new FluidIC { ID = 2, FluidType = "Type 0", ReleaseType = "INSTANTANEOUS", FactIC = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new FluidIC { ID = 3, FluidType = "Type 1", ReleaseType = "CONTINUOUS", FactIC = 0, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new FluidIC { ID = 4, FluidType = "Type 1", ReleaseType = "INSTANTANEOUS", FactIC = 1, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
    );


            modelBuilder.Entity<LDMax>()
        .HasData(
         new LDMax { ID = 1, DetectionRating = "A", IsolationRating = "A", D1 = 20, D2 = 10, D3 = 5, ReductionFactor = 0.25M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 2, DetectionRating = "A", IsolationRating = "B", D1 = 30, D2 = 20, D3 = 10, ReductionFactor = 0.2M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 3, DetectionRating = "A", IsolationRating = "C", D1 = 40, D2 = 30, D3 = 20, ReductionFactor = 0.1M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 4, DetectionRating = "B", IsolationRating = "A", D1 = 40, D2 = 30, D3 = 20, ReductionFactor = 0.15M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 5, DetectionRating = "B", IsolationRating = "B", D1 = 40, D2 = 30, D3 = 20, ReductionFactor = 0.15M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 6, DetectionRating = "B", IsolationRating = "C", D1 = 60, D2 = 30, D3 = 20, ReductionFactor = 0.1M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 7, DetectionRating = "C", IsolationRating = "A", D1 = 60, D2 = 40, D3 = 20, ReductionFactor = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 8, DetectionRating = "C", IsolationRating = "B", D1 = 60, D2 = 40, D3 = 20, ReductionFactor = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
         new LDMax { ID = 9, DetectionRating = "C", IsolationRating = "C", D1 = 60, D2 = 40, D3 = 20, ReductionFactor = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
         );

            modelBuilder.Entity<DetectionIsolation>()
 .HasData(
  new DetectionIsolation { ID = 1, DetectionRating = "A", IsolationRating = "A", FactDI = 0.25M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 2, DetectionRating = "A", IsolationRating = "B", FactDI = 0.2M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 3, DetectionRating = "A", IsolationRating = "C", FactDI = 0.1M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 4, DetectionRating = "B", IsolationRating = "A", FactDI = 0.15M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 5, DetectionRating = "B", IsolationRating = "B", FactDI = 0.15M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 6, DetectionRating = "B", IsolationRating = "C", FactDI = 0.1M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 7, DetectionRating = "C", IsolationRating = "A", FactDI = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 8, DetectionRating = "C", IsolationRating = "B", FactDI = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
  new DetectionIsolation { ID = 9, DetectionRating = "C", IsolationRating = "C", FactDI = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
  );

            modelBuilder.Entity<MitigationSystem>()
   .HasData(
    new MitigationSystem { ID = 1, Mitigation = "Inventory blowdown, coupled with isolation system classification B or higher", SystemCode = "BD", FactMIT = 0.25M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new MitigationSystem { ID = 2, Mitigation = "Fire water deluge system and monitors", SystemCode = "FWS", FactMIT = 0.2M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new MitigationSystem { ID = 3, Mitigation = "Fire water monitors only", SystemCode = "FWM", FactMIT = 0.05M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new MitigationSystem { ID = 4, Mitigation = "Foam spray system", SystemCode = "FS", FactMIT = 0.15M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
    new MitigationSystem { ID = 5, Mitigation = "Not available", SystemCode = "NA", FactMIT = 0M, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }
    );

            modelBuilder.Entity<GFF>()
          .HasData(
                 new GFF { ID = 1, ComponentType = "PIPE", ComponentDiameterFrom = 400, ComponentDiameterTo = 9999, Gff1 =0, Gff2=0, Gff3= 0, Gff4=0, GffTotal =0, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now },
                 new GFF { ID = 2, ComponentType = "PIPE", ComponentDiameterFrom = 300, ComponentDiameterTo = 400, Gff1 = 0, Gff2 = 0, Gff3 = 0, Gff4 = 0, GffTotal = 0, CreatedBy = "SYSADMIN", CreatedDate = DateTime.Now }

                );




                   base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Entity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((Entity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((Entity)entityEntry.Entity).ModifiedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
