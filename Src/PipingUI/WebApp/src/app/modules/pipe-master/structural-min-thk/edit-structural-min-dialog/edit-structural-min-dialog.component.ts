import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-structural-min-dialog',
  templateUrl: './edit-structural-min-dialog.component.html',
  styleUrls: ['./edit-structural-min-dialog.component.css']
})
export class EditStructuralMinDialogComponent implements OnInit {

  editData: FormGroup;
  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<EditStructuralMinDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit(): void {
    this.getMasterData(this.data.masterData.id);
  }

  getMasterData(ID) {
    this.editData = this.fb.group({
      id: [ID],
      componentType: [this.data.masterData.componentType, [Validators.required, Validators.maxLength(50)]],
      outsideDiameterInches: [this.data.masterData.outsideDiameterInches, [Validators.required]],
      outsideDiameterMM: [this.data.masterData.outsideDiameterMM, [Validators.required]],
      structureWallThicknessMM: [this.data.masterData.structureWallThicknessMM, [Validators.required]],
      active: [this.data.masterData.active],
      createdBy: [this.data.masterData.createdBy],
      modifiedBy: [this.data.masterData.modifiedBy]
    })
  }

  onSubmit() {
    let edit_dialog_data = this.editData.value;
    edit_dialog_data.outsideDiameterInches = +edit_dialog_data.outsideDiameterInches;
    edit_dialog_data.outsideDiameterMM = +edit_dialog_data.outsideDiameterMM;
    edit_dialog_data.structureWallThicknessMM = +edit_dialog_data.structureWallThicknessMM;
    this.dialogRef.close(edit_dialog_data);
  }

  closeDialog() {
    this.dialogRef.close();
  }

  onCancel() {
    this.editData.reset();
  }
  
}
