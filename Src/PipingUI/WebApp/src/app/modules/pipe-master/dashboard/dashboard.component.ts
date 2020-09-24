import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { PipingSpreadsheet } from 'src/app/shared/models/plantfluid/plantfluid.model';
import { ChartType, ChartOptions, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class DashboardComponent implements OnInit {

  doughnutChartLabels: Label[] = ['Over Due for Inspection', 'Good', 'Acceptable', 'Poor', 'Low Critical', 'Not Due'];
  doughnutChartData = [
    [30, 60, 60, 200, 200, 800]
  ];
  doughnutChartType: ChartType = 'doughnut';
  doughnutChartColors: any = [
    {
      backgroundColor: ['#9E572F', '#71B63B', '#F39E1D', '#E01F1F', '#89DAF3', '#1F6332']
    }
  ];

  doughnutChartOptions: any = {
    responsive: true,
    maintainAspectRatio: true,
    legend: {
      position: 'bottom',
      labels: {
        fontFamily: 'Open Sans',
        fontSize: 12,
      }
    }
  };

  public bubbleChartOptions: ChartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    legend: {
      position: 'bottom',
      labels: {
        fontFamily: 'Open Sans',
        fontSize: 12,
      }
    },
    scales: {
      xAxes: [{
        ticks: {
          min: 0,
          // max: 20,
          callback: value => this.bubbleChartLabels[value]
        }
      }],
      yAxes: [{
        scaleLabel: {
          display: true,
          labelString: "Pipe Lines"
        },
        ticks: {
          min: 0,
          max: 30,
        }
      }]
    }
  };
  public bubbleChartType: ChartType = 'bubble';
  public bubbleChartLegend = true;

  public bubbleChartData: ChartDataSets[] = [
    {
      data:[
        {x: 1, y: 11, r: 15},
        {x: 2, y: 16, r: 10},
        {x: 3, y: 6, r: 18},
        {x: 4, y: 17, r: 25},
      ],
      label:'Flanges',
      backgroundColor:'#0094DB',
      hoverBackgroundColor:'#0094DB'
    },
    {
      data:[
        {x: 5, y: 23, r: 15},
        {x: 6, y: 17, r: 20},
        {x: 7, y: 21, r: 10},
        {x: 8, y: 16, r: 12}
      ],
      label:'Weld Defects',
      backgroundColor:'#DE3100',
      hoverBackgroundColor:'#DE3100'
    }
  ];

  bubbleChartLabels: Label[] = ['Ammonia 01', 'Ammonia 02', 'Ammonia 03', 'Ammonia 04', 'Ammonia 05', 'Ammonia 06', 'Ammonia 07', 'Ammonia 08', 'Ammonia 09']

  PipingSpreadsheetDataSource: any; 
  PipingSpreadsheetDisplayColumns: string[] = ['equipmentNo', 'ReportNo', 'Criticality', 'Status', 'DefectCode', 'History',"Mail"];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  PipingSpreadsheetList: PipingSpreadsheet[] = [
    { "ID": "1", "equipmentNo": "P01.AL101", "ReportNo": "730/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "2", "equipmentNo": "P01.AL102", "ReportNo": "731/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "3", "equipmentNo": "P01.AL103", "ReportNo": "732/20", "Criticality": "Medium", "Status": "High", "DefectCode": "7345", "History": "View" },
    { "ID": "4", "equipmentNo": "P01.AL104", "ReportNo": "733/20", "Criticality": "High", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "1", "equipmentNo": "P01.AL101", "ReportNo": "730/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "2", "equipmentNo": "P01.AL102", "ReportNo": "731/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "3", "equipmentNo": "P01.AL103", "ReportNo": "732/20", "Criticality": "Medium", "Status": "High", "DefectCode": "7345", "History": "View" },
    { "ID": "4", "equipmentNo": "P01.AL104", "ReportNo": "733/20", "Criticality": "High", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "1", "equipmentNo": "P01.AL101", "ReportNo": "730/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "2", "equipmentNo": "P01.AL102", "ReportNo": "731/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "3", "equipmentNo": "P01.AL103", "ReportNo": "732/20", "Criticality": "Medium", "Status": "High", "DefectCode": "7345", "History": "View" },
    { "ID": "4", "equipmentNo": "P01.AL104", "ReportNo": "733/20", "Criticality": "High", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "1", "equipmentNo": "P01.AL101", "ReportNo": "730/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "2", "equipmentNo": "P01.AL102", "ReportNo": "731/20", "Criticality": "Low", "Status": "Poor", "DefectCode": "7345", "History": "View" },
    { "ID": "3", "equipmentNo": "P01.AL103", "ReportNo": "732/20", "Criticality": "Medium", "Status": "High", "DefectCode": "7345", "History": "View" },
    { "ID": "4", "equipmentNo": "P01.AL104", "ReportNo": "733/20", "Criticality": "High", "Status": "Poor", "DefectCode": "7345", "History": "View" }
  ];

  MatrixData: any = {"A1":"367","A2":"254","A3":"777","A4":"50","A5":"34",
  "B1":"58","B2":"170","B3":"768","B4":"50","B5":"34",
  "C1":"88","C2":"17","C3":"403","C4":"50","C5":"34",
  "D1":"224","D2":"7","D3":"592","D4":"50","D5":"34",
  "E1":"40","E2":"3","E3":"952","E4":"50","E5":"34"
};

  MatrixFields: any[] = [
    { label: '1', isLabel: true, cols: 1, rows: 1, border: '0px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'E1' },
    { label: 'D1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'D1' },
    { label: 'C1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'C1' },
    { label: 'B1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'B1' },
    { label: 'A1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'A1' },

    { label: '2', isLabel: true, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'E2' },
    { label: 'D2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'D2' },
    { label: 'C2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'C2' },
    { label: 'B2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'B2' },
    { label: 'A2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'A2' },

    { label: '3', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'E3' },
    { label: 'D3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'D3' },
    { label: 'C3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'C3' },
    { label: 'B3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'B3' },
    { label: 'A3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FF4E4E', field: 'A3' },

    { label: '4', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'pandIDNo' },
    { label: 'E4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'E4' },
    { label: 'D4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'D4' },
    { label: 'C4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'C4' },
    { label: 'B4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'B4' },
    { label: 'A4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'A4' },

    { label: '5', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'plantCode' },
    { label: 'E5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'E5' },
    { label: 'D5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'D5' },
    { label: 'C5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'C5' },
    { label: 'B5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'B5' },
    { label: 'A5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'A5' },

    { label: '', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'D', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'C', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'B', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'A', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' }
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
