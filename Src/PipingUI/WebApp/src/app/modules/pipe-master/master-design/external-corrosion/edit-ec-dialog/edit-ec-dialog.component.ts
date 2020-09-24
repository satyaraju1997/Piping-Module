import { Component, OnInit, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';

@Component({
  selector: 'app-edit-ec-dialog',
  templateUrl: './edit-ec-dialog.component.html',
  styleUrls: ['./edit-ec-dialog.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class EditEcDialogComponent implements OnInit {

  editECData: FormGroup;
  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<EditEcDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private updateDataService: PipeMasterService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.editECData = this.fb.group({
      id: [this.data.id],
      pipeMasterID: [this.data.ecData.pipeMasterID],
      equipmentNo: [this.data.ecData.equipmentNo],
      theoriticalCR: [this.data.ecData.theoriticalCR, [Validators.required]],
      effectiveCR: [this.data.ecData.effectiveCR, [Validators.required]],
      measuredLCR: [this.data.ecData.measuredLCR],
      measuredSCR: [this.data.ecData.measuredSCR],
      useMeasuredLCR: [(this.data.ecData.useMeasuredLCR === 'Y' ? true : false), [Validators.required]],
      useMeasuredSCR: [(this.data.ecData.useMeasuredSCR === 'Y' ? true : false), [Validators.required]],
      veryHigh: [this.data.ecData.veryHigh],
      high: [this.data.ecData.high],
      medium: [this.data.ecData.medium],
      low: [this.data.ecData.low],
      found: [this.data.ecData.found],
      damageFactor: [this.data.ecData.damageFactor, [Validators.required]],
      pof: [this.data.ecData.pof, [Validators.required]],
      art: [this.data.ecData.art],
      strengthRatio: [this.data.ecData.strengthRatio],
      lastMeasuredYear: [this.data.ecData.lastMeasuredYear, [Validators.required]],
      effectiveAge: [this.data.ecData.effectiveAge, [Validators.required]],
      soilInterfaceCondensation: [(this.data.ecData.soilInterfaceCondensation === 'Y' ? true : false), [Validators.required]],
      pipeDirectBeamComplexDesign: [(this.data.ecData.pipeDirectBeamComplexDesign === 'Y' ? true : false), [Validators.required]],
      repaintedYear: [this.data.ecData.repaintedYear, [Validators.required]],
      driver: [this.data.ecData.driver, [Validators.required]],
      coatingQuality: [this.data.ecData.coatingQuality, [Validators.required]],
      coatingAge: [this.data.ecData.coatingAge, [Validators.required]],
      coatAdjustment: [this.data.ecData.coatAdjustment, [Validators.required]],
      lineAge: [this.data.ecData.lineAge, [Validators.required]],
      corrosionType: [this.data.ecData.corrosionType, [Validators.required]],
      externalProcess: [this.data.ecData.externalProcess, [Validators.required]],
      suceptability: [this.data.ecData.suceptability],
      adjustedSuceptability: [this.data.ecData.adjustedSuceptability],
      createdBy: [this.data.ecData.createdBy],
      modifiedBy: [this.data.ecData.modifiedBy]
    })
  }

  onSaveData() {
    
    let ec_edit_data = this.editECData.value;
    ec_edit_data.soilInterfaceCondensation = ec_edit_data.soilInterfaceCondensation === true ? 'Y' : 'N';
    ec_edit_data.pipeDirectBeamComplexDesign = ec_edit_data.pipeDirectBeamComplexDesign === true ? 'Y' : 'N';
    ec_edit_data.useMeasuredLCR = ec_edit_data.useMeasuredLCR === true ? 'Y' : 'N';
    ec_edit_data.useMeasuredSCR = ec_edit_data.useMeasuredSCR === true ? 'Y' : 'N';
    ec_edit_data.id = +ec_edit_data.id;
    this.dialogRef.close(this.editECData.value);
  }

  onCancel() {
    this.editECData.reset();
  }

  closeDialog() {
    this.dialogRef.close();
  }

}
