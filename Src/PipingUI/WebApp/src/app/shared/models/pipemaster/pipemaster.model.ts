export class InspectionStrategy {
    ID: string;
    equipmentNo: string;
    dmCode: string;
    description: string;
    priority: string;
    frequency: string;
    recommendedProgram: string;
}

export class DocumentMaster {
    ID: string;
    equipmentNo: string;
    documentNo: string;
    description: string;
    format: string;
}

export class BasicData {
    id: number;
    equipmentNo: string;
    description: string;
    fromTo: string;
    plantCode: string;
    train: string;
    pandIDNo: string;
    areaCode: string;
    fluid: string;
    yearInService: number;
    overallStatus: string;
    nextInspectionDate: string;
    nextFollowDate: string;
    pipeClusterNo: string;
    corrosionLoopNo: string;
    modifiedBy: string
}

export class DesignData {
    id: number;
    designTemperature: number;
    designPressure: number;
    operatingTemperature: number;
    operatingPressure: number;
    pwht: string;
    materialCode: string;
    materialStd: string;
    materialGrade: string;
    pipeSpec: string;
    nominalDiameter: number;
    nominalThick: number;
    length: number;
    jointEfficiency: number;
    insulated: string;
    insulationType: string;
    corrosionAllowance: number;
    mdmt: number;
    constructionCode: string;
    modifiedBy: string;
    useLastMeasuredThick_ULMT: string;
    minReqThkOption_MRTO: string;
    allowableStressMPA_S: number;
    yieldStrengthMPA_YS: number;
    tensileStrengthMPA_TS: number;
    flowStress_FS: number;
    stengthRatio_SR: number;
    lastMeasuredThick_LMT: number;
    lastMeasuredYear_LMY: number;
    prMinReqThkInternal_PMTI: number;
    prMinReqThkExternal_PMTE: number;
    userCalPrMinReqThk_UMT: number;
    structuralMinThk_SMT: number;
    effectiveMinReqThk_EMRT: number;
    effectiveThk_ETHK: number;
}

export class InternalCorrosion {
    ID: string;
    equipmentNo: string;
    InjectionPoints: string;
    AllowableStress: string;
    YieldStrengh: string;
    Efficiency: string;
    TensileStregth: string;
    PrMinReqThk: string;
    MinReqThk: string;
    StructuralMinThk: string;
    TheoriticalCR: string;
    MeasuredLCR: string;
    MeasuredSCR: string;
    UseMeasuredLCR: string;
    UseMeasuredSCR: string;
    LastMeasuredThk: string;
    LastMesauredYear: string;
    EffectiveCR: string;
    NoofConfidenceHigh: string;
    NoofConfidenceMediumHigh: string;
    NoofConfidenceMedium: string;
    NoofConfidenceLow: string;
    DamageFactor: string;
    POF: string;
    EffectiveAge: string;
    EffectiveThk: string;
}

export class ExternalCorrosion {
    id: number;
    pipeMasterID: number;
    equipmentNo: string;
    theoriticalCR: number;
    effectiveCR: number;
    measuredLCR: number;
    measuredSCR: number;
    useMeasuredLCR: string;
    useMeasuredSCR: string;
    veryHigh: number;
    high: number;
    medium: number;
    low: number;
    found: number;
    damageFactor: number;
    pof: number;
    lastMeasuredYear: number;
    effectiveAge: number;
    soilInterfaceCondensation: string;
    pipeDirectBeamComplexDesign: string;
    repaintedYear: number;
    driver: string;
    coatingQuality: string;
    coatingAge: number;
    coatAdjustment: number;
    lineAge: number;
    corrosionType: string;
    externalProcess: string;
    createdBy: string;
    modifiedBy: string
}

export class TMLSummary {
    ID: string;
    equipmentNo: string;
    DMCode: string;
    TMLNo: string;
    NominalThk: string;
    Diameter: string;
    MinReqThk: string;
    LastMeasuredThk: string;
    LongTermCR: string;
    ShortTermCR: string;
    HalfLife: string;
    NextInspYear: string;
    LastInspYear: string;
}

export class POFOTDM {
    ID: string;
    equipmentNo: string;
    DMCode: string;
    Description: string;
    InitialSuceptability: string;
    SeverityIndex: string;
    VeryHigh: string;
    High: string;
    Medium: string;
    Low: string;
    Found: string;
    DamageReductionFactor: string;
    DamageFactor: string;
    POF: string;
}
export class COF {
    ID: string;
    equipmentNo: string;
    PipeClusterNo: string;
    CorrosionLoopNo: string;
    ApplicableFluid: string;
    NormalBoilingPoint: string;
    MolecularWeight: string;
    Fluid: string;
    FluidPhaseStored: string;
    FluidPhaseAtReleasedCondition: string;
    MassOfInventoryFluid: string;
    DetectionSystemRating: string;
    IsolationSystemRating: string;
    ComponentType: string;
    LengthOfComponent: string;
    MassOfFluidInComponent: string;
    InnerDiameterOfComponent: string;
    OperatingTemperature: string;
    OperatingPressure: string;
}

export class ItemMenu {
    id: string;
    code: string;
    name: string;
    path: string;
    breadCrumb: string;
    icon: string;
    parentID: string;
    displayOrder: number;
}


