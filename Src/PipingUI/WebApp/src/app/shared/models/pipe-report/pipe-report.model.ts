export class PipeReport {
    id: number;
    reportNo: string;
    workOrderNo: string;
    equipmentNo: string;
    description: string;
    fromTo: string;
    plantCode: string;
    train: string;
    pandIDNo: string;
    clusterNo: string;
    overallCOF: string;
    overallPOF: string;
    material: string;
    fluid: string;
    consequenceRank: string;
    overallCondition: string;
    overallStatus: string;
    revisedStatus: string;
    inspectionType: string;
    resultedInto: string;    
    requireRCA: string;
    rcaModel: string;
    rcaStatus: string;
    totalManHours: number;
    insulationCondition: string;
    repaintedYear: number;
    defectCode: string;
    rootCause: string;
    nominalDiameter: number;
    nominalThick: number;
    measuredThick: number;
    nextFollowUpDate: string;
    createdBy: string;
    modifiedBy: string;
    createdDate: string;
    modifiedDate: string
}

export class AddPipeReport {
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
  pipeClusterNo: string;
  corrosionLoopNo: string;
  nextInspectionDate: string;
  nextFollowDate: string;
  overallRisk: string;
  overallStatus: string;
  overallPOF: string;
  overallCOF: string;
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
  createdBy: string;
  createdDate: string;
  modifiedBy: string;
  modifiedDate: string;
  systemInfo: string
}

export class Observation {
    id: number;
    pipeMasterID: number;
    pipeReportID: number;
    equipmentNo: string;
    reportNo: string;
    observation: string;
    createdBy: string;
    modifiedBy: string;
    createdDate: string;
    modifiedDate: string
}

export class Recommendation {
    id: number;
    pipeMasterID: number;
    pipeReportID: number;
    equipmentNo: string;
    reportNo: string;
    serialNo: string;
    actionCategory: string;
    recommendedAction: string;
    targetDate: string;
    responsible: string;
    priority: string;
    woNumber: string;
    commentByActionTaker: string;
    actionUpdateDate: string;
    actionNo: string;
    modifiedTargetDate: string;
    woStatus: string;
    createdBy: string;
    modifiedBy: string;
    createdDate: string;
    modifiedDate: string;
    
}

export class TML {
      id: number;
      pipeMasterID: number;
      pipeReportID: number;
      equipmentNo: string;
      reportNo: string;
      tmlNo: string;
      corrosionType: string;
      componentType: string;
      year: number;
      nominalDiameter: number;
      nominalThick: number;
      measuredDiameter: number;
      measuredThick: number;
      lastMeasuredDiameter: number;
      lastMeasuredThick: number;
      lastMeasuredYear: number;
      remainingLife: number;
      nextInspectionDate: string;
      createdBy: string;
      modifiedBy: string;
      createdDate: string;
      modifiedDate: string
}

// export class InspectionConfidence {
//     ID: string;
//     equipmentNo: string;
//     ReportNo: string; 
//     DmCode: string;
//     Description: string;
//     Priority: string;
//     Frequency: string;
//     InspectionProgram: string;
//     Confidence:string;
//     NDTMethod: string;
//     lastInpecYear: string;
// }

export class InspectionStrategy {
    id: number;
    pipeMasterID: number;
    pipeReportID: number;
    equipmentNo: string;
    reportNo: string;
    dmCode: string;
    priority: string;
    frequency: string;
    recommendedAction: string;
    ndtMethod: string;
    inspectionYear: number;
    createdBy: string;
    modifiedBy: string;
    createdDate: string;
    modifiedDate: string
}

export class Observations {
    id: number;
    description: string;
    active: true     
}

export enum PdfReportAction {
    Open,
    Download,
    Print,    
  }

  export enum PdfReportType {
    PipeReport,
    PipeMaster,
    CorrosionStudy,    
    RiskAnalysis
  }