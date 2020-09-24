import { Component, OnInit, ElementRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { DomSanitizer } from '@angular/platform-browser';
import { PipeReportService } from 'src/app/core/http/pipe-report/pipe-report.service';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { TML, Recommendation, Observation } from 'src/app/shared/models/pipe-report/pipe-report.model';
import { DatePipe } from '@angular/common';
import { ObservationsDialogComponent } from '../observations-dialog/observations-dialog.component';

@Component({
  selector: 'app-edit-pipe-report',
  templateUrl: './edit-pipe-report.component.html',
  styleUrls: ['./edit-pipe-report.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [DatePipe]
})
export class EditPipeReportComponent implements OnInit {

  @ViewChild('fileUpload', { static: false }) fileUpload: ElementRef;

  formData: FormData;
  pipeReport: FormGroup;
  tmlList: FormGroup;
  inspectionObservationList = [];
  inspectionConfidenceList: FormGroup;
  inspectionRecommendationList: FormGroup;
  inspectionDocumentList: FormGroup;
  editReport;
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
  confidenceList = [];
  
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
  reportData: any;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private dialog: MatDialog,
    private datePipe: DatePipe,
    private editPipeReport: PipeReportService,
    private sanitizer: DomSanitizer
  ) { 
    this.formData = new FormData();
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.editReport = params.reportNo;
      this.equipmentNo = params.equipmentNo;
    });    

    this.editPipeReport.getDataByReportNo(this.editReport).subscribe(res => {
      console.log(res);
      this.pipeReportData = res;
      this.reportData = this.pipeReportData.pipeReport;
      this.inspecProgram = this.pipeReportData.inspectionProgramList;
      this.tmlListData = this.pipeReportData.tmlList;
      this.observationList = this.pipeReportData.inspectionObservationList;
      this.recommendationList = this.pipeReportData.inspectionRecommendationList;
      this.confidenceList = this.pipeReportData.inspectionConfidenceList;

      this.confidenceList.forEach((element, index) => {
        element['formId'] = index;
      });

      this.observationDataSource = new MatTableDataSource(this.observationList);
      this.recommendationDataSource = new MatTableDataSource(this.recommendationList);
      this.tmlDataSource = new MatTableDataSource(this.tmlListData);

      if (this.pipeReportData) {
        this.initializeForm();
        this.updateConfidenceList();
      }
    });
    this.getObservations();
  }

  getObservations() {
    this.editPipeReport.getObservations().subscribe(res => {
      this.observations = res;
    });
  }

  initializeForm() {
    this.pipeReport = this.fb.group({
      id: [this.reportData.id],
      pipeMasterID: [this.reportData.pipeMasterID],
      reportNo: [this.reportData.reportNo],
      workOrderNo: [this.reportData.workOrderNo],
      equipmentNo: [this.reportData.equipmentNo],
      description: [this.reportData.description],
      fromTo: [this.reportData.fromTo],
      parentPlantCode: [this.reportData.parentPlantCode],
      plantCode: [this.reportData.plantCode],
      train: [this.reportData.train],
      pandIDNo: [this.reportData.pandIDNo],
      clusterNo: [this.reportData.pipeClusterNo],
      overallCOF: [this.reportData.overallCOF],
      overallPOF: [this.reportData.overallPOF],
      material: [this.reportData.material],
      fluid: [this.reportData.fluid],
      fluidCode: [this.reportData.fluidCode],
      unitCode: [this.reportData.unitCode],
      consequenceRank: [this.reportData.consequenceRank],
      overallCondition: [this.reportData.overallCondition],
      overallStatus: [this.reportData.overallStatus],
      revisedStatus: [this.reportData.revisedStatus],
      inspectionType: [this.reportData.inspectionType],
      resultedInto: [this.reportData.resultedInto],
      requireRCA: [this.reportData.requireRCA],
      rcaModel: [this.reportData.rcaModel],
      rcaStatus: [this.reportData.rcaStatus],
      totalManHours: [this.reportData.totalManHours],
      insulationCondition: [this.reportData.insulationCondition],
      repaintedYear: [this.reportData.repaintedYear],
      defectCode: [this.reportData.defectCode],
      rootCause: [this.reportData.rootCause],
      nominalDiameter: [this.reportData.nominalDiameter],
      nominalThick: [this.reportData.nominalThick],
      measuredThick: [this.reportData.measuredThick],
      nextFollowUpDate: [this.reportData.nextFollowUpDate],
      inspectionYear: [this.reportData.inspectionYear],
      inspectionDate: [this.reportData.inspectionDate],
      inspectionBy: [this.reportData.inspectionBy],
      verificationDate: [this.reportData.verificationDate],
      verificationBy: [this.reportData.verificationBy],
      approvalDate: [this.reportData.approvalDate],
      approvalBy: [this.reportData.approvalBy],
      createdBy: [this.reportData.createdBy],
      modifiedBy: [this.reportData.modifiedBy],
      createdDate: [this.reportData.createdDate],
      modifiedDate: [this.reportData.modifiedDate]
    });

    this.inspectionDocumentList = this.fb.group({
      id: [],
      pipeMasterID: [],
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
      createdDate: [],
      modifiedDate: []
    });

    this.tmlList = this.fb.group({
      id: [],
      pipeMasterID: [],
      pipeReportID: [],
      equipmentNo: [],
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
      nextInspectionDate: [],
      createdBy: [],
      modifiedBy: [],
      createdDate: [],
      modifiedDate: []
    });

    this.inspectionConfidenceList = this.fb.group({
      confidence: this.fb.array([])
    });

    this.inspectionRecommendationList = this.fb.group({
      id: [],
      pipeMasterID: [],
      pipeReportID: [],
      equipmentNo: [],
      reportNo: [],
      serialNo: [],
      actionCategory: [],
      recommendedAction: [],
      targetDate: [],
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
      createdDate: [],
      modifiedDate: []
    });

    this.inspectionDistributionList = this.fb.group({
      id: [],
      pipeMasterID: [],
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
      createdDate: [],
      modifiedDate: []
    });
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
    const index = this.tmlDataSource.data[i];
    this.tmlDataSource.data.splice(index, -1);
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
              id: this.pipeReportData.id,
              pipeMasterID: 1,
              pipeReportID: 1,
              equipmentNo: '',
              reportNo: '',
              observation: this.observations[i].description,
              createdBy: '',
              modifiedBy: '',
              createdDate: '',
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

  onAddRecommendation() {
    this.inspectionRecommendationList.getRawValue();
    const data = this.recommendationDataSource.data;
    data.push(this.inspectionRecommendationList.getRawValue());
    this.recommendationDataSource._updateChangeSubscription();
    this.inspectionRecommendationList.reset();
  }

  updateConfidenceList() {
    if (this.inspecConfidence === false) {
      this.confidenceList.forEach((list, index) => {
        const i = index; 
        (this.inspectionConfidenceList.get('confidence') as FormArray).controls.push(
          this.fb.group({
            id: this.confidenceList[i].id,
            pipeMasterID: this.confidenceList[i].pipeMasterID,
            pipeReportID: this.confidenceList[i].pipeReportID,
            equipmentNo: this.confidenceList[i].equipmentNo,
            damageMechanism: this.confidenceList[i].damageMechanism,
            reportNo: this.confidenceList[i].reportNo,
            inspectionProgram: this.confidenceList[i].inspectionProgram,
            frequency: this.confidenceList[i].frequency,
            priority: this.confidenceList[i].priority,
            confidenceLevel: this.confidenceList[i].confidenceLevel,
            cmlNo: this.confidenceList[i].cmlNo,
            ndtMethod: this.confidenceList[i].ndtMethod,
            lastInspectionYear: this.confidenceList[i].lastInspectionYear,
            createdBy: this.confidenceList[i].createdBy,
            modifiedBy: this.confidenceList[i].modifiedBy,
            createdDate: this.confidenceList[i].createdDate,
            modifiedDate: this.confidenceList[i].modifiedDate
          })
        )
      });
    }
    this.inspecConfidence = true;
  }

  onSubmit() {
    const dateInput = new Date().toISOString().substring(0, 10);
    this.pipeReport.controls['nextFollowUpDate'].setValue(dateInput);
    this.tmlList.controls['nextInspectionDate'].setValue(dateInput);
    this.inspectionRecommendationList.controls['targetDate'].setValue(dateInput);
    let inputData = {
      'pipeReport': this.pipeReport.getRawValue(),
      'inspectionConfidenceList': this.inspectionConfidenceList.getRawValue().confidence,
      'inspectionDocumentList': null,
      // 'inspectionDocumentList': this.inspectionDocumentList.getRawValue(),
      'inspectionRecommendationList': this.recommendationDataSource.data,
      // 'inspectionDistributionList': this.inspectionDistributionList.getRawValue(),
      'inspectionDistributionList': null,
      'inspectionObservationList': this.observationDataSource.data,
      'inspectionProgramList': this.inspectionProgramList,
      'tmlList': this.tmlDataSource.data
    }
    this.formData.append('PipeReportInfo', JSON.stringify(inputData));
    this.editPipeReport.updatePipereport(this.formData).subscribe(res => {
      console.log(res);
    })
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
