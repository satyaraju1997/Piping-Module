export class PipeReport {
    ID: string;
    equipmentNo: string;
    ReportNo: string;    
    Criticality: string;
    Status: string;
    DefectCode: string;
    History:string;      
}

export class Observation {
    ID: string;
    equipmentNo: string;
    ReportNo: string;    
    SlNo: string;
    Observation: string;
    InsulationCondition: string;
    Repainted:string;      
}

export class Recommendation {
    ID: string;
    equipmentNo: string;
    ReportNo: string;    
    SlNo: string;
    Recommendation: string;
    Priority: string;
    Responsible:string; 
    TargetDate: string;
    WOnumber:string;     
    
}

export class TML {
    ID: string;
    equipmentNo: string;
    ReportNo: string;    
    TMLNo: string;
    CorrosionType: string;
    NominalDiameter: string;
    NominalThick:string; 
    MinReqThick: string;
    MeasuredThick:string;
    ComponentType:string;
}

export class InspectionConfidence {
    ID: string;
    equipmentNo: string;
    ReportNo: string; 
    DmCode: string;
    Description: string;
    Priority: string;
    Frequency: string;
    InspectionProgram: string;
    Confidence:string;
    NDTMethod: string;
    lastInpecYear: string;
}