export class RiskSheet {
    id?: number;
    equipmentNo?: string;
    cof?: string;
    currentPOF?: number;
    currentYear?: string;
    currentPriority?: string;
    currentRisk?: string;
    currentFinancial?: number;
    currentFinancialRisk?: number;
    currentCummulativeRisk?: number;
    analysisPOF?: number;
    analysisYear?: number;
    analysisPriority?: number;
    analysisRisk?: string;
    analysisFinancial?: number;
    analysisFinancialRisk?: number;
    analysisCummulativeRisk?: number;
}

export class RiskMatrix {
    a1?: number;
    a2?: number;
    a3?: number;
    a4?: number;
    a5?: number;
    b1?: number;
    b2?: number;
    b3?: number;
    b4?: number;
    b5?: number;
    c1?: number;
    c2?: number;
    c3?: number;
    c4?: number;
    c5?: number;
    d1?: number;
    d2?: number;
    d3?: number;
    d4?: number;
    d5?: number;
    e1?: number;
    e2?: number;
    e3?: number;
    e4?: number;
    e5?: number;
}

export class RiskChart {
    equipmentID?: string[];
    cummulativeRisk?: number[];
}

export class RiskParameter {
    year?: number;
    priority?: number;
    confidence?: string;
}
