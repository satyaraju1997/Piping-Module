import { Component, OnInit, ViewEncapsulation, Inject, ViewChild, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl, ValidatorFn } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { LookupService } from 'src/app/core/http/lookup/lookup.service';
import { MatInput } from '@angular/material/input';
import { AlertService } from 'src/app/shared/services/alert.service';
@Component({
  selector: 'app-dialog-structural-min-thk',
  templateUrl: './dialog-structural-min-thk.component.html',
  styleUrls: ['./dialog-structural-min-thk.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DialogStructuralMinThkComponent implements OnInit {

  addData: FormGroup;
  title: string;
  id: any;
  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<DialogStructuralMinThkComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private lookupService: LookupService,
    private alertService: AlertService,
  ) { }

  ngOnInit(): void {
      this.initializeForm();
  }

  initializeForm() {
    this.addData = this.fb.group({
      id: [0],
      componentType: ['', [Validators.required, Validators.maxLength(50)]],
      outsideDiameterInches: [0, [Validators.required]],
      outsideDiameterMM: [0, [Validators.required]],
      structureWallThicknessMM: [0, [Validators.required]],
      active: [true],
      createdBy: ['SYSADMIN'],
      modifiedBy: ['SYSADMIN']
    })
  }

  // ngAfterViewInit() {
  //   if (this.inputComponentType) this.inputComponentType.nativeElement.focus();
  // }

  onSubmit() {

    let add_dialog_data = this.addData.value;
    add_dialog_data.outsideDiameterInches = +add_dialog_data.outsideDiameterInches;
    add_dialog_data.outsideDiameterMM = +add_dialog_data.outsideDiameterMM;
    add_dialog_data.structureWallThicknessMM = +add_dialog_data.structureWallThicknessMM;
    this.dialogRef.close(add_dialog_data);

    if (add_dialog_data) {
      this.addData.controls['createdBy'].setValue("SYSADMIN");
      this.addData.controls['modifiedBy'].setValue("SYSADMIN");
      this.dialogRef.close(add_dialog_data);
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }

  onCancel() {
    this.addData.reset();
  }
}
