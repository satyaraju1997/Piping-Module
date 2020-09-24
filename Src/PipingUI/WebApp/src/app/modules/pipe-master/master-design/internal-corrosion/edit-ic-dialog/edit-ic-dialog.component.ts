import { Component, OnInit, ViewEncapsulation, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';

@Component({
  selector: 'app-edit-ic-dialog',
  templateUrl: './edit-ic-dialog.component.html',
  styleUrls: ['./edit-ic-dialog.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class EditIcDialogComponent implements OnInit {

  editICData: FormGroup;

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<EditIcDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private updateDataService: PipeMasterService
    ) { }

  ngOnInit(): void {
    this.initializeForm();
    
  }

  initializeForm() {
    this.editICData = this.fb.group({
      id: [+this.data.id],
      pipeMasterID: [this.data.icData.pipeMasterID],
      equipmentNo: [this.data.icData.equipmentNo],
      injectionPoints: [(this.data.icData.injectionPoints === 'Y' ? true : false), [Validators.required]],
      effectiveCR: [this.data.icData.effectiveCR, [Validators.required]],
      damageFactor: [this.data.icData.damageFactor, [Validators.required]],
      pof: [this.data.icData.pof, [Validators.required]],
      art: [this.data.icData.art],
      strengthRatio: [this.data.icData.strengthRatio],
      theoriticalCR: [this.data.icData.theoriticalCR, [Validators.required]],
      measuredLCR: [this.data.icData.measuredLCR],
      measuredSCR: [this.data.icData.measuredSCR],
      useMeasuredLCR: [(this.data.icData.useMeasuredLCR === 'Y' ? true : false), [Validators.required]],
      useMeasuredSCR: [(this.data.icData.useMeasuredSCR === 'Y' ? true : false), [Validators.required]],
      effectiveAge: [this.data.icData.effectiveAge, [Validators.required]],
      veryHigh: [this.data.icData.veryHigh],
      high: [this.data.icData.high],
      medium: [this.data.icData.medium],
      low: [this.data.icData.low],
      lastMeasuredYear: [this.data.icData.lastMeasuredYear],
      createdBy: [this.data.icData.createdBy],
      modifiedBy: [this.data.icData.modifiedBy],
      found: [this.data.icData.found]
    })
  }

  onSaveData() {
    let ic_edit_data = this.editICData.value;
    ic_edit_data.injectionPoints = ic_edit_data.injectionPoints === true ? 'Y' : 'N';
    ic_edit_data.useMeasuredLCR = ic_edit_data.useMeasuredLCR === true ? 'Y' : 'N';
    ic_edit_data.useMeasuredSCR = ic_edit_data.useMeasuredSCR === true ? 'Y' : 'N';
    this.dialogRef.close(this.editICData.value);
  }

  onCancel() {
    this.editICData.reset();
  }
  closeDialog() {
    this.dialogRef.close();
  }

}
