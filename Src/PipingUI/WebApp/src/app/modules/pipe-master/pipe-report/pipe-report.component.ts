import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { PipeReport } from 'src/app/shared/models/pipe-report/pipe-report.model';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import {  Observation, Recommendation, TML,PdfReportAction, PdfReportType } from 'src/app/shared/models/pipe-report/pipe-report.model';
import { Router, ActivatedRoute } from '@angular/router';
import { PipeReportService } from 'src/app/core/http/pipe-report/pipe-report.service';
import { PdfReportService } from 'src/app/shared/services/pdf-report.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-pipe-report',
  templateUrl: './pipe-report.component.html',
  styleUrls: ['./pipe-report.component.css'],
  // encapsulation: ViewEncapsulation.None
})
export class PipeReportComponent implements OnInit {
  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  equipmentNo: string;
  pipeReportList: any;
  reportNo: any;
  PipingReportDisplayColumns: string[] = ['select','equipmentNo', 'ReportNo','FromTo','Rank', 'Condition', 'Status',  'Followup', 'Result'];
  panelOpenState = false;
  observationDataSource: any;
  tmlDataSource: any;
  PipingReportDataSource: any;
  inspectionColumns: string[] = ['dmCode', 'priority', 'frequency', 'program','confidence', 'add'];
  observationColumns: string[] = ['SlNo', 'Observation', 'InsulationCondition', 'Repainted', 'add'];
  tmlColumns:string[] = ['TMLNo', 'CorrosionType', 'NominalDiameter', 'NominalThick','MinReqThick','MeasuredThick', 'add'];

  observationList: Observation[] = [];

  recommendationList: Recommendation[] = [];
  tmlList: TML[] = [];

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private viewPipeReport: PipeReportService,
    private addPipeReport: PipeReportService,
    private pdfReport: PdfReportService
  ) { }

  ngOnInit(): void {
    
    this.route.queryParams.subscribe((params) => {
      this.equipmentNo = params.equipmentNo;
    });
    this.viewPipeReport.getPipeReportList(this.equipmentNo).subscribe(res => {     
      this.pipeReportList = res;
      this.PipingReportDataSource = new MatTableDataSource(this.pipeReportList);
    })
    this.observationDataSource = new MatTableDataSource(this.observationList);
   
    this.tmlDataSource = new MatTableDataSource(this.tmlList);
  }

  
  ngAfterViewInit() {
  }

  onCheckRecord(reportNo) {
    this.reportNo = reportNo;
  }

  onAdd() {
    this.router.navigate(['/pipe-master/add-pipe-report'], {queryParams: {equipmentNo: this.equipmentNo}});
  }

  onEdit() {
    let pipeReportNo;
    let equipmentNo;
    for (let i = 0; i < this.pipeReportList.length; i++) {
      if (this.reportNo && (this.reportNo === this.pipeReportList[i].reportNo)) {
        pipeReportNo = this.reportNo;
        equipmentNo = this.pipeReportList[i].equipmentNo;
        // localStorage.setItem('pipeReportData', JSON.stringify(this.pipeReportList[i]));
      }
    }
    this.router.navigate(['/pipe-master/edit-pipe-report'], { queryParams: { reportNo: pipeReportNo, equipmentNo: equipmentNo } });
  }

  onDownload(){
    let pipeReportNo;
    let equipmentNo;
    for (let i = 0; i < this.pipeReportList.length; i++) {
      if (this.reportNo && (this.reportNo === this.pipeReportList[i].reportNo)) {
        pipeReportNo = this.reportNo;
        equipmentNo = this.pipeReportList[i].equipmentNo;
        localStorage.setItem('pipeReportData', JSON.stringify(this.pipeReportList[i]));
      }
    }
    this.pdfReport.generatePdfReport(pipeReportNo,PdfReportType.PipeReport, PdfReportAction.Open);   
   }

   onPrint(){
    let pipeReportNo;
    let equipmentNo;
    for (let i = 0; i < this.pipeReportList.length; i++) {
      if (this.reportNo && (this.reportNo === this.pipeReportList[i].reportNo)) {
        pipeReportNo = this.reportNo;
        equipmentNo = this.pipeReportList[i].equipmentNo;
        localStorage.setItem('pipeReportData', JSON.stringify(this.pipeReportList[i]));
      }
    }
    this.pdfReport.generatePdfReport(pipeReportNo,PdfReportType.PipeReport, PdfReportAction.Print);   
   }

}
