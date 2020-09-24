import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { LookupService } from 'src/app/core/http/lookup/lookup.service';
import { StructuralMinThk } from 'src/app/shared/models/lookup/lookup.model';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { DialogStructuralMinThkComponent } from './dialog-structural-min-thk/dialog-structural-min-thk.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { EditStructuralMinDialogComponent } from './edit-structural-min-dialog/edit-structural-min-dialog.component';

@Component({
  selector: 'app-structural-min-thk',
  templateUrl: './structural-min-thk.component.html',
  styleUrls: ['./structural-min-thk.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class StructuralMinThkComponent implements OnInit {
  masterData: any;
  dataSource: any;
  displayColumns: string[] = ['select', 'componentType', 'outsideDiameter_IN', 'outsideDiameter_MM', 'structalMinThk_MM', 'edit', 'delete'];
  structuralMinThkList: StructuralMinThk[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private lookupService: LookupService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit(): void {
    this.LoadGrid();
  }

  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
  }

  LoadGrid() {
    this.lookupService.getAllStructuralMinThkData().subscribe((res: any) => {
      this.structuralMinThkList = res;
      this.dataSource = new MatTableDataSource(this.structuralMinThkList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onAdd() {
    const addData = this.dialog.open(DialogStructuralMinThkComponent, {
      width: '540px',
    });
    addData.afterClosed().subscribe(result => {
      if(result) {
        this.lookupService.createStructuralMinThkData(result).subscribe((res: any) => {
          this.snackBar.open('Successfully updated', '', {
            duration: 5000,
          });
          this.LoadGrid();
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

  onEditData(ID) {
    this.lookupService.getStructuralMinThkData(ID).subscribe(data => {
      this.masterData = data;

      const editData = this.dialog.open(EditStructuralMinDialogComponent, {
        width: '540px',
        data: { masterData: this.masterData }
      });
      editData.afterClosed().subscribe(result => {
        if (result) {
          this.lookupService.updateStructuralMinThkData(result).subscribe((res: any) => {
            this.snackBar.open('Successfully updated', '', {
              duration: 5000,
            });
            this.LoadGrid();
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
    });
  }

}