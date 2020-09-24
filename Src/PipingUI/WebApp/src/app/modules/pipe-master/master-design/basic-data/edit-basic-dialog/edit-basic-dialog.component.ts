import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';

@Component({
  selector: 'app-edit-basic-dialog',
  templateUrl: './edit-basic-dialog.component.html',
  styleUrls: ['./edit-basic-dialog.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class EditBasicDialogComponent implements OnInit {

  editBasicData: FormGroup;
  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<EditBasicDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private updateDataService: PipeMasterService
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.editBasicData = this.fb.group({
    id: [this.data.basicData.id],
    equipmentNo: [this.data.basicData.equipmentNo, [Validators.required]],
    description: [this.data.basicData.description],
    fromTo: [this.data.basicData.fromTo],
    pandIDNo: [this.data.basicData.pandIDNo],
    plantCode: [this.data.basicData.plantCode, [Validators.required]],
    corrosionLoopNo: [this.data.basicData.corrosionLoopNo, [Validators.required]],
    pipeClusterNo: [this.data.basicData.pipeClusterNo, [Validators.required]],
    yearInService: [this.data.basicData.yearInService, [Validators.required]],
    fluid: [this.data.basicData.fluid, [Validators.required]],
    areaCode: [this.data.basicData.areaCode],
    overallStatus: [this.data.basicData.overallStatus],
    nextInspectionDate: [this.data.basicData.nextInspectionDate],
    nextFollowDate: [this.data.basicData.nextFollowDate],
    train: [this.data.basicData.train, [Validators.required]],
    modifiedBy: [this.data.basicData.modifiedBy]
    })
  }

  onSaveData() {
    let basic_data = this.editBasicData.value;
    basic_data.id = +basic_data.id;
    basic_data.yearInService = +basic_data.yearInService;
    this.dialogRef.close(basic_data);
  }

  onCancel() {
    this.editBasicData.reset();
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
