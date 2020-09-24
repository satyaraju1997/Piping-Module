export class StructuralMinThk {
    id: number;
    componentType: string;
    outsideDiameterInches: number;
    outsideDiameterMM: number;
    structureWallThicknessMM: number;
    active: string;
    createdBy: string;
    createdDate: string;
    modifiedBy: string;
    modifiedDate: string;
    status:string;
    statusMessage:string;
}

export class LookupTable
{
    id: number;
    lookupTableName:string;
    path:string;
}