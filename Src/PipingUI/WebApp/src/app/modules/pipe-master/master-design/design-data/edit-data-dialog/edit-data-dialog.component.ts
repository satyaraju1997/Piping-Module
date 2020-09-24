import { Component, OnInit, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';


@Component({
  selector: 'app-edit-data-dialog',
  templateUrl: './edit-data-dialog.component.html',
  styleUrls: ['./edit-data-dialog.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class EditDataDialogComponent implements OnInit {

  editData: FormGroup;
  materialCodes: any;
  insulationTypes: any;
  materialGradeOptions: any;
  materialStdOptions: any;

  constructor(
    private fb: FormBuilder,
    private designDataService: PipeMasterService,
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<EditDataDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private updateDataService: PipeMasterService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
    this.materialCodeList();
    this.insulationTypeList();
    this.materialStdList();
    this.materialGradeList();
  }

  initializeForm() {
    this.editData = this.fb.group({
      id: [this.data.designData.id],
      designTemperature: [this.data.designData.designTemperature, [Validators.required]],
      designPressure: [this.data.designData.designPressure, [Validators.required]],
      operatingTemperature: [this.data.designData.operatingTemperature, [Validators.required]],
      operatingPressure: [this.data.designData.operatingPressure, [Validators.required]],
      pwht: [(this.data.designData.pwht === 'Y' ? true : false), [Validators.required]],
      materialCode: [this.data.designData.materialCode, [Validators.required]],
      materialStd: [this.data.designData.materialStd, [Validators.required]],
      materialGrade: [this.data.designData.materialGrade, [Validators.required]],
      pipeSpec: [this.data.designData.pipeSpec],
      nominalDiameter: [this.data.designData.nominalDiameter, [Validators.required]],
      nominalThick: [this.data.designData.nominalThick, [Validators.required]],
      length: [this.data.designData.length],
      jointEfficiency: [this.data.designData.jointEfficiency, [Validators.required]],
      insulated: [(this.data.designData.insulated === 'Y' ? true : false), [Validators.required]],
      insulationType: [this.data.designData.insulationType],
      corrosionAllowance: [this.data.designData.corrosionAllowance, [Validators.required]],
      mdmt: [this.data.designData.mdmt],
      constructionCode: [this.data.designData.constructionCode],
      modifiedBy: [''],

      allowableStressMPA_S: [this.data.designData.allowableStressMPA_S, [Validators.required]],
      yieldStrengthMPA_YS: [this.data.designData.yieldStrengthMPA_YS, [Validators.required]],
      tensileStrengthMPA_TS: [this.data.designData.tensileStrengthMPA_TS, [Validators.required]],
      flowStress_FS: [this.data.designData.flowStress_FS, [Validators.required]],
      stengthRatio_SR: [this.data.designData.stengthRatio_SR, [Validators.required]],
     
      lastMeasuredThick_LMT: [this.data.designData.lastMeasuredThick_LMT],
      lastMeasuredYear_LMY: [this.data.designData.lastMeasuredYear_LMY],
      prMinReqThkInternal_PMTI: [this.data.designData.prMinReqThkInternal_PMTI],
      // prMinReqThkExternal_PMTE: [this.data.designData.prMinReqThkExternal_PMTE],
      userCalPrMinReqThk_UMT: [this.data.designData.userCalPrMinReqThk_UMT],
      structuralMinThk_SMT: [this.data.designData.structuralMinThk_SMT, [Validators.required]],
      effectiveMinReqThk_EMRT: [this.data.designData.effectiveMinReqThk_EMRT, [Validators.required]],
      effectiveThk_ETHK: [this.data.designData.effectiveThk_ETHK, [Validators.required]],
      minReqThkOption_MRTO: [this.data.designData.minReqThkOption_MRTO, [Validators.required]],
      useLastMeasuredThick_ULMT: [(this.data.designData.useLastMeasuredThick_ULMT === 'Y' ? true : false)]
    })
  }
  
  materialCodeList() {
    this.designDataService.getMaterialCodesList().subscribe(res => {
      this.materialCodes = res;
    })
  }

  insulationTypeList() {
    this.designDataService.getInsulationTypes().subscribe(res => {
      this.insulationTypes = res;
    })
  }

  materialStdList() {
    this.designDataService.getMaterialStdList().subscribe(res => {
      this.materialStdOptions = res;
    })
  }

  materialGradeList() {
    this.designDataService.getMaterialGradeList().subscribe(res => {
      this.materialGradeOptions = res;
    })
  }

  onSaveData() {
    let design_edit_data = this.editData.value;
    design_edit_data.pwht = design_edit_data.pwht === true ? 'Y' : 'N';
    design_edit_data.insulated = design_edit_data.insulated === true ? 'Y' : 'N';
    design_edit_data.useLastMeasuredThick_ULMT = design_edit_data.useLastMeasuredThick_ULMT === true ? 'Y' : 'N';
    this.dialogRef.close(design_edit_data);
  }

  onCancel() {
    this.editData.reset();
    this.initializeForm();

  }
  closeDialog() {
    this.dialogRef.close();
  }
}