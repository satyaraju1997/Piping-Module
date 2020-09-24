import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-cof-dialog',
  templateUrl: './edit-cof-dialog.component.html',
  styleUrls: ['./edit-cof-dialog.component.css']
})
export class EditCofDialogComponent implements OnInit {

  constructor(
    public dialog: MatDialog,
    private dialogRef: MatDialogRef<EditCofDialogComponent>,
  ) { }

  ngOnInit(): void {
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
