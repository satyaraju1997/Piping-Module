import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { PipingSpreadsheet } from 'src/app/shared/models/plantfluid/plantfluid.model';

@Component({
  selector: 'app-inspection-program',
  templateUrl: './inspection-program.component.html',
  styleUrls: ['./inspection-program.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class InspectionProgramComponent implements OnInit {

  DrivingRiskMatrixData: any = {"A1":"367","A2":"254","A3":"777","A4":"50","A5":"34",
  "B1":"58","B2":"170","B3":"768","B4":"50","B5":"34",
  "C1":"88","C2":"17","C3":"403","C4":"50","C5":"34",
  "D1":"224","D2":"7","D3":"592","D4":"50","D5":"34",
  "E1":"40","E2":"3","E3":"952","E4":"50","E5":"34"
};

DrivingRiskMatrixFields: any[] = [
    { label: '1', isLabel: true, cols: 1, rows: 1, border: '0px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'E1' },
    { label: 'D1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'D1' },
    { label: 'C1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'C1' },
    { label: 'B1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'B1' },
    { label: 'A1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'A1' },

    { label: '2', isLabel: true, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'yellow', field: 'E2' },
    { label: 'D2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'yellow', field: 'D2' },
    { label: 'C2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'C2' },
    { label: 'B2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'B2' },
    { label: 'A2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'A2' },

    { label: '3', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'E3' },
    { label: 'D3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'D3' },
    { label: 'C3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'C3' },
    { label: 'B3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'pink', field: 'B3' },
    { label: 'A3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'red', field: 'A3' },

    { label: '4', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'pandIDNo' },
    { label: 'E4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'E4' },
    { label: 'D4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'D4' },
    { label: 'C4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'C4' },
    { label: 'B4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'B4' },
    { label: 'A4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'pink', field: 'A4' },

    { label: '5', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'plantCode' },
    { label: 'E5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'E5' },
    { label: 'D5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'D5' },
    { label: 'C5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'C5' },
    { label: 'B5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'B5' },
    { label: 'A5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'pink', field: 'A5' },

    { label: '', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'D', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'C', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'B', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'A', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' }
  ];

  ProjectedRiskMatrixData: any = {"A1":"367","A2":"254","A3":"777","A4":"50","A5":"34",
  "B1":"58","B2":"170","B3":"768","B4":"50","B5":"34",
  "C1":"88","C2":"17","C3":"403","C4":"50","C5":"34",
  "D1":"224","D2":"7","D3":"592","D4":"50","D5":"34",
  "E1":"40","E2":"3","E3":"952","E4":"50","E5":"34"
};

ProjectedRiskMatrixFields: any[] = [
    { label: '1', isLabel: true, cols: 1, rows: 1, border: '0px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'E1' },
    { label: 'D1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'D1' },
    { label: 'C1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'C1' },
    { label: 'B1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'B1' },
    { label: 'A1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'A1' },

    { label: '2', isLabel: true, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'yellow', field: 'E2' },
    { label: 'D2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'yellow', field: 'D2' },
    { label: 'C2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'C2' },
    { label: 'B2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'pink', field: 'B2' },
    { label: 'A2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: 'red', field: 'A2' },

    { label: '3', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'E3' },
    { label: 'D3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'D3' },
    { label: 'C3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'C3' },
    { label: 'B3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'pink', field: 'B3' },
    { label: 'A3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'red', field: 'A3' },

    { label: '4', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'pandIDNo' },
    { label: 'E4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'E4' },
    { label: 'D4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'D4' },
    { label: 'C4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'C4' },
    { label: 'B4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'B4' },
    { label: 'A4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'pink', field: 'A4' },

    { label: '5', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'plantCode' },
    { label: 'E5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'E5' },
    { label: 'D5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'D5' },
    { label: 'C5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'green', field: 'C5' },
    { label: 'B5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'yellow', field: 'B5' },
    { label: 'A5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: 'pink', field: 'A5' },

    { label: '', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'D', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'C', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'B', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'A', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' }
  ];

  PipingSpreadsheetDataSource: any; 
  PipingSpreadsheetDisplayColumns: string[] = ['equipmentNo', 'ReportNo', 'Criticality', 'Status', 'DefectCode', 'History',"Mail"];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  PipingSpreadsheetList: PipingSpreadsheet[] = [
    { "ID": "1", "equipmentNo": "P01.AL101", "ReportNo": "730/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "2", "equipmentNo": "P01.AL102", "ReportNo": "731/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "3", "equipmentNo": "P01.AL103", "ReportNo": "732/20", "Criticality": "Meduium", "Status": "High", "DefectCode": "7345", "History": "View" },
    { "ID": "4", "equipmentNo": "P01.AL104", "ReportNo": "733/20", "Criticality": "High", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "1", "equipmentNo": "P01.AL101", "ReportNo": "730/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "2", "equipmentNo": "P01.AL102", "ReportNo": "731/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "3", "equipmentNo": "P01.AL103", "ReportNo": "732/20", "Criticality": "Meduium", "Status": "High", "DefectCode": "7345", "History": "View" },
    { "ID": "4", "equipmentNo": "P01.AL104", "ReportNo": "733/20", "Criticality": "High", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "1", "equipmentNo": "P01.AL101", "ReportNo": "730/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "2", "equipmentNo": "P01.AL102", "ReportNo": "731/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" }
    
  ];

  constructor() { }

  ngOnInit(): void {
    this.PipingSpreadsheetDataSource = new MatTableDataSource(this.PipingSpreadsheetList);
  }

 ngAfterViewInit() {
    this.PipingSpreadsheetDataSource.paginator = this.paginator;
    this.PipingSpreadsheetDataSource.sort = this.sort;
  }


}
