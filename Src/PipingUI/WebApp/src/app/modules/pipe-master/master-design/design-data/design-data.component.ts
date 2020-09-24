import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';
import { DesignData, DocumentMaster } from 'src/app/shared/models/pipemaster/pipemaster.model';
import { MatTableDataSource } from '@angular/material/table';
import { PipeMasterService } from 'src/app/core/http/pipe-master/pipe-master.service';
import { MatDialog } from '@angular/material/dialog';
import { EditDataDialogComponent } from './edit-data-dialog/edit-data-dialog.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-design-data',
  templateUrl: './design-data.component.html',
  styleUrls: ['./design-data.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class DesignDataComponent implements OnInit {

  @Input() unitID;
  designData: any;
  materialCodes: any;

  designDataSource: any;
  IsEditDesignData: any = false;
  designDisplayedColumns: string[] = ['documentNo', 'description', 'format', 'edit'];

  documentList: DocumentMaster[] = [
    { "ID": "1", "equipmentNo": "P01.AL1001", "documentNo": "01-001", "description": "Isometric-1", "format": "png" },
    { "ID": "2", "equipmentNo": "P01.AL1001", "documentNo": "101.1101", "description": "Summary Report", "format": "word" }
  ];

  EditDesignData() {
    // this.IsEditDesignData = true;
  }
  constructor(
    private designDataService: PipeMasterService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private updateDataService: PipeMasterService
  ) { }

  ngOnChanges() {
    this.getDesignData(this.unitID);
  }

  ngOnInit(): void {
    this.getDesignData(this.unitID);
  }

  getDesignData(unitID) {
    this.designDataSource = new MatTableDataSource(this.documentList);
    this.designDataService.getDesignData(this.unitID).subscribe(data => {
      this.designData = data;
    });
  }

  onEditData() {
    const editData = this.dialog.open(EditDataDialogComponent, {
      width: '850px',
      data: { designData: this.designData }
    });
    editData.afterClosed().subscribe(result => {
      if (result) {
        this.updateDataService.updateDesignData(result).subscribe((res: any) => {
          this.snackBar.open('Successfully updated', '', {
            duration: 5000,
          });
          this.getDesignData(this.unitID);
        }, (error) => {
          switch (error.status) {
            case 415:
              this.snackBar.open('Unable to update', '', {
                duration: 5000,
              });
              break;
          }
        }
        )
      } else {
        return;
      }
    })
  }
}
