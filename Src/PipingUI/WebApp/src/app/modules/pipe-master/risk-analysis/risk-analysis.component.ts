import { Component, OnInit, ViewEncapsulation, ViewChild, ElementRef } from '@angular/core';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { PipingSpreadsheet } from 'src/app/shared/models/plantfluid/plantfluid.model';
import { ChartType, ChartOptions, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { RiskAnalysisService } from 'src/app/core/http/risk-analysis/risk-analysis.service';
import { RiskChart, RiskMatrix, RiskSheet, RiskParameter } from 'src/app/shared/models/risk-analysis/risk-analysis.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import * as XLSX from 'xlsx';
import numeral from 'numeral'

const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';
@Component({
  selector: 'app-risk-analysis',
  templateUrl: './risk-analysis.component.html',
  styleUrls: ['./risk-analysis.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class RiskAnalysisComponent implements OnInit {
  analyzeForm: FormGroup;
  currentYear: any;
  analysisYear: any;

  DrivingRiskMatrixFields: any[] = [
    { label: '1', isLabel: true, cols: 1, rows: 1, border: '0px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'e1' },
    { label: 'D1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'd1' },
    { label: 'C1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'c1' },
    { label: 'B1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'b1' },
    { label: 'A1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'a1' },

    { label: '2', isLabel: true, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'e2' },
    { label: 'D2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'd2' },
    { label: 'C2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'c2' },
    { label: 'B2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'b2' },
    { label: 'A2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'a2' },

    { label: '3', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'e3' },
    { label: 'D3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'd3' },
    { label: 'C3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'c3' },
    { label: 'B3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'b3' },
    { label: 'A3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FF4E4E', field: 'a3' },

    { label: '4', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'pandIDNo' },
    { label: 'E4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'e4' },
    { label: 'D4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'd4' },
    { label: 'C4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'c4' },
    { label: 'B4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'b4' },
    { label: 'A4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'a4' },

    { label: '5', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'plantCode' },
    { label: 'E5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'e5' },
    { label: 'D5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'd5' },
    { label: 'C5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'c5' },
    { label: 'B5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'b5' },
    { label: 'A5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'a5' },

    { label: '', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'D', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'C', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'B', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'A', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' }
  ];

  ProjectedRiskMatrixFields: any[] = [
    { label: '1', isLabel: true, cols: 1, rows: 1, border: '0px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'e1' },
    { label: 'D1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'd1' },
    { label: 'C1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'c1' },
    { label: 'B1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'b1' },
    { label: 'A1', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'a1' },

    { label: '2', isLabel: true, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FFFFFF', field: '' },
    { label: 'E2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'e2' },
    { label: 'D2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#F5FE8C', field: 'd2' },
    { label: 'C2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'c2' },
    { label: 'B2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FCC1C0', field: 'b2' },
    { label: 'A2', isLabel: false, cols: 1, rows: 1, border: '2px solid #FFFFFF', color: '#FF4E4E', field: 'a2' },

    { label: '3', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'e3' },
    { label: 'D3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'd3' },
    { label: 'C3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'c3' },
    { label: 'B3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'b3' },
    { label: 'A3', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FF4E4E', field: 'a3' },

    { label: '4', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'pandIDNo' },
    { label: 'E4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'e4' },
    { label: 'D4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'd4' },
    { label: 'C4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'c4' },
    { label: 'B4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'b4' },
    { label: 'A4', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'a4' },

    { label: '5', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: 'plantCode' },
    { label: 'E5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'e5' },
    { label: 'D5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'd5' },
    { label: 'C5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#ADFFC4', field: 'c5' },
    { label: 'B5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#F5FE8C', field: 'b5' },
    { label: 'A5', isLabel: false, cols: 1, rows: 1, border: '1px solid #DBDBDB', color: '#FCC1C0', field: 'a5' },

    { label: '', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'E', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'D', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'C', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'B', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' },
    { label: 'A', isLabel: true, cols: 1, rows: 1, border: '0px solid #DBDBDB', color: '#FFFFFF', field: '' }
  ];

  
  currentRiskMatrix: RiskMatrix;
  currentRiskChart: RiskChart;
  currentRiskSheet: RiskSheet[];
  analysisRiskMatrix: RiskMatrix = null;
  analysisRiskChart: RiskChart;
  analysisRiskSheet: RiskSheet[];
  PipingSpreadsheetDataSource: any;
  PipingSpreadsheetDisplayColumns: string[] = ['equipmentNo', "cof", 'currentPOF', "currentPriority", "currentRisk", "currentFinancialRisk",  "currentCummulativeRisk", "analysisPOF", "analysisPriority", "analysisRisk","analysisFinancialRisk", "analysisCummulativeRisk"];
  currentChartLabels: Label[];
  currentChartData: any;
  analysisChartLabels: Label[];
  analysisChartData: any;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  
  @ViewChild('sheet',{ read: ElementRef }) table: ElementRef;
  lineChartType: ChartType = 'line';
  lineChartLegend = true;
  lineChartColors: any = [
    {
      borderColor: '#003D7E',
      backgroundColor: '#E5E5E5',
      fill: false,
      borderWidth: 3,
      pointRadius: 0,
    }
  ];

  // lineChartOptions: any = {

  //   responsive: true,
  //   maintainAspectRatio: true,
  //   legend: false,
  //   options: {
  //     elements: {
  //       point: {
  //         radius: 0
  //       }
  //     },
  //     scales: {
  //       yAxes: [{ 
  //         scaleLabel: {
  //           display: true,
  //           labelString: "Cummulative Risk"
  //         }
  //       }],
  //       xAxes: [{ 
  //         scaleLabel: {
  //           display: true,
  //           labelString: "Equipment Nos"
  //         }
  //       }],
  //       position: 'left',
  //       ticks: {
  //            min: 0,
  //            max: 1000000000,
  //            userCallback: function(value, index, values) {
  //             value = value.format('0.0a');
  //             return value;
  //            }
  //       },

  //         // display: true,
  //         // ticks: {
  //         //   beginAtZero: true,
  //         //   max: 60000,
  //         //   stepSize: 10000
  //         // },

  //         // gridLines: {
  //         //   display: false,

  //         //   drawBorder: false
  //         // }
  //     }
  //   }
  // };

  public lineChartOptions: any = {
    responsive: true,
    maintainAspectRatio: true,
    legend: false,
    scales: {
      xAxes: [{
        scaleLabel: {
          display: true,
          labelString: "Equipment Count"
        },
        ticks: {
          min: 0,
          max: 20,
        }
      }],
      yAxes: [{
        scaleLabel: {
          display: true,
          labelString: "Cummulative Risk (In $)"
        },
        ticks: {
          min: 0,
          callback: function (value, index, values) {
              value = numeral(value).format('0.a')
            return value
          },
      }
    }]
  }
  };

  constructor(
    private fb: FormBuilder,
    private riskAnalysisService: RiskAnalysisService
    ) {

  }

  ngOnInit(): void {



    this.riskAnalysisService.getCurrentRiskChart(0).subscribe(res => {
      this.currentRiskChart = res;
      this.currentChartLabels = this.currentRiskChart.equipmentID;
      this.currentChartData = [this.currentRiskChart.cummulativeRisk];
      this.analysisRiskChart = res;
        this.analysisChartLabels = this.analysisRiskChart.equipmentID;
        this.analysisChartData = [this.analysisRiskChart.cummulativeRisk];
    });
    
    this.riskAnalysisService.getCurrentRiskMatrix().subscribe(res => {
      this.currentRiskMatrix = res;
      this.analysisRiskMatrix = res;
    });

    this.riskAnalysisService.getCurrentRiskSheet(0).subscribe(res => {
      this.currentRiskSheet = res;
      this.PipingSpreadsheetDataSource = new MatTableDataSource(this.currentRiskSheet);
      this.PipingSpreadsheetDataSource.paginator = this.paginator;
      this.PipingSpreadsheetDataSource.sort = this.sort;
    });

    // this.riskAnalysisService.getAnalysisRiskMatrix().subscribe(res => {
    //   this.analysisRiskMatrix = res;
    // });

    this.initializeForm();
  }

  initializeForm() {
    this.currentYear = new Date().getFullYear().toString();
    this.analysisYear = new Date().getFullYear().toString();
    this.analyzeForm = this.fb.group({
      year: [this.currentYear],
      priority: ['0'],
      confidence: ['1']
    });

    this.riskAnalysisService.getCurrentRiskChart(0).subscribe(res => {
      this.currentRiskChart = res;
      this.currentChartLabels = this.currentRiskChart.equipmentID;
      this.currentChartData = [this.currentRiskChart.cummulativeRisk];
      this.analysisRiskChart = res;
        this.analysisChartLabels = this.analysisRiskChart.equipmentID;
        this.analysisChartData = [this.analysisRiskChart.cummulativeRisk];
    });
    
    this.riskAnalysisService.getCurrentRiskMatrix().subscribe(res => {
      this.currentRiskMatrix = res;
      this.analysisRiskMatrix = res;
    });

    this.riskAnalysisService.getCurrentRiskSheet(0).subscribe(res => {
      this.currentRiskSheet = res;
      this.PipingSpreadsheetDataSource = new MatTableDataSource(this.currentRiskSheet);
      this.PipingSpreadsheetDataSource.paginator = this.paginator;
      this.PipingSpreadsheetDataSource.sort = this.sort;
    });

  }

  public exportAsExcelFile(json: any[], excelFileName: string): void {
    
    // const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(json);
    // console.log('worksheet',worksheet);
    // const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    // const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
    // //const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'buffer' });
    // this.saveAsExcelFile(excelBuffer, excelFileName);
  }

  // private saveAsExcelFile(buffer: any, fileName: string): void {
  //   const data: Blob = new Blob([buffer], {
  //     type: EXCEL_TYPE
  //   });
  //   FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  // }

  exportexcel() 
    {
       /* table id is passed over here */   
      //  let element = document.getElementById('sheet'); 
       const ws: XLSX.WorkSheet =XLSX.utils.json_to_sheet(this.currentRiskSheet);

       /* generate workbook and add the worksheet */
       const wb: XLSX.WorkBook = XLSX.utils.book_new();
       XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

       /* save to file */
       XLSX.writeFile(wb, "RiskAnalysis.xlsx");			
    }

  onCancel() {
    this.initializeForm();
  }

  onAnalyze() {
    // console.log(this.analyzeForm.value);
    // this.analyzeForm = this.fb.group({
    //   year: [this.analyzeForm.value.year],
    //   priority: [this.analyzeForm.value.priority],
    //   confidence: [this.analyzeForm.value.confidence]

    // });
    

    this.analysisYear = this.analyzeForm.value.year;
    this.riskAnalysisService.analyzeRisk(this.analyzeForm.value).subscribe((res1) => {
      this.riskAnalysisService.getAnalysisRiskChart(0).subscribe(res => {
        this.analysisRiskChart = res;
        this.analysisChartLabels = this.analysisRiskChart.equipmentID;
        this.analysisChartData = [this.analysisRiskChart.cummulativeRisk];
      });

      this.riskAnalysisService.getCurrentRiskChart(0).subscribe(res => {
        this.currentRiskChart = res;
        this.currentChartLabels = this.currentRiskChart.equipmentID;
        this.currentChartData = [this.currentRiskChart.cummulativeRisk];        
      });

      this.riskAnalysisService.getAnalysisRiskSheet(0).subscribe(res => {
        this.currentRiskSheet = res;
        this.PipingSpreadsheetDataSource = new MatTableDataSource(this.currentRiskSheet);
        this.PipingSpreadsheetDataSource.paginator = this.paginator;
        this.PipingSpreadsheetDataSource.sort = this.sort;
      });
  
      this.riskAnalysisService.getAnalysisRiskMatrix().subscribe(res => {
        this.analysisRiskMatrix = res;
      });

    })
  }
}
