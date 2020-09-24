import { Component, OnInit, ViewChild, ViewEncapsulation, ElementRef } from '@angular/core';
import { PipeReport, Recommendation, Observation, TML } from 'src/app/shared/models/pipe-report/pipe-report.model';
import { MatTableDataSource } from '@angular/material/table';
import { Router, ActivatedRoute } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { InspectionStrategy } from 'src/app/shared/models/pipemaster/pipemaster.model';
import { PipeReportService } from 'src/app/core/http/pipe-report/pipe-report.service';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { map } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { DatePipe } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ObservationsDialogComponent } from '../observations-dialog/observations-dialog.component';
import * as moment from 'moment';
@Component({
  selector: 'app-add-pipe-report',
  templateUrl: './add-pipe-report.component.html',
  styleUrls: ['./add-pipe-report.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [DatePipe]
})
export class AddPipeReportComponent implements OnInit {

  @ViewChild('fileUpload', { static: false }) fileUpload: ElementRef;
  formData: FormData;
  pipeReport: FormGroup;
  tmlList: FormGroup;
  inspectionObservationList = [];
  inspectionConfidenceList: FormGroup;
  inspectionRecommendationList: FormGroup;
  inspectionDocumentList: FormGroup;
  inspectionProgramList = [];
  confidence = [];
  inspectionDistributionList: FormGroup;
  equipmentNo: string;
  pipeReportData: any = null;
  inspecStrategy: any;
  inspecProgram: any;
  observations: any;
  displayFileName: any = [];
  fileName: string = 'SheetJS.xlsx';
  files: File[] = [];
  isValid: boolean;
  recommendationDataSource: any;
  inspectionDataSource: any;
  observationDataSource: any;
  tmlDataSource: any;
  // observation: any;
  observDesc: string = '';
  inspecConfidence = false;

  recommendationColumns: string[] = ['slNo', 'recommendedAction', 'actionCategory', 'responsible', 'targetDate', 'woNumber', 'add'];
  inspectionColumns: string[] = ['dmCode', 'priority', 'frequency', 'program', 'ndtMethod', 'lastInspecYear', 'confidence', 'CMLNo'];
  observationColumns: string[] = ['observation', 'add'];
  tmlColumns: string[] = [
    'tmlNo',
    'corrosionType',
    'componentType',
    'nominalDiameter',
    'nominalThick',
    'lastMeasuredThick',
    'year',
    'measuredThick',
    'remainingLife',
    'nextInspectionDate',
    'add'
  ];
  observationList: Observation[] = [];
  recommendationList: Recommendation[] = [];
  tmlListData: TML[] = [];
  PipeMasterID :any;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private dialog: MatDialog,
    private addPipeReport: PipeReportService,
    private sanitizer: DomSanitizer,
    private datePipe: DatePipe,
    private snackBar: MatSnackBar,
  ) { 
    this.formData = new FormData();
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.equipmentNo = params.equipmentNo;

    });
    this.addPipeReport.addPipeReport(this.equipmentNo).subscribe(res => {
      this.pipeReportData = res;
      this.PipeMasterID = this.pipeReportData.PipeMasterID;
      if (this.pipeReportData) {
        this.initializeForm();
      }
    });

    this.getProgramList();
    this.getObservations();
    this.observationDataSource = new MatTableDataSource(this.observationList);
    this.recommendationDataSource = new MatTableDataSource(this.recommendationList);
    this.tmlDataSource = new MatTableDataSource(this.tmlListData);
  }

  getObservations() {
    this.addPipeReport.getObservations().subscribe(res => {
      this.observations = res;
    });
  }

  getProgramList() {
    this.addPipeReport.getInspectionStrategy(this.equipmentNo).subscribe((res: any) => {
      this.inspecStrategy = res;
      this.inspecProgram = res.map(data => data.recommendedAction);
      this.inspecStrategy.forEach((element, index) => {
        element['formId'] = index;
      });
      for (let i = 0; i < res.length; i++) {
        const inputData = {
          id: res[i].id,
          pipeMasterID: res[i].pipeMasterID,
          pipeReportID: res[i].pipeReportID,
          equipmentNo: res[i].equipmentNo,
          reportNo: res[i].reportNo,
          program: res[i].recommendedAction,
          createdBy: res[i].createdBy,
          modifiedBy: res[i].modifiedBy,
          createdDate: this.datePipe.transform(new Date(), 'yyyy-MM-dd'),
          modifiedDate: null
        }
        this.inspectionProgramList.push(inputData);
      }
      this.updateConfidenceList();
    });
  }

  initializeForm() {
    this.pipeReport = this.fb.group({
      id: [0],
      pipeMasterID: [this.PipeMasterID],
      reportNo: [],
      workOrderNo: [],
      equipmentNo: [this.pipeReportData.equipmentNo],
      description: [this.pipeReportData.description],
      fromTo: [this.pipeReportData.fromTo],
      parentPlantCode: [],
      plantCode: [this.pipeReportData.plantCode],
      train: [this.pipeReportData.train],
      pandIDNo: [this.pipeReportData.pandIDNo],
      clusterNo: [this.pipeReportData.pipeClusterNo],
      overallCOF: [],
      overallPOF: [],
      material: [this.pipeReportData.materialCode],
      fluid: [this.pipeReportData.fluid],
      fluidCode: [],
      unitCode: [],
      consequenceRank: [],
      overallCondition: [],
      overallStatus: [],
      revisedStatus: [],
      inspectionType: ["Preventive"],
      resultedInto: [],
      requireRCA: [],
      rcaModel: [],
      rcaStatus: [],
      totalManHours: [],
      insulationCondition: [],
      repaintedYear: [],
      defectCode: [],
      rootCause: [],
      nominalDiameter: [],
      nominalThick: [],
      measuredThick: [],
      nextFollowUpDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      inspectionYear: [],
      inspectionDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      inspectionBy: [],
      verificationDate: [],
      verificationBy: [],
      approvalDate: [],
      approvalBy: [],
      createdBy: [],
      modifiedBy: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      createdDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      modifiedDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
    });

    this.inspectionDocumentList = this.fb.group({
      id: [0],
      pipeMasterID: [this.PipeMasterID],
      pipeReportID: [],
      equipmentNo: [],
      reportNo: [],
      documentType: [],
      fileSize: [],
      fileFormat: [],
      fileName: [],
      content: [],
      active: [],
      createdBy: [],
      modifiedBy: [],
      createdDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      modifiedDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')]
    });

    this.tmlList = this.fb.group({
      id: [],
      pipeMasterID: [this.PipeMasterID],
      pipeReportID: [],
      equipmentNo: [this.pipeReportData.equipmentNo],
      reportNo: [],
      tmlNo: [],
      corrosionType: [],
      componentType: [],
      yearInService: [],
      nominalDiameter: [],
      nominalThick: [],
      measuredDiameter: [],
      measuredThick: [],
      lastMeasuredDiameter: [],
      lastMeasuredThick: [],
      lastMeasuredYear: [],
      remainingLife: [],
      nextInspectionDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      createdBy: [this.pipeReportData.createdBy],
      modifiedBy: [this.pipeReportData.modifiedBy],
      createdDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      modifiedDate: [this.pipeReportData.modifiedDate]
    });

    this.inspectionConfidenceList = this.fb.group({
      confidence: this.fb.array([])
    });

    this.inspectionRecommendationList = this.fb.group({
      id: [0],
      pipeMasterID: [this.PipeMasterID],
      pipeReportID: [],
      equipmentNo: [this.pipeReportData.equipmentNo],
      reportNo: [],
      serialNo: [],
      actionCategory: [],
      recommendedAction: [],
      targetDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      responsible: [],
      priority: [],
      woNumber: [],
      commentByActionTaker: [],
      actionUpdateDate: [],
      actionNo: [],
      modifiedTargetDate: [],
      woStatus: [],
      createdBy: [],
      modifiedBy: [],
      createdDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      modifiedDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')]
    });

    this.inspectionDistributionList = this.fb.group({
      id: [0],
      pipeMasterID: [this.PipeMasterID],
      pipeReportID: [],
      equipmentNo: [],
      reportNo: [],
      distributionStatus: [],
      occurred: [],
      distributionCode: [],
      distributionBy: [],
      remarks: [],
      phoneNo: [],
      email: [],
      createdBy: [],
      modifiedBy: [],
      createdDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
      modifiedDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')]
    })
  }

  onClickBack() {
    this.router.navigate(['/pipe-master/pipe-report']);
  }

  onAddTmL() {
    this.tmlList.getRawValue();
    const data = this.tmlDataSource.data;
    data.push(this.tmlList.getRawValue());
    this.tmlDataSource._updateChangeSubscription();
    this.tmlList.reset();
  }

  onDeleteTML(i) {
    const index = this.tmlDataSource.data[i.id];
    this.tmlDataSource.data.splice(index, 1);
    this.tmlDataSource._updateChangeSubscription();
  }

  onListClick() {
    const selectedObservation = this.dialog.open(ObservationsDialogComponent, {
      width: '500px',
      data: { observations: this.observations }
    });
    selectedObservation.afterClosed().subscribe(result => {
      if (result) {
        for (let i = 0; i < this.observations.length; i++) {
          if (result === this.observations[i].id) {
            this.observDesc = this.observations[i].description;
            const inputData = {
              id: i,
              pipeMasterID: this.PipeMasterID,
              pipeReportID: 0,
              equipmentNo: '',
              reportNo: '',
              observation: this.observations[i].description,
              createdBy: '',
              modifiedBy: '',
              createdDate: this.datePipe.transform(new Date(), 'yyyy-MM-dd'),
              modifiedDate: ''
            }
            this.inspectionObservationList.push(inputData);
          }
        }
      } else {
        return;
      }
    })
  }

  onAddObservation() {
    this.observDesc = '';
    const data = this.observationDataSource.data;
    data.push(this.inspectionObservationList[this.inspectionObservationList.length - 1]);
    this.observationDataSource._updateChangeSubscription();
  }

  onDeleteObservation(i) {
    const index = this.observationDataSource.data[i];
    this.observationDataSource.data.splice(i, 1);
    this.observationDataSource._updateChangeSubscription();
  }

  onAddRecommendation() {
    this.inspectionRecommendationList.getRawValue();
    const data = this.recommendationDataSource.data;
    data.push(this.inspectionRecommendationList.getRawValue());
    this.recommendationDataSource._updateChangeSubscription();
    this.inspectionRecommendationList.reset();
  }

  onDeleteRecommendation(i) {
    const index = this.recommendationDataSource.data[i.id];
    this.recommendationDataSource.data.splice(index, 1);
    this.recommendationDataSource._updateChangeSubscription();
  }

  updateConfidenceList() {
    if (this.inspecConfidence === false) {
      for (let i = 0; i < this.inspecStrategy.length; i++) {
        const inputData = {
          id: this.inspecStrategy[i].id,
          pipeMasterID: this.PipeMasterID,
          pipeReportID: this.inspecStrategy[i].pipeReportID,
          equipmentNo: this.inspecStrategy[i].equipmentNo,
          damageMechanism: this.inspecStrategy[i].damageMechanism,
          reportNo: this.inspecStrategy[i].reportNo,
          inspectionProgram: this.inspecStrategy[i].recommendedAction,
          frequency: this.inspecStrategy[i].frequency,
          priority: this.inspecStrategy[i].priority,
          ndtMethod: this.inspecStrategy[i].ndtMethod,
          lastInspectionYear: this.inspecStrategy[i].inspectionYear,
          createdBy: this.inspecStrategy[i].createdBy,
          modifiedBy: this.inspecStrategy[i].modifiedBy,
          createdDate: this.inspecStrategy[i].createdDate,
          modifiedDate: this.inspecStrategy[i].modifiedDate
        }
        this.confidence.push(inputData);
      }

      this.confidence.forEach((list, index) => {
        const i = index;
        (this.inspectionConfidenceList.get('confidence') as FormArray).controls.push(
          this.fb.group({
            id: this.inspecStrategy[i].id,
            pipeMasterID: this.PipeMasterID,
            pipeReportID: this.inspecStrategy[i].pipeReportID,
            equipmentNo: this.inspecStrategy[i].equipmentNo,
            damageMechanism: this.inspecStrategy[i].damageMechanism,
            reportNo: this.inspecStrategy[i].reportNo,
            inspectionProgram: this.inspecStrategy[i].recommendedAction,
            frequency: this.inspecStrategy[i].frequency,
            priority: this.inspecStrategy[i].priority,
            confidenceLevel: [''],
            cmlNo: [''],
            ndtMethod: this.inspecStrategy[i].ndtMethod,
            lastInspectionYear: this.inspecStrategy[i].inspectionYear,
            createdBy: this.inspecStrategy[i].createdBy,
            modifiedBy: this.inspecStrategy[i].modifiedBy,
            createdDate: [this.datePipe.transform(new Date(), 'yyyy-MM-dd')],
            modifiedDate: this.inspecStrategy[i].modifiedDate
          })
        )
      });
    }
    this.inspecConfidence = true;
  }

  onSubmit() {
    // const created_date = moment(createdDate).format("YYYY-MM-DD");
    let reportData = {
      'pipeReport': this.pipeReport.getRawValue(),
      'inspectionConfidenceList': this.inspectionConfidenceList.getRawValue().confidence,
    //  ,'inspectionDocumentList': this.inspectionDocumentList.getRawValue()
      'inspectionRecommendationList': this.recommendationDataSource.data,
      // ,'inspectionDistributionList': this.inspectionDistributionList.getRawValue()
      'inspectionObservationList': this.observationDataSource.data,
      'inspectionProgramList': this.inspectionProgramList,
      'tmlList': this.tmlDataSource.data
    }

    this.formData.append('PipeReportInfo', JSON.stringify(reportData));
    console.log(JSON.stringify(reportData));
    this.addPipeReport.addNewPipeReport(this.formData).subscribe(res => {
      console.log(res);
      this.onBack();
      this.snackBar.open('Successfully added ' + res.pipeReport.reportNo, '', {
        duration: 5000,
      });
    });
  }

  // File Upload
  onFileChange(event: any) {

    let files = event.dataTransfer ? event.dataTransfer.files : event.target.files;
    for (let i = 0; i < files.length; i++) {
      let file = files[i];

      if (this.validate(file)) {
        var ext = file.name.substring(file.name.lastIndexOf('.') + 1);
        file.objectURL = this.sanitizer.bypassSecurityTrustUrl((window.URL.createObjectURL(files[i])));
        this.files.push(files[i]);
        this.displayFileName.push({ id: 0, name: file.name, extension: ext, icon: 'assets/' + ext + '_icon.svg' });
      }
    }

  }


  validate(file: File) {
    var ext = file.name.substring(file.name.lastIndexOf('.') + 1);
    // for (const f of this.files) {
    // if (f.name === file.name && f.lastModified === file.lastModified && f.size === f.size) {
    //   return false
    // }

    if (ext.toLowerCase() != 'csv' && ext.toLowerCase() != 'xls' && ext.toLowerCase() != 'xlsx'
      && ext.toLowerCase() != 'pdf'
      && ext.toLowerCase() != 'doc' && ext.toLowerCase() != 'docx'
      && ext.toLowerCase() != 'jpg' && ext.toLowerCase() != 'jpeg'
      && ext.toLowerCase() != 'png' && ext.toLowerCase() != 'bmp') {
      this.isValid = true;
      return false;
    }
    else {
      this.isValid = false;
      return true;
    }
    // }

  }
  onClick(event) {
    if (this.fileUpload)
      this.fileUpload.nativeElement.click()
  }

  fileRemove(name) {
    let file = this.displayFileName.find(d => d.name === name);
    let index = this.displayFileName.findIndex(d => d.name === name);
    if (file.id === 0) {

      this.displayFileName.splice(index, 1);
    }
    else {

      this.displayFileName.splice(index, 1);
    }

  }

  onBack() {
    this.router.navigate(['/pipe-master/pipe-report'], {queryParams: {equipmentNo: this.equipmentNo}});
  }

}