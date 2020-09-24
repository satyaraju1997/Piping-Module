using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Piping.Repository.Migrations
{
    public partial class Initial_MigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COF",
                columns: table => new
                {
                    COFID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    EquipmentNo = table.Column<string>(nullable: true),
                    FluidCode = table.Column<string>(nullable: true),
                    Holes = table.Column<string>(nullable: true),
                    ReferenceFluid = table.Column<string>(nullable: true),
                    ToxicFluid = table.Column<string>(nullable: true),
                    ToxicPercentage = table.Column<decimal>(nullable: true),
                    ReleaseState = table.Column<string>(nullable: true),
                    StoredStage = table.Column<string>(nullable: true),
                    ReleaseModel = table.Column<string>(nullable: true),
                    OpPr = table.Column<decimal>(nullable: true),
                    Detection = table.Column<string>(nullable: true),
                    Isolation = table.Column<string>(nullable: true),
                    Mitigation = table.Column<string>(nullable: true),
                    Diameter = table.Column<decimal>(nullable: true),
                    Length = table.Column<decimal>(nullable: true),
                    OpTemp = table.Column<decimal>(nullable: true),
                    IgnitionSourceNearBy = table.Column<string>(nullable: true),
                    MassInventory = table.Column<decimal>(nullable: true),
                    CdLiquid = table.Column<decimal>(nullable: true),
                    CdVapour = table.Column<decimal>(nullable: true),
                    Kv = table.Column<int>(nullable: true),
                    Gc = table.Column<int>(nullable: true),
                    C1 = table.Column<int>(nullable: true),
                    Patm = table.Column<decimal>(nullable: true),
                    HoleDia = table.Column<decimal>(nullable: true),
                    MaxDiaWmax = table.Column<decimal>(nullable: true),
                    MW = table.Column<decimal>(nullable: true),
                    FluidType = table.Column<int>(nullable: true),
                    AIT = table.Column<decimal>(nullable: true),
                    EffectiveDensity = table.Column<decimal>(nullable: true),
                    VapourDensity = table.Column<decimal>(nullable: true),
                    LiquidDensity = table.Column<decimal>(nullable: true),
                    K = table.Column<decimal>(nullable: true),
                    Max60XLD = table.Column<decimal>(nullable: true),
                    Area = table.Column<decimal>(nullable: true),
                    OpPrPlus101 = table.Column<decimal>(nullable: true),
                    LiquidReleaseRate = table.Column<decimal>(nullable: true),
                    Ptrans = table.Column<decimal>(nullable: true),
                    Wn1 = table.Column<decimal>(nullable: true),
                    Wn2 = table.Column<decimal>(nullable: true),
                    PPtrans = table.Column<decimal>(nullable: true),
                    VapourReleaseRate = table.Column<decimal>(nullable: true),
                    EffectiveReleaseRate = table.Column<decimal>(nullable: true),
                    MaxAreaWmax = table.Column<decimal>(nullable: true),
                    LiquidReleaseRateLDmax = table.Column<decimal>(nullable: true),
                    Wn1Wmax = table.Column<decimal>(nullable: true),
                    Wn2Wmax = table.Column<decimal>(nullable: true),
                    VapourReleaseRateWmax = table.Column<decimal>(nullable: true),
                    EffectiveReleaseRateWmax = table.Column<decimal>(nullable: true),
                    MassComp = table.Column<decimal>(nullable: true),
                    AvailableMassInventory = table.Column<decimal>(nullable: true),
                    MassAdd = table.Column<decimal>(nullable: true),
                    MassCompPlusMassAdd = table.Column<decimal>(nullable: true),
                    MassAvailable = table.Column<decimal>(nullable: true),
                    Tn = table.Column<decimal>(nullable: true),
                    ReleaseType = table.Column<string>(nullable: true),
                    FactDI = table.Column<decimal>(nullable: true),
                    FactMIT = table.Column<decimal>(nullable: true),
                    Raten = table.Column<decimal>(nullable: true),
                    LDn = table.Column<decimal>(nullable: true),
                    Massn = table.Column<decimal>(nullable: true),
                    CAINL_A_cmd = table.Column<decimal>(nullable: true),
                    CAINL_B_cmd = table.Column<decimal>(nullable: true),
                    IAINL_A_cmd = table.Column<decimal>(nullable: true),
                    IAINL_B_cmd = table.Column<decimal>(nullable: true),
                    CAIL_A_cmd = table.Column<decimal>(nullable: true),
                    CAIL_B_cmd = table.Column<decimal>(nullable: true),
                    IAIL_A_cmd = table.Column<decimal>(nullable: true),
                    IAIL_B_cmd = table.Column<decimal>(nullable: true),
                    CAINL_A_pi = table.Column<decimal>(nullable: true),
                    CAINL_B_pi = table.Column<decimal>(nullable: true),
                    IAINL_A_pi = table.Column<decimal>(nullable: true),
                    IAINL_B_pi = table.Column<decimal>(nullable: true),
                    CAIL_A_pi = table.Column<decimal>(nullable: true),
                    CAIL_B_pi = table.Column<decimal>(nullable: true),
                    IAIL_A_pi = table.Column<decimal>(nullable: true),
                    IAIL_B_pi = table.Column<decimal>(nullable: true),
                    Ts = table.Column<decimal>(nullable: true),
                    Enff = table.Column<decimal>(nullable: true),
                    CAINL_CA_cmd = table.Column<decimal>(nullable: true),
                    IAINL_CA_cmd = table.Column<decimal>(nullable: true),
                    CAIL_CA_cmd = table.Column<decimal>(nullable: true),
                    IAIL_CA_cmd = table.Column<decimal>(nullable: true),
                    CAINL_CA_pi = table.Column<decimal>(nullable: true),
                    IAINL_CA_pi = table.Column<decimal>(nullable: true),
                    CAIL_CA_pi = table.Column<decimal>(nullable: true),
                    IAIL_CA_pi = table.Column<decimal>(nullable: true),
                    FactICcalc = table.Column<decimal>(nullable: true),
                    FactIC = table.Column<decimal>(nullable: true),
                    AINL_CMD_CA = table.Column<decimal>(nullable: true),
                    AIL_CMD_CA = table.Column<decimal>(nullable: true),
                    AINL_PI_CA = table.Column<decimal>(nullable: true),
                    AIL_PI_CA = table.Column<decimal>(nullable: true),
                    TsPlus55 = table.Column<decimal>(nullable: true),
                    TsMinus55 = table.Column<decimal>(nullable: true),
                    FactAITcalc = table.Column<decimal>(nullable: true),
                    FactAIT = table.Column<decimal>(nullable: true),
                    CA_cmd = table.Column<decimal>(nullable: true),
                    CA_pi = table.Column<decimal>(nullable: true),
                    GFFn = table.Column<decimal>(nullable: true),
                    GFFtotal = table.Column<decimal>(nullable: true),
                    Final_CA_cmd = table.Column<decimal>(nullable: true),
                    Final_CA_pi = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COF", x => x.COFID);
                });

            migrationBuilder.CreateTable(
                name: "MST_COFFluid",
                columns: table => new
                {
                    COFFluidID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    Fluid = table.Column<string>(nullable: true),
                    FluidModel = table.Column<string>(nullable: true),
                    CAINL_A_cmd = table.Column<decimal>(nullable: true),
                    CAINL_B_cmd = table.Column<decimal>(nullable: true),
                    IAINL_A_cmd = table.Column<decimal>(nullable: true),
                    IAINL_B_cmd = table.Column<decimal>(nullable: true),
                    CAIL_A_cmd = table.Column<decimal>(nullable: true),
                    CAIL_B_cmd = table.Column<decimal>(nullable: true),
                    IAIL_A_cmd = table.Column<decimal>(nullable: true),
                    IAIL_B_cmd = table.Column<decimal>(nullable: true),
                    CAINL_A_pi = table.Column<decimal>(nullable: true),
                    CAINL_B_pi = table.Column<decimal>(nullable: true),
                    IAINL_A_pi = table.Column<decimal>(nullable: true),
                    IAINL_B_pi = table.Column<decimal>(nullable: true),
                    CAIL_A_pi = table.Column<decimal>(nullable: true),
                    CAIL_B_pi = table.Column<decimal>(nullable: true),
                    IAIL_A_pi = table.Column<decimal>(nullable: true),
                    IAIL_B_pi = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_COFFluid", x => x.COFFluidID);
                });

            migrationBuilder.CreateTable(
                name: "MST_COFIC",
                columns: table => new
                {
                    COFIC_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    FluidType = table.Column<string>(nullable: true),
                    ReleaseType = table.Column<string>(nullable: true),
                    FactIC = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_COFIC", x => x.COFIC_ID);
                });

            migrationBuilder.CreateTable(
                name: "MST_DetectionIsolation",
                columns: table => new
                {
                    DetectionIsolationID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    DetectionRating = table.Column<string>(nullable: true),
                    IsolationRating = table.Column<string>(nullable: true),
                    FactDI = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_DetectionIsolation", x => x.DetectionIsolationID);
                });

            migrationBuilder.CreateTable(
                name: "MST_FluidAttribute",
                columns: table => new
                {
                    FluidAttributeID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    Fluid = table.Column<string>(nullable: true),
                    RepresentFluid = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_FluidAttribute", x => x.FluidAttributeID);
                });

            migrationBuilder.CreateTable(
                name: "MST_FluidPhase",
                columns: table => new
                {
                    FluidPhaseID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    FluidStoredPhase = table.Column<string>(nullable: true),
                    FluidReleasePhase = table.Column<string>(nullable: true),
                    FluidModel = table.Column<string>(nullable: true),
                    NBP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_FluidPhase", x => x.FluidPhaseID);
                });

            migrationBuilder.CreateTable(
                name: "MST_FluidReference",
                columns: table => new
                {
                    FluidReferenceID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    RepresentativeFluid = table.Column<string>(nullable: true),
                    MolecularWeight = table.Column<decimal>(nullable: true),
                    LiquidDensity = table.Column<decimal>(nullable: true),
                    NBP = table.Column<decimal>(nullable: true),
                    SpecificHeatCapacityRatio = table.Column<decimal>(nullable: true),
                    AIT = table.Column<decimal>(nullable: true),
                    FluidReleasePhase = table.Column<string>(nullable: true),
                    FluidType = table.Column<string>(nullable: true),
                    Flammable = table.Column<string>(nullable: true),
                    Toxic = table.Column<string>(nullable: true),
                    NFNT = table.Column<string>(nullable: true),
                    K = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_FluidReference", x => x.FluidReferenceID);
                });

            migrationBuilder.CreateTable(
                name: "MST_GFF",
                columns: table => new
                {
                    GFF_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    ComponentType = table.Column<string>(nullable: true),
                    ComponentDiameterFrom = table.Column<int>(nullable: true),
                    ComponentDiameterTo = table.Column<int>(nullable: true),
                    Gff1 = table.Column<decimal>(nullable: true),
                    Gff2 = table.Column<decimal>(nullable: true),
                    Gff3 = table.Column<decimal>(nullable: true),
                    Gff4 = table.Column<decimal>(nullable: true),
                    GffTotal = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_GFF", x => x.GFF_ID);
                });

            migrationBuilder.CreateTable(
                name: "MST_LDMax",
                columns: table => new
                {
                    LDMaxID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    DetectionRating = table.Column<string>(nullable: true),
                    IsolationRating = table.Column<string>(nullable: true),
                    D1 = table.Column<decimal>(nullable: true),
                    D2 = table.Column<decimal>(nullable: true),
                    D3 = table.Column<decimal>(nullable: true),
                    ReductionFactor = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_LDMax", x => x.LDMaxID);
                });

            migrationBuilder.CreateTable(
                name: "MST_MitigationSystem",
                columns: table => new
                {
                    MitigationSystemID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    Mitigation = table.Column<string>(nullable: true),
                    SystemCode = table.Column<string>(nullable: true),
                    FactMIT = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MST_MitigationSystem", x => x.MitigationSystemID);
                });

            migrationBuilder.CreateTable(
                name: "PipeMasterCOF",
                columns: table => new
                {
                    PipeMasterCOFID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SystemInfo = table.Column<string>(maxLength: 50, nullable: true),
                    PipeMasterID = table.Column<int>(nullable: true),
                    EquipmentNo = table.Column<string>(nullable: true),
                    FluidCode = table.Column<string>(nullable: true),
                    ApplicableFluid = table.Column<string>(nullable: true),
                    Fluid = table.Column<string>(nullable: true),
                    ToxicFluid = table.Column<string>(nullable: true),
                    ToxicFluidPercentage = table.Column<decimal>(nullable: true),
                    ReleaseState = table.Column<string>(nullable: true),
                    StoredStage = table.Column<string>(nullable: true),
                    ReleaseModel = table.Column<string>(nullable: true),
                    OperatingPressure = table.Column<decimal>(nullable: true),
                    DetectionRating = table.Column<string>(nullable: true),
                    IsolationRating = table.Column<string>(nullable: true),
                    Mitigation = table.Column<string>(nullable: true),
                    ComponentDiameter = table.Column<decimal>(nullable: true),
                    ComponentLength = table.Column<decimal>(nullable: true),
                    OperatingTemperature = table.Column<decimal>(nullable: true),
                    IgnitionSource = table.Column<string>(nullable: true),
                    MassInventory = table.Column<decimal>(nullable: true),
                    MassComponent = table.Column<decimal>(nullable: true),
                    NormalBoilingPoint = table.Column<decimal>(nullable: true),
                    MolecularWeight = table.Column<decimal>(nullable: true),
                    FluidPhase = table.Column<string>(nullable: true),
                    FluidPhaseStored = table.Column<string>(nullable: true),
                    ComponentType = table.Column<string>(nullable: true),
                    Flammable = table.Column<string>(nullable: true),
                    Toxic = table.Column<string>(nullable: true),
                    NFNT = table.Column<string>(nullable: true),
                    ProductionLoss = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeMasterCOF", x => x.PipeMasterCOFID);
                    table.ForeignKey(
                        name: "FK_PipeMasterCOF_PipeMaster_PipeMasterID",
                        column: x => x.PipeMasterID,
                        principalTable: "PipeMaster",
                        principalColumn: "PipeMasterID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 352, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 352, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 352, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 352, DateTimeKind.Local).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 352, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 352, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "AlertMaster",
                keyColumn: "AlertMasterID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "AlertMaster",
                keyColumn: "AlertMasterID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "AlertMaster",
                keyColumn: "AlertMasterID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "CompanyID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(9009));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8140));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8155));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8163));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8165));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8176));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8192));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8195));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8204));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8261));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8292));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8308));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8319));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 385, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 370, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 370, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 370, DateTimeKind.Local).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 370, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 370, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.InsertData(
                table: "MST_COFFluid",
                columns: new[] { "COFFluidID", "CAIL_A_cmd", "CAIL_A_pi", "CAIL_B_cmd", "CAIL_B_pi", "CAINL_A_cmd", "CAINL_A_pi", "CAINL_B_cmd", "CAINL_B_pi", "CreatedBy", "CreatedDate", "Fluid", "FluidModel", "IAIL_A_cmd", "IAIL_A_pi", "IAIL_B_cmd", "IAIL_B_pi", "IAINL_A_cmd", "IAINL_A_pi", "IAINL_B_cmd", "IAINL_B_pi", "ModifiedBy", "ModifiedDate", "SystemInfo" },
                values: new object[,]
                {
                    { 1, 55.13m, 143.2m, 0.95m, 0.92m, 8.669m, 21.83m, 0.98m, 0.96m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 389, DateTimeKind.Local).AddTicks(9883), "C1-C2", "Gas", 163.7m, 473.9m, 0.62m, 0.63m, 6.469m, 12.46m, 0.67m, 0.67m, null, null, null },
                    { 2, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(212), "C1-C2", "Liquid", 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, null, null, null },
                    { 3, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(220), "C3-C4", "Gas", 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, null, null, null },
                    { 4, 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(228), "Ammonia", "Gas", 0m, 0m, 0m, 0m, 0m, 0m, 0m, 0m, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "MST_COFIC",
                columns: new[] { "COFIC_ID", "CreatedBy", "CreatedDate", "FactIC", "FluidType", "ModifiedBy", "ModifiedDate", "ReleaseType", "SystemInfo" },
                values: new object[,]
                {
                    { 1, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(3224), 1m, "Type 0", null, null, "CONTINUOUS", null },
                    { 2, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(3320), 1m, "Type 0", null, null, "INSTANTANEOUS", null },
                    { 3, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(3323), 0m, "Type 1", null, null, "CONTINUOUS", null },
                    { 4, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(3326), 1m, "Type 1", null, null, "INSTANTANEOUS", null }
                });

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6943));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6958));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6972));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6984));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7011));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4543));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4657));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.InsertData(
                table: "MST_DetectionIsolation",
                columns: new[] { "DetectionIsolationID", "CreatedBy", "CreatedDate", "DetectionRating", "FactDI", "IsolationRating", "ModifiedBy", "ModifiedDate", "SystemInfo" },
                values: new object[,]
                {
                    { 4, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(907), "B", 0.15m, "A", null, null, null },
                    { 5, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(910), "B", 0.15m, "B", null, null, null },
                    { 6, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(913), "B", 0.1m, "C", null, null, null },
                    { 7, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(917), "C", 0m, "A", null, null, null },
                    { 8, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(921), "C", 0m, "B", null, null, null },
                    { 9, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(924), "C", 0m, "C", null, null, null },
                    { 2, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(899), "A", 0.2m, "B", null, null, null },
                    { 1, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(804), "A", 0.25m, "A", null, null, null },
                    { 3, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(904), "A", 0.1m, "C", null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3711));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3871));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3884));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 383, DateTimeKind.Local).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(7178));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(7344));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(758));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(769));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(772));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(776));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(796));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(806));

            migrationBuilder.InsertData(
                table: "MST_FluidAttribute",
                columns: new[] { "FluidAttributeID", "CreatedBy", "CreatedDate", "DisplayOrder", "Fluid", "ModifiedBy", "ModifiedDate", "RepresentFluid", "SystemInfo" },
                values: new object[,]
                {
                    { 3, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(8945), 3, "Hydrogen", null, null, "H2", null },
                    { 1, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(8831), 1, "Natural Gas", null, null, "C1-C2", null },
                    { 2, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(8938), 2, "Methane", null, null, "C3-C4", null }
                });

            migrationBuilder.InsertData(
                table: "MST_FluidPhase",
                columns: new[] { "FluidPhaseID", "CreatedBy", "CreatedDate", "FluidModel", "FluidReleasePhase", "FluidStoredPhase", "ModifiedBy", "ModifiedDate", "NBP", "SystemInfo" },
                values: new object[,]
                {
                    { 1, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(5697), "Gas", "Gas", "Gas", null, null, "", null },
                    { 2, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(5846), "Gas", "Liquid", "Gas", null, null, "", null },
                    { 3, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(5853), "Gas", "Gas", "Liquid", null, null, "<=27", null },
                    { 4, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(5859), "Liquid", "Gas", "Liquid", null, null, ">27", null },
                    { 5, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(5865), "Liquid", "Liquid", "Liquid", null, null, "", null }
                });

            migrationBuilder.InsertData(
                table: "MST_FluidReference",
                columns: new[] { "FluidReferenceID", "AIT", "CreatedBy", "CreatedDate", "DisplayOrder", "Flammable", "FluidReleasePhase", "FluidType", "K", "LiquidDensity", "ModifiedBy", "ModifiedDate", "MolecularWeight", "NBP", "NFNT", "RepresentativeFluid", "SpecificHeatCapacityRatio", "SystemInfo", "Toxic" },
                values: new object[,]
                {
                    { 1, 558m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 388, DateTimeKind.Local).AddTicks(7708), 1, "Y", "Gas", "TYPE 0", 1.3m, 250.512m, null, null, 23m, -125m, "N", "C1-C2", 1.1m, null, "N" },
                    { 2, 369m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 388, DateTimeKind.Local).AddTicks(7957), 2, "Y", "Gas", "TYPE 0", 1.1m, 538.379m, null, null, 51m, -21m, "N", "C3-C4", 1.05m, null, "N" },
                    { 3, 400m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 388, DateTimeKind.Local).AddTicks(7967), 3, "Y", "Gas", "TYPE 0", 1.2m, 71.012m, null, null, 2m, -253m, "N", "H2", 1.38m, null, "N" },
                    { 4, 0m, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 388, DateTimeKind.Local).AddTicks(8010), 4, "N", "Gas", "TYPE 0", 1.3m, 0m, null, null, 0m, 0m, "N", "Ammonia", 0m, null, "Y" }
                });

            migrationBuilder.InsertData(
                table: "MST_GFF",
                columns: new[] { "GFF_ID", "ComponentDiameterFrom", "ComponentDiameterTo", "ComponentType", "CreatedBy", "CreatedDate", "Gff1", "Gff2", "Gff3", "Gff4", "GffTotal", "ModifiedBy", "ModifiedDate", "SystemInfo" },
                values: new object[,]
                {
                    { 2, 300, 400, "PIPE", "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(8490), 0m, 0m, 0m, 0m, 0m, null, null, null },
                    { 1, 400, 9999, "PIPE", "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(8327), 0m, 0m, 0m, 0m, 0m, null, null, null }
                });

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 380, DateTimeKind.Local).AddTicks(3232));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 380, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 380, DateTimeKind.Local).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 380, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 380, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 380, DateTimeKind.Local).AddTicks(3355));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 380, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.InsertData(
                table: "MST_LDMax",
                columns: new[] { "LDMaxID", "CreatedBy", "CreatedDate", "D1", "D2", "D3", "DetectionRating", "IsolationRating", "ModifiedBy", "ModifiedDate", "ReductionFactor", "SystemInfo" },
                values: new object[,]
                {
                    { 1, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7504), 20m, 10m, 5m, "A", "A", null, null, 0.25m, null },
                    { 4, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7640), 40m, 30m, 20m, "B", "A", null, null, 0.15m, null },
                    { 3, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7636), 40m, 30m, 20m, "A", "C", null, null, 0.1m, null },
                    { 5, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7643), 40m, 30m, 20m, "B", "B", null, null, 0.15m, null },
                    { 6, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7647), 60m, 30m, 20m, "B", "C", null, null, 0.1m, null },
                    { 7, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7653), 60m, 40m, 20m, "C", "A", null, null, 0m, null },
                    { 8, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7658), 60m, 40m, 20m, "C", "B", null, null, 0m, null },
                    { 9, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7662), 60m, 40m, 20m, "C", "C", null, null, 0m, null },
                    { 2, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 390, DateTimeKind.Local).AddTicks(7630), 30m, 20m, 10m, "A", "B", null, null, 0.2m, null }
                });

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9486));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9496));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 382, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.InsertData(
                table: "MST_MitigationSystem",
                columns: new[] { "MitigationSystemID", "CreatedBy", "CreatedDate", "FactMIT", "Mitigation", "ModifiedBy", "ModifiedDate", "SystemCode", "SystemInfo" },
                values: new object[,]
                {
                    { 3, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(3325), 0.05m, "Fire water monitors only", null, null, "FWM", null },
                    { 2, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(3321), 0.2m, "Fire water deluge system and monitors", null, null, "FWS", null },
                    { 1, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(3246), 0.25m, "Inventory blowdown, coupled with isolation system classification B or higher", null, null, "BD", null },
                    { 4, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(3330), 0.15m, "Foam spray system", null, null, "FS", null },
                    { 5, "SYSADMIN", new DateTime(2020, 8, 12, 2, 10, 0, 391, DateTimeKind.Local).AddTicks(3334), 0m, "Not available", null, null, "NA", null }
                });

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(9401));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 384, DateTimeKind.Local).AddTicks(9405));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(663));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(676));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(693));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(699));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(704));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(713));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(719));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(725));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 387, DateTimeKind.Local).AddTicks(737));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8924));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8929));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8940));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8946));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8949));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8956));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(8973));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9037));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9059));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9074));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9077));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9081));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 377, DateTimeKind.Local).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3593));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3615));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3622));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3647));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3653));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3662));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3671));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3677));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2713));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2865));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2873));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2881));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2887));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2891));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 360, DateTimeKind.Local).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 359, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 359, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 359, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 359, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 359, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 359, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 359, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 348, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 350, DateTimeKind.Local).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 350, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 350, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 350, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 350, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 350, DateTimeKind.Local).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7382));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7392));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7416));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7433));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7438));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7467));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7476));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7501));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7523));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7598));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 67,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7609));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 68,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 69,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7614));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 70,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 71,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 72,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 73,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 74,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 75,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7630));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 76,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 77,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 78,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 79,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 80,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 81,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7645));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 82,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 83,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 84,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 85,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 86,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 87,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 88,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 89,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 90,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 91,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 92,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 93,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 94,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 95,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 96,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 97,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7690));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 98,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7695));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 100,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7701));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 102,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7704));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 103,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 104,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 106,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 107,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 108,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 109,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 110,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 111,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 112,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7729));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 113,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7731));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 114,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7734));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 115,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 116,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 117,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 118,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 119,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 120,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7748));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 121,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 122,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 123,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 124,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 125,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 126,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 127,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 128,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 129,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 130,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 131,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 132,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7787));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 133,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7790));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 134,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7792));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 135,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 136,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 137,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 138,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 139,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 140,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 141,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 142,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 143,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7817));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 144,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7821));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 145,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7823));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 146,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 147,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 148,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 149,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7834));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 150,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 151,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 152,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 153,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 154,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 155,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 156,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 157,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 158,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 159,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 160,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 161,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 162,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 163,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 164,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 165,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 166,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 167,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 168,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 169,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 170,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 171,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 172,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 173,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 174,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7899));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 175,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7902));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 176,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 177,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7912));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 178,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 180,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7917));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 181,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 182,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7922));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 183,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7925));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 184,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 185,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 186,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 187,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7934));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 188,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 189,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 190,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 191,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 192,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7948));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 194,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 195,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 196,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 197,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 198,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 199,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 200,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 201,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 202,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 203,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7982));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 204,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 205,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 206,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7993));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 207,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7995));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 208,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 209,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 353, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(2857));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3035));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 369, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 371, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 12, 2, 10, 0, 372, DateTimeKind.Local).AddTicks(6736));

            migrationBuilder.CreateIndex(
                name: "IX_PipeMasterCOF_PipeMasterID",
                table: "PipeMasterCOF",
                column: "PipeMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COF");

            migrationBuilder.DropTable(
                name: "MST_COFFluid");

            migrationBuilder.DropTable(
                name: "MST_COFIC");

            migrationBuilder.DropTable(
                name: "MST_DetectionIsolation");

            migrationBuilder.DropTable(
                name: "MST_FluidAttribute");

            migrationBuilder.DropTable(
                name: "MST_FluidPhase");

            migrationBuilder.DropTable(
                name: "MST_FluidReference");

            migrationBuilder.DropTable(
                name: "MST_GFF");

            migrationBuilder.DropTable(
                name: "MST_LDMax");

            migrationBuilder.DropTable(
                name: "MST_MitigationSystem");

            migrationBuilder.DropTable(
                name: "PipeMasterCOF");

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "ActionID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "AlertMaster",
                keyColumn: "AlertMasterID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 744, DateTimeKind.Local).AddTicks(9119));

            migrationBuilder.UpdateData(
                table: "AlertMaster",
                keyColumn: "AlertMasterID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 744, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "AlertMaster",
                keyColumn: "AlertMasterID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 744, DateTimeKind.Local).AddTicks(9332));

            migrationBuilder.UpdateData(
                table: "Company",
                keyColumn: "CompanyID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9130));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9137));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9165));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9174));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9184));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9191));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9201));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9207));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9212));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9241));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9246));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9253));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9256));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9260));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9270));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9284));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9287));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9290));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9316));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9319));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9325));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9328));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9338));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9341));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9352));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9362));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "DMGuide",
                keyColumn: "DMGuideID",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 738, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 738, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 738, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "DepartmentID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 738, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 739, DateTimeKind.Local).AddTicks(3396));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2423));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2548));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2560));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2562));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2564));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2567));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2572));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2581));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2586));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2595));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2597));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2602));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2613));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2619));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "MST_CUICorrosionRate",
                keyColumn: "MST_CUICorrosionRate_ID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3609));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3632));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3635));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3638));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3646));

            migrationBuilder.UpdateData(
                table: "MST_CUISuceptability",
                keyColumn: "MST_CUISuceptability_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8560));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8578));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8588));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8594));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8602));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8605));

            migrationBuilder.UpdateData(
                table: "MST_ExternalCorrosionRate",
                keyColumn: "MST_ExternalCorrosionRate_ID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSeverityIndex",
                keyColumn: "MST_ExternalSeverityIndex_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 752, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7781));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7926));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7932));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7956));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(8072));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "MST_ExternalSuceptability",
                keyColumn: "MST_ExternalSuceptability_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 751, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 747, DateTimeKind.Local).AddTicks(9884));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 748, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 748, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 748, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 748, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 748, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "MST_InsulationType",
                keyColumn: "MST_InsulationType_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 748, DateTimeKind.Local).AddTicks(85));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4173));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4175));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4185));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "MST_MaterialCodes",
                keyColumn: "MST_MaterialCodes_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 750, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(1323));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.UpdateData(
                table: "MST_Observation",
                keyColumn: "ObservationMasterID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 753, DateTimeKind.Local).AddTicks(1334));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4320));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4323));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4337));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4364));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4379));

            migrationBuilder.UpdateData(
                table: "MST_RiskPriority",
                keyColumn: "RiskPriorityID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 754, DateTimeKind.Local).AddTicks(4382));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4681));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4714));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4728));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4768));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4771));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4779));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4792));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4822));

            migrationBuilder.UpdateData(
                table: "MST_StructuralMinThk",
                keyColumn: "MST_StructuralMinThk_ID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 745, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8207));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8385));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8419));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8428));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 726, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4563));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4565));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4567));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4571));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "PlantMaster",
                keyColumn: "PlantMasterID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(104));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(259));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "QuickLink",
                keyColumn: "QuickLinkID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 730, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 723, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 724, DateTimeKind.Local).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 724, DateTimeKind.Local).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 724, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 724, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 724, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 724, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1762));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1792));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1798));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1829));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1844));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1846));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1850));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1884));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1891));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1893));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1896));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1898));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1909));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1911));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1914));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1916));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1922));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1924));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 66,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 67,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 68,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 69,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 70,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 71,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 72,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1939));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 73,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1940));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 74,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1942));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 75,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1944));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 76,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1946));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 77,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1948));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 78,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 79,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1952));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 80,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 81,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1956));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 82,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1959));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 83,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1961));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 84,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 85,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 86,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 87,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 88,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 89,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 90,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 91,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 92,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 93,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 94,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 95,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1984));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 96,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 97,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 98,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1992));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 99,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 100,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1995));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 101,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(1997));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 102,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 103,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2001));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 104,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2003));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 105,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2005));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 106,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 107,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 108,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 109,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 110,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 111,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2024));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 112,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 113,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2028));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 114,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 115,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 116,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 117,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 118,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 119,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 120,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 121,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 122,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 123,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 124,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 125,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 126,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 127,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 128,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 129,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 130,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 131,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 132,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 133,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 134,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 135,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 136,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 137,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 138,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 139,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 140,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 141,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 142,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 143,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 144,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 145,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2103));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 146,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 147,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 148,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 149,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 150,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 151,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 152,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 153,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 154,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2126));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 155,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 156,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 157,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2134));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 158,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2137));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 159,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2142));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 160,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 161,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 162,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 163,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2152));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 164,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 165,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2158));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 166,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 167,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2161));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 168,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 169,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 170,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2167));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 171,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 172,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2171));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 173,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 174,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 175,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2177));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 176,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2179));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 177,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 178,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 180,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 181,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 182,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 183,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 184,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 185,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 186,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 187,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 188,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 189,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 190,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 191,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 192,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 193,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 194,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 195,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 196,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 197,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 198,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 199,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 200,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 201,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 202,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 203,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 204,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 205,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 206,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2241));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 207,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 208,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2245));

            migrationBuilder.UpdateData(
                table: "RoleMenuAction",
                keyColumn: "RoleMenuActionID",
                keyValue: 209,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 727, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1746));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1761));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1764));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1755));

            migrationBuilder.UpdateData(
                table: "RoleMenuQuickLink",
                keyColumn: "RoleMenuQuickLinkID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 737, DateTimeKind.Local).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 740, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 8, 10, 1, 36, 49, 740, DateTimeKind.Local).AddTicks(4135));
        }
    }
}
