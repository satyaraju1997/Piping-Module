import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-observations-dialog',
  templateUrl: './observations-dialog.component.html',
  styleUrls: ['./observations-dialog.component.css']
})
export class ObservationsDialogComponent implements OnInit {

  observation: string;

  constructor(
    private dialogRef: MatDialogRef<ObservationsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit(): void {
    this.observation = this.data.observations;
  }

  onSelect(id) {
    this.dialogRef.close(id);
  }
}
